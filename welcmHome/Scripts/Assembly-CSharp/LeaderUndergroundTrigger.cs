using System.Collections;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Playables;

public class LeaderUndergroundTrigger : MonoBehaviour
{
	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private UndergroundCloset hidingInteractable;

	private PlayerController playerController;

	private FirstPersonController playerControls;

	private Animator anim;

	private JumpscareTrigger undergroundJumpscare;

	public AISoundForLeaderUnderground sound;

	private bool dialogueHasStarted;

	private bool coroutineStarted;

	private bool isRotating;

	private bool isLooking;

	public EventReference killSounds;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		playerControls = playerController.transform.GetComponent<FirstPersonController>();
		anim = GetComponent<Animator>();
		undergroundJumpscare = Object.FindAnyObjectByType<JumpscareTrigger>();
		if (undergroundJumpscare != null)
		{
			undergroundJumpscare.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (playerController.DialogueBox.activeSelf)
		{
			dialogueHasStarted = true;
		}
		if (dialogueHasStarted && !playerController.DialogueBox.activeSelf)
		{
			director.Play();
			dialogueHasStarted = false;
		}
		if (!hidingInteractable.isHiding && !coroutineStarted && isLooking)
		{
			director.Stop();
			StartCoroutine(StartGameOver());
		}
	}

	private void RotateTowardsDestination(Transform point)
	{
		if (!isRotating)
		{
			isRotating = true;
			Vector3 normalized = (point.position - base.transform.position).normalized;
			normalized.y = 0f;
			Quaternion endValue = Quaternion.LookRotation(normalized);
			base.transform.DORotateQuaternion(endValue, 1f).OnComplete(delegate
			{
				isRotating = false;
			});
		}
	}

	private IEnumerator StartGameOver()
	{
		coroutineStarted = true;
		GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		RotateTowardsDestination(playerController.transform);
		anim.SetBool("isWalking", value: true);
		yield return new WaitForSeconds(1f);
		playerControls.DisableInput();
		playerController.GetComponentInChildren<PauseMenu>().StartGameOver();
		yield return new WaitForSeconds(4f);
		playKillSound();
		base.transform.DOMove(playerController.transform.position, 10f).SetEase(Ease.Linear);
		yield return new WaitForSeconds(7f);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void StartLooking(bool setLooking)
	{
		isLooking = setLooking;
	}

	private void playKillSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(killSounds);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void EnableUndergroundJumpscare()
	{
		if (base.transform.GetComponent<LeaderUndergroundTrigger>() != null)
		{
			base.transform.GetComponent<LeaderUndergroundTrigger>().enabled = false;
		}
		if (undergroundJumpscare != null)
		{
			undergroundJumpscare.gameObject.SetActive(value: true);
		}
	}
}
