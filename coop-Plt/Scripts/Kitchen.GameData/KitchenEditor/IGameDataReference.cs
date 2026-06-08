using KitchenData;

namespace KitchenEditor
{
	public interface IGameDataReference
	{
		GameDataObject RefersTo { get; }
	}
}
