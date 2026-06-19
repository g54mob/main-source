using UnityEngine;

public class DogState : MonoBehaviour
{
	public bool debugVis;

	private float faceCastDist = 1f;

	private Vector3 faceCastExtents = new Vector3(0.5f, 0.5f, 0.1f);

	private RaycastHit[] results = new RaycastHit[100];

	private float stateUpdateTimer = 1f;

	private float currentStateUpdateTime;

	private float objectDistractionRate = 0.1f;

	private float dogDistractionRate = 0.01f;

	private GameObject currentObjectInFrontOfFace;

	private DogAI aiRef;

	private GameObject mouth;

	private FaceController faceRef;

	private LegController legControllerRef;

	private MouthController mouthControllerRef;

	private void Awake()
	{
		aiRef = GetComponent<DogAI>();
		faceRef = GetComponent<FaceController>();
		legControllerRef = GetComponent<LegController>();
		mouthControllerRef = GetComponent<MouthController>();
		mouth = legControllerRef.mouth;
	}

	private void Update()
	{
		currentStateUpdateTime -= Time.deltaTime;
		if (currentStateUpdateTime <= 0f)
		{
			CheckState();
		}
	}

	public void UpdateMouth()
	{
		if (legControllerRef != null)
		{
			mouth = legControllerRef.mouth;
		}
	}

	private void CheckState()
	{
		CheckFace();
		currentStateUpdateTime = stateUpdateTimer;
	}

	private void CheckFace()
	{
		currentObjectInFrontOfFace = null;
		if (!mouthControllerRef.IsCarryingObject())
		{
			RaycastHit faceHitInfo = GetFaceHitInfo();
			if (faceHitInfo.transform != null && (!(faceHitInfo.transform.root.gameObject == base.gameObject) || (faceHitInfo.transform.gameObject.layer != LayerMask.NameToLayer("Body") && faceHitInfo.transform.gameObject.layer != LayerMask.NameToLayer("Head"))))
			{
				OnObjectInFrontOfFace(faceHitInfo.transform.gameObject, faceHitInfo.point, faceHitInfo.normal);
			}
		}
	}

	public RaycastHit GetFaceHitInfo()
	{
		Vector3 position = mouth.transform.position;
		Vector3 vector = -legControllerRef.bodyFront.transform.right;
		if (debugVis)
		{
			Debug.DrawLine(position, position + vector * faceCastDist, Color.blue, faceCastDist);
		}
		return RaycastUtil.GetClosestHitIgnoringObject(RaycastUtil.GoodBoxCastAllNonAlloc(position, faceCastExtents, vector, Quaternion.identity, faceCastDist, results), position, results, base.gameObject);
	}

	public RaycastHit GetFaceHitInfoForGauranteedObject(GameObject obj, Vector3 bitePos, int chosenHeadIndex)
	{
		Vector3 position = faceRef.GetDogHeadForIndex(chosenHeadIndex).mouthTransform.position;
		Vector3 vector = bitePos - position;
		float num = Mathf.Max(Vector3.Distance(position, bitePos) + 0.05f, 1f);
		if (debugVis)
		{
			Debug.DrawLine(position, position + vector * faceCastDist, Color.blue, num);
		}
		int num2 = RaycastUtil.GoodRaycastAllNonAlloc(position, vector, num, results);
		for (int i = 0; i < num2; i++)
		{
			if (results[i].transform.root == obj.transform.root)
			{
				return results[i];
			}
		}
		return default(RaycastHit);
	}

	private void OnObjectInFrontOfFace(GameObject obj, Vector3 hitPoint, Vector3 normal)
	{
		if (obj.transform.root.GetComponent<RoomBase>() != null || mouthControllerRef.IsCarryingObject())
		{
			return;
		}
		currentObjectInFrontOfFace = obj.transform.root.gameObject;
		if (aiRef.GetCurrentBehavior() != null && aiRef.GetTargetObject() != null)
		{
			if (aiRef.GetTargetObject().transform.root != obj.transform.root)
			{
				aiRef.OnObjectInFrontOfFace(currentObjectInFrontOfFace);
			}
		}
		else
		{
			float newWeight = (currentObjectInFrontOfFace.CompareTag(Tags.DOG) ? dogDistractionRate : objectDistractionRate);
			DistractionObject newDistraction = new DistractionObject(aiRef, newWeight, currentObjectInFrontOfFace);
			aiRef.TryAddNewDistraction(newDistraction);
		}
	}

	public GameObject GetObjectInFrontOfFace()
	{
		return currentObjectInFrontOfFace;
	}

	public bool RightSideBlocked(float zMult = 0.75f)
	{
		return SideBlocked(legControllerRef.bodyFront.transform.forward, zMult);
	}

	public bool LeftSideBlocked(float zMult = 0.75f)
	{
		return SideBlocked(-legControllerRef.bodyFront.transform.forward, zMult);
	}

	private bool SideBlocked(Vector3 dir, float zMult = 0.75f)
	{
		GameObject bodyFront = legControllerRef.bodyFront;
		Vector3 localScale = bodyFront.transform.localScale;
		localScale += new Vector3(localScale.x, 0f, 0f);
		localScale += new Vector3(legControllerRef.GetHeadLength(), 0f, 0f);
		localScale /= 2f;
		int num = RaycastUtil.GoodBoxCastAllNonAlloc(bodyFront.transform.position + bodyFront.transform.right * (bodyFront.transform.localScale.x / 2f) - bodyFront.transform.right * (legControllerRef.GetHeadLength() / 2f), localScale, dir, bodyFront.transform.rotation, localScale.z * zMult, results);
		for (int i = 0; i < num; i++)
		{
			if (results[i].transform.root.gameObject != base.gameObject)
			{
				return true;
			}
		}
		return false;
	}
}
