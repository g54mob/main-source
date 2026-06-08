using System.ComponentModel;

namespace Moq.Language.Flow
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IReturnsThrowsGetter<TMock, TProperty> : IReturnsGetter<TMock, TProperty>, IFluentInterface, IThrows where TMock : class
	{
	}
}
