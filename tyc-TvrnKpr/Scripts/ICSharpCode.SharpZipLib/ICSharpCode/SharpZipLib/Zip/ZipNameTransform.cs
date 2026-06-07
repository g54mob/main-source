using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class ZipNameTransform : INameTransform
	{
		private string trimPrefix_;

		private static readonly char[] InvalidEntryChars;

		private static readonly char[] InvalidEntryCharsRelaxed;

		public string TrimPrefix
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ZipNameTransform()
		{
		}

		public ZipNameTransform(string trimPrefix)
		{
		}

		static ZipNameTransform()
		{
		}

		public string TransformDirectory(string name)
		{
			return null;
		}

		public string TransformFile(string name)
		{
			return null;
		}

		private static string MakeValidName(string name, char replacement)
		{
			return null;
		}

		public static bool IsValidName(string name, bool relaxed)
		{
			return false;
		}

		public static bool IsValidName(string name)
		{
			return false;
		}
	}
}
