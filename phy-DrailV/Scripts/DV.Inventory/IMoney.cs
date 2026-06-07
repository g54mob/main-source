using UnityEngine;

public interface IMoney
{
	double Amount { get; set; }

	bool ShouldDestroyOnUse { get; }

	AudioClip AddToInventorySound { get; }

	bool SoundAlreadyPlayed { get; set; }

	GameObject gameObject { get; }

	double TrySpend(double amountToSpend);
}
