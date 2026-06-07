using System.Collections;
using System.Linq;
using Animancer;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;

namespace CTS
{
	public class AgentActionGrabDrinkOnPlate : AgentAction<Agent>
	{
		private SoftReference<Drink> _drinkToGrab;

		private bool _shouldSpawnPlate;

		private readonly Resource<OrderPlate> PlatePrefab = new Resource<OrderPlate>("Pfb_OrderPlate");

		public AgentActionGrabDrinkOnPlate(SoftReference<Drink> drink)
		{
			_drinkToGrab = drink;
		}

		public AgentActionGrabDrinkOnPlate(Drink drink)
			: this(SoftReference.Create(drink))
		{
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			Drink drink = _drinkToGrab.Get();
			if (!drink)
			{
				return false;
			}
			if (drink.IsHeld)
			{
				return false;
			}
			PlateSlot plateSlot = drink.InSlot as PlateSlot;
			OrderPlate heldObject = agentRef.ObjectHolding.GetHeldObject<OrderPlate>();
			if ((object)heldObject == null)
			{
				if (plateSlot != null)
				{
					return false;
				}
			}
			else if ((bool)plateSlot && !heldObject.DrinkSlots.Contains(plateSlot))
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return agentRef.ObjectHolding.IsHolding<OrderPlate>();
			}
			return true;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToActor(_drinkToGrab.Get(), EInteractionKey.PickUp);
		}

		public override IEnumerator ActionRoutine()
		{
			_shouldSpawnPlate = !base.ActionAgent.ObjectHolding.IsHolding<OrderPlate>();
			base.ActionAgent.Animator.Events.OnGrab += OnGrab;
			yield return base.ActionAgent.Animator.PlayPunctual(_shouldSpawnPlate ? AgentAnim.GrabObjectLeft : AgentAnim.GrabObjectRight, FadeMode.FromStart);
		}

		private void OnGrab()
		{
			base.ActionAgent.Animator.Events.OnGrab -= OnGrab;
			if (_shouldSpawnPlate)
			{
				OrderPlate orderPlate = Pooler.Pull(PlatePrefab.Value);
				orderPlate.gameObject.SetActive(value: true);
				base.ActionAgent.ObjectHolding.TryGrabObject(orderPlate);
			}
			_drinkToGrab.Get().InSlot.SetUnused();
			base.ActionAgent.ObjectHolding.GetHeldObject<OrderPlate>().AddDrink(_drinkToGrab);
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
