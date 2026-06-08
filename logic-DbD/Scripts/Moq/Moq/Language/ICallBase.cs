using System.ComponentModel;
using Moq.Language.Flow;

namespace Moq.Language
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICallBase : IFluentInterface
	{
		ICallBaseResult CallBase();
	}
}
