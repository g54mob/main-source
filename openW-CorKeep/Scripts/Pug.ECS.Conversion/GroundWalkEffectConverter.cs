using Pug.Conversion;
using UnityEngine;

public class GroundWalkEffectConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		if (!base.IsServer && ((TryGetActiveComponent<EnemyAuthoring>(authoring, out var _) && !TryGetActiveComponent<BossAuthoring>(authoring, out var _)) || TryGetActiveComponent<PlayerAuthoring>(authoring, out var _)))
		{
			AddComponentData(new GroundWalkEffectCD
			{
				DistanceToTriggerSq = 0.64000005f
			});
		}
	}
}
