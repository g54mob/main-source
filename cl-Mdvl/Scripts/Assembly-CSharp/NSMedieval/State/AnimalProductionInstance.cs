using System;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State.Timers;
using NSMedieval.Types;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("AnimalProductionInstance", "")]
	public class AnimalProductionInstance : IGameDisposable, IDisposable, IFVSerializable
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private bool readyForHarvest;

		[SerializeField]
		private Timer productionTimer;

		[NonSerialized]
		private AnimalProduction blueprint;

		[NonSerialized]
		private AnimalInstance owner;

		public bool HasDisposed { get; private set; }

		public AnimalProduction Blueprint
		{
			get
			{
				if (blueprint == null)
				{
					blueprint = Repository<AnimalProductionRepository, AnimalProduction>.Instance.GetByID(id);
				}
				return blueprint;
			}
		}

		public bool ReadyForHarvest => readyForHarvest;

		public event Action<IGameDisposable> OnDisposedEvent;

		public AnimalProductionInstance(string id, AnimalInstance owner)
		{
			this.id = id;
			blueprint = Repository<AnimalProductionRepository, AnimalProduction>.Instance.GetByID(this.id);
			this.owner = owner;
			productionTimer = new Timer(blueprint.ProductionDuration);
			productionTimer.AddCallback(OnProductionCompleted);
		}

		public void ForceCompleteProduction()
		{
			productionTimer.ForceComplete();
		}

		public void Dispose()
		{
			if (!HasDisposed)
			{
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				HasDisposed = true;
				productionTimer.Dispose();
				productionTimer = null;
				this.OnDisposedEvent = null;
				owner = null;
			}
		}

		public void ReInstantiate(AnimalInstance owner)
		{
			this.owner = owner;
			blueprint = Repository<AnimalProductionRepository, AnimalProduction>.Instance.GetByID(id);
			productionTimer.AddCallback(OnProductionCompleted);
			if (!readyForHarvest)
			{
				productionTimer.ResumeAddToTimerController();
			}
			else if (this.owner.AnimalType == AnimalType.Domestic || this.owner.AnimalType == AnimalType.Pet)
			{
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, this.owner);
			}
		}

		public ResourcePileInstance HarvestCompleted(int amountToSpawn)
		{
			readyForHarvest = false;
			if (HasDisposed)
			{
				return null;
			}
			ResourcePileView resourcePileView = MonoSingleton<ResourcePileManager>.Instance.SpawnPileAnimalHarvest(new ResourceInstance(blueprint.Resource, amountToSpawn), owner.GetPosition(), owner);
			productionTimer?.RestartTimer();
			if (!(resourcePileView == null))
			{
				return resourcePileView.ResourcePileInstance;
			}
			return null;
		}

		public void CancelProduction()
		{
			readyForHarvest = false;
			productionTimer.Dispose();
			productionTimer = null;
		}

		public int GetCompletionPercentage()
		{
			return productionTimer?.GetCompletionPercentage() ?? 0;
		}

		private void OnProductionCompleted()
		{
			if (blueprint.AutoSpawn)
			{
				AutoSpawnResources();
				return;
			}
			readyForHarvest = true;
			if (owner.AnimalType == AnimalType.Domestic || owner.AnimalType == AnimalType.Pet)
			{
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, owner);
			}
		}

		private void AutoSpawnResources()
		{
			MonoSingleton<ResourcePileManager>.Instance.SpawnPile(new ResourceInstance(blueprint.Resource, blueprint.AmountToSpawn), owner.GetPosition(), owner.AnimalType == AnimalType.Wild);
			productionTimer.RestartTimer();
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("readyForHarvest", readyForHarvest);
			serializer.Write("productionTimer", productionTimer);
		}

		public AnimalProductionInstance(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			readyForHarvest = deserializer.ReadBool("readyForHarvest");
			productionTimer = deserializer.ReadObject<Timer>("productionTimer");
		}
	}
}
