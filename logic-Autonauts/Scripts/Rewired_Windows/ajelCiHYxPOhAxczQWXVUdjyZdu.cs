using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class ajelCiHYxPOhAxczQWXVUdjyZdu
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int HqQMmqmpeCXlKIZljJLDSLROgicf(void* deviceInstance, IntPtr data);

	private readonly IntPtr oQrDIzabSXnJeReNAUCNWaVKrkpV;

	private readonly HqQMmqmpeCXlKIZljJLDSLROgicf gcSCuQrNDUgbabBuaIMfeSRwgnvd;

	[CompilerGenerated]
	private List<KuQxCBzznSLnNWYiaqXOToEkUKh> jkiTQVNaJguPgdDUZkBQZEJDIvsh;

	public IntPtr NativePointer
	{
		get
		{
			return oQrDIzabSXnJeReNAUCNWaVKrkpV;
		}
	}

	public List<KuQxCBzznSLnNWYiaqXOToEkUKh> Objects
	{
		[CompilerGenerated]
		get
		{
			return jkiTQVNaJguPgdDUZkBQZEJDIvsh;
		}
		[CompilerGenerated]
		private set
		{
			jkiTQVNaJguPgdDUZkBQZEJDIvsh = value;
		}
	}

	public unsafe ajelCiHYxPOhAxczQWXVUdjyZdu()
	{
		gcSCuQrNDUgbabBuaIMfeSRwgnvd = kINMUNcnttXlHcLiiRzXUiWJSNS;
		oQrDIzabSXnJeReNAUCNWaVKrkpV = Marshal.GetFunctionPointerForDelegate((Delegate)gcSCuQrNDUgbabBuaIMfeSRwgnvd);
		Objects = new List<KuQxCBzznSLnNWYiaqXOToEkUKh>();
	}

	[MonoPInvokeCallback(typeof(HqQMmqmpeCXlKIZljJLDSLROgicf))]
	private unsafe static int kINMUNcnttXlHcLiiRzXUiWJSNS(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		ajelCiHYxPOhAxczQWXVUdjyZdu instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<ajelCiHYxPOhAxczQWXVUdjyZdu>(instanceId, out instance))
		{
			return 1;
		}
		KuQxCBzznSLnNWYiaqXOToEkUKh kuQxCBzznSLnNWYiaqXOToEkUKh = new KuQxCBzznSLnNWYiaqXOToEkUKh();
		kuQxCBzznSLnNWYiaqXOToEkUKh.YlftNbjDTaOHNaMzVFmdceqqrvk(ref *(KuQxCBzznSLnNWYiaqXOToEkUKh.IXzEsNajOujzwjdxhqldUAuMgOSA*)P_0);
		instance.Objects.Add(kuQxCBzznSLnNWYiaqXOToEkUKh);
		return 1;
	}
}
