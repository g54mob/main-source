namespace Bindito.Core
{
	public interface IProvider<out T>
	{
		T Get();
	}
}
