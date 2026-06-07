using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerRamba : CharacterController
	{
		[SerializeField]
		private bool _DebugAutoMorph;

		private const ItemType MorphRelic = ItemType.RELIC_LAZULIA;

		private const float BonusAmount = 1f;

		private const float BonusArmor = 2f;

		private const float BonusMaxHP = 100f;

		private MorphVFX _morphVFX;

		private bool _isMorphed;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _twinklePfx;

		private ParticleSystem _cartPfx;

		private PhaserSprite _cartFront;

		private PhaserSprite _cartBack;

		private MultiTargetTween _tintTween;

		private List<uint> _tints;

		private int _tintCounter;

		public bool MorphAbilityUnlocked => false;

		public bool IsMorphed => false;

		public bool EnableTintTween => false;

		public bool EnableTwinklePfx => false;

		public bool SitsOnCart => false;

		public override void LevelUp()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		private void CheckForMorph()
		{
		}

		private void MorphedOnStop()
		{
		}

		private void MakeMorphVFX()
		{
		}

		protected override void OnStop()
		{
		}

		public override void OnDeath()
		{
		}

		public override void Revive(float percentage = 1f, bool instantRevival = false)
		{
		}

		private void Morph()
		{
		}

		private void SpawnCart()
		{
		}

		private void DoTintTween()
		{
		}

		private void GenerateTwinklePfx()
		{
		}

		private void GenerateCartPfx()
		{
		}

		private void UpdateCartPfx()
		{
		}

		private void UpdateDepths()
		{
		}

		private void PlayTwinklePfx(bool play = true)
		{
		}

		public override void Despawn()
		{
		}
	}
}
