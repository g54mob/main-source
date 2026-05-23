using System;
using System.Runtime.CompilerServices;

internal struct uWaovIOcoCFNjfHzcSVlEieiyJx
{
	public IntPtr JAPGXbnGLEVcKvOepfYKLDmQrgU;

	private IntPtr tUsNDLlTlKgJlEuMSHhIpaWqkvH;

	private int gZlgraAiEeOaHcZGkfapAWwyCKyD;

	public int IckFjyUuHaWCpzSJYswmjKnqtfg;

	public int rrotJhvUrwqPbiAeUWvpTADfTUB;

	internal bool IsValid
	{
		get
		{
			if (gZlgraAiEeOaHcZGkfapAWwyCKyD > 0)
			{
				return tUsNDLlTlKgJlEuMSHhIpaWqkvH != IntPtr.Zero;
			}
			return false;
		}
	}

	public IntPtr RawDataPtr
	{
		get
		{
			return tUsNDLlTlKgJlEuMSHhIpaWqkvH;
		}
	}

	public int RawDataBytes
	{
		get
		{
			return gZlgraAiEeOaHcZGkfapAWwyCKyD;
		}
	}

	internal unsafe uWaovIOcoCFNjfHzcSVlEieiyJx(ref fIfDvwvvsOcXtZCxSBYBVEQFUcW rawInput, tRYyuqvNaAroIkduxNnmcDdOaen memQueue)
	{
		JAPGXbnGLEVcKvOepfYKLDmQrgU = rawInput.wtYGxjhSdvLEZrXjirTZkeCIDfO.JAPGXbnGLEVcKvOepfYKLDmQrgU;
		IckFjyUuHaWCpzSJYswmjKnqtfg = rawInput.qCmvlLxcVUaxPDpvXtvsPlXAJOVt.WbhjSGsjNymzrHQfxwWIFhCqAnK.IckFjyUuHaWCpzSJYswmjKnqtfg;
		rrotJhvUrwqPbiAeUWvpTADfTUB = rawInput.qCmvlLxcVUaxPDpvXtvsPlXAJOVt.WbhjSGsjNymzrHQfxwWIFhCqAnK.GNXBETqgaPEiYAFuSLvncfNUPlZ;
		gZlgraAiEeOaHcZGkfapAWwyCKyD = IckFjyUuHaWCpzSJYswmjKnqtfg * rrotJhvUrwqPbiAeUWvpTADfTUB;
		if (gZlgraAiEeOaHcZGkfapAWwyCKyD > 0)
		{
			fixed (IntPtr* vDFspOOHYRIQoZIRvjuLQnBIQok = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref rawInput.qCmvlLxcVUaxPDpvXtvsPlXAJOVt.WbhjSGsjNymzrHQfxwWIFhCqAnK.vDFspOOHYRIQoZIRvjuLQnBIQok))
			{
				tUsNDLlTlKgJlEuMSHhIpaWqkvH = memQueue.vcQVsNQJjICkKZlvTwHrmCNfVZD((uint)gZlgraAiEeOaHcZGkfapAWwyCKyD, vDFspOOHYRIQoZIRvjuLQnBIQok);
			}
		}
		else
		{
			tUsNDLlTlKgJlEuMSHhIpaWqkvH = IntPtr.Zero;
		}
	}
}
