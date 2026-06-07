using UnityEngine;

namespace Gh.Tk
{
	public class AlertVisualType
	{
		public const string Critical = "critical";

		public const string Warning = "warning";

		public const string Minor = "minor";

		public const string Positive = "positive";

		public string typeId;

		public int priority;

		public GameObject badge;

		public AlertVisualType(string typeId, int priority, GameObject icon)
		{
		}
	}
}
