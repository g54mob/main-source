using System.Collections.Generic;
using ModApi.Services.Purchasing;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.ListView
{
	public class ListViewItemScript : MonoBehaviour
	{
		public enum FlairColorType
		{
			None = 0,
			Primary = 1,
			Danger = 2,
			Warning = 3,
			Success = 4
		}

		public enum StatusIconType
		{
			None = 0,
			Exclamation = 1,
			Checkmark = 2,
			Locked = 3
		}

		private XmlElement _icon;

		private bool _selected;

		private StatusIconType _statusIcon;

		private XmlElement _statusIconElement;

		private TextMeshProUGUI _subtitleText;

		private TextMeshProUGUI _titleText;

		public List<string> FilterKeywords { get; }

		public IInAppPurchaseFeature InAppFeature { get; internal set; }

		public object ItemModel { get; set; }

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
					if (_selected)
					{
						XmlElement.AddClass("selected");
					}
					else
					{
						XmlElement.RemoveClass("selected");
					}
				}
			}
		}

		public Sprite Sprite
		{
			get
			{
				return _icon.GetComponent<Image>()?.sprite;
			}
			set
			{
				_icon.GetComponent<Image>().sprite = value;
			}
		}

		public string SpriteResourcePath
		{
			get
			{
				return _icon.GetAttribute("sprite");
			}
			set
			{
				_icon.SetAndApplyAttribute("sprite", value);
			}
		}

		public StatusIconType StatusIcon
		{
			get
			{
				return _statusIcon;
			}
			set
			{
				if (_statusIcon != value)
				{
					if (_statusIcon == StatusIconType.Checkmark)
					{
						_statusIconElement.RemoveClass("status-checkmark");
					}
					else if (_statusIcon == StatusIconType.Exclamation)
					{
						_statusIconElement.RemoveClass("status-exclamation");
					}
					else if (_statusIcon == StatusIconType.Locked)
					{
						_statusIconElement.RemoveClass("status-lock");
					}
					_statusIcon = value;
					if (_statusIcon == StatusIconType.Checkmark)
					{
						_statusIconElement.AddClass("status-checkmark");
					}
					else if (_statusIcon == StatusIconType.Exclamation)
					{
						_statusIconElement.AddClass("status-exclamation");
					}
					else if (_statusIcon == StatusIconType.Locked)
					{
						_statusIconElement.AddClass("status-lock");
					}
				}
			}
		}

		public string StatusIconColor
		{
			get
			{
				return _statusIconElement.GetAttribute("color");
			}
			set
			{
				_statusIconElement.SetAndApplyAttribute("color", value);
			}
		}

		public string StatusIconTooltip
		{
			get
			{
				return _statusIconElement.GetAttribute("tooltip");
			}
			set
			{
				_statusIconElement.SetAndApplyAttribute("tooltip", value);
			}
		}

		public string Subtitle
		{
			get
			{
				return _subtitleText?.text;
			}
			set
			{
				if (_subtitleText != null)
				{
					_subtitleText.text = value;
				}
			}
		}

		public string Title
		{
			get
			{
				return _titleText.text;
			}
			set
			{
				_titleText.text = value;
			}
		}

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public bool VisibleInScrollView
		{
			get
			{
				ScrollRect componentInParent = GetComponentInParent<ScrollRect>();
				RectTransform component = GetComponent<RectTransform>();
				RectTransform component2 = componentInParent.GetComponent<RectTransform>();
				Vector3[] array = new Vector3[4];
				component.GetWorldCorners(array);
				bool flag = false;
				for (int i = 0; i < 4; i++)
				{
					flag = flag || RectTransformUtility.RectangleContainsScreenPoint(component2, array[i]);
				}
				return flag;
			}
		}

		public XmlElement XmlElement { get; private set; }

		public ListViewItemScript()
		{
			FilterKeywords = new List<string>();
		}

		public void Initialize(XmlElement element)
		{
			XmlElement = element;
			_titleText = XmlElement.GetElementByInternalId<TextMeshProUGUI>("title");
			_subtitleText = XmlElement.GetElementByInternalId<TextMeshProUGUI>("subtitle");
			_icon = XmlElement.GetElementByInternalId("icon");
			_statusIconElement = XmlElement.GetElementByInternalId("status-icon");
		}

		public void SetFlair(FlairColorType color, string text)
		{
			XmlElement elementByInternalId = XmlElement.GetElementByInternalId("flair");
			if (elementByInternalId != null)
			{
				XmlElement.GetElementByInternalId("flair-text").SetText(text);
				elementByInternalId.RemoveClass("primary");
				elementByInternalId.RemoveClass("danger");
				elementByInternalId.RemoveClass("warning");
				elementByInternalId.RemoveClass("success");
				switch (color)
				{
				case FlairColorType.None:
					elementByInternalId.SetActive(active: false);
					break;
				case FlairColorType.Primary:
					elementByInternalId.SetActive(active: true);
					elementByInternalId.AddClass("primary");
					break;
				case FlairColorType.Danger:
					elementByInternalId.SetActive(active: true);
					elementByInternalId.AddClass("danger");
					break;
				case FlairColorType.Warning:
					elementByInternalId.SetActive(active: true);
					elementByInternalId.AddClass("warning");
					break;
				case FlairColorType.Success:
					elementByInternalId.SetActive(active: true);
					elementByInternalId.AddClass("success");
					break;
				}
			}
		}
	}
}
