using System;
using System.Globalization;
using Rewired.Libraries.SharpDX;

internal class ZaTrePujSOBIfuqTlTtZUAAZPrQ : Exception
{
	private ResultDescriptor YZBdBcjSzKtHqAFOavgLqQZlNmr;

	public hbpFHugbKyodFCJCiZcKFruzcGvs ResultCode
	{
		get
		{
			return YZBdBcjSzKtHqAFOavgLqQZlNmr.Result;
		}
	}

	public ResultDescriptor Descriptor
	{
		get
		{
			return YZBdBcjSzKtHqAFOavgLqQZlNmr;
		}
	}

	public ZaTrePujSOBIfuqTlTtZUAAZPrQ()
		: base("A SharpDX exception occurred.")
	{
		YZBdBcjSzKtHqAFOavgLqQZlNmr = ResultDescriptor.Find(hbpFHugbKyodFCJCiZcKFruzcGvs.mwBxXjlFurjQdRZMzjjlJPyjMtq);
		base.HResult = (int)hbpFHugbKyodFCJCiZcKFruzcGvs.mwBxXjlFurjQdRZMzjjlJPyjMtq;
	}

	public ZaTrePujSOBIfuqTlTtZUAAZPrQ(hbpFHugbKyodFCJCiZcKFruzcGvs result)
		: this(ResultDescriptor.Find(result))
	{
		base.HResult = (int)result;
	}

	public ZaTrePujSOBIfuqTlTtZUAAZPrQ(ResultDescriptor descriptor)
		: base(descriptor.ToString())
	{
		YZBdBcjSzKtHqAFOavgLqQZlNmr = descriptor;
		base.HResult = (int)descriptor.Result;
	}

	public ZaTrePujSOBIfuqTlTtZUAAZPrQ(hbpFHugbKyodFCJCiZcKFruzcGvs result, string message)
		: base(message)
	{
		YZBdBcjSzKtHqAFOavgLqQZlNmr = ResultDescriptor.Find(result);
		base.HResult = (int)result;
	}

	public ZaTrePujSOBIfuqTlTtZUAAZPrQ(hbpFHugbKyodFCJCiZcKFruzcGvs result, string message, params object[] args)
		: base(string.Format(CultureInfo.InvariantCulture, message, args))
	{
		YZBdBcjSzKtHqAFOavgLqQZlNmr = ResultDescriptor.Find(result);
		base.HResult = (int)result;
	}

	public ZaTrePujSOBIfuqTlTtZUAAZPrQ(string message, params object[] args)
		: this(hbpFHugbKyodFCJCiZcKFruzcGvs.mwBxXjlFurjQdRZMzjjlJPyjMtq, message, args)
	{
	}

	public ZaTrePujSOBIfuqTlTtZUAAZPrQ(string message, Exception innerException, params object[] args)
		: base(string.Format(CultureInfo.InvariantCulture, message, args), innerException)
	{
		YZBdBcjSzKtHqAFOavgLqQZlNmr = ResultDescriptor.Find(hbpFHugbKyodFCJCiZcKFruzcGvs.mwBxXjlFurjQdRZMzjjlJPyjMtq);
		base.HResult = (int)hbpFHugbKyodFCJCiZcKFruzcGvs.mwBxXjlFurjQdRZMzjjlJPyjMtq;
	}
}
