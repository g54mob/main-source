using UnityEngine;

namespace Assets.Behaviour.UI
{
	public class UIResolutionScaling : MonoBehaviour
	{
		[SerializeField]
		private float _baseResolution = 2560f;

		[SerializeField]
		private bool _scaleDown = true;

		[SerializeField]
		private bool _scaleUp;

		private bool _initialized;

		private Vector2 _anchorMin;

		private Vector2 _anchorMax;

		private Vector2 _anchoredPosition;

		private void OnEnable()
		{
			UpdateResolutionScale();
			ResolutionManager.Add(this);
		}

		public void UpdateResolutionScale()
		{
			float num = (float)Screen.width / _baseResolution;
			if (!_scaleUp)
			{
				num = Mathf.Clamp01(num);
			}
			if (!_scaleDown)
			{
				num = Mathf.Max(1f, num);
			}
			base.transform.localScale = new Vector3(num, num, 1f);
			if (base.transform is RectTransform rectTransform)
			{
				if (!_initialized)
				{
					_initialized = true;
					_anchorMin = rectTransform.anchorMin;
					_anchorMax = rectTransform.anchorMax;
					_anchoredPosition = rectTransform.anchoredPosition;
				}
				float num2 = _anchorMax.x - _anchorMin.x;
				float num3 = _anchorMax.y - _anchorMin.y;
				float num4 = 1f / num - 1f;
				rectTransform.anchoredPosition = new Vector2(_anchoredPosition.x * num, _anchoredPosition.y * num);
				rectTransform.anchorMin = new Vector2(_anchorMin.x * (1f + num4 * num2), _anchorMin.y * (1f + num4 * num3));
				rectTransform.anchorMax = new Vector2(_anchorMax.x * (1f + num4 * num2), _anchorMax.y * (1f + num4 * num3));
			}
		}
	}
}
