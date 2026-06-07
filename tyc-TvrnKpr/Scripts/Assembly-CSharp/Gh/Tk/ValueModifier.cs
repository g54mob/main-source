namespace Gh.Tk
{
	public class ValueModifier
	{
		public string key;

		public float value;

		public bool isPercentageModifier;

		public string DisplayReasonKey;

		public float expiresAt;

		private int _count;

		protected ValueModifier()
		{
		}

		public ValueModifier(string key, float value, bool isPercentageModifier, string displayReasonKey)
		{
		}

		public void LogValueAndAverageAll(float value)
		{
		}
	}
}
