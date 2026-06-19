using UnityEngine;

namespace Enemy
{
	public class EnemyPlaneCrashCleanup : MonoBehaviour
	{
		[Header("Trigger")]
		[Tooltip("World Y position below which the plane is considered down.")]
		[SerializeField]
		private float _altitudeThreshold;

		[Tooltip("Transform to watch. Defaults to this object when empty.")]
		[SerializeField]
		private Transform _trackedTransform;

		[Header("Audio")]
		[Tooltip("All audio sources detached and faded out when the plane goes down.")]
		[SerializeField]
		private AudioSource[] _audioSources;

		[Tooltip("Seconds the detached audio takes to fade to silence.")]
		[SerializeField]
		private float _fadeDuration = 4f;

		[Header("Cleanup")]
		[Tooltip("GameObject disabled once the plane is down. Defaults to this object.")]
		[SerializeField]
		private GameObject _objectToDisable;

		[Tooltip("Delay before disabling (lets explosion VFX play out).")]
		[SerializeField]
		private float _disableDelay;

		private bool _triggered;

		private void Awake()
		{
			if (_trackedTransform == null)
			{
				_trackedTransform = base.transform;
			}
			if (_objectToDisable == null)
			{
				_objectToDisable = base.gameObject;
			}
		}

		private void Update()
		{
			if (!_triggered && _trackedTransform.position.y <= _altitudeThreshold)
			{
				HandleDown();
			}
		}

		public void HandleDown()
		{
			if (!_triggered)
			{
				_triggered = true;
				DetachAndFadeAudio();
				if (_disableDelay > 0f)
				{
					Invoke("DisableObject", _disableDelay);
				}
				else
				{
					DisableObject();
				}
			}
		}

		private void DetachAndFadeAudio()
		{
			if (_audioSources == null)
			{
				return;
			}
			AudioSource[] audioSources = _audioSources;
			foreach (AudioSource audioSource in audioSources)
			{
				if (!(audioSource == null))
				{
					audioSource.transform.SetParent(null, worldPositionStays: true);
					DetachableAudioFadeOut detachableAudioFadeOut = audioSource.GetComponent<DetachableAudioFadeOut>();
					if (detachableAudioFadeOut == null)
					{
						detachableAudioFadeOut = audioSource.gameObject.AddComponent<DetachableAudioFadeOut>();
					}
					detachableAudioFadeOut.Begin(_fadeDuration);
				}
			}
		}

		private void DisableObject()
		{
			if (_objectToDisable != null)
			{
				_objectToDisable.SetActive(value: false);
			}
		}
	}
}
