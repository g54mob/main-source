namespace CTS.Core
{
	public class FloatStatistic : IStatistic
	{
		public float FloatValue { get; protected set; }

		public FloatStatistic(float startValue)
		{
			FloatValue = startValue;
		}
	}
}
