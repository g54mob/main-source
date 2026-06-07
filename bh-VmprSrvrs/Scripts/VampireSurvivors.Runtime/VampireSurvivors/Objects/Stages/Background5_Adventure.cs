using JetBrains.Annotations;

namespace VampireSurvivors.Objects.Stages
{
	[UsedImplicitly]
	public class Background5_Adventure : Background5
	{
		protected override bool AlwaysSpawnEnder => false;

		protected override bool DropGospel => false;

		protected override float EnderShieldTime => 0f;
	}
}
