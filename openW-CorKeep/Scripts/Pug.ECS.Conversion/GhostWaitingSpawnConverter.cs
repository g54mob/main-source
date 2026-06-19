using Pug.Conversion;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

public class GhostWaitingSpawnConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		if (!base.IsServer && TryGetActiveComponent<GhostAuthoringComponent>(authoring, out var _))
		{
			Entity entity = CreateAdditionalEntity(base.PrimaryEntity);
			AddComponentData(entity, new GhostWaitingSpawnInitCD
			{
				mainEntity = base.PrimaryEntity
			});
			EnsureHasComponent<GhostWaitingSpawnCD>();
		}
	}
}
