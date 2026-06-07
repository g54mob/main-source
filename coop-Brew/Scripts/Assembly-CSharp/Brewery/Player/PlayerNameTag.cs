using Brewery.Voice;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Player
{
	public class PlayerNameTag : MonoBehaviour
	{
		[Header("UI Document")]
		[Tooltip("UIDocument component for the name tag UI")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Billboard Transform")]
		[Tooltip("Transform that will rotate to face the camera (usually the UIDocument's transform)")]
		[SerializeField]
		private Transform billboardTransform;

		[Header("Visibility")]
		[Tooltip("Maximum distance to show name tags")]
		[SerializeField]
		private float maxVisibleDistance;

		[Tooltip("Distance at which name tag starts fading (adds 'far' class)")]
		[SerializeField]
		private float fadeStartDistance;

		[Tooltip("Distance at which name tag is very faded (adds 'very-far' class)")]
		[SerializeField]
		private float veryFarDistance;

		[Header("Voice Icons")]
		[Tooltip("Icon shown when player is talking")]
		[SerializeField]
		private Texture2D talkingIcon;

		[Tooltip("Icon shown when player is silent (not used by default — icon hidden)")]
		[SerializeField]
		private Texture2D silentIcon;

		[Tooltip("Icon shown when player is muted")]
		[SerializeField]
		private Texture2D mutedIcon;

		[Header("Debug")]
		[Tooltip("Show name tag even for local player (for testing voice icons solo)")]
		[SerializeField]
		private bool showLocalPlayerTag;

		[SerializeField]
		private bool showDebugLogs;

		private VisualElement nameRoot;

		private Label nameLabel;

		private VisualElement voiceIcon;

		private Camera mainCamera;

		private Transform playerTransform;

		private NetworkObject parentNetworkObject;

		private bool isUIInitialized;

		private bool isLocalPlayer;

		private bool ownershipDetermined;

		private string cachedPlayerName;

		private bool hasSteamName;

		private float lastNameRetryTime;

		private const float NAME_RETRY_INTERVAL = 0.5f;

		private VivoxPlayerTracker voiceTracker;

		private float silentTimer;

		private const float SILENT_HIDE_DELAY = 2f;

		private bool voiceIconVisible;

		private bool needsBillboardUpdate;

		public static bool SuppressAll { get; set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void TryDetermineOwnership()
		{
		}

		private Camera GetLocalPlayerCamera()
		{
			return null;
		}

		private void InitializeUI()
		{
		}

		private ulong GetOwnerClientId()
		{
			return 0uL;
		}

		private string GetPlayerDisplayName()
		{
			return null;
		}

		private void UpdateNameDisplay()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateDistanceClasses(float distance)
		{
		}

		private void UpdateVoiceIcon(VoiceState state)
		{
		}

		private void SetVoiceIconVisible(bool visible)
		{
		}

		private void OnDisable()
		{
		}

		private void OnCameraPreCull(Camera cam)
		{
		}
	}
}
