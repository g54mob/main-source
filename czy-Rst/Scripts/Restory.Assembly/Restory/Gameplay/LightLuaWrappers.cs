using System;
using PixelCrushers.DialogueSystem;
using Zenject;

namespace Restory.Gameplay
{
	public class LightLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string PlayPowerSurgeEffect = "Light_PlayPowerSurgeEffect";
		}

		private readonly LightEffectsService lightEffectsService;

		public LightLuaWrappers(LightEffectsService lightEffectsService)
		{
			this.lightEffectsService = lightEffectsService;
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
			Lua.RegisterFunction(LuaNames.PlayPowerSurgeEffect, this, SymbolExtensions.GetMethodInfo(() => PlayPowerSurgeEffect()));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.PlayPowerSurgeEffect);
		}

		private void PlayPowerSurgeEffect()
		{
			lightEffectsService.PlayPowerSurgeEffect();
		}
	}
}
