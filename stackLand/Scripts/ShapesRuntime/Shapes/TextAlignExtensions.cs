using TMPro;
using UnityEngine;

namespace Shapes
{
	public static class TextAlignExtensions
	{
		public static Vector2 GetPivot(this TextAlign align)
		{
			return align switch
			{
				TextAlign.TopLeft => new Vector2(0f, 1f), 
				TextAlign.Top => new Vector2(0.5f, 1f), 
				TextAlign.TopRight => new Vector2(1f, 1f), 
				TextAlign.Left => new Vector2(0f, 0.5f), 
				TextAlign.Center => new Vector2(0.5f, 0.5f), 
				TextAlign.Right => new Vector2(1f, 0.5f), 
				TextAlign.BottomLeft => new Vector2(0f, 0f), 
				TextAlign.Bottom => new Vector2(0.5f, 0f), 
				TextAlign.BottomRight => new Vector2(1f, 0f), 
				_ => default(Vector2), 
			};
		}

		public static TextAlignmentOptions GetTMPAlignment(this TextAlign align)
		{
			return align switch
			{
				TextAlign.TopLeft => TextAlignmentOptions.TopLeft, 
				TextAlign.Top => TextAlignmentOptions.Top, 
				TextAlign.TopRight => TextAlignmentOptions.TopRight, 
				TextAlign.Left => TextAlignmentOptions.Left, 
				TextAlign.Center => TextAlignmentOptions.Center, 
				TextAlign.Right => TextAlignmentOptions.Right, 
				TextAlign.BottomLeft => TextAlignmentOptions.BottomLeft, 
				TextAlign.Bottom => TextAlignmentOptions.Bottom, 
				TextAlign.BottomRight => TextAlignmentOptions.BottomRight, 
				_ => (TextAlignmentOptions)0, 
			};
		}
	}
}
