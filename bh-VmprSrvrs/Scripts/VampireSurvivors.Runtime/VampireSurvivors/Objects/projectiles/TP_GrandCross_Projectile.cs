using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_GrandCross_Projectile : Projectile
	{
		[SerializeField]
		private MeshRenderer _PropellerMesh;

		[SerializeField]
		private Transform _Propeller;

		[SerializeField]
		private Transform _Pivot;

		private TP_GrandCross_Weapon _crossbowCrash;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _moveXTween;

		private MultiTargetTween _moveYTween;

		private float _speedXDuration;

		private float _pivotRotation;

		private TweenerCore<float, float, FloatOptions> pivotRotationTween;

		public float offsetX;

		public float offsetY;

		public float targetX;

		public float targetY;

		public float scaleOffsetX;

		private float _bodyPixelSize;

		private float _propellerScale;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void moveToTargetX()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
