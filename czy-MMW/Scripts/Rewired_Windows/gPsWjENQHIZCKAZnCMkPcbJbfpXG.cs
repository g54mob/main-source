using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout((LayoutKind)0, Size = 4)]
internal struct gPsWjENQHIZCKAZnCMkPcbJbfpXG
{
	private int AvLaambnyQHuhNNFjavmuhqSrJBbA;

	public UZXqahMfdCepAdfDNKUfbPnbUVDIc SSKbqaHTsdHnXFaeBStVuCKuyFvFc => (UZXqahMfdCepAdfDNKUfbPnbUVDIc)(AvLaambnyQHuhNNFjavmuhqSrJBbA & -16776961);

	public int KhjeFruRAxTAlOoUTAetUGTfJnjL => (AvLaambnyQHuhNNFjavmuhqSrJBbA >> 8) & 0xFFFF;

	public bool GlrnsPQwjXNuOXoWXyMqpMbaAHNk(gPsWjENQHIZCKAZnCMkPcbJbfpXG P_0)
	{
		return P_0.AvLaambnyQHuhNNFjavmuhqSrJBbA == AvLaambnyQHuhNNFjavmuhqSrJBbA;
	}

	public bool UXHcHWfnsGQvnodYHifKjnaAiFYeB(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(gPsWjENQHIZCKAZnCMkPcbJbfpXG))
		{
			return false;
		}
		return GlrnsPQwjXNuOXoWXyMqpMbaAHNk((gPsWjENQHIZCKAZnCMkPcbJbfpXG)P_0);
	}

	public int QwxIZRPFSixoqnXdQFtbKcVxPQuH()
	{
		return AvLaambnyQHuhNNFjavmuhqSrJBbA;
	}

	public string CrOtVtJkerEdzqcYPuZAwmrgzsnE()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", SSKbqaHTsdHnXFaeBStVuCKuyFvFc, KhjeFruRAxTAlOoUTAetUGTfJnjL, AvLaambnyQHuhNNFjavmuhqSrJBbA);
	}
}
