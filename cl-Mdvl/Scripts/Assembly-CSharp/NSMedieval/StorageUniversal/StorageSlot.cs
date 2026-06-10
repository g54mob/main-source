using System;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.StorageUniversal
{
	[Serializable]
	[FVSerializableKey("StorageSlot", "")]
	public class StorageSlot : IFVSerializable
	{
		private StockpileReservationInfo reservationInfo;

		[SerializeField]
		private ResourcePileInstance pile;

		[SerializeField]
		private bool hasVisuals = true;

		public StockpileReservationInfo ReservationInfo => reservationInfo;

		public ResourcePileInstance Pile => pile;

		public bool HasVisuals => hasVisuals;

		public event Action<StorageSlot, int> PileTakenEvent;

		public event Action<StorageSlot> PileHealthDepletedEvent;

		public StorageSlot()
		{
		}

		public void SetHasVisuals(bool hasVisuals)
		{
			this.hasVisuals = hasVisuals;
		}

		public bool HasReservation()
		{
			return reservationInfo.Agent != null;
		}

		public float GetFillPercentage()
		{
			if (pile == null)
			{
				return 0f;
			}
			ResourceInstance storedResource = pile.GetStoredResource();
			if (storedResource == null || storedResource.Amount == 0)
			{
				return 0f;
			}
			return (float)storedResource.Amount / (float)storedResource.StackingLimit * 100f;
		}

		public void SetupAfterLoading()
		{
			if (pile == null)
			{
				return;
			}
			if (pile.Blueprint == null || pile.GetStoredResource() == null)
			{
				MonoSingleton<ResourcePileManager>.Instance.ForceDisposePile(pile);
				pile = null;
				return;
			}
			pile.OnResourceTakenEvent += OnPileTaken;
			pile.OnDisposedEvent += delegate
			{
				OnDurabilityDepleted();
			};
			pile.SetDurabilityDepletedCallback(OnDurabilityDepleted);
		}

		public void ClearReservations()
		{
			reservationInfo = default(StockpileReservationInfo);
		}

		public void Reserve(StockpileReservationInfo info)
		{
			if (pile != null && pile.Blueprint != null && pile.Blueprint != info.Blueprint)
			{
				Log.Error("info.Blueprint != this.currentResources[index].Blueprint this should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\UniversalStorage\\StorageSlot.cs");
			}
			else
			{
				reservationInfo = info;
			}
		}

		public void SetStoredPile(ResourcePileInstance pile)
		{
			if (pile?.GetStoredResource() == null)
			{
				this.pile = null;
				return;
			}
			this.pile = pile;
			this.PileTakenEvent = null;
			this.pile.OnDisposedEvent += delegate
			{
				OnDurabilityDepleted();
			};
			this.pile.OnResourceTakenEvent += OnPileTaken;
			this.pile.SetDurabilityDepletedCallback(OnDurabilityDepleted);
			VillageManager.ActiveVillage.Map.AddToTheWorld(pile);
		}

		private void OnPileTaken(ResourcePileInstance pile, Resource blueprint, int amountTaken)
		{
			if (this.pile?.GetStoredResource() == null)
			{
				this.pile = null;
				this.PileTakenEvent?.Invoke(this, 0);
				return;
			}
			int amount = this.pile.GetStoredResource().Amount;
			if (amount == 0)
			{
				VillageManager.ActiveVillage.Map.RemoveFromWorld(pile);
				this.pile = null;
			}
			this.PileTakenEvent?.Invoke(this, amount);
		}

		private void OnDurabilityDepleted()
		{
			pile = null;
			this.PileHealthDepletedEvent?.Invoke(this);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("pile", pile);
			serializer.Write("hasVisuals", hasVisuals);
		}

		public StorageSlot(FVDeserializer deserializer)
		{
			pile = deserializer.ReadObject<ResourcePileInstance>("pile");
			hasVisuals = deserializer.ReadBool("hasVisuals");
		}
	}
}
