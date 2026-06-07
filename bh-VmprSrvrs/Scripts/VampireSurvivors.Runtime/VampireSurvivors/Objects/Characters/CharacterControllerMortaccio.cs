using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerMortaccio : CharacterController
	{
		private bool _isMorphed;

		private int _amountBonus;

		private int _armorBonus;

		private int _maxHpBonus;

		private PhaserSprite _sparkSprite;

		private PhaserSprite _ringSprite;

		private PhaserSprite _burstSprite;

		private PhaserSprite _darkSprite;

		private PhaserSprite _head;

		private SpriteAnimation _burstSpriteAnim;

		private SpriteAnimation _headSpriteAnim;

		private MultiTargetTween _ringTween;

		private MultiTargetTween _sparkTween;

		private MultiTargetTween _darkTween;

		private readonly float2 _headOffset;

		private readonly float2 _invHeadOffset;

		private bool _morphSpritesHidden;

		public bool IsMorphed => false;

		protected override void OnUpdate()
		{
		}

		public override void LevelUp()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		private void MakeBigSkeleton()
		{
		}

		private void Morph()
		{
		}

		private void PlaySparkle()
		{
		}

		public override void Revive(float percentage = 1f, bool instantRevival = false)
		{
		}

		public override void OnDeath()
		{
		}

		public override void SetExtraVisualsVisible(bool show)
		{
		}
	}
}
