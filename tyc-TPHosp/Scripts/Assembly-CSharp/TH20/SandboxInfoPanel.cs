using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TH20.ExtContent;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SandboxInfoPanel : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _hospitalNameText;

		[SerializeField]
		private HospitalSaveInfoPanel _saveInfoPanel;

		[SerializeField]
		private GameObject _dlcRequiredObject;

		[SerializeField]
		private GameObject _requiresDLCHeaderPrefab;

		[SerializeField]
		private GameObject _requiresUGCHeaderPrefab;

		[SerializeField]
		private GameObject _requiresLocalUGCHeaderPrefab;

		[SerializeField]
		private GameObject _requiresDLCItemPrefab;

		[SerializeField]
		private GameObject _requiresUGCItemPrefab;

		[SerializeField]
		private GameObject _requiresLocalUGCItemPrefab;

		[SerializeField]
		private Transform _contentRequiredContainer;

		private Metagame _metagame;

		private DLCManager _dlcManager;

		public void Setup(SandboxSettings settings, SaveFileHeader saveHeader, MetagameMap metagameMap, SandboxSaveManager saveManager, DLCManager dlcManager, SandboxMenu.DLCAndUGCPresence dlcAndUGCPresence)
		{
			_metagame = metagameMap.Metagame;
			_dlcManager = dlcManager;
			_saveInfoPanel.Initialize();
			Refresh(saveHeader, settings, dlcAndUGCPresence);
		}

		public void Refresh(SaveFileHeader saveHeader, SandboxSettings settings, SandboxMenu.DLCAndUGCPresence dlcAndUGCPresence)
		{
			bool flag = saveHeader != null;
			bool num = SandboxSaveManager.CurrentSettings == settings && _metagame.CurrentLevel != null;
			_hospitalNameText.text = settings.DisplayName;
			if (num)
			{
				_saveInfoPanel.SetActive(active: true);
				_saveInfoPanel.UpdateFromLevel(_metagame.CurrentLevel);
			}
			else if (flag)
			{
				_saveInfoPanel.SetActive(active: true);
				_saveInfoPanel.UpdateFromSave(saveHeader);
			}
			else
			{
				_saveInfoPanel.SetActive(active: false);
			}
			RefreshContentRequiredInfo(dlcAndUGCPresence);
		}

		public void RefreshContentRequiredInfo(SandboxMenu.DLCAndUGCPresence dlcAndUGCPresence)
		{
			List<uint> presentDLC = dlcAndUGCPresence.presentDLC;
			List<uint> missingDLC = dlcAndUGCPresence.missingDLC;
			List<SandboxMenu.IDAndName> presentWorkshopItems = dlcAndUGCPresence.presentWorkshopItems;
			List<SandboxMenu.IDAndName> missingWorkshopItems = dlcAndUGCPresence.missingWorkshopItems;
			List<SandboxMenu.IDAndName> presentLocalUGCItems = dlcAndUGCPresence.presentLocalUGCItems;
			List<SandboxMenu.IDAndName> missingLocalUGCItems = dlcAndUGCPresence.missingLocalUGCItems;
			if (presentDLC.Count > 0 || missingDLC.Count > 0 || presentWorkshopItems.Count > 0 || missingWorkshopItems.Count > 0 || presentLocalUGCItems.Count > 0 || missingLocalUGCItems.Count > 0)
			{
				GameObjectUtils.DestroyChildren(_contentRequiredContainer.gameObject);
				if (presentDLC.Count > 0 || missingDLC.Count > 0)
				{
					UnityEngine.Object.Instantiate(_requiresDLCHeaderPrefab, _contentRequiredContainer.transform, worldPositionStays: false);
					foreach (uint item in missingDLC)
					{
						SandboxDependencyEntry component = UnityEngine.Object.Instantiate(_requiresDLCItemPrefab, _contentRequiredContainer.transform, worldPositionStays: false).GetComponent<SandboxDependencyEntry>();
						DLCItemDefinition dlc = _dlcManager.GetDLCByAppID(item);
						if (dlc == null)
						{
							continue;
						}
						Action buttonAction = null;
						if (dlc.IsPurchasable)
						{
							buttonAction = delegate
							{
								HandleDLCButton(dlc);
							};
						}
						component.Setup(dlc.Name.Translation, null, Color.red, buttonAction, dlc.OverrideButtonText.Term);
					}
					foreach (uint item2 in presentDLC)
					{
						SandboxDependencyEntry component2 = UnityEngine.Object.Instantiate(_requiresDLCItemPrefab, _contentRequiredContainer.transform, worldPositionStays: false).GetComponent<SandboxDependencyEntry>();
						DLCItemDefinition dLCByAppID = _dlcManager.GetDLCByAppID(item2);
						if (dLCByAppID != null)
						{
							component2.Setup(dLCByAppID.Name.Translation);
						}
					}
				}
				if (presentWorkshopItems.Count > 0 || missingWorkshopItems.Count > 0)
				{
					UnityEngine.Object.Instantiate(_requiresUGCHeaderPrefab, _contentRequiredContainer.transform, worldPositionStays: false);
					foreach (SandboxMenu.IDAndName workshopItem in missingWorkshopItems)
					{
						UnityEngine.Object.Instantiate(_requiresUGCItemPrefab, _contentRequiredContainer.transform, worldPositionStays: false).GetComponent<SandboxDependencyEntry>().Setup(workshopItem.Name, null, Color.red, delegate
						{
							TrySubscribeToWorkshopItem(workshopItem.ID);
						});
					}
					foreach (SandboxMenu.IDAndName item3 in presentWorkshopItems)
					{
						UnityEngine.Object.Instantiate(_requiresUGCItemPrefab, _contentRequiredContainer.transform, worldPositionStays: false).GetComponent<SandboxDependencyEntry>().Setup(item3.Name);
					}
				}
				if (presentLocalUGCItems.Count > 0 || missingLocalUGCItems.Count > 0)
				{
					UnityEngine.Object.Instantiate(_requiresLocalUGCHeaderPrefab, _contentRequiredContainer.transform, worldPositionStays: false);
					foreach (SandboxMenu.IDAndName item4 in missingLocalUGCItems)
					{
						UnityEngine.Object.Instantiate(_requiresLocalUGCItemPrefab, _contentRequiredContainer.transform, worldPositionStays: false).GetComponent<SandboxDependencyEntry>().Setup(item4.Name, "Menu/Sandbox/UsesUnpublishedUGC_Tooltip", Color.red);
					}
					foreach (SandboxMenu.IDAndName item5 in presentLocalUGCItems)
					{
						UnityEngine.Object.Instantiate(_requiresLocalUGCItemPrefab, _contentRequiredContainer.transform, worldPositionStays: false).GetComponent<SandboxDependencyEntry>().Setup(item5.Name, "Menu/Sandbox/UsesUnpublishedLocalUGC_Tooltip", new Color(1f, 0.55f, 0f));
					}
				}
				GameObjectUtils.SetActive(_dlcRequiredObject, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(_dlcRequiredObject, isActive: false);
			}
		}

		private void HandleDLCButton(DLCItemDefinition dlc)
		{
			ExtraContentMenu.ShowBrowser(dlc, _metagame.App.AnalyticsManager, _metagame.App.MessageBox);
		}

		private void TrySubscribeToWorkshopItem(string publishID)
		{
			string steamURL = string.Empty;
			string browserURL = string.Empty;
			ExtContentSourceWorkshop.GetSteamOverlayWorkshopItemURLsForPublishedFileId(publishID, ref steamURL, ref browserURL);
			WorkshopUtils.OpenSteamOverlay(steamURL, browserURL);
		}
	}
}
