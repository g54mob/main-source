using System.Collections;
using Animancer;
using CTS.Core.Pooling;

namespace CTS.BBT.AI
{
	public class WorkerActionPutDrinkOnPlate : WorkerAction
	{
		private readonly PooledRef<Drink> _drink;

		private readonly OrderPlate _plate;

		private readonly GroupOrder _order;

		private bool _spawnPlate;

		internal WorkerActionPutDrinkOnPlate(Drink drink, OrderPlate plate)
		{
			_drink = new PooledRef<Drink>(drink);
			_plate = plate;
			_order = _drink.Value.Order.GroupOrder;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			Drink value = _drink.Value;
			if (value.Order == null)
			{
				return false;
			}
			if (value.Order.GroupOrder != _order)
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding && !agentRef.ObjectHolding.IsHolding(_plate))
			{
				return false;
			}
			if (value.InSlot is PlateSlot)
			{
				return false;
			}
			return true;
		}

		public override void OnStart()
		{
			SyncWithItem((Drink)_drink);
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToActor(_drink.Value, EInteractionKey.PickUp);
		}

		public override IEnumerator ActionRoutine()
		{
			_spawnPlate = !base.ActionAgent.ObjectHolding.IsHolding(_plate);
			base.ActionAgent.Animator.Events.OnGrab += OnGrab;
			yield return base.ActionAgent.Animator.PlayPunctual(_spawnPlate ? AgentAnim.GrabObjectLeft : AgentAnim.GrabObjectRight, FadeMode.FromStart);
		}

		private void OnGrab()
		{
			base.ActionAgent.Animator.Events.OnGrab -= OnGrab;
			if (_drink.TryGetValue(out var outValue))
			{
				if (_spawnPlate)
				{
					_plate.gameObject.SetActive(value: true);
					base.ActionAgent.ObjectHolding.TryGrabObject(_plate);
				}
				outValue.InSlot.SetUnused();
				_plate.AddDrink(outValue);
			}
		}

		protected override void OnStopped()
		{
			base.ActionAgent.Animator.Events.OnGrab -= OnGrab;
		}

		public override void OnCancel()
		{
		}
	}
}
