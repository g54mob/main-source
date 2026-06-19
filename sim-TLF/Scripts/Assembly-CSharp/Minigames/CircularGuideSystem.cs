using MyBox;
using UnityEngine;
using UnityEngine.UI;

namespace Minigames
{
	public class CircularGuideSystem : MonoBehaviour
	{
		[SerializeField]
		private Image _guide;

		[SerializeField]
		private RectTransform _centerPoint;

		[SerializeField]
		private RectTransform _canvasRect;

		[SerializeField]
		private float _fadeOffset = 40f;

		private RectTransform _guideRect;

		private void Awake()
		{
			_guideRect = _guide.rectTransform;
		}

		private void Update()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, Input.mousePosition, null, out var localPoint);
			float value = Vector2.Distance(localPoint, _centerPoint.anchoredPosition);
			float b = _guideRect.sizeDelta.x * 0.5f;
			float a = Mathf.InverseLerp(_fadeOffset, b, value);
			_guide.SetAlpha(a);
		}
	}
}
