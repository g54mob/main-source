using System.Collections.Generic;
using JetBrains.Annotations;

public interface IFileSystem
{
	[NotNull]
	List<string> GetFilesInDirectory(string directory);

	[NotNull]
	List<string> GetDirectoriesInDirectory(string directory);

	[CanBeNull]
	byte[] ReadFile([NotNull] string filepath);

	bool WriteFile([NotNull] string filepath, [NotNull] byte[] data);

	bool DeleteFile([NotNull] string filepath);
}
