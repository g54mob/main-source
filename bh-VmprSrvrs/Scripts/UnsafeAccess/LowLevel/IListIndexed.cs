using UnityEngine.LowLevel;

namespace LowLevel
{
	public interface IListIndexed<T> where T : class, IListIndexed<T>
	{
		void SetNewIndex(ListArrayIndexed<T> arrayIndexed, int idx);
	}
}
