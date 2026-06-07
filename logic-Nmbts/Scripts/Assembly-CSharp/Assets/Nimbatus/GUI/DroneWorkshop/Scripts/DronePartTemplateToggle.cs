using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class DronePartTemplateToggle : MonoBehaviour
	{
		public GameObject ActiveGameObject;

		public GameObject InactiveGameObject;

		public UITexture Icon;

		public Color SelectedColor;

		public Color NormalColor;

		[HideInInspector]
		public LoadAllDroneParts DronePartList;

		private bool _hover;

		public void Update()
		{
			if (DronePartList.ShowTemplates)
			{
				ActiveGameObject.SetActive(true);
				InactiveGameObject.SetActive(false);
				Icon.color = SelectedColor;
				return;
			}
			ActiveGameObject.SetActive(false);
			InactiveGameObject.SetActive(true);
			if (_hover)
			{
				Icon.color = SelectedColor;
			}
			else
			{
				Icon.color = NormalColor;
			}
		}

		public void OnClick()
		{
			DronePartList.SelectedDronePartType = EDronePartType.None;
			DronePartList.ShowTemplates = true;
			DronePartList.FillUp();
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show("Drone Part Templates");
			if (!show)
			{
				NimbatusToolTip.Show(null);
			}
		}

		protected virtual void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
