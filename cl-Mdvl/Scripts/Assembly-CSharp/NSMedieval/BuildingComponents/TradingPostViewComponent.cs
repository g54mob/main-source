using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Construction;
using NSMedieval.GameEventSystem;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Heraldry;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(TradingPostComponent))]
	public class TradingPostViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private TradingPostComponent tradingPostComponent;

		[NonSerialized]
		private List<GameObject> slotParents;

		[NonSerialized]
		private Dictionary<TraderBehaviour, int> tradersUsing;

		[NonSerialized]
		private Dictionary<string, Transform>[] slotByResourceId;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			tradingPostComponent = GetComponent<TradingPostComponent>();
			if (tradersUsing == null)
			{
				tradersUsing = new Dictionary<TraderBehaviour, int>();
			}
			else
			{
				tradersUsing.Clear();
			}
		}

		protected override void OnComponentEnterFoundationState()
		{
			base.OnComponentEnterFoundationState();
			if (BaseBuildingViewComponent.BaseBuildingInstance.FactionOwnership == FactionOwnership.Enemy)
			{
				MonoSingleton<HeraldryManager>.Instance.TrySetHeraldry(BaseBuildingViewComponent.FinishedMeshRenderers, GlobalSaveController.CurrentVillageData.WorldMapPlace.FactionInstance);
			}
			else
			{
				MonoSingleton<HeraldryManager>.Instance.TrySetPlayerHeraldry(BaseBuildingViewComponent.FinishedMeshRenderers);
			}
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnShowGoodsOnTradingPost -= ShowGoodsOnTradingPost;
				MonoSingleton<NPCController>.Instance.OnNPCDiedEvent -= OnNpcDied;
			}
			if (MonoSingleton<GameEventSystemController>.IsInstantiated())
			{
				MonoSingleton<GameEventSystemController>.Instance.GameEventEnded -= OnEventEnded;
			}
			if (MonoSingleton<TradingManager>.IsInstantiated())
			{
				MonoSingleton<TradingManager>.Instance.TradeAppliedEvent -= OnTradeApplied;
			}
			if (MonoSingleton<FactionsController>.IsInstantiated())
			{
				MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent -= OnFriendlinessChanged;
			}
			foreach (GameObject slotParent in slotParents)
			{
				RemoveAllChildren(slotParent.transform);
			}
			if (tradersUsing != null)
			{
				foreach (TraderBehaviour key in tradersUsing.Keys)
				{
					key.TradingPostComponentInstance = null;
					key.TradingPostReservedPositionIndex = -1;
					key.TradingPostBuildingInstance = null;
					key.TradingPostReservedPosition = Vec3Int.zero;
				}
				tradersUsing.Clear();
				tradersUsing = null;
			}
			base.OnBuildingDisposed(disposable);
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			MonoSingleton<NPCController>.Instance.OnShowGoodsOnTradingPost += ShowGoodsOnTradingPost;
			MonoSingleton<NPCController>.Instance.OnNPCDiedEvent += OnNpcDied;
			MonoSingleton<GameEventSystemController>.Instance.GameEventEnded += OnEventEnded;
			MonoSingleton<TradingManager>.Instance.TradeAppliedEvent += OnTradeApplied;
			MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent += OnFriendlinessChanged;
			if (slotParents == null)
			{
				int maxTraders = tradingPostComponent.ComponentInstance.Blueprint.MaxTraders;
				slotParents = new List<GameObject>();
				slotByResourceId = new Dictionary<string, Transform>[maxTraders];
				for (int i = 0; i < maxTraders; i++)
				{
					GameObject obj = new GameObject($"TraderGoodsParent{i}");
					obj.transform.parent = base.transform;
					obj.transform.localPosition = Vector3.zero;
					obj.transform.localRotation = Quaternion.identity;
					GameObject item = obj;
					slotParents.Add(item);
					slotByResourceId[i] = new Dictionary<string, Transform>();
				}
			}
		}

		private static void RemoveAllChildren(Transform slot)
		{
			for (int num = slot.childCount - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(slot.GetChild(num).gameObject);
			}
		}

		private void OnNpcDied(HumanoidInstance humanoid)
		{
			if (humanoid.IsTrader() && tradersUsing.ContainsKey(humanoid.TraderBehaviour))
			{
				ClearGoods(humanoid.TraderBehaviour);
				tradersUsing.Remove(humanoid.TraderBehaviour);
			}
		}

		private void OnEventEnded(GameEventInstance eventInstance)
		{
			if (eventInstance is TraderEvent traderEvent && traderEvent.Trader?.TraderBehaviour != null && tradersUsing.ContainsKey(traderEvent.Trader.TraderBehaviour))
			{
				ClearGoods(traderEvent.Trader.TraderBehaviour);
				tradersUsing.Remove(traderEvent.Trader.TraderBehaviour);
			}
			if (!(eventInstance is MultiTraderEvent multiTraderEvent))
			{
				return;
			}
			using PooledList<TraderBehaviour> pooledList = ListPool<TraderBehaviour>.GetJanitor();
			foreach (TraderBehaviour key in tradersUsing.Keys)
			{
				if (key?.Humanoid != null && multiTraderEvent.Traders.Contains(key.Humanoid))
				{
					pooledList.Add(key);
				}
			}
			foreach (TraderBehaviour item in pooledList)
			{
				ClearGoods(item);
				tradersUsing.Remove(item);
			}
		}

		private void ShowGoodsOnTradingPost(TradingPostComponentInstance tradingPost, TraderBehaviour traderBehaviour)
		{
			if (traderBehaviour.TradingPostBuildingInstance == base.BaseBuildingInstance)
			{
				RefreshGoods(traderBehaviour);
			}
		}

		private void ClearGoods(TraderBehaviour traderBehaviour)
		{
			if (traderBehaviour.TradingPostComponentInstance == tradingPostComponent.ComponentInstance)
			{
				int tradingPostReservedPositionIndex = traderBehaviour.TradingPostReservedPositionIndex;
				if (tradingPostReservedPositionIndex != -1)
				{
					RemoveAllChildren(slotParents[tradingPostReservedPositionIndex].transform);
				}
			}
		}

		private ResourceInstance GetFirstFreeResource(TraderBehaviour traderBehaviour)
		{
			int tradingPostReservedPositionIndex = traderBehaviour.TradingPostReservedPositionIndex;
			foreach (ResourceInstance resource in traderBehaviour.Storage.Resources)
			{
				if (resource != null && resource.Amount != 0 && !slotByResourceId[tradingPostReservedPositionIndex].ContainsKey(resource.BlueprintId))
				{
					return resource;
				}
			}
			return null;
		}

		private ResourcePileView GenerateResourceView(ResourceInstance resourceInstance)
		{
			ResourcePileView resourcePileView = ResourcePileFactory.ProduceView(resourceInstance);
			if (resourcePileView == null)
			{
				return null;
			}
			ShelfFillView.RemoveExcessComponents(resourcePileView.gameObject, resetEulerAngles: false);
			resourcePileView.transform.localPosition = Vector3.zero;
			HideResource hideResource = resourcePileView.GetComponent<HideResource>();
			if (hideResource != null)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					if (!(hideResource == null))
					{
						hideResource.SetElevationOnShelf(base.BaseBuildingInstance.GridDataPosition.y);
						hideResource.TryForceHide(MonoSingleton<World>.Instance.LayerLevel);
					}
				});
			}
			return resourcePileView;
		}

		private void RefreshGoods(TraderBehaviour traderBehaviour)
		{
			if (traderBehaviour.TradingPostComponentInstance != tradingPostComponent.ComponentInstance || slotByResourceId == null || traderBehaviour?.Storage.Resources == null)
			{
				return;
			}
			int tradingPostReservedPositionIndex = traderBehaviour.TradingPostReservedPositionIndex;
			if (tradingPostReservedPositionIndex == -1 || slotByResourceId.Length <= tradingPostReservedPositionIndex || !tradingPostComponent.ComponentInstance.WorkplacePositions.Contains(traderBehaviour.GetGridPosition()) || !tradersUsing.TryAdd(traderBehaviour, traderBehaviour.TradingPostReservedPositionIndex))
			{
				return;
			}
			string[] array = slotByResourceId[tradingPostReservedPositionIndex].Keys.ToArray();
			foreach (string text in array)
			{
				if (!traderBehaviour.Storage.Contains(text) && slotByResourceId[tradingPostReservedPositionIndex].TryGetValue(text, out var value) && value != null)
				{
					slotByResourceId[tradingPostReservedPositionIndex].Remove(text);
					RemoveAllChildren(value);
				}
			}
			TraderSlot traderSlot = tradingPostComponent.ComponentInstance.Blueprint.Slots[tradingPostReservedPositionIndex];
			for (int j = 0; j < traderSlot.VisualAssetSlots.Length; j++)
			{
				ResourceInstance firstFreeResource = GetFirstFreeResource(traderBehaviour);
				if (firstFreeResource == null)
				{
					continue;
				}
				ResourcePileView resourcePileView = GenerateResourceView(firstFreeResource);
				if (resourcePileView == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(49, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\TradingPost\\TradingPostViewComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("TradingPostView: cannot create view for resource ");
						messageBuilder.AppendFormatted(firstFreeResource.BlueprintId);
					}
					Log.Error(messageBuilder);
					break;
				}
				GameObject gameObject = slotParents[tradingPostReservedPositionIndex];
				resourcePileView.transform.SetParent(gameObject.transform, worldPositionStays: false);
				resourcePileView.transform.localPosition = traderSlot.VisualAssetSlots[j];
				resourcePileView.transform.localScale = Vector3.one * 0.8f;
				if (!slotByResourceId[tradingPostReservedPositionIndex].TryAdd(firstFreeResource.BlueprintId, gameObject.transform))
				{
					slotByResourceId[tradingPostReservedPositionIndex][firstFreeResource.BlueprintId] = gameObject.transform;
				}
			}
		}

		private void OnTradeApplied(ITrader playerTrader, ITrader otherTrader, float totalValueTraded, bool wasGiftingOnly)
		{
			if (otherTrader is TraderBehaviour traderBehaviour && tradersUsing.ContainsKey(traderBehaviour))
			{
				RefreshGoods(traderBehaviour);
			}
		}

		private void OnFriendlinessChanged(FactionFriendliness newFriendliness, FactionInstance faction)
		{
			if (tradersUsing.Count == 0 && !tradersUsing.AnyNonAlloc((KeyValuePair<TraderBehaviour, int> item) => item.Key.Faction == faction))
			{
				return;
			}
			using PooledList<TraderBehaviour> pooledList = tradersUsing.Keys.ToPooledListJanitor();
			foreach (TraderBehaviour item in pooledList)
			{
				if (item.Faction == faction)
				{
					ClearGoods(item);
					tradersUsing.Remove(item);
				}
			}
		}
	}
}
