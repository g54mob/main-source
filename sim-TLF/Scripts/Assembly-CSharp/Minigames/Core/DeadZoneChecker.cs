using UnityEngine;

namespace Minigames.Core
{
	public class DeadZoneChecker
	{
		private RectTransform[] _deadZones;

		private Canvas _canvas;

		public DeadZoneChecker(RectTransform[] deadZones, Canvas canvas)
		{
			_deadZones = deadZones;
			_canvas = canvas;
		}

		public bool IsInDeadZone(Vector2 localPos, RectTransform canvasTransform)
		{
			if (_deadZones == null || _deadZones.Length == 0)
			{
				return false;
			}
			Vector2 screenPoint = canvasTransform.TransformPoint(localPos);
			RectTransform[] deadZones = _deadZones;
			foreach (RectTransform rectTransform in deadZones)
			{
				if (!(rectTransform == null) && RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPoint, _canvas.worldCamera))
				{
					return true;
				}
			}
			return false;
		}
	}
}
