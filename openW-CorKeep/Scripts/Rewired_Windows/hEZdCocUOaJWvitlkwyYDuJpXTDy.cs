using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class hEZdCocUOaJWvitlkwyYDuJpXTDy
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int biNWymAnwNeNFAmGsIlaGuQaurMLA(void* deviceInstance, IntPtr data);

	private readonly IntPtr tJUcFZiJYRYVBqEZdmHZPoxzcwIn;

	private readonly biNWymAnwNeNFAmGsIlaGuQaurMLA TGSRXWMPHJlegavGmZkeSembvIDB;

	[CompilerGenerated]
	private List<PyvhEXOOIhgSeIwyAsaBOIoxukWy> WMvKRvSynWcUVuNbivzylCwbUWli;

	public IntPtr zVSuFcAvcCbuCICCkONYNOotOahI => tJUcFZiJYRYVBqEZdmHZPoxzcwIn;

	public List<PyvhEXOOIhgSeIwyAsaBOIoxukWy> MhBQEziwseSLZyotxSBAGUjOqHTV
	{
		[CompilerGenerated]
		get
		{
			return WMvKRvSynWcUVuNbivzylCwbUWli;
		}
		[CompilerGenerated]
		private set
		{
			WMvKRvSynWcUVuNbivzylCwbUWli = wMvKRvSynWcUVuNbivzylCwbUWli;
		}
	}

	public unsafe hEZdCocUOaJWvitlkwyYDuJpXTDy()
	{
		TGSRXWMPHJlegavGmZkeSembvIDB = fjhEVHnmjnmyhdfJyPvyaWOhlHRE;
		tJUcFZiJYRYVBqEZdmHZPoxzcwIn = Marshal.GetFunctionPointerForDelegate(TGSRXWMPHJlegavGmZkeSembvIDB);
		MhBQEziwseSLZyotxSBAGUjOqHTV = new List<PyvhEXOOIhgSeIwyAsaBOIoxukWy>();
	}

	[MonoPInvokeCallback(typeof(biNWymAnwNeNFAmGsIlaGuQaurMLA))]
	private unsafe static int fjhEVHnmjnmyhdfJyPvyaWOhlHRE(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<hEZdCocUOaJWvitlkwyYDuJpXTDy>(instanceId, out var instance))
		{
			return 1;
		}
		PyvhEXOOIhgSeIwyAsaBOIoxukWy pyvhEXOOIhgSeIwyAsaBOIoxukWy = new PyvhEXOOIhgSeIwyAsaBOIoxukWy();
		pyvhEXOOIhgSeIwyAsaBOIoxukWy.CNQqiPQvkfppfIJUYhglCDRhCwwHA(ref *(PyvhEXOOIhgSeIwyAsaBOIoxukWy.auaojAXlaYjpgArQbELIDcUtnMCEb*)P_0);
		instance.MhBQEziwseSLZyotxSBAGUjOqHTV.Add(pyvhEXOOIhgSeIwyAsaBOIoxukWy);
		return 1;
	}
}
