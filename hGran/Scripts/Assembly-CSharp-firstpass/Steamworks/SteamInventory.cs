namespace Steamworks
{
	public static class SteamInventory
	{
		public static EResult GetResultStatus(SteamInventoryResult_t resultHandle)
		{
			return default(EResult);
		}

		public static bool GetResultItems(SteamInventoryResult_t resultHandle, SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize)
		{
			return false;
		}

		public static bool GetResultItemProperty(SteamInventoryResult_t resultHandle, uint unItemIndex, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut)
		{
			pchValueBuffer = null;
			return false;
		}

		public static uint GetResultTimestamp(SteamInventoryResult_t resultHandle)
		{
			return 0u;
		}

		public static bool CheckResultSteamID(SteamInventoryResult_t resultHandle, CSteamID steamIDExpected)
		{
			return false;
		}

		public static void DestroyResult(SteamInventoryResult_t resultHandle)
		{
		}

		public static bool GetAllItems(out SteamInventoryResult_t pResultHandle)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool GetItemsByID(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t[] pInstanceIDs, uint unCountInstanceIDs)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool SerializeResult(SteamInventoryResult_t resultHandle, byte[] pOutBuffer, out uint punOutBufferSize)
		{
			punOutBufferSize = default(uint);
			return false;
		}

		public static bool DeserializeResult(out SteamInventoryResult_t pOutResultHandle, byte[] pBuffer, uint unBufferSize, bool bRESERVED_MUST_BE_FALSE = false)
		{
			pOutResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool GenerateItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint[] punArrayQuantity, uint unArrayLength)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool GrantPromoItems(out SteamInventoryResult_t pResultHandle)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool AddPromoItem(out SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool AddPromoItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint unArrayLength)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool ConsumeItem(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool ExchangeItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayGenerate, uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, SteamItemInstanceID_t[] pArrayDestroy, uint[] punArrayDestroyQuantity, uint unArrayDestroyLength)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool TransferItemQuantity(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static void SendItemDropHeartbeat()
		{
		}

		public static bool TriggerItemDrop(out SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool TradeItems(out SteamInventoryResult_t pResultHandle, CSteamID steamIDTradePartner, SteamItemInstanceID_t[] pArrayGive, uint[] pArrayGiveQuantity, uint nArrayGiveLength, SteamItemInstanceID_t[] pArrayGet, uint[] pArrayGetQuantity, uint nArrayGetLength)
		{
			pResultHandle = default(SteamInventoryResult_t);
			return false;
		}

		public static bool LoadItemDefinitions()
		{
			return false;
		}

		public static bool GetItemDefinitionIDs(SteamItemDef_t[] pItemDefIDs, out uint punItemDefIDsArraySize)
		{
			punItemDefIDsArraySize = default(uint);
			return false;
		}

		public static bool GetItemDefinitionProperty(SteamItemDef_t iDefinition, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSizeOut)
		{
			pchValueBuffer = null;
			return false;
		}

		public static SteamAPICall_t RequestEligiblePromoItemDefinitionsIDs(CSteamID steamID)
		{
			return default(SteamAPICall_t);
		}

		public static bool GetEligiblePromoItemDefinitionIDs(CSteamID steamID, SteamItemDef_t[] pItemDefIDs, ref uint punItemDefIDsArraySize)
		{
			return false;
		}
	}
}
