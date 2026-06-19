namespace Aggro.Core
{
	public interface IValueTypeList<T> where T : struct
	{
		int Count { get; }

		T this[int index] { get; set; }

		unsafe void* GetUnsafePtr();
	}
}
