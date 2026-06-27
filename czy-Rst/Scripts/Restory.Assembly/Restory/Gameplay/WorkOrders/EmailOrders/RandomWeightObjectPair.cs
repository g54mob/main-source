namespace Restory.Gameplay.WorkOrders.EmailOrders
{
	public struct RandomWeightObjectPair<T> : IRandomnessWeightHolder
	{
		public T PossibleObject;

		public int Weight { get; set; }
	}
}
