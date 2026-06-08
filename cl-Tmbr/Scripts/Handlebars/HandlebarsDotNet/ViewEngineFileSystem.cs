using System.Linq;

namespace HandlebarsDotNet
{
	public abstract class ViewEngineFileSystem
	{
		public abstract string GetFileContent(string filename);

		private static string GetDir(string currentFilePath)
		{
			if (currentFilePath == "")
			{
				return null;
			}
			string[] array = currentFilePath.Split('\\', '/');
			if (array.Length == 1)
			{
				return "";
			}
			return string.Join("/", array.Take(array.Length - 1));
		}

		public string Closest(string filename, string otherFileName)
		{
			for (string dir = GetDir(filename); dir != null; dir = GetDir(dir))
			{
				string text = CombinePath(dir, otherFileName);
				if (FileExists(text))
				{
					return text;
				}
			}
			return null;
		}

		protected abstract string CombinePath(string dir, string otherFileName);

		public abstract bool FileExists(string filePath);
	}
}
