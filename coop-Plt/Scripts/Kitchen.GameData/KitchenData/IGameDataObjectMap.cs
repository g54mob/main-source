namespace KitchenData
{
	public interface IGameDataObjectMap
	{
		T Get<T>(int id) where T : GameDataObject;

		T Get<T>(T obj) where T : GameDataObject;
	}
}
