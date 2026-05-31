using DG.Tweening;
using UnityEngine;

public class NightTimeLeaderWalk : MonoBehaviour
{
	[SerializeField]
	private Transform[] walkPoints;

	[SerializeField]
	private float[] lerpDurations;

	private PlayerController playerController;

	public Animator anim;

	private bool dialogueHasStarted;

	public bool canWalk;

	private int currentPointIndex;

	private float timeElapsed;

	private Vector3 startPosition;

	private bool isRotating;

	public GameObject killbox0;

	public GameObject killbox1;

	public GameObject killbox2;

	public NPCBaseController AI;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		anim = GetComponent<Animator>();
		startPosition = base.transform.position;
		anim.SetBool("isWalking", value: true);
		dialogueHasStarted = true;
		AI.Activity = EActivity.WALKING;
	}

	private void Update()
	{
		if (playerController.DialogueBox.activeSelf)
		{
			dialogueHasStarted = true;
		}
		if (dialogueHasStarted && !playerController.DialogueBox.activeSelf)
		{
			canWalk = true;
			RotateTowardsDestination(walkPoints[currentPointIndex]);
		}
		if (canWalk && currentPointIndex < walkPoints.Length)
		{
			WalkToNextPoint();
		}
		if (currentPointIndex >= 1 && currentPointIndex < 5)
		{
			killbox0.gameObject.SetActive(value: false);
			killbox1.gameObject.SetActive(value: true);
			killbox2.gameObject.SetActive(value: false);
		}
		else if (currentPointIndex >= 5 && currentPointIndex < 20)
		{
			killbox0.gameObject.SetActive(value: false);
			killbox1.gameObject.SetActive(value: false);
			killbox2.gameObject.SetActive(value: true);
		}
		else if (currentPointIndex >= 20 && currentPointIndex < 25)
		{
			killbox0.gameObject.SetActive(value: false);
			killbox1.gameObject.SetActive(value: true);
			killbox2.gameObject.SetActive(value: false);
		}
		else if (currentPointIndex >= 25 && currentPointIndex < 40)
		{
			killbox0.gameObject.SetActive(value: true);
			killbox1.gameObject.SetActive(value: false);
			killbox2.gameObject.SetActive(value: false);
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
		if (Vector3.Distance(base.transform.position, position) < 0.1f)
		{
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
			RotateTowardsDestination(playerController.gameObject.transform);
			currentPointIndex = 0;
		}
	}

	public void RotateTowardsDestination(Transform point)
	{
		Vector3 normalized = (point.position - base.transform.position).normalized;
		normalized.y = 0f;
		Quaternion endValue = Quaternion.LookRotation(normalized);
		base.transform.DORotateQuaternion(endValue, 1f);
	}
}
