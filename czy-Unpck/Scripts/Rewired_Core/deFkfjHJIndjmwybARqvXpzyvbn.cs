using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
internal struct deFkfjHJIndjmwybARqvXpzyvbn
{
	[FieldOffset(0)]
	public int OIPYdeiAtjrgmUOEAKGdQjUXXZz;

	[FieldOffset(0)]
	public float VlYIlGajNcGszIOIaHnUWsGNPwm;

	public deFkfjHJIndjmwybARqvXpzyvbn(int item)
	{
		VlYIlGajNcGszIOIaHnUWsGNPwm = 0f;
		OIPYdeiAtjrgmUOEAKGdQjUXXZz = item;
	}

	public deFkfjHJIndjmwybARqvXpzyvbn(float item)
	{
		OIPYdeiAtjrgmUOEAKGdQjUXXZz = 0;
		VlYIlGajNcGszIOIaHnUWsGNPwm = item;
	}

	public static implicit operator int(deFkfjHJIndjmwybARqvXpzyvbn obj)
	{
		return obj.OIPYdeiAtjrgmUOEAKGdQjUXXZz;
	}

	public static implicit operator float(deFkfjHJIndjmwybARqvXpzyvbn obj)
	{
		return obj.VlYIlGajNcGszIOIaHnUWsGNPwm;
	}

	public static implicit operator deFkfjHJIndjmwybARqvXpzyvbn(int obj)
	{
		return new deFkfjHJIndjmwybARqvXpzyvbn(obj);
	}

	public static implicit operator deFkfjHJIndjmwybARqvXpzyvbn(float obj)
	{
		return new deFkfjHJIndjmwybARqvXpzyvbn(obj);
	}
}
