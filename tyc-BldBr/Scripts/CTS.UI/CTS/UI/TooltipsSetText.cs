using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CTS.UI
{
	public class TooltipsSetText : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private TextMeshProUGUI _titleComponent;

		[SerializeField]
		private TextMeshProUGUI _textComponent;

		[SerializeField]
		private TextMeshProUGUI _textBottom;

		[HideInInspector]
		public string titleString;

		[HideInInspector]
		public string textString;

		[HideInInspector]
		public string bottomString;

		[HideInInspector]
		public string masternameString;

		[HideInInspector]
		public string descriptionString;

		private bool _hideWhenPointerOut;

		private Coroutine _hideCoroutine;

		private Color _titleColor;

		private Color _contentColor;

		private Color _bottomColor;

		private Color _invisibleColor = new Color(0f, 0f, 0f, 0f);

		public bool HavePointer { get; private set; }

		private void Awake()
		{
			_titleColor = _titleComponent.color;
			_contentColor = _textComponent.color;
			_bottomColor = _textBottom.color;
		}

		private void OnEnable()
		{
			_titleComponent.text = titleString;
			_textComponent.text = textString;
			_textBottom.text = bottomString;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			HavePointer = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			HavePointer = false;
			if (_hideWhenPointerOut)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		public void HideWhenPointerOut(bool hideValue)
		{
			if (hideValue)
			{
				if (_hideCoroutine == null)
				{
					_hideCoroutine = StartCoroutine(HideCor(hideValue: true));
				}
			}
			else if (_hideCoroutine != null)
			{
				StopCoroutine(_hideCoroutine);
				_hideCoroutine = null;
			}
		}

		public void RefreshComponenets()
		{
			_titleComponent.text = titleString;
			_textComponent.text = textString;
			_textBottom.text = bottomString;
		}

		public void SetVisibleText(bool visible)
		{
			_titleComponent.color = (visible ? _titleColor : _invisibleColor);
			_textComponent.color = (visible ? _contentColor : _invisibleColor);
			_textBottom.color = (visible ? _bottomColor : _invisibleColor);
		}

		public Vector2 RefreshSize()
		{
			Vector2 result = new Vector2(0f, 0f);
			Vector2 vector = (string.IsNullOrWhiteSpace(_titleComponent.text) ? Vector2.zero : _titleComponent.GetRenderedValues(onlyVisibleCharacters: true));
			Vector2 vector2 = (string.IsNullOrWhiteSpace(_textComponent.text) ? Vector2.zero : _textComponent.GetRenderedValues(onlyVisibleCharacters: true));
			Vector2 vector3 = (string.IsNullOrWhiteSpace(_textBottom.text) ? Vector2.zero : _textBottom.GetRenderedValues(onlyVisibleCharacters: true));
			result.x = vector.x;
			if (vector2.x > result.x)
			{
				result.x = vector2.x;
			}
			if (vector3.x > result.x)
			{
				result.x = vector3.x;
			}
			result.x += _titleComponent.rectTransform.anchoredPosition.x * 2f;
			result.y = Mathf.Abs(_titleComponent.rectTransform.anchoredPosition.y);
			if (!string.IsNullOrWhiteSpace(_titleComponent.text))
			{
				result.y += vector.y;
				result.y += Mathf.Abs(_titleComponent.rectTransform.anchoredPosition.y);
			}
			if (!string.IsNullOrWhiteSpace(_textComponent.text))
			{
				result.y += vector2.y;
				result.y += Mathf.Abs(_titleComponent.rectTransform.anchoredPosition.y);
			}
			if (!string.IsNullOrWhiteSpace(_textBottom.text))
			{
				result.y += vector3.y;
				result.y += Mathf.Abs(_titleComponent.rectTransform.anchoredPosition.y);
			}
			return result;
		}

		private IEnumerator HideCor(bool hideValue)
		{
			yield return null;
			if (!HavePointer && hideValue)
			{
				base.gameObject.SetActive(value: false);
			}
			else
			{
				_hideWhenPointerOut = hideValue;
			}
			_hideCoroutine = null;
		}
	}
}
