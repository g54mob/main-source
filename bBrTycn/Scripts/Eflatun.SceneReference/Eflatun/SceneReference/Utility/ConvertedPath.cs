using System.IO;

namespace Eflatun.SceneReference.Utility
{
	internal class ConvertedPath
	{
		public string GivenPath { get; }

		public string WindowsPath { get; }

		public string UnixPath { get; }

		public string PlatformPath { get; }

		public ConvertedPath(string path)
		{
			GivenPath = path;
			string[] value = path.Split('\\', '/');
			WindowsPath = string.Join("\\", value);
			UnixPath = string.Join("/", value);
			PlatformPath = string.Join(Path.DirectorySeparatorChar.ToString(), value);
		}
	}
}
