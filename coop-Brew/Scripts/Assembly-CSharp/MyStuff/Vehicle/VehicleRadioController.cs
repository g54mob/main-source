using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AudioSystem;
using Brewery.Vehicle;
using Ezereal;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Audio;

namespace MyStuff.Vehicle
{
	public class VehicleRadioController : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFadeInCoroutine_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VehicleRadioController _003C_003E4__this;

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
			public _003CFadeInCoroutine_003Ed__52(int _003C_003E1__state)
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
		private sealed class _003CFadeOutCoroutine_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VehicleRadioController _003C_003E4__this;

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
			public _003CFadeOutCoroutine_003Ed__53(int _003C_003E1__state)
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
		private sealed class _003CPlayPlaylistCoroutine_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VehicleRadioController _003C_003E4__this;

			public float initialStartPosition;

			private bool _003CisFirstTrack_003E5__2;

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
			public _003CPlayPlaylistCoroutine_003Ed__50(int _003C_003E1__state)
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

		[Header("Music Configuration")]
		[Tooltip("Playlist to play (cycles through tracks)")]
		[SerializeField]
		private MusicPlaylist playlist;

		[Tooltip("Single track to play (used if playlist is not assigned)")]
		[SerializeField]
		private MusicTrack singleTrack;

		[Header("Spatial Audio Settings")]
		[Tooltip("Audio mixer group for the radio output")]
		[SerializeField]
		private AudioMixerGroup audioMixerGroup;

		[Tooltip("How 3D the sound is. 0 = 2D, 1 = fully spatial")]
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

		[Tooltip("Volume of the radio (0-1)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float volume;

		[Tooltip("Fade duration when starting/stopping music")]
		[SerializeField]
		private float fadeDuration;

		[Header("Behavior")]
		[Tooltip("Automatically turn on radio when driver enters")]
		[SerializeField]
		private bool autoStartOnEnter;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<bool> _isOn;

		private NetworkVariable<int> _trackIndex;

		private AudioSource _audioSource;

		private Coroutine _playlistCoroutine;

		private Coroutine _fadeCoroutine;

		private IVehicleController _vehicleController;

		private EzerealCarController _carController;

		private bool _wasHasDriver;

		private bool _rememberedRadioOn;

		private bool _isSubscribedToInput;

		private InputReader _subscribedInputReader;

		public bool IsOn => false;

		public int CurrentTrackIndex => 0;

		public MusicTrack CurrentTrack => null;

		public event Action OnRadioInteraction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void CreateAudioSource()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void Update()
		{
		}

		private void SubscribeToInput()
		{
		}

		private void UnsubscribeFromInput()
		{
		}

		private void OnToggleRadio()
		{
		}

		private void OnNextTrack()
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void ToggleRadioServerRpc()
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void NextTrackServerRpc()
		{
		}

		[Rpc(SendTo.ClientsAndHost)]
		private void TriggerRadioReachClientRpc()
		{
		}

		private void SetRadioOn(bool on)
		{
		}

		private void OnRadioStateChanged(bool previousValue, bool newValue)
		{
		}

		private void OnTrackIndexChanged(int previousValue, int newValue)
		{
		}

		private void StartMusicPlayback(float startPosition)
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

		[IteratorStateMachine(typeof(_003CPlayPlaylistCoroutine_003Ed__50))]
		private IEnumerator PlayPlaylistCoroutine(float initialStartPosition)
		{
			return null;
		}

		private void AdvanceTrack()
		{
		}

		[IteratorStateMachine(typeof(_003CFadeInCoroutine_003Ed__52))]
		private IEnumerator FadeInCoroutine(float targetVolume)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFadeOutCoroutine_003Ed__53))]
		private IEnumerator FadeOutCoroutine()
		{
			return null;
		}

		private bool GetHasDriver()
		{
			return false;
		}

		private bool IsLocalPlayerInVehicle()
		{
			return false;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_485785405(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1003585087(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_51617215(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
