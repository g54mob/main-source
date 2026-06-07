namespace LibTessDotNet
{
	public interface ITypePool
	{
		object Get();

		void Return(object obj);
	}
}
