using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class dAPpvQuiarQyzKUzVLfdYgsFzHL : TypeSpecificParameters
{
	[CompilerGenerated]
	private int NwedbPLxpabZlFIlpeTXSWwYnlT;

	[CompilerGenerated]
	private int gyiFfLfGnkWlZWakKvNXELgVaHpm;

	[CompilerGenerated]
	private int QpGWFMYIDVLrLqFiDupqsyrWwpc;

	[CompilerGenerated]
	private int[] cPwOWRyBJkbJuLOyMRHRedUtaunD;

	public int ChannelCount
	{
		[CompilerGenerated]
		get
		{
			return NwedbPLxpabZlFIlpeTXSWwYnlT;
		}
		[CompilerGenerated]
		set
		{
			NwedbPLxpabZlFIlpeTXSWwYnlT = value;
		}
	}

	public int SamplePeriod
	{
		[CompilerGenerated]
		get
		{
			return gyiFfLfGnkWlZWakKvNXELgVaHpm;
		}
		[CompilerGenerated]
		set
		{
			gyiFfLfGnkWlZWakKvNXELgVaHpm = value;
		}
	}

	public int SampleCount
	{
		[CompilerGenerated]
		get
		{
			return QpGWFMYIDVLrLqFiDupqsyrWwpc;
		}
		[CompilerGenerated]
		set
		{
			QpGWFMYIDVLrLqFiDupqsyrWwpc = value;
		}
	}

	public int[] ForceData
	{
		[CompilerGenerated]
		get
		{
			return cPwOWRyBJkbJuLOyMRHRedUtaunD;
		}
		[CompilerGenerated]
		set
		{
			cPwOWRyBJkbJuLOyMRHRedUtaunD = value;
		}
	}

	public override int Size
	{
		get
		{
			return QiyhMeApbloIAQYCjGAvUEQIhAz.THBpTsDJKmVwufYBxLzZkiSYLgH<ZXzeQGNXkmyCTZiUoeehWIhOjnDb>();
		}
	}

	protected unsafe override TypeSpecificParameters MarshalFrom(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(ZXzeQGNXkmyCTZiUoeehWIhOjnDb))
		{
			return null;
		}
		ChannelCount = ((ZXzeQGNXkmyCTZiUoeehWIhOjnDb*)(void*)P_1)->sNjCxudYcjZZjefVIXTmrDagpRx;
		SamplePeriod = ((ZXzeQGNXkmyCTZiUoeehWIhOjnDb*)(void*)P_1)->POcoibBqUTLgnQlyChfaHBElpDbI;
		SampleCount = ((ZXzeQGNXkmyCTZiUoeehWIhOjnDb*)(void*)P_1)->MPggtCBZqZSjilumnpCTGgKiktFQ;
		ForceData = new int[SampleCount];
		fixed (int* forceData = ForceData)
		{
			QiyhMeApbloIAQYCjGAvUEQIhAz.jZaoqafpmcVnUamkQHboGxYtgDI((IntPtr)forceData, ((ZXzeQGNXkmyCTZiUoeehWIhOjnDb*)(void*)P_1)->cITHOhSWcKUeayXLzCBXcvHgcfD, ForceData.Length * sizeof(ZXzeQGNXkmyCTZiUoeehWIhOjnDb));
		}
		return this;
	}

	internal unsafe override IntPtr MarshalTo()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((ZXzeQGNXkmyCTZiUoeehWIhOjnDb*)(void*)intPtr)->sNjCxudYcjZZjefVIXTmrDagpRx = ChannelCount;
		((ZXzeQGNXkmyCTZiUoeehWIhOjnDb*)(void*)intPtr)->POcoibBqUTLgnQlyChfaHBElpDbI = SamplePeriod;
		((ZXzeQGNXkmyCTZiUoeehWIhOjnDb*)(void*)intPtr)->MPggtCBZqZSjilumnpCTGgKiktFQ = SampleCount;
		IntPtr intPtr2 = Marshal.AllocHGlobal(ForceData.Length * 4);
		((ZXzeQGNXkmyCTZiUoeehWIhOjnDb*)(void*)intPtr)->cITHOhSWcKUeayXLzCBXcvHgcfD = intPtr2;
		fixed (int* forceData = ForceData)
		{
			QiyhMeApbloIAQYCjGAvUEQIhAz.jZaoqafpmcVnUamkQHboGxYtgDI(intPtr2, (IntPtr)forceData, ForceData.Length * 4);
		}
		return intPtr;
	}

	internal unsafe override void MarshalFree(IntPtr P_0)
	{
		base.MarshalFree(P_0);
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(((ZXzeQGNXkmyCTZiUoeehWIhOjnDb*)(void*)P_0)->cITHOhSWcKUeayXLzCBXcvHgcfD);
		}
	}
}
