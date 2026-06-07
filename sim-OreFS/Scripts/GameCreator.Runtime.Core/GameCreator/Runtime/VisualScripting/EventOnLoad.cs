using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Load")]
	[Category("Storage/On Load")]
	[Description("Executed when a previously saved game is loaded")]
	[Image(typeof(IconDiskSolid), ColorTheme.Type.Blue)]
	[Keywords(new string[] { "Load", "Save", "Profile", "Slot", "Game", "Session" })]
	public class EventOnLoad : Event
	{
		private enum Option
		{
			BeforeLoading = 0,
			AfterLoading = 1
		}

		[SerializeField]
		private Option m_When = Option.AfterLoading;

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			Singleton<SaveLoadManager>.Instance.EventBeforeLoad += OnBeforeLoad;
			Singleton<SaveLoadManager>.Instance.EventAfterLoad += OnAfterLoad;
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			if (!ApplicationManager.IsExiting)
			{
				Singleton<SaveLoadManager>.Instance.EventBeforeLoad -= OnBeforeLoad;
				Singleton<SaveLoadManager>.Instance.EventAfterLoad -= OnAfterLoad;
			}
		}

		private void OnBeforeLoad(int obj)
		{
			if (m_When == Option.BeforeLoading)
			{
				m_Trigger.Execute(base.Self);
			}
		}

		private void OnAfterLoad(int obj)
		{
			if (m_When == Option.AfterLoading)
			{
				m_Trigger.Execute(base.Self);
			}
		}
	}
}
