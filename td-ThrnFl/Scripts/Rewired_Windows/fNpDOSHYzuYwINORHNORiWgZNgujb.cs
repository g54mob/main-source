using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class fNpDOSHYzuYwINORHNORiWgZNgujb
{
	[CompilerGenerated]
	private DateTime KxpMsKUgMsLCZhKOGFHcBMklUTZuA;

	[CompilerGenerated]
	private WeakReference jXqEeErTorNqPNBHXRVXKGDhuVt;

	[CompilerGenerated]
	private string ijuptLyLzGryBkIKHSTwqjWsHrqI;

	public DateTime cjxORUyUInIoiVUrplXPMaKKAUjj
	{
		[CompilerGenerated]
		get
		{
			return KxpMsKUgMsLCZhKOGFHcBMklUTZuA;
		}
		[CompilerGenerated]
		private set
		{
			KxpMsKUgMsLCZhKOGFHcBMklUTZuA = kxpMsKUgMsLCZhKOGFHcBMklUTZuA;
		}
	}

	public WeakReference xaZSuSLVKFlkBBeudNiTIadkWxs
	{
		[CompilerGenerated]
		get
		{
			return jXqEeErTorNqPNBHXRVXKGDhuVt;
		}
		[CompilerGenerated]
		private set
		{
			jXqEeErTorNqPNBHXRVXKGDhuVt = weakReference;
		}
	}

	public string tUqMMqgilmhQunVKUBCVfqtNduJoA
	{
		[CompilerGenerated]
		get
		{
			return ijuptLyLzGryBkIKHSTwqjWsHrqI;
		}
		[CompilerGenerated]
		private set
		{
			ijuptLyLzGryBkIKHSTwqjWsHrqI = text;
		}
	}

	public bool yDOOGqukMomCCMMlUGblqJfiAwJw => xaZSuSLVKFlkBBeudNiTIadkWxs.IsAlive;

	public fNpDOSHYzuYwINORHNORiWgZNgujb(DateTime P_0, MSoQGDbwmmEgYqaQEfOTqzjYuOHC P_1, string P_2)
	{
		cjxORUyUInIoiVUrplXPMaKKAUjj = P_0;
		xaZSuSLVKFlkBBeudNiTIadkWxs = new WeakReference(P_1, trackResurrection: true);
		tUqMMqgilmhQunVKUBCVfqtNduJoA = P_2;
	}

	public virtual string KCCMWVCIoRJQMvrkSrTIQqeLyJbe()
	{
		if (!(xaZSuSLVKFlkBBeudNiTIadkWxs.Target is MSoQGDbwmmEgYqaQEfOTqzjYuOHC mSoQGDbwmmEgYqaQEfOTqzjYuOHC))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", mSoQGDbwmmEgYqaQEfOTqzjYuOHC.odpdeHVpSKtJOjaxhiXZmqovsVjq.ToInt64(), mSoQGDbwmmEgYqaQEfOTqzjYuOHC.GetType().FullName, cjxORUyUInIoiVUrplXPMaKKAUjj, tUqMMqgilmhQunVKUBCVfqtNduJoA).AppendLine();
		return stringBuilder.ToString();
	}
}
