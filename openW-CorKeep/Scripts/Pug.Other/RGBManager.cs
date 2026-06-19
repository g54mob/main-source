#define PUG_RGB_ENABLED
using System.Collections.Generic;
using System.Diagnostics;
using CgSDK;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;

public class RGBManager : ManagerBase
{
	public enum State
	{
		Menu = 0,
		DirtBiome = 1,
		LarvaBiome = 2,
		StoneBiome = 3,
		NatureBiome = 4,
		MoldBiome = 5,
		SeaBiome = 6,
		CityBiome = 7,
		DesertBiome = 8,
		LavaBiome = 9,
		BossFight = 10,
		Casting = 11,
		SpawnFromCore_Rumble = 12,
		PlayerDeath_FadeToBlack = 13,
		Inventory = 14
	}

	public enum Event
	{
		PlayerDeath_Splat = 0,
		BossKill = 1,
		SpawnFromCore_Spawn = 2,
		LoweringGreatWall = 3,
		DestroyAncientDestructible = 4,
		Bomb = 5,
		FindNewLegendaryItem = 6,
		FindNewEpicItem = 7,
		Sleeping = 8,
		InsertBossCrystal = 9,
		PortalTeleport = 10
	}

	private readonly string gameName = "CoreKeeper";

	private readonly string[] stateProfileNames = new string[15]
	{
		"CORE_Menu", "SDKL_EnvSand", "SDKL_EnvMud", "SDKL_EnvDarkGrey", "SDKL_EnvDarkGreen", "CORE_Mold", "SDKL_UnderwaterBlue", "SDKL_EnvTech", "SDKL_EnvSand", "SDKL_Lava",
		"SDKL_Alarm", "SDKL_PillarsBlue", "SDKL_ShockBlue", "SDKL_FadeToBlack", "CORE_Inventory"
	};

	private readonly string[] eventProfileNames = new string[11]
	{
		"SDKL_BloodSplatter", "SDKL_Explosion", "SDKL_PulseBlue", "SDKL_WaveDownBlue", "SDKL_SplashBlue", "SDKL_Explosion", "SDKL_LootOrange", "SDKL_LootPurple", "SDKL_WaveUpGreen", "SDKL_PulseStarBlue",
		"SDKL_PulseStarCyan"
	};

	private bool initialized;

	private int currentBiomeState = -1;

	private HashSet<State> currentActiveStates = new HashSet<State>();

	private Dictionary<Biome, State> biomeStateMap = new Dictionary<Biome, State>();

	private Dictionary<Event, float> lastEvent = new Dictionary<Event, float>();

	private bool inventoryStateActive;

	private bool useRgb;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("RGBManager.Init");

