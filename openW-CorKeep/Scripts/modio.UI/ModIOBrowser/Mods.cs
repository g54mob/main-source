using System;
using ModIO;
using ModIO.Util;
using ModIOBrowser.Implementation;

namespace ModIOBrowser
{
	public static class Mods
	{
		private static ModId lastRatedMod;

		private static ModRating lastRatingType;

		public static ProgressHandle CurrentModManagementOperationHandle;

		public static ModManagementEventDelegate OnModManagementEvent;

		internal static void SubscribeToEvent(ModProfile profile, Action callback = null)
		{
			if (!SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated)
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance?.Open();
				return;
			}
			SelfInstancingMonoSingleton<Collection>.Instance.pendingSubscriptions.Add(profile);
			ModIOUnity.SubscribeToMod(profile.id, delegate(Result result)
			{
				SelfInstancingMonoSingleton<Collection>.Instance.pendingSubscriptions.Remove(profile);
				if (result.Succeeded())
				{
					SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
					{
						title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Subscribed"),
						description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{GetModNameFromId} has been added to the download queue", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(profile.id)),
						positiveAccent = true
					});
					SelfInstancingMonoSingleton<Collection>.Instance.CacheLocalSubscribedModStatuses();
					if (Collection.IsOn())
					{
						SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
					}
				}
				else
				{
					SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
					{
						title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Failed to subscribe"),
						description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Unable to subscribe to '{GetModNameFromId}'", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(profile.id)),
						positiveAccent = false
					});
				}
				callback?.Invoke();
			});
		}

		public static void UnsubscribeFromEvent(ModProfile profile, Action callback = null)
		{
			if (!SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated)
			{
				return;
			}
			SelfInstancingMonoSingleton<Collection>.Instance.pendingSubscriptions.Remove(profile);
			if (!SelfInstancingMonoSingleton<Collection>.Instance.pendingUnsubscribes.Contains(profile.id))
			{
				SelfInstancingMonoSingleton<Collection>.Instance.pendingUnsubscribes.Add(profile.id);
			}
			ModIOUnity.UnsubscribeFromMod(profile.id, delegate(Result result)
			{
				if (SelfInstancingMonoSingleton<Collection>.Instance.pendingUnsubscribes.Contains(profile.id))
				{
					SelfInstancingMonoSingleton<Collection>.Instance.pendingUnsubscribes.Remove(profile.id);
				}
				if (result.Succeeded())
				{
					SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
					{
						title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Unsubscribed"),
						description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{GetNameFromModId} has been removed from your collection", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(profile.id)),
						positiveAccent = true
					});
					SelfInstancingMonoSingleton<Collection>.Instance.CacheLocalSubscribedModStatuses();
				}
				callback?.Invoke();
			});
		}

		public static void RateEvent(ModId modId, ModRating rating, Action callback = null)
		{
			if (!SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated)
			{
				return;
			}
			ModIOUnity.RateMod(modId, rating, delegate(Result result)
			{
				callback?.Invoke();
				if (result.Succeeded())
				{
					if ((long)lastRatedMod != (long)modId || lastRatingType != rating)
					{
						lastRatingType = rating;
						lastRatedMod = modId;
						SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
						{
							title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Rating added"),
							description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Your rating has been added for {Mod}", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(modId)),
							positiveAccent = true
						});
					}
				}
				else
				{
					SelfInstancingMonoSingleton<Details>.Instance.UpdateRatingButtons();
					SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
					{
						title = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Failed to add rating"),
						description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Failed to submit your rating for {Mod}", SelfInstancingMonoSingleton<Collection>.Instance.GetModNameFromId(modId)),
						positiveAccent = false
					});
				}
			});
		}

		public static void ModManagementEvent(ModManagementEventType type, ModId id, Result eventResult)
		{
			OnModManagementEvent?.Invoke(type, id, eventResult);
			if (eventResult.IsStorageSpaceInsufficient() && !SelfInstancingMonoSingleton<Collection>.Instance.notEnoughSpaceForTheseMods.Contains(id))
			{
				SelfInstancingMonoSingleton<Collection>.Instance.notEnoughSpaceForTheseMods.Add(id);
			}
			if (Browser.IsOpen)
			{
				SelfInstancingMonoSingleton<Notifications>.Instance.ProcessModManagementEventIntoNotification(type, id, eventResult);
				CurrentModManagementOperationHandle = ModIOUnity.GetCurrentModManagementOperation();
				if (CurrentModManagementOperationHandle.Completed)
				{
					CurrentModManagementOperationHandle = null;
				}
				SelfInstancingMonoSingleton<Collection>.Instance.CacheLocalSubscribedModStatuses();
				if (CollectionModListItem.listItems.ContainsKey(id))
				{
					CollectionModListItem.listItems[id].UpdateStatus(type);
				}
				if (HomeModListItem.listItems.ContainsKey(id))
				{
					HomeModListItem.listItems[id].UpdateStatus(type, id);
				}
				if (Details.IsOn())
				{
					SelfInstancingMonoSingleton<Details>.Instance.ModDetailsProgressTab.UpdateStatus(type, id);
				}
				Home.ModManagementEvent(type, id, eventResult);
				if (SelfInstancingMonoSingleton<DownloadQueue>.Instance.DownloadQueuePanel.activeSelf)
				{
					SelfInstancingMonoSingleton<DownloadQueue>.Instance.RefreshDownloadHistoryPanel();
				}
			}
		}

		internal static void UpdateProgressState()
		{
			UpdateProgressStateInternal(CurrentModManagementOperationHandle);
		}

		private static void UpdateProgressStateInternal(ProgressHandle handle)
		{
			if (handle == null)
			{
				CurrentModManagementOperationHandle = ModIOUnity.GetCurrentModManagementOperation();
			}
			SelfInstancingMonoSingleton<Avatar>.Instance.UpdateDownloadProgressBar(handle);
			if (Collection.IsOn())
			{
				if (handle != null && CollectionModListItem.listItems.ContainsKey(handle.modId))
				{
					CollectionModListItem.listItems[handle.modId].UpdateProgressState(handle);
				}
			}
			else if (Details.IsOn())
			{
				SelfInstancingMonoSingleton<Details>.Instance.UpdateDownloadProgress(handle);
			}
			else if (handle != null && SelfInstancingMonoSingleton<SearchResults>.Instance.SearchResultsPanel.activeSelf && SearchResultListItem.listItems.ContainsKey(handle.modId))
			{
				SearchResultListItem.listItems[handle.modId].UpdateProgressBar(handle);
			}
			Home.UpdateProgressState(handle);
			if (SelfInstancingMonoSingleton<DownloadQueue>.Instance.DownloadQueuePanel.activeSelf)
			{
				SelfInstancingMonoSingleton<DownloadQueue>.Instance.UpdateDownloadQueueCurrentDownloadDisplay(handle);
			}
		}
	}
}
