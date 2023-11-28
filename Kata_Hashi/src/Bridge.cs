namespace Kata_Hashi;

public class Bridge(int code1, int code2, int value)
{
    public readonly Island Island1 = new(code1);
    public readonly Island Island2 = new(code2);
    public readonly int Value = value;
}