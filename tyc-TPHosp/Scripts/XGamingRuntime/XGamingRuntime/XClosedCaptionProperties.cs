using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XClosedCaptionProperties
	{
		public XColor BackgroundColor { get; }

		public XColor FontColor { get; }

		public XColor WindowColor { get; }

		public XClosedCaptionFontEdgeAttribute FontEdgeAttribute { get; }

		public XClosedCaptionFontStyle FontStyle { get; }

		public float FontScale { get; }

		public bool Enabled { get; }

		internal XClosedCaptionProperties(XGamingRuntime.Interop.XClosedCaptionProperties interopStruct)
		{
			BackgroundColor = new XColor(interopStruct.BackgroundColor);
			FontColor = new XColor(interopStruct.FontColor);
			WindowColor = new XColor(interopStruct.WindowColor);
			FontEdgeAttribute = interopStruct.FontEdgeAttribute;
			FontStyle = interopStruct.FontStyle;
			FontScale = interopStruct.FontScale;
			Enabled = interopStruct.Enabled.Value;
		}
	}
}
