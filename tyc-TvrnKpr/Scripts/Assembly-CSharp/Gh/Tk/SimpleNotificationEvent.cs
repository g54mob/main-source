namespace Gh.Tk
{
	public class SimpleNotificationEvent : GameEvent, ICustomSaveState, IUpdateable
	{
		private bool _didAutoOpen;

		public bool AutoOpen { get; set; }

		public UINotificationData UINotificationData { get; protected set; }

		protected SimpleNotificationEvent()
		{
		}

		public SimpleNotificationEvent(float dueInSeconds, UINotificationData uiNotificationData, bool autoOpen = false)
		{
		}

		public virtual string GetGroupId()
		{
			return null;
		}

		public override void Trigger()
		{
		}

		protected virtual void SetupNotification()
		{
		}

		protected virtual void OnDismissCallback()
		{
		}

		protected virtual void ShowNotification()
		{
		}

		protected virtual void OnDecisionCallback(int option)
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void LateRestoreState(IDataStore data)
		{
		}

		public virtual void RestoreState(IDataStore data)
		{
		}

		public void SaveState(IDataStore data)
		{
		}

		protected void AutoOpenOrWait()
		{
		}

		public void UpdateObject()
		{
		}
	}
}
