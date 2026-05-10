using System;
using UnityEngine;

namespace CTS.UI
{
	[Serializable]
	public struct TooltipsShowingInfo
	{
		public Transform _ToolTipPosition;

		public Vector2 _size;

		public TooltipsManager.EPivotPosition _pivot;

		public bool _useDefaultSize;
	}
}
