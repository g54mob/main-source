using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPreferredColor
	{
		public string PrimaryColor { get; }

		public string SecondaryColor { get; }

		public string TertiaryColor { get; }

		internal XblPreferredColor(XGamingRuntime.Interop.XblPreferredColor interopPreferredColor)
		{
			PrimaryColor = Converters.ByteArrayToString(interopPreferredColor.primaryColor);
			SecondaryColor = Converters.ByteArrayToString(interopPreferredColor.secondaryColor);
			TertiaryColor = Converters.ByteArrayToString(interopPreferredColor.tertiaryColor);
		}
	}
}
