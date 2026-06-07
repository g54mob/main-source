using TMPro;

namespace Shapes
{
	public static class TextAlignExtensions
	{
		public static TextAlignmentOptions GetTMPAlignment(this TextAlign align)
		{
			return align switch
			{
				TextAlign.TopLeft => TextAlignmentOptions.TopLeft, 
				TextAlign.Top => TextAlignmentOptions.Top, 
				TextAlign.TopRight => TextAlignmentOptions.TopRight, 
				TextAlign.TopJustified => TextAlignmentOptions.TopJustified, 
				TextAlign.TopFlush => TextAlignmentOptions.TopFlush, 
				TextAlign.TopGeoAligned => TextAlignmentOptions.TopGeoAligned, 
				TextAlign.Left => TextAlignmentOptions.Left, 
				TextAlign.Center => TextAlignmentOptions.Center, 
				TextAlign.Right => TextAlignmentOptions.Right, 
				TextAlign.Justified => TextAlignmentOptions.Justified, 
				TextAlign.Flush => TextAlignmentOptions.Flush, 
				TextAlign.CenterGeoAligned => TextAlignmentOptions.CenterGeoAligned, 
				TextAlign.BottomLeft => TextAlignmentOptions.BottomLeft, 
				TextAlign.Bottom => TextAlignmentOptions.Bottom, 
				TextAlign.BottomRight => TextAlignmentOptions.BottomRight, 
				TextAlign.BottomJustified => TextAlignmentOptions.BottomJustified, 
				TextAlign.BottomFlush => TextAlignmentOptions.BottomFlush, 
				TextAlign.BottomGeoAligned => TextAlignmentOptions.BottomGeoAligned, 
				TextAlign.BaselineLeft => TextAlignmentOptions.BaselineLeft, 
				TextAlign.Baseline => TextAlignmentOptions.Baseline, 
				TextAlign.BaselineRight => TextAlignmentOptions.BaselineRight, 
				TextAlign.BaselineJustified => TextAlignmentOptions.BaselineJustified, 
				TextAlign.BaselineFlush => TextAlignmentOptions.BaselineFlush, 
				TextAlign.BaselineGeoAligned => TextAlignmentOptions.BaselineGeoAligned, 
				TextAlign.MidlineLeft => TextAlignmentOptions.MidlineLeft, 
				TextAlign.Midline => TextAlignmentOptions.Midline, 
				TextAlign.MidlineRight => TextAlignmentOptions.MidlineRight, 
				TextAlign.MidlineJustified => TextAlignmentOptions.MidlineJustified, 
				TextAlign.MidlineFlush => TextAlignmentOptions.MidlineFlush, 
				TextAlign.MidlineGeoAligned => TextAlignmentOptions.MidlineGeoAligned, 
				TextAlign.CaplineLeft => TextAlignmentOptions.CaplineLeft, 
				TextAlign.Capline => TextAlignmentOptions.Capline, 
				TextAlign.CaplineRight => TextAlignmentOptions.CaplineRight, 
				TextAlign.CaplineJustified => TextAlignmentOptions.CaplineJustified, 
				TextAlign.CaplineFlush => TextAlignmentOptions.CaplineFlush, 
				TextAlign.CaplineGeoAligned => TextAlignmentOptions.CaplineGeoAligned, 
				TextAlign.Converted => TextAlignmentOptions.Converted, 
				_ => (TextAlignmentOptions)0, 
			};
		}
	}
}
