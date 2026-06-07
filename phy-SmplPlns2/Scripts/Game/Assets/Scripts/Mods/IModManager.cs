using System;
using System.Collections.Generic;
using Assets.Scripts.Levels;
using Assets.Scripts.Mods.Events;
using UnityEngine;

namespace Assets.Scripts.Mods
{
	public interface IModManager : IModManagerBase
	{
		IReadOnlyList<MapInfo> AllMaps { get; }

		IReadOnlyList<GameMod> GameMods { get; }

		IReadOnlyList<ModLevelInfo> Levels { get; }

		IReadOnlyList<MapInfo> SandboxMaps { get; }

		bool SupportsCodeExecution { get; }

		event EventHandler<ModLoadedEventArgs> ModLoaded;

		ModLevelInfo? GetModLevelInfo(string modName, string levelName);

		MapInfo? GetModMapInfo(string modName, string mapName);

		LevelBase LoadLevel(ModLevelInfo level);

		GameObject LoadMap(MapInfo map);
	}
}
