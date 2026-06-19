using Affixes.Authoring;
using Pug.Automation;
using Pug.Conversion;
using UnityEngine;

public class GhostEffectEventConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		if (TryGetActiveComponent<SupportAffixesAuthoring>(authoring, out var _) || TryGetActiveComponent<AttackContinuouslyAuthoring>(authoring, out var _) || TryGetActiveComponent<MinionAuthoring>(authoring, out var _) || TryGetActiveComponent<MerchantAuthoring>(authoring, out var _) || (TryGetActiveComponent<MortarProjectileAuthoring>(authoring, out var component5) && component5.isPredicted && component5.hitTiles) || TryGetActiveComponent<PlayerAuthoring>(authoring, out var _) || TryGetActiveComponent<ProjectileAuthoring>(authoring, out var _) || TryGetActiveComponent<EnemyAuthoring>(authoring, out var _) || TryGetActiveComponent<AutomatedMineableAuthoring>(authoring, out var _))
		{
			EnsureHasComponent<GhostEffectEventBufferPointerCD>();
			EnsureHasBuffer<GhostEffectEventBuffer>();
			for (int i = 0; i < 3; i++)
			{
				AddToBuffer(default(GhostEffectEventBuffer));
			}
			EnsureHasComponent<LocalEffectEventBufferPointerCD>();
			EnsureHasBuffer<LocalEffectEventBuffer>();
			for (int j = 0; j < 10; j++)
			{
				AddToBuffer(default(LocalEffectEventBuffer));
			}
		}
	}
}
