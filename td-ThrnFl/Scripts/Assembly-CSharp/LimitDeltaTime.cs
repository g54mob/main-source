using UnityEngine;

public class LimitDeltaTime : MonoBehaviour
{
	public float maxDeltaTimeInMs = 16f;

	private void Start()
	{
		Time.maximumDeltaTime = maxDeltaTimeInMs / 1000f;
	}
}
