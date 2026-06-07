using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration.API
{
	public static class Inventory
	{
		public static class Client
		{
			private class SerializationPointer
			{
				public UserData expectedUser;

				public Action<InventoryResult> callback;
			}

			private static Dictionary<ItemData, List<ItemDetail>> itemIndex = new Dictionary<ItemData, List<ItemDetail>>();

			private static SteamInventoryDefinitionUpdateEvent eventSteamInventoryDefinitionUpdate = new SteamInventoryDefinitionUpdateEvent();

			private static SteamInventoryResultReadyEvent eventSteamInventoryResultReady = new SteamInventoryResultReadyEvent();

			private static SteamMicroTransactionAuthorizationResponce eventSteamMTXAuthResponse = new SteamMicroTransactionAuthorizationResponce();

			private static Dictionary<SteamInventoryResult_t, Action<InventoryResult>> resultHandles = new Dictionary<SteamInventoryResult_t, Action<InventoryResult>>();

			private static Dictionary<SteamInventoryResult_t, Action<byte[]>> serializationResults = new Dictionary<SteamInventoryResult_t, Action<byte[]>>();

			private static Dictionary<SteamInventoryResult_t, SerializationPointer> deserializationResults = new Dictionary<SteamInventoryResult_t, SerializationPointer>();

			private static CallResult<SteamInventoryEligiblePromoItemDefIDs_t> m_SteamInventoryEligiblePromoItemDefIDs_t;

			private static CallResult<SteamInventoryStartPurchaseResult_t> m_SteamInventoryStartPurchaseResult_t;

			private static CallResult<SteamInventoryRequestPricesResult_t> m_SteamInventoryRequestPricesResult_t;

			private static Callback<SteamInventoryDefinitionUpdate_t> m_SteamInventoryDefinitionUpdate_t;

			private static Callback<SteamInventoryResultReady_t> m_SteamInventoryResultReady_t;

			private static Callback<MicroTxnAuthorizationResponse_t> m_MicroTxnAuthorizationResponse_t;

			public static Currency.Code LocalCurrencyCode { get; private set; }

			public static string LocalCurrencySymbol => Currency.GetSymbol(LocalCurrencyCode);

			public static SteamInventoryDefinitionUpdateEvent EventSteamInventoryDefinitionUpdate
			{
				get
				{
					if (m_SteamInventoryDefinitionUpdate_t == null)
					{
						m_SteamInventoryDefinitionUpdate_t = Callback<SteamInventoryDefinitionUpdate_t>.Create(delegate
						{
							eventSteamInventoryDefinitionUpdate.Invoke();
						});
					}
					return eventSteamInventoryDefinitionUpdate;
				}
			}

			public static SteamInventoryResultReadyEvent EventSteamInventoryResultReady
			{
				get
				{
					if (m_SteamInventoryResultReady_t == null)
					{
						m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
					}
					return eventSteamInventoryResultReady;
				}
			}

			public static SteamMicroTransactionAuthorizationResponce EventSteamMicroTransactionAuthorizationResponse
			{
				get
				{
					if (m_MicroTxnAuthorizationResponse_t == null)
					{
						m_MicroTxnAuthorizationResponse_t = Callback<MicroTxnAuthorizationResponse_t>.Create(delegate(MicroTxnAuthorizationResponse_t r)
						{
							eventSteamMTXAuthResponse.Invoke(new AppId_t(r.m_unAppID), r.m_ulOrderID, r.m_bAuthorized == 1);
						});
					}
					return eventSteamMTXAuthResponse;
				}
			}

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void Init()
			{
				itemIndex = new Dictionary<ItemData, List<ItemDetail>>();
				eventSteamInventoryDefinitionUpdate = new SteamInventoryDefinitionUpdateEvent();
				eventSteamInventoryResultReady = new SteamInventoryResultReadyEvent();
				eventSteamMTXAuthResponse = new SteamMicroTransactionAuthorizationResponce();
				resultHandles = new Dictionary<SteamInventoryResult_t, Action<InventoryResult>>();
				serializationResults = new Dictionary<SteamInventoryResult_t, Action<byte[]>>();
				deserializationResults = new Dictionary<SteamInventoryResult_t, SerializationPointer>();
				m_SteamInventoryEligiblePromoItemDefIDs_t = null;
				m_SteamInventoryStartPurchaseResult_t = null;
				m_SteamInventoryRequestPricesResult_t = null;
				m_SteamInventoryDefinitionUpdate_t = null;
				m_SteamInventoryResultReady_t = null;
				m_MicroTxnAuthorizationResponse_t = null;
			}

			public static List<ItemDetail> Details(ItemData item)
			{
				if (!itemIndex.ContainsKey(item))
				{
					itemIndex.Add(item, new List<ItemDetail>());
				}
				return itemIndex[item];
			}

			public static long ItemTotalQuantity(ItemData item)
			{
				if (!itemIndex.ContainsKey(item))
				{
					return 0L;
				}
				return itemIndex[item].Sum((ItemDetail p) => Convert.ToInt64(p.Quantity));
			}

			public static bool AddPromoItem(SteamItemDef_t itemDef, Action<InventoryResult> callback)
			{
				if (callback == null)
				{
					return false;
				}
				if (m_SteamInventoryResultReady_t == null)
				{
					m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
				}
				if (SteamInventory.AddPromoItem(out var pResultHandle, itemDef))
				{
					resultHandles.Add(pResultHandle, callback);
					return true;
				}
				return false;
			}

			public static bool AddPromoItems(ItemDefinitionObject item, Action<InventoryResult> callback)
			{
				return AddPromoItem(item.Id, callback);
			}

			public static bool AddPromoItems(SteamItemDef_t[] itemDefs, Action<InventoryResult> callback)
			{
				if (callback == null)
				{
					return false;
				}
				if (m_SteamInventoryResultReady_t == null)
				{
					m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
				}
				if (SteamInventory.AddPromoItems(out var pResultHandle, itemDefs, (uint)itemDefs.Length))
				{
					resultHandles.Add(pResultHandle, callback);
					return true;
				}
				return false;
			}

			public static bool AddPromoItems(ItemDefinitionObject[] items, Action<InventoryResult> callback)
			{
				return AddPromoItems(Array.ConvertAll(items, (ItemDefinitionObject p) => p.Id), callback);
			}

			public static bool AddPromoItems(IEnumerable<SteamItemDef_t> itemDefs, Action<InventoryResult> callback)
			{
				return AddPromoItems(itemDefs.ToArray(), callback);
			}

			public static bool CheckResultSteamID(SteamInventoryResult_t resultHandle, CSteamID steamIDExpected)
			{
				return SteamInventory.CheckResultSteamID(resultHandle, steamIDExpected);
			}

			public static void ConsumeItem(SteamItemInstanceID_t itemConsume, uint quantity, Action<InventoryResult> callback)
			{
				if (callback != null)
				{
					if (m_SteamInventoryResultReady_t == null)
					{
						m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
					}
					SteamInventory.ConsumeItem(out var pResultHandle, itemConsume, quantity);
					resultHandles.Add(pResultHandle, callback);
				}
			}

			public static void DeserializeResult(UserData expectedUser, byte[] buffer, Action<InventoryResult> callback)
			{
				if (callback != null)
				{
					if (m_SteamInventoryResultReady_t == null)
					{
						m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
					}
					SteamInventory.DeserializeResult(out var pOutResultHandle, buffer, (uint)buffer.Length);
					deserializationResults.Add(pOutResultHandle, new SerializationPointer
					{
						callback = callback,
						expectedUser = expectedUser
					});
				}
			}

			public static void DestroyResult(SteamInventoryResult_t resultHandle)
			{
				SteamInventory.DestroyResult(resultHandle);
			}

			public static void ExchangeItems(SteamItemDef_t generate, SteamItemInstanceID_t[] destroy, uint[] destroyQuantity, Action<InventoryResult> callback)
			{
				if (callback != null)
				{
					if (m_SteamInventoryResultReady_t == null)
					{
						m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
					}
					SteamInventory.ExchangeItems(out var pResultHandle, new SteamItemDef_t[1] { generate }, new uint[1] { 1u }, 1u, destroy, destroyQuantity, (uint)destroy.Length);
					resultHandles.Add(pResultHandle, callback);
				}
			}

			public static void GenerateItems(SteamItemDef_t[] itemDefs, uint[] quantity, Action<InventoryResult> callback)
			{
				if (callback != null)
				{
					if (m_SteamInventoryResultReady_t == null)
					{
						m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
					}
					SteamInventory.GenerateItems(out var pResultHandle, itemDefs, quantity, (uint)itemDefs.Length);
					resultHandles.Add(pResultHandle, callback);
				}
			}

			public static void GetAllItems(Action<InventoryResult> callback = null)
			{
				if (m_SteamInventoryResultReady_t == null)
				{
					m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
				}
				itemIndex.Clear();
				SteamInventory.GetAllItems(out var pResultHandle);
				if (callback != null)
				{
					if (resultHandles.ContainsKey(pResultHandle))
					{
						resultHandles[pResultHandle] = callback;
					}
					else
					{
						resultHandles.Add(pResultHandle, callback);
					}
				}
			}

			public static void GetEligiblePromoItems(UserData user, Action<EResult, ItemData[], bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				if (m_SteamInventoryEligiblePromoItemDefIDs_t == null)
				{
					m_SteamInventoryEligiblePromoItemDefIDs_t = CallResult<SteamInventoryEligiblePromoItemDefIDs_t>.Create();
				}
				SteamAPICall_t hAPICall = SteamInventory.RequestEligiblePromoItemDefinitionsIDs(user);
				m_SteamInventoryEligiblePromoItemDefIDs_t.Set(hAPICall, delegate(SteamInventoryEligiblePromoItemDefIDs_t result, bool e)
				{
					if (e || result.m_result != EResult.k_EResultOK)
					{
						callback?.Invoke(result.m_result, new ItemData[0], e);
					}
					else
					{
						SteamItemDef_t[] array = new SteamItemDef_t[result.m_numEligiblePromoItemDefs];
						uint punItemDefIDsArraySize = (uint)result.m_numEligiblePromoItemDefs;
						if (SteamInventory.GetEligiblePromoItemDefinitionIDs(user, array, ref punItemDefIDsArraySize))
						{
							ItemData[] array2 = new ItemData[punItemDefIDsArraySize];
							for (int i = 0; i < punItemDefIDsArraySize; i++)
							{
								array2[i] = array[i];
							}
							callback?.Invoke(result.m_result, array2, e);
						}
						else
						{
							callback(EResult.k_EResultFail, null, e);
						}
					}
				});
			}

			public static void GetEligiblePromoItems(UserData user, Action<EResult, ItemDefinitionObject[], bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				if (SteamSettings.current == null)
				{
					Debug.LogError("GetEligiblePromoItems can only return ItemDefinitionObject results when their is a current SteamSettings object.");
					callback?.Invoke(EResult.k_EResultInvalidParam, null, arg3: true);
					return;
				}
				if (m_SteamInventoryEligiblePromoItemDefIDs_t == null)
				{
					m_SteamInventoryEligiblePromoItemDefIDs_t = CallResult<SteamInventoryEligiblePromoItemDefIDs_t>.Create();
				}
				SteamAPICall_t hAPICall = SteamInventory.RequestEligiblePromoItemDefinitionsIDs(user);
				m_SteamInventoryEligiblePromoItemDefIDs_t.Set(hAPICall, delegate(SteamInventoryEligiblePromoItemDefIDs_t result, bool e)
				{
					if (e || result.m_result != EResult.k_EResultOK)
					{
						callback?.Invoke(result.m_result, null, e);
					}
					else
					{
						SteamItemDef_t[] buffer = new SteamItemDef_t[result.m_numEligiblePromoItemDefs];
						uint punItemDefIDsArraySize = (uint)result.m_numEligiblePromoItemDefs;
						if (SteamInventory.GetEligiblePromoItemDefinitionIDs(user, buffer, ref punItemDefIDsArraySize))
						{
							ItemDefinitionObject[] array = new ItemDefinitionObject[buffer.Length];
							int i;
							for (i = 0; i < punItemDefIDsArraySize; i++)
							{
								array[i] = SteamSettings.Client.inventory.items.FirstOrDefault((ItemDefinitionObject p) => p.Id == buffer[i]);
							}
							callback(result.m_result, array, e);
						}
						else
						{
							callback(EResult.k_EResultFail, null, e);
						}
					}
				});
			}

			public static bool GetItemDefinitionIDs(out SteamItemDef_t[] results)
			{
				uint punItemDefIDsArraySize = 0u;
				if (SteamInventory.GetItemDefinitionIDs(null, ref punItemDefIDsArraySize))
				{
					results = new SteamItemDef_t[punItemDefIDsArraySize];
					return SteamInventory.GetItemDefinitionIDs(results, ref punItemDefIDsArraySize);
				}
				results = new SteamItemDef_t[0];
				return false;
			}

			public static string GetItemDefinitionProperty(SteamItemDef_t item, string propertyName)
			{
				uint punValueBufferSizeOut = 0u;
				if (SteamInventory.GetItemDefinitionProperty(item, propertyName, out var _, ref punValueBufferSizeOut))
				{
					SteamInventory.GetItemDefinitionProperty(item, propertyName, out var pchValueBuffer2, ref punValueBufferSizeOut);
					return pchValueBuffer2;
				}
				return string.Empty;
			}

			public static string[] GetItemDefinitionProperties(SteamItemDef_t item)
			{
				uint punValueBufferSizeOut = 0u;
				SteamInventory.GetItemDefinitionProperty(item, null, out var pchValueBuffer, ref punValueBufferSizeOut);
				SteamInventory.GetItemDefinitionProperty(item, null, out pchValueBuffer, ref punValueBufferSizeOut);
				return pchValueBuffer.Split(',');
			}

			public static void GetItemsByID(SteamItemInstanceID_t[] instanceIds, Action<InventoryResult> callback = null)
			{
				if (m_SteamInventoryResultReady_t == null)
				{
					m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
				}
				SteamInventory.GetItemsByID(out var pResultHandle, instanceIds, (uint)instanceIds.Length);
				if (callback != null)
				{
					resultHandles.Add(pResultHandle, callback);
				}
			}

			public static bool GetItemPrice(SteamItemDef_t item, out ulong currentPrice, out ulong basePrice)
			{
				return SteamInventory.GetItemPrice(item, out currentPrice, out basePrice);
			}

			public static bool GetItemsWithPrices(out SteamItemDef_t[] items, out ulong[] currentPrices, out ulong[] basePrices)
			{
				uint numItemsWithPrices = SteamInventory.GetNumItemsWithPrices();
				items = new SteamItemDef_t[numItemsWithPrices];
				currentPrices = new ulong[numItemsWithPrices];
				basePrices = new ulong[numItemsWithPrices];
				return SteamInventory.GetItemsWithPrices(items, currentPrices, basePrices, numItemsWithPrices);
			}

			public static bool GetResultItemProperty(SteamInventoryResult_t resultHandle, uint itemIndex, string propertyName, out string valueBuffer, ref uint bufferSize)
			{
				return SteamInventory.GetResultItemProperty(resultHandle, itemIndex, propertyName, out valueBuffer, ref bufferSize);
			}

			public static bool GetResultItems(SteamInventoryResult_t resultHandle, SteamItemDetails_t[] items, ref uint count)
			{
				return SteamInventory.GetResultItems(resultHandle, items, ref count);
			}

			public static DateTime GetResultTimestamp(SteamInventoryResult_t resultHandle)
			{
				return new DateTime(1970, 1, 1).AddSeconds(SteamInventory.GetResultTimestamp(resultHandle));
			}

			public static bool GrantPromoItems(Action<InventoryResult> callback = null)
			{
				if (callback == null)
				{
					return false;
				}
				if (m_SteamInventoryResultReady_t == null)
				{
					m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
				}
				if (SteamInventory.GrantPromoItems(out var pResultHandle))
				{
					if (callback != null)
					{
						resultHandles.Add(pResultHandle, callback);
					}
					return true;
				}
				return false;
			}

			public static bool LoadItemDefinitions()
			{
				return SteamInventory.LoadItemDefinitions();
			}

			public static void RequestPrices(Action<SteamInventoryRequestPricesResult_t, bool> callback)
			{
				if (m_SteamInventoryRequestPricesResult_t == null)
				{
					m_SteamInventoryRequestPricesResult_t = CallResult<SteamInventoryRequestPricesResult_t>.Create();
				}
				SteamAPICall_t hAPICall = SteamInventory.RequestPrices();
				m_SteamInventoryRequestPricesResult_t.Set(hAPICall, delegate(SteamInventoryRequestPricesResult_t response, bool ioError)
				{
					if (ioError || response.m_result != EResult.k_EResultOK)
					{
						LocalCurrencyCode = Currency.Code.Unknown;
						Debug.LogWarning("Failed to fetch current prices for the list of available inventory items.\nSteam Response: " + response.m_result);
					}
					else
					{
						LocalCurrencyCode = (Currency.Code)Enum.Parse(typeof(Currency.Code), response.m_rgchCurrency.ToUpper());
					}
					callback?.Invoke(response, ioError);
				});
			}

			public static void SerializeItemResultsByID(SteamItemInstanceID_t[] instanceIds, Action<byte[]> callback)
			{
				if (callback != null)
				{
					if (m_SteamInventoryResultReady_t == null)
					{
						m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
					}
					SteamInventory.GetItemsByID(out var pResultHandle, instanceIds, (uint)instanceIds.Length);
					serializationResults.Add(pResultHandle, callback);
				}
			}

			public static void SerializeAllItemResults(Action<byte[]> callback)
			{
				if (callback != null)
				{
					if (m_SteamInventoryResultReady_t == null)
					{
						m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
					}
					SteamInventory.GetAllItems(out var pResultHandle);
					serializationResults.Add(pResultHandle, callback);
				}
			}

			public static void StartPurchase(SteamItemDef_t[] items, uint[] quantities, Action<SteamInventoryStartPurchaseResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_SteamInventoryStartPurchaseResult_t == null)
					{
						m_SteamInventoryStartPurchaseResult_t = CallResult<SteamInventoryStartPurchaseResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamInventory.StartPurchase(items, quantities, (uint)items.Length);
					m_SteamInventoryStartPurchaseResult_t.Set(hAPICall, callback.Invoke);
				}
			}

			public static void TransferItemQuantity(SteamItemInstanceID_t source, uint quantity, SteamItemInstanceID_t destination, Action<InventoryResult> callback)
			{
				if (callback != null)
				{
					if (m_SteamInventoryResultReady_t == null)
					{
						m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
					}
					SteamInventory.TransferItemQuantity(out var pResultHandle, source, quantity, destination);
					resultHandles.Add(pResultHandle, callback);
				}
			}

			public static void TriggerItemDrop(SteamItemDef_t item, Action<InventoryResult> callback)
			{
				if (callback != null)
				{
					if (m_SteamInventoryResultReady_t == null)
					{
						m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
					}
					SteamInventory.TriggerItemDrop(out var pResultHandle, item);
					resultHandles.Add(pResultHandle, callback);
				}
			}

			public static SteamInventoryUpdateHandle_t StartUpdateProperties()
			{
				return SteamInventory.StartUpdateProperties();
			}

			public static void SubmitUpdateProperties(SteamInventoryUpdateHandle_t handle, Action<InventoryResult> callback)
			{
				if (callback != null)
				{
					if (m_SteamInventoryResultReady_t == null)
					{
						m_SteamInventoryResultReady_t = Callback<SteamInventoryResultReady_t>.Create(HandleInventoryResults);
					}
					SteamInventory.SubmitUpdateProperties(handle, out var pResultHandle);
					resultHandles.Add(pResultHandle, callback);
				}
			}

			public static void RemoveProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t item, string propertyName)
			{
				SteamInventory.RemoveProperty(handle, item, propertyName);
			}

			public static void SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t item, string propertyName, string data)
			{
				SteamInventory.SetProperty(handle, item, propertyName, data);
			}

			public static void SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t item, string propertyName, bool data)
			{
				SteamInventory.SetProperty(handle, item, propertyName, data);
			}

			public static void SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t item, string propertyName, long data)
			{
				SteamInventory.SetProperty(handle, item, propertyName, data);
			}

			public static void SetProperty(SteamInventoryUpdateHandle_t handle, SteamItemInstanceID_t item, string propertyName, float data)
			{
				SteamInventory.SetProperty(handle, item, propertyName, data);
			}

			private static ItemDetail GetExtendedItemDetail(SteamInventoryResult_t result, uint index, SteamItemDetails_t detail)
			{
				uint punValueBufferSizeOut = 0u;
				SteamInventory.GetResultItemProperty(result, index, null, out var pchValueBuffer, ref punValueBufferSizeOut);
				SteamInventory.GetResultItemProperty(result, index, null, out pchValueBuffer, ref punValueBufferSizeOut);
				string[] array = pchValueBuffer.Split(',');
				List<ItemProperty> list = new List<ItemProperty>();
				ItemTag[] array2 = new ItemTag[0];
				string dynamicProperties = string.Empty;
				if (array.Length != 0)
				{
					for (int i = 0; i < array.Length; i++)
					{
						punValueBufferSizeOut = 0u;
						SteamInventory.GetResultItemProperty(result, index, array[i], out var _, ref punValueBufferSizeOut);
						SteamInventory.GetResultItemProperty(result, index, array[i], out pchValueBuffer, ref punValueBufferSizeOut);
						if (array[i] == "tags")
						{
							string[] array3 = pchValueBuffer.Split(';');
							array2 = new ItemTag[array3.Length];
							for (int j = 0; j < array3.Length; j++)
							{
								if (array3[j].Contains(":"))
								{
									string[] array4 = array3[j].Split(':');
									if (array4.Length >= 2)
									{
										array2[j] = new ItemTag
										{
											category = array4[0],
											tag = array4[1]
										};
									}
									else
									{
										array2[j] = new ItemTag
										{
											category = array4[0]
										};
									}
								}
								else
								{
									array2[j] = new ItemTag
									{
										category = array3[index]
									};
								}
							}
						}
						else if (array[i] == "dynamic_props")
						{
							dynamicProperties = pchValueBuffer;
						}
						else
						{
							list.Add(new ItemProperty
							{
								key = array[i],
								value = pchValueBuffer
							});
						}
					}
				}
				ItemDetail nDet = new ItemDetail
				{
					itemDetails = detail,
					properties = list.ToArray(),
					dynamicProperties = dynamicProperties,
					tags = array2
				};
				ItemData definition = nDet.Definition;
				if (itemIndex.ContainsKey(definition))
				{
					List<ItemDetail> list2 = itemIndex[definition];
					list2.RemoveAll((ItemDetail p) => p.ItemId == nDet.ItemId);
					list2.Add(nDet);
					itemIndex[definition] = list2;
				}
				else
				{
					itemIndex.Add(definition, new List<ItemDetail> { nDet });
				}
				return nDet;
			}

			private static void HandleInventoryResults(SteamInventoryResultReady_t results)
			{
				if (serializationResults.ContainsKey(results.m_handle))
				{
					SteamInventory.SerializeResult(results.m_handle, null, out var punOutBufferSize);
					byte[] array = new byte[punOutBufferSize];
					SteamInventory.SerializeResult(results.m_handle, array, out punOutBufferSize);
					serializationResults[results.m_handle]?.Invoke(array);
					serializationResults.Remove(results.m_handle);
					SteamInventory.DestroyResult(results.m_handle);
					return;
				}
				uint punOutItemsArraySize = 0u;
				InventoryResult inventoryResult = new InventoryResult
				{
					items = new ItemDetail[0],
					result = results.m_result,
					timestamp = new DateTime(1970, 1, 1).AddSeconds(SteamInventory.GetResultTimestamp(results.m_handle))
				};
				SteamInventory.GetResultItems(results.m_handle, null, ref punOutItemsArraySize);
				if (punOutItemsArraySize != 0)
				{
					SteamItemDetails_t[] array2 = new SteamItemDetails_t[punOutItemsArraySize];
					ItemDetail[] array3 = new ItemDetail[punOutItemsArraySize];
					SteamInventory.GetResultItems(results.m_handle, array2, ref punOutItemsArraySize);
					for (uint num = 0u; num < punOutItemsArraySize; num++)
					{
						array3[num] = GetExtendedItemDetail(results.m_handle, num, array2[num]);
					}
					inventoryResult = new InventoryResult
					{
						items = array3,
						result = results.m_result,
						timestamp = new DateTime(1970, 1, 1).AddSeconds(SteamInventory.GetResultTimestamp(results.m_handle))
					};
				}
				if (deserializationResults.ContainsKey(results.m_handle))
				{
					SerializationPointer serializationPointer = deserializationResults[results.m_handle];
					if (!SteamInventory.CheckResultSteamID(results.m_handle, serializationPointer.expectedUser))
					{
						inventoryResult.result = EResult.k_EResultFail;
					}
					serializationPointer.callback?.Invoke(inventoryResult);
					deserializationResults.Remove(results.m_handle);
				}
				else
				{
					EventSteamInventoryResultReady?.Invoke(inventoryResult);
					if (resultHandles.ContainsKey(results.m_handle))
					{
						resultHandles[results.m_handle]?.Invoke(inventoryResult);
						resultHandles.Remove(results.m_handle);
					}
				}
				SteamInventory.DestroyResult(results.m_handle);
			}
		}
	}
}
