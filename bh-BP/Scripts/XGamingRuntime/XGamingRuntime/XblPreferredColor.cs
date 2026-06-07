using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPreferredColor
	{
		public string PrimaryColor { get; private set; }

		public string SecondaryColor { get; private set; }

		public string TertiaryColor { get; private set; }

		internal XblPreferredColor(XGamingRuntime.Interop.XblPreferredColor interopPreferredColor)
		{
		}
	}
}
