using LitJson;

namespace Gh.Tk
{
	public class NewHandbookTopicNotificationEvent : SimpleNotificationEvent
	{
		private string _topicCodexId;

		private string _headerLine;

		[JsonIgnore]
		public string CodexId => null;

		public static void Fire(string topicCodexId, string headerLine = null)
		{
		}

		protected NewHandbookTopicNotificationEvent()
		{
		}

		public NewHandbookTopicNotificationEvent(UINotificationData uiNotificationData, string topicCodexId, string headerLine)
		{
		}

		protected override void OnDecisionCallback(int option)
		{
		}
	}
}
