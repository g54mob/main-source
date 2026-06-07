using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml
{
	public class XmlLayoutToggleGroup : ToggleGroup
	{
		public Sprite ToggleBackgroundImage;

		public Color ToggleBackgroundColor;

		public Sprite ToggleSelectedImage;

		public Color ToggleSelectedColor;

		protected List<Toggle> m_toggleElements = new List<Toggle>();

		protected List<Action<int>> m_EventHandlers = new List<Action<int>>();

		protected List<Action<string>> m_TextEventHandlers = new List<Action<string>>();

		protected int m_previousValue = -1;

		private bool isHandlingSetSelectedValue;

		protected void OnValidate()
		{
			UpdateToggleElements();
		}

		public void UpdateToggleElements()
		{
			m_toggleElements.ForEach(delegate(Toggle t)
			{
				UpdateToggleElement(t);
			});
		}

		public void UpdateToggleElement(Toggle toggle)
		{
			if (!(toggle.GetComponent<XmlLayoutToggleButton>() != null))
			{
				Image component = toggle.targetGraphic.GetComponent<Image>();
				component.sprite = ToggleBackgroundImage;
				component.color = ToggleBackgroundColor;
				Image component2 = toggle.graphic.GetComponent<Image>();
				component2.sprite = ToggleSelectedImage;
				component2.color = ToggleSelectedColor;
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			UpdateToggleElements();
		}

		public void AddToggle(Toggle toggle)
		{
			toggle.group = this;
			m_toggleElements.Add(toggle);
		}

		public void AddOnValueChangedEventHandler(Action handler)
		{
			m_EventHandlers.Add(delegate
			{
				handler();
			});
		}

		public void AddOnValueChangedEventHandler(Action<int> handler)
		{
			m_EventHandlers.Add(handler);
		}

		public void AddOnValueChangedEventHandler(Action<string> handler)
		{
			m_TextEventHandlers.Add(handler);
		}

		private void ValueChanged(int newValue)
		{
			if (m_EventHandlers.Count > 0)
			{
				m_EventHandlers.ForEach(delegate(Action<int> e)
				{
					e(newValue);
				});
			}
			if (m_TextEventHandlers.Count <= 0)
			{
				return;
			}
			Toggle toggle = m_toggleElements[newValue];
			XmlLayoutToggleButton toggleButton = toggle.GetComponent<XmlLayoutToggleButton>();
			if (toggleButton != null)
			{
				m_TextEventHandlers.ForEach(delegate(Action<string> e)
				{
					e(toggleButton.TextComponent.text);
				});
			}
		}

		public int GetSelectedValue()
		{
			for (int i = 0; i < m_toggleElements.Count; i++)
			{
				if (m_toggleElements[i].isOn)
				{
					return i;
				}
			}
			return -1;
		}

		public string GetSelectedTextValue()
		{
			for (int i = 0; i < m_toggleElements.Count; i++)
			{
				if (m_toggleElements[i].isOn)
				{
					return GetTextValueForIndex(i);
				}
			}
			return null;
		}

		internal string GetTextValueForIndex(int index)
		{
			XmlLayoutToggleButton component = m_toggleElements[index].GetComponent<XmlLayoutToggleButton>();
			if (component != null)
			{
				return component.TextComponent.text;
			}
			return null;
		}

		public void SetSelectedValue(int newValue, bool fireEvent = true)
		{
			if (isHandlingSetSelectedValue || newValue == -1)
			{
				return;
			}
			isHandlingSetSelectedValue = true;
			for (int i = 0; i < m_toggleElements.Count; i++)
			{
				Toggle toggle = m_toggleElements[i];
				if (i == newValue)
				{
					toggle.isOn = i == newValue;
					if (toggle.isOn && i != m_previousValue && fireEvent)
					{
						ValueChanged(i);
					}
				}
			}
			m_previousValue = newValue;
			isHandlingSetSelectedValue = false;
		}

		public void SetSelectedValue(string newValue, bool fireEvent = true)
		{
			for (int i = 0; i < m_toggleElements.Count; i++)
			{
				if (GetTextValueForIndex(i) == newValue)
				{
					SetSelectedValue(i, fireEvent);
					break;
				}
			}
		}

		internal int GetValueForElement(Toggle element)
		{
			for (int i = 0; i < m_toggleElements.Count; i++)
			{
				if (m_toggleElements[i] == element)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
