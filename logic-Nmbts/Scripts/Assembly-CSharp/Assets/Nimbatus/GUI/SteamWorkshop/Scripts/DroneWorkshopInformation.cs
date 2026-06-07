using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Workshop;
using I2.Loc;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class DroneWorkshopInformation : MonoBehaviour
	{
		public UILabel DroneTitleLabel;

		public UILabel CreatorLabel;

		public UILabel DroneDescriptionLabel;

		public UILabel DownloadsLabel;

		public UITexture DroneImage;

		public ChangeVoteControl VoteControl;

		public StarRatingControl RatingControl;

		public DeleteWorkshopItemButton DeleteButton;

		public DownloadWorkshopItem DownloadButton;

		public EditWorkshopItem EditButton;

		public UIScrollView DescriptionView;

		public GameObject LoadingScreen;

		public UILabel LoadingLabel;

		public GameObject BlockingForeground;

		private DroneBrowserManager _manager;

		private WorkshopItemResult _item;

		public void Init(DroneBrowserManager manager, WorkshopItemResult item)
		{
			if (item == null)
			{
				BlockingForeground.gameObject.SetActive(true);
				return;
			}
			_manager = manager;
			_item = item;
			BlockingForeground.gameObject.SetActive(false);
			DroneTitleLabel.text = item.Title;
			DroneDescriptionLabel.text = item.Description;
			DescriptionView.ResetPosition();
			string translation = LocalizationManager.GetTermTranslation("DroneHangar/DownloadCount");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string> { 
			{
				"Count",
				item.NumberOfDownloads.ToString()
			} });
			DownloadsLabel.text = translation;
			string friendPersonaName = SteamFriends.GetFriendPersonaName(new CSteamID(item.OwnerId));
			CreatorLabel.text = LabelHelper.White + LocalizationManager.GetTermTranslation("Tournaments/BuiltBy") + " " + LabelHelper.DarkOrange + friendPersonaName;
			DroneImage.mainTexture = item.PreviewImage;
			StartCoroutine(VoteControl.Init(item));
			RatingControl.Init(item);
			DownloadButton.Init(this, item);
			EditButton.Init(this, item);
			StopLoading();
			if (item.CanBeEdited)
			{
				DeleteButton.gameObject.SetActive(true);
				DeleteButton.Init(this, item);
				EditButton.gameObject.SetActive(true);
			}
			else
			{
				DeleteButton.gameObject.SetActive(false);
				EditButton.gameObject.SetActive(false);
			}
		}

		public void Update()
		{
			if (_item != null)
			{
				DroneImage.mainTexture = _item.PreviewImage;
			}
		}

		public IEnumerator DownloadItem(WorkshopItemResult item)
		{
			StartLoading(LocalizationManager.GetTermTranslation("DroneHangar/Downloading"));
			yield return StartCoroutine(_manager.DownloadItem(item));
			StopLoading();
		}

		public IEnumerator DeleteItem(WorkshopItemResult item)
		{
			StartLoading(LocalizationManager.GetTermTranslation("DroneHangar/Deleting"));
			yield return StartCoroutine(_manager.DeleteItem(item));
			StopLoading();
		}

		public void EditItem(WorkshopItemResult item)
		{
			_manager.ShowUploadPanel(item);
		}

		private void StartLoading(string text)
		{
			LoadingScreen.SetActive(true);
			LoadingLabel.text = text;
		}

		private void StopLoading()
		{
			LoadingScreen.SetActive(false);
			LoadingLabel.text = "";
		}

		public IEnumerator UnsubscribeItem(WorkshopItemResult item)
		{
			StartLoading(LocalizationManager.GetTermTranslation("DroneHangar/Removing"));
			yield return StartCoroutine(_manager.UnsubscribeItem(item));
			StopLoading();
		}
	}
}
