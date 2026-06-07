using System.IO;
using System.Text;

namespace GameCreator.Runtime.Common
{
	public static class PathUtils
	{
		public static string Combine(params string[] sections)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string value in sections)
			{
				if (string.IsNullOrEmpty(value))
				{
					continue;
				}
				if (stringBuilder.Length > 0)
				{
					if (stringBuilder[stringBuilder.Length - 1] != '/')
					{
						stringBuilder.Append('/');
					}
				}
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		public static string PathForOS(string path)
		{
			return path.Replace('/', Path.DirectorySeparatorChar);
		}

		public static string PathToUnix(string path)
		{
			return path.Replace(Path.DirectorySeparatorChar, '/');
		}
	}
}
