using System.ComponentModel;

namespace Moq.Language.Flow
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ISetupGetter<TMock, TProperty> : ICallbackGetter<TMock, TProperty>, IFluentInterface, IReturnsThrowsGetter<TMock, TProperty>, IReturnsGetter<TMock, TProperty>, IThrows, IVerifies where TMock : class
	{
	}
}
