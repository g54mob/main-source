namespace ModIO
{
	public class ProgressHandle
	{
		public ModId modId { get; internal set; }

		public ModManagementOperationType OperationType { get; internal set; }

		public float Progress { get; internal set; }

		public long BytesPerSecond { get; internal set; }

		public bool Completed { get; internal set; }

		public bool Failed { get; internal set; }
	}
}
