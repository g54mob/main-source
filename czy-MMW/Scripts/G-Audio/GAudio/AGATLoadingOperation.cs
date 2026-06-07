namespace GAudio
{
	public abstract class AGATLoadingOperation
	{
		public FileLoadProgressHandler OnFileLoadProgress { get; set; }

		public FileLoadedHandler OnFileWasLoaded { get; set; }

		public OperationCompletedHandler OnOperationCompleted { get; set; }

		public LoadOperationStatus Status { get; protected set; }

		public LoadOperationFailReason FailReason { get; protected set; }

		public string CurrentFileName { get; protected set; }

		public abstract bool AddFile(string relativePath, PathRelativeType pathType);
	}
}
