using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.App.Scripts.Objects.Enemies.DLC7;

public class LEMON_BOSS_TheWall : EnemyControllerBoss
{
	protected override void UpdateBaseHealth()
	{
		//IL_0089: Invalid comparison between I4 and F4
		GameManager core = GM.Core;
		float num = _hp + _hp;
		if ((_hp = num * core._bossHealthMultiplier) > _maxHp)
		{
			_hp = _maxHp;
		}
		if (!(0f < _hp))
		{
			Die();
		}
	}
}
