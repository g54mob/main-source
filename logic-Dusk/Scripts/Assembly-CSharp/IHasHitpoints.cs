public interface IHasHitpoints
{
	float TotalHitpoints { get; }

	float CurrentHitPoints { get; }

	bool IsDead { get; }
}