	public bool IsAvailable => initialized;

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			initialized = global::CgSDK.CgSDK.Initialize(gameName, stateProfileNames, eventProfileNames);
			biomeStateMap.Add(Biome.Slime, State.DirtBiome);
			biomeStateMap.Add(Biome.Larva, State.LarvaBiome);
			biomeStateMap.Add(Biome.Stone, State.StoneBiome);
			biomeStateMap.Add(Biome.Nature, State.NatureBiome);
			biomeStateMap.Add(Biome.Sea, State.SeaBiome);
			biomeStateMap.Add(Biome.Desert, State.DesertBiome);
			return true;
		}
	}

	public override void Deinit()
	{
		if (initialized)
		{
			global::CgSDK.CgSDK.EndAllStates();
			global::CgSDK.CgSDK.EndAllEvents();
			global::CgSDK.CgSDK.Deinitialize();
			base.Deinit();
		}
	}

	[Conditional("PUG_RGB_ENABLED")]
	public void TriggerEvent(Event e)
	{
		if (initialized && useRgb && (!lastEvent.ContainsKey(e) || !(Time.time - lastEvent[e] < 1f)))
		{
			UnityEngine.Debug.Log($"Trigger RGB event {e} ({eventProfileNames[(int)e]})");
			global::CgSDK.CgSDK.TriggerEvent((int)e);
			if (!lastEvent.ContainsKey(e))
			{
				lastEvent.Add(e, Time.time);
			}
			else
			{
				lastEvent[e] = Time.time;
			}
		}
	}

	[Conditional("PUG_RGB_ENABLED")]
	public void StartState(State s)
	{
		if (initialized)
		{
			if (useRgb)
			{
				UnityEngine.Debug.Log($"Start RGB state {s} ({stateProfileNames[(int)s]})");
				global::CgSDK.CgSDK.StartState((int)s);
			}
			currentActiveStates.Add(s);
		}
	}

	[Conditional("PUG_RGB_ENABLED")]
	public void EndState(State s)
	{
		if (initialized)
		{
			if (useRgb)
			{
				UnityEngine.Debug.Log($"End RGB state {s}");
				global::CgSDK.CgSDK.EndState((int)s);
			}
			currentActiveStates.Remove(s);
		}
	}

	[Conditional("PUG_RGB_ENABLED")]
	private void LateUpdate()
	{
		if (!initialized)
		{
			return;
		}
		if (useRgb != Manager.prefs.useRGBEffects)
		{
			if (Manager.prefs.useRGBEffects)
			{
				ResumeAll();
			}
			else
			{
				PauseAll();
			}
			useRgb = Manager.prefs.useRGBEffects;
		}
		if (Manager.sceneHandler == null)
		{
			return;
		}
		if (Manager.sceneHandler.isTitle)
		{
			if (!currentActiveStates.Contains(State.Menu))
			{
				StartState(State.Menu);
			}
		}
		else if (currentActiveStates.Contains(State.Menu))
		{
			EndState(State.Menu);
		}
		if (Manager.ecs.ClientWorld == null)
		{
			if (currentBiomeState != -1)
			{
				global::CgSDK.CgSDK.EndState(currentBiomeState);
				currentBiomeState = -1;
			}
			return;
		}
		if (Manager.music.currentMusicRosterType == MusicRosterType.BOSS)
		{
			if (!currentActiveStates.Contains(State.BossFight))
			{
				StartState(State.BossFight);
			}
		}
		else if (currentActiveStates.Contains(State.BossFight))
		{
			EndState(State.BossFight);
		}
		if (!(Manager.main.player != null))
		{
			return;
		}
		Manager.audio.ambientSoundsHandler.GetNearbyTileData(out var tileCount).Complete();
		int tileCount2 = GetTileCount(tileCount, TileType.ground, Tileset.Mold);
		int tileCount3 = GetTileCount(tileCount, TileType.ground, Tileset.City);
		int num = GetTileCount(tileCount, TileType.ground, Tileset.Lava) + GetTileCount(tileCount, TileType.water, Tileset.Lava);
		TileInfo topTile = Manager.multiMap.GetTileLayerLookup().GetTopTile(Manager.main.player.WorldPosition.RoundToInt2());
		int num2;
		if (tileCount2 >= 50 && (currentBiomeState == 5 || topTile.tileset == 9))
		{
			num2 = 5;
		}
		else if (tileCount3 >= 50 && (currentBiomeState == 7 || topTile.tileset == 24))
		{
			num2 = 7;
		}
		else if (num >= 50 && (currentBiomeState == 9 || topTile.tileset == 3))
		{
			num2 = 9;
		}
		else
		{
			Biome currentBiome = Manager.main.player.currentBiome;
			num2 = (int)(biomeStateMap.ContainsKey(currentBiome) ? biomeStateMap[currentBiome] : ((State)(-1)));
		}
		if (num2 != -1 && num2 != currentBiomeState)
		{
			if (currentBiomeState != -1)
			{
				EndState((State)currentBiomeState);
			}
			StartState((State)num2);
			currentBiomeState = num2;
		}
		if (!Manager.ui.isAnyInventoryShowing && inventoryStateActive)
		{
			EndState(State.Inventory);
			inventoryStateActive = false;
		}
		else if (Manager.ui.isAnyInventoryShowing && !inventoryStateActive)
		{
			StartState(State.Inventory);
			inventoryStateActive = true;
		}
	}

	private void PauseAll()
	{
		foreach (State currentActiveState in currentActiveStates)
		{
			global::CgSDK.CgSDK.EndState((int)currentActiveState);
		}
		global::CgSDK.CgSDK.EndAllEvents();
	}

	private void ResumeAll()
	{
		foreach (State currentActiveState in currentActiveStates)
		{
			global::CgSDK.CgSDK.StartState((int)currentActiveState);
		}
	}

	private static int GetTileCount(NativeHashMap<TileTypeAndTileset, int> tileCount, TileType tileType, Tileset tileset)
	{
		TileTypeAndTileset key = new TileTypeAndTileset
		{
			TileType = tileType,
			Tileset = tileset
		};
		if (!tileCount.TryGetValue(key, out var item))
		{
			return 0;
		}
		return item;
	}

	[Conditional("PUG_RGB_ENABLED")]
	public void OnSceneUnload()
	{
		if (initialized)
		{
			global::CgSDK.CgSDK.EndAllStates();
			global::CgSDK.CgSDK.EndAllEvents();
			currentActiveStates.Clear();
			currentBiomeState = -1;
		}
	}
}
