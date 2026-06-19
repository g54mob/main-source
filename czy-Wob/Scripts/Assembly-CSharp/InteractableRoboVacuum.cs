using System.Collections.Generic;
using ClockStone;
using UnityEngine;

public class InteractableRoboVacuum : InteractableBase
{
	public Rigidbody rb;

	public GameObject brushLeft;

	public GameObject brushRight;

	private bool wasCollidingWithPuddle;

	private GameObject currentTargetPuddle;

	private RoomBase currentPuddleRoom;

	private int currentPathIndex;

	private PathPosition[] currentPath;

	private float targetDistance = 0.35f;

	private Vector3 sweeperRot = new Vector3(0f, 1080f, 0f);

	private float moveForce = 900f;

	private float rotForce = 1200f;

	private float spinMultiplier = 2f;

	private float wiggleMultiplier = 2f;

	private float dogGrabbingRotMultiplier = 2f;

	private float dogGrabbingMoveMultiplier = 3f;

	private bool isBackingUp;

	private float neededBackupTime = 1f;

	private float currentBackupTime;

	private bool isSpinning;

	private float neededSpinTime = 1.5f;

	private float currentSpinTime;

	private bool isWiggling;

	private float neededWiggleTime = 1.5f;

	private float currentWiggleTime;

	private float stuckTime;

	private float neededStuckTime = 1.5f;

	private Vector3 lastPosStuck = Vector3.zero;

	private RoomBase lastFoundRoom;

	private Vector3 lastPosRoomCheck = Vector3.zero;

	private bool isCorrecting;

	private float facingDeadzoneInitialCorrection = 8f;

	private float facingDeadzoneCorrectedAngle = 1f;

	private float puddleCheckTimer;

	private float puddleCheckTime = 1f;

	private AudioObject currentVacuumLoop;

	private AudioObject currentPuddleFinishedSound;

	private float loopFadeTime = 0.5f;

	private string startSound = "vacuum_start";

	private string stopSound = "vacuum_stop";

	private string loopSound = "vacuum_loop";

	private string puddleFinishedSound = "vacuum_puddle";

	private Vector3 centerOfMassOffset = new Vector3(0f, -0.25f, 0f);

	private bool isGrounded;

	private int lastGroundedCheckFrame = -1;

	private float groundedDistanceCheck = 0.3f;

	private float grabbedGroundedDistanceCheck = 0.4f;

	private float ungroundedTime;

	private float ungroundedShutoffTime = 3f;

	private int liquidCleanupFrameBuffer = 5;

	private List<LiquidPuddle> activePuddles = new List<LiquidPuddle>();

	private Dictionary<LiquidPuddle, int> liquidPuddleCleanupDict = new Dictionary<LiquidPuddle, int>();

	private ulong objID;

	private BoundingBoxComponent bbcRef;

	private NavmeshHelper navmeshRef;

	private void Awake()
	{
		navmeshRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
	}

	private void OnDestroy()
	{
		if (currentVacuumLoop != null)
		{
			currentVacuumLoop.Stop(loopFadeTime);
			currentVacuumLoop = null;
		}
	}

	private void Start()
	{
		Vector3 inertiaTensor = rb.inertiaTensor;
		Quaternion inertiaTensorRotation = rb.inertiaTensorRotation;
		rb.centerOfMass += centerOfMassOffset;
		rb.inertiaTensor = inertiaTensor;
		rb.inertiaTensorRotation = inertiaTensorRotation;
		rb.maxAngularVelocity = 15f;
		objID = GetComponent<ObjectID>().GetUID();
	}

