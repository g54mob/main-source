using UnityEngine;

namespace MalbersAnimations
{
	public class SoundBehavior : StateMachineBehaviour
	{
		[Tooltip("Game Object to Store the Audio Source Component. This allows Animation States to share the same AudioSource")]
		public string m_source = "Animator Sounds";

		public AudioClip[] sounds;

		[Tooltip("Play the sound when the Animation Starts")]
		public bool playOnEnter = true;

		[Hide("playOnEnter")]
		[Tooltip("PlayOnEnter After the transition is over")]
		public bool SkipTransition;

		[Tooltip("Loop forever the sound")]
		public bool Loop;

		[Tooltip("Stop playing if the Animation exits")]
		public bool stopOnExit;

		[Hide("playOnEnter", true)]
		[Range(0f, 1f)]
		public float PlayOnTime = 0.5f;

		[Space]
		[MinMaxRange(-3f, 3f)]
		public RangedFloat pitch = new RangedFloat(1f, 1f);

		[MinMaxRange(0f, 1f)]
		public RangedFloat volume = new RangedFloat(1f, 1f);

		private AudioSource _audio;

		private Transform audioTransform;

		public float MaxDistance = 10f;

		private bool played;

		private void CheckAudioSource(Animator animator)
		{
			if (audioTransform == null)
			{
				string text = m_source;
				if (string.IsNullOrEmpty(text))
				{
					text = "Animator Sounds";
				}
				audioTransform = animator.transform.FindGrandChild(text);
				if (!audioTransform)
				{
					GameObject gameObject = new GameObject
					{
						name = text
					};
					audioTransform = gameObject.transform;
					audioTransform.parent = animator.transform;
					audioTransform.ResetLocal();
				}
				_audio = audioTransform.GetComponent<AudioSource>();
				if (!_audio)
				{
					_audio = audioTransform.gameObject.AddComponent<AudioSource>();
					_audio.spatialBlend = 1f;
					_audio.maxDistance = MaxDistance;
				}
				_audio.playOnAwake = false;
			}
		}

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			CheckAudioSource(animator);
			played = false;
			if (playOnEnter && !SkipTransition)
			{
				PlaySound();
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!played && !animator.IsInTransition(layerIndex))
			{
				if (playOnEnter && SkipTransition)
				{
					PlaySound();
				}
				else if (stateInfo.normalizedTime > PlayOnTime)
				{
					PlaySound();
				}
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (stopOnExit && (bool)_audio && animator.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash != stateInfo.fullPathHash)
			{
				_audio?.Stop();
				_audio.clip = null;
			}
		}

		public virtual void PlaySound()
		{
			if (!_audio || !_audio.enabled || sounds.Length == 0)
			{
				return;
			}
			AudioClip audioClip = sounds[Random.Range(0, sounds.Length)];
			if (_audio.loop && audioClip == _audio.clip)
			{
				played = true;
				return;
			}
			if (_audio.isPlaying)
			{
				_audio.Stop();
			}
			_audio.clip = audioClip;
			if (audioClip != null)
			{
				_audio.pitch = pitch.RandomValue;
				_audio.volume = volume.RandomValue;
				_audio.loop = Loop;
				_audio.Play();
			}
			played = true;
		}
	}
}
