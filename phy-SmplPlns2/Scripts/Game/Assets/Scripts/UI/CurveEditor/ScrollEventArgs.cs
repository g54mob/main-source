using System;
using UnityEngine;

namespace Assets.Scripts.UI.CurveEditor
{
	public class ScrollEventArgs : EventArgs
	{
		public Vector2 Delta { get; set; }
	}
}
