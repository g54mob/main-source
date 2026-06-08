using System;
using System.ComponentModel;
using Moq.Language.Flow;

namespace Moq.Language
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICallbackGetter<TMock, TProperty> : IFluentInterface where TMock : class
	{
		IReturnsThrowsGetter<TMock, TProperty> Callback(Action action);
	}
}
