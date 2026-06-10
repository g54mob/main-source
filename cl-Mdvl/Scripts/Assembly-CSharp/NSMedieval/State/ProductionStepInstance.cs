using System;
using Models.Production;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("ProductionStepInstance", "")]
	public abstract class ProductionStepInstance : IGameDisposable, IDisposable, IFVSerializable
	{
		[SerializeField]
		private ProductionStepType type;

		[SerializeField]
		private bool isCompleted;

		[NonSerialized]
		private bool isActive;

		private ProductionInstance ownerProductionInstance;

		private ProductionStep blueprint;

		public bool HasDisposed { get; private set; }

		public ProductionStepType Type => type;

		public ProductionInstance OwnerProductionInstance => ownerProductionInstance;

		public ProductionStep Blueprint => blueprint;

		public bool IsCompleted => isCompleted;

		public bool IsActive => isActive;

		public virtual float Progress => 0f;

		public event Action<IGameDisposable> OnDisposedEvent;

		public event Action<ProductionStepInstance> OnCompletedEvent;

		public ProductionStepInstance(ProductionStepType type)
		{
			this.type = type;
		}

		public ProductionStepInstance()
		{
		}

		public virtual void Dispose()
		{
			if (!HasDisposed)
			{
				this.OnCompletedEvent = null;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				this.OnDisposedEvent = null;
				HasDisposed = true;
			}
		}

		internal virtual void Initialize(ProductionInstance owner, ProductionStep blueprint)
		{
			ownerProductionInstance = owner;
			this.blueprint = blueprint;
		}

		internal virtual void OnStart()
		{
		}

		internal virtual void OnEnd()
		{
		}

		internal virtual void OnBecomeActive()
		{
			isActive = true;
			ProductionComponent productionComponent = GetProductionComponent();
			if (productionComponent != null)
			{
				productionComponent.UpdateProductionCircle();
			}
		}

		internal virtual void OnBecomeInactive()
		{
			isActive = false;
			ProductionComponent productionComponent = GetProductionComponent();
			if (productionComponent != null)
			{
				productionComponent.UpdateProductionCircle();
			}
		}

		internal virtual void Reset()
		{
			isCompleted = false;
			ProductionComponent productionComponent = GetProductionComponent();
			if (productionComponent != null)
			{
				productionComponent.UpdateProductionCircle();
			}
		}

		protected virtual void Complete()
		{
			if (!isCompleted)
			{
				isCompleted = true;
				this.OnCompletedEvent?.Invoke(this);
			}
		}

		protected ProductionComponent GetProductionComponent()
		{
			return (OwnerProductionInstance?.OwnerProductionComponentInstance?.Map?.ProductionComponentBuildingManager)?.GetComponent(OwnerProductionInstance.OwnerProductionComponentInstance);
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}: {3}, {4}: {5}, {6}: {7}", "Type", Type, "IsCompleted", IsCompleted, "IsActive", IsActive, "Progress", Progress);
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			serializer.WriteEnum("type", type);
			serializer.Write("isCompleted", isCompleted);
		}

		public ProductionStepInstance(FVDeserializer deserializer)
		{
			type = deserializer.ReadEnum("type", ProductionStepType.None);
			isCompleted = deserializer.ReadBool("isCompleted");
		}
	}
}
