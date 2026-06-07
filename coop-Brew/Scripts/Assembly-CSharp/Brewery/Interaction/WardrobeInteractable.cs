using InteractionSystem;
using Player.Customization;
using Player.Customization.Sidekick;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Interaction
{
	[RequireComponent(typeof(NetworkObject))]
	public class WardrobeInteractable : NetworkBehaviour, IInteractable
	{
		public enum DoorRotationAxis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		[Header("Wardrobe Camera")]
		[Tooltip("Transform representing where the camera should be positioned when this wardrobe is used")]
		[SerializeField]
		private Transform wardrobeCameraPosition;

		[Header("Player Position")]
		[Tooltip("Transform where the player will be teleported when interacting")]
		[SerializeField]
		private Transform playerSitPosition;

		[Header("Interaction Settings")]
		[Tooltip("Transform used for interaction distance calculations")]
		[SerializeField]
		private Transform interactionPoint;

		[Tooltip("Custom text for the interaction prompt (optional)")]
		[SerializeField]
		private string customPromptText;

		[Tooltip("Maximum distance player can interact from")]
		[SerializeField]
		private float interactionDistance;

		[Tooltip("Priority when multiple interactables are in range (higher = preferred)")]
		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning. Leave null for default screen-space HUD.")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Door Configuration")]
		[Tooltip("Left door transform (optional)")]
		[SerializeField]
		private Transform leftDoor;

		[Tooltip("Right door transform (optional)")]
		[SerializeField]
		private Transform rightDoor;

		[Tooltip("Angle in degrees for left door to open (positive = outward)")]
		[SerializeField]
		private float leftDoorOpenAngle;

		[Tooltip("Angle in degrees for right door to open (positive = outward)")]
		[SerializeField]
		private float rightDoorOpenAngle;

		[Tooltip("Direction multiplier for left door (-1 or 1 to flip rotation direction)")]
		[SerializeField]
		private float leftDoorDirection;

		[Tooltip("Direction multiplier for right door (-1 or 1 to flip rotation direction)")]
		[SerializeField]
		private float rightDoorDirection;

		[Tooltip("Which local axis the doors rotate around")]
		[SerializeField]
		private DoorRotationAxis doorRotationAxis;

		[Header("Drawer Configuration")]
		[Tooltip("Array of drawer transforms to animate")]
		[SerializeField]
		private Transform[] drawers;

		[Tooltip("How far each drawer moves when opening (in local units)")]
		[SerializeField]
		private float drawerMoveDistance;

		[Tooltip("Local direction drawers move when opening")]
		[SerializeField]
		private Vector3 drawerMoveDirection;

		[Header("Animation Settings")]
		[Tooltip("Duration of open/close animations in seconds")]
		[SerializeField]
		private float animationDuration;

		[Tooltip("Delay between each door/drawer animation for staggered effect")]
		[SerializeField]
		private float staggerDelay;

		[Tooltip("Overshoot amount for pop effect (0 = no overshoot, 1 = 100% overshoot)")]
		[Range(0f, 2f)]
		[SerializeField]
		private float popOvershoot;

		[Tooltip("Easing type for opening animation")]
		[SerializeField]
		private LeanTweenType openEaseType;

		[Tooltip("Easing type for closing animation")]
		[SerializeField]
		private LeanTweenType closeEaseType;

		[Header("Debug")]
		[Tooltip("Show debug logs for interaction events")]
		[SerializeField]
		private bool showDebugLogs;

		private ulong currentUserId;

		private bool isInUse;

		private Quaternion leftDoorClosedRotation;

		private Quaternion rightDoorClosedRotation;

		private Vector3[] drawerClosedPositions;

		private bool isOpen;

		private void Awake()
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

		[ClientRpc]
		private void AnimateWardrobeClientRpc(bool opening)
		{
		}

		[ClientRpc]
		private void OpenWardrobeUIClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void CloseWardrobeUIClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private void TeleportPlayerToSitPosition(Transform playerTransform)
		{
		}

		private void PlayOpenAnimation()
		{
		}

		private void PlayCloseAnimation()
		{
		}

		private Vector3 GetDoorOpenEuler(float angle)
		{
			return default(Vector3);
		}

		private void PlayWardrobeDoorOpenSound(Vector3 position)
		{
		}

		private void PlayWardrobeDoorCloseSound(Vector3 position)
		{
		}

		private void PlayDrawerOpenSound(Vector3 position)
		{
		}

		private void PlayDrawerCloseSound(Vector3 position)
		{
		}

		private CharacterCustomizer FindLocalPlayerCustomizer()
		{
			return null;
		}

		private SidekickCharacterCustomizer FindLocalSidekickCustomizer()
		{
			return null;
		}

		public void ReleaseWardrobe()
		{
		}

		private void ReleaseWardrobeInternal()
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void RequestReleaseWardrobeServerRpc(RpcParams rpcParams = default(RpcParams))
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void DrawDoorArc(Transform door, float angle)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_429372096(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1157727834(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2261742324(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3925691327(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
