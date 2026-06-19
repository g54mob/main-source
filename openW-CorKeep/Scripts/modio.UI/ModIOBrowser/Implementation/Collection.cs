using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModIO;
using ModIO.Implementation.API.Objects;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class Collection : SelfInstancingMonoSingleton<Collection>
	{
		[Header("Collection Panel")]
		[SerializeField]
		public GameObject CollectionPanel;

		[SerializeField]
		private TMP_Text CollectionPanelTitle;

		[SerializeField]
		private TMP_InputField CollectionPanelSearchField;

		[SerializeField]
		private GameObject CollectionPanelModListItem;

		[SerializeField]
		private RectTransform CollectionPanelContentParent;

		[SerializeField]
		private Scrollbar CollectionPanelContentScrollBar;

		[SerializeField]
		private Transform CollectionPanelModListItemParent;

		[SerializeField]
		private TMP_Text CollectionPanelCheckForUpdatesText;

		[SerializeField]
		private Button CollectionPanelCheckForUpdatesButton;

		[SerializeField]
		private MultiTargetDropdown CollectionPanelFirstDropDownFilter;

		[SerializeField]
		private MultiTargetDropdown CollectionPanelSecondDropDownFilter;

		[SerializeField]
		private Image CollectionPanelHeaderBackground;

		[SerializeField]
		private Selectable defaultCollectionSelection;

		internal CollectionModListItem currentSelectedCollectionListItem;

		public SubscribedMod[] subscribedMods = Array.Empty<SubscribedMod>();

		public InstalledMod[] installedMods = Array.Empty<InstalledMod>();

		public List<ModProfile> pendingSubscriptions = new List<ModProfile>();

		public HashSet<ModId> pendingUnsubscribes = new HashSet<ModId>();

		public HashSet<ModId> notEnoughSpaceForTheseMods = new HashSet<ModId>();

		private Dictionary<ModId, string> modStatus = new Dictionary<ModId, string>();

		private bool checkingForUpdates;

		private IEnumerator collectionHeaderTransition;

		private float collectionHeaderLastAlphaTarget = -1f;

		[Header("Uninstall Confirmation")]
		[SerializeField]
		public GameObject uninstallConfirmationPanel;

		[SerializeField]
		private TMP_Text uninstallConfirmationPanelModName;

		[SerializeField]
		private TMP_Text uninstallConfirmationPanelFileSize;

		private ModProfile currentSelectedModForUninstall;

		internal Translation CollectionPanelCheckForUpdatesTextTranslation;

		internal Translation CollectionPanelTitleTranslation;

		internal Translation kbTranslation;

		internal Translation mbTranslation;

		internal Translation bytesTranslation;

		internal Dictionary<ModId, List<ModId>> modDependenciesCache = new Dictionary<ModId, List<ModId>>();

		public static bool IsOn()
		{
			if (SelfInstancingMonoSingleton<Collection>.Instance != null && SelfInstancingMonoSingleton<Collection>.Instance.CollectionPanel != null)
			{
				return SelfInstancingMonoSingleton<Collection>.Instance.CollectionPanel.activeSelf;
			}
			return false;
		}

		public void CloseUninstallConfirmation()
		{
			uninstallConfirmationPanel.SetActive(value: false);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.Collection);
		}

		public void OpenUninstallConfirmation(ModProfile profile)
		{
			uninstallConfirmationPanelModName.text = profile.name;
			long archiveFileSize = profile.archiveFileSize;
			if (archiveFileSize < 1000000)
			{
				if (archiveFileSize >= 1000)
				{
					Translation.Get(kbTranslation, "KB", delegate(string s)
					{
						uninstallConfirmationPanelFileSize.text = $"{(double)profile.archiveFileSize * 0.001} {s}";
					});
				}
				else
				{
					Translation.Get(bytesTranslation, "bytes", delegate(string s)
					{
						uninstallConfirmationPanelFileSize.text = $"{profile.archiveFileSize} {s}";
					});
				}
			}
			else
			{
				Translation.Get(mbTranslation, "MB", delegate(string s)
				{
					uninstallConfirmationPanelFileSize.text = $"{(double)profile.archiveFileSize * 1E-06} {s}";
				});
			}
			currentSelectedModForUninstall = profile;
			uninstallConfirmationPanel.SetActive(value: true);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.ConfirmUninstall);
		}

		public void ConfirmUninstall()
		{
			CloseUninstallConfirmation();
			if (SelfInstancingMonoSingleton<Collection>.Instance.IsSubscribed(currentSelectedModForUninstall.id))
			{
				Mods.UnsubscribeFromEvent(currentSelectedModForUninstall);
			}
			else
			{
				ModIOUnity.ForceUninstallMod(currentSelectedModForUninstall.id);
			}
			RefreshList();
		}

		public void Open()
		{
			Navigating.GoToPanel(CollectionPanel);
			CacheLocalSubscribedModStatuses(delegate
			{
				RefreshList();
			});
			SelfInstancingMonoSingleton<NavBar>.Instance.UpdateNavbarSelection();
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.Collection);
		}

		private void Refresh()
		{
			SelfInstancingMonoSingleton<Collection>.Instance.CacheLocalSubscribedModStatuses();
			modStatus.Clear();
			SubscribedMod[] array = subscribedMods;
			for (int i = 0; i < array.Length; i++)
			{
				SubscribedMod mod = array[i];
				modStatus.Add(mod.modProfile.id, Utility.GetModStatusAsString(mod));
			}
			InstalledMod[] array2 = installedMods;
			for (int i = 0; i < array2.Length; i++)
			{
				InstalledMod installedMod = array2[i];
				if (!modStatus.ContainsKey(installedMod.modProfile.id))
				{
					modStatus.Add(installedMod.modProfile.id, "Installed");
				}
				else
				{
					modStatus[installedMod.modProfile.id] = "Installed";
				}
			}
			foreach (ModProfile pendingSubscription in pendingSubscriptions)
			{
				if (!modStatus.ContainsKey(pendingSubscription.id))
				{
					modStatus.Add(pendingSubscription.id, "Pending...");
				}
				else
				{
					modStatus[pendingSubscription.id] = "Pending...";
				}
			}
		}

		public void RefreshList()
		{
			if (checkingForUpdates)
			{
				Translation.Get(CollectionPanelCheckForUpdatesTextTranslation, "Checking...", CollectionPanelCheckForUpdatesText);
			}
			else
			{
				Translation.Get(CollectionPanelCheckForUpdatesTextTranslation, "Check for updates", CollectionPanelCheckForUpdatesText);
			}
			Refresh();
			bool flag = true;
			bool flag2 = false;
			switch (CollectionPanelFirstDropDownFilter.value)
			{
			case 1:
				flag2 = true;
				flag = false;
				break;
			case 2:
				flag2 = true;
				break;
			}
			List<CollectionProfile> list = new List<CollectionProfile>();
			if (flag)
			{
				SubscribedMod[] array = subscribedMods;
				for (int i = 0; i < array.Length; i++)
				{
					SubscribedMod subscribedMod = array[i];
					if (!pendingUnsubscribes.Contains(subscribedMod.modProfile.id))
					{
						list.Add(new CollectionProfile(subscribedMod.modProfile, subscribed: true, subscribedMod.enabled, 1, modStatus[subscribedMod.modProfile.id]));
					}
				}
				foreach (ModProfile pendingSubscription in pendingSubscriptions)
				{
					list.Add(new CollectionProfile(pendingSubscription, subscribed: true, enabled: true, 1, modStatus[pendingSubscription.id]));
				}
			}
			if (flag2)
			{
				List<ModId> list2 = pendingSubscriptions.Select((ModProfile mod) => mod.id).ToList();
				InstalledMod[] array2 = installedMods;
				for (int i = 0; i < array2.Length; i++)
				{
					InstalledMod installedMod = array2[i];
					if (!list2.Contains(installedMod.modProfile.id) && installedMod.subscribedUsers.Count >= 1)
					{
						list.Add(new CollectionProfile(installedMod.modProfile, subscribed: false, enabled: false, installedMod.subscribedUsers.Count, modStatus[installedMod.modProfile.id]));
					}
				}
			}
			string text = ColorUtility.ToHtmlStringRGBA(SharedUi.colorScheme.GetSchemeColor(ColorSetterType.Highlight));
			if (subscribedMods == null)
			{
				Translation.Get(CollectionPanelTitleTranslation, "Collection", CollectionPanelTitle);
			}
			else
			{
				Translation.Get(CollectionPanelTitleTranslation, "Collection <size=20><color=#{accentHashColor}>({subscribedAndPending.Count})</color></size>", CollectionPanelTitle, text ?? "", $"{list.Count}");
			}
			switch (CollectionPanelSecondDropDownFilter.value)
			{
			case 0:
				list.Sort(CompareModProfilesAlphabetically);
				break;
			case 1:
				list.Sort(CompareModProfilesByFileSize);
				break;
			}
			ListItem.HideListItems<CollectionModListItem>();
			bool flag3 = false;
			string text2 = CollectionPanelSearchField.text;
			CollectionModListItem collectionModListItem = null;
			foreach (CollectionProfile item in list)
			{
				if (item.name.IndexOf(text2, StringComparison.OrdinalIgnoreCase) < 0)
				{
					continue;
				}
				ListItem listItem = ListItem.GetListItem<CollectionModListItem>(CollectionPanelModListItem, CollectionPanelModListItemParent, SharedUi.colorScheme);
				if (listItem is CollectionModListItem collectionModListItem2)
				{
					listItem.Setup(item);
					listItem.SetViewportRestraint(CollectionPanelContentParent, null);
					if (!flag3)
					{
						flag3 = true;
						SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(listItem.selectable);
						SetExplicitDownNavigationForTopRowButtons(listItem.selectable);
						collectionModListItem2.SetNavigationAbove(CollectionPanelCheckForUpdatesButton);
					}
					collectionModListItem?.ConnectNavigationToItemBelow(collectionModListItem2);
					collectionModListItem = collectionModListItem2;
				}
			}
			if (!flag3)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(defaultCollectionSelection);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(CollectionPanelModListItemParent as RectTransform);
		}

		private void SetExplicitDownNavigationForTopRowButtons(Selectable selectable)
		{
			Navigation navigation = CollectionPanelCheckForUpdatesButton.navigation;
			navigation.selectOnDown = selectable;
			CollectionPanelCheckForUpdatesButton.navigation = navigation;
			Navigation navigation2 = CollectionPanelFirstDropDownFilter.navigation;
			navigation2.selectOnDown = selectable;
			CollectionPanelFirstDropDownFilter.navigation = navigation2;
			Navigation navigation3 = CollectionPanelSecondDropDownFilter.navigation;
			navigation3.selectOnDown = selectable;
			CollectionPanelSecondDropDownFilter.navigation = navigation3;
		}

		public void OnScrollValueChange()
		{
			float num = -1f;
			num = ((!(CollectionPanelContentScrollBar.value < 1f)) ? ((CollectionPanelHeaderBackground.color.a == 0f) ? num : 0f) : ((CollectionPanelHeaderBackground.color.a == 1f) ? num : 1f));
			if (num != -1f && num != collectionHeaderLastAlphaTarget)
			{
				collectionHeaderLastAlphaTarget = num;
				if (collectionHeaderTransition != null)
				{
					StopCoroutine(collectionHeaderTransition);
				}
				collectionHeaderTransition = ImageTransitions.Alpha(CollectionPanelHeaderBackground, num);
				StartCoroutine(collectionHeaderTransition);
			}
		}

		public void CheckForUpdates()
		{
			if (!checkingForUpdates)
			{
				Translation.Get(CollectionPanelCheckForUpdatesTextTranslation, "Checking...", CollectionPanelCheckForUpdatesText);
				ModIOUnity.FetchUpdates(FinishedCheckingForUpdates);
				checkingForUpdates = true;
			}
		}

		private void FinishedCheckingForUpdates(Result result)
		{
			checkingForUpdates = false;
			if (result.Succeeded())
			{
				RefreshList();
			}
			Translation.Get(CollectionPanelCheckForUpdatesTextTranslation, "Check for updates", CollectionPanelCheckForUpdatesText);
		}

		public string GetModNameFromId(ModId id)
		{
			SubscribedMod[] array = subscribedMods;
			for (int i = 0; i < array.Length; i++)
			{
				SubscribedMod subscribedMod = array[i];
				if ((long)subscribedMod.modProfile.id == (long)id)
				{
					return subscribedMod.modProfile.name;
				}
			}
			foreach (ModProfile pendingSubscription in pendingSubscriptions)
			{
				if ((long)pendingSubscription.id == (long)id)
				{
					return pendingSubscription.name;
				}
			}
			return "A mod";
		}

		internal void CacheLocalSubscribedModStatuses(Action onComplete = null)
		{
			Result result;
			SubscribedMod[] array = ModIOUnity.GetSubscribedMods(out result);
			if (array == null)
			{
				array = new SubscribedMod[0];
			}
			subscribedMods = array;
			InstalledMod[] systemInstalledMods = ModIOUnity.GetSystemInstalledMods(out result);
			if (result.Succeeded())
			{
				installedMods = systemInstalledMods;
			}
			modDependenciesCache.Clear();
			int totalMods = subscribedMods.Length;
			int iteratedMods = 0;
			if (totalMods == 0)
			{
				onComplete?.Invoke();
				return;
			}
			SubscribedMod[] array2 = subscribedMods;
			for (int i = 0; i < array2.Length; i++)
			{
				SubscribedMod mod = array2[i];
				ModIOUnity.GetModDependencies(mod.modProfile.id, delegate(ResultAnd<ModDependencies[]> resultDependencies)
				{
					if (resultDependencies.result.Succeeded())
					{
						List<ModId> value = resultDependencies.value.Select((ModDependencies dep) => dep.modId).ToList();
						modDependenciesCache[mod.modProfile.id] = value;
					}
					else
					{
						modDependenciesCache[mod.modProfile.id] = new List<ModId>();
					}
					int num = iteratedMods;
					iteratedMods = num + 1;
					if (iteratedMods == totalMods)
					{
						onComplete?.Invoke();
					}
				});
			}
		}

		internal static bool IsDependencyForOtherMods(ModId modId)
		{
			foreach (KeyValuePair<ModId, List<ModId>> item in SelfInstancingMonoSingleton<Collection>.Instance.modDependenciesCache)
			{
				List<ModId> value = item.Value;
				if (value != null && value.Contains(modId))
				{
					return true;
				}
			}
			return false;
		}

		internal bool IsSubscribed(ModId id)
		{
			SubscribedModStatus status;
			return IsSubscribed(id, out status);
		}

		internal bool IsSubscribed(ModId id, out SubscribedModStatus status)
		{
			if (subscribedMods == null)
			{
				SelfInstancingMonoSingleton<Collection>.Instance.CacheLocalSubscribedModStatuses();
			}
			foreach (ModId pendingUnsubscribe in pendingUnsubscribes)
			{
				if ((long)pendingUnsubscribe == (long)id)
				{
					status = SubscribedModStatus.None;
					return false;
				}
			}
			SubscribedMod[] array = subscribedMods;
			for (int i = 0; i < array.Length; i++)
			{
				SubscribedMod subscribedMod = array[i];
				if ((long)subscribedMod.modProfile.id == (long)id)
				{
					status = subscribedMod.status;
					return true;
				}
			}
			foreach (ModProfile pendingSubscription in pendingSubscriptions)
			{
				if ((long)pendingSubscription.id == (long)id)
				{
					status = SubscribedModStatus.WaitingToDownload;
					return true;
				}
			}
			status = SubscribedModStatus.None;
			return false;
		}

		internal bool IsInstalled(ModId id)
		{
			if (installedMods == null)
			{
				CacheLocalSubscribedModStatuses();
			}
			InstalledMod[] array = installedMods;
			for (int i = 0; i < array.Length; i++)
			{
				if ((long)array[i].modProfile.id == (long)id)
				{
					return true;
				}
			}
			return false;
		}

		internal bool GetSubscribedProfile(ModId id, out ModProfile profile)
		{
			if (subscribedMods == null)
			{
				SelfInstancingMonoSingleton<Collection>.Instance.CacheLocalSubscribedModStatuses();
			}
			SubscribedMod[] array = subscribedMods;
			for (int i = 0; i < array.Length; i++)
			{
				SubscribedMod subscribedMod = array[i];
				if ((long)subscribedMod.modProfile.id == (long)id)
				{
					profile = subscribedMod.modProfile;
					return true;
				}
			}
			foreach (ModProfile pendingSubscription in pendingSubscriptions)
			{
				if ((long)pendingSubscription.id == (long)id)
				{
					profile = pendingSubscription;
					return true;
				}
			}
			profile = default(ModProfile);
			return false;
		}

		private static int CompareModProfilesAlphabetically(SubscribedMod A, SubscribedMod B)
		{
			return CompareModProfilesAlphabetically(A.modProfile, B.modProfile);
		}

		private static int CompareModProfilesAlphabetically(InstalledMod A, InstalledMod B)
		{
			return CompareModProfilesAlphabetically(A.modProfile, B.modProfile);
		}

		private static int CompareModProfilesAlphabetically(CollectionProfile A, CollectionProfile B)
		{
			return CompareModProfilesAlphabetically(A.modProfile, B.modProfile);
		}

		private static int CompareModProfilesAlphabetically(ModProfile A, ModProfile B)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			int num4 = 10;
			int num5 = 0;
			string text = A.name;
			foreach (char c in text)
			{
				if (num5 >= num4)
				{
					break;
				}
				num3 = ((num3 == 0f) ? 1f : (num3 + 100f));
				num += (float)(int)char.ToLower(c) / num3;
				num5++;
			}
			num3 = 0f;
			num5 = 0;
			text = B.name;
			foreach (char c2 in text)
			{
				if (num5 >= num4)
				{
					break;
				}
				num3 = ((num3 == 0f) ? 1f : (num3 + 100f));
				num2 += (float)(int)char.ToLower(c2) / num3;
				num5++;
			}
			if (num > num2)
			{
				return 1;
			}
			if (num2 > num)
			{
				return -1;
			}
			return 0;
		}

		private static int CompareModProfilesByFileSize(InstalledMod A, InstalledMod B)
		{
			return CompareModProfilesByFileSize(A.modProfile, B.modProfile);
		}

		private static int CompareModProfilesByFileSize(CollectionProfile A, CollectionProfile B)
		{
			return CompareModProfilesByFileSize(A.modProfile, B.modProfile);
		}

		private static int CompareModProfilesByFileSize(ModProfile A, ModProfile B)
		{
			if (A.archiveFileSize > B.archiveFileSize)
			{
				return -1;
			}
			if (A.archiveFileSize < B.archiveFileSize)
			{
				return 1;
			}
			return 0;
		}
	}
}
