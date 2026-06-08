using Platforms;

namespace Kitchen.NetworkSupport
{
	public static class NetworkHelpers
	{
		public static NetworkPermissions CurrentNetworkPermissions
		{
			get
			{
				return Platform.Current.CurrentNetworkPermissions;
			}
			set
			{
				Platform.Current.CurrentNetworkPermissions = value;
			}
		}
	}
}
