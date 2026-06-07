using System;
using System.IO;

public class FileMetadata
{
	public readonly string extension;

	public readonly FileType fileType;

	public DateTime dateLastWritten;

	public readonly FileSource fileSource;

	public string platformRootedPath;

	public string workshopDirectory;

	public string url;

	public readonly string displayName;

	public FileMetadata(FileInfo fileInfo, FileSource fileSource, FileType fileType)
	{
		displayName = Path.GetFileNameWithoutExtension(fileInfo.Name);
		platformRootedPath = fileInfo.FullName;
		dateLastWritten = fileInfo.LastWriteTimeUtc;
		extension = fileInfo.Extension;
		this.fileSource = fileSource;
		this.fileType = fileType;
	}

	public FileMetadata(string platformRootedPath, FileSource fileSource, FileType fileType)
	{
		this.platformRootedPath = platformRootedPath;
		displayName = Path.GetFileNameWithoutExtension(platformRootedPath);
		extension = Path.GetExtension(platformRootedPath);
		this.fileSource = fileSource;
		this.fileType = fileType;
	}

	public override string ToString()
	{
		return $"DisplayName:{displayName} Extension:{extension} Source:{fileSource} PlatformRootedPath:{platformRootedPath}";
	}
}
