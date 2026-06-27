using System;
using PixelCrushers.DialogueSystem;
using Restory.Data.GameConfigs;
using Zenject;

namespace Restory.Gameplay.Dialogue.LuaWrappers
{
	public class GameVersionLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string GetBuildType = "GameVersion_GetBuildType";

			public static readonly string IsFullReleaseVersion = "GameVersion_IsFullReleaseVersion";

			public static readonly string IsDemoVersion = "GameVersion_IsDemoVersion";

			public static readonly string IsPlaytestVersion = "GameVersion_IsPlaytestVersion";
		}

		private readonly GameConfig gameConfig;

		public GameVersionLuaWrappers(GameConfig gameConfig)
		{
			this.gameConfig = gameConfig;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.GetBuildType, this, SymbolExtensions.GetMethodInfo(() => GetBuildType()));
			Lua.RegisterFunction(LuaNames.IsFullReleaseVersion, this, SymbolExtensions.GetMethodInfo(() => IsFullReleaseVersion()));
			Lua.RegisterFunction(LuaNames.IsDemoVersion, this, SymbolExtensions.GetMethodInfo(() => IsDemoVersion()));
			Lua.RegisterFunction(LuaNames.IsPlaytestVersion, this, SymbolExtensions.GetMethodInfo(() => IsPlaytestVersion()));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.GetBuildType);
			Lua.UnregisterFunction(LuaNames.IsFullReleaseVersion);
			Lua.UnregisterFunction(LuaNames.IsDemoVersion);
			Lua.UnregisterFunction(LuaNames.IsPlaytestVersion);
		}

		private string GetBuildType()
		{
			return gameConfig.VersionType.ToString();
		}

		private bool IsFullReleaseVersion()
		{
			return gameConfig.VersionType == VersionType.Release;
		}

		private bool IsDemoVersion()
		{
			return gameConfig.VersionType == VersionType.Demo;
		}

		private bool IsPlaytestVersion()
		{
			return gameConfig.VersionType == VersionType.Playtest;
		}
	}
}
