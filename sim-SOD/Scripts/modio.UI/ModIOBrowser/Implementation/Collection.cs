using System.Collections;
using System.Collections.Generic;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class Collection : SelfInstancingMonoSingleton<Collection>
	{
		[SerializeField]
		[Header("Collection Panel")]
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

		public SubscribedMod[] subscribedMods;

		public InstalledMod[] installedMods;

		public List<ModProfile> pendingSubscriptions;

		public HashSet<ModId> pendingUnsubscribes;

		public HashSet<ModId> notEnoughSpaceForTheseMods;

		private Dictionary<ModId, string> modStatus;

		private bool checkingForUpdates;

		private IEnumerator collectionHeaderTransition;

		private float collectionHeaderLastAlphaTarget;

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

		public static bool IsOn()
		{
			return false;
		}

		public void CloseUninstallConfirmation()
		{
		}

		public void OpenUninstallConfirmation(ModProfile profile)
		{
		}

		public void ConfirmUninstall()
		{
		}

		public void Open()
		{
		}

		private void Refresh()
		{
		}

		public void RefreshList()
		{
		}

		private void SetExplicitDownNavigationForTopRowButtons(Selectable selectable)
		{
		}

		public void OnScrollValueChange()
		{
		}

		public void CheckForUpdates()
		{
		}

		private void FinishedCheckingForUpdates(Result result)
		{
		}

		public string GetModNameFromId(ModId id)
		{
			return null;
		}

		internal void CacheLocalSubscribedModStatuses()
		{
		}

		internal bool IsSubscribed(ModId id)
		{
			return false;
		}

		internal bool IsSubscribed(ModId id, out SubscribedModStatus status)
		{
			status = default(SubscribedModStatus);
			return false;
		}

		internal bool IsInstalled(ModId id)
		{
			return false;
		}

		internal bool GetSubscribedProfile(ModId id, out ModProfile profile)
		{
			profile = default(ModProfile);
			return false;
		}

		private static int CompareModProfilesAlphabetically(SubscribedMod A, SubscribedMod B)
		{
			return 0;
		}

		private static int CompareModProfilesAlphabetically(InstalledMod A, InstalledMod B)
		{
			return 0;
		}

		private static int CompareModProfilesAlphabetically(CollectionProfile A, CollectionProfile B)
		{
			return 0;
		}

		private static int CompareModProfilesAlphabetically(ModProfile A, ModProfile B)
		{
			return 0;
		}

		private static int CompareModProfilesByFileSize(InstalledMod A, InstalledMod B)
		{
			return 0;
		}

		private static int CompareModProfilesByFileSize(CollectionProfile A, CollectionProfile B)
		{
			return 0;
		}

		private static int CompareModProfilesByFileSize(ModProfile A, ModProfile B)
		{
			return 0;
		}
	}
}
