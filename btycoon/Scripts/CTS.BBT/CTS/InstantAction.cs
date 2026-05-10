namespace CTS
{
	public abstract class InstantAction : SequenceAction
	{
		public override bool IsValid()
		{
			return true;
		}

		public override void Play(ActionSequence sequence)
		{
			SendStartEvent(started: false);
			SendStartEvent(started: true);
			FinishAction(PlayAction(sequence));
		}

		protected abstract bool PlayAction(ActionSequence sequence);
	}
}
