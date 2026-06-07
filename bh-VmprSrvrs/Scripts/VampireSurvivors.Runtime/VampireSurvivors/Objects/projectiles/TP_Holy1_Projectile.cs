using DG.Tweening;
using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Holy1_Projectile : Projectile
	{
		private const float Radius = 32f;

		private const float CrossOffsetY = 0.44f;

		private const float CrossBGScale = 1.1f;

		private const float FadeDuration = 250f;

		private PhaserSprite _areaSprite;

		private PhaserSprite _crossSprite;

		private PhaserSprite _crossSprite2;

		private PhaserSprite _crossSpriteBG;

		private PhaserSprite _crossSpriteBG2;

		private Tween _scaleTween;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _crossTween;

		private MultiTargetTween _crossTween2;

		private const float MaxAlpha = 0.8f;

		private Timer _expireTimer;

		private Timer _hitboxTimer;

		private Timer _healTimer;

		private TP_Holy1_Weapon _parentWeapon;

		private bool _geminiProjectile;

		private float2 _initialPos;

		private float[] _requiemRandomOffsets;

		private int _requiemRandomIndex;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void DoCrossAnim()
		{
		}

		public override void Despawn()
		{
		}

		private void StartDespawn()
		{
		}

		private void HealPlayersInArea()
		{
		}

		private bool IsCharacterInRange(CharacterController character)
		{
			return false;
		}
	}
}
