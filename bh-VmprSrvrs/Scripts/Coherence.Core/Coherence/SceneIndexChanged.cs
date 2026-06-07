using Coherence.Entities;

namespace Coherence
{
	public struct SceneIndexChanged
	{
		public Entity EntityID;

		public int SceneIndex;

		public SceneIndexChanged(Entity entityID, int sceneIndex)
		{
			EntityID = default(Entity);
			SceneIndex = 0;
		}
	}
}
