using DV.Utils;
using UnityEngine;
using VRTK;

public class CharacterControllerMover : MonoBehaviour
{
	private Transform headset;

	private Transform playArea;

	private Vector3 headsetZero;

	private float cameraMaxDistanceFromCenter = 0.15f;

	[SerializeField]
	private float cameraMaxDistanceFromCenterStandard = 0.15f;

	private float sqrCameraMaxDistanceFromCenter;

	private CustomFirstPersonController customFPC;

	private CameraSmoothing cameraSmoothing;

	private float upperDistanceThreshold = 50f;

	private int fallSafetyMask;

	private readonly RaycastHit[] fallSafetyHits = new RaycastHit[3];

	private void Awake()
	{
		VRTK_SDKManager.instance?.AddBehaviourToToggleOnLoadedSetupChange(this);
		cameraMaxDistanceFromCenter = cameraMaxDistanceFromCenterStandard;
		fallSafetyMask = 1 << LayerMask.NameToLayer("Train_Walkable");
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isQuitting)
		{
			VRTK_SDKManager.instance?.RemoveBehaviourToToggleOnLoadedSetupChange(this);
		}
	}

	private void OnEnable()
	{
		customFPC = GetComponent<CustomFirstPersonController>();
		cameraSmoothing = GetComponent<CameraSmoothing>();
		headset = VRTK_DeviceFinder.HeadsetCamera();
		headsetZero = headset.localPosition;
		playArea = VRTK_DeviceFinder.PlayAreaTransform();
		sqrCameraMaxDistanceFromCenter = cameraMaxDistanceFromCenter * cameraMaxDistanceFromCenter;
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			float moveRange = SingletonBehaviour<WorldMover>.Instance.moveRange;
			if (moveRange > sqrCameraMaxDistanceFromCenter && moveRange < upperDistanceThreshold)
			{
				upperDistanceThreshold = moveRange;
			}
		}
	}

	private void Update()
	{
		MoveCharacterColliderUnderPlayersHead(force: false);
	}

	public void MoveCharacterColliderUnderPlayersHead(bool force)
	{
		if (!headset)
		{
			return;
		}
		Vector3 vector = headsetZero - headset.localPosition;
		vector.y = 0f;
		float sqrMagnitude = vector.sqrMagnitude;
		if (force || (sqrMagnitude >= sqrCameraMaxDistanceFromCenter && sqrMagnitude < upperDistanceThreshold && !HasFallSafetyBelowHead()))
		{
			Transform parent = playArea.transform.parent;
			Transform parent2 = (PlayerManager.Car ? PlayerManager.Car.interior : null);
			playArea.transform.SetParent(parent2);
			Vector3 direction = headset.position - base.transform.position;
			direction.y = 0f;
			customFPC.IgnoreFootstepsSoundUntilGrounded(isShortIgnore: true);
			customFPC.MoveBy(direction);
			cameraSmoothing.head.position = cameraSmoothing.cameraAnchor.position;
			playArea.SetParent(parent);
			Vector3 vector2 = playArea.localPosition;
			vector2.y = 0f;
			if (vector2.sqrMagnitude > 225f)
			{
				Debug.LogWarning($"Resetting play area local position to zero to avoid potential bug, the value would otherwise be {vector2})", this);
				vector2 = Vector3.zero;
			}
			playArea.localPosition = vector2;
			cameraSmoothing.canSmooth = true;
			Vector3 vector3 = customFPC.transform.position - headset.position;
			vector3.y = 0f;
			if (vector3.sqrMagnitude < sqrCameraMaxDistanceFromCenter)
			{
				headsetZero = headset.localPosition;
			}
		}
	}

	private bool HasFallSafetyBelowHead()
	{
		if ((bool)PlayerManager.Car)
		{
			int num = Physics.RaycastNonAlloc(headset.position, Vector3.down, fallSafetyHits, 5f, fallSafetyMask, QueryTriggerInteraction.Collide);
			for (int i = 0; i < num; i++)
			{
				Collider collider = fallSafetyHits[i].collider;
				if ((bool)collider && collider.isTrigger && collider.gameObject.name.Equals("[fall safety]"))
				{
					return true;
				}
			}
		}
		return false;
	}
}
