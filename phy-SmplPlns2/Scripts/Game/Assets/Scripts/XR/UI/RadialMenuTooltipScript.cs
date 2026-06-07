using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.XR.UI
{
	public class RadialMenuTooltipScript : MonoBehaviour
	{
		private RadialMenuButtonScript _activeButton;

		[SerializeField]
		private Image _background;

		[SerializeField]
		private Vector2 _backgroundPadding;

		private float _hoveredDurationLeft;

		private float _hoveredDurationRight;

		private bool _isVisible;

		[SerializeField]
		private TextMeshProUGUI _label;

		private RectTransform _rectTransform;

		private bool _skipDelay;

		[SerializeField]
		private float _tooltipDelay = 1f;

		public RadialMenuButtonScript HoveredLeft { get; private set; }

		public RadialMenuButtonScript HoveredRight { get; private set; }

		public bool IsVisible => _isVisible;

		public void SetHoveredButton(XRHandType hand, RadialMenuButtonScript button)
		{
			if (hand == XRHandType.Left)
			{
				if (_skipDelay)
				{
					if (button != null)
					{
						SetVisible(button);
					}
				}
				else if (button != HoveredLeft)
				{
					_hoveredDurationLeft = 0f;
				}
				HoveredLeft = button;
				return;
			}
			if (_skipDelay)
			{
				if (button != null)
				{
					SetVisible(button);
				}
			}
			else if (button != HoveredRight)
			{
				_hoveredDurationRight = 0f;
			}
			HoveredRight = button;
		}

		protected virtual void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
		}

		protected virtual void OnDisable()
		{
			HoveredLeft = null;
			HoveredRight = null;
			_skipDelay = false;
			_hoveredDurationLeft = 0f;
			_hoveredDurationRight = 0f;
			SetVisible(null);
		}

		protected virtual void Update()
		{
			bool flag = HoveredLeft != null;
			bool flag2 = HoveredRight != null;
			bool flag3 = flag || flag2;
			if (!flag3 && _isVisible)
			{
				SetVisible(null);
			}
			if (_skipDelay)
			{
				if (flag3)
				{
					_hoveredDurationLeft = _tooltipDelay;
					_hoveredDurationRight = _tooltipDelay;
					return;
				}
				if (!flag)
				{
					_hoveredDurationLeft -= Time.unscaledDeltaTime;
					if (_hoveredDurationLeft < 0f)
					{
						_hoveredDurationLeft = 0f;
					}
				}
				if (!flag2)
				{
					_hoveredDurationRight -= Time.unscaledDeltaTime;
					if (_hoveredDurationRight < 0f)
					{
						_hoveredDurationRight = 0f;
					}
				}
				if (_hoveredDurationLeft == 0f && _hoveredDurationRight == 0f)
				{
					_skipDelay = false;
				}
				return;
			}
			if (flag)
			{
				_hoveredDurationLeft += Time.unscaledDeltaTime;
				if (_hoveredDurationLeft > _tooltipDelay)
				{
					_hoveredDurationLeft = _tooltipDelay;
				}
			}
			if (flag2)
			{
				_hoveredDurationRight += Time.unscaledDeltaTime;
				if (_hoveredDurationRight > _tooltipDelay)
				{
					_hoveredDurationRight = _tooltipDelay;
				}
			}
			if (_hoveredDurationRight >= _tooltipDelay)
			{
				_skipDelay = true;
				SetVisible(HoveredRight);
			}
			else if (_hoveredDurationLeft >= _tooltipDelay)
			{
				_skipDelay = true;
				SetVisible(HoveredLeft);
			}
		}

		private void SetVisible(RadialMenuButtonScript button)
		{
			if (!(_activeButton == button))
			{
				_activeButton = button;
				_isVisible = button != null && !string.IsNullOrWhiteSpace(button.Tooltip);
				if (_isVisible)
				{
					_label.gameObject.SetActive(value: true);
					_background.gameObject.SetActive(value: true);
					_label.text = _activeButton.Tooltip;
					_label.rectTransform.sizeDelta = new Vector2(100f, 10f);
					_label.ForceMeshUpdate(ignoreActiveState: true);
					Vector2 sizeDelta = (Vector2)_label.textBounds.size + _backgroundPadding;
					_rectTransform.sizeDelta = sizeDelta;
				}
				else
				{
					_label.gameObject.SetActive(value: false);
					_background.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
