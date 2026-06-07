using System.IO;

namespace M4.Session
{
	public class DefaultFileSystemRead : FileSystemActionBase
	{
		public DefaultFileSystemRead(string file_name, string directory)
			: base(FileSystemAction.Read, file_name, directory)
		{
		}

		public override bool Execute()
		{
			if (File.Exists(base.Directory + "/" + base.FileName))
			{
				base.Data = File.ReadAllBytes(base.Directory + "/" + base.FileName);
				return true;
			}
			return false;
		}
	}
}
