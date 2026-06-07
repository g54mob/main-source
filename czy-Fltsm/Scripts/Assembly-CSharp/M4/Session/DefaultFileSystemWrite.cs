using System.IO;

namespace M4.Session
{
	public class DefaultFileSystemWrite : FileSystemActionBase
	{
		public DefaultFileSystemWrite(string file_name, string directory, byte[] data)
			: base(FileSystemAction.Write, file_name, directory)
		{
			base.Data = data;
		}

		public override bool Execute()
		{
			File.WriteAllBytes(base.Directory + "/" + base.FileName, base.Data);
			return true;
		}
	}
}
