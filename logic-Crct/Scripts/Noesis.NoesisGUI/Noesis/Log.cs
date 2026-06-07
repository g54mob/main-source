using System.Runtime.InteropServices;

namespace Noesis
{
	public class Log
	{
		private delegate void NativeLogCallback(uint level, string channel, string message);

		private static LogCallback _logCallback;

		private static NativeLogCallback _noesisLogCallback;

		public static void SetLogCallback(LogCallback callback)
		{
		}

		[MonoPInvokeCallback(typeof(NativeLogCallback))]
		private static void OnLog(uint level, string channel, string message)
		{
		}

		internal static void Error(string message)
		{
		}

		[PreserveSig]
		private static extern void Noesis_RegisterLogCallback(NativeLogCallback callback);
	}
}
