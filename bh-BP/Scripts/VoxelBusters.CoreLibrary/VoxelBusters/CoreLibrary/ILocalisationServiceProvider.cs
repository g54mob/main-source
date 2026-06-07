namespace VoxelBusters.CoreLibrary
{
	public interface ILocalisationServiceProvider
	{
		string GetLocalisedString(string key, string defaultValue);
	}
}
