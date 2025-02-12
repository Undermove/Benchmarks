import http from 'k6/http';
import { group, sleep } from 'k6';

export let options = {
    stages: [
        { duration: '30s', target: 50 },
        { duration: '1m', target: 50 },
        { duration: '30s', target: 0 },
    ],
    thresholds: {
        http_req_duration: ['p(95)<500'],
    },
};

const BASE_URL = 'http://localhost:5062';

export default function () {
    let key = 'key_' + __VU + '_' + __ITER;

    group('SimpleCache', () => {
        let res = http.request('GET', `${BASE_URL}/simplecache?key=${key}`, {
            headers: { 'Content-Type': 'application/json' },
        });
        if (res.status !== 200) {
            console.error('SimpleCache error: ' + res.status);
        }
    });

    sleep(1);
}
