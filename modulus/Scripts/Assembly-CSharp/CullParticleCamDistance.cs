using UnityEngine;

public class CullParticleCamDistance : MonoBehaviour
{
	private const float CULL_DISTANCE_TO_CAMERA = 70f;

	[SerializeField]
	private ParticleSystem _particleSystem;

	private Transform _mainCamTransform;

	private void Awake()
	{
		_mainCamTransform = Camera.main.transform;
	}

	private void Update()
	{
		bool flag = (base.transform.position - _mainCamTransform.position).magnitude > 70f;
		if (flag && _particleSystem.isPlaying)
		{
			_particleSystem.Pause();
		}
		else if (!flag && !_particleSystem.isPlaying)
		{
			_particleSystem.Play();
		}
	}
}
