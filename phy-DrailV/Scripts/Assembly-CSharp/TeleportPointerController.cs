using System;
using DV;
using DV.Utils;
using DV.WorldTools;
using UnityEngine;
using VRTK;

[ExecuteBefore(typeof(DefaultOrder))]
public class TeleportPointerController : MonoBehaviour
{
	private struct PointerData
	{
		public bool hasHit;

		public RaycastHit hit;

		public Transform target;

		public IPointable pointable;

		public bool teleportAllowed;

		public Vector3 teleportPosition;

		public Quaternion teleportRotation;

		public bool reorientPlayer;

		public bool showArrow;

		public Vector3 arrowDirection;
	}

	private const float WATER_TP_HEIGHT_OFFSET = 0.5f;

	private const float HEIGHTMAP_CORRECTION_THRESHOLD = 0.2f;

	public APointerLogic pointerLogic;

	public float showArrowThreshold = 0.25f;

	public CustomFirstPersonController customFirstPersonController;

	public LayerMask layerMask;

	public GameObject validCursorPrefab;

	public GameObject invalidCursorPrefab;

	public GameObject arrowCursorPrefab;

	public Color colorValid = new Color(9f / 85f, 0.6509804f, 44f / 51f);

	public Color colorInvalid = new Color(71f / 85f, 0.12156863f, 2f / 15f);

	private GameObject cursorValid;

	private GameObject cursorInvalid;

	private GameObject cursorArrow;

	[NonSerialized]
	public bool manualUpdate;

	private IPointable currentlyHovered;

	public bool teleportAllowed = true;

	public bool cabTeleportAllowed = true;

	private GameParams gameParams;

	private LocomotionInputVr vrInput;

	private bool isVR;

	private bool isRightHand;

	private int terrainLayer;

	private int waterLayer;

	private int terrainMask;

	private bool shouldTeleportNextFrame;

	public event Action Teleported;

	private void Start()
	{
		gameParams = Globals.G.GameParams;
		cursorValid = UnityEngine.Object.Instantiate(validCursorPrefab);
		cursorValid.name = "[teleport cursor - valid]";
		cursorValid.SetActive(value: false);
		cursorInvalid = UnityEngine.Object.Instantiate(invalidCursorPrefab);
		cursorInvalid.name = "[teleport cursor - invalid]";
		cursorInvalid.SetActive(value: false);
		cursorArrow = UnityEngine.Object.Instantiate(arrowCursorPrefab);
		cursorArrow.name = "[teleport cursor - arrow]";
		cursorArrow.SetActive(value: false);
		pointerLogic.colorValid = colorValid;
		pointerLogic.colorInvalid = colorInvalid;
		terrainLayer = LayerMask.NameToLayer("Terrain");
		terrainMask = LayerMask.GetMask("Terrain");
		waterLayer = LayerMask.NameToLayer("Water");
		isVR = VRManager.IsVREnabled();
		if (isVR)
		{
			vrInput = new LocomotionInputVr();
			isRightHand = VRTK_SDK_Bridge.IsControllerRightHand(GetComponentInParent<VRTK_ControllerEvents>().gameObject);
		}
	}

	private void OnDestroy()
	{
		vrInput?.Dispose();
	}

	private Vector3 GetLeastParallelAxis(Vector3 vec)
	{
		float num = Mathf.Abs(Vector3.Dot(vec, Vector3.right));
		float num2 = Mathf.Abs(Vector3.Dot(vec, Vector3.up));
		if (num < num2)
		{
			return Vector3.right;
		}
		return Vector3.up;
	}

	public void LateUpdate()
	{
		if (!manualUpdate)
		{
			DoTeleportLogic();
		}
	}

	public void EnsureUnhover()
	{
		if (currentlyHovered as UnityEngine.Object != null)
		{
			currentlyHovered.Unhover();
			currentlyHovered = null;
		}
	}

