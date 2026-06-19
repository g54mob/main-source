using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
internal struct vIAxrSRutHHlKLKXzybedQfwSDa
{
	[FieldOffset(0)]
	public int AtCpsPqXKROQCfagvWtskiAZxym;

	[FieldOffset(0)]
	public float VLsVdAusIYSFclcZQWXkyWFXkz;

	public vIAxrSRutHHlKLKXzybedQfwSDa(int item)
	{
		VLsVdAusIYSFclcZQWXkyWFXkz = 0f;
		AtCpsPqXKROQCfagvWtskiAZxym = item;
	}

	public vIAxrSRutHHlKLKXzybedQfwSDa(float item)
	{
		AtCpsPqXKROQCfagvWtskiAZxym = 0;
		VLsVdAusIYSFclcZQWXkyWFXkz = item;
	}

	public static implicit operator int(vIAxrSRutHHlKLKXzybedQfwSDa obj)
	{
		return obj.AtCpsPqXKROQCfagvWtskiAZxym;
	}

	public static implicit operator float(vIAxrSRutHHlKLKXzybedQfwSDa obj)
	{
		return obj.VLsVdAusIYSFclcZQWXkyWFXkz;
	}

	public static implicit operator vIAxrSRutHHlKLKXzybedQfwSDa(int obj)
	{
		return new vIAxrSRutHHlKLKXzybedQfwSDa(obj);
	}

	public static implicit operator vIAxrSRutHHlKLKXzybedQfwSDa(float obj)
	{
		return new vIAxrSRutHHlKLKXzybedQfwSDa(obj);
	}
}
