using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AudioSystem;
using BrewGame.SaveSystem.Integration;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Audio;

namespace InteractionSystem
{
	[RequireComponent(typeof(NetworkObject))]
	public class SpeakerController : NetworkBehaviour, IInteractable, IInteractionIKTarget, ISaveable
	{
		[CompilerGenerated]
		private sealed class _003CFadeInCoroutine_003Ed__89 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SpeakerController _003C_003E4__this;

			public float targetVolume;

			private float _003Celapsed_003E5__2;

			private float _003CstartVolume_003E5__3;

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
			public _003CFadeInCoroutine_003Ed__89(int _003C_003E1__state)
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
		private sealed class _003CFadeOutCoroutine_003Ed__90 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SpeakerController _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			private float _003CstartVolume_003E5__3;

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
			public _003CFadeOutCoroutine_003Ed__90(int _003C_003E1__state)
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
		private sealed class _003CPlayPlaylistSequentialCoroutine_003Ed__87 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SpeakerController _003C_003E4__this;

			public bool skipFirstTrackPlay;

			public float initialStartPosition;

			private int _003CtrackCount_003E5__2;

			private bool _003CisFirstTrack_003E5__3;

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
			public _003CPlayPlaylistSequentialCoroutine_003Ed__87(int _003C_003E1__state)
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
		private sealed class _003CPreloadAudioCoroutine_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SpeakerController _003C_003E4__this;

			private List<AudioClip> _003CclipsToLoad_003E5__2;

			private List<AudioClip>.Enumerator _003C_003E7__wrap2;

