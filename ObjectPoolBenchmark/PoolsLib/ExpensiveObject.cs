namespace PoolsLib;

public class ExpensiveObject
{
    public int Data { get; set; }
    //80Kb (80 * 1024 bytes). Array size + it's other expenses less than LOH required size
    private byte[] Buffer { get; set; }

    public ExpensiveObject()
    {
        Data = new Random().Next();
        Buffer = new byte[80 * 1024]; // 80 KB
        
        for (int i = 0; i < Buffer.Length; i++)
        {
            Buffer[i] = (byte)(i % 256);
        }
    }

    public void Reset()
    {
        Data = 0;
        Array.Clear(Buffer, 0, Buffer.Length);
    }
}