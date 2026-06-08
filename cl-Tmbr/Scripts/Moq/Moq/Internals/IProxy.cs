using System.ComponentModel;

namespace Moq.Internals
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IProxy
	{
		object Interceptor { get; }
	}
}
