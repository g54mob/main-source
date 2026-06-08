public interface IAbilityActivationProvider
{
	string GetId();

	bool IsAvailable();

	AsciiSprite GetIcon();

	bool IsEnabled();

	bool IsWaiting();

	float GetCooldownRemaining();

	SuperAbilityActivationState ActivateAbility();
}
