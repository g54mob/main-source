using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using __Project__.Scripts.Multiplayer;

public class SecurityCamera : MonoBehaviour, IInteractable
{
	public int SecurityCameraId;

	public FurniturePlacingMode furniturePlacingMode;

	public LayerMask layerMask;

	public bool IsEnable;

	public bool IsActivated;

	[SerializeField]
	private Vector2 m_WallEdges_X;

	[SerializeField]
	private Vector2 m_WallEdges_Y;

	[SerializeField]
	private Vector2 m_CeilingEdges_X;

	[SerializeField]
	private Vector2 m_CeilingEdges_Y;

	[SerializeField]
	private float m_RotateSpeed;

	[SerializeField]
	private Vector3 m_TargetRotation;

	[SerializeField]
	private Transform m_CameraHolder;

	[SerializeField]
	private bool m_IsDrawGismos;

	[Space]
	[SerializeField]
	private Canvas m_Canvas;

	[SerializeField]
	private RectTransform m_Overlay;

	[SerializeField]
	private Image m_CoverImage_North;

	[SerializeField]
	private Image m_CoverImage_South;

	[SerializeField]
	private Image m_CoverImage_East;

	[SerializeField]
	private Image m_CoverImage_West;

	[SerializeField]
	private TextMeshProUGUI m_TimerText;

	[SerializeField]
	private TextMeshProUGUI m_CamNumberText;

	[Space]
	[SerializeField]
	private Furniture m_Furniture;

	[SerializeField]
	private Transform m_CameraParent;

	[SerializeField]
	private GameObject m_WallAttachment;

	[SerializeField]
	private GameObject m_CeilingAttachment;

	[SerializeField]
	private bool m_IsAtCeiling;

	[SerializeField]
	private Volume m_SecurityCameraVolume;

	private DayCycleManager m_DayCycle;

	private bool isComputerClosed;

	private InputActions m_InputActions;

	private Matrix4x4 m_CullingMatrix;

	private Plane[] m_ViewPlanes;

	private Vector3 velocity;

	private PlayerInstance m_InteractedPlayer;

	private NetworkSecurityCamera m_NetworkSecurityCamera;

	private SecurityCameraSaveData m_SaveData;

	public NetworkSecurityCamera NetworkSecurityCamera => null;

	public bool IsOccupied { get; set; }

	public InteractactableType Type => default(InteractactableType);

	public Quaternion CameraTargetRotation => default(Quaternion);

	public bool PlacingMode => false;

	public bool IsAtCeiling
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public Matrix4x4 CullingMatrix
	{
		get
		{
			return default(Matrix4x4);
		}
		set
		{
		}
	}

	public Transform CameraHolder => null;

	public SecurityCameraSaveData SaveData
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void OnEnable()
	{
	}

	public void Initialize()
	{
	}

	public void Subscribe(PlayerInstance playerInstance)
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Unsubscribe()
	{
	}

	public void ResetData()
	{
	}

	private void OnRotate(bool clockvise)
	{
	}

	private void Start()
	{
	}

	public void Setup()
	{
	}

	private void CheckCeiling()
	{
	}

	public void ManualUpdate()
	{
	}

	private void OnFurnitureStartPlacingMode(GameObject obj)
	{
	}

	private void OnFurnitureBoxUp(GameObject obj)
	{
	}

	private void OnFurniturePlaced(GameObject obj)
	{
	}

	private void UpdateTimeText()
	{
	}

	private void SetScreenCovers()
	{
	}

	private void OnUse(bool down)
	{
	}

	private void OnBack()
	{
	}

	public void SwitchPlacementArea(bool _IsCeiling)
	{
	}

	public void SwitchPlacementArea_Network(bool _IsCeiling)
	{
	}

	private void Rotate()
	{
	}

	private void SnapSpeakerWall()
	{
	}

	private void OnComputerInteractionStopped()
	{
	}

	private void OnSectionPurchased(int obj)
	{
	}

	private void SetVirtualCameraMatrix()
	{
	}

	public void AlignCamera(Transform _Camera)
	{
	}

	public void InteractSecurityCamera_Network(bool willOpen)
	{
	}

	public void EnableCameraMode()
	{
	}

	public void DisableCameraMode()
	{
	}

	public bool IsCustomerVisible(Bounds _Bounds)
	{
		return false;
	}

	public bool InstantInteract()
	{
		return false;
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	private void OnDrawGizmos()
	{
	}

	private void DrawFrustum(Plane[] camPlanes)
	{
	}

	private Vector3 Plane3Intersect(Plane p1, Plane p2, Plane p3)
	{
		return default(Vector3);
	}
}
