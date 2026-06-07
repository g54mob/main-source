namespace MiscUtil.Linq
{
	public interface IFuture<T>
	{
		T Value { get; }
	}
}
