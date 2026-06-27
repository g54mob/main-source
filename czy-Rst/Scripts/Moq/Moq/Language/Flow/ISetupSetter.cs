using System.ComponentModel;

namespace Moq.Language.Flow
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ISetupSetter<TMock, TProperty> : ICallbackSetter<TProperty>, IFluentInterface, ICallbackResult, ICallBase, ICallBaseResult, IThrows, IThrowsResult, IOccurrence, IVerifies, IRaise<TMock> where TMock : class
	{
	}
}
