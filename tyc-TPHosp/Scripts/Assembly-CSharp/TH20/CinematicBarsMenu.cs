using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CinematicBarsMenu : MenuBase
	{
		[SerializeField]
		private Image _topBars;

		[SerializeField]
		private Image _bottomBars;

		[SerializeField]
		private float _animateInSpeed = 1.5f;

		[SerializeField]
		private float _animateOutSpeed = 1f;

		private bool _animateIn;

		private float _topBarHeight;

		private float _bottomBarHeight;

		private float _t;

		public bool IsShowing => _t > 0f;

		private void Start()
		{
			_topBarHeight = _topBars.rectTransform.sizeDelta.y;
			_bottomBarHeight = _bottomBars.rectTransform.sizeDelta.y;
		}

		public void Show()
		{
			_animateIn = true;
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
		}

		public void Hide()
		{
			_animateIn = false;
		}

		protected override void Update()
		{
			if (_animateIn)
			{
				_t += Time.unscaledDeltaTime / _animateInSpeed;
				_t = Mathf.Clamp01(_t);
				float t = EasingsUtils.CubicEaseOut(_t);
				float y = Mathf.Lerp(_topBarHeight, 0f, t);
				_topBars.rectTransform.anchoredPosition = new Vector2(_topBars.rectTransform.localPosition.x, y);
				float y2 = Mathf.Lerp(0f - _bottomBarHeight, 0f, t);
				_bottomBars.rectTransform.anchoredPosition = new Vector2(_bottomBars.rectTransform.localPosition.x, y2);
			}
			else
			{
				_t -= Time.unscaledDeltaTime / _animateOutSpeed;
				_t = Mathf.Clamp01(_t);
				float t2 = EasingsUtils.CubicEaseOut(_t);
				float y3 = Mathf.Lerp(_topBarHeight, 0f, t2);
				_topBars.rectTransform.anchoredPosition = new Vector2(_topBars.rectTransform.anchoredPosition.x, y3);
				float y4 = Mathf.Lerp(0f - _bottomBarHeight, 0f, t2);
				_bottomBars.rectTransform.anchoredPosition = new Vector2(_bottomBars.rectTransform.anchoredPosition.x, y4);
				if (_t <= 0f)
				{
					GameObjectUtils.SetActive(base.gameObject, isActive: false);
				}
			}
			base.Update();
		}
	}
}
