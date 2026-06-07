namespace VoxelBusters.CoreLibrary
{
	public interface IJsonServiceProvider
	{
		string ToJson(object obj);

		object FromJson(string jsonString);
	}
}
