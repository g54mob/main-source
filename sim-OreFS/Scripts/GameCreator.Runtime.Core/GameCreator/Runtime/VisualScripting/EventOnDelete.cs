using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Delete")]
	[Category("Storage/On Delete")]
	[Description("Executed when a previously saved game deleted")]
	[Keywords(new string[] { "Load", "Save", "Delete", "Profile", "Slot", "Game", "Session" })]
	[Image(typeof(IconDiskOutline), ColorTheme.Type.Red, typeof(OverlayCross))]
	public class EventOnDelete : Event
	{
		private enum Option
		{
			BeforeDeleting = 0,
			AfterDeleting = 1
		}

		[SerializeField]
		private Option m_When = Option.AfterDeleting;

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			Singleton<SaveLoadManager>.Instance.EventBeforeDelete += OnBeforeDelete;
			Singleton<SaveLoadManager>.Instance.EventAfterDelete += OnAfterDelete;
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			if (!ApplicationManager.IsExiting)
			{
				Singleton<SaveLoadManager>.Instance.EventBeforeDelete -= OnBeforeDelete;
				Singleton<SaveLoadManager>.Instance.EventAfterDelete -= OnAfterDelete;
			}
		}

		private void OnBeforeDelete(int obj)
		{
			if (m_When == Option.BeforeDeleting)
			{
				m_Trigger.Execute(base.Self);
			}
		}

		private void OnAfterDelete(int obj)
		{
			if (m_When == Option.AfterDeleting)
			{
				m_Trigger.Execute(base.Self);
			}
		}
	}
}
