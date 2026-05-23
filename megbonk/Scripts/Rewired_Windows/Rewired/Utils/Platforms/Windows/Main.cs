using System.ComponentModel;

namespace Rewired.Utils.Platforms.Windows
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class Main
	{
		public static object GetPlatformInitializer()
		{
			return null;
		}
	}
}
