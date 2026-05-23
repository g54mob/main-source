using UnityEngine;

public class StackingFoodSound : MonoBehaviour
{
	private bool soundPlayed;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!soundPlayed)
		{
			AudioManager.S.PlaySFX(AudioManager.S.foodStacked);
			soundPlayed = true;
		}
	}
}
