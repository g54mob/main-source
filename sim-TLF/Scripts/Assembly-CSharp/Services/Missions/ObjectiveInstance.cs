using System;

namespace Services.Missions
{
	[Serializable]
	public class ObjectiveInstance
	{
		public string ObjectiveId;

		public int CurrentAmount;

		public bool IsComplete;

		public ObjectiveInstance()
		{
		}

		public ObjectiveInstance(string objectiveId)
		{
			ObjectiveId = objectiveId;
			CurrentAmount = 0;
			IsComplete = false;
		}
	}
}
