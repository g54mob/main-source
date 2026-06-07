using System.Collections.Generic;

namespace UltimateReplay.Storage
{
	internal struct ReplayFileTaskID
	{
		private static List<int> usedTasks = new List<int>();

		private int id;

		public static ReplayFileTaskID empty = new ReplayFileTaskID
		{
			id = -1
		};

		private ReplayFileTaskID(int id)
		{
			this.id = id;
		}

		public static ReplayFileTaskID GenerateID()
		{
			lock (usedTasks)
			{
				int num = 0;
				int num2 = -1;
				while (num2 == -1)
				{
					int num3 = num++ * (27 + num);
					if (!usedTasks.Contains(num3))
					{
						num2 = num3;
					}
				}
				return new ReplayFileTaskID(num2);
			}
		}

		public static void ReleaseID(ReplayFileTaskID taskID)
		{
			lock (usedTasks)
			{
				if (usedTasks.Contains(taskID.id))
				{
					usedTasks.Remove(taskID.id);
				}
			}
		}
	}
}
