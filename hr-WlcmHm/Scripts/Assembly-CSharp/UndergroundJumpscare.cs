using System.Collections;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class UndergroundJumpscare : Jumpscare
{
	[Header("Jumpscare Settings")]
	[SerializeField]
	private float durationUntilTalk;

	[Header("Smash Mechanic Settings")]
	[SerializeField]
	private Image smashBar;

	[SerializeField]
	private float barDecreaseRate = 0.5f;

	[SerializeField]
	private float barIncreaseAmount = 0.2f;

	private GameObject smashMenu;

	private GameObject player;

	public GameObject door;

	private PlayerController playerController;

	private FirstPersonController firstPersonController;

	private Animator anim;

	private bool isSmashing;

	private bool dialogueHasStarted;

	private bool triggered;

	public EventReference killSounds;

	public EventReference DeathSound;

	private void Start()
	{
		smashMenu = smashBar.transform.parent.gameObject;
		SetSmashMenu(setBool: false);
		base.gameObject.SetActive(value: false);
		player = GameObject.FindGameObjectWithTag("Player");
		playerController = player.GetComponent<PlayerController>();
		firstPersonController = player.GetComponent<FirstPersonController>();
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if (playerController.DialogueBox.activeSelf)
		{
			dialogueHasStarted = true;
		}
		if (dialogueHasStarted && !playerController.DialogueBox.activeSelf && !triggered)
		{
			if (InventoryManager.Instance.inventoryItems.Contains("Knife"))
			{
				StartSmashMechanic();
			}
			else
			{
				StartCoroutine(GameOverTransition());
			}
			dialogueHasStarted = false;
		}
		if (!isSmashing)
		{
			return;
		}
		smashBar.fillAmount -= barDecreaseRate * Time.deltaTime;
		if (smashBar.fillAmount <= 0f)
		{
			StartCoroutine(GameOverTransition());
			isSmashing = false;
			SetSmashMenu(setBool: false);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			smashBar.fillAmount += barIncreaseAmount;
			if (smashBar.fillAmount >= 1f)
			{
				isSmashing = false;
				smashBar.fillAmount = 1f;
				door.SetActive(value: true);
				StartCoroutine(StartKillTransition());
			}
		}
	}

	public override void Scare()
	{
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		base.gameObject.SetActive(value: true);
		StartCoroutine(StartJumpscare());
	}

	private IEnumerator StartJumpscare()
	{
		RotateTowardsDestination(player.transform);
		base.transform.GetComponent<CapsuleCollider>().enabled = false;
		yield return new WaitForSeconds(durationUntilTalk);
		base.transform.GetComponent<NPCBaseController>().Interact();
	}

	private void StartSmashMechanic()
	{
		smashBar.fillAmount = 0.5f;
		SetSmashMenu(setBool: true);
		firstPersonController.DisableInput(unlockMouse: false);
		triggered = true;
		isSmashing = true;
	}

	private void RotateTowardsDestination(Transform player)
	{
		Vector3 normalized = (player.position - base.transform.position).normalized;
		normalized.y = 0f;
		Quaternion endValue = Quaternion.LookRotation(normalized);
		base.transform.DORotateQuaternion(endValue, 1f);
	}

	private void SetSmashMenu(bool setBool)
	{
		foreach (Transform item in smashMenu.transform)
		{
			item.gameObject.SetActive(setBool);
		}
	}

	private IEnumerator StartKillTransition()
	{
		SetSmashMenu(setBool: false);
		playerController.GetComponentInChildren<PauseMenu>().SetKillTransition(setBool: true);
		yield return new WaitForSeconds(4f);
		playKillSound();
		yield return new WaitForSeconds(2f);
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		playerController.GetComponentInChildren<PauseMenu>().SetKillTransition(setBool: false);
		anim.SetTrigger("Dead");
		playDeathSound();
		float duration = 2f;
		ShortcutExtensions.DOMove(endValue: new Vector3(base.transform.position.x, base.transform.position.y - 0.8f, base.transform.position.z), target: base.transform, duration: duration).SetEase(Ease.OutCubic);
		firstPersonController.EnableInput();
	}

	private IEnumerator GameOverTransition()
	{
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		firstPersonController.DisableInput();
		playerController.GetComponentInChildren<PauseMenu>().StartGameOver();
		yield return new WaitForSeconds(4f);
		playKillSound();
		yield return new WaitForSeconds(2f);
	}

	private void playKillSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(killSounds);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	private void playDeathSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(DeathSound);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}
}
