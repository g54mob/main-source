using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects
{
	public class WindSock : MonoBehaviour
	{
		[SerializeField]
		private float _magicForceMultiplier = 1f;

		private float _realSineAmp = 0.25f;

		private Rigidbody _rigidbody;

		[SerializeField]
		private float _sineAmplitude = 0.25f;

		private float _sineFrequency;

		private float _sineInput;

		protected virtual void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		protected virtual void FixedUpdate()
		{
			_sineFrequency = FlightSceneScript.Instance.WindManager.WindVelocity.magnitude / 7.5f;
			_realSineAmp = FlightSceneScript.Instance.WindManager.WindVelocity.magnitude / 50f * _sineAmplitude;
			_sineInput += _sineFrequency * Time.fixedDeltaTime + Random.Range(-1f, 1f);
			float num = 1f + _realSineAmp * Mathf.Sin(_sineInput);
			_rigidbody.AddForce(FlightSceneScript.Instance.WindManager.WindVelocity * _magicForceMultiplier * num);
		}
	}
}
