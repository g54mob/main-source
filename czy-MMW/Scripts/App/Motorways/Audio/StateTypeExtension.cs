namespace Motorways.Audio
{
	public static class StateTypeExtension
	{
		public static bool Contains(this StateType superset, StateType subset)
		{
			return (superset & subset) == subset;
		}
	}
}
