namespace LibTessDotNet
{
	public interface Pooled<T> where T : class, Pooled<T>, new()
	{
		void Init(IPool pool);

		void Reset(IPool pool);
	}
}
