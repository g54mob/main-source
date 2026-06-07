using System.Collections;
using UnityEngine;

namespace SLS.Widgets.Table
{
	public abstract class VisibleComponent : MonoBehaviour
	{
		protected RectTransform _rt;

		protected bool _isFirstUpdate;

		protected bool _isVisible;

		private Canvas _parentCanvas;

		public RectTransform rt => null;

		public bool IsVisible => false;

		private Canvas ParentCanvas => null;

		private IEnumerator OnRectTransformDimensionsChange()
		{
			return null;
		}

		protected abstract void BecameVisible();

		protected virtual bool ShouldPostponeUpdate()
		{
			return false;
		}

		public static Rect AsScreenSpace(RectTransform rectTransform)
		{
			return default(Rect);
		}

		public static bool IsRectVisible(RectTransform rectTransform)
		{
			return false;
		}
	}
}
