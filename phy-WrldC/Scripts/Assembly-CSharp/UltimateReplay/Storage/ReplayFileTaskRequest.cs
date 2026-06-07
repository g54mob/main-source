namespace UltimateReplay.Storage
{
	internal struct ReplayFileTaskRequest
	{
		public ReplayFileTaskID taskID;

		public ReplayFileRequest task;

		public ReplayFileTaskPriority priority;

		public object data;
	}
}
