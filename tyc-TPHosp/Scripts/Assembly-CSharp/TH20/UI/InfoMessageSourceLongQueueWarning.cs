using System;

namespace TH20.UI
{
	[Serializable]
	public class InfoMessageSourceLongQueueWarning : InfoMessageSource
	{
		public override string GetMessage(Level level)
		{
			int num = 0;
			int queueWarningLength = level.HospitalPolicy.QueueWarningLength;
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				if (allRoom.QueueLength >= queueWarningLength)
				{
					num++;
				}
			}
			string text = _localisedString.Translation;
			LocalisationParams.Set("COUNT", num);
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
