public interface IDyingBehaviour
{
	void StartDying(DeathContext context);

	void UpdateDying(DeathContext context);

	bool IsDoneDying(DeathContext context);

	void FinishedDying(DeathContext context);
}
