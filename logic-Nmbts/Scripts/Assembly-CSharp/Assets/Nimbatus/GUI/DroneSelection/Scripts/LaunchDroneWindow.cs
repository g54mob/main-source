using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DeployCosts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class LaunchDroneWindow : MonoBehaviour
	{
		public AcceptLaunchButton LaunchButton;

		public CancelLaunchButton CancelButton;

		[Header("Threat")]
		public GameObject ThreatContainer;

		public UILabel ThreatLabelCost;

		public UILabel ThreatLabelCurrent;

		public UILabel ThreatLabelResult;

		[Header("Resources")]
		public GameObject ResourceContainer;

		public UITexture ResourceCostIcon;

		public UILabel ResourceLabelCost;

		public UILabel ResourceLabelCurrent;

		public UILabel ResourceLabelResult;

		private DroneSelectionManager _selectionManager;

		private Action _launchAction;

		private float _threatX;

		private float _resourceX;

		public void Init(DroneSelectionManager manager)
		{
			_selectionManager = manager;
			LaunchButton.Init(this);
			CancelButton.Init(this);
			_threatX = ThreatContainer.transform.localPosition.x;
			_resourceX = ResourceContainer.transform.localPosition.x;
		}

		public void InitDrone(DroneData drone, Action launchAction)
		{
			_launchAction = launchAction;
			float currentThreatLevel = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.CurrentThreatLevel;
			DeployCost deployCost = DeployCostHelper.CalculateDeployCost(drone.NumberOfParts);
			double num = Math.Floor(SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetAvailableResources(deployCost.Resource));
			ThreatLabelCost.text = ((deployCost.Threat > 0f) ? LabelHelper.DarkOrange : LabelHelper.White) + "+ " + deployCost.Threat + "%";
			ThreatLabelCurrent.text = LabelHelper.LightGrey + currentThreatLevel.ToString("F2") + "%";
			ThreatLabelResult.text = LabelHelper.LightGrey + Mathf.Clamp(currentThreatLevel + deployCost.Threat, 0f, 100f).ToString("F2") + "%";
			ResourceLabelCost.text = LabelHelper.DarkOrange + " - " + Mathf.Abs(deployCost.ResourceAmount);
			ResourceLabelCurrent.text = LabelHelper.LightGrey + num;
			ResourceLabelResult.text = LabelHelper.LightGrey + (num + (double)deployCost.ResourceAmount);
			ResourceCostIcon.mainTexture = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(deployCost.Resource).Icon;
			if (deployCost.ResourceAmount == 0)
			{
				ResourceContainer.SetActive(false);
				Vector3 localPosition = ThreatContainer.transform.localPosition;
				localPosition.x = 0f;
				ThreatContainer.transform.localPosition = localPosition;
				return;
			}
			if (deployCost.Threat <= float.Epsilon)
			{
				ThreatContainer.SetActive(false);
				Vector3 localPosition2 = ResourceContainer.transform.localPosition;
				localPosition2.x = 0f;
				ResourceContainer.transform.localPosition = localPosition2;
				return;
			}
			ThreatContainer.SetActive(true);
			ResourceContainer.SetActive(true);
			Vector3 localPosition3 = ThreatContainer.transform.localPosition;
			localPosition3.x = _threatX;
			ThreatContainer.transform.localPosition = localPosition3;
			localPosition3 = ResourceContainer.transform.localPosition;
			localPosition3.x = _resourceX;
			ResourceContainer.transform.localPosition = localPosition3;
		}

		public void LaunchDrone()
		{
			Action launchAction = _launchAction;
			if (launchAction != null)
			{
				launchAction();
			}
		}

		public void CancelLaunch()
		{
			_selectionManager.HideLaunchPanel();
		}
	}
}
