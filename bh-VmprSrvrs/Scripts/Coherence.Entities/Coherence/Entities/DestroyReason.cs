using System.ComponentModel;

namespace Coherence.Entities
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum DestroyReason : byte
	{
		BadReason = 0,
		ClientDestroy = 1,
		DuplicateDestroy = 2,
		QueryMoved = 3,
		MaxEntitiesReached = 4,
		MaxQueriesReached = 5,
		UnauthorizedCreate = 6
	}
}
