using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval
{
	public class NPCController : MonoSingleton<NPCController>
	{
		public delegate void NPCHandler(HumanoidInstance humanoid);

		public event NPCHandler OnNPCSpawnedEvent;

		public event NPCHandler OnNPCRemovedEvent;

		public event NPCHandler OnNPCDiedEvent;

		public event WorkerController.HumanoidStringTriggerHandler ShowToolEvent;

		public event WorkerController.HumanoidTriggerHandler HideToolEvent;

		public event NPCHandler OnNPCBecomeAggressive;

		public event NPCHandler OnNPCChanged;

		public event NPCHandler LeavingMapEvent;

		public event Action<TradingPostComponentInstance, TraderBehaviour> OnShowGoodsOnTradingPost;

		public event Action<CaptiveNpcBehaviour, bool> OnMarkedForRecruitmentEvent;

		public event Action<CaptiveNpcBehaviour> OnOwnerSetEvent;

		public event Action<CaptiveNpcBehaviour> PrisonerReleasedEvent;

		public event Action<IReadOnlyCollection<HumanoidInstance>> CapturedPrisonersEvent;

		protected override void OnDestroy()
		{
			this.ShowToolEvent = null;
			this.HideToolEvent = null;
			this.OnNPCSpawnedEvent = null;
			this.OnNPCRemovedEvent = null;
			this.OnNPCDiedEvent = null;
			this.OnNPCBecomeAggressive = null;
			this.OnNPCChanged = null;
			this.LeavingMapEvent = null;
			this.OnShowGoodsOnTradingPost = null;
			this.OnMarkedForRecruitmentEvent = null;
			this.CapturedPrisonersEvent = null;
			this.OnOwnerSetEvent = null;
			this.PrisonerReleasedEvent = null;
			base.OnDestroy();
		}

		public void RemoveNPC(HumanoidInstance instance)
		{
			this.OnNPCRemovedEvent?.Invoke(instance);
			this.OnNPCChanged?.Invoke(instance);
		}

		public void OnNPCSpawned(HumanoidInstance instance)
		{
			this.OnNPCSpawnedEvent?.Invoke(instance);
			this.OnNPCChanged?.Invoke(instance);
		}

		public void FireOnNpcChanged(HumanoidInstance instance)
		{
			this.OnNPCChanged?.Invoke(instance);
		}

		public void OnNPCDied(HumanoidInstance instance)
		{
			this.OnNPCDiedEvent?.Invoke(instance);
		}

		public void ShowTool(HumanoidInstance humanoid, string toolID, Transform socket)
		{
			this.ShowToolEvent?.Invoke(humanoid, toolID, socket);
		}

		public void HideTool(HumanoidInstance humanoid)
		{
			this.HideToolEvent?.Invoke(humanoid);
		}

		public void NPCBecomeAggressive(HumanoidInstance humanoidInstance)
		{
			this.OnNPCBecomeAggressive?.Invoke(humanoidInstance);
		}

		public void DropItem(EquipmentInstance item, InventoryInstance inventory)
		{
			HumanoidInstance humanoidInstance = GlobalSaveController.CurrentVillageData?.NPCs.Find((HumanoidInstance npc) => npc.Inventory.Equals(inventory));
			if (humanoidInstance != null)
			{
				MonoSingleton<NPCManager>.Instance.GetView(humanoidInstance).DropItem(item);
			}
		}

		public void EquipItem(EquipmentInstance item, InventoryInstance inventory)
		{
			HumanoidInstance humanoidInstance = GlobalSaveController.CurrentVillageData?.NPCs.Find((HumanoidInstance npc) => npc.Inventory.Equals(inventory));
			if (humanoidInstance != null)
			{
				MonoSingleton<NPCManager>.Instance.GetView(humanoidInstance).EquipItem(item);
			}
		}

		public void OnLeaveMapEvent(HumanoidInstance humanoid)
		{
			this.LeavingMapEvent?.Invoke(humanoid);
		}

		public void ShowGoodsOnTradingPost(TradingPostComponentInstance tradingPost, TraderBehaviour traderBehaviour)
		{
			this.OnShowGoodsOnTradingPost?.Invoke(tradingPost, traderBehaviour);
		}

		public void OnOwnerSet(CaptiveNpcBehaviour prisonerBehaviour)
		{
			this.OnOwnerSetEvent?.Invoke(prisonerBehaviour);
		}

		public void OnMarkedForRecruitment(CaptiveNpcBehaviour captiveNpcBehaviour, bool markForRecruitment)
		{
			this.OnMarkedForRecruitmentEvent?.Invoke(captiveNpcBehaviour, markForRecruitment);
		}

		public void PrisonerReleased(CaptiveNpcBehaviour captiveNpcBehaviour)
		{
			this.PrisonerReleasedEvent?.Invoke(captiveNpcBehaviour);
		}

		public void CapturedPrisoners(IReadOnlyCollection<HumanoidInstance> cpaturedPrisoners)
		{
			this.CapturedPrisonersEvent?.Invoke(cpaturedPrisoners);
		}
	}
}
