using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct XahColKIioNyOrcJVpcAjxEhJink
{
	private const int flxaJPzoWcYsmjXwEPxGHKlLlBK = 65534;

	private const int UiUzmdqdwkVMWpfmAbvCWmVjHtJ = 16776960;

	private int bYskAdDRIXiwgUlKeakktobFWos;

	public pYDUQtFWywMKELdMLkqFCiEuGzi Flags => (pYDUQtFWywMKELdMLkqFCiEuGzi)(bYskAdDRIXiwgUlKeakktobFWos & -16776961);

	public int InstanceNumber => (bYskAdDRIXiwgUlKeakktobFWos >> 8) & 0xFFFF;

	public XahColKIioNyOrcJVpcAjxEhJink(pYDUQtFWywMKELdMLkqFCiEuGzi typeFlags, int instanceNumber)
	{
		this = default(XahColKIioNyOrcJVpcAjxEhJink);
		bYskAdDRIXiwgUlKeakktobFWos = (int)(typeFlags & ~pYDUQtFWywMKELdMLkqFCiEuGzi.vgNuKhdRbopODNVDFxuIEgEOHOhe) | ((!(instanceNumber < 0 || instanceNumber > 65534)) ? ((instanceNumber & 0xFFFF) << 8) : 0);
	}

	public static explicit operator int(XahColKIioNyOrcJVpcAjxEhJink type)
	{
		return type.bYskAdDRIXiwgUlKeakktobFWos;
	}

	public bool sDUAvZTXlEIwugPidIgHPcnkQFr(XahColKIioNyOrcJVpcAjxEhJink P_0)
	{
		return P_0.bYskAdDRIXiwgUlKeakktobFWos == bYskAdDRIXiwgUlKeakktobFWos;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(XahColKIioNyOrcJVpcAjxEhJink))
		{
			return false;
		}
		return sDUAvZTXlEIwugPidIgHPcnkQFr((XahColKIioNyOrcJVpcAjxEhJink)obj);
	}

	public override int GetHashCode()
	{
		return bYskAdDRIXiwgUlKeakktobFWos;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", new object[3] { Flags, InstanceNumber, bYskAdDRIXiwgUlKeakktobFWos });
	}
}
