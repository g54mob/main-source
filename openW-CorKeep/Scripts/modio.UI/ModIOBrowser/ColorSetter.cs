using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	internal class ColorSetter : MonoBehaviour
	{
		public ColorSetterType type;

		private MultiTargetButton button;

		private void OnEnable()
		{
			if (SharedUi.colorScheme != null)
			{
				Refresh(SharedUi.colorScheme);
			}
		}

		private void SetGraphicColor(Color color)
		{
			Graphic component = GetComponent<Graphic>();
			if (component != null)
			{
				float a = component.color.a;
				color.a = a;
				component.color = color;
			}
		}

		private void SetSelectableColorBlock(ColorBlock colors)
		{
			Selectable component = GetComponent<Selectable>();
			if (component != null)
			{
				component.colors = colors;
			}
		}

		private void SetDropdownColorBlocks()
		{
		}

		internal void Refresh()
		{
			ColorScheme componentInParent = GetComponentInParent<ColorScheme>();
			if (componentInParent != null)
			{
				componentInParent.RefreshUI();
			}
		}

		internal void Refresh(ColorScheme scheme)
		{
			switch (type)
			{
			case ColorSetterType.Button:
				SetSelectableColorBlock(scheme.GetColorBlock_Button());
				break;
			case ColorSetterType.Dropdown:
				SetSelectableColorBlock(scheme.GetColorBlock_Button());
				break;
			default:
				SetGraphicColor(scheme.GetSchemeColor(type));
				break;
			}
		}
	}
}
