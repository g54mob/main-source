using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	public static class XboxLiveGlobal
	{
		[PreserveSig]
		public unsafe static extern int XblGetScid(sbyte** scid);
	}
}
