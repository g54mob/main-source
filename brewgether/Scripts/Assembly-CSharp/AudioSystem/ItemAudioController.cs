using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace AudioSystem
{
	public class ItemAudioController : NetworkBehaviour
	{
		[Header("Default Placement Sounds")]
		[Tooltip("Default sounds for items without custom placement sound. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] defaultPlacementClips;

		[Tooltip("Volume for placement sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float placementVolume;

		[Header("Default Pickup Sounds")]
		[Tooltip("Default sounds for items without custom pickup sound. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] defaultPickupClips;

		[Tooltip("Volume for pickup sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float pickupVolume;

		[Header("Default Interaction Sounds")]
		[Tooltip("Default sounds for items without custom interaction sound. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] defaultInteractionClips;

		[Tooltip("Volume for interaction sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float interactionVolume;

		[Header("Hammer Sounds")]
		[Tooltip("Sounds for hammer hits during building. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] hammerHitClips;

		[Tooltip("Volume for hammer hit sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float hammerHitVolume;

		[Header("Safe Door Sounds")]
		[Tooltip("Sounds for safe door opening. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] safeDoorOpenClips;

		[Tooltip("Sounds for safe door closing. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] safeDoorCloseClips;

		[Tooltip("Volume for safe door sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float safeDoorVolume;

		[Header("Star Collect Sounds")]
		[Tooltip("Sounds for collecting a skill star. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] starCollectClips;

		[Tooltip("Volume for star collect sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float starCollectVolume;

		[Header("Audio Settings")]
		[Tooltip("Random pitch variation range.")]
		[Range(0f, 0.3f)]
		[SerializeField]
		private float pitchVariation;

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

		public static ItemAudioController Instance { get; private set; }

		private void Awake()
		{
		}

		public override void OnDestroy()
		{
		}

		public void PlayPlacementSound(Item item, Vector3 position)
		{
		}

		public void PlayPlacementSoundLocal(Item item, Vector3 position)
		{
		}

		public void PlayPickupSound(Item item, Vector3 position)
		{
		}

		public void PlayPickupSoundLocal(Item item, Vector3 position)
		{
		}

		public void PlayInteractionSound(Item item, Vector3 position)
		{
		}

		public void PlayInteractionSoundLocal(Item item, Vector3 position)
		{
		}

		public void PlayHammerHitSound(Vector3 position)
		{
		}

		private AudioClip GetRandomHammerHitClip()
		{
			return null;
		}

		public void PlaySafeDoorOpen(Vector3 position)
		{
		}

		public void PlaySafeDoorClose(Vector3 position)
		{
		}

		private AudioClip GetRandomClip(AudioClip[] clips)
		{
			return null;
		}

		[ClientRpc]
		private void PlayPlacementSoundClientRpc(string itemId, Vector3 position)
		{
		}

		[ClientRpc]
		private void PlayPickupSoundClientRpc(string itemId, Vector3 position)
		{
		}

		[ClientRpc]
		private void PlayInteractionSoundClientRpc(string itemId, Vector3 position)
		{
		}

		private void PlayPlacementSoundInternal(string itemId, Vector3 position)
		{
		}

		private AudioClip GetRandomDefaultPlacementClip()
		{
			return null;
		}

		private void PlayPickupSoundInternal(string itemId, Vector3 position)
		{
		}

		private AudioClip GetRandomDefaultPickupClip()
		{
			return null;
		}

		private void PlayInteractionSoundInternal(string itemId, Vector3 position)
		{
		}

		private AudioClip GetRandomDefaultInteractionClip()
		{
			return null;
		}

		private void PlayClipAtPosition(AudioClip clip, Vector3 position, float volume)
		{
		}

		public void PlayStarCollectSound(Vector3 position)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3497555704(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1678041462(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1593814343(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
