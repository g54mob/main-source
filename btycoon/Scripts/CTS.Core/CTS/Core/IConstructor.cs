namespace CTS.Core
{
	public interface IConstructor<in T>
	{
		void Construct(T instance);
	}
}
