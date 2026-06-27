using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct LEuvDhxKvWdNgdGKNNakDiKtAuJK
{
	[FieldOffset(0)]
	private int VhiQsHmEEreTnqQiAKIkSfnUXDfL;

	[FieldOffset(0)]
	private long MxRduZmcxtkwjCWNsctrKnUCNUIL;

	[FieldOffset(0)]
	private IntPtr pJMNxtDIdhwnibucfuWhyiKNzyfG;

	private static readonly bool iEMVPqNtyRVOUrCTWCtccPNcEfCf;

	public static readonly int RPJdODlvWmemfFrsNAabNYyROBedA;

	static LEuvDhxKvWdNgdGKNNakDiKtAuJK()
	{
		RPJdODlvWmemfFrsNAabNYyROBedA = IntPtr.Size;
		iEMVPqNtyRVOUrCTWCtccPNcEfCf = RPJdODlvWmemfFrsNAabNYyROBedA == 8;
	}

	public static LEuvDhxKvWdNgdGKNNakDiKtAuJK yqUNbqQzYQvRWeGApbcQbcevGbdU(byte[] P_0, int P_1)
	{
		LEuvDhxKvWdNgdGKNNakDiKtAuJK result = default(LEuvDhxKvWdNgdGKNNakDiKtAuJK);
		if (iEMVPqNtyRVOUrCTWCtccPNcEfCf)
		{
			result.MxRduZmcxtkwjCWNsctrKnUCNUIL = BitConverter.ToInt64(P_0, P_1);
			result.pJMNxtDIdhwnibucfuWhyiKNzyfG = new IntPtr(result.MxRduZmcxtkwjCWNsctrKnUCNUIL);
		}
		else
		{
			result.VhiQsHmEEreTnqQiAKIkSfnUXDfL = BitConverter.ToInt32(P_0, P_1);
			result.pJMNxtDIdhwnibucfuWhyiKNzyfG = new IntPtr(result.VhiQsHmEEreTnqQiAKIkSfnUXDfL);
		}
		return result;
	}

	[SpecialName]
	public static LEuvDhxKvWdNgdGKNNakDiKtAuJK textmLTcqVwANsHtDDZcjbwEGxLO(IntPtr P_0)
	{
		LEuvDhxKvWdNgdGKNNakDiKtAuJK result = new LEuvDhxKvWdNgdGKNNakDiKtAuJK
		{
			pJMNxtDIdhwnibucfuWhyiKNzyfG = P_0
		};
		if (iEMVPqNtyRVOUrCTWCtccPNcEfCf)
		{
			result.MxRduZmcxtkwjCWNsctrKnUCNUIL = P_0.ToInt64();
		}
		else
		{
			result.VhiQsHmEEreTnqQiAKIkSfnUXDfL = P_0.ToInt32();
		}
		return result;
	}

	[SpecialName]
	public static IntPtr rhYgDeOYoIoVxokcikUMkMqJbQWdA(LEuvDhxKvWdNgdGKNNakDiKtAuJK P_0)
	{
		return P_0.pJMNxtDIdhwnibucfuWhyiKNzyfG;
	}

	public string XxrVpZAWBjsaRRNlwWYoGQcXoHab()
	{
		if (iEMVPqNtyRVOUrCTWCtccPNcEfCf)
		{
			return MxRduZmcxtkwjCWNsctrKnUCNUIL.ToString();
		}
		return VhiQsHmEEreTnqQiAKIkSfnUXDfL.ToString();
	}
}
