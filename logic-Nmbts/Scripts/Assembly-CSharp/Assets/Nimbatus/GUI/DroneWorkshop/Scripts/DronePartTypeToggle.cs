using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class DronePartTypeToggle : MonoBehaviour
	{
		public GameObject ActiveGameObject;

		public GameObject InactiveGameObject;

		public UITexture Icon;

		public Color SelectedColor;

		public Color NormalColor;

		[HideInInspector]
		public LoadAllDroneParts DronePartList;

		public EDronePartType Type;

		private bool _hover;

		public bool HasUnlockedParts()
		{
			return SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<DronePart>().Any((DronePart d) => d.Unlocked && d.DronePartType == Type);
		}

		public void Update()
		{
			if (DronePartList.SelectedDronePartType == Type && !DronePartList.ShowTemplates)
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
			DronePartList.ShowTemplates = false;
			DronePartList.SelectedDronePartType = Type;
			DronePartList.FillUp();
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(Type.ToLocalizationString());
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
