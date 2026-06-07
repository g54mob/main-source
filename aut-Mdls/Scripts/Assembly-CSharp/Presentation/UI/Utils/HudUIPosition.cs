using System;
using Data.Variables;
using UnityEngine;

namespace Presentation.UI.Utils
{
	[Serializable]
	public struct HudUIPosition
	{
		public BoolVariableSO BoolVariable;

		public Vector2 InactivePosition;

		public Vector2 ActivePosition;

		public bool IgnoreZero;
	}
}
