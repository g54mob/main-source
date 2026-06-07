using System;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class LocalDroneList : MonoBehaviour
	{
		public UIGrid ResultGrid;

		public UIScrollView ResultScrollView;

		public LocalDroneItem DroneItemPrefab;

		[HideInInspector]
		public DroneData SelectedDrone;

		public event Action SelectedDroneChanged;

		public void Init()
		{
			ResultGrid.transform.DestroyAllChildren();
			foreach (DroneData drone in SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones)
			{
				LocalDroneItem localDroneItem = UnityEngine.Object.Instantiate(DroneItemPrefab);
				localDroneItem.Init(this, drone);
				localDroneItem.gameObject.transform.position = ResultGrid.transform.position;
				localDroneItem.gameObject.transform.parent = ResultGrid.transform;
				localDroneItem.gameObject.transform.localScale = ResultGrid.transform.localScale;
			}
			ResultGrid.enabled = true;
			ResultGrid.Reposition();
			ResultGrid.repositionNow = true;
			ResultScrollView.UpdateScrollbars(true);
		}

		public void SelectItem(DroneData drone)
		{
			SelectedDrone = drone;
			Action action = this.SelectedDroneChanged;
			if (action != null)
			{
				action();
			}
		}
	}
}
