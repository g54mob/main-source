using CloudOnce.CloudPrefs;

namespace CloudOnce
{
	public static class CloudVariables
	{
		private static readonly CloudString s_data = new CloudString("data");

		public static string data
		{
			get
			{
				return s_data.Value;
			}
			set
			{
				s_data.Value = value;
			}
		}
	}
}
