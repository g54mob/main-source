using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class QnQgtyXpaUAkMdjHCfbNIKxlixdab
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int SOSoHgvPWxBbwIiaSDojchyaZBmHA(void* deviceInstance, IntPtr data);

	private readonly IntPtr SSNabVPyEhjtcwrhFIsCKDYbSCme;

	private readonly SOSoHgvPWxBbwIiaSDojchyaZBmHA eiTAcNzeflCRTjiNORYzHgWlwPmQ;

	[CompilerGenerated]
	private List<cmifrNlvyBXuXIoQyzrEFMGvtUuO> tssjlBnPesMaXkLfOijbmMMrsTmB;

	public IntPtr OdVXOarAUcPRhScgSJFLYuMdngLP => SSNabVPyEhjtcwrhFIsCKDYbSCme;

	public List<cmifrNlvyBXuXIoQyzrEFMGvtUuO> fyCxrbPqWClnomxNFoENRZPKJrrm
	{
		[CompilerGenerated]
		get
		{
			return tssjlBnPesMaXkLfOijbmMMrsTmB;
		}
		[CompilerGenerated]
		private set
		{
			tssjlBnPesMaXkLfOijbmMMrsTmB = list;
		}
	}

	public unsafe QnQgtyXpaUAkMdjHCfbNIKxlixdab()
	{
		eiTAcNzeflCRTjiNORYzHgWlwPmQ = MuuxWBYUXVAyQfFvYKnpjkHlJptc;
		SSNabVPyEhjtcwrhFIsCKDYbSCme = Marshal.GetFunctionPointerForDelegate(eiTAcNzeflCRTjiNORYzHgWlwPmQ);
		fyCxrbPqWClnomxNFoENRZPKJrrm = new List<cmifrNlvyBXuXIoQyzrEFMGvtUuO>();
	}

	[MonoPInvokeCallback(typeof(SOSoHgvPWxBbwIiaSDojchyaZBmHA))]
	private unsafe static int MuuxWBYUXVAyQfFvYKnpjkHlJptc(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<QnQgtyXpaUAkMdjHCfbNIKxlixdab>(instanceId, out var instance))
		{
			return 1;
		}
		cmifrNlvyBXuXIoQyzrEFMGvtUuO cmifrNlvyBXuXIoQyzrEFMGvtUuO2 = new cmifrNlvyBXuXIoQyzrEFMGvtUuO();
		cmifrNlvyBXuXIoQyzrEFMGvtUuO2.naJbTFFdMXAFQzOcqyhqODblhMONA(ref *(cmifrNlvyBXuXIoQyzrEFMGvtUuO.VgzzQUgZEinNLUscDbWZjWqbgkcM*)P_0);
		instance.fyCxrbPqWClnomxNFoENRZPKJrrm.Add(cmifrNlvyBXuXIoQyzrEFMGvtUuO2);
		return 1;
	}
}
