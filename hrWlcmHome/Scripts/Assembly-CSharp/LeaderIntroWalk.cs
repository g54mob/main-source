using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class LeaderIntroWalk : MonoBehaviour
{
	[SerializeField]
	private Transform[] walkPoints;

	[SerializeField]
	private float[] lerpDurations;

	[SerializeField]
	private Animator gatesAnim;

	[SerializeField]
	private EventReference gateEvent;

	[SerializeField]
	private EventInstance gateSound;

	[SerializeField]
	private bool isPoliceOfficer;

	[SerializeField]
	private bool shouldDisableInteraction = true;

	private PlayerController playerController;

	public Animator anim;

	private bool dialogueHasStarted;

	public bool canWalk;

	private int currentPointIndex;

	private float timeElapsed;

	private Vector3 startPosition;

	private bool isRotating;

	private bool gateSoundPlayed;

	private NPCBaseController npcBase;

	private bool hasTalked;

	[SerializeField]
	private bool overrideFinalRotation;

	[SerializeField]
	private Transform finalRotation;

	[SerializeField]
	private bool ignoreStartPosition;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		anim = GetComponent<Animator>();
		gateSound = RuntimeManager.CreateInstance(gateEvent);
		RuntimeManager.AttachInstanceToGameObject(gateSound, base.transform);
		startPosition = base.transform.position;
		npcBase = GetComponent<NPCBaseController>();
	}

	private void Update()
	{
		if (!hasTalked && npcBase.activity == EActivity.TALKING)
		{
			hasTalked = true;
		}
		if (hasTalked && npcBase.activity == EActivity.IDLE)
		{
			if (ignoreStartPosition)
			{
				startPosition = base.transform.position;
			}
			canWalk = true;
			if (gatesAnim != null)
			{
				gatesAnim.SetTrigger("Open");
				if (!gateSoundPlayed)
				{
					PlayGateSound();
					gateSoundPlayed = true;
				}
			}
			if (currentPointIndex < walkPoints.Length)
			{
				RotateTowardsDestination(walkPoints[currentPointIndex]);
			}
		}
		if (!canWalk || currentPointIndex >= walkPoints.Length)
		{
			return;
		}
		WalkToNextPoint();
		if (shouldDisableInteraction)
		{
			Collider component = base.transform.GetComponent<Collider>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
	}

	private void PlayGateSound()
	{
		if (gateSound.isValid())
		{
			gateSound.start();
			gateSound.release();
		}
	}

	private void WalkToNextPoint()
	{
		anim.SetBool("isWalking", value: true);
		if (!isRotating)
		{
			RotateTowardsDestination(walkPoints[currentPointIndex]);
			isRotating = true;
		}
		Vector3 position = walkPoints[currentPointIndex].position;
		float num = lerpDurations[currentPointIndex];
		base.transform.position = Vector3.Lerp(startPosition, position, timeElapsed / num);
		timeElapsed += Time.deltaTime;
		if (!(Vector3.Distance(base.transform.position, position) < 0.1f))
		{
			return;
		}
		timeElapsed = 0f;
		startPosition = base.transform.position;
		currentPointIndex++;
		if (currentPointIndex < walkPoints.Length)
		{
			isRotating = false;
			return;
		}
		canWalk = false;
		anim.SetBool("isWalking", value: false);
		if (!isPoliceOfficer)
		{
			RotateTowardsDestination(overrideFinalRotation ? finalRotation : playerController.gameObject.transform);
		}
		else
		{
			base.transform.gameObject.SetActive(value: false);
		}
	}

	public void RotateTowardsDestination(Transform point)
	{
		Vector3 normalized = (point.position - base.transform.position).normalized;
		normalized.y = 0f;
		Quaternion endValue = Quaternion.LookRotation(normalized);
		base.transform.DORotateQuaternion(endValue, 1f).OnComplete(delegate
		{
			isRotating = false;
		});
	}
}
