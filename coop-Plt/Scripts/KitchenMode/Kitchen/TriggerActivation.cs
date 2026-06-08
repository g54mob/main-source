using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(ItemTransferGroup))]
	public class TriggerActivation : ItemInteractionSystem
	{
		private EntityQuery ClearActivations;

		private bool RequireHeld;

		private bool RequirePressed;

		protected override void Initialise()
		{
			base.Initialise();
			ClearActivations = GetEntityQuery(typeof(CRequiresHeldActivation));
		}

		protected override EntityContext CreateContext()
		{
			EntityContext result = base.CreateContext();
			result.Remove<CIsInactive>(ClearActivations);
			return result;
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			if (Has<CPreventUse>(data.Target))
			{
				return false;
			}
			RequireHeld = Has<CRequiresHeldActivation>(data.Target);
			RequirePressed = Has<CRequiresActivation>(data.Target);
			if (!RequireHeld && !RequirePressed)
			{
				return false;
			}
			if (HasComponent<CLockedWhileDuration>(data.Target) && Require<CTakesDuration>(data.Target, out CTakesDuration comp) && comp.Active)
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			if (RequireHeld)
			{
				data.Context.Remove<CIsInactive>(data.Target);
			}
			if (RequirePressed)
			{
				if (HasComponent<CIsInactive>(data.Target))
				{
					data.Context.Remove<CIsInactive>(data.Target);
				}
				else
				{
					data.Context.Add<CIsInactive>(data.Target);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
