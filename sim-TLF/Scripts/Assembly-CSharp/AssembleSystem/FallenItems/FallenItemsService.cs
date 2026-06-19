using System.Collections.Generic;
using UI.Inventory;
using UnityEngine;
using Zenject;

namespace AssembleSystem.FallenItems
{
	public class FallenItemsService : IFallenItemsService, ITickable
	{
		private readonly struct TrackedItem
		{
			public readonly Transform Transform;

			public readonly Rigidbody Rigidbody;

			public readonly MeshRenderer MeshRenderer;

			public TrackedItem(Transform transform, Rigidbody rigidbody, MeshRenderer meshRenderer)
			{
				Transform = transform;
				Rigidbody = rigidbody;
				MeshRenderer = meshRenderer;
			}
		}

		private readonly Transform _dumpsterPoint;

		private readonly float _fallThreshold;

		private readonly float _checkInterval;

		private readonly float _stackSpacing;

		private readonly IInventoryService _inventoryService;

		private readonly IInventoryUIService _inventoryUIService;

		private readonly Dictionary<IInventoryManagable, TrackedItem> _items = new Dictionary<IInventoryManagable, TrackedItem>();

		private readonly List<IInventoryManagable> _rescuedInInventory = new List<IInventoryManagable>();

		private float _timer;

		public FallenItemsService(Transform dumpsterPoint, float fallThreshold, float checkInterval, float stackSpacing, IInventoryService inventoryService, IInventoryUIService inventoryUIService)
		{
			_dumpsterPoint = dumpsterPoint;
			_fallThreshold = fallThreshold;
			_checkInterval = Mathf.Max(0f, checkInterval);
			_stackSpacing = stackSpacing;
			_inventoryService = inventoryService;
			_inventoryUIService = inventoryUIService;
		}

		public void Register(IInventoryManagable item)
		{
			if (item is MonoBehaviour monoBehaviour && !_items.ContainsKey(item))
			{
				_items[item] = new TrackedItem(monoBehaviour.transform, monoBehaviour.GetComponent<Rigidbody>(), monoBehaviour.GetComponent<MeshRenderer>());
			}
		}

		public void Unregister(IInventoryManagable item)
		{
			if (item != null)
			{
				_items.Remove(item);
			}
		}

		void ITickable.Tick()
		{
			_timer += Time.deltaTime;
			if (!(_timer < _checkInterval))
			{
				_timer = 0f;
				CheckFallenItems();
			}
		}

		private void CheckFallenItems()
		{
			if (_dumpsterPoint == null)
			{
				return;
			}
			int num = 0;
			_rescuedInInventory.Clear();
			foreach (KeyValuePair<IInventoryManagable, TrackedItem> item in _items)
			{
				IInventoryManagable key = item.Key;
				TrackedItem value = item.Value;
				if (!(value.Transform == null) && !(value.Transform.position.y > _fallThreshold) && (!TeleportExempt.IsExempt(value.Transform) || IsDetachedPart(key)))
				{
					Rescue(value, num);
					num++;
					if (_inventoryService.Items.Contains(key))
					{
						_rescuedInInventory.Add(key);
					}
				}
			}
			foreach (IInventoryManagable item2 in _rescuedInInventory)
			{
				RemoveFromInventory(item2);
			}
		}

		private static bool IsDetachedPart(IInventoryManagable item)
		{
			if (!(item is PartObject { StateMachine: var stateMachine }))
			{
				return false;
			}
			if (stateMachine != null)
			{
				if (stateMachine.Placed)
				{
					return !stateMachine.Tightened;
				}
				return true;
			}
			return false;
		}

		private void RemoveFromInventory(IInventoryManagable item)
		{
			_inventoryUIService.RemoveItem(item);
			_inventoryService.RemoveItem(item);
		}

		private void Rescue(TrackedItem tracked, int stackIndex)
		{
			Vector3 position = _dumpsterPoint.position + Vector3.up * (_stackSpacing * (float)stackIndex);
			if (tracked.MeshRenderer != null)
			{
				Vector3 vector = tracked.MeshRenderer.bounds.center - tracked.Transform.position;
				position -= vector;
			}
			tracked.Transform.SetPositionAndRotation(position, _dumpsterPoint.rotation);
			if (tracked.Rigidbody != null)
			{
				tracked.Rigidbody.linearVelocity = Vector3.zero;
				tracked.Rigidbody.angularVelocity = Vector3.zero;
			}
		}
	}
}
