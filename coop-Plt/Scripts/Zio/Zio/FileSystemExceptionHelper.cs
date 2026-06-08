using System.IO;

namespace Zio
{
	internal static class FileSystemExceptionHelper
	{
		public static FileNotFoundException NewFileNotFoundException(UPath path)
		{
			return new FileNotFoundException($"Could not find file `{path}`.");
		}

		public static DirectoryNotFoundException NewDirectoryNotFoundException(UPath path)
		{
			return new DirectoryNotFoundException($"Could not find a part of the path `{path}`.");
		}

		public static IOException NewDestinationDirectoryExistException(UPath path)
		{
			return new IOException($"The destination path `{path}` is an existing directory");
		}

		public static IOException NewDestinationFileExistException(UPath path)
		{
			return new IOException($"The destination path `{path}` is an existing file");
		}
	}
}
