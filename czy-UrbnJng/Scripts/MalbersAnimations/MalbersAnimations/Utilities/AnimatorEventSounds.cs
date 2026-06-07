using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Effects - Audio/Animator Event Sound")]
	public class AnimatorEventSounds : MonoBehaviour, IAnimatorListener
	{
		public List<EventSound> m_EventSound;

		public AudioSource _audioSource;

		protected Animator anim;

		public bool debug;

		Transform IAnimatorListener.transform => base.transform;

		private void Start()
		{
			anim = GetComponent<Animator>();
			if (_audioSource == null)
			{
				_audioSource = base.gameObject.AddComponent<AudioSource>();
			}
			_audioSource.volume = 0f;
		}

		public virtual void DisableSoundEvent(string SoundName)
		{
			EventSound eventSound = m_EventSound.Find((EventSound item) => item.name == SoundName);
			if (eventSound != null)
			{
				eventSound.active = false;
			}
		}

		public virtual void EnableSoundEvent(string SoundName)
		{
			EventSound eventSound = m_EventSound.Find((EventSound item) => item.name == SoundName);
			if (eventSound != null)
			{
				eventSound.active = true;
			}
		}

		public virtual void PlaySound(AnimationEvent e)
		{
			if ((double)e.animatorClipInfo.weight < 0.1)
			{
				return;
			}
			if (debug)
			{
				Debug.Log("Play Audio: Clip - [" + e.animatorClipInfo.clip.name + "]", e.animatorClipInfo.clip);
			}
			EventSound eventSound = m_EventSound.Find((EventSound item) => item.name == e.stringParameter && item.active);
			if (eventSound == null)
			{
				return;
			}
			eventSound.VolumeWeight = e.animatorClipInfo.weight;
			if ((bool)anim)
			{
				_audioSource.pitch = anim.speed;
			}
			if (_audioSource.isPlaying)
			{
				if (eventSound.VolumeWeight * eventSound.volume > _audioSource.volume)
				{
					eventSound.PlayAudio(_audioSource);
				}
			}
			else
			{
				eventSound.PlayAudio(_audioSource);
			}
		}

		public virtual void PlaySound(string sound)
		{
			EventSound eventSound = m_EventSound.Find((EventSound item) => item.name == sound && item.active);
			if (eventSound == null)
			{
				return;
			}
			eventSound.VolumeWeight = 1f;
			if (_audioSource.isPlaying)
			{
				if (eventSound.volume > _audioSource.volume)
				{
					eventSound.PlayAudio(_audioSource);
				}
			}
			else
			{
				eventSound.PlayAudio(_audioSource);
			}
		}

		public virtual void PlaySoundForever(string sound)
		{
			EventSound eventSound = m_EventSound.Find((EventSound item) => item.name == sound && item.active);
			if (eventSound != null)
			{
				eventSound.VolumeWeight = 1f;
				StartCoroutine(C_Playforever(eventSound));
			}
		}

		public virtual void StopPlaying(string sound)
		{
			EventSound eventSound = m_EventSound.Find((EventSound item) => item.name == sound && item.active);
			if (eventSound != null && eventSound.source != null && eventSound.source.isPlaying)
			{
				eventSound.source.Stop();
			}
			StopAllCoroutines();
		}

		private IEnumerator C_Playforever(EventSound E_sound)
		{
			if (E_sound.interval <= 0f)
			{
				yield return null;
				yield return null;
				yield break;
			}
			WaitForSeconds timeInterval = new WaitForSeconds(E_sound.interval);
			while (true)
			{
				E_sound.PlayAudio(_audioSource);
				yield return timeInterval;
			}
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}
	}
}
