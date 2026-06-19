using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggGrabbingArm : MonoBehaviour
{
	private enum ArmState
	{
		DEFAULT = 0,
		READY_TO_GRAB = 1,
		EGG_GRABBED = 2,
		READY_TO_DROP = 3
	}

	public GameObject holderObject;

	public Transform castTransform;

	public GameObject mainArm;

	public GameObject grabberArm;

	private ConfigurableJoint mainArmJoint;

	private ConfigurableJoint grabberJoint;

	public Vector3 defaultMainArmPos;

	public Vector3 readyToGrabMainArmPos;

	public Vector3 readyToDropMainArmPos;

	public Vector3 defaultUpperArmPos;

	public Vector3 readyToGrabUpperArmPos;

	public Vector3 readyToDropUpperArmPos;

	private FixedJoint eggJoint;

	private GameObject attachedEgg;

	private float armStateWait = 1f;

	private List<Vector3> mainArmPositionList;

	private List<Vector3> upperArmPositionList;

	private Quaternion targetMainArmRotation = Quaternion.identity;

	private Quaternion targetUpperArmRotation = Quaternion.identity;

	private Coroutine currentArmRoutine;

	private float eggCheckCastDist = 2.5f;

	private RaycastHit[] results = new RaycastHit[1000];

	private void OnEnable()
	{
		mainArmJoint = mainArm.GetComponent<ConfigurableJoint>();
		grabberJoint = grabberArm.GetComponent<ConfigurableJoint>();
		mainArmPositionList = new List<Vector3> { defaultMainArmPos, readyToGrabMainArmPos, defaultMainArmPos, readyToDropMainArmPos };
		upperArmPositionList = new List<Vector3> { defaultUpperArmPos, readyToGrabUpperArmPos, defaultUpperArmPos, readyToDropUpperArmPos };
		IgnoreCollisions();
		StartArmRoutine();
	}

	private void OnDisable()
	{
		StopArmRoutine();
		mainArmJoint = null;
		grabberJoint = null;
	}

	private void StopArmRoutine()
	{
		if (currentArmRoutine != null)
		{
			StopCoroutine(currentArmRoutine);
			currentArmRoutine = null;
		}
	}

	private void StartArmRoutine()
	{
		StopArmRoutine();
		currentArmRoutine = StartCoroutine(MoveToGrabPosition());
	}

	private IEnumerator MoveToGrabPosition()
	{
		yield return UpdateArms(1, armStateWait);
		yield return new WaitForSeconds(armStateWait);
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		while (!CheckForEgg())
		{
			yield return frameWait;
		}
		currentArmRoutine = StartCoroutine(MoveToEggHeldPosition());
	}

	private IEnumerator MoveToEggHeldPosition()
	{
		yield return UpdateArms(0, armStateWait);
		currentArmRoutine = StartCoroutine(MoveToDropPosition());
	}

	private IEnumerator MoveToDropPosition()
	{
		yield return UpdateArms(3, armStateWait);
		yield return new WaitForSeconds(armStateWait);
		DropEgg();
		yield return new WaitForSeconds(armStateWait);
		currentArmRoutine = StartCoroutine(ReturnToDefaultRoutine());
	}

	private IEnumerator ReturnToDefaultRoutine()
	{
		yield return UpdateArms(0, armStateWait);
		currentArmRoutine = StartCoroutine(MoveToGrabPosition());
	}

	private bool CheckForEgg()
	{
		Vector3 halfExtents = new Vector3(holderObject.transform.lossyScale.x / 4f, 0f, holderObject.transform.lossyScale.z) / 2f;
		int num = RaycastUtil.GoodBoxCastAllNonAlloc(castTransform.position, halfExtents, Vector3.down, holderObject.transform.rotation, eggCheckCastDist, results);
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				if (results[i].transform.root.gameObject.CompareTag(Tags.EGG))
				{
					AttachEgg(results[i].transform.root.gameObject, results[i].point);
					return true;
				}
			}
		}
		return false;
	}

	private void AttachEgg(GameObject egg, Vector3 contactPoint)
	{
		DropEgg();
		attachedEgg = egg;
		eggJoint = holderObject.AddComponent<FixedJoint>();
		Rigidbody componentInChildren = attachedEgg.GetComponentInChildren<Rigidbody>();
		Vector3 vector = holderObject.GetComponent<Collider>().ClosestPointOnBounds(contactPoint);
		Vector3 vector2 = componentInChildren.GetComponent<Collider>().ClosestPointOnBounds(vector);
		componentInChildren.transform.position += vector - vector2;
		eggJoint.connectedBody = componentInChildren;
	}

	private void DropEgg()
	{
		if (!(attachedEgg == null))
		{
			Object.Destroy(eggJoint);
			eggJoint = null;
			attachedEgg = null;
		}
	}

	private IEnumerator UpdateArms(int index, float timerMax)
	{
		Vector3 startingMainRot = mainArmJoint.targetRotation.eulerAngles;
		Vector3 startingUpperRot = grabberJoint.targetRotation.eulerAngles;
		if (startingMainRot.x > 180f)
		{
			startingMainRot.x -= 360f;
		}
		float timer = 0f;
		WaitForFixedUpdate fixedWait = new WaitForFixedUpdate();
		for (; timer <= timerMax; timer += Time.fixedDeltaTime)
		{
			float easeTime = timer / timerMax;
			Vector3 euler = new Vector3(Inchworm.GetLinearEasingValue(easeTime, startingMainRot.x, startingMainRot.x - mainArmPositionList[index].x, timerMax), Inchworm.GetLinearEasingValue(easeTime, startingMainRot.y, startingMainRot.y - mainArmPositionList[index].y, timerMax), Inchworm.GetLinearEasingValue(easeTime, startingMainRot.z, startingMainRot.z - mainArmPositionList[index].z, timerMax));
			Vector3 euler2 = new Vector3(Inchworm.GetLinearEasingValue(easeTime, startingUpperRot.x, startingUpperRot.x - upperArmPositionList[index].x, timerMax), Inchworm.GetLinearEasingValue(easeTime, startingUpperRot.y, startingUpperRot.y - upperArmPositionList[index].y, timerMax), Inchworm.GetLinearEasingValue(easeTime, startingUpperRot.z, startingUpperRot.z - upperArmPositionList[index].z, timerMax));
			targetMainArmRotation = Quaternion.Euler(euler);
			targetUpperArmRotation = Quaternion.Euler(euler2);
			mainArmJoint.targetRotation = targetMainArmRotation;
			grabberJoint.targetRotation = targetUpperArmRotation;
			yield return fixedWait;
		}
		targetMainArmRotation = Quaternion.Euler(mainArmPositionList[index]);
		targetUpperArmRotation = Quaternion.Euler(upperArmPositionList[index]);
		mainArmJoint.targetRotation = targetMainArmRotation;
		grabberJoint.targetRotation = targetUpperArmRotation;
	}

	private void IgnoreCollisions()
	{
		List<Collider> list = new List<Collider>();
		list.AddRange(GetComponentsInChildren<Collider>());
		for (int i = 0; i < list.Count; i++)
		{
			for (int j = 0; j < list.Count; j++)
			{
				if (i != j)
				{
					Physics.IgnoreCollision(list[i], list[j]);
					Physics.IgnoreCollision(list[j], list[i]);
				}
			}
		}
	}
}
