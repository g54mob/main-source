namespace VampireSurvivors.Objects.Stages;

public class Background5_Adventure : Background5
{
	protected override bool AlwaysSpawnEnder => true;

	protected override bool DropGospel => false;

	protected override float EnderShieldTime => 10000f;
}
