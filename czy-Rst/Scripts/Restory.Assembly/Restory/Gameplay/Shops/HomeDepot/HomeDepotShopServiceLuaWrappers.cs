using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.Base;
using Restory.Data.Decors;
using Restory.Data.Equipment;
using Restory.Data.PC;
using Zenject;

namespace Restory.Gameplay.Shops.HomeDepot
{
	public class HomeDepotShopServiceLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string SetItemIsHiddenInShop = "HomeDepotShop_SetItemIsHiddenInShop";
		}

		private readonly HomeDepotShopService homeDepotShopService;

		private readonly GameEntityDataBaseProvider gameEntityDataBaseProvider;

		public HomeDepotShopServiceLuaWrappers(HomeDepotShopService homeDepotShopService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.homeDepotShopService = homeDepotShopService;
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
			Lua.RegisterFunction(LuaNames.SetItemIsHiddenInShop, this, SymbolExtensions.GetMethodInfo(() => SetItemIsHiddenInShop(string.Empty, isHiddenInShop: true)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.SetItemIsHiddenInShop);
		}

		private void SetItemIsHiddenInShop(string itemID, bool isHiddenInShop)
		{
			if (!gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<RestoryEntityInfoBase>(itemID, out var entityInfo))
			{
				return;
			}
			if (!(entityInfo is DecorInfo decorInfo))
			{
				if (!(entityInfo is ToolInfo toolInfo))
				{
					if (!(entityInfo is PaintingPaletteInfo paletteInfo))
					{
						if (entityInfo is PcAppInfo pcAppInfo)
						{
							homeDepotShopService.SetPcAppItemIsHiddenInShop(pcAppInfo, isHiddenInShop);
						}
					}
					else
					{
						homeDepotShopService.SetPaletteItemIsHiddenInShop(paletteInfo, isHiddenInShop);
					}
				}
				else
				{
					homeDepotShopService.SetCleaningToolItemIsHiddenInShop(toolInfo, isHiddenInShop);
				}
			}
			else
			{
				homeDepotShopService.SetDecorItemIsHiddenInShop(decorInfo, isHiddenInShop);
			}
		}
	}
}
