using System;
using UnityEngine;

namespace Assets.Scripts.UI.CurveEditor
{
	public class ClickEventArgs : EventArgs
	{
		public Vector2 DeltaPosition { get; set; }

		public float DragDistanceSinceBegin { get; set; }

		public FingerToolMode FingerToolMode { get; set; }

		public InputButton InputButton { get; set; }

		public InputState InputState { get; set; }

		public bool IsTouch => PointerId >= 0;

		public bool IsTouchPrimary
		{
			get
			{
				if (PointerId >= 0)
				{
					return InputButton == InputButton.Primary;
				}
				return false;
			}
		}

		public int PointerId { get; set; }

		public Vector2 Position { get; set; }

		public Ray Ray { get; set; }
	}
}
