using System;
using UnityEngine;

namespace CTS.BBT.AI
{
	[DisallowMultipleComponent]
	public class AgentObjectHolding : MonoBehaviour
	{
		private Agent _agentRef;

		internal Item CurrentHeld { get; private set; }

		public bool IsCurrentlyHolding => (object)CurrentHeld != null;

		public event Action<Item> OnItemGrab;

		private void Awake()
		{
			_agentRef = GetComponent<Agent>();
		}

		public bool IsHolding<THoldable>() where THoldable : Item
		{
			if (!IsCurrentlyHolding)
			{
				return false;
			}
			return CurrentHeld is THoldable;
		}

		public bool IsHolding<THoldable>(Func<THoldable, bool> p_filter) where THoldable : Item
		{
			if (!IsCurrentlyHolding)
			{
				return false;
			}
			if (CurrentHeld is THoldable arg)
			{
				return p_filter(arg);
			}
			return false;
		}

		public bool IsHolding(Item p_holdable)
		{
			if (!IsCurrentlyHolding)
			{
				return false;
			}
			return CurrentHeld == p_holdable;
		}

		public THoldable GetHeldObject<THoldable>() where THoldable : Item
		{
			if (!IsHolding<THoldable>())
			{
				return null;
			}
			return (THoldable)CurrentHeld;
		}

		public void DropObject()
		{
			if (IsCurrentlyHolding)
			{
				CurrentHeld.DropHoldable();
				this.OnItemGrab?.Invoke(null);
				CurrentHeld.GetComponentInChildren<Collider>(includeInactive: true).enabled = true;
				CurrentHeld = null;
			}
		}

		public bool TryGrabObject(Item p_holdable)
		{
			if (IsCurrentlyHolding)
			{
				return false;
			}
			if (!p_holdable)
			{
				return false;
			}
			if (!p_holdable.TryGrabHoldable(_agentRef))
			{
				return false;
			}
			this.OnItemGrab?.Invoke(p_holdable);
			CurrentHeld = p_holdable;
			CurrentHeld.GetComponentInChildren<Collider>(includeInactive: true).enabled = false;
			return true;
		}
	}
}
