using Rewired.Utils;

internal class ysnwtpITiSKXwTPsZzjcMXDqELRC : QMOnNQLQBaPaSwFdrzJOgltgCTkfA
{
	public readonly int VIgzZxiWPqPFPHOplyOchLvmYaYy;

	public readonly int gnAgOkYluDORZDsUoSbPSQyguPhJ;

	public readonly int KFQTmDlAqryAAbakYqYvMPREKpfJ;

	public readonly int uCWxAdVXIvpAnKbPZGDwGDyXjWwf;

	public readonly int vwBzHejASmRnaSPJHfpLTRjjDJKD;

	public readonly int aFntOaNjjmyXCjHyvkvMGZelZCfi;

	public readonly uint PKgBYjJrOuBcnxesWFFqQRVTQDDd;

	public readonly uint hjdNcHOGHljchuFOffTjhzxFulJw;

	public readonly int gQJaujghGvBbHdcOsMjySSbVWzY;

	private readonly int tzijuYbCbgjQXAmzPmvkTneAnKlHb;

	public uint IpowQrWgAKWJbohdrclSaosMreNB;

	public int bHhKLBYReRMVzLmXXVGCAnLNQrgi
	{
		get
		{
			if (IpowQrWgAKWJbohdrclSaosMreNB < VIgzZxiWPqPFPHOplyOchLvmYaYy || IpowQrWgAKWJbohdrclSaosMreNB > gnAgOkYluDORZDsUoSbPSQyguPhJ)
			{
				return -1;
			}
			int num = (int)((IpowQrWgAKWJbohdrclSaosMreNB - VIgzZxiWPqPFPHOplyOchLvmYaYy) / tzijuYbCbgjQXAmzPmvkTneAnKlHb * 4500);
			if (num >= 36000)
			{
				num = 0;
			}
			return num;
		}
	}

	public ysnwtpITiSKXwTPsZzjcMXDqELRC(byte P_0, ushort P_1, ushort P_2, int P_3, int P_4, int P_5, int P_6, int P_7, int P_8, uint P_9, uint P_10, int P_11)
		: base(P_0, P_1, P_2, P_3, P_4)
	{
		VIgzZxiWPqPFPHOplyOchLvmYaYy = P_5;
		gnAgOkYluDORZDsUoSbPSQyguPhJ = P_6;
		PKgBYjJrOuBcnxesWFFqQRVTQDDd = P_9;
		hjdNcHOGHljchuFOffTjhzxFulJw = P_10;
		gQJaujghGvBbHdcOsMjySSbVWzY = P_11;
		KFQTmDlAqryAAbakYqYvMPREKpfJ = P_5 - 1;
		if (KFQTmDlAqryAAbakYqYvMPREKpfJ < 0)
		{
			KFQTmDlAqryAAbakYqYvMPREKpfJ = P_6 + 1;
		}
		aFntOaNjjmyXCjHyvkvMGZelZCfi = -1;
		int num = P_6 - P_5 + 1;
		tzijuYbCbgjQXAmzPmvkTneAnKlHb = MathTools.Clamp(num / 8, 1, int.MaxValue);
		PNnwosyJbZAkbwObisgdtMytZJol();
	}

	public override void PNnwosyJbZAkbwObisgdtMytZJol()
	{
		IpowQrWgAKWJbohdrclSaosMreNB = (uint)KFQTmDlAqryAAbakYqYvMPREKpfJ;
	}
}
