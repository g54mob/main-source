namespace Gh.Tk
{
	public class MinMaxAmountOfPropsWithIdentifierRequirement : PropZoneRoomRequirement
	{
		private readonly string[] _prefabTypeIdentifiers;

		private readonly int _minAmount;

		private readonly int _maxAmount;

		protected MinMaxAmountOfPropsWithIdentifierRequirement()
		{
		}

		public MinMaxAmountOfPropsWithIdentifierRequirement(string titleKey, string[] prefabTypeIdentifiers, int minAmount, int maxAmount = -1, string zone = null, Room room = null)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}
	}
}
