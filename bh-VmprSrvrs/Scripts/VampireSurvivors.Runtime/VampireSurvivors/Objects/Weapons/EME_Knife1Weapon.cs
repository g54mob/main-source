using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Knife1Weapon : EME_Weapon
	{
		[SerializeField]
		protected Projectile _MoonfallPrefab;

		[SerializeField]
		protected Projectile _KaleidoscopePrefab;

		protected BulletPool _moonfallPool;

		protected BulletPool _kaleidoscopePool;

		protected override int EvolutionLevel => 0;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		protected override int ComboIndexFinal => 0;

		protected virtual bool IsEvolved => false;

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override void OnStart()
		{
		}

		public void DoMoonfall(float2 position)
		{
		}

		public void DoKaleidoscope(float2 position)
		{
		}

		protected override float CalcCritMul()
		{
			return 0f;
		}

		private void ActivateKnifeInvul()
		{
		}
	}
}
