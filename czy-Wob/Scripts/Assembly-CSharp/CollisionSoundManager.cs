using UnityEngine;

public class CollisionSoundManager : MonoBehaviour
{
	public string audioName = "thump";

	private float minSeparationRate = 0.1f;

	private float lastTime;

	public bool CanPlayCollisionSound()
	{
		if (Time.realtimeSinceStartup - lastTime < minSeparationRate)
		{
			return false;
		}
		return true;
	}

	public void OnCollisionSoundPlayed()
	{
		lastTime = Time.realtimeSinceStartup;
	}
}
