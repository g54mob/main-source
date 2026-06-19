using System.Collections;
using UnityEngine;

namespace Items.AirDrop
{
	public class Beacon : MonoBehaviour
	{
		[Header("References")]
		[Tooltip("Volumetric light GameObject that is spun around the Y axis. Toggled on/off with the beacon.")]
		[SerializeField]
		private GameObject _beaconLight;

		[Tooltip("Audio source for the beacon sound. Looping is recommended.")]
		[SerializeField]
		private AudioSource _beaconSource;

		[Header("Settings")]
		[Tooltip("Spin speed of the light around its local Y axis, in degrees per second.")]
		[SerializeField]
		private float _rotationSpeed = 90f;

		[Tooltip("How long the beacon stays on after activation, in seconds. 0 or less = stay on forever.")]
		[SerializeField]
		private float _activeDuration = 15f;

		[Tooltip("If true the beacon activates automatically when this object is enabled.")]
		[SerializeField]
		private bool _activateOnEnable;

		private bool _isActive;

		private Coroutine _disableRoutine;

		private void Awake()
		{
			SetBeaconState(on: false);
		}

		private void OnEnable()
		{
			if (_activateOnEnable)
			{
				Activate();
			}
		}

		private void OnDisable()
		{
			_disableRoutine = null;
		}

		private void Update()
		{
			if (_isActive && _beaconLight != null)
			{
				_beaconLight.transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f, Space.Self);
			}
		}

		public void Activate()
		{
			Activate(_activeDuration);
		}

		public void Activate(float duration)
		{
			if (_disableRoutine != null)
			{
				StopCoroutine(_disableRoutine);
			}
			_disableRoutine = null;
			SetBeaconState(on: true);
			if (duration > 0f && base.gameObject.activeInHierarchy)
			{
				_disableRoutine = StartCoroutine(DisableAfter(duration));
			}
		}

		public void Deactivate()
		{
			if (_disableRoutine != null)
			{
				StopCoroutine(_disableRoutine);
			}
			_disableRoutine = null;
			SetBeaconState(on: false);
		}

		private IEnumerator DisableAfter(float duration)
		{
			yield return new WaitForSeconds(duration);
			SetBeaconState(on: false);
			_disableRoutine = null;
		}

		private void SetBeaconState(bool on)
		{
			_isActive = on;
			if (_beaconLight != null)
			{
				_beaconLight.SetActive(on);
			}
			if (_beaconSource == null)
			{
				return;
			}
			if (on)
			{
				if (!_beaconSource.isPlaying)
				{
					_beaconSource.Play();
				}
			}
			else
			{
				_beaconSource.Stop();
			}
		}
	}
}
