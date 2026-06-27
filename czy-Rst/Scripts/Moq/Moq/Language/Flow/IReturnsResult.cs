using System.ComponentModel;

namespace Moq.Language.Flow
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IReturnsResult<TMock> : ICallback, IFluentInterface, IOccurrence, IRaise<TMock>, IVerifies
	{
	}
}
