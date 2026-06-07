namespace Gh.Tk
{
	public class MinPropTypeForEachPropTypeRequirement<T, K> : PropZoneRoomRequirement where T : Prop where K : Prop
	{
		private readonly int _minAmount;

		protected MinPropTypeForEachPropTypeRequirement()
		{
		}

		public MinPropTypeForEachPropTypeRequirement(string titleKey, int minAmount, string zone = null, Room room = null)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}
	}
}
