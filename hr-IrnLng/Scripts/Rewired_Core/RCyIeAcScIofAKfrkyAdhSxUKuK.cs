using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
internal struct RCyIeAcScIofAKfrkyAdhSxUKuK
{
	[FieldOffset(0)]
	public int oIaGVvfPjMJdYbsCfcvdJkbTtaYr;

	[FieldOffset(0)]
	public float fldmGDRRLDtBHaRUMMwEqlnzqvX;

	public RCyIeAcScIofAKfrkyAdhSxUKuK(int item)
	{
		fldmGDRRLDtBHaRUMMwEqlnzqvX = 0f;
		oIaGVvfPjMJdYbsCfcvdJkbTtaYr = item;
	}

	public RCyIeAcScIofAKfrkyAdhSxUKuK(float item)
	{
		oIaGVvfPjMJdYbsCfcvdJkbTtaYr = 0;
		fldmGDRRLDtBHaRUMMwEqlnzqvX = item;
	}

	public static implicit operator int(RCyIeAcScIofAKfrkyAdhSxUKuK obj)
	{
		return obj.oIaGVvfPjMJdYbsCfcvdJkbTtaYr;
	}

	public static implicit operator float(RCyIeAcScIofAKfrkyAdhSxUKuK obj)
	{
		return obj.fldmGDRRLDtBHaRUMMwEqlnzqvX;
	}

	public static implicit operator RCyIeAcScIofAKfrkyAdhSxUKuK(int obj)
	{
		return new RCyIeAcScIofAKfrkyAdhSxUKuK(obj);
	}

	public static implicit operator RCyIeAcScIofAKfrkyAdhSxUKuK(float obj)
	{
		return new RCyIeAcScIofAKfrkyAdhSxUKuK(obj);
	}
}
