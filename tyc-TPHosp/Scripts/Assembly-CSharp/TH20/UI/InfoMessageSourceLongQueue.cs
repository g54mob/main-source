using System;
using UnityEngine;

namespace TH20.UI
{
	[Serializable]
	public class InfoMessageSourceLongQueue : InfoMessageSource
	{
		[SerializeField]
		private LocalisedString _minMaxString;

		public override string GetMessage(Level level)
		{
			int num = int.MaxValue;
			int num2 = int.MinValue;
			int queueWarningLength = level.HospitalPolicy.QueueWarningLength;
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				if (allRoom.QueueLength >= queueWarningLength)
				{
					num = Mathf.Min(allRoom.QueueLength, num);
					num2 = Mathf.Max(allRoom.QueueLength, num2);
				}
			}
			num = ((num != int.MaxValue) ? num : 0);
			num2 = ((num2 != int.MinValue) ? num2 : 0);
			string text = ((num == num2) ? _localisedString.Translation : _minMaxString.Translation);
			LocalisationParams.Set("MIN", num);
			LocalisationParams.Set("MAX", num2);
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
