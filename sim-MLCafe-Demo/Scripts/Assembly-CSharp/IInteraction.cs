using UnityEngine;

public interface IInteraction
{
	void OnInteraction()
	{
	}

	void OnPlayerInteraction(CharacterControllerComponent character)
	{
	}

	void OnPlayerHoldInteraction(CharacterControllerComponent character)
	{
	}

	void OnPlayerHoldInteractionStopped(CharacterControllerComponent character)
	{
	}

	void OnPlayerAction(CharacterControllerComponent character)
	{
	}

	bool IsInRange(Vector3 position)
	{
		return false;
	}
}
