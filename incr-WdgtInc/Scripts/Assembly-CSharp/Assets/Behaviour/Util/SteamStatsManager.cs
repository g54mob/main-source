using System.Collections.Generic;
using System.Numerics;
using Assets.Behaviour.UI;
using Assets.Source.Item;
using Assets.Source.Player;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Behaviour.Util
{
	public class SteamStatsManager : MonoBehaviour
	{
		public const float StatsStoreInterval = 300f;

		public const float RichPresenceInterval = 5f;

		private static SteamStatsManager _instance;

		private float _statsStoreTimer = 300f;

		private float _updateRichPresenceTimer = 5f;

		private bool _loaded;

		private Dictionary<SteamStatType, SteamStat> _stats = new Dictionary<SteamStatType, SteamStat>();

		private Dictionary<ItemType, SteamStat> _statsByItem = new Dictionary<ItemType, SteamStat>();

		private Callback<GameOverlayActivated_t> _overlayActivated;

		private string _richPresenceString;

		private void Awake()
		{
			if ((bool)_instance)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			_instance = this;
			Object.DontDestroyOnLoad(this);
			_initStats();
		}

		private void Start()
		{
			if (SteamManager.Initialized)
			{
				_overlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
			}
		}

		public void OnGameOverlayActivated(GameOverlayActivated_t data)
		{
			if (data.m_bActive != 0)
			{
				Time.timeScale = 0f;
			}
			else if (!GameUI.MenuVisible)
			{
				Time.timeScale = 1f;
			}
		}

		private void _initStats()
		{
			_addStat(new SteamStat(SteamStatType.WidgetsCrafted, new int[5] { 10, 10000, 10000000, 100000000, 1000000000 }, "widget"));
			_addStat(new SteamStat(SteamStatType.TechTier, new int[6] { 2, 4, 6, 8, 10, 12 }));
			_addStat(new SteamStat(SteamStatType.CircuitBoardsCrafted, new int[1] { 5000000 }, "circuit_board"));
			_addStat(new SteamStat(SteamStatType.MicroprocessorsCrafted, new int[1] { 5000000 }, "microprocessor"));
			_addStat(new SteamStat(SteamStatType.NanoprocessorsCrafted, new int[1] { 5000000 }, "nanoprocessor"));
			_addStat(new SteamStat(SteamStatType.PicoprocessorsCrafted, new int[1] { 5000000 }, "picoprocessor"));
			_addStat(new SteamStat(SteamStatType.OmegaWidgetsCrafted, new int[3] { 10, 10000, 1000000 }, "omega_widget"));
			_addStat(new SteamStat(SteamStatType.Ascensions, new int[2] { 1, 10 }));
			_addStat(new SteamStat(SteamStatType.MaxPrestige, new int[3] { 5, 25, 50 }));
			_addStat(new SteamStat(SteamStatType.RocketsLaunched, new int[4] { 1, 10, 30, 60 }));
			_addStat(new SteamStat(SteamStatType.FramesBuilt, new int[4] { 10, 100, 1000, 2500 }));
			_addStat(new SteamStat(SteamStatType.PowerPerSecond, new int[2] { 1000, 50000 }));
			_addStat(new SteamStat(SteamStatType.Handcrafted, new int[2] { 1000, 1000000 }));
			_addStat(new SteamStat(SteamStatType.WidgetsHandcrafted, new int[1] { 10000 }));
			_addStat(new SteamStat(SteamStatType.PlacementBonus, new int[3] { 10, 250, 1500 }));
			_addStat(new SteamStat(SteamStatType.Warehouses, new int[2] { 10, 100 }));
			_addStat(new SteamStat(SteamStatType.FramesUpgraded, new int[3] { 1, 200, 2000 }));
			_addStat(new SteamStat(SteamStatType.SecretButtons, new int[1] { 12 }));
			_addStat(new SteamStat(SteamStatType.GlitchWidgetsSpent, new int[2] { 100, 10000 }));
			_addStat(new SteamStat(SteamStatType.LogisticsHubs, new int[1] { 100 }));
			_addStat(new SteamStat(SteamStatType.Graveyards, new int[1] { 100 }));
		}

		private void _addStat(SteamStat stat)
		{
			_stats[stat.Stat] = stat;
			if (stat.Item != null)
			{
				_statsByItem[stat.Item] = stat;
			}
		}

		private void Update()
		{
			if (!_loaded && SteamManager.Initialized)
			{
				SteamUserStats.RequestCurrentStats();
				_loaded = true;
			}
			foreach (SteamStat value in _stats.Values)
			{
				value.Update(Time.deltaTime);
			}
			_statsStoreTimer -= Time.deltaTime;
			if (_statsStoreTimer < 0f)
			{
				_statsStoreTimer = 300f;
				SteamUserStats.StoreStats();
			}
			_updateRichPresenceTimer -= Time.deltaTime;
			if (_updateRichPresenceTimer < 0f)
			{
				_updateRichPresenceTimer = 5f;
				_updateRichPresence();
			}
		}

		private void OnApplicationQuit()
		{
			if (SteamManager.Initialized)
			{
				SteamUserStats.StoreStats();
			}
		}

		private void _updateRichPresence()
		{
			if (SteamManager.Initialized)
			{
				string text = _getRichPresenceText();
				if (text != null && text != _richPresenceString)
				{
					_richPresenceString = text;
					SteamFriends.SetRichPresence("steam_display", text);
				}
			}
		}

		private string _getRichPresenceText()
		{
			if (SceneManager.GetActiveScene().name == "MainMenu")
			{
				return "Main Menu";
			}
			if (GamePlayer.Current == null)
			{
				return "Loading game";
			}
			TechNode[] milestoneTech = MilestoneUI.MilestoneTech;
			foreach (TechNode techNode in milestoneTech)
			{
				if (GamePlayer.Current.GetTechConstruction(techNode) != null)
				{
					return "Researching " + techNode.Name;
				}
			}
			switch (GamePlayer.Current.TechTier)
			{
			case 1:
				return "Building Widgets";
			case 2:
				return "Increasing Widget spin rate";
			case 3:
				return "Enhancing Widget capacitance";
			case 4:
				return "Computing Widget performance";
			case 5:
				return "Integrating Widget efficiency";
			case 6:
				return "Engaging Widget mainframes";
			case 7:
				return "Uploading Widgets to cloud";
			case 8:
				return "Measuring Quantum Widgets";
			case 9:
				return "Breaking Widget shackles";
			case 10:
				return "Preparing for Widget Ascension";
			case 11:
				return "Fostering Widget Sentience";
			default:
				if (GamePlayer.Current.RocketParts > 0L)
				{
					return "Building a Rocket";
				}
				return "Placating the Omega Widgets";
			}
		}

		public static void Init()
		{
			if (!_instance)
			{
				new GameObject("SteamStatsManager").AddComponent<SteamStatsManager>();
			}
		}

		public static void Add(SteamStatType type, int count)
		{
			if ((bool)_instance && _instance._stats.TryGetValue(type, out var value))
			{
				value.Add(count);
			}
		}

		public static void Set(SteamStatType type, int val)
		{
			if ((bool)_instance && _instance._stats.TryGetValue(type, out var value))
			{
				value.Set(val);
			}
		}

		public static void ItemProduced(ItemType type, BigInteger count, bool handCrafted)
		{
			if ((bool)_instance && !(count > 2147483647L))
			{
				if (_instance._statsByItem.TryGetValue(type, out var value))
				{
					value.Add((int)count);
				}
				if (handCrafted && type != ItemType.WidgetParticle && type != ItemType.Power)
				{
					Add(SteamStatType.Handcrafted, (int)count);
				}
				if (handCrafted && type == ItemType.BasicWidget)
				{
					Add(SteamStatType.WidgetsHandcrafted, (int)count);
				}
			}
		}
	}
}
