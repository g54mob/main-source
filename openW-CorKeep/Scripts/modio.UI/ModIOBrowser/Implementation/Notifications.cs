using System.Collections;
using System.Collections.Generic;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class Notifications : SelfInstancingMonoSingleton<Notifications>
	{
		public class QueuedNotice
		{
			public string title;

			public string description;

			public bool positiveAccent;
		}

		[Header("Notifications")]
		[SerializeField]
		private GameObject NotificationPanel;

		[SerializeField]
		private Image NotificationPanelImage;

		[SerializeField]
		private Image NotificationPanelIconBackgroundImage;

		[SerializeField]
		private Image NotificationPanelIconImage;

		[SerializeField]
		private TMP_Text NotificationPanelTitle;

		[SerializeField]
		private TMP_Text NotificationPanelDescription;

		[SerializeField]
		private Sprite NotificationErrorIcon;

		[SerializeField]
		private Sprite NotificationCheckmarkIcon;

		private Queue<QueuedNotice> upcomingNotices = new Queue<QueuedNotice>();

		private bool showingNotice;

		private Vector2 notificationOrigin = new Vector2(24f, 24f);

		private void OnDisable()
		{
			NotificationPanel.SetActive(value: false);
			upcomingNotices.Clear();
			showingNotice = false;
		}

		public void ProcessModManagementEventIntoNotification(ModManagementEventType type, ModId modId, Result result)
		{
			switch (type)
			{
			case ModManagementEventType.Installed:
				AddNotificationToQueue(new QueuedNotice
				{
					title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Mod installed"),
					description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{modname} has finished installing", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(modId) ?? ""),
					positiveAccent = true
				});
				break;
			case ModManagementEventType.InstallFailed:
			{
				string description = (result.IsStorageSpaceInsufficient() ? SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Not enough space") : SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{modname} failed to install", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(modId) ?? ""));
				AddNotificationToQueue(new QueuedNotice
				{
					title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Mod installation failed"),
					description = description,
					positiveAccent = false
				});
				break;
			}
			case ModManagementEventType.DownloadFailed:
			{
				string description = (result.IsStorageSpaceInsufficient() ? SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Not enough space") : SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{modname} failed to download", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(modId) ?? ""));
				AddNotificationToQueue(new QueuedNotice
				{
					title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Mod download failed"),
					description = description,
					positiveAccent = false
				});
				break;
			}
			case ModManagementEventType.UninstallFailed:
				AddNotificationToQueue(new QueuedNotice
				{
					title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Mod delete failed"),
					description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{modname} failed to delete", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(modId) ?? ""),
					positiveAccent = false
				});
				break;
			case ModManagementEventType.Updated:
				AddNotificationToQueue(new QueuedNotice
				{
					title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Mod updated"),
					description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{modname} has finished updating", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(modId) ?? ""),
					positiveAccent = true
				});
				break;
			case ModManagementEventType.UpdateFailed:
				AddNotificationToQueue(new QueuedNotice
				{
					title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Mod update failed"),
					description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{modname} failed to update", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(modId) ?? ""),
					positiveAccent = false
				});
				break;
			case ModManagementEventType.DownloadStarted:
			case ModManagementEventType.Downloaded:
			case ModManagementEventType.UninstallStarted:
			case ModManagementEventType.Uninstalled:
			case ModManagementEventType.UpdateStarted:
				break;
			}
		}

		public void AddNotificationToQueue(QueuedNotice notice)
		{
			if (upcomingNotices.Count <= 5)
			{
				upcomingNotices.Enqueue(notice);
				StartCoroutine(ShowNextNotice());
			}
		}

		private IEnumerator ShowNextNotice()
		{
			if (showingNotice || upcomingNotices.Count == 0)
			{
				yield break;
			}
			showingNotice = true;
			QueuedNotice queuedNotice = upcomingNotices.Dequeue();
			NotificationPanelTitle.text = queuedNotice.title;
			NotificationPanelDescription.text = queuedNotice.description;
			NotificationPanelIconBackgroundImage.color = (queuedNotice.positiveAccent ? MonoSingleton<Browser>.Instance.colorScheme.PositiveAccent : SharedUi.colorScheme.NegativeAccent);
			NotificationPanelIconImage.sprite = (queuedNotice.positiveAccent ? NotificationCheckmarkIcon : NotificationErrorIcon);
			List<Graphic> graphics = new List<Graphic> { NotificationPanelImage, NotificationPanelIconImage, NotificationPanelIconBackgroundImage, NotificationPanelTitle, NotificationPanelDescription };
			foreach (Graphic item in graphics)
			{
				Color color = item.color;
				color.a = 0f;
				item.color = color;
			}
			int totalIncrements = 10;
			float alphaChangePerIncrement = 1f / (float)totalIncrements;
			float timeBetweenIncrements = 0.02f;
			float num = 32f;
			float verticalMovementPerIncrement = num / (float)totalIncrements;
			Vector2 vector = notificationOrigin;
			vector.y -= num;
			NotificationPanel.transform.position = vector;
			NotificationPanel.SetActive(value: true);
			LayoutRebuilder.ForceRebuildLayoutImmediate(NotificationPanel.transform as RectTransform);
			for (int i = 0; i < totalIncrements; i++)
			{
				Vector2 vector2 = NotificationPanel.transform.position;
				vector2.y += verticalMovementPerIncrement;
				NotificationPanel.transform.position = vector2;
				foreach (Graphic item2 in graphics)
				{
					Color color2 = item2.color;
					color2.a += alphaChangePerIncrement;
					item2.color = color2;
				}
				yield return new WaitForSecondsRealtime(timeBetweenIncrements);
			}
			yield return new WaitForSecondsRealtime(3f);
			for (int i = 0; i < totalIncrements; i++)
			{
				foreach (Graphic item3 in graphics)
				{
					Color color3 = item3.color;
					color3.a -= alphaChangePerIncrement;
					item3.color = color3;
				}
				yield return new WaitForSecondsRealtime(timeBetweenIncrements);
			}
			NotificationPanel.SetActive(value: false);
			showingNotice = false;
			StartCoroutine(ShowNextNotice());
		}
	}
}
