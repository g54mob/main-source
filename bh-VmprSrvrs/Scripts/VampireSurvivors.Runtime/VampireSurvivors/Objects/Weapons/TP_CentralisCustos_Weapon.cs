using DG.Tweening;
using TMPro;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_CentralisCustos_Weapon : Weapon
	{
		[SerializeField]
		private SpriteRenderer _AreaRenderer;

		[SerializeField]
		private SpriteRenderer _HeadRenderer;

		[SerializeField]
		private SpriteRenderer _HeadEnrageEffect;

		[SerializeField]
		private Transform _HeadScaler;

		[SerializeField]
		private bool _enableDebugText;

		[SerializeField]
		private TMP_Text _debugText;

		private const float YPosOffset = 0.5f;

		private const float RendererScaleMultiplier = 2f;

		private const float HeadRendererScaleMultiplier = 1f;

		private SpriteAnimation _headAnim;

		private const int AnimFPS = 20;

		private const float BonusStatsDuration = 2500f;

		private const float BonusArmor = 10f;

		private const float BonusRegen = 2f;

		private const float BonusCooldown = 0.1f;

		private const int StatBonusStackLimit = 1;

		private int _numStatBonusStacks;

		private Timer _bonusRetriggerTimer;

		private const float BonusRetriggerTime = 1000f;

		private bool _bonusCanTrigger;

		private Tween _rotateTweenHandle;

		private Tween _headRotateTween;

		private Sequence _fadeTween;

		private MultiTargetTween _headAlphaTween;

		private MultiTargetTween _headScaleXTween;

		private MultiTargetTween _headScaleYTween;

		private MultiTargetTween _headEnrageTween;

		private const float HeadDefaultAlpha = 0.6f;

		public override float PArea()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Cleanup()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override void ResetFiringTimer()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		private void OnPlayerDamaged()
		{
		}

		private void ApplyStatBonuses(bool addStats = true)
		{
		}

		private void StartLoopingAlphaTween()
		{
		}

		private void DoScreenShake()
		{
		}

		private void UpdatePosition()
		{
		}

		private void UpdateRenderersScaleToArea()
		{
		}

		private void UpdateDebugTextVisibility()
		{
		}

		private float AlphaFromScale(float weaponArea, float maxScale, float minAlpha)
		{
			return 0f;
		}
	}
}
