using UnityEngine;

public class RandomPichShiftOnStart : MonoBehaviour
{
	public AudioSource target;

	public float radius = 0.075f;

	private void Awake()
	{
		target.pitch += Random.Range(0f - radius, radius);
		target.Play();
	}
}
