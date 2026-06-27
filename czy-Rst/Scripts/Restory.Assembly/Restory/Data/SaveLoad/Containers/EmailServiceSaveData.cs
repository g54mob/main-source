using System;
using Restory.Gameplay.EmailSystems;
using Restory.TimeSystems;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class EmailServiceSaveData
	{
		public EmailLetterRecordInFolder[] UpcomingEmails;

		public EmailLetterRecordInFolder[] ReceivedEmails;

		public MainDayTimes LastTrackedTime;
	}
}
