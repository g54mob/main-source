using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Save")]
	[Category("Storage/On Save")]
	[Description("Executed when the game is saved")]
	[Image(typeof(IconDiskSolid), ColorTheme.Type.Green)]
	[Keywords(new string[] { "Load", "Save", "Profile", "Slot", "Game", "Session" })]
	public class EventOnSave : Event
	{
		private enum Option
		{
			BeforeSaving = 0,
			AfterSaving = 1
		}

		[SerializeField]
		private Option m_When;

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			Singleton<SaveLoadManager>.Instance.EventBeforeSave += OnBeforeSave;
			Singleton<SaveLoadManager>.Instance.EventAfterSave += OnAfterSave;
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			if (!ApplicationManager.IsExiting)
			{
				Singleton<SaveLoadManager>.Instance.EventBeforeSave -= OnBeforeSave;
				Singleton<SaveLoadManager>.Instance.EventAfterSave -= OnAfterSave;
			}
		}

		private void OnBeforeSave(int obj)
		{
			if (m_When == Option.BeforeSaving)
			{
				m_Trigger.Execute(base.Self);
			}
		}

		private void OnAfterSave(int obj)
		{
			if (m_When == Option.AfterSaving)
			{
				m_Trigger.Execute(base.Self);
			}
		}
	}
}
