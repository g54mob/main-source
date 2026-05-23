namespace Assets.Scripts.Inventory__Items__Pickups.Stats
{
	public class StatComponents
	{
		public bool hasModifications;

		public float baseValue { get; private set; }

		public float additiveValue { get; private set; }

		public float multiplicativeValue { get; private set; }

		public void Recycle()
		{
		}

		public void SetValues(float baseValues, float additiveValues, float multiplicativeValues)
		{
		}

		public float GetFinalValue(StatComponents other)
		{
			return 0f;
		}

		public void AddMultiplier(float value)
		{
		}

		public void AddAdditive(float value)
		{
		}

		public void AddFlat(float value)
		{
		}
	}
}
