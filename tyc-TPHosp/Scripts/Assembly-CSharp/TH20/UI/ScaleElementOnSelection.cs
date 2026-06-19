using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20.UI
{
	public class ScaleElementOnSelection : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Vector2 _sizeDelta;

		[SerializeField]
		private float _rate = 10f;

		private bool _isActive;

		private bool _stayActiveAfterPointerExit;

		private RectTransform _rectTransform;

		private Vector2 _initialSize;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_initialSize = _rectTransform.sizeDelta;
		}

		private void Update()
		{
			Vector2 vector = (_isActive ? (_initialSize + _sizeDelta) : _initialSize);
			Vector2 sizeDelta = _rectTransform.sizeDelta;
			if (Vector2.Distance(sizeDelta, vector) < 1f)
			{
				_rectTransform.sizeDelta = vector;
				return;
			}
			sizeDelta.x = MathUtils.InterpolateTo(sizeDelta.x, vector.x, _rate, Time.unscaledDeltaTime);
			sizeDelta.y = MathUtils.InterpolateTo(sizeDelta.y, vector.y, _rate, Time.unscaledDeltaTime);
			_rectTransform.sizeDelta = sizeDelta;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_isActive = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (!_stayActiveAfterPointerExit)
			{
				_isActive = false;
			}
		}

		public void SetKeepSizeAfterPointerExit(bool keepSize)
		{
			_stayActiveAfterPointerExit = keepSize;
			if (!_stayActiveAfterPointerExit)
			{
				_isActive = false;
			}
		}

		public void SetActive(bool active)
		{
			_isActive = active;
		}
	}
}
