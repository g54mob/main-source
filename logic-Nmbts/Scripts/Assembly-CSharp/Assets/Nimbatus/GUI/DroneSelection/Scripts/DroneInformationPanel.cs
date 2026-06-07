using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Missions.UI;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions.UI;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DroneInformationPanel : MonoBehaviour
	{
		public UIInput TitleLabel;

		public UIInput DescriptionLabel;

		public UIScrollView DescriptionScrollView;

		public UITexture DroneImage;

		public SaveDroneToFile SaveButton;

		public DeleteDrone DeleteDroneButton;

		public EditDrone EditDroneButton;

		public DuplicateDrone DuplicateDroneButton;

		public DeployCostDisplay CostDisplay;

		public UploadDrone UploadDroneButton;

		public LaunchDrone LaunchDroneButton;

		public ShowDronePreconditions Preconditions;

		public MissionDescriptionUi MissionDisplay;

		public NotCompatiblePanel NotComptiblePanel;

		private DroneSelectionManager _manager;

		private DroneData _item;

		private bool _hasBeenChanged;

		public void Init(DroneSelectionManager droneSelectionManager, DroneData item)
		{
			if (_item != null)
			{
				SubmitChanges();
			}
			_hasBeenChanged = false;
			base.gameObject.SetActive(false);
			_manager = droneSelectionManager;
			_item = item;
			CostDisplay.Init(item.NumberOfParts);
			SaveButton.Init(this, item);
			DeleteDroneButton.Init(this, item);
			EditDroneButton.Init(item);
			DuplicateDroneButton.Init(this, item);
			UploadDroneButton.Init(this, item);
			LaunchDroneButton.Init(item);
			Preconditions.Init(item);
			Preconditions.gameObject.SetActive(!DroneSelectionManager.HideLaunchButton);
			if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.IsActiveInThisMode() && SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation != null && SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.Mission != EMissionType.None && !DroneSelectionManager.HideLaunchButton)
			{
				MissionDisplay.gameObject.SetActive(true);
				MissionDisplay.Init(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.Mission);
			}
			else
			{
				MissionDisplay.gameObject.SetActive(false);
			}
			NotComptiblePanel.Init(this, item);
			NotComptiblePanel.gameObject.SetActive(!item.IsCompatible());
			TitleLabel.value = _item.DroneName;
			DescriptionLabel.value = _item.Description;
			DescriptionScrollView.ResetPosition();
			DroneImage.mainTexture = item.Image;
			if (DroneImage.mainTexture != null)
			{
				DroneImage.mainTexture.wrapMode = TextureWrapMode.Clamp;
			}
			base.gameObject.SetActive(true);
		}

		public void OnEnable()
		{
			EventDelegate.Add(TitleLabel.onChange, SaveChanges);
			EventDelegate.Add(DescriptionLabel.onChange, SaveChanges);
		}

		public void OnDisable()
		{
			SubmitChanges();
			EventDelegate.Remove(TitleLabel.onChange, SaveChanges);
			EventDelegate.Remove(DescriptionLabel.onChange, SaveChanges);
		}

		public void SubmitChanges()
		{
			if (_item != null && _item.IsCompatible() && HasChanges())
			{
				SaveChanges();
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Save(_item);
				_hasBeenChanged = false;
			}
		}

		public void SaveChanges()
		{
			if (_item != null && (_item.Description != DescriptionLabel.value || _item.DroneName != TitleLabel.value))
			{
				_item.Description = DescriptionLabel.value;
				_item.DroneName = TitleLabel.value;
				_hasBeenChanged = true;
			}
		}

		public bool HasChanges()
		{
			if (_item == null)
			{
				return false;
			}
			if (_hasBeenChanged || _item.Description != DescriptionLabel.value || _item.DroneName != TitleLabel.value)
			{
				return true;
			}
			return false;
		}

		public void DeleteDrone(DroneData item)
		{
			_manager.DeleteDrone(item);
		}

		public void DuplicateDrone(DroneData item)
		{
			_manager.DuplicateDrone(item);
		}

		public void ShowDroneUploadPanel(DroneData item)
		{
			SaveChanges();
			_manager.ShowDroneUploadPanel(item);
		}
	}
}
