using System;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT
{
	public class Seat : FurnitureInteractor, IContextActor
	{
		private static NamedLayerMask slotLayer = new NamedLayerMask("ItemSlot");

		private static NamedLayerMask tableLayer = new NamedLayerMask("Furniture");

		private Table _currentTable;

		[field: SerializeField]
		public ContextActorData ContextActorData { get; private set; } = new ContextActorData();

		public ItemSlot ItemSlot { get; private set; }

		public bool IsLow => base.Furniture.Parameters.Tags.HasFlag(EFurnitureTags.LowerChair);

		public static event Action<Seat, bool> OnSeatLinked;

		protected override void OnAwake()
		{
			base.OnAwake();
			if (TryGetComponent<FurnitureController>(out var component))
			{
				component.NeedSlot = true;
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			base.Furniture.Controller.OnSlot += OnSlot;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			base.Furniture.Controller.OnSlot -= OnSlot;
			ClearItemSlot();
		}

		protected override void OnFurnitureBecameUnavailable()
		{
			if ((bool)base.User)
			{
				if ((bool)base.User.FurnitureAssignment.CurrentSeat)
				{
					base.User.ForceStop();
				}
				if (base.User is Customer customer)
				{
					customer.ClearOrder();
					customer.ReleaseSeat();
				}
			}
			base.OnFurnitureBecameUnavailable();
		}

		private void OnSlot(FurnitureSlot slot)
		{
			ClearItemSlot();
			if (!slot)
			{
				if ((bool)_currentTable)
				{
					_currentTable.RemoveSeat(this);
					Seat.OnSeatLinked?.Invoke(this, arg2: false);
				}
				_currentTable = null;
				return;
			}
			FurnitureInteractor interactor = slot.FurnitureController.Furniture.Interactor;
			if ((bool)interactor && interactor is Table table)
			{
				if ((bool)_currentTable && _currentTable != table)
				{
					_currentTable.RemoveSeat(this);
				}
				_currentTable = table;
				if (SearchForSlot())
				{
					ItemSlot.SetUsed(null);
					_currentTable.AddSeat(this);
				}
				Seat.OnSeatLinked?.Invoke(this, arg2: true);
			}
		}

		private void ClearItemSlot()
		{
			if ((bool)ItemSlot)
			{
				ItemSlot.SetUnused();
				ItemSlot = null;
			}
		}

		private bool SearchForSlot()
		{
			Collider[] array = PhysicsAllocation.Get(20);
			int num = Physics.OverlapSphereNonAlloc(base.transform.position + base.transform.forward * 0.5f + Vector3.up, 0.75f, array, slotLayer, QueryTriggerInteraction.Collide);
			if (num <= 0)
			{
				return false;
			}
			float num2 = float.MaxValue;
			int num3 = -1;
			Vector2 vector = base.transform.position.ToHorizontal2D();
			DrinkSlot itemSlot = null;
			for (int i = 0; i < num; i++)
			{
				if (!array[i].TryGetComponent<DrinkSlot>(out var component) || component.InUse)
				{
					Debug.DrawRay(array[i].bounds.center, Vector3.up, Color.red, 2f);
					continue;
				}
				Debug.DrawRay(array[i].bounds.center, Vector3.up, Color.green, 2f);
				float sqrMagnitude = (array[i].transform.position.ToHorizontal2D() - vector).sqrMagnitude;
				if (sqrMagnitude < num2)
				{
					itemSlot = component;
					num2 = sqrMagnitude;
					num3 = i;
				}
			}
			if (num3 < 0)
			{
				return false;
			}
			ItemSlot = itemSlot;
			return true;
		}
	}
}
