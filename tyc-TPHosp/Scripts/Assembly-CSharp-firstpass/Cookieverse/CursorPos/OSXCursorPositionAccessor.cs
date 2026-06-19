using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Cookieverse.CursorPos
{
	public class OSXCursorPositionAccessor : ICursorPositionAccessor
	{
		public struct CGPoint
		{
			public double X { get; set; }

			public double Y { get; set; }
		}

		[DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
		public static extern int CGWarpMouseCursorPosition(CGPoint point);

		[DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
		public static extern IntPtr CGEventCreate(IntPtr source);

		[DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
		public static extern CGPoint CGEventGetLocation(IntPtr evt);

		[DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
		public static extern void CFRelease(IntPtr cf);

		public bool IsSupported()
		{
			return false;
		}

		public bool CanConfineToRect()
		{
			return false;
		}

		public void ConfineToRect(Vector2 topLeft, Vector2 bottomRight)
		{
			throw new OsCursorException("Unsupported)");
		}

		public void ReleaseConfine()
		{
			throw new OsCursorException("Unsupported)");
		}

		public void Set(Vector2 position)
		{
			CGWarpMouseCursorPosition(new CGPoint
			{
				X = position.x,
				Y = position.y
			});
		}

		public Vector2 Get()
		{
			IntPtr intPtr = CGEventCreate(IntPtr.Zero);
			CGPoint cGPoint = CGEventGetLocation(intPtr);
			CFRelease(intPtr);
			return new Vector2((float)cGPoint.X, (float)cGPoint.Y);
		}
	}
}
