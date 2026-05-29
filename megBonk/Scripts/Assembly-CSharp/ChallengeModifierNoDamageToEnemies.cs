using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

[CreateAssetMenu(menuName = "Me/Progression/Challenge/ChallengeModifiers/No damage to enemies", order = 1)]
public class ChallengeModifierNoDamageToEnemies : ChallengeModifier
{
	public override void Init(ChallengeData challengeData)
	{
	}

	public override void Cleanup()
	{
	}

	private void OnDamageEnemy(Enemy arg1, DamageContainer arg2)
	{
	}
}
