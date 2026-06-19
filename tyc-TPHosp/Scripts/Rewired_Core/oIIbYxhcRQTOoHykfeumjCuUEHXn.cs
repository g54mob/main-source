using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
internal struct oIIbYxhcRQTOoHykfeumjCuUEHXn
{
	[FieldOffset(0)]
	public long oOViPvSeokUxOQBijGgKkbzwLHD;

	[FieldOffset(0)]
	public double OamWJIREoxpGELdtwrmHsIPTjWE;

	public oIIbYxhcRQTOoHykfeumjCuUEHXn(long item)
	{
		oOViPvSeokUxOQBijGgKkbzwLHD = 0L;
		OamWJIREoxpGELdtwrmHsIPTjWE = item;
	}

	public oIIbYxhcRQTOoHykfeumjCuUEHXn(double item)
	{
		oOViPvSeokUxOQBijGgKkbzwLHD = 0L;
		OamWJIREoxpGELdtwrmHsIPTjWE = item;
	}

	public static implicit operator long(oIIbYxhcRQTOoHykfeumjCuUEHXn obj)
	{
		return obj.oOViPvSeokUxOQBijGgKkbzwLHD;
	}

	public static implicit operator double(oIIbYxhcRQTOoHykfeumjCuUEHXn obj)
	{
		return obj.OamWJIREoxpGELdtwrmHsIPTjWE;
	}

	public static implicit operator oIIbYxhcRQTOoHykfeumjCuUEHXn(long obj)
	{
		return new oIIbYxhcRQTOoHykfeumjCuUEHXn(obj);
	}

	public static implicit operator oIIbYxhcRQTOoHykfeumjCuUEHXn(double obj)
	{
		return new oIIbYxhcRQTOoHykfeumjCuUEHXn(obj);
	}
}