	private void Update()
	{
		if (currentPuddleFinishedSound != null && !PauseController.IsPaused() && !currentPuddleFinishedSound.IsPlaying())
		{
			currentPuddleFinishedSound = null;
		}
		if (currentVacuumLoop != null)
		{
			currentVacuumLoop.transform.position = rb.transform.position;
		}
		if (!(currentTargetPuddle == null))
		{
			return;
		}
		currentPath = null;
		if (puddleCheckTimer < puddleCheckTime)
		{
			puddleCheckTimer += Time.deltaTime;
			return;
		}
		RoomBase roomToCheck = null;
		if (MathUtil.Vector3AlmostEqual(rb.transform.position, lastPosRoomCheck, 0.5f))
		{
			roomToCheck = lastFoundRoom;
		}
		CheckForNewPuddle(roomToCheck);
	}

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		base.OnObjectBittenByDog(biteVector, dog);
		AudioController.Play(startSound, rb.transform);
		isSpinning = true;
		currentSpinTime = 0f;
	}

	public void OnPetting()
	{
		if (!isWiggling)
		{
			isWiggling = true;
			currentWiggleTime = 0f;
		}
	}

	public void OnPettingStart()
	{
		if (!isWiggling)
		{
			AudioController.Play(startSound, rb.transform);
		}
	}

	private void CheckForNewPuddle(RoomBase roomToCheck = null)
	{
		if (bbcRef == null)
		{
			bbcRef = GetComponent<BoundingBoxComponent>();
			if (bbcRef == null)
			{
				return;
			}
		}
		puddleCheckTimer = 0f;
		if (!CheckIsGrounded())
		{
			return;
		}
		RoomBase roomBase = roomToCheck;
		if (roomBase == null)
		{
			roomBase = (lastFoundRoom = bbcRef.GetCurrentRoom());
			lastPosRoomCheck = rb.transform.position;
		}
		if (!(roomBase != null) || !roomBase.DoPuddlesExist())
		{
			return;
		}
		List<PlacedObjectInfo> placedPuddles = roomBase.GetPlacedPuddles();
		currentTargetPuddle = GetClosestPuddle(placedPuddles);
		if (currentTargetPuddle != null)
		{
			currentPathIndex = 0;
			currentPuddleRoom = roomBase;
			currentPath = navmeshRef.GetPath(base.gameObject, currentTargetPuddle.transform.position);
			if (currentPath.Length == 0)
			{
				currentTargetPuddle = null;
			}
			else if (currentVacuumLoop == null)
			{
				AudioController.Play(startSound, rb.transform);
			}
		}
	}

	private void LateUpdate()
	{
		wasCollidingWithPuddle = false;
		PuddleCleanup();
	}

	private void FixedUpdate()
	{
		if (currentTargetPuddle != null && currentVacuumLoop == null)
		{
			currentVacuumLoop = AudioController.Play(loopSound, rb.transform.position);
		}
		if (isWiggling)
		{
			currentWiggleTime += Time.fixedDeltaTime;
			if (currentWiggleTime >= neededWiggleTime)
			{
				isWiggling = false;
			}
			if (CheckIsGrounded())
			{
				float num = Mathf.Sin(currentWiggleTime * 25f);
				RotateInDirection(rb.transform.up * num);
			}
			return;
		}
		if (isSpinning)
		{
			currentSpinTime += Time.fixedDeltaTime;
			if (currentSpinTime >= neededSpinTime)
			{
				isSpinning = false;
			}
			if (CheckIsGrounded())
			{
				RotateInDirection(rb.transform.up);
			}
			return;
		}
		if (currentTargetPuddle == null)
		{
			if (currentVacuumLoop != null)
			{
				currentVacuumLoop.Stop(loopFadeTime);
				currentVacuumLoop = null;
			}
			return;
		}
		brushLeft.transform.Rotate(sweeperRot * Time.fixedDeltaTime);
		brushRight.transform.Rotate(sweeperRot * Time.fixedDeltaTime);
		if (wasCollidingWithPuddle)
		{
			return;
		}
		if (stuckTime >= neededStuckTime)
		{
			isBackingUp = true;
			currentBackupTime = 0f;
			stuckTime = 0f;
		}
		if (isBackingUp)
		{
			if (CheckIsGrounded())
			{
				currentBackupTime += Time.fixedDeltaTime;
				MoveInDirection(-rb.transform.forward);
				if (currentBackupTime >= neededBackupTime)
				{
					isBackingUp = false;
				}
			}
			return;
		}
		if (currentPathIndex + 1 >= currentPath.Length)
		{
			currentPathIndex = 0;
			currentTargetPuddle = null;
			return;
		}
		if (Vector3.Distance(rb.position, currentPath[currentPathIndex + 1].position) <= targetDistance && currentPathIndex < currentPath.Length - 2)
		{
			currentPathIndex++;
		}
		while (RaycastUtil.NavmeshPipeCast(rb.transform.position, currentPath[currentPathIndex + 1].position - rb.transform.position, Vector3.Distance(rb.transform.position, currentPath[currentPathIndex + 1].position)))
		{
			currentPathIndex--;
			if (currentPathIndex < 0)
			{
				currentPathIndex = 0;
				currentTargetPuddle = null;
				return;
			}
		}
		MoveTowardsPoint(currentPath[currentPathIndex + 1].position);
		if (MathUtil.Vector3AlmostEqual(rb.transform.position, lastPosStuck))
		{
			stuckTime += Time.fixedDeltaTime;
		}
		else
		{
			stuckTime = 0f;
		}
		lastPosStuck = rb.transform.position;
	}

	private void MoveInDirection(Vector3 v)
	{
		float num = 1f;
		if (ObjectConnectionsManager.IsObjectBeingGrabbedByAnyDog(objID))
		{
			num = dogGrabbingMoveMultiplier;
		}
		rb.AddForce(v * moveForce * num);
	}

	private void RotateInDirection(Vector3 d)
	{
		float num = 1f;
		if (ObjectConnectionsManager.IsObjectBeingGrabbedByAnyDog(objID))
		{
			num = dogGrabbingRotMultiplier;
		}
		if (isWiggling)
		{
			num = wiggleMultiplier;
		}
		else if (isSpinning)
		{
			num = spinMultiplier;
		}
		rb.AddRelativeTorque(d * rotForce * num);
	}

	private void MoveTowardsPoint(Vector3 point)
	{
		if (!CheckIsGrounded())
		{
			return;
		}
		float positiveBoundAngle = AngleUtil.GetPositiveBoundAngle(AngleUtil.GetYFacingAngle(rb.transform.position, point));
		float positiveBoundAngle2 = AngleUtil.GetPositiveBoundAngle(rb.transform.eulerAngles.y - 90f);
		float num = Mathf.Abs(positiveBoundAngle - positiveBoundAngle2);
		if ((isCorrecting && num > facingDeadzoneCorrectedAngle) || (!isCorrecting && num > facingDeadzoneInitialCorrection))
		{
			isCorrecting = true;
			bool flag = true;
			if (num >= 180f)
			{
				if (positiveBoundAngle2 > positiveBoundAngle)
				{
					flag = false;
				}
			}
			else if (positiveBoundAngle > positiveBoundAngle2)
			{
				flag = false;
			}
			if (flag)
			{
				RotateInDirection(-rb.transform.up);
			}
			else
			{
				RotateInDirection(rb.transform.up);
			}
		}
		else
		{
			isCorrecting = false;
			MoveInDirection(rb.transform.forward);
		}
	}

	private bool CheckIsGrounded()
	{
		if (lastGroundedCheckFrame >= Time.frameCount)
		{
			return isGrounded;
		}
		float dist = groundedDistanceCheck;
		if (ObjectConnectionsManager.IsObjectBeingGrabbedByAnyDog(objID))
		{
			dist = grabbedGroundedDistanceCheck;
		}
		lastGroundedCheckFrame = Time.frameCount;
		isGrounded = RaycastUtil.StageRaycast(rb.transform.position, -rb.transform.up, dist);
		if (isGrounded)
		{
			ungroundedTime = 0f;
		}
		else
		{
			ungroundedTime += Time.deltaTime;
			if (ungroundedTime >= ungroundedShutoffTime)
			{
				currentPathIndex = 0;
				currentTargetPuddle = null;
			}
		}
		return isGrounded;
	}

	private GameObject GetClosestPuddle(List<PlacedObjectInfo> puddles)
	{
		GameObject result = null;
		float num = float.PositiveInfinity;
		for (int i = 0; i < puddles.Count; i++)
		{
			float num2 = Vector3.Distance(rb.position, puddles[i].objectRef.transform.position);
			if (num2 < num)
			{
				num = num2;
				result = puddles[i].objectRef;
			}
		}
		return result;
	}

	public void OnCollisionWithPuddle(LiquidPuddle puddle)
	{
		if (!(currentTargetPuddle == null) && CheckIsGrounded())
		{
			if (!liquidPuddleCleanupDict.ContainsKey(puddle))
			{
				activePuddles.Add(puddle);
				liquidPuddleCleanupDict.Add(puddle, Time.frameCount);
			}
			else
			{
				liquidPuddleCleanupDict[puddle] = Time.frameCount;
			}
		}
	}

	private void PuddleCleanup()
	{
		for (int num = activePuddles.Count - 1; num >= 0; num--)
		{
			if (activePuddles[num] == null || Time.frameCount - liquidPuddleCleanupDict[activePuddles[num]] > liquidCleanupFrameBuffer)
			{
				liquidPuddleCleanupDict.Remove(activePuddles[num]);
				activePuddles.RemoveAt(num);
			}
			else
			{
				PuddleCleanupIndividual(activePuddles[num]);
			}
		}
	}

	private void PuddleCleanupIndividual(LiquidPuddle puddle)
	{
		if (puddle == null)
		{
			return;
		}
		puddle.OnCleanup();
		wasCollidingWithPuddle = true;
		if (puddle == null || puddle.GetLifetime() <= 0f)
		{
			currentTargetPuddle = null;
			activePuddles.Remove(puddle);
			liquidPuddleCleanupDict.Remove(puddle);
			CheckForNewPuddle(currentPuddleRoom);
			if (currentPuddleFinishedSound == null)
			{
				currentPuddleFinishedSound = AudioController.Play(puddleFinishedSound, rb.transform);
			}
			if (currentTargetPuddle == null)
			{
				AudioController.Play(stopSound, rb.transform);
			}
		}
	}
}
