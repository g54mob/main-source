using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Michsky.DreamOS
{
	public class MailManager : MonoBehaviour
	{
		[Serializable]
		public class MailAsset
		{
			public string itemTitle = "Mail Title";

			public MailItem mailAsset;
		}

		[SerializeField]
		private Transform mailViewer;

		[SerializeField]
		private Transform inboxParent;

		[SerializeField]
		private Transform sentParent;

		[SerializeField]
		private Transform junkParent;

		[SerializeField]
		private PopupPanelManager attachmentPanel;

		[SerializeField]
		private Transform attachmentParent;

		[SerializeField]
		private GameObject itemTemplate;

		[SerializeField]
		private GameObject mailTemplate;

		[SerializeField]
		private GameObject attachmentItem;

		[SerializeField]
		private MusicPlayerManager musicManager;

		[SerializeField]
		private NotepadManager noteManager;

		[SerializeField]
		private PhotoGalleryManager pictureManager;

		[SerializeField]
		private VideoPlayerManager videoManager;

		[SerializeField]
		private bool useLocalization = true;

		public string fromPrefix = "<";

		public string fromSuffix = ">";

		public List<MailAsset> mailList = new List<MailAsset>();

		private float cachedTemplateLength = 0.5f;

		private MailPreset currentMailPreset;

		private MailItemPreset currentItemPreset;

		[Inject]
		private DiContainer _diContainer;

		private void Awake()
		{
			InitializeMails();
			if (mailTemplate != null)
			{
				cachedTemplateLength = DreamOSInternalTools.GetAnimatorClipLength(mailTemplate.GetComponent<Animator>(), "MailTemplate_In") + 0.1f;
			}
			if (musicManager == null && UnityEngine.Object.FindObjectsByType<MusicPlayerManager>(FindObjectsSortMode.None).Length != 0)
			{
				musicManager = UnityEngine.Object.FindObjectsByType<MusicPlayerManager>(FindObjectsSortMode.None)[0];
			}
			if (noteManager == null && UnityEngine.Object.FindObjectsByType<NotepadManager>(FindObjectsSortMode.None).Length != 0)
			{
				noteManager = UnityEngine.Object.FindObjectsByType<NotepadManager>(FindObjectsSortMode.None)[0];
			}
			if (pictureManager == null && UnityEngine.Object.FindObjectsByType<PhotoGalleryManager>(FindObjectsSortMode.None).Length != 0)
			{
				pictureManager = UnityEngine.Object.FindObjectsByType<PhotoGalleryManager>(FindObjectsSortMode.None)[0];
			}
			if (videoManager == null && UnityEngine.Object.FindObjectsByType<VideoPlayerManager>(FindObjectsSortMode.None).Length != 0)
			{
				videoManager = UnityEngine.Object.FindObjectsByType<VideoPlayerManager>(FindObjectsSortMode.None)[0];
			}
		}

		public void InitializeMails()
		{
			if (mailViewer == null || inboxParent == null || sentParent == null || junkParent == null || attachmentParent == null)
			{
				Debug.LogError("[MailManager] One or more required Transform references are null. Check Inspector assignments on MailManager.", this);
				return;
			}
			foreach (Transform item in mailViewer)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			foreach (Transform item2 in inboxParent)
			{
				UnityEngine.Object.Destroy(item2.gameObject);
			}
			foreach (Transform item3 in sentParent)
			{
				UnityEngine.Object.Destroy(item3.gameObject);
			}
			foreach (Transform item4 in junkParent)
			{
				UnityEngine.Object.Destroy(item4.gameObject);
			}
			foreach (Transform item5 in attachmentParent)
			{
				UnityEngine.Object.Destroy(item5.gameObject);
			}
			for (int i = 0; i < mailList.Count; i++)
			{
				CreateMailItem(mailList[i]);
			}
			if (attachmentPanel != null)
			{
				attachmentPanel.gameObject.SetActive(value: false);
				attachmentPanel.InstantMinimized();
			}
		}

		public void AddMailItem(MailAsset mailAsset)
		{
			if (inboxParent == null || sentParent == null || junkParent == null)
			{
				Debug.LogError("[MailManager] Transform references are null. Cannot add mail item.", this);
				return;
			}
			mailList.Add(mailAsset);
			CreateMailItem(mailAsset);
		}

		private void CreateMailItem(MailAsset mailAssetEntry)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(itemTemplate, Vector3.zero, Quaternion.identity);
			gameObject.name = mailAssetEntry.itemTitle;
			if (mailAssetEntry.mailAsset.mailFolder == MailItem.MailFolder.Inbox)
			{
				gameObject.transform.SetParent(inboxParent, worldPositionStays: false);
			}
			else if (mailAssetEntry.mailAsset.mailFolder == MailItem.MailFolder.Sent)
			{
				gameObject.transform.SetParent(sentParent, worldPositionStays: false);
			}
			else if (mailAssetEntry.mailAsset.mailFolder == MailItem.MailFolder.Junk)
			{
				gameObject.transform.SetParent(junkParent, worldPositionStays: false);
			}
			MailItemPreset mip = gameObject.GetComponent<MailItemPreset>();
			if (mailAssetEntry.mailAsset.contactImage == null)
			{
				mip.letterText.text = mailAssetEntry.mailAsset.fromName.Substring(0, 1);
			}
			else
			{
				mip.coverImage.sprite = mailAssetEntry.mailAsset.contactImage;
				mip.coverImage.gameObject.SetActive(value: true);
			}
			mip.mailItem = mailAssetEntry.mailAsset;
			LocalizedObject tempLoc = mip.subjectText.gameObject.GetComponent<LocalizedObject>();
			if (!useLocalization || string.IsNullOrEmpty(mip.mailItem.subjectKey) || tempLoc == null || !tempLoc.CheckLocalizationStatus())
			{
				mip.subjectText.text = mailAssetEntry.mailAsset.subject;
			}
			else
			{
				tempLoc.localizationKey = mip.mailItem.subjectKey;
				tempLoc.onLanguageChanged.AddListener(delegate
				{
					mip.subjectText.text = tempLoc.GetKeyOutput(tempLoc.localizationKey);
				});
				tempLoc.InitializeItem();
				tempLoc.UpdateItem();
			}
			mip.nameText.text = mailAssetEntry.mailAsset.fromName;
			mip.timeText.text = mailAssetEntry.mailAsset.time;
			mip.dateText.text = mailAssetEntry.mailAsset.date;
			gameObject.GetComponent<ButtonManager>().onClick.AddListener(delegate
			{
				ApplyToTemplate(mip);
			});
		}

		private void ApplyToTemplate(MailItemPreset mip)
		{
			if (currentItemPreset == mip)
			{
				return;
			}
			if (currentMailPreset != null)
			{
				UnityEngine.Object.Destroy(currentMailPreset.gameObject);
			}
			foreach (Transform item in attachmentParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(mailTemplate, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.gameObject.name = mip.mailItem.name;
			gameObject.transform.SetParent(mailViewer, worldPositionStays: false);
			currentMailPreset = gameObject.GetComponent<MailPreset>();
			currentItemPreset = mip;
			if (mip.mailItem.contactImage == null)
			{
				currentMailPreset.letterText.text = mip.mailItem.fromName.Substring(0, 1);
			}
			else
			{
				currentMailPreset.coverImage.sprite = mip.mailItem.contactImage;
				currentMailPreset.coverImage.gameObject.SetActive(value: true);
			}
			LocalizedObject tempLoc = currentMailPreset.subjectText.gameObject.GetComponent<LocalizedObject>();
			if (!useLocalization || string.IsNullOrEmpty(mip.mailItem.subjectKey) || tempLoc == null || !tempLoc.CheckLocalizationStatus())
			{
				currentMailPreset.subjectText.text = mip.mailItem.subject;
			}
			else if (tempLoc != null)
			{
				tempLoc.localizationKey = mip.mailItem.subjectKey;
				tempLoc.onLanguageChanged.AddListener(delegate
				{
					mip.subjectText.text = tempLoc.GetKeyOutput(tempLoc.localizationKey);
				});
				tempLoc.InitializeItem();
				tempLoc.UpdateItem();
			}
			currentMailPreset.nameText.text = mip.mailItem.fromName;
			currentMailPreset.fromText.text = fromPrefix + mip.mailItem.from + fromSuffix;
			currentMailPreset.timeText.text = mip.mailItem.time;
			currentMailPreset.dateText.text = mip.mailItem.date;
			LayoutRebuilder.ForceRebuildLayoutImmediate(currentMailPreset.fromText.transform.parent.GetComponent<RectTransform>());
			LayoutRebuilder.ForceRebuildLayoutImmediate(currentMailPreset.dateText.transform.parent.GetComponent<RectTransform>());
			if (!mip.mailItem.useCustomContent)
			{
				currentMailPreset.contentList.SetActive(value: true);
				LocalizedObject tempConLoc = currentMailPreset.contentText.gameObject.GetComponent<LocalizedObject>();
				if (!useLocalization || string.IsNullOrEmpty(mip.mailItem.contentKey) || tempConLoc == null || !tempLoc.CheckLocalizationStatus())
				{
					currentMailPreset.contentText.text = mip.mailItem.mailContent;
				}
				else if (tempConLoc != null)
				{
					tempConLoc.localizationKey = mip.mailItem.contentKey;
					tempConLoc.onLanguageChanged.AddListener(delegate
					{
						currentMailPreset.contentText.text = tempConLoc.GetKeyOutput(mip.mailItem.contentKey);
					});
					tempConLoc.InitializeItem();
					tempConLoc.UpdateItem();
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(currentMailPreset.contentList.GetComponent<RectTransform>());
			}
			else
			{
				currentMailPreset.contentList.SetActive(value: false);
				GameObject obj = _diContainer.InstantiatePrefab(mip.mailItem.customContentPrefab);
				obj.transform.SetParent(currentMailPreset.customParent, worldPositionStays: false);
				obj.transform.localPosition = new Vector3(0f, 0f, 0f);
				obj.transform.rotation = Quaternion.identity;
				obj.transform.localScale = Vector3.one;
				RectTransform component = obj.GetComponent<RectTransform>();
				component.anchorMin = Vector2.zero;
				component.anchorMax = Vector2.one;
				component.offsetMin = Vector2.zero;
				component.offsetMax = Vector2.zero;
				component.pivot = new Vector2(0.5f, 0.5f);
				obj.gameObject.name = mip.mailItem.name;
			}
			for (int num = 0; num < mip.mailItem.attachments.Count; num++)
			{
				int index = num;
				GameObject obj2 = UnityEngine.Object.Instantiate(attachmentItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
				obj2.gameObject.name = mip.mailItem.attachments[num].attachmentTitle;
				obj2.transform.SetParent(attachmentParent, worldPositionStays: false);
				ButtonManager component2 = obj2.GetComponent<ButtonManager>();
				component2.buttonText = mip.mailItem.attachments[num].attachmentTitle;
				component2.UpdateUI();
				MailAttachmentPreset component3 = component2.gameObject.GetComponent<MailAttachmentPreset>();
				if (mip.mailItem.attachments[index].attachmentType == MailItem.Attachment.Music)
				{
					component3.musicIcon.SetActive(value: true);
					component2.onClick.AddListener(delegate
					{
						musicManager.gameObject.GetComponent<WindowManager>().OpenWindow();
						musicManager.PlayCustomClip(mip.mailItem.attachments[index].musicAttachment, musicManager.libraryPlaylist.coverImage, mip.mailItem.attachments[index].attachmentTitle, mip.mailItem.fromName);
					});
				}
				else if (mip.mailItem.attachments[index].attachmentType == MailItem.Attachment.Note)
				{
					component3.noteIcon.SetActive(value: true);
					component2.onClick.AddListener(delegate
					{
						noteManager.gameObject.GetComponent<WindowManager>().OpenWindow();
						noteManager.OpenCustomNote(mip.mailItem.attachments[index].attachmentTitle, mip.mailItem.attachments[index].noteAttachment);
					});
				}
				else if (mip.mailItem.attachments[index].attachmentType == MailItem.Attachment.Picture)
				{
					component3.pictureIcon.SetActive(value: true);
					component2.onClick.AddListener(delegate
					{
						pictureManager.gameObject.GetComponent<WindowManager>().OpenWindow();
						pictureManager.OpenPhoto(mip.mailItem.attachments[index].pictureAttachment, mip.mailItem.attachments[index].attachmentTitle, mip.mailItem.fromName);
					});
				}
				else if (mip.mailItem.attachments[index].attachmentType == MailItem.Attachment.Video)
				{
					component3.videoIcon.SetActive(value: true);
					component2.onClick.AddListener(delegate
					{
						videoManager.gameObject.GetComponent<WindowManager>().OpenWindow();
						videoManager.OpenVideo(mip.mailItem.attachments[index].videoAttachment, mip.mailItem.attachments[index].attachmentTitle);
					});
				}
			}
			if (attachmentPanel != null && mip.mailItem.attachments.Count == 0)
			{
				attachmentPanel.gameObject.SetActive(value: false);
				attachmentPanel.InstantMinimized();
			}
			else if (attachmentPanel != null)
			{
				attachmentPanel.OpenPanel();
			}
			StopCoroutine("DestroyViewerAnimator");
			StartCoroutine("DestroyViewerAnimator");
		}

		private IEnumerator DestroyViewerAnimator()
		{
			yield return new WaitForSeconds(cachedTemplateLength);
			currentMailPreset.animator.enabled = false;
		}
	}
}
