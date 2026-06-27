using System;
using PixelCrushers.DialogueSystem;
using Zenject;

namespace Restory.Gameplay.Competitions
{
	public sealed class CompetitionsLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string HasLastSubmittedDevice = "Competitions_HasLastSubmittedDevice";

			public static readonly string GetLastSubmittedDeviceId = "Competitions_GetLastSubmittedDeviceId";

			public static readonly string WasLastSubmittedDeviceBestTime = "Competitions_WasLastSubmittedDeviceBestTime";
		}

		private readonly CompetitionsLastSubmittedDeviceTrackingService lastSubmittedDeviceTrackingService;

		public CompetitionsLuaWrappers(CompetitionsLastSubmittedDeviceTrackingService lastSubmittedDeviceTrackingService)
		{
			this.lastSubmittedDeviceTrackingService = lastSubmittedDeviceTrackingService;
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
			Lua.RegisterFunction(LuaNames.HasLastSubmittedDevice, this, SymbolExtensions.GetMethodInfo(() => HasLastSubmittedDevice()));
			Lua.RegisterFunction(LuaNames.GetLastSubmittedDeviceId, this, SymbolExtensions.GetMethodInfo(() => GetLastSubmittedDeviceId()));
			Lua.RegisterFunction(LuaNames.WasLastSubmittedDeviceBestTime, this, SymbolExtensions.GetMethodInfo(() => WasLastSubmittedDeviceBestTime()));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.HasLastSubmittedDevice);
			Lua.UnregisterFunction(LuaNames.GetLastSubmittedDeviceId);
			Lua.UnregisterFunction(LuaNames.WasLastSubmittedDeviceBestTime);
		}

		private bool HasLastSubmittedDevice()
		{
			return lastSubmittedDeviceTrackingService.HasSubmittedDevice;
		}

		private string GetLastSubmittedDeviceId()
		{
			if (!lastSubmittedDeviceTrackingService.HasSubmittedDevice)
			{
				return string.Empty;
			}
			return lastSubmittedDeviceTrackingService.LastSubmittedDeviceInfo.ID;
		}

		private bool WasLastSubmittedDeviceBestTime()
		{
			if (lastSubmittedDeviceTrackingService.HasSubmittedDevice)
			{
				return lastSubmittedDeviceTrackingService.WasLastSubmittedDeviceBestTime;
			}
			return false;
		}
	}
}
