using Pug.Conversion;
using UnityEngine;

public class MinionConverter : SingleAuthoringComponentConverter<MinionAuthoring>
{
	protected override void Convert(MinionAuthoring authoring)
	{
		AddComponentData(new MinionCD
		{
			damageMultiplier = authoring.damageMultiplier,
			isFlying = authoring.TryGetComponent<IsFlyingAuthoring>(out var _)
		});
		if (authoring.hasMiningAttack)
		{
			if (TryGetActiveComponent<MeleeAttackStateAuthoring>(authoring, out var _))
			{
				AddComponentData(new MiningMinionCD
				{
					damageMultiplier = authoring.miningDamageMultiplier
				});
			}
			else
			{
				Debug.LogError("Minion " + authoring.name + " has mining attack enabled but is missing MeleeAttackStateAuthoring component. Proceeding without mining attack.");
			}
		}
		EnsureHasComponent<MinionLevelCD>();
		EnsureHasComponent<OwnerReferenceCD>();
		EnsureHasComponent<DontDisableCD>();
		EnsureHasComponent<CurrentTileCD>();
	}
}
