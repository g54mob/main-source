using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_TP_DeathArm : EnemyController
{
	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0083: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		baseBody._immovable = true;
		BaseBody baseBody2 = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite2 = setFrame(sprite);
	}

	protected override void Die()
	{
	}

	public override void Disappear()
	{
		base.Disappear();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		WeaponType damageType2 = default(WeaponType);
		bool hasKb2 = default(bool);
		base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
		EnemyController component = _owner.GetComponent<EnemyController>();
		component.GetDamaged(value, showHitVfx, damageKb, WeaponType.VOID, hasKb: false);
	}

	protected override void OnUpdate()
	{
	}
}
