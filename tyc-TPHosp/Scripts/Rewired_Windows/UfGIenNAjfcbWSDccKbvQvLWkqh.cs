using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct UfGIenNAjfcbWSDccKbvQvLWkqh
{
	private const int cdSOIAgjuzBUFdFRrlhvIqdGMjQo = 65534;

	private const int JWpYRqvWYhbXpJKubsZxdvqeoFV = 16776960;

	private int ekXOSmKgiYUeZoQYDsSVYIMIKUy;

	public qLlbkJgSwnsGlOrbhfONlbVdJMjX Flags => (qLlbkJgSwnsGlOrbhfONlbVdJMjX)(ekXOSmKgiYUeZoQYDsSVYIMIKUy & -16776961);

	public int InstanceNumber => (ekXOSmKgiYUeZoQYDsSVYIMIKUy >> 8) & 0xFFFF;

	public UfGIenNAjfcbWSDccKbvQvLWkqh(qLlbkJgSwnsGlOrbhfONlbVdJMjX typeFlags, int instanceNumber)
	{
		this = default(UfGIenNAjfcbWSDccKbvQvLWkqh);
		ekXOSmKgiYUeZoQYDsSVYIMIKUy = (int)(typeFlags & ~qLlbkJgSwnsGlOrbhfONlbVdJMjX.yMginoaLxvArajJIqWxtbhwTQJx) | ((!(instanceNumber < 0 || instanceNumber > 65534)) ? ((instanceNumber & 0xFFFF) << 8) : 0);
	}

	public static explicit operator int(UfGIenNAjfcbWSDccKbvQvLWkqh type)
	{
		return type.ekXOSmKgiYUeZoQYDsSVYIMIKUy;
	}

	public bool lpfGDOSkHRGqZKIqCGEaicWfABrw(UfGIenNAjfcbWSDccKbvQvLWkqh P_0)
	{
		return P_0.ekXOSmKgiYUeZoQYDsSVYIMIKUy == ekXOSmKgiYUeZoQYDsSVYIMIKUy;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(UfGIenNAjfcbWSDccKbvQvLWkqh))
		{
			return false;
		}
		return lpfGDOSkHRGqZKIqCGEaicWfABrw((UfGIenNAjfcbWSDccKbvQvLWkqh)obj);
	}

	public override int GetHashCode()
	{
		return ekXOSmKgiYUeZoQYDsSVYIMIKUy;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", new object[3] { Flags, InstanceNumber, ekXOSmKgiYUeZoQYDsSVYIMIKUy });
	}
}
