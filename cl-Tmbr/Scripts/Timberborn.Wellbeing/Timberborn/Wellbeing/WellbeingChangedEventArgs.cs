namespace Timberborn.Wellbeing
{
	public struct WellbeingChangedEventArgs
	{
		public readonly int OldWellbeing;

		public readonly int NewWellbeing;

		public WellbeingChangedEventArgs(int oldWellbeing, int newWellbeing)
		{
			OldWellbeing = oldWellbeing;
			NewWellbeing = newWellbeing;
		}
	}
}
