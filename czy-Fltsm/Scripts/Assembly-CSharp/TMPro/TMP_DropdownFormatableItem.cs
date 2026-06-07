using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TMPro
{
	[RequireComponent(typeof(Selectable))]
	public class TMP_DropdownFormatableItem : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private TMP_DropdownItemFormatter _formatter;

		[SerializeField]
		private Toggle _toggle;

		private bool _enable;

		public bool Interactable
		{
			get
			{
				if (_toggle.isActiveAndEnabled)
				{
					return _toggle.interactable;
				}
				return false;
			}
			set
			{
				_toggle.interactable = value;
			}
		}

		private void OnEnable()
		{
			_enable = true;
		}

		private void OnDisable()
		{
			_formatter.OnItemDisabled(this);
		}

		private void LateUpdate()
		{
			if (_enable)
			{
				_formatter.OnItemEnabled(this);
				_enable = false;
			}
		}

		public void Select()
		{
			if ((bool)_toggle)
			{
				EventSystem.current.SetSelectedGameObject(_toggle.gameObject);
			}
		}

		public void Hide()
		{
			RectTransform rectTransform = base.transform as RectTransform;
			RectTransform rectTransform2 = _scrollRect.transform as RectTransform;
			RectTransform content = _scrollRect.content;
			content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, content.sizeDelta.y - rectTransform.sizeDelta.y);
			if (content.sizeDelta.y < rectTransform2.sizeDelta.y)
			{
				rectTransform2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, content.sizeDelta.y);
			}
			base.gameObject.SetActive(value: false);
		}

		public bool IsSelected()
		{
			return EventSystem.current.currentSelectedGameObject == _toggle.gameObject;
		}
	}
}
