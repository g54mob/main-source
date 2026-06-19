using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

namespace Pug.Conversion
{
	public interface IGhostConfigOverride
	{
		void OverrideGhostConfig(GameObject authoring, EntityManager entityManager, Entity entity, ref GhostPrefabCreation.Config config);
	}
}
