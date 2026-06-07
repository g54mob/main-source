using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioCamera : MonoBehaviour
{
	private float _minZoom = 6f;

	private float _maxZoom = 14f;

	private float _maxDistance = 15f;

	private float _minVolume;

	private float _maxVolume = 1f;

	private AudioSource audioSource;

	private Camera cam;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		cam = Camera.main;
	}

	private void Update()
	{
		float orthographicSize = cam.orthographicSize;
		float num = Mathf.Abs(base.transform.position.x - cam.transform.position.x);
		if (num > _maxDistance || orthographicSize > _maxZoom)
		{
			audioSource.volume = 0f;
			return;
		}
		float num2 = Mathf.InverseLerp(_maxZoom, _minZoom, orthographicSize) / 2f;
		float num3 = Mathf.Clamp01(1f - num / _maxDistance);
		float t = num2 * num3;
		float volume = Mathf.Lerp(_minVolume, _maxVolume, t);
		audioSource.volume = volume;
	}
}
