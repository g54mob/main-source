using System.Collections.Generic;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyCosmicEgg : EnemyRedBlue
	{
		private bool _hasGeneratedSprites;

		private bool _damageDone;

		private float _infiniteCorridorTime;

		private float _infiniteCorridorDelay;

		private float _worldScreenHeight;

		private PhaserSprite _wingL;

		private PhaserSprite _wingR;

		private PhaserSprite _eye;

		private PhaserSprite _corridorBg;

		private PhaserSprite _corridorLight;

		private MultiTargetTween _spritesDeathTween;

		private MultiTargetTween _icLightTween;

		private MultiTargetTween _icAngleTween;

		private MultiTargetTween _icScaleTween;

		private const string FrameNameEyeBlue = "CEye_i01.png";

		private const string FrameNameEyeRed = "CEyeRed_i01.png";

		private const string FrameNameEggBlue = "CEgg_i01.png";

		private const string FrameNameEggRed = "CEggRed_i01.png";

		private const string FrameNameWing = "Wing_i01.png";

		protected override List<uint> Tints { get; }

		protected override void Awake()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Disappear()
		{
		}

		protected override void Die()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnRecycleEnemy()
		{
		}

		private void GenerateSpritesAndAnimations()
		{
		}

		private void UpdateSprites()
		{
		}

		private void CastInfiniteCorridor()
		{
		}

		public override void TurnBlue()
		{
		}

		public override void TurnRed()
		{
		}
	}
}
