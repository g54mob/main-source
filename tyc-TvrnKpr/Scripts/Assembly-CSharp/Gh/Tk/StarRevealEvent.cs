using System;
using System.Runtime.CompilerServices;
using LitJson;

namespace Gh.Tk
{
	public class StarRevealEvent : GameEvent, ICustomSaveState, IUpdateable
	{
		private string _notificationId;

		public int Star { get; private set; }

		[JsonIgnore]
		public UINotificationData UINotificationData { get; protected set; }

		public static event EventHandler StarRevealEventChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static StarRevealEvent Fire(int star)
		{
			return null;
		}

		public static bool IsStarRevealPending()
		{
			return false;
		}

		public static bool IsStarRevealPending(int star)
		{
			return false;
		}

		protected StarRevealEvent()
		{
		}

		public StarRevealEvent(int starRating)
		{
		}

		public void UpdateObject()
		{
		}

		private void SetupNotification()
		{
		}

		public virtual void RestoreState(IDataStore data)
		{
		}

		public void SaveState(IDataStore data)
		{
		}

		public override void Trigger()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
