using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.Decors;
using Restory.Gameplay.Storages;
using Zenject;

namespace Restory.Gameplay.Decors
{
	public class DecorLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string CreateDecor = "Decors_CreateDecor";
		}

		private readonly GameEntityDataBaseProvider gameEntityDataBaseProvider;

		private readonly DevicesFromNpcsService deliveryService;

		public DecorLuaWrappers(DevicesFromNpcsService devicesFromNpcsService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.gameEntityDataBaseProvider = gameEntityDataBaseProvider;
			deliveryService = devicesFromNpcsService;
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
			Lua.RegisterFunction(LuaNames.CreateDecor, this, SymbolExtensions.GetMethodInfo(() => CreateDecor(string.Empty)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.CreateDecor);
		}

		private void CreateDecor(string deviceConditionID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DecorInfo>(deviceConditionID, out var entityInfo))
			{
				deliveryService.AddInteractiveObject(entityInfo);
			}
		}
	}
}
