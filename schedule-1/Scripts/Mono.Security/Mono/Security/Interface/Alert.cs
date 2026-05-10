namespace Mono.Security.Interface
{
	public class Alert
	{
		private AlertLevel level;

		private AlertDescription description;

		public AlertLevel Level => default(AlertLevel);

		public AlertDescription Description => default(AlertDescription);

		public Alert(AlertDescription description)
		{
		}

		private void inferAlertLevel()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
