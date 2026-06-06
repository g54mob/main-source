namespace M4.Session
{
	public abstract class FileSystemActionBase
	{
		private string fileName;

		private string directory;

		public string FileName { get; private set; }

		public string Directory { get; private set; }

		public string Path { get; private set; }

		public FileSystemActionResult Result { get; protected set; }

		public string ResultMessage { get; protected set; }

		public byte[] Data { get; protected set; }

		internal FileSystemAction Action { get; private set; }

		public FileSystemActionBase(FileSystemAction action, string file_name, string directory)
		{
			Action = action;
			FileName = file_name;
			Directory = directory;
		}

		public abstract bool Execute();

		internal void SetResult(FileSystemActionResult result, byte[] data = null)
		{
			Result = result;
			Data = data;
		}
	}
}
