using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class OuZZCwsasokiVmunagPxHgBqhXVn
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int HwqsBfBgzpTyIKkDwCYmRVsaTZTU(void* deviceInstance, IntPtr data);

	private readonly IntPtr MqQirjaqqxjFUYlNvZMhMElhKvrf;

	private readonly HwqsBfBgzpTyIKkDwCYmRVsaTZTU wdGiFBIFUjEUAThwVzCZVtBSdLgIb;

	[CompilerGenerated]
	private List<qhWDokgorlogyTGTWjdCrUXmjTTA> WZErMflUBhOmekrSFJENRKDejHggA;

	public IntPtr gNZjCelDnMYsctvthMngmzMwQCAt => MqQirjaqqxjFUYlNvZMhMElhKvrf;

	public List<qhWDokgorlogyTGTWjdCrUXmjTTA> XWpWPSILrjvjkCGeTreFJArempMf
	{
		[CompilerGenerated]
		get
		{
			return WZErMflUBhOmekrSFJENRKDejHggA;
		}
		[CompilerGenerated]
		private set
		{
			WZErMflUBhOmekrSFJENRKDejHggA = wZErMflUBhOmekrSFJENRKDejHggA;
		}
	}

	public unsafe OuZZCwsasokiVmunagPxHgBqhXVn()
	{
		wdGiFBIFUjEUAThwVzCZVtBSdLgIb = VTFXWTzhmJWLSjyniCNxDUwWNkbG;
		MqQirjaqqxjFUYlNvZMhMElhKvrf = Marshal.GetFunctionPointerForDelegate(wdGiFBIFUjEUAThwVzCZVtBSdLgIb);
		XWpWPSILrjvjkCGeTreFJArempMf = new List<qhWDokgorlogyTGTWjdCrUXmjTTA>();
	}

	[MonoPInvokeCallback(typeof(HwqsBfBgzpTyIKkDwCYmRVsaTZTU))]
	private unsafe static int VTFXWTzhmJWLSjyniCNxDUwWNkbG(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<OuZZCwsasokiVmunagPxHgBqhXVn>(instanceId, out var instance))
		{
			return 1;
		}
		qhWDokgorlogyTGTWjdCrUXmjTTA qhWDokgorlogyTGTWjdCrUXmjTTA2 = new qhWDokgorlogyTGTWjdCrUXmjTTA();
		qhWDokgorlogyTGTWjdCrUXmjTTA2.VsPcWEMfYtXHnqbSVYGzmcpzSBGS(ref *(qhWDokgorlogyTGTWjdCrUXmjTTA.brJOyEDkzdRJyTfqLVUTjSJkOFOI*)P_0);
		instance.XWpWPSILrjvjkCGeTreFJArempMf.Add(qhWDokgorlogyTGTWjdCrUXmjTTA2);
		return 1;
	}
}
