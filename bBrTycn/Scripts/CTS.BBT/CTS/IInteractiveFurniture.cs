using CTS.BBT;

namespace CTS
{
	public interface IInteractiveFurniture : IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		Furniture Furniture { get; }

		bool CanBeUsed();
	}
}
