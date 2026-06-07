using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class QuickSelectPanel : MonoBehaviour, IDroneInformationList
	{
		public DroneInformationItem DroneItemPrefab;

		public GameObject FirstVisitPanel;

		public UITable ResultGrid;

		public QuickSelectDroneInformationPanel InfoPanel;

		private DroneSelectionManager _manager;

		private DroneData _selectedDrone;

		private List<DroneData> _drones;

		public void Init(DroneSelectionManager manager)
		{
			_manager = manager;
			FillUpDrones();
		}

		private void FillUpDrones()
		{
			(from Transform child in ResultGrid.transform
				select child.gameObject).ToList().ForEach(Object.Destroy);
			_drones = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones;
			_drones = (from d in _drones
				orderby d.LastUseTime descending
				where d.IsCompatible()
				select d).Take(3).ToList();
			if (_drones.Count <= 0)
			{
				FirstVisitPanel.gameObject.SetActive(true);
				return;
			}
			FirstVisitPanel.gameObject.SetActive(false);
			foreach (DroneData drone in _drones)
			{
				DroneInformationItem droneInformationItem = Object.Instantiate(DroneItemPrefab);
				droneInformationItem.Init(this, drone);
				droneInformationItem.gameObject.transform.position = ResultGrid.transform.position;
				droneInformationItem.gameObject.transform.parent = ResultGrid.transform;
				droneInformationItem.gameObject.transform.localScale = ResultGrid.transform.localScale;
			}
			SelectDrone(_drones.First());
		}

		public DroneData GetSelectedDrone()
		{
			return _selectedDrone;
		}

		public void SelectDrone(DroneData drone)
		{
			_selectedDrone = drone;
			if (_selectedDrone != null)
			{
				InfoPanel.gameObject.SetActive(true);
				InfoPanel.Init(this);
			}
			else
			{
				InfoPanel.gameObject.SetActive(false);
			}
		}
	}
}
