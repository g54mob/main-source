using System.IO;
using System.Text;

namespace UniJSON
{
	public class FileSystemAccessor : IFileSystemAccessor
	{
		private string m_path;

		private string m_baseDir;

		public FileSystemAccessor(string path)
		{
			m_path = path;
			if (Directory.Exists(path))
			{
				m_baseDir = path;
			}
			else
			{
				m_baseDir = Path.GetDirectoryName(path);
			}
		}

		public override string ToString()
		{
			return "<" + Path.GetFileName(m_path) + ">";
		}

		public string ReadAllText()
		{
			return File.ReadAllText(m_path, Encoding.UTF8);
		}

		public string ReadAllText(string relativePath)
		{
			return File.ReadAllText(Path.Combine(m_baseDir, relativePath), Encoding.UTF8);
		}

		public IFileSystemAccessor Get(string relativePath)
		{
			return new FileSystemAccessor(Path.Combine(m_baseDir, relativePath));
		}
	}
}
