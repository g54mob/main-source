using System.ComponentModel;

namespace Moq.Language.Flow
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICallbackResult : ICallBase, IFluentInterface, ICallBaseResult, IThrows, IThrowsResult, IOccurrence, IVerifies
	{
	}
}
