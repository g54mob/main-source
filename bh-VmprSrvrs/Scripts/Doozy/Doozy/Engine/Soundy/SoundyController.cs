using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Soundy
{
	[DefaultExecutionOrder(-100)]
	public class SoundyController : MonoBehaviour
	{
		private static List<SoundyController> s_database;

		private static bool s_pauseAllControllers;

		private static bool s_muteAllControllers;

		private Transform m_transform;

		private Transform m_followTarget;

		private AudioSource m_audioSource;

		private bool m_inUse;

		private float m_playProgress;

		private bool m_isPaused;

		private bool m_isMuted;

		private float m_lastPlayedTime;

		private bool m_isPlaying;

		private bool m_autoPaused;

		private bool m_muted;

		private bool m_paused;

		private static bool DebugComponent => false;

		public static bool PauseAllControllers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool MuteAllControllers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public AudioSource AudioSource
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public bool InUse
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public float PlayProgress
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		public bool IsPaused
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool IsMuted
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public float LastPlayedTime
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		public float IdleDuration => 0f;

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void Kill()
		{
		}

		public void Mute()
		{
		}

		public void Pause()
		{
		}

		public void Play()
		{
		}

		public void SetFollowTarget(Transform followTarget)
		{
		}

		public void SetOutputAudioMixerGroup(AudioMixerGroup outputAudioMixerGroup)
		{
		}

		public void SetPosition(Vector3 position)
		{
		}

		public void SetSourceProperties(AudioClip clip, float volume, float pitch, bool loop, float spatialBlend)
		{
		}

		public void Stop()
		{
		}

		public void Unmute()
		{
		}

		public void Unpause()
		{
		}

		private void FollowTarget()
		{
		}

		private void ResetController()
		{
		}

		private void UpdateLastPlayedTime()
		{
		}

		private void UpdatePlayProgress()
		{
		}

		public static SoundyController GetController()
		{
			return null;
		}

		public static void KillAll()
		{
		}

		public static void MuteAll()
		{
		}

		public static void PauseAll()
		{
		}

		public static void RemoveNullControllersFromDatabase()
		{
		}

		public static void StopAll()
		{
		}

		public static void UnmuteAll()
		{
		}

		public static void UnpauseAll()
		{
		}
	}
}
