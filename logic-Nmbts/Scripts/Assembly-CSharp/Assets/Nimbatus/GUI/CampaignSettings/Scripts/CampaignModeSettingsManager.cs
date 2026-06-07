using System.Collections;
using System.Linq;
using Assets.Nimbatus.GUI.Story;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.CampaignSettings.Scripts
{
	public class CampaignModeSettingsManager : MonoBehaviour
	{
		public DronePerkItem ItemPrefab;

		public DisplayDronePerkDetails PerkDetails;

		public GameObject LoadingPanel;

		public UIGrid ContainerGrid;

		public IntroUiManager IntroManager;

		public DronePerk SelectedPerk { get; private set; }

		public void Awake()
		{
			if (SaveManager.LoadedSave != null && SaveManager.LoadedSave.Mode == EGameMode.Campaign && RuntimeGlobals.GameModeSettings.ViewCampaignTutorial)
			{
				NimbatusSceneManager.LoadScene("MissionControlScene");
			}
			else
			{
				IntroManager.Init(this);
			}
		}

		public void Start()
		{
			ContainerGrid.transform.DestroyAllChildren();
			if (SaveManager.SelectedSave != null && SaveManager.SelectedSave.Settings.ViewCampaignTutorial)
			{
				SelectedPerk = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.GetHiddenPerks().FirstOrDefault();
				return;
			}
			bool flag = true;
			foreach (DronePerk allPerk in SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.GetAllPerks())
			{
				if (flag)
				{
					SelectPerk(allPerk);
					flag = false;
				}
				DronePerkItem dronePerkItem = Object.Instantiate(ItemPrefab, ContainerGrid.transform);
				dronePerkItem.Init(this, allPerk);
				dronePerkItem.transform.position = ContainerGrid.transform.position;
				dronePerkItem.transform.parent = ContainerGrid.transform;
				dronePerkItem.transform.localScale = Vector3.one;
			}
			ContainerGrid.Reposition();
		}

		public void SelectPerk(DronePerk perk)
		{
			SelectedPerk = perk;
			PerkDetails.Init(perk, this);
		}

		public IEnumerator LoadGame()
		{
			LoadingPanel.SetActive(true);
			yield return true;
			SaveManager.SelectedSave.Settings.DronePerkId = SelectedPerk.UniqueId;
			if (SelectedPerk.StarterSet.AllPartsUnlocked)
			{
				SaveManager.SelectedSave.Settings.ShowAllDroneParts = true;
				SaveManager.SelectedSave.Settings.HasPartUnlocking = false;
				SaveManager.SelectedSave.Settings.DeployCost = false;
			}
			SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.PreparePerk(SelectedPerk.UniqueId);
			SaveManager.LoadSaveGame(SaveManager.SelectedSave);
			NimbatusSceneManager.LoadScene("MissionControlScene");
		}
	}
}
