using System.ComponentModel;

namespace Moq.Language.Flow
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ISetup<TMock> : ICallback, IFluentInterface, ICallbackResult, ICallBase, ICallBaseResult, IThrows, IThrowsResult, IOccurrence, IVerifies, IRaise<TMock> where TMock : class
	{
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ISetup<TMock, TResult> : ICallback<TMock, TResult>, IFluentInterface, IReturnsThrows<TMock, TResult>, IReturns<TMock, TResult>, IThrows, IVerifies where TMock : class
	{
	}
}
