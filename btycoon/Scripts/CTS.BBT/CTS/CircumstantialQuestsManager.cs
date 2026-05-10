namespace CTS
{
	public class CircumstantialQuestsManager : QuestsManager
	{
		public static bool CircumstantialQuestRunning { get; private set; }

		protected override void OnEnabled()
		{
			base.OnEnabled();
			CircumstantialQuest.CircumstantialQuestStarting += OnCircumstantialQuestStarting;
			CircumstantialQuest.CircumstantialQuestValidating += OnCircumstantialQuestValidating;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			CircumstantialQuest.CircumstantialQuestStarting -= OnCircumstantialQuestStarting;
			CircumstantialQuest.CircumstantialQuestValidating -= OnCircumstantialQuestValidating;
			CircumstantialQuestRunning = false;
		}

		private void OnCircumstantialQuestValidating()
		{
			CircumstantialQuestRunning = false;
		}

		private void OnCircumstantialQuestStarting()
		{
			CircumstantialQuestRunning = true;
		}
	}
}
