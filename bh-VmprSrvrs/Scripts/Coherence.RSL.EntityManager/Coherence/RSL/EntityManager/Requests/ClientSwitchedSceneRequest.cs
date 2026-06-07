using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Requests
{
	public class ClientSwitchedSceneRequest : RequestInfo
	{
		private uint oldScene;

		private uint newScene;

		public ClientSwitchedSceneRequest(Entity entity, uint participant, FloatingOrigin origin, EntityMeta meta, bool isInternal, uint oldScene, uint newScene)
			: base(default(Entity), 0u, default(FloatingOrigin), default(EntityMeta), isInternal: false)
		{
		}

		public uint GetOldScene()
		{
			return 0u;
		}

		public uint GetNewScene()
		{
			return 0u;
		}
	}
}
