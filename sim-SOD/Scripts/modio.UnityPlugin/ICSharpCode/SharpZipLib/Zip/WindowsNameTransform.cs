using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class WindowsNameTransform : INameTransform
	{
		private const int MaxPath = 260;

		private string _baseDirectory;

		private bool _trimIncomingPaths;

		private char _replacementChar;

		private bool _allowParentTraversal;

		private static readonly char[] InvalidEntryChars;

		public string BaseDirectory
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool AllowParentTraversal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool TrimIncomingPaths
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public char Replacement
		{
			get
			{
				return '\0';
			}
			set
			{
			}
		}

		public WindowsNameTransform(string baseDirectory, bool allowParentTraversal = false)
		{
		}

		public WindowsNameTransform()
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

		public static bool IsValidName(string name)
		{
			return false;
		}

		public static string MakeValidName(string name, char replacement)
		{
			return null;
		}
	}
}
