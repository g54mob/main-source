public interface IPoolable
{
	void OnAllocation(IPoolSystem pool);

	void OnOccupied();

	void OnFree();
}
