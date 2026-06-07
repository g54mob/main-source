namespace Gh.Tk
{
	public class MinMaxAmountOfPropTypeRequirement<T> : PropZoneRoomRequirement where T : Prop
	{
		private readonly int _minAmount;

		private readonly int _maxAmount;

		public int MinStars { get; set; }

		protected MinMaxAmountOfPropTypeRequirement()
		{
		}

		public MinMaxAmountOfPropTypeRequirement(string titleKey, int minAmount, int maxAmount = -1, string zone = null, Room room = null)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}
	}
}
