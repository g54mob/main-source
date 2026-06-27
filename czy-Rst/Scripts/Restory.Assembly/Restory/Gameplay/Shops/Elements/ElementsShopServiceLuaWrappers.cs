using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.Base;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.Shops.Elements;
using Zenject;

namespace Restory.Gameplay.Shops.Elements
{
	public class ElementsShopServiceLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string SetElementIsInStock = "ElementsShop_SetElementIsInStock";

			public static readonly string SetDeviceElementsIsInStock = "ElementsShop_SetDeviceElementsIsInStock";
		}

		private readonly ElementsShopService elementsShopService;

		private readonly GameEntityDataBaseProvider gameEntityDataBaseProvider;

		public ElementsShopServiceLuaWrappers(ElementsShopService elementsShopService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.elementsShopService = elementsShopService;
			this.gameEntityDataBaseProvider = gameEntityDataBaseProvider;
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
			Lua.RegisterFunction(LuaNames.SetElementIsInStock, this, SymbolExtensions.GetMethodInfo(() => SetElementIsInStock(string.Empty, isInStock: true)));
			Lua.RegisterFunction(LuaNames.SetDeviceElementsIsInStock, this, SymbolExtensions.GetMethodInfo(() => SetDeviceElementsIsInStock(string.Empty, isInStock: true)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.SetElementIsInStock);
			Lua.UnregisterFunction(LuaNames.SetDeviceElementsIsInStock);
		}

		private void SetElementIsInStock(string elementID, bool isInStock)
		{
			if (!gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<RestoryEntityInfoBase>(elementID, out var entityInfo))
			{
				return;
			}
			foreach (ElementsShopItemData elementItem in elementsShopService.ElementItems)
			{
				if (elementItem.Element == entityInfo)
				{
					elementItem.IsInStock = isInStock;
				}
			}
		}

		private void SetDeviceElementsIsInStock(string deviceID, bool isInStock)
		{
			if (!gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceInfo>(deviceID, out var entityInfo))
			{
				return;
			}
			foreach (ElementsShopItemData elementItem in elementsShopService.ElementItems)
			{
				ElementInfo element = elementItem.Element;
				if ((object)element != null && element.SourceDevice is DeviceInfo deviceInfo && deviceInfo == entityInfo)
				{
					elementItem.IsInStock = isInStock;
				}
			}
		}
	}
}
