using System.Linq;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class HeaderElement : ItemElement
	{
		private bool _collapsed;

		private string _label;

		private TextMeshProUGUI _labelText;

		private string _subtitle;

		private TextMeshProUGUI _subtitleText;

		public override bool Collapsed => !base.Group.Visible;

		protected string Label
		{
			get
			{
				return _label;
			}
			set
			{
				if (_label != value)
				{
					_label = value;
					_labelText.text = value;
				}
			}
		}

		private string Subtitle
		{
			get
			{
				return _subtitle;
			}
			set
			{
				if (_subtitle != value)
				{
					_subtitle = value;
					if (!string.IsNullOrWhiteSpace(value))
					{
						_subtitleText.gameObject.SetActive(value: true);
						_subtitleText.text = value;
					}
					else
					{
						_subtitleText.gameObject.SetActive(value: false);
					}
				}
			}
		}

		public HeaderElement(XmlElement xmlElement, HeaderModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			HeaderElement headerElement = this;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			XmlElement xmlElement2 = xmlElement;
			if (!xmlElement.HasClass("inspector-header"))
			{
				xmlElement2 = xmlElement2.GetChildElementsWithClass("inspector-header").FirstOrDefault();
			}
			if (!string.IsNullOrWhiteSpace(group.FullCollapsedId))
			{
				group.Collapsed = Game.Instance.Settings.UserPrefs.GetBool(group.FullCollapsedId, group.Collapsed);
			}
			if (xmlElement2 != null)
			{
				xmlElement2.AddOnClickEvent(delegate
				{
					headerElement.Group.Collapsed = !headerElement.Group.Collapsed;
					if (!string.IsNullOrWhiteSpace(headerElement.Group.FullCollapsedId))
					{
						Game.Instance.Settings.UserPrefs.SetBool(headerElement.Group.FullCollapsedId, headerElement.Group.Collapsed);
					}
				});
			}
			else
			{
				Debug.LogError("Could not find inspector-header class in HeaderElement template.");
			}
			if (group.Indentation > 0)
			{
				xmlElement.GetElementByInternalId("header-content").rectTransform.offsetMin = new Vector2(group.Indentation * 10, 0f);
			}
			if (model.OnMoveItem != null || model.OnDeleteItem != null)
			{
				xmlElement.GetElementByInternalId("move-panel").SetActive(active: true);
				Button elementByInternalId = xmlElement.GetElementByInternalId<Button>("move-up-button");
				Button elementByInternalId2 = xmlElement.GetElementByInternalId<Button>("move-down-button");
				if (model.OnMoveItem != null)
				{
					elementByInternalId.onClick.AddListener(delegate
					{
						model.OnMoveItem(-1);
					});
					elementByInternalId2.onClick.AddListener(delegate
					{
						model.OnMoveItem(1);
					});
				}
				else
				{
					elementByInternalId.gameObject.SetActive(value: false);
					elementByInternalId2.gameObject.SetActive(value: false);
				}
				xmlElement.GetElementByInternalId<Button>("delete-button").onClick.AddListener(delegate
				{
					model.OnDeleteItem();
				});
			}
			Label = group.Name;
			_subtitleText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("subtitle");
			Subtitle = group.Subtitle;
			if (string.IsNullOrWhiteSpace(Subtitle))
			{
				_labelText.rectTransform.anchorMax = Vector2.one;
				_labelText.overflowMode = TextOverflowModes.Overflow;
			}
			else
			{
				_labelText.rectTransform.anchorMax = new Vector2(0.5f, 1f);
				_labelText.overflowMode = TextOverflowModes.Ellipsis;
			}
			Update();
		}

		public override void Update()
		{
			if (_collapsed != base.Group.Collapsed)
			{
				_collapsed = base.Group.Collapsed;
				if (_collapsed)
				{
					base.XmlElement.AddClass("collapsed");
				}
				else
				{
					base.XmlElement.RemoveClass("collapsed");
				}
			}
			if (base.Group.Visible)
			{
				Label = base.Group.Name;
				Subtitle = base.Group.Subtitle;
			}
		}
	}
}
