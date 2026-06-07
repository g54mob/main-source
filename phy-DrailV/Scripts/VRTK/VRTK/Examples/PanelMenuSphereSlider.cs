using UnityEngine;
using UnityEngine.UI;

namespace VRTK.Examples
{
	public class PanelMenuSphereSlider : MonoBehaviour
	{
		public Slider slider;

		public MeshRenderer changeObject;

		public VRTK_PanelMenuItemController panelMenuController;

		public Color[] colours = new Color[0];

		protected virtual void OnEnable()
		{
			if (panelMenuController != null)
			{
				panelMenuController.PanelMenuItemSwipeRight += PanelMenuItemSwipeRight;
				panelMenuController.PanelMenuItemSwipeLeft += PanelMenuItemSwipeLeft;
			}
		}

		protected virtual void OnDisable()
		{
			if (panelMenuController != null)
			{
				panelMenuController.PanelMenuItemSwipeRight -= PanelMenuItemSwipeRight;
				panelMenuController.PanelMenuItemSwipeLeft -= PanelMenuItemSwipeLeft;
			}
		}

		protected virtual void PanelMenuItemSwipeRight(object sender, PanelMenuItemControllerEventArgs e)
		{
			if (slider != null)
			{
				slider.value++;
				SetColor();
			}
		}

		protected virtual void PanelMenuItemSwipeLeft(object sender, PanelMenuItemControllerEventArgs e)
		{
			if (slider != null)
			{
				slider.value--;
				SetColor();
			}
		}

		protected virtual void SetColor()
		{
			if (slider.value < (float)colours.Length && changeObject != null)
			{
				changeObject.material.color = colours[(int)slider.value];
			}
		}
	}
}
