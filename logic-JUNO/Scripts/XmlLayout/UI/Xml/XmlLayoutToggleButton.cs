using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Xml
{
	[RequireComponent(typeof(Toggle))]
	public class XmlLayoutToggleButton : XmlLayoutButton
	{
		[Header("ToggleButton Colors")]
		public Color SelectedBackgroundColor;

		public Color SelectedIconColor;

		public Color DeselectedBackgroundColor;

		public Color DeselectedIconColor;

		public Sprite SelectedIconSprite;

		public Sprite DeselectedIconSprite;

		private Toggle m_Toggle;

		private Image m_Image;

		private EventSystem m_eventSystem;

		public Toggle Toggle
		{
			get
			{
				if (m_Toggle == null)
				{
					m_Toggle = GetComponent<Toggle>();
				}
				return m_Toggle;
			}
		}

		public Image Image
		{
			get
			{
				if (m_Image == null)
				{
					m_Image = GetComponent<Image>();
				}
				return m_Image;
			}
		}

		protected EventSystem eventSystem
		{
			get
			{
				if (m_eventSystem == null)
				{
					m_eventSystem = Object.FindObjectOfType<EventSystem>();
				}
				return m_eventSystem;
			}
		}

		private void Start()
		{
			Toggle.onValueChanged.AddListener(delegate(bool e)
			{
				ToggleValue(e);
			});
			ToggleValue(Toggle.isOn);
		}

		private void OnValidate()
		{
			ToggleValue(Toggle.isOn);
		}

		private void ToggleValue(bool isOn)
		{
			if (isOn)
			{
				ToggleOn();
			}
			else
			{
				ToggleOff();
			}
			if (eventSystem != null && eventSystem.currentSelectedGameObject == base.gameObject)
			{
				eventSystem.SetSelectedGameObject(null);
			}
		}

		private void ToggleOn()
		{
			Toggle.colors = Toggle.colors.SetNormalColor(SelectedBackgroundColor);
			if (TextComponent != null)
			{
				TextComponent.color = TextColors.pressedColor;
			}
			if (IconComponent != null)
			{
				IconComponent.color = SelectedIconColor;
				IconHoverColor = SelectedIconColor;
				IconColor = SelectedIconColor;
				if (SelectedIconSprite != null)
				{
					IconComponent.sprite = SelectedIconSprite;
				}
			}
		}

		private void ToggleOff()
		{
			Toggle.colors = Toggle.colors.SetNormalColor(DeselectedBackgroundColor);
			if (TextComponent != null)
			{
				TextComponent.color = TextColors.normalColor;
			}
			if (IconComponent != null)
			{
				IconComponent.color = DeselectedIconColor;
				IconHoverColor = DeselectedIconColor;
				IconColor = DeselectedIconColor;
				if (DeselectedIconSprite != null)
				{
					IconComponent.sprite = DeselectedIconSprite;
				}
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
		}

		public void UpdateDisplay()
		{
			ToggleValue(Toggle.isOn);
		}
	}
}
