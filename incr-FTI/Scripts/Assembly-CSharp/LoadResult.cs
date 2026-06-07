public readonly struct LoadResult
{
	public readonly LoadResultStatus status;

	public readonly string displayName;

	public readonly FileSource fileSource;

	public readonly FileType fileType;

	public LoadResult(LoadResultStatus status, string displayName, FileSource fileSource, FileType fileType)
	{
		this.status = status;
		this.displayName = displayName;
		this.fileSource = fileSource;
		this.fileType = fileType;
	}
}
