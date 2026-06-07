using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class NotificationDecision : IPersistable
	{
		[FormerlySerializedAs("label")]
		public string labelKey;

		public bool isDisabled;

		public bool isHidden;

		protected NotificationDecision()
		{
		}

		public NotificationDecision(string labelKey, bool isDisabled = false, bool isHidden = false)
		{
		}
	}
}
