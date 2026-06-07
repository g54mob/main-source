using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace AudioSystem
{
	public class CombatAudioController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CPlayHitSoundDelayed_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CombatAudioController _003C_003E4__this;

			public Vector3 position;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CPlayHitSoundDelayed_003Ed__26(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CPlaySwingSoundDelayed_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CombatAudioController _003C_003E4__this;

			public Vector3 position;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CPlaySwingSoundDelayed_003Ed__25(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Swing Sounds")]
		[Tooltip("Array of swing/whoosh sounds. One is randomly selected per swing.")]
		[SerializeField]
		private AudioClip[] swingClips;

		[Header("Hit Sounds")]
		[Tooltip("Array of hit/impact sounds. One is randomly selected per hit.")]
		[SerializeField]
		private AudioClip[] hitClips;

		[Header("Unarmed Swing Sounds")]
		[Tooltip("Array of unarmed swing/whoosh sounds. One is randomly selected per punch.")]
		[SerializeField]
		private AudioClip[] unarmedSwingClips;

		[Tooltip("Base volume for unarmed swing sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float unarmedSwingVolume;

		[Header("Throw Sounds")]
		[Tooltip("Array of throw swish sounds. One is randomly selected per throw.")]
		[SerializeField]
		private AudioClip[] throwSwishClips;

		[Tooltip("Base volume for throw swish sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float throwSwishVolume;

		[Header("Audio Settings")]
		[Tooltip("Base volume for swing sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float swingVolume;

		[Tooltip("Base volume for hit sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float hitVolume;

		[Tooltip("Random pitch variation range.")]
		[Range(0f, 0.3f)]
		[SerializeField]
		private float pitchVariation;

		[Header("Timing")]
		[Tooltip("Delay before playing swing sound (seconds). Set to 0 when using animation events for timing.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float swingDelay;

		[Tooltip("Delay before playing hit sound (seconds).")]
		[Range(0f, 0.5f)]
		[SerializeField]
		private float hitDelay;

		[Header("3D Settings")]
		[Tooltip("Spatial blend (0 = 2D, 1 = 3D).")]
		[Range(0f, 1f)]
		[SerializeField]
		private float spatialBlend;

		[Tooltip("Minimum distance for 3D sound.")]
		[SerializeField]
		private float minDistance;

		[Tooltip("Maximum distance for 3D sound.")]
		[SerializeField]
		private float maxDistance;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public static CombatAudioController Instance { get; private set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void PlaySwingSound(Vector3 position)
		{
		}

		public void PlayHitSound(Vector3 position)
		{
		}

		public void PlayUnarmedSwingSound(Vector3 position)
		{
		}

		public void PlayThrowSwish(Vector3 position)
		{
		}

		[IteratorStateMachine(typeof(_003CPlaySwingSoundDelayed_003Ed__25))]
		private IEnumerator PlaySwingSoundDelayed(Vector3 position)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPlayHitSoundDelayed_003Ed__26))]
		private IEnumerator PlayHitSoundDelayed(Vector3 position)
		{
			return null;
		}

		private void PlaySwingSoundImmediate(Vector3 position)
		{
		}

		private void PlayHitSoundImmediate(Vector3 position)
		{
		}

		public void PlaySwingSoundNetworked(Vector3 position)
		{
		}

		public void PlayHitSoundNetworked(Vector3 position)
		{
		}

		private void PlayClipAtPosition(AudioClip clip, Vector3 position, float volume)
		{
		}
	}
}
