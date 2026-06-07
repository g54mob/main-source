using System.ComponentModel;

namespace Coherence.Entities
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum EntityOperation : byte
	{
		Unknown = 0,
		Create = 1,
		Update = 2,
		Destroy = 3
	}
}
