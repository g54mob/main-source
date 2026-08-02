namespace Polarith.AI.Criteria
{
	public interface ISensor<T>
	{
		int ReceptorCount { get; }

		IReceptor<T> this[int id] { get; }

		IReceptor<T> AddReceptor();

		IReceptor<T> InsertReceptor(int id);

		IReceptor<T> GetReceptor(int id);

		void RemoveReceptorAt(int id);

		void ClearReceptors();
	}
}
