using System;
using System.ComponentModel;
using Moq.Language.Flow;

namespace Moq.Language
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICallbackSetter<TProperty> : IFluentInterface
	{
		ICallbackResult Callback(Action<TProperty> action);
	}
}
