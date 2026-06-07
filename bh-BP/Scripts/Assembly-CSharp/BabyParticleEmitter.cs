using UnityEngine;

public class BabyParticleEmitter : MonoBehaviour
{
	public TrailPartType Type;

	public float emissionRate;

	private Vector3 lastEmitPos;

	private Vector3 lastTrackPos;

	private float distanceAccum;

	private void Start()
	{
	}

	public void ResetPosition()
	{
	}

	private void LateUpdate()
	{
	}
}
