using MessagePack;

[MessagePackObject(false)]
public class ResourceStateDto
{
	[Key(0)]
	public double Players;

	[Key(1)]
	public double Money;

	[Key(2)]
	public double MoneyLifetime;

	[Key(3)]
	public int Nodes;

	[Key(4)]
	public float Load;

	[Key(5)]
	public float Uptime;

	[Key(6)]
	public float Ping;

	[Key(7)]
	public float Bugs;

	[Key(8)]
	public float Hype;

	[Key(9)]
	public float TargetHype;

	[Key(10)]
	public double MoneySpend;
}
