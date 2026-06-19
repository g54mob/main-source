using System.Collections.Generic;

namespace TH20
{
	public class CollaborativeProgressStatus
	{
		public uint TimeStamp;

		public Dictionary<int, int> NodeCompletionData = new Dictionary<int, int>();

		public static CollaborativeProgressStatus CreateStatusData(CollaborativeProject project, uint timestamp = 0u)
		{
			if (project == null)
			{
				return null;
			}
			CollaborativeProgressStatus collaborativeProgressStatus = new CollaborativeProgressStatus();
			foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum in project.ProjectData)
			{
				if (!(projectDatum.Value is CollaborativeProjectData collaborativeProjectData))
				{
					continue;
				}
				Dictionary<int, uint> dictionary = collaborativeProjectData.ResearchData?.CompletedNodeTimestamps;
				if (dictionary == null)
				{
					continue;
				}
				foreach (KeyValuePair<int, uint> item in dictionary)
				{
					int key = item.Key;
					if (item.Value >= timestamp)
					{
						collaborativeProgressStatus.NodeCompletionData.TryGetValue(key, out var value);
						collaborativeProgressStatus.NodeCompletionData[key] = value + 1;
					}
				}
			}
			collaborativeProgressStatus.TimeStamp = OnlineManager.GetServerTime();
			return collaborativeProgressStatus;
		}
	}
}
