using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices
{
	public sealed class ContinuanceToken : Handle
	{
		public ContinuanceToken()
		{
		}

		public ContinuanceToken(IntPtr innerHandle)
		{
		}

		public Result ToString(out string outBuffer)
		{
			outBuffer = null;
			return default(Result);
		}

		[PreserveSig]
		internal static extern Result EOS_ContinuanceToken_ToString(IntPtr continuanceToken, IntPtr outBuffer, ref int inOutBufferLength);
	}
}
