namespace Gh.Tk
{
	public class StatModifier : IPersistable
	{
		public string Name { get; set; }

		public float ChangePerSecond { get; set; }

		public string DisplayReasonKey { get; set; }

		public string GroupableDisplayReasonKey { get; set; }

		public float Duration { get; set; }

		public bool HasTimedOut { get; private set; }

		protected StatModifier()
		{
		}

		public StatModifier(string name, float changePerSecond, string displayReasonKey, float duration)
		{
		}

		public void Update()
		{
		}
	}
}
