using System.Collections.Generic;

namespace Gh.Tk
{
	public class AlertMessage
	{
		public static Dictionary<string, string[]> VoTextKeys;

		public string source;

		public string textKey;

		public string voTextKey;

		public string comparisonKey;

		public float timestamp;

		public static string GetVoTextForCameraVisual(string visual)
		{
			return null;
		}

		protected AlertMessage()
		{
		}

		public AlertMessage(AdvisorAlertBase source, string textKey, string voTextKey, string comparisonKey)
		{
		}
	}
}
