using System.Collections.Generic;
using DV;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterReparenting : MonoBehaviour
{
	private class ControllerColliderFloorHitSorter : IComparer<ControllerColliderHit>
	{
		public int Compare(ControllerColliderHit hitA, ControllerColliderHit hitB)
		{
			float num = hitA?.point.y ?? float.MinValue;
			float num2 = hitB?.point.y ?? float.MinValue;
			if (num > num2)
			{
				return 1;
			}
			if (num < num2)
			{
				return -1;
			}
			return 0;
		}
	}

	public const string REPARENT_TAG = "ReparentTarget";

	private LocomotionInputWrapper input;

	private Transform cameraHolder;

	private CharacterController charController;

	private CustomFirstPersonController fpsController;

	private int walkableLayer;

	private Vector3 teleportHeightOffset;

	private ControllerColliderFloorHitSorter floorHitSorter = new ControllerColliderFloorHitSorter();

	private CharacterReparentTarget lastReparentingTarget;

	private List<ControllerColliderHit> orderedHits = new List<ControllerColliderHit>();

	private ACharacterControllerProvider Provider => fpsController.provider;

	private void Awake()
	{
		input = GetComponent<LocomotionInputWrapper>();
		charController = GetComponent<CharacterController>();
		fpsController = GetComponent<CustomFirstPersonController>();
		cameraHolder = GetComponent<CameraSmoothing>().head;
		walkableLayer = Provider.MovablePlatformLayer;
		if (input == null || charController == null || fpsController == null || cameraHolder == null)
		{
			Debug.LogError("Couldn't extract all expected components on CharacterReparenting!", this);
		}
		teleportHeightOffset = new Vector3(0f, charController.height * 0.5f + charController.skinWidth * 1.1f, 0f);
		fpsController.ClimbingLaddersChanged += OnClimbingLaddersChanged;
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading && fpsController != null)
		{
			fpsController.ClimbingLaddersChanged -= OnClimbingLaddersChanged;
		}
	}

	public void ReparentTo(Transform target, bool forceReparent = false, CharacterReparentTarget characterReparentTarget = null)
	{
		if (forceReparent || !(target == base.transform.parent))
		{
			orderedHits.Clear();
			if (lastReparentingTarget != null)
			{
				lastReparentingTarget.ClearPlayer();
			}
			lastReparentingTarget = characterReparentTarget;
			if ((bool)characterReparentTarget)
			{
				characterReparentTarget.SetPlayer(base.transform, this);
			}
			float y = cameraHolder.position.y - base.transform.position.y;
			base.transform.SetParent(target);
			cameraHolder.SetParent(base.transform.parent);
			cameraHolder.position = base.transform.position + new Vector3(0f, y, 0f);
			if (target == null)
			{
				Scene activeScene = SceneManager.GetActiveScene();
				SceneManager.MoveGameObjectToScene(base.transform.gameObject, activeScene);
				SceneManager.MoveGameObjectToScene(cameraHolder.gameObject, activeScene);
			}
			Provider.OnCharacterReparented(target);
		}
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (!(hit.normal.y < 0.017452406f))
		{
			float num = fpsController.transform.position.y + charController.radius + charController.skinWidth;
			if (!(hit.point.y > num))
			{
				orderedHits.Add(hit);
			}
		}
	}

	private void Update()
	{
		if (orderedHits.Count == 0 || !charController.isGrounded)
		{
			return;
		}
		orderedHits.Sort(floorHitSorter);
		foreach (ControllerColliderHit orderedHit in orderedHits)
		{
			if ((bool)orderedHit.collider)
			{
				bool flag = IsWalkable(orderedHit.gameObject);
				if (!(fpsController.transform.parent == (flag ? orderedHit.transform.root : null)) && !(fpsController.transform.parent == (flag ? orderedHit.transform.parent : null)) && TryToReparentOnFloorChange(orderedHit.gameObject))
				{
					break;
				}
			}
		}
		orderedHits.Clear();
	}

	public bool TryToReparentOnFloorChange(GameObject collidedWith)
	{
		CharacterReparentTarget characterReparentTarget = null;
		if (IsWalkable(collidedWith))
		{
			characterReparentTarget = collidedWith.GetComponentInParent<CharacterReparentTarget>();
		}
		Transform transform = null;
		if ((bool)characterReparentTarget && characterReparentTarget.target != charController.transform.parent)
		{
			transform = characterReparentTarget.target;
		}
		bool flag = true;
		if (fpsController.underwater)
		{
			if ((bool)transform && characterReparentTarget.isTrain)
			{
				Bounds trainBounds = Provider.GetTrainBounds(characterReparentTarget.target);
				Vector3 vector = Vector3.one * (charController.radius * 1.99f) + Vector3.up;
				trainBounds.size += vector;
				flag = trainBounds.Contains(transform.InverseTransformPoint(base.transform.position));
			}
			else
			{
				flag = false;
			}
		}
		if (flag && ((bool)transform || (collidedWith.transform.root != base.transform.parent && !IsWalkable(collidedWith.transform.gameObject))))
		{
			ReparentTo(transform, forceReparent: false, characterReparentTarget);
			return true;
		}
		return false;
	}

	private void OnClimbingLaddersChanged(bool isClimbing, Transform ladders)
	{
		if (isClimbing)
		{
			CharacterReparentTarget componentInParent = ladders.GetComponentInParent<CharacterReparentTarget>();
			Transform target = (componentInParent ? componentInParent.target : null);
			ReparentTo(target, forceReparent: false, componentInParent);
		}
	}

	private bool IsWalkable(GameObject gameObject)
	{
		if (gameObject.layer != walkableLayer)
		{
			return gameObject.CompareTag("ReparentTarget");
		}
		return true;
	}
}
