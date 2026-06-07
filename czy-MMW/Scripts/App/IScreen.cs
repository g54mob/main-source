using System.Collections.Generic;
using Client;

public interface IScreen
{
	void Tick(float deltaTime);

	void Enable(bool shouldBeVisible);

	void TransitionIn(ScreenStack.MotorwaysScreen outScreen);

	void TransitionOut(ScreenStack.MotorwaysScreen inScreen);

	float TransitionInPercentage();

	float TransitionOutPercentage();

	bool IsTransitioningIn();

	bool IsTransitioningOut();

	void OnTransitionedIn();

	void OnTransitionedOut();

	void OnGainedFocus();

	void OnLostFocus();

	void RegisterAdditionalThemeComponents(List<IThemeComponent> additionalThemeComponents);

	void UnregisterAdditionalThemeComponents(List<IThemeComponent> additionalThemeComponents);

	bool IsVisible();

	bool CanTransitionIn();

	void BackActivated();

	bool CanPopScreen();
}
