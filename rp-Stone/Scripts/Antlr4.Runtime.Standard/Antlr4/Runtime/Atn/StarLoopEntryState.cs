namespace Antlr4.Runtime.Atn
{
	public sealed class StarLoopEntryState : DecisionState
	{
		public StarLoopbackState loopBackState;

		public bool isPrecedenceDecision;

		public override StateType StateType => StateType.StarLoopEntry;
	}
}
