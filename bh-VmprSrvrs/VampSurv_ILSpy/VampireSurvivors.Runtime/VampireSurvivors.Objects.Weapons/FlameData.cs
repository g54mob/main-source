using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Weapons;

public class FlameData
{
	public bool active;

	public PhaserSprite flameSprite;

	public MultiTargetTween flameTweenIn;

	public MultiTargetTween flameTweenOut;
}
