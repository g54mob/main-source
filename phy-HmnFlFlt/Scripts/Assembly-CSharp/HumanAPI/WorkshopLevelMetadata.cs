namespace HumanAPI
{
	public class WorkshopLevelMetadata : WorkshopItemMetadata
	{
		public string dataPath
		{
			get
			{
				return FileTools.Combine(folder, "data");
			}
		}
	}
}
