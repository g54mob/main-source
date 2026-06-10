using System;
using System.Linq;
using System.Text;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[Serializable]
	public class EventAttendeeTypeSetting
	{
		[SerializeField]
		private EventAttendeeType attendeeType;

		[SerializeField]
		private int[] limitByRoleLevel;

		[SerializeField]
		private StringStringPair[] effectorArgs;

		[SerializeField]
		private string goalId;

		public EventAttendeeType AttendeeType => attendeeType;

		public string GoalId => goalId;

		public int GetLimit(int roleLevel = 0)
		{
			if (limitByRoleLevel == null || limitByRoleLevel.Length == 0)
			{
				return 0;
			}
			if (roleLevel > limitByRoleLevel.Length - 1)
			{
				if (limitByRoleLevel.Last() != -1)
				{
					return limitByRoleLevel.Last();
				}
				return int.MaxValue;
			}
			if (limitByRoleLevel[roleLevel] != -1)
			{
				return limitByRoleLevel[roleLevel];
			}
			return int.MaxValue;
		}

		public string GetEffectorIdParsed(string effectorId)
		{
			if (effectorArgs == null || effectorArgs.Length == 0)
			{
				return effectorId;
			}
			StringBuilder stringBuilder = new StringBuilder(effectorId);
			StringStringPair[] array = effectorArgs;
			foreach (StringStringPair stringStringPair in array)
			{
				stringBuilder.Replace(stringStringPair.Key, stringStringPair.Value);
			}
			return stringBuilder.ToString();
		}
	}
}