	public void DoTeleportLogic()
	{
		cursorArrow.SetActive(value: false);
		cursorValid.SetActive(value: false);
		cursorInvalid.SetActive(value: false);
		if (!teleportAllowed || !gameParams.ShortDashAllowed)
		{
			return;
		}
		bool flag = pointerLogic.IsActivationButtonBeingHeld();
		bool flag2 = pointerLogic.IsActivationButtonJustReleased();
		if (SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen)
		{
			pointerLogic.Disable();
			return;
		}
		PointerData pointerData;
		if (cabTeleportAllowed)
		{
			RaycastHit hit;
			bool hasHit = pointerLogic.ScanForCab(layerMask, out hit);
			PopulatePointerData(out pointerData, hasHit, hit);
		}
		else
		{
			PopulatePointerData(out pointerData, hasHit: false, default(RaycastHit));
		}
		if (currentlyHovered as UnityEngine.Object != null && pointerData.pointable != currentlyHovered)
		{
			currentlyHovered.Unhover();
		}
		currentlyHovered = pointerData.pointable;
		if (pointerData.pointable != null)
		{
			HandIPointableSource source = (isVR ? ((!isRightHand) ? HandIPointableSource.VRLeft : HandIPointableSource.VRRight) : HandIPointableSource.NonVR);
			pointerData.pointable.Hover(pointerData.hit.point, pointerData.hit.normal, source);
		}
		if (flag || flag2 || shouldTeleportNextFrame)
		{
			pointerLogic.Enable();
			if (!pointerData.target)
			{
				RaycastHit hit2;
				bool hasHit2 = pointerLogic.ScanForTeleportDestination(layerMask, out hit2);
				PopulatePointerData(out pointerData, hasHit2, hit2);
				float playerHeight;
				if (!isVR || LocomotionSetup.CurrentLocomotion == LocomotionType.Smooth)
				{
					playerHeight = customFirstPersonController.CapsuleHeight + customFirstPersonController.capsule.stepOffset / 2f;
				}
				else
				{
					vrInput.UpdateFrame();
					playerHeight = (vrInput.CrouchRequested ? 0.72f : 1.62f);
				}
				if (pointerData.hasHit && pointerData.teleportAllowed && TeleportRaycastLogic.AdjustHit(pointerLogic.transform.position, pointerData.hit, out var adjustedHit, layerMask, playerHeight))
				{
					float num = adjustedHit.point.y - hit2.point.y;
					pointerData.target = adjustedHit.collider.transform;
					pointerData.reorientPlayer = false;
					pointerData.teleportPosition = adjustedHit.point;
					pointerData.showArrow = Mathf.Abs(num) > showArrowThreshold;
					pointerData.arrowDirection = ((num > 0f) ? Vector3.up : Vector3.down);
				}
			}
			if ((bool)pointerData.target)
			{
				cursorValid.transform.position = pointerData.teleportPosition;
				cursorValid.SetActive(value: true);
				pointerLogic.SetColor(colorValid);
				if (pointerData.showArrow)
				{
					cursorArrow.SetActive(value: true);
					cursorArrow.transform.position = pointerData.hit.point;
					cursorArrow.transform.LookAt(pointerData.hit.point + pointerData.hit.normal, pointerData.arrowDirection);
				}
			}
			else if (pointerData.hasHit)
			{
				cursorInvalid.transform.SetPositionAndRotation(pointerData.hit.point, Quaternion.LookRotation(pointerData.hit.normal, GetLeastParallelAxis(pointerData.hit.normal)));
				cursorInvalid.SetActive(value: true);
				pointerLogic.SetColor(colorInvalid);
			}
		}
		else
		{
			pointerLogic.Disable();
		}
		if ((bool)pointerData.target && (flag2 || shouldTeleportNextFrame))
		{
			if (SingletonBehaviour<WorldMover>.Instance != null && SingletonBehaviour<WorldMover>.Instance.MovedThisFrame)
			{
				shouldTeleportNextFrame = true;
				return;
			}
			shouldTeleportNextFrame = false;
			Teleport(pointerData);
		}
	}

	private void Teleport(PointerData pd)
	{
		bool flag = pd.target.gameObject.layer == waterLayer;
		if (flag)
		{
			pd.teleportPosition += Vector3.down * 0.5f;
		}
		if (pd.target.gameObject.layer == terrainLayer || flag)
		{
			float interpolated = HeightMapProvider.GetInterpolated(pd.teleportPosition);
			float num = interpolated - pd.teleportPosition.y;
			if (num >= 0.2f && !Physics.Raycast(pd.teleportPosition + Vector3.up * 0.2f, Vector3.down, num + 0.4f, terrainMask))
			{
				Debug.LogWarning($"Teleport terrain correction {pd.target.gameObject.name} @ {pd.teleportPosition.x}, {pd.teleportPosition.z}: Y {pd.teleportPosition.y} -> {interpolated} (delta {num})", pd.target.gameObject);
				pd.teleportPosition.y = interpolated;
			}
		}
		PlayerManager.TeleportPlayer(pd.teleportPosition, pd.teleportRotation, pd.target, pd.reorientPlayer, playFootstepSound: true);
		if (flag)
		{
			PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>().isRepositioning = false;
		}
		if (pd.pointable is ITeleportDestination teleportDestination)
		{
			teleportDestination.AfterPlayerTeleported();
		}
		this.Teleported?.Invoke();
	}

	private void PopulatePointerData(out PointerData pointerData, bool hasHit, RaycastHit hit)
	{
		pointerData = new PointerData
		{
			hasHit = hasHit,
			hit = hit,
			showArrow = false
		};
		if (!hit.collider)
		{
			return;
		}
		IPointable componentInParent = hit.collider.GetComponentInParent<IPointable>();
		if (componentInParent != null)
		{
			pointerData.pointable = componentInParent;
			if (componentInParent is ITeleportDestination teleportDestination && teleportDestination.IsTeleportAllowed())
			{
				pointerData.target = ((MonoBehaviour)teleportDestination).transform;
				pointerData.teleportAllowed = true;
				pointerData.reorientPlayer = teleportDestination.ShouldRotatePlayerOnTeleport();
				ref Vector3 teleportPosition = ref pointerData.teleportPosition;
				ref Quaternion teleportRotation = ref pointerData.teleportRotation;
				(teleportPosition, teleportRotation) = teleportDestination.GetTeleportPose();
			}
		}
		else if (!hit.collider.CompareTag("NO_TELEPORT"))
		{
			pointerData.teleportAllowed = true;
		}
	}
}
