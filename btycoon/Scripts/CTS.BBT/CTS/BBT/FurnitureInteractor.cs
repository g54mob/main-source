using System;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT
{
	public abstract class FurnitureInteractor : CTSBehaviour, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		private static readonly NamedLayerMask ItemLayer = new NamedLayerMask("Item");

		private static readonly float SearchRadius = 0.075f;

		[field: Inject(false)]
		public Furniture Furniture { get; }

		[field: Inject(false)]
		public PathLockable PathStatus { get; }

		[field: Inject(false)]
		public FurnitureSyncer Syncing { get; }

		public bool IsVisible => Furniture.Controller.IsPlaced;

		public Action WasSeen { get; set; }

		public Transform Transform => base.transform;

		public RoomObject RoomObject => Furniture.RoomObject;

		public bool InUse { get; private set; }

		public Agent User { get; private set; }

		public bool Pathable
		{
			get
			{
				if (!(PathStatus == null))
				{
					return !PathStatus.Locked;
				}
				return true;
			}
		}

		public event Action FurnitureBecameUnavailable;

		private void Subscribe()
		{
			Unsubscribe();
			Furniture.Controller.FurniturePlaced += PlaceFurniture;
			Furniture.OnFurnitureSold += OnFurnitureSold;
		}

		private void Unsubscribe()
		{
			Furniture.Controller.FurniturePlaced -= PlaceFurniture;
			Furniture.OnFurnitureSold -= OnFurnitureSold;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Subscribe();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			Unsubscribe();
		}

		private void OnDestroy()
		{
			TriggerFurnitureBecameUnavailable();
			OnFurnitureDestroyed();
		}

		private void PlaceFurniture(bool buyIt)
		{
			OnFurniturePlaced();
		}

		public virtual void OnFurniturePlaced()
		{
		}

		public virtual void OnFurnitureSold()
		{
		}

		public virtual void OnFurnitureDestroyed()
		{
		}

		protected virtual void OnFurnitureBecameUnavailable()
		{
		}

		internal void TriggerFurnitureBecameUnavailable()
		{
			this.FurnitureBecameUnavailable?.Invoke();
			OnFurnitureBecameUnavailable();
		}

		internal void TriggerFurniturePickedUp()
		{
			this.FurnitureBecameUnavailable?.Invoke();
			OnFurniturePickedUp();
		}

		protected virtual void OnFurniturePickedUp()
		{
			if (InUse)
			{
				if (TryGetComponent<IContextActor>(out var component))
				{
					component.ContextActorData.ClearAssociatedChores();
				}
				StopUsing();
			}
		}

		public virtual bool CanBeUsed()
		{
			if (!Pathable)
			{
				return false;
			}
			if (!InUse)
			{
				return Furniture.Controller.IsPlaced;
			}
			return false;
		}

		public virtual bool CanBeUsed(Agent agent)
		{
			if (!Pathable)
			{
				return false;
			}
			if (!InUse || User == agent)
			{
				return Furniture.Controller.IsPlaced;
			}
			return false;
		}

		public void StartUsing(Agent p_agent)
		{
			if (!InUse)
			{
				User = p_agent;
				InUse = true;
			}
		}

		public void StopUsing()
		{
			if (InUse)
			{
				User = null;
				InUse = false;
			}
		}
	}
}
