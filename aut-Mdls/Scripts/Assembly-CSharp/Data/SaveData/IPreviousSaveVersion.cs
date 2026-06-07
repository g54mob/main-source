namespace Data.SaveData
{
	public interface IPreviousSaveVersion : ISaveVersion
	{
		ISaveVersion ToNextVersion();
	}
}
