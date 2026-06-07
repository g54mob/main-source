using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DeployCosts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DeployCostDisplay : MonoBehaviour
	{
		public UILabel ThreatLabel;

		public UILabel ResourceLabel;

		public UITexture ResourceIcon;

		public void Init(int parts)
		{
			DeployCost deployCost = DeployCostHelper.CalculateDeployCost(parts);
			if (DroneSelectionManager.HideLaunchButton || !SaveManager.LoadedSave.Settings.DeployCost)
			{
				base.gameObject.SetActive(false);
				return;
			}
			ThreatLabel.text = ((!SaveManager.LoadedSave.Settings.NimbatusHealthAndThreat) ? "" : (((deployCost.Threat > 0f) ? LabelHelper.Orange : LabelHelper.LightGrey) + "+" + deployCost.Threat + "% " + LocalizationManager.GetTermTranslation("CampaignMode/Threat")));
			ResourceIcon.mainTexture = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(deployCost.Resource).Icon;
			ResourceLabel.text = ((deployCost.ResourceAmount < 0) ? LabelHelper.Orange : LabelHelper.LightGrey) + deployCost.ResourceAmount;
		}
	}
}
