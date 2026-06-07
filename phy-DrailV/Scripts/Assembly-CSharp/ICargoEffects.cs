public interface ICargoEffects
{
	void UpdateEffectsFlowOut(float flowOut);

	void UpdateEffectsFlowIn(float flowIn);

	void OnCargoExploded();

	void ActivateEffectsExternally(bool playRuptureSound = false);

	void ToggleRuptureVisibility(bool on);

	void AllowSpecialEffects(bool allow);

	void SetupForContent(ICargoContent cargoContent);
}
