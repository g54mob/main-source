using System.Collections;
using Assets.Behaviour.Frame.Parts;
using Assets.Behaviour.Util;
using Assets.Source.Player;
using Assets.Source.Util;
using Assets.Source.World.Frames;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Behaviour.UI
{
	public class RocketLaunchUI : FullScreenUI
	{
		public static RocketLaunchUI Instance;

		[SerializeField]
		private AudioSource _rocketAudio;

		[SerializeField]
		private Transform _buttons;

		[SerializeField]
		private TMP_Text _ascendText;

		private void Awake()
		{
			Instance = this;
		}

		public override void OnFullScreenActivate()
		{
			StartCoroutine(_rocketLaunch());
			GameUI.Instance.HideBottomBar();
			GameUI.Instance.HideTopBar();
		}

		public override void OnFullScreenDeactivate()
		{
			GameUI.Instance.ShowBottomBar();
			GameUI.Instance.ShowTopBar();
			_buttons.gameObject.SetActive(value: false);
		}

		private IEnumerator _rocketLaunch()
		{
			_rocketAudio.volume = UISounds.Volume;
			if (GamePlayer.Current.Prestige == 0 && GamePlayer.Current.SessionStats.PlayTime < 57600)
			{
				SteamAchievement.Trigger("Speedrun1");
			}
			if (GamePlayer.Current.Prestige == 0 && GamePlayer.Current.SessionStats.PlayTime < 43200)
			{
				SteamAchievement.Trigger("Speedrun2");
			}
			yield return new WaitForSeconds(5f);
			SaveGame.StoreAutosaveState("autosave-rocketlaunch");
			while (GamePlayer.Current.RocketParts >= T12LaunchFacility.PartsPerRocket)
			{
				GamePlayer.Current.ConsumeInventoryItem(GamePlayer.RocketPartItem, T12LaunchFacility.PartsPerRocket);
				GamePlayer.Current.AddRocketLaunchedBenchmark();
				GamePlayer.Current.RocketsLaunched++;
			}
			SteamStatsManager.Set(SteamStatType.RocketsLaunched, GamePlayer.Current.RocketsLaunched);
			if (!GamePlayer.Current.HasTech(TechNode.IndenturedServitude))
			{
				SteamAchievement.Trigger("NoIndenturedServitude");
			}
			if (!GamePlayer.Current.HasTech("t6f_incinerator_flag"))
			{
				SteamAchievement.Trigger("NoIncinerators");
			}
			float num = GamePlayer.GetPrestigeMultiplier(GamePlayer.Current.Prestige + GamePlayer.Current.RocketsLaunched) - GamePlayer.Current.PrestigeMultiplier;
			_ascendText.TL("@T12LaunchFacilityAscension", GamePlayer.Current.RocketsLaunched, GameMath.FormatPercentage(num));
			_buttons.gameObject.SetActive(value: true);
			UISounds.TurnPage();
		}

		public void ButtonAscend()
		{
			GamePlayer current = GamePlayer.Current;
			GamePlayer.StartNewGame();
			GamePlayer.Current.Prestige = current.Prestige + current.RocketsLaunched;
			GamePlayer.Current.TotalStats = current.TotalStats;
			GamePlayer.Current.AddInventoryItem(GamePlayer.RocketPartItem, current.RocketParts, addToStats: false);
			GamePlayer.Current.AscensionCount = current.AscensionCount + 1;
			SteamStatsManager.Set(SteamStatType.Ascensions, GamePlayer.Current.AscensionCount);
			SteamStatsManager.Set(SteamStatType.MaxPrestige, GamePlayer.Current.Prestige);
			_preserveTech(current, "t1_deconstruct");
			_preserveTech(current, "t3_move_frame");
			_preserveTech(current, "t3u_construction_progress");
			_preserveTech(current, "t3u_construction_pause");
			_preserveTech(current, "t3u_construction_cancelall");
			_preserveTech(current, "t4u_eagle_eye");
			_preserveTech(current, "t4u_highlight_frames");
			_preserveTech(current, "t4_overview_upgrade");
			_preserveTech(current, "t4_overview_upgrade_status");
			_preserveTech(current, "t5_copy_paste");
			_preserveTech(current, "t5_area_move");
			_preserveTech(current, "t8_auto_upgrade");
			_preserveTech(current, "t8_auto_upgrade_2");
			_preserveTech(current, "t8_auto_upgrade_3");
			T1BasicWidgetIntro.NewGameStarted = true;
			SceneManager.LoadScene("Game");
		}

		private void _preserveTech(GamePlayer old, TechNode tech)
		{
			if (old.HasTech(tech))
			{
				GamePlayer.Current.AddTech(tech);
			}
		}

		public void ButtonStayHere()
		{
			GameUI.Instance.ShowFrameUI();
		}
	}
}
