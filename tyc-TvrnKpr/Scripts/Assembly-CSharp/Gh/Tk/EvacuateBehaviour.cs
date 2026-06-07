namespace Gh.Tk
{
	public class EvacuateBehaviour : ActorBehaviour
	{
		protected EvacuateBehaviour()
		{
		}

		public EvacuateBehaviour(Actor owner)
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public override void OnRemoving()
		{
		}
	}
}
