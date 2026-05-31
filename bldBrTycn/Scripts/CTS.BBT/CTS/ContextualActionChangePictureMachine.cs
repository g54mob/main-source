using CTS.BBT;

namespace CTS
{
	public class ContextualActionChangePictureMachine : MenuContextualAction<Hypnotic>
	{
		public override void Setup()
		{
		}

		public override bool CanBeExecutedWithoutWorker()
		{
			return true;
		}

		protected override bool CanBePerformed()
		{
			return true;
		}

		protected override void Execution()
		{
			contextActor.ChangePicture();
		}
	}
}