			private AudioClip _003Cclip_003E5__4;

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
			public _003CPreloadAudioCoroutine_003Ed__58(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Music Configuration")]
		[Tooltip("Playlist to play when speaker is turned on")]
		[SerializeField]
		private MusicPlaylist playlist;

		[Tooltip("Single track to play (used if playlist is not assigned)")]
		[SerializeField]
		private MusicTrack singleTrack;

		[Header("Spatial Audio Settings")]
		[Tooltip("Audio mixer group for the speaker output")]
		[SerializeField]
		private AudioMixerGroup audioMixerGroup;

		[Tooltip("How 3D the sound is. 0 = 2D (heard everywhere), 1 = fully 3D spatial")]
		[Range(0f, 1f)]
		[SerializeField]
		private float spatialBlend;

		[Tooltip("Distance within which audio is at full volume")]
		[SerializeField]
		private float minDistance;

		[Tooltip("Distance beyond which audio is silent")]
		[SerializeField]
		private float maxDistance;

		[Tooltip("How audio fades with distance")]
		[SerializeField]
		private AudioRolloffMode rolloffMode;

		[Tooltip("Volume of the speaker (0-1)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float volume;

		[Tooltip("Fade duration when starting/stopping music")]
		[SerializeField]
		private float fadeDuration;

		[Header("Visual References")]
		[Tooltip("Optional: GameObjects to show when speaker is on (e.g., speaker lights, particles)")]
		[SerializeField]
		private GameObject[] onVisuals;

		[Header("Speaker Animation")]
		[Tooltip("Transforms to animate when playing (e.g., speaker mesh). Will pulse/wobble subtly.")]
		[SerializeField]
		private Transform[] animatedSpeakers;

		[Tooltip("Enable subtle scale pulsing animation")]
		[SerializeField]
		private bool enableScalePulse;

		[Tooltip("Scale pulse intensity (0.02 = 2% size change)")]
		[Range(0.01f, 0.1f)]
		[SerializeField]
		private float scalePulseIntensity;

		[Tooltip("Scale pulse speed (pulses per second)")]
		[Range(0.5f, 4f)]
		[SerializeField]
		private float scalePulseSpeed;

		[Tooltip("Enable subtle rotation wobble")]
		[SerializeField]
		private bool enableRotationWobble;

		[Tooltip("Rotation wobble intensity (degrees)")]
		[Range(0.5f, 5f)]
		[SerializeField]
		private float rotationWobbleIntensity;

		[Tooltip("Rotation wobble speed")]
		[Range(0.5f, 4f)]
		[SerializeField]
		private float rotationWobbleSpeed;

		[Header("Timer Settings")]
		[Tooltip("How long the speaker stays on before automatically turning off (in game seconds). 0 = never auto-off.")]
		[SerializeField]
		private float autoOffDuration;

		[Header("Interaction Settings")]
		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("IK Reach Animation")]
		[SerializeField]
		private bool enableIKReach;

		[SerializeField]
		private float ikReachDuration;

		[Header("Repair State")]
		[Tooltip("If true, the speaker starts broken and must be repaired via an antenna interactable")]
		[SerializeField]
		private bool requiresRepair;

		[Tooltip("Unique save ID for this speaker (only needed if requiresRepair is true)")]
		[SerializeField]
		private string uniqueSaveId;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<bool> _isRepaired;

		private Vector3[] _originalScales;

		private Vector3[] _originalRotations;

		private int[] _scaleTweenIds;

		private int[] _rotationTweenIds;

		private AudioSource _audioSource;

		private Coroutine _playlistCoroutine;

		private Coroutine _fadeCoroutine;

		private bool _audioPreloaded;

		private NetworkVariable<bool> _isOn;

		private NetworkVariable<float> _timeRemaining;

		private NetworkVariable<float> _musicStartPosition;

		private NetworkVariable<int> _networkTrackIndex;

		public bool IsOn => false;

		public float TimeRemaining => 0f;

		public float AutoOffDuration => 0f;

		public int CurrentTrackIndex => 0;

		public MusicTrack CurrentTrack => null;

		public bool IsRepaired => false;

		public bool IsBroken => false;

		public float IKReachDuration => 0f;

		public bool EnableIKReach => false;

		public string SaveableId => null;

		public void Repair()
		{
		}

		private void Awake()
		{
		}

		private void CreateAudioSource()
		{
		}

		private void CacheOriginalTransforms()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		[IteratorStateMachine(typeof(_003CPreloadAudioCoroutine_003Ed__58))]
		private IEnumerator PreloadAudioCoroutine()
		{
			return null;
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnTrackIndexChanged(int previousValue, int newValue)
		{
		}

		private void OnRepairStateChanged(bool previousValue, bool newValue)
		{
		}

		private void Update()
		{
		}

		public string GetInteractionPrompt()
		{
			return null;
		}

		public bool CanInteract(ulong clientId)
		{
			return false;
		}

		public bool ShouldRemainFocused(ulong clientId)
		{
			return false;
		}

		public void Interact(ulong clientId)
		{
		}

		public float GetInteractionDistance()
		{
			return 0f;
		}

		public Transform GetInteractionTransform()
		{
			return null;
		}

		public int GetInteractionPriority()
		{
			return 0;
		}

		public void OnInteractionFocus()
		{
		}

		public void OnInteractionLoseFocus()
		{
		}

		public Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		public void SetOn(bool on)
		{
		}

		public void Toggle()
		{
		}

		private void OnStateChanged(bool previousValue, bool newValue)
		{
		}

		private void OnTimeChanged(float previousValue, float newValue)
		{
		}

		private void ApplyVisualState(bool isOn)
		{
		}

		private void StartMusicPlayback()
		{
		}

		private void StartMusicPlaybackForLateJoiner()
		{
		}

		private void StopMusicPlayback()
		{
		}

		private void StopPlaybackCoroutines()
		{
		}

		private void PlayTrack(MusicTrack track, float startPosition, bool loop)
		{
		}

		[IteratorStateMachine(typeof(_003CPlayPlaylistSequentialCoroutine_003Ed__87))]
		private IEnumerator PlayPlaylistSequentialCoroutine(float initialStartPosition, bool skipFirstTrackPlay = false)
		{
			return null;
		}

		private void AdvanceToNextTrack(int trackCount)
		{
		}

		[IteratorStateMachine(typeof(_003CFadeInCoroutine_003Ed__89))]
		private IEnumerator FadeInCoroutine(float targetVolume)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFadeOutCoroutine_003Ed__90))]
		private IEnumerator FadeOutCoroutine()
		{
			return null;
		}

		private void PlayToggleSound(bool turningOn)
		{
		}

		private void StartSpeakerAnimations()
		{
		}

		private void StopSpeakerAnimations()
		{
		}

		[ClientRpc]
		private void PlayButtonClickClientRpc(ulong clientId)
		{
		}

		[ClientRpc]
		private void TriggerInteractionIKClientRpc(ulong interactingClientId, ulong targetNetworkObjectId, float duration)
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2609079367(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2265122302(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
