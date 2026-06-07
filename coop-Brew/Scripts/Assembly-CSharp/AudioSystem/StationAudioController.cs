using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace AudioSystem
{
	public class StationAudioController : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFadeOutAndStopCoroutine_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AudioSource source;

			public StationAudioController _003C_003E4__this;

			public ulong stationNetworkId;

			private float _003CstartVolume_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CFadeOutAndStopCoroutine_003Ed__42(int _003C_003E1__state)
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

		[Header("Batch Processing Sounds (CornGrinder, Stomping)")]
		[Tooltip("Looping sounds for batch processing. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] batchProcessingLoopClips;

		[Header("Boiling Station Sounds")]
		[Tooltip("Looping sounds for the Convert step.")]
		[SerializeField]
		private AudioClip[] boilingConvertLoopClips;

		[Tooltip("Looping sounds for the Sterilize step.")]
		[SerializeField]
		private AudioClip[] boilingSterilizeLoopClips;

		[Tooltip("Looping sounds for the Cooldown step.")]
		[SerializeField]
		private AudioClip[] boilingCooldownLoopClips;

		[Tooltip("One-shot sounds for pitching yeast.")]
		[SerializeField]
		private AudioClip[] boilingPitchYeastClips;

		[Header("Winemaking Station Sounds")]
		[Tooltip("Looping sounds for Primary Fermentation.")]
		[SerializeField]
		private AudioClip[] winePrimaryFermentationLoopClips;

		[Tooltip("Looping sounds for Press and Rack step.")]
		[SerializeField]
		private AudioClip[] winePressRackLoopClips;

		[Tooltip("Looping sounds for Aging Prep step.")]
		[SerializeField]
		private AudioClip[] wineAgingPrepLoopClips;

		[Header("Spirits Station Sounds")]
		[Tooltip("Looping sounds for Mashing step.")]
		[SerializeField]
		private AudioClip[] spiritsMashingLoopClips;

		[Tooltip("Looping sounds for Fermentation step.")]
		[SerializeField]
		private AudioClip[] spiritsFermentationLoopClips;

		[Tooltip("Looping sounds for Distillation step.")]
		[SerializeField]
		private AudioClip[] spiritsDistillationLoopClips;

		[Header("Common Sounds")]
		[Tooltip("One-shot sounds for step completion.")]
		[SerializeField]
		private AudioClip[] stepCompletionClips;

		[Header("Volume Settings")]
		[Tooltip("Volume for looping process sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float loopVolume;

		[Tooltip("Volume for step completion sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float completionVolume;

		[Tooltip("Volume for one-shot action sounds (like pitch yeast).")]
		[Range(0f, 1f)]
		[SerializeField]
		private float oneShotVolume;

		[Header("Fade Settings")]
		[Tooltip("Duration of fade-out when stopping loops.")]
		[SerializeField]
		private float fadeOutDuration;

		[Header("Pitch Variation")]
		[Tooltip("Random pitch variation range for variety.")]
		[Range(0f, 0.2f)]
		[SerializeField]
		private float pitchVariation;

		[Header("Spatial Settings")]
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

		private Dictionary<ulong, AudioSource> _activeLoops;

		private Dictionary<ulong, Coroutine> _fadeCoroutines;

		public static StationAudioController Instance { get; private set; }

		private void Awake()
		{
		}

		public override void OnDestroy()
		{
		}

		public void StartProcessingLoopNetworked(ulong stationNetworkId, StationSoundType soundType, Vector3 position)
		{
		}

		public void StopProcessingLoopNetworked(ulong stationNetworkId)
		{
		}

		public void PlayStepCompleteNetworked(ulong stationNetworkId, Vector3 position)
		{
		}

		public void PlayOneShotNetworked(ulong stationNetworkId, StationSoundType soundType, Vector3 position)
		{
		}

		public void StartProcessingLoopLocal(ulong stationNetworkId, StationSoundType soundType, Vector3 position, Transform parent = null)
		{
		}

		public void StopProcessingLoopLocal(ulong stationNetworkId)
		{
		}

		public bool HasActiveLoop(ulong stationNetworkId)
		{
			return false;
		}

		[ClientRpc]
		private void StartProcessingLoopClientRpc(ulong stationNetworkId, int soundTypeInt, Vector3 position)
		{
		}

		[ClientRpc]
		private void StopProcessingLoopClientRpc(ulong stationNetworkId)
		{
		}

		[ClientRpc]
		private void PlayStepCompleteClientRpc(ulong stationNetworkId, Vector3 position)
		{
		}

		[ClientRpc]
		private void PlayOneShotClientRpc(ulong stationNetworkId, int soundTypeInt, Vector3 position)
		{
		}

		private void StartLoopInternal(ulong stationNetworkId, StationSoundType soundType, Vector3 position, Transform parent)
		{
		}

		private void StopLoopInternal(ulong stationNetworkId)
		{
		}

		[IteratorStateMachine(typeof(_003CFadeOutAndStopCoroutine_003Ed__42))]
		private IEnumerator FadeOutAndStopCoroutine(ulong stationNetworkId, AudioSource source)
		{
			return null;
		}

		private AudioSource CreateLoopingSource(AudioClip clip, Vector3 position, Transform parent)
		{
			return null;
		}

		private void PlayStepCompleteInternal(Vector3 position)
		{
		}

		private void PlayOneShotInternal(StationSoundType soundType, Vector3 position)
		{
		}

		private void PlayClipAtPosition(AudioClip clip, Vector3 position, float volume)
		{
		}

		private AudioClip GetRandomClipForSoundType(StationSoundType soundType)
		{
			return null;
		}

		private AudioClip GetRandomClip(AudioClip[] clips)
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3364277361(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3764763563(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3374261481(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_161320736(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
