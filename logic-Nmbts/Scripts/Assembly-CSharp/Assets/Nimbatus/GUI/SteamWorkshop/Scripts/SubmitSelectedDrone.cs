using System.Collections;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Workshop;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class SubmitSelectedDrone : MonoBehaviour
	{
		public UIInput Title;

		public UIInput Description;

		public UITexture DroneImage;

		public TweenPosition StatusTween;

		public UILabel StatusLabel;

		public EnumChooser DroneTypeChooser;

		public FillUploadedDrones DroneList;

		public ReplaceDroneToggle Toggle;

		private bool _replaceDrone;

		public void Start()
		{
			if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone != null)
			{
				Toggle.Init(this, false);
				ToggleReplaceDrones(false);
				DroneTypeChooser.Init<EWorkshopTag>(EWorkshopTag.Battle);
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.Image.wrapMode = TextureWrapMode.Clamp;
				DroneImage.mainTexture = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.Image;
				Title.value = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.DroneName;
				Description.value = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.Description;
			}
		}

		public void OnClick()
		{
			if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone != null)
			{
				CreateWorkshopItemInformation createWorkshopItemInformation = new CreateWorkshopItemInformation
				{
					Id = PublishedFileId_t.Invalid,
					ChangeNote = "",
					Description = Description.value,
					Title = Title.value,
					Language = "en",
					Tag = (EWorkshopTag)(object)DroneTypeChooser.SelectedOption
				};
				if (_replaceDrone && DroneList.SelectedItem != null)
				{
					createWorkshopItemInformation.Id = DroneList.SelectedItem.FileId;
				}
				StartCoroutine(Upload(createWorkshopItemInformation));
			}
		}

		public IEnumerator Upload(CreateWorkshopItemInformation droneInfo)
		{
			StatusTween.Play(true);
			StatusLabel.text = "Uploading...";
			yield return StartCoroutine(SerializableMonobehaviour<SteamWorkshopManager, SteamWorkshopSaveData>.Instance.UploadDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone, droneInfo));
			if (SerializableMonobehaviour<SteamWorkshopManager, SteamWorkshopSaveData>.Instance.LastUploadStatus)
			{
				StatusLabel.text = "Upload complete";
				yield return new WaitForSeconds(0.5f);
				NimbatusSceneManager.LoadScene("DroneHangarScene");
			}
			else
			{
				StatusLabel.text = "Upload failed";
				yield return new WaitForSeconds(0.5f);
				StatusTween.Play(false);
			}
		}

		public void ToggleReplaceDrones(bool currentValue)
		{
			DroneList.gameObject.SetActive(currentValue);
			if (currentValue)
			{
				DroneList.Init();
			}
			_replaceDrone = currentValue;
		}
	}
}
