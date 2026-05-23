using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class APjXdYLYDtcURWywbovQbSnUCPfL
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int CnhFZArlvEcbvGzZfWbmYnkHEewbA(void* deviceInstance, IntPtr data);

	private readonly IntPtr CfiwkfRTJUvsfHrEmXkFfIBGGrip;

	private readonly CnhFZArlvEcbvGzZfWbmYnkHEewbA srasvbtjMKVoIJOobNymuvKWeDmK;

	[CompilerGenerated]
	private List<agXldjjcDkpqUxQdFPyLgCAMtRsl> tvZbaTjWiLQgxDqcbbJoJjWYFPLk;

	public IntPtr WEoDmWngrRjDgnPRdfQYttUEfDBw => CfiwkfRTJUvsfHrEmXkFfIBGGrip;

	public List<agXldjjcDkpqUxQdFPyLgCAMtRsl> hqlFxNHKzfMvvHYqeLXUqaDhcQvhA
	{
		[CompilerGenerated]
		get
		{
			return tvZbaTjWiLQgxDqcbbJoJjWYFPLk;
		}
		[CompilerGenerated]
		private set
		{
			tvZbaTjWiLQgxDqcbbJoJjWYFPLk = list;
		}
	}

	public unsafe APjXdYLYDtcURWywbovQbSnUCPfL()
	{
		srasvbtjMKVoIJOobNymuvKWeDmK = CpLnvaMhUwCDIEmRdJeNCcbUsbEB;
		CfiwkfRTJUvsfHrEmXkFfIBGGrip = Marshal.GetFunctionPointerForDelegate(srasvbtjMKVoIJOobNymuvKWeDmK);
		hqlFxNHKzfMvvHYqeLXUqaDhcQvhA = new List<agXldjjcDkpqUxQdFPyLgCAMtRsl>();
	}

	[MonoPInvokeCallback(typeof(CnhFZArlvEcbvGzZfWbmYnkHEewbA))]
	private unsafe static int CpLnvaMhUwCDIEmRdJeNCcbUsbEB(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<APjXdYLYDtcURWywbovQbSnUCPfL>(instanceId, out var instance))
		{
			return 1;
		}
		agXldjjcDkpqUxQdFPyLgCAMtRsl agXldjjcDkpqUxQdFPyLgCAMtRsl2 = new agXldjjcDkpqUxQdFPyLgCAMtRsl();
		agXldjjcDkpqUxQdFPyLgCAMtRsl2.rDwhLpxHzsPZRjDRXmqrqwlCPnYv(ref *(agXldjjcDkpqUxQdFPyLgCAMtRsl.PkMFAeckbXXBIhPDisLIQnaSdRoJA*)P_0);
		instance.hqlFxNHKzfMvvHYqeLXUqaDhcQvhA.Add(agXldjjcDkpqUxQdFPyLgCAMtRsl2);
		return 1;
	}
}
