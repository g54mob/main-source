using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DeployCosts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ShowDeployCost : MonoBehaviour
	{
		public UILabel Label;

		public GameObject ResourceIcon;

		public void Update()
		{
			DeployCost deployCost = DeployCostHelper.CalculateDeployCost(DronePartManager.Instance.ActiveNumberOfDroneParts);
			if (RuntimeGlobals.GameModeSettings.DeployCost && !(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation is WormHoleLocationData))
			{
				ResourceIcon.SetActive(true);
				string translation = LocalizationManager.GetTermTranslation("DroneWorkshop/DeployCost");
				LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string> { 
				{
					"Count",
					DronePartManager.Instance.ActiveNumberOfDroneParts.ToString()
				} });
				Label.text = translation + " ";
				UILabel label = Label;
				label.text = label.text + LabelHelper.Orange + Mathf.Abs(deployCost.ResourceAmount);
			}
			else
			{
				ResourceIcon.SetActive(false);
				Label.text = LabelHelper.White + LocalizationManager.GetTermTranslation("DroneWorkshop/Parts") + " " + LabelHelper.Orange + DronePartManager.Instance.ActiveNumberOfDroneParts;
			}
		}
	}
}
