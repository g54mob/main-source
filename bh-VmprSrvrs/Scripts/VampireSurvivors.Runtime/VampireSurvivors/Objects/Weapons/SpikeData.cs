using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Weapons
{
	public class SpikeData
	{
		public bool active;

		public PhaserSprite spikeSprite;

		public MultiTargetTween spikeTweenIn;

		public MultiTargetTween spikeTweenOut;
	}
}
