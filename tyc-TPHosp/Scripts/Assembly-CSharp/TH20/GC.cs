using System.Runtime.InteropServices;

namespace TH20
{
	public static class GC
	{
		private static bool _enabled = true;

		public static void Enable()
		{
			if (!_enabled)
			{
				_enabled = true;
				GC_enable();
			}
		}

		public static void Disable()
		{
			if (_enabled)
			{
				_enabled = false;
				GC_disable();
			}
		}

		[DllImport("__Internal")]
		public static extern void GC_disable();

		[DllImport("__Internal")]
		public static extern void GC_enable();
	}
}
