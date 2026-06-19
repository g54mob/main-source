using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class ScaleElementOnMouseOver : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Vector2 _sizeDelta;

		[SerializeField]
		private float _rate = 10f;

		private bool _isActive;

		private RectTransform _rectTransform;

		private Vector2 _initialSize;

		private void OnEnable()
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
			_isActive = false;
		}
	}
}
