using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyHealByFlower : EnemyController
{
	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		object obj = default(object);
		if ((nint)obj != 41)
		{
			WeaponType damageType2 = default(WeaponType);
			bool hasKb2 = default(bool);
			base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
			return;
		}
		float hp = value + _hp;
		_hp = hp;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		CharacterController activeCharacter = gameSessionData._activeCharacter;
		float xp = (float)activeCharacter._level * 0.001f;
		core.AddPlayerXp(xp);
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		GM.Core.ShowRecoveryAt(pos, value);
	}
}
