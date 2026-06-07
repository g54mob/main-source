public static class NativeFilePicker
{
	public delegate void FilePickedCallback(string path);

	public delegate void MultipleFilesPickedCallback(string[] paths);

	public delegate void FilesExportedCallback(bool success);

	public enum Permission
	{
		Denied = 0,
		Granted = 1,
		ShouldAsk = 2
	}

	public static Permission CheckPermission(bool readPermissionOnly = false)
	{
		return default(Permission);
	}

	public static Permission RequestPermission(bool readPermissionOnly = false)
	{
		return default(Permission);
	}

	public static void OpenSettings()
	{
	}

	public static bool CanPickMultipleFiles()
	{
		return false;
	}

	public static bool CanExportFiles()
	{
		return false;
	}

	public static bool CanExportMultipleFiles()
	{
		return false;
	}

	public static bool IsFilePickerBusy()
	{
		return false;
	}

	public static string ConvertExtensionToFileType(string extension)
	{
		return null;
	}

	public static Permission PickFile(FilePickedCallback callback, string[] allowedFileTypes)
	{
		return default(Permission);
	}

	public static Permission PickMultipleFiles(MultipleFilesPickedCallback callback, string[] allowedFileTypes)
	{
		return default(Permission);
	}

	public static Permission ExportFile(string filePath, FilePickedCallback callback = null)
	{
		return default(Permission);
	}

	public static Permission ExportMultipleFiles(string[] filePaths, FilesExportedCallback callback = null)
	{
		return default(Permission);
	}
}
