using ResourcesManager;

namespace Build
{
	public class Version
	{
		public int Major;

		public int Minor;

		public int Patch;

		public int Revision;

		public int Build;

		private const string FILE_NAME = "version";

		public Version()
		{
		}

		public Version(string version)
		{
			string[] array = version.Split('.');
			if (array.Length != 0)
			{
				int.TryParse(array[0], out Major);
			}
			if (array.Length > 1)
			{
				int.TryParse(array[1], out Minor);
			}
			if (array.Length > 2)
			{
				int.TryParse(array[2], out Patch);
			}
			if (array.Length > 3)
			{
				int.TryParse(array[3], out Revision);
			}
			if (array.Length > 4)
			{
				int.TryParse(array[4], out Build);
			}
		}

		public static Version Load()
		{
			string text = string.Empty;
			if (!Resources.LoadText("version", out text))
			{
				return new Version();
			}
			return new Version(text);
		}

		public override string ToString()
		{
			return $"{Major}.{Minor}.{Patch}.{Revision}.{Build}";
		}

		public string ToShortString()
		{
			return $"{Major}.{Minor}.{Patch}";
		}
	}
}
