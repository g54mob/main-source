namespace MathNet.Numerics.Providers
{
	public interface IProviderCreator<T> where T : class
	{
		T CreateProvider();
	}
}
