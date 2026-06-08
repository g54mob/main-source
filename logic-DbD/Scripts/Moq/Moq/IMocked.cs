using System.ComponentModel;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IMocked<T> : IMocked where T : class
	{
		new Mock<T> Mock { get; }
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IMocked
	{
		Mock Mock { get; }
	}
}
