using UnityEngine;

public class TorchLight : MonoBehaviour
{
	[SerializeField]
	private float _timeOffset;

	[SerializeField]
	private float _minIntensity = 2f;

	[SerializeField]
	private float _maxIntensity = 3f;

	[SerializeField]
	private float _minRange = 5f;

	[SerializeField]
	private float _maxRange = 7f;

	[SerializeField]
	private float _changeSpeed = 3f;

	[SerializeField]
	private float _shakeIntensity = 0.05f;

	[SerializeField]
	private float _shakeSpeed = 5f;

	[SerializeField]
	private bool _localTransform;

	private Light _light;

	private float _random;

	private Vector3 _initialPosition;

	private void Start()
	{
		_random = Random.Range(0f, 65535f);
		_timeOffset = _random;
		_light = GetComponent<Light>();
		_initialPosition = base.transform.position;
	}

	private void Update()
	{
		float num = Time.time + _timeOffset;
		float t = Mathf.PerlinNoise(_random, num * _changeSpeed);
		float intensity = Mathf.Lerp(_minIntensity, _maxIntensity, t);
		float range = Mathf.Lerp(_minRange, _maxRange, t);
		_light.intensity = intensity;
		_light.range = range;
		Vector3 vector = (_localTransform ? Vector3.zero : _initialPosition) + new Vector3(Mathf.PerlinNoise(num * _shakeSpeed, 0f) - 0.5f, Mathf.PerlinNoise(0f, num * _shakeSpeed) - 0.5f, Mathf.PerlinNoise(num * _shakeSpeed, num * _shakeSpeed) - 0.5f) * (_shakeIntensity * 2f);
		if (_localTransform)
		{
			base.transform.localPosition = vector;
		}
		else
		{
			base.transform.position = vector;
		}
	}
}
