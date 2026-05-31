using System.Collections;
using Animancer;

namespace CTS.BBT.AI
{
	public class WorkerChoreClearDrink : WorkerChore
	{
		private readonly Drink _drink;

		internal WorkerChoreClearDrink(ChoreCategory category, Drink drink)
			: base(category, drink.RoomObject)
		{
			_drink = drink;
		}

		public override string GetDisplayName()
		{
			return ContextualActionDisplayNames.GetAction(EActionName.ClearEmptyDrink);
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (_drink.IsHeld)
			{
				return false;
			}
			if ((bool)_drink.InSlot)
			{
				return !(_drink.InSlot is PlateSlot);
			}
			return true;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			PathingTracker outTracker;
			yield return MoveToActor(_drink, EInteractionKey.PickUp, out outTracker);
		}

		public override IEnumerator ActionRoutine()
		{
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.GrabObjectRight, FadeMode.FromStart);
			_drink.Clear();
		}

		protected override void OnStopped()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
