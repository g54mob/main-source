using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Netcode;
using UnityEngine;

namespace AudioSystem
{
	public class PlayerFootstepController : NetworkBehaviour
	{
		public enum SurfaceType
		{
			Asphalt = 0,
			Gravel = 1,
			Grass = 2,
			Wood = 3
		}

		private enum Gait
		{
			Idle = 0,
			Walk = 1,
			Run = 2
		}

		[Header("References")]
		[SerializeField]
		private CharacterController characterController;

		[SerializeField]
		private LayerMask groundLayerMask;

		[Header("Visual Effects")]
		[Tooltip("Dust particle system for gravel. Requires Play On Awake enabled on prefab.")]
		[SerializeField]
		private ParticleSystem gravelDustParticles;

		[Header("Walk Loops")]
		[SerializeField]
		private AudioClip asphaltWalkLoop;

		[SerializeField]
		private AudioClip gravelWalkLoop;

		[SerializeField]
		private AudioClip grassWalkLoop;

		[SerializeField]
		private AudioClip woodWalkLoop;

		[Header("Run Loops")]
		[SerializeField]
		private AudioClip asphaltRunLoop;

		[SerializeField]
		private AudioClip gravelRunLoop;

		[SerializeField]
		private AudioClip grassRunLoop;

		[SerializeField]
		private AudioClip woodRunLoop;

		[Header("Landing (one-shot)")]
		[SerializeField]
		private AudioClip[] landingHeavyClips;

		[Tooltip("Minimum fall distance (meters) before landing sound plays")]
		[SerializeField]
		private float minLandingFallHeight;

		[SerializeField]
		[Range(0f, 1f)]
		private float landingVolume;

		[Header("Jump (one-shot)")]
		[Tooltip("Array of jump takeoff sounds. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] jumpClips;

		[SerializeField]
		[Range(0f, 1f)]
		private float jumpVolume;

		[Header("Speed Thresholds")]
		[Tooltip("Minimum speed to play walk loop")]
		[SerializeField]
		private float walkSpeedMin;

		[Tooltip("Speed to switch from walk to run")]
		[SerializeField]
		private float runSpeedThreshold;

		[Header("Audio Settings")]
		[SerializeField]
		[Range(0f, 1f)]
		private float maxVolume;

		[Tooltip("How fast volume fades in/out")]
		[SerializeField]
		private float fadeSpeed;

		[Tooltip("How fast to crossfade between walk/run")]
		[SerializeField]
		private float crossfadeSpeed;

		[SerializeField]
		[Range(0f, 1f)]
		private float spatialBlend;

		[SerializeField]
		private float minDistance;

		[SerializeField]
		private float maxDistance;

		[Header("Surface Detection")]
		[SerializeField]
		private float rayDistance;

		[Tooltip("Terrain layer indices that count as gravel/road (splatmap lookup)")]
		[SerializeField]
		private int[] terrainGravelLayers;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private AudioSource sourceA;

		private AudioSource sourceB;

		private bool sourceAActive;

		private AudioSource oneShotSource;

		private Vector3 lastPosition;

		private float smoothedSpeed;

		private float speedSmoothVelocity;

		private SurfaceType currentSurface;

		private Gait currentGait;

		private Gait targetGait;

		private float sourceAVolume;

		private float sourceBVolume;

		private float masterVolume;

		private bool isGrounded;

		private const float GROUND_CHECK_DISTANCE = 0.3f;

		private bool footstepsEnabled;

		private bool wasGroundedForLanding;

		private bool isFallTracking;

		private float highestYDuringFall;

		private InputReader inputReader;

		private const float SPEED_SMOOTH_TIME = 0.1f;

		private bool dustInitialized;

		private float surfaceDetectTimer;

		private const float SURFACE_DETECT_INTERVAL = 0.1f;

		private void Awake()
		{
		}

		private void AssignMixerGroups()
		{
		}

		private AudioSource CreateLoopSource(string name)
		{
			return null;
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

		private void DetectGait()
		{
		}

		private void UpdateLoopAudio()
		{
		}

		private void StartCrossfade(Gait newGait)
		{
		}

		private void UpdateSourcePlayState(AudioSource source, float volume)
		{
		}

		private AudioClip GetClipForGait(Gait gait, SurfaceType surface)
		{
			return null;
		}

		private void DetectSurface()
		{
		}

		private void UpdateDustParticles()
		{
		}

		private void UpdateLandingDetection()
		{
		}

		private void TriggerLanding()
		{
		}

		private void OnJumpPerformed()
		{
		}

		[ServerRpc]
		private void PlayJumpServerRpc(int clipIndex)
		{
		}

		[ClientRpc]
		private void PlayJumpClientRpc(int clipIndex, float pitch)
		{
		}

		[ServerRpc]
		private void PlayLandingServerRpc(int clipIndex)
		{
		}

		[ClientRpc]
		private void PlayLandingClientRpc(int clipIndex, float pitch)
		{
		}

		public void SetFootstepsEnabled(bool enabled)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2735467303(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_35338266(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1491920956(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1512561973(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
