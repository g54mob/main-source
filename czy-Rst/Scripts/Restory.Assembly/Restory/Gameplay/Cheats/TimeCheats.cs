using System;
using System.ComponentModel;
using Restory.Gameplay.Common;
using Restory.Gameplay.TimeSystems;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class TimeCheats : SRDebugCheatBase, IActiveStateSwitchRequester
	{
		private readonly TimeSystem timeSystem;

		private readonly GameCalendar gameCalendar;

		private const string COMMON_CATEGORY = "Time Cheats";

		private bool isTimeStopped;

		[Category("Time Cheats")]
		[DisplayName("Is Time Stopped")]
		public bool TimeSystemBlocked
		{
			get
			{
				return isTimeStopped;
			}
			set
			{
				isTimeStopped = value;
				if (isTimeStopped)
				{
					timeSystem.BlockTimeSystem(this);
				}
				else
				{
					timeSystem.StopBlockingTimeSystem(this);
				}
				Debug.Log("Cheat command: TimeSystemBlocked success");
			}
		}

		[Category("Time Cheats")]
		[DisplayName("Skip 30 minutes")]
		public void SkipThirtyMinutes()
		{
			SkipTime(TimeSpan.FromMinutes(30.0));
			Debug.Log("Cheat command: SkipThirtyMinutes success – skipped 30 minutes");
		}

		[Category("Time Cheats")]
		[DisplayName("Skip 1 hour")]
		public void SkipOneHour()
		{
			SkipTime(TimeSpan.FromHours(1.0));
			Debug.Log("Cheat command: SkipOneHour success – skipped 1 hour");
		}

		[Category("Time Cheats")]
		[DisplayName("Skip 2 hours")]
		public void SkipTwoHours()
		{
			SkipTime(TimeSpan.FromHours(2.0));
			Debug.Log("Cheat command: SkipTwoHours success – skipped 2 hour");
		}

		[Category("Time Cheats")]
		[DisplayName("Skip 4 hours")]
		public void SkipFourHours()
		{
			SkipTime(TimeSpan.FromHours(4.0));
			Debug.Log("Cheat command: SkipFourHours success – skipped 4 hour");
		}

		[Category("Time Cheats")]
		[DisplayName("Skip 8 hours")]
		public void SkipEightHours()
		{
			SkipTime(TimeSpan.FromHours(8.0));
			Debug.Log("Cheat command: SkipEightHours success – skipped 8 hour");
		}

		private void SkipTime(TimeSpan timeToSkip)
		{
			DateTime dateTime = gameCalendar.CurrentDateTime + timeToSkip;
			TimeOfDay targetTimeOfDay = new TimeOfDay(dateTime.Hour, dateTime.Minute, dateTime.Second);
			timeSystem.SkipTime(targetTimeOfDay);
		}

		[Inject]
		public TimeCheats(TimeSystem timeSystem, GameCalendar gameCalendar)
		{
			this.timeSystem = timeSystem;
			this.gameCalendar = gameCalendar;
		}
	}
}
