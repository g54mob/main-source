namespace UniJSON
{
	public interface IFileSystemAccessor
	{
		string ReadAllText();

		string ReadAllText(string relativePath);

		IFileSystemAccessor Get(string relativePath);
	}
}
