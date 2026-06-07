using System.Collections;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Rendering;

public class CultistInsideRun : MonoBehaviour
{
	[SerializeField]
	private float distance = 5f;

	[SerializeField]
	private Transform[] walkPoints;

	[SerializeField]
	private float[] lerpDurations;

	[SerializeField]
	private Volume globalVolumeBase;

	private PlayerController playerController;

	private FirstPersonController playerControls;

	private Animator anim;

	private PauseMenu pauseMenu;

	[HideInInspector]
	public bool canWalk;

	private int currentPointIndex;

	private float timeElapsed;

	private Vector3 startPosition;

	private bool isRotating;

	public EventReference killSounds;

	private bool coroutineStarted;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		playerControls = playerController.transform.GetComponent<FirstPersonController>();
		anim = GetComponent<Animator>();
		startPosition = base.transform.position;
		pauseMenu = Object.FindAnyObjectByType<PauseMenu>();
	}

	private void Update()
	{
		if (!coroutineStarted && !pauseMenu.isPaused)
		{
			if (canWalk && currentPointIndex < walkPoints.Length)
			{
				WalkToNextPoint();
			}
			float sqrMagnitude = (base.transform.position - playerController.transform.position).sqrMagnitude;
			float num = distance * distance;
			float target = ((sqrMagnitude <= num) ? 0.5f : 1f);
			globalVolumeBase.weight = Mathf.MoveTowards(globalVolumeBase.weight, target, 0.1f * Time.deltaTime);
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
		}
	}

	private void RotateTowardsDestination(Transform point)
	{
		Vector3 normalized = (point.position - base.transform.position).normalized;
		normalized.y = 0f;
		Quaternion endValue = Quaternion.LookRotation(normalized);
		base.transform.DORotateQuaternion(endValue, 1f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerControls.isWalking = false;
			GetComponent<AISoundForCultistRun>().enabled = false;
			StartCoroutine(StartGameOver());
		}
	}

	private IEnumerator StartGameOver()
	{
		coroutineStarted = true;
		playerControls.DisableInput();
		anim.SetBool("isWalking", value: false);
		RotateTowardsDestination(playerController.transform);
		playerController.GetComponentInChildren<PauseMenu>().StartGameOver();
		yield return new WaitForSeconds(4f);
		playKillSound();
		yield return new WaitForSeconds(2f);
		anim.SetBool("isWalking", value: true);
		base.transform.DOMove(playerController.transform.position, 10f).SetEase(Ease.Linear);
		yield return new WaitForSeconds(7f);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	private void playKillSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(killSounds);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}
}
