using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameKit.Utilities.Types.CanvasContainers
{
	public class ResizableContainer : FloatingContainer
	{
		[Tooltip("Minimum and maximum range for width and height of the RectTransform.")]
		public FloatRange2D SizeLimits;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetSizeAndShow(Vector2 size, bool ignoreSizeLimits = false)
		{
		}

		protected virtual void ResizeAndShow(Vector2 desiredSize, bool ignoreSizeLimits)
		{
		}
	}
}
