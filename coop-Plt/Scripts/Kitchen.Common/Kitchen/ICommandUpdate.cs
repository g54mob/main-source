using Controllers;
using MessagePack;

namespace Kitchen
{
	[AutoUnion]
	public interface ICommandUpdate
	{
		[Key(0)]
		SourceIdentifier SourceIdentifier { get; }
	}
}
