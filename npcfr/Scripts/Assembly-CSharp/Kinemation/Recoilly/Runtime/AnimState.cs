namespace Kinemation.Recoilly.Runtime
{
	public struct AnimState
	{
		public ConditionDelegate checkCondition;

		public PlayDelegate onPlay;

		public StopDelegate onStop;
	}
}
