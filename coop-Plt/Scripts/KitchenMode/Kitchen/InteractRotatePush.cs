using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(LowPriorityInteractionGroup))]
	public class InteractRotatePush : InteractionSystem
	{
		private CConveyPushRotatable Rotatable;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CConveyPushRotatable>(data.Target, out Rotatable))
			{
				return false;
			}
			if (Rotatable.Target == Orientation.Null)
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			Rotatable.Target = Rotatable.Target.RotateCW();
			if (Rotatable.Target == Orientation.Down)
			{
				Rotatable.Target = Orientation.Left;
			}
			Set(data.Target, Rotatable);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
