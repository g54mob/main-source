using System.Runtime.InteropServices;

namespace Noesis
{
	public static class Platform
	{
		public static PlatformID ID { get; private set; }

		static Platform()
		{
		}

		[PreserveSig]
		private static extern int Noesis_GetPlatformID();
	}
}
