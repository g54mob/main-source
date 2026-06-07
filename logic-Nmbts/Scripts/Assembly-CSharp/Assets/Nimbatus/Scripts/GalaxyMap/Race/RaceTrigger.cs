using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	public class RaceTrigger : MonoBehaviour
	{
		private AudioObject _audioLoop;

		private bool _isPlaying;

		[HideInInspector]
		public List<DronePart> Colliders;

		protected virtual void Start()
		{
			Colliders = new List<DronePart>();
		}

		protected virtual void Update()
		{
			foreach (DronePart item in Colliders.ToList())
			{
				if (item == null || item.HealthPool.IsDead || item.IsBroken)
				{
					Colliders.Remove(item);
				}
			}
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.layer == 9 || other.gameObject.layer == 27)
			{
				Colliders.Add(other.GetComponent<DronePart>());
			}
		}

		protected virtual void OnTriggerExit(Collider other)
		{
			if (other.gameObject.layer == 9 || other.gameObject.layer == 27)
			{
				Colliders.Remove(other.GetComponent<DronePart>());
			}
		}

		internal AudioObject PlaySound(string sound)
		{
			if (string.IsNullOrEmpty(sound))
			{
				return null;
			}
			return AudioController.Play(sound, base.transform);
		}

		internal void StopSound(string sound)
		{
			if (!string.IsNullOrEmpty(sound))
			{
				AudioController.Stop(sound);
			}
		}

		internal void StartSoundLoop(string sound, float volume = 1f)
		{
			if (!_isPlaying && !string.IsNullOrEmpty(sound) && (!(_audioLoop != null) || !_audioLoop.IsPlaying()))
			{
				_audioLoop = AudioController.Play(sound, base.transform, volume);
				_isPlaying = true;
			}
		}

		internal void StopSoundLoop()
		{
			if (_isPlaying)
			{
				if (_audioLoop != null)
				{
					_audioLoop.Stop(0.1f);
					_isPlaying = false;
				}
				_isPlaying = false;
			}
		}
	}
}
