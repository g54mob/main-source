using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class DownloadQueueListItem : ListItem, IDeselectHandler, IEventSystemHandler, ISelectHandler
	{
		[SerializeField]
		private TMP_Text modName;

		[SerializeField]
		private TMP_Text fileSize;

		[SerializeField]
		private Image modLogo;

		[SerializeField]
		private GameObject loadingIcon;

		[SerializeField]
		private GameObject failedToLoadIcon;

		[SerializeField]
		private GameObject failedToLoadMod;

		public ModProfile profile;

		public static DownloadQueueListItem currentDownloadQueueListItem;

		public void OpenModDetailsForThisProfile()
		{
			SelfInstancingMonoSingleton<Details>.Instance.Open(profile, delegate
			{
				SelfInstancingMonoSingleton<DownloadQueue>.Instance.OpenDownloadQueuePanel();
			});
		}

		public override void SetViewportRestraint(RectTransform content, RectTransform viewport)
		{
			base.SetViewportRestraint(content, viewport);
		}

		public override void Setup(SubscribedMod mod)
		{
			base.Setup();
			profile = mod.modProfile;
			modName.text = mod.modProfile.name;
			fileSize.text = Utility.GenerateHumanReadableStringForBytes(mod.modProfile.archiveFileSize);
			failedToLoadMod.SetActive(mod.status == SubscribedModStatus.ProblemOccurred);
			modLogo.color = Color.clear;
			base.gameObject.SetActive(value: true);
			failedToLoadIcon.SetActive(value: false);
			loadingIcon.SetActive(value: true);
			ModIOUnity.DownloadTexture(mod.modProfile.logoImage_320x180, SetIcon);
			LayoutRebuilder.ForceRebuildLayoutImmediate(modName.transform.parent as RectTransform);
		}

		private void SetIcon(ResultAnd<Texture2D> textureAnd)
		{
			if (textureAnd.result.Succeeded() && textureAnd.value != null)
			{
				SelfInstancingMonoSingleton<QueueRunner>.Instance.AddSpriteCreation(textureAnd.value, delegate(Sprite sprite)
				{
					modLogo.color = Color.white;
					modLogo.sprite = sprite;
				});
			}
			else
			{
				failedToLoadIcon.SetActive(value: true);
			}
			loadingIcon.SetActive(value: false);
		}

		public void Unsubscribe()
		{
			Mods.UnsubscribeFromEvent(profile);
			SelfInstancingMonoSingleton<DownloadQueue>.Instance.RefreshDownloadHistoryPanel();
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (currentDownloadQueueListItem == this)
			{
				currentDownloadQueueListItem = null;
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			currentDownloadQueueListItem = this;
		}
	}
}
