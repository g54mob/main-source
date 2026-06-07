internal class DataDiskPartition
{
	public int IdPartition;

	public bool IsFormated;

	public bool IsDeleted;

	public bool CanInstallSystem;

	public int TotalSpace;

	public int FreeSpace;

	public string Name;

	public string Type;

	public DataDiskPartition(int id, string name, string type, int totalSpace, int freeSpace, bool canInstallSystem)
	{
	}

	public void FormatPartition()
	{
	}

	public void DeletePartition()
	{
	}
}
