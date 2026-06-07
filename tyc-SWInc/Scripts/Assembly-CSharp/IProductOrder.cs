public interface IProductOrder : IReferenceFix
{
	void RemoveFromStorage();

	int GetAtlasIndex();
}
