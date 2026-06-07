using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class VentProjectile : Projectile
	{
		private class VentUsageSlot
		{
			public SpriteRenderer _dummySprite;

			public MultiTargetTween _currentTween;
		}

		[SerializeField]
		private Material _dummySpriteMaterial;

		private int _uses;

		private float selfScale;

		private bool _readyForUse;

		protected PhaserSprite _ventSprite;

		protected PhaserSprite _blackHoleSprite;

		private MultiTargetTween _currentTween;

		private List<VentUsageSlot> _usageSlots;

		private int _currentlyAnimatingCount;

		private float _repeatIntervalCounter;

		public bool CanSuckMore => false;

		public PhaserSprite VentSprite => null;

		protected override void Awake()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Activate()
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		private VentUsageSlot CreateNewSlot()
		{
			return null;
		}

		public void DoVentHit(IDamageable other)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void UpdateClipping(SpriteRenderer dummySprite, float offset = 0f)
		{
		}

		private void ReturnFromVent(ArcadeSprite phaserObject, object[] tweenTargets, VentUsageSlot slot)
		{
		}

		private void UseFinished(VentUsageSlot slot)
		{
		}

		private void FadeOut()
		{
		}

		public void AddUses(int uses)
		{
		}

		public bool IsAnimating()
		{
			return false;
		}

		public override void Despawn()
		{
		}
	}
}
