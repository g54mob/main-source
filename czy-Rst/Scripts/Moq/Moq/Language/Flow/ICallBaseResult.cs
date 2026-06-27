using System.ComponentModel;

namespace Moq.Language.Flow
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICallBaseResult : IThrows, IFluentInterface, IThrowsResult, IOccurrence, IVerifies
	{
	}
}
