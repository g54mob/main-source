using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.Fracturing
{
	public class LightFlickerScript : MonoBehaviour
	{
		[Tooltip("Maximum random light intensity")]
		[SerializeField]
		private float _maxIntensity = 1f;

		[Tooltip("Minimum random light intensity")]
		[SerializeField]
		private float _minIntensity;

		[Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
		[Range(1f, 50f)]
		[SerializeField]
		private int _smoothing = 5;

		private float _lastSum;

		private Queue<float> _smoothQueue;

		private Light _light;

		private void Start()
		{
			_smoothQueue = new Queue<float>(_smoothing);
			_light = GetComponent<Light>();
		}

		private void Update()
		{
			while (_smoothQueue.Count >= _smoothing)
			{
				_lastSum -= _smoothQueue.Dequeue();
			}
			float num = Random.Range(_minIntensity, _maxIntensity);
			_smoothQueue.Enqueue(num);
			_lastSum += num;
			_light.intensity = _lastSum / (float)_smoothQueue.Count;
		}
	}
}
