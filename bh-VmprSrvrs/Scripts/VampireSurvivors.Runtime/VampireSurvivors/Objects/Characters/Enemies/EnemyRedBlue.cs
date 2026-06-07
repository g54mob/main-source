using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyRedBlue : EnemyController
	{
		protected bool _isBlue;

		protected bool _isRed;

		protected bool _invertFlip;

		protected float _defaultScale;

		public static readonly List<WeaponType> BlueWeapons;

		public static readonly List<WeaponType> RedWeapons;

		protected virtual List<uint> Tints { get; }

		protected override void OnUpdate()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void OnMusicBeat()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnRecycleEnemy()
		{
		}

		public virtual void TurnBlue()
		{
		}

		public virtual void TurnRed()
		{
		}

		private static float Approach(float start, float end, float shift)
		{
			return 0f;
		}
	}
}
