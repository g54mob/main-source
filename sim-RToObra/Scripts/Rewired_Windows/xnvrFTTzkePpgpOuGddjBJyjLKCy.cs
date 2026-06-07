using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class xnvrFTTzkePpgpOuGddjBJyjLKCy
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int NTboImItfNiznNDgtJMQHVOppaB(void* deviceInstance, IntPtr data);

	private readonly IntPtr gCHLRLMMTROdfhHdjSeFpmVcoRj;

	private readonly NTboImItfNiznNDgtJMQHVOppaB uQapxaGEDQOujgaUJWGffIJYTlv;

	[CompilerGenerated]
	private List<rrkiWNHnEkzBYEXAvbDAWsEtjKd> eDYBNPnNimUiclwduBvWgDZyCGfE;

	public IntPtr NativePointer
	{
		get
		{
			return gCHLRLMMTROdfhHdjSeFpmVcoRj;
		}
	}

	public List<rrkiWNHnEkzBYEXAvbDAWsEtjKd> DeviceInstances
	{
		[CompilerGenerated]
		get
		{
			return eDYBNPnNimUiclwduBvWgDZyCGfE;
		}
		[CompilerGenerated]
		private set
		{
			eDYBNPnNimUiclwduBvWgDZyCGfE = value;
		}
	}

	public unsafe xnvrFTTzkePpgpOuGddjBJyjLKCy()
	{
		uQapxaGEDQOujgaUJWGffIJYTlv = pgqgGFojKFkvMJbeVHfBMYhbyxu;
		gCHLRLMMTROdfhHdjSeFpmVcoRj = Marshal.GetFunctionPointerForDelegate(uQapxaGEDQOujgaUJWGffIJYTlv);
		DeviceInstances = new List<rrkiWNHnEkzBYEXAvbDAWsEtjKd>();
	}

	[MonoPInvokeCallback(typeof(NTboImItfNiznNDgtJMQHVOppaB))]
	private unsafe static int pgqgGFojKFkvMJbeVHfBMYhbyxu(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		xnvrFTTzkePpgpOuGddjBJyjLKCy instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<xnvrFTTzkePpgpOuGddjBJyjLKCy>(instanceId, out instance))
		{
			return 1;
		}
		rrkiWNHnEkzBYEXAvbDAWsEtjKd rrkiWNHnEkzBYEXAvbDAWsEtjKd2 = new rrkiWNHnEkzBYEXAvbDAWsEtjKd();
		rrkiWNHnEkzBYEXAvbDAWsEtjKd2.CCXHeHFCFsQDMbnwdqXpPnwaKpIy(ref *(rrkiWNHnEkzBYEXAvbDAWsEtjKd.kaXgOiCCnssTpMvhCCVSgIrrWMYU*)P_0);
		instance.DeviceInstances.Add(rrkiWNHnEkzBYEXAvbDAWsEtjKd2);
		return 1;
	}
}
