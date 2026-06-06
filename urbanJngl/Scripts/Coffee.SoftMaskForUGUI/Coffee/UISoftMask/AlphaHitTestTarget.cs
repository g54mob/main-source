using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	[ExecuteAlways]
	[RequireComponent(typeof(Graphic))]
	[DisallowMultipleComponent]
	public class AlphaHitTestTarget : MonoBehaviour, ICanvasRaycastFilter
	{
		private Graphic _graphic;

		public Graphic graphic
		{
			get
			{
				if (!_graphic && !TryGetComponent<Graphic>(out _graphic))
				{
					return null;
				}
				return _graphic;
			}
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		bool ICanvasRaycastFilter.IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			if (!base.isActiveAndEnabled || !graphic || !graphic.IsActive())
			{
				return true;
			}
			return Utils.AlphaHitTestValid(graphic, sp, eventCamera, 0.01f);
		}
	}
}
