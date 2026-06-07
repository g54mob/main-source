using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects
{
	public class MorphVFX
	{
		private PhaserSprite _sparkSprite;

		private PhaserSprite _ringSprite;

		private MultiTargetTween _ringTween;

		private MultiTargetTween _sparkTween;

		private PhaserSprite _burstSprite;

		private PhaserSprite _darkSprite;

		private MultiTargetTween _darkTween;

		private float _x;

		private float _y;

		public uint[] _burstTint;

		public string _sparkName;

		public string _diskName;

		public void Make()
		{
		}

		public void PlaySparkle(CharacterController character)
		{
		}
	}
}
