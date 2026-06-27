using System.ComponentModel;

namespace Moq.Language.Flow
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IReturnsThrows<TMock, TResult> : IReturns<TMock, TResult>, IFluentInterface, IThrows where TMock : class
	{
	}
}
