using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DeleteDronePanel : MonoBehaviour
	{
		public UILabel Title;

		public DeleteDroneButton DeleteButton;

		public CancelDeleteButton CancelButton;

		public UITexture DroneImage;

		private DroneSelectionManager _selectionManager;

		private DroneData _data;

		public void Init(DroneSelectionManager manager, DroneData item)
		{
			_selectionManager = manager;
			_data = item;
			DeleteButton.Init(this);
			CancelButton.Init(this);
			Title.text = item.DroneName;
			DroneImage.mainTexture = item.Image;
			if (DroneImage.mainTexture != null)
			{
				DroneImage.mainTexture.wrapMode = TextureWrapMode.Clamp;
			}
		}

		public void DeleteDrone()
		{
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DeleteDrone(_data);
			_selectionManager.UpdateList();
			_selectionManager.HideDeletePanel();
			_selectionManager.SelectDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.LastOrDefault());
			SaveManager.StoreSaveGame(false, false);
		}

		public void CancelDelete()
		{
			_selectionManager.HideDeletePanel();
		}
	}
}
