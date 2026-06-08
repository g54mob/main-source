using System;
using System.ComponentModel;
using Moq.Language.Flow;

namespace Moq.Language
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IReturnsGetter<TMock, TProperty> : IFluentInterface where TMock : class
	{
		IReturnsResult<TMock> Returns(TProperty value);

		IReturnsResult<TMock> Returns(Func<TProperty> valueFunction);

		IReturnsResult<TMock> CallBase();
	}
}
