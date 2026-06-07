namespace Stateless.Reflection
{
	public class DynamicStateInfo
	{
		public string DestinationState { get; set; }

		public string Criterion { get; set; }

		public DynamicStateInfo(string destinationState, string criterion)
		{
			DestinationState = destinationState;
			Criterion = criterion;
		}
	}
}
