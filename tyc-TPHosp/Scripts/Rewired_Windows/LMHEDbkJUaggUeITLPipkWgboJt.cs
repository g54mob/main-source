using System;
using System.Globalization;

internal class LMHEDbkJUaggUeITLPipkWgboJt : Exception
{
	private idVfiiFRzAukcbNWHToMNNCddpvE UJRiMHvbnutBEGKgKUgnStkBtPY;

	public llpFqWliQEfHkPmCCWtyJDAPdFG ResultCode => UJRiMHvbnutBEGKgKUgnStkBtPY.Result;

	public idVfiiFRzAukcbNWHToMNNCddpvE Descriptor => UJRiMHvbnutBEGKgKUgnStkBtPY;

	public LMHEDbkJUaggUeITLPipkWgboJt()
		: base("A SharpDX exception occurred.")
	{
		UJRiMHvbnutBEGKgKUgnStkBtPY = idVfiiFRzAukcbNWHToMNNCddpvE.SnXWYarLWHAxUNNKUUfbiwNydPi(llpFqWliQEfHkPmCCWtyJDAPdFG.kHFmoPnpsJxcKVqEXHVFvqCJicD);
		base.HResult = (int)llpFqWliQEfHkPmCCWtyJDAPdFG.kHFmoPnpsJxcKVqEXHVFvqCJicD;
	}

	public LMHEDbkJUaggUeITLPipkWgboJt(llpFqWliQEfHkPmCCWtyJDAPdFG result)
		: this(idVfiiFRzAukcbNWHToMNNCddpvE.SnXWYarLWHAxUNNKUUfbiwNydPi(result))
	{
		base.HResult = (int)result;
	}

	public LMHEDbkJUaggUeITLPipkWgboJt(idVfiiFRzAukcbNWHToMNNCddpvE descriptor)
		: base(descriptor.ToString())
	{
		UJRiMHvbnutBEGKgKUgnStkBtPY = descriptor;
		base.HResult = (int)descriptor.Result;
	}

	public LMHEDbkJUaggUeITLPipkWgboJt(llpFqWliQEfHkPmCCWtyJDAPdFG result, string message)
		: base(message)
	{
		UJRiMHvbnutBEGKgKUgnStkBtPY = idVfiiFRzAukcbNWHToMNNCddpvE.SnXWYarLWHAxUNNKUUfbiwNydPi(result);
		base.HResult = (int)result;
	}

	public LMHEDbkJUaggUeITLPipkWgboJt(llpFqWliQEfHkPmCCWtyJDAPdFG result, string message, params object[] args)
		: base(string.Format(CultureInfo.InvariantCulture, message, args))
	{
		UJRiMHvbnutBEGKgKUgnStkBtPY = idVfiiFRzAukcbNWHToMNNCddpvE.SnXWYarLWHAxUNNKUUfbiwNydPi(result);
		base.HResult = (int)result;
	}

	public LMHEDbkJUaggUeITLPipkWgboJt(string message, params object[] args)
		: this(llpFqWliQEfHkPmCCWtyJDAPdFG.kHFmoPnpsJxcKVqEXHVFvqCJicD, message, args)
	{
	}

	public LMHEDbkJUaggUeITLPipkWgboJt(string message, Exception innerException, params object[] args)
		: base(string.Format(CultureInfo.InvariantCulture, message, args), innerException)
	{
		UJRiMHvbnutBEGKgKUgnStkBtPY = idVfiiFRzAukcbNWHToMNNCddpvE.SnXWYarLWHAxUNNKUUfbiwNydPi(llpFqWliQEfHkPmCCWtyJDAPdFG.kHFmoPnpsJxcKVqEXHVFvqCJicD);
		base.HResult = (int)llpFqWliQEfHkPmCCWtyJDAPdFG.kHFmoPnpsJxcKVqEXHVFvqCJicD;
	}
}
