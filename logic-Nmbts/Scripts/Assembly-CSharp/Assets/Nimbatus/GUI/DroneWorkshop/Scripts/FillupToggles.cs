using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class FillupToggles : MonoBehaviour
	{
		public List<DronePartTypeToggle> Toggles;

		public UIGrid ToggleGrid;

		public LoadAllDroneParts DronePartList;

		public DronePartTemplateToggle TemplateToggle;

		public void Start()
		{
			FillUp();
		}

		public void Update()
		{
			ToggleGrid.enabled = true;
		}

		public void FillUp()
		{
			ToggleGrid.gameObject.SetActive(true);
			ToggleGrid.enabled = true;
			(from Transform child in ToggleGrid.transform
				select child.gameObject).ToList().ForEach(Object.Destroy);
			bool flag = false;
			foreach (DronePartTypeToggle toggle in Toggles)
			{
				DronePartTypeToggle dronePartTypeToggle = InstantiateToggleButton(toggle);
				if (!flag && dronePartTypeToggle != null)
				{
					DronePartList.SelectedDronePartType = dronePartTypeToggle.Type;
					flag = true;
				}
			}
			if (RuntimeGlobals.GameModeSettings.HasTemplates && !RuntimeGlobals.GameModeSettings.InCampaignTutorial)
			{
				DronePartTemplateToggle dronePartTemplateToggle = Object.Instantiate(TemplateToggle);
				dronePartTemplateToggle.DronePartList = DronePartList;
				dronePartTemplateToggle.transform.position = ToggleGrid.transform.position;
				dronePartTemplateToggle.transform.parent = ToggleGrid.transform;
				dronePartTemplateToggle.transform.localScale = ToggleGrid.transform.localScale;
				ToggleGrid.repositionNow = true;
			}
		}

		private DronePartTypeToggle InstantiateToggleButton(DronePartTypeToggle toggle)
		{
			if ((toggle.Type == EDronePartType.None && (SaveManager.LoadedSave.Settings.HasPartUnlocking || SaveManager.LoadedSave.Settings.ShowAllDroneParts)) || (toggle.Type != EDronePartType.None && toggle.HasUnlockedParts()))
			{
				DronePartTypeToggle dronePartTypeToggle = Object.Instantiate(toggle);
				dronePartTypeToggle.DronePartList = DronePartList;
				dronePartTypeToggle.transform.position = ToggleGrid.transform.position;
				dronePartTypeToggle.transform.parent = ToggleGrid.transform;
				dronePartTypeToggle.transform.localScale = ToggleGrid.transform.localScale;
				ToggleGrid.repositionNow = true;
				return dronePartTypeToggle;
			}
			return null;
		}
	}
}
