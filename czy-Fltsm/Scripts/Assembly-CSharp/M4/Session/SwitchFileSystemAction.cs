using System;

namespace M4.Session
{
	public class SwitchFileSystemAction : FileSystemActionBase
	{
		public long Size { get; private set; }

		public SwitchFileSystemAction(string file_name, long size)
			: base(FileSystemAction.Read, file_name, "")
		{
			Size = size;
		}

		public SwitchFileSystemAction(string file_name, byte[] data, long size)
			: base(FileSystemAction.Write, file_name, "")
		{
			base.Data = data;
			Size = size;
		}

		public override bool Execute()
		{
			throw new NotImplementedException();
		}
	}
}
