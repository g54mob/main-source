public interface IGracePeriodDamager
{
	void OnDamageGracePeriodEnd(PlayerController player);

	bool DamagerIsValid();
}
