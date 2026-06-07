using Coherence.Entities;

namespace Coherence.Core
{
	public interface IEntityRegistry
	{
		bool EntityExists(in Entity entity);
	}
}
