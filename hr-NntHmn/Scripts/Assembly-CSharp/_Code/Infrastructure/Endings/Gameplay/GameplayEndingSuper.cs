namespace _Code.Infrastructure.Endings.Gameplay
{
	public sealed class GameplayEndingSuper : AGameplayEnding
	{
		public override int Priority => 0;

		public override EEnding Ending => default(EEnding);

		public override bool AreConditionsMet => false;

		protected override void TriggerInner()
		{
		}
	}
}
