using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Weapon : Weapon
	{
		[Header("Glimmer Visual Prefabs")]
		[SerializeField]
		[Tooltip("Prefab for the first glimmer projectile. Shouldn't be left blank.")]
		protected Projectile _Glimmer1Prefab;

		[SerializeField]
		[Tooltip("Prefab for the second glimmer projectile. Can be left blank.")]
		protected Projectile _Glimmer2Prefab;

		[SerializeField]
		[Tooltip("Prefab for the third glimmer projectile. Can be left blank.")]
		protected Projectile _Glimmer3Prefab;

		[Header("Pre-Unlock Mechanics")]
		private float timeBeforeGlimmer;

		private const float FIVE_SECOND_TIMER = 5000f;

		private float finalGlimmerTimer;

		private Timer glimmerUnlockTimer;

		private bool glimmerUnlocked;

		protected BulletPool _glimmer1Pool;

		protected BulletPool _glimmer2Pool;

		protected BulletPool _glimmer3Pool;

		private static List<TechniqueUsage> s_techniqueUsages;

		private static float s_lastUpdateTime;

		protected bool _hasGlimmeredFirstTime;

		protected bool _hasProcessedFirstGlimmer;

		protected bool _hasSentFirstGlimmer;

		protected bool _hasAddedEvo;

		protected bool _hasEvolution;

		protected bool _ShouldGlimmerNextFire;

		protected float _glimmerChance;

		protected int _fireCounter;

		protected int _lastFiredGlimmerLevel;

		private readonly Dictionary<WeaponType, string> _glimmerNames;

		public int OwnerComboModifier;

		private bool _forceGlimmer;

		public const int DefaultPoolSize = 20;

		protected virtual int GlimmerTier => 0;

		protected virtual float GlimmerChanceBaseValue => 0f;

		protected virtual float GlimmerChanceEntropyValue => 0f;

		protected virtual int EvolutionLevel => 0;

		protected virtual int _comboIndex1 => 0;

		protected virtual int _comboIndex2 => 0;

		protected virtual int _comboIndex3 => 0;

		protected int ComboIndex1 => 0;

		protected int ComboIndex2 => 0;

		protected int ComboIndex3 => 0;

		protected virtual int ComboIndexFinal => 0;

		protected override int ProjectilePoolSize => 0;

		protected virtual bool CanWeaponGlimmer => false;

		protected virtual WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override void OnStart()
		{
		}

		protected virtual void InitGlimmer1BulletPool()
		{
		}

		protected virtual void InitGlimmer2BulletPool()
		{
		}

		protected virtual void InitGlimmer3BulletPool()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public void SetGlimmerFirstTimeOnline()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected virtual void Fire_DoTargeting()
		{
		}

		protected virtual void Fire_DoAttacks(BulletPool glimmerPool, bool skipTriggers = false)
		{
		}

		protected virtual void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		protected virtual void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		protected virtual BulletPool GetGlimmerBulletPool(int index, out int glimmerLevel, bool forcedGlimmer = false)
		{
			glimmerLevel = default(int);
			return null;
		}

		protected bool GlimmerChecks()
		{
			return false;
		}

		protected virtual float FinalGlimmerChance()
		{
			return 0f;
		}

		public override bool LevelUp()
		{
			return false;
		}

		protected virtual bool AddEvolutionChecks()
		{
			return false;
		}

		protected virtual BulletPool GetTopLevelTechnique()
		{
			return null;
		}

		protected virtual int GetTopLevelTechniqueComboIndex()
		{
			return 0;
		}

		public List<EnemyController> Closest(VampireSurvivors.Objects.Characters.CharacterController source, PhysicsGroup targets)
		{
			return null;
		}

		private string GetGlimmerName(WeaponType weaponType)
		{
			return null;
		}

		private void RunGlimmerAnimation()
		{
		}

		private bool HandleAnyTechniqueTriggers(BulletPool glimmerPool, int glimmerLevel, bool isGlimmering)
		{
			return false;
		}

		public override void Cleanup()
		{
		}
	}
}
