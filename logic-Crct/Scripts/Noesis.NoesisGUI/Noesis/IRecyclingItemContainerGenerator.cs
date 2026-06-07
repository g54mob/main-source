namespace Noesis
{
	public interface IRecyclingItemContainerGenerator : IItemContainerGenerator
	{
		void Recycle(GeneratorPosition position, int count);
	}
}
