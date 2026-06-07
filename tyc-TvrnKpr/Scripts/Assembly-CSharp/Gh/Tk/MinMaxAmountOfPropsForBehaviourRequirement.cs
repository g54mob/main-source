namespace Gh.Tk
{
	public class MinMaxAmountOfPropsForBehaviourRequirement : PropZoneRoomRequirement
	{
		private readonly string[] _mandatoryBehaviours;

		private readonly string[] _behavioursToExclude;

		private readonly int _minAmount;

		private readonly int _maxAmount;

		private readonly bool _countAps;

		protected MinMaxAmountOfPropsForBehaviourRequirement()
		{
		}

		public MinMaxAmountOfPropsForBehaviourRequirement(string titleKey, string[] mandatoryBehaviours, string[] behavioursToExclude, int minAmount, int maxAmount = -1, string zone = null, Room room = null, bool countAps = false)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}
	}
}
