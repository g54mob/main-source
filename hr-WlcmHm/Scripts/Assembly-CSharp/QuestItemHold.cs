using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemHold : QuestItemBase
{
	[Tooltip("Time in seconds")]
	[SerializeField]
	private float targetHoldTime;

	[SerializeField]
	private bool isClothes = true;

	private bool holdingKey;

	private float holdingTime;

	private Image progressImg;

	private FirstPersonController firstPersonController;

	private new void Start()
	{
		base.Start();
		progressImg = playerController.ProgressImage;
		firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
	}

	private void Update()
	{
		if (!holdingKey)
		{
			return;
		}
		firstPersonController.isWalking = false;
		holdingTime += Time.deltaTime;
		if (holdingTime >= targetHoldTime)
		{
			playerController.GetCurrentQuest().currentAmount++;
			PlayInteractSound();
			holdingTime = 0f;
			UpdateUI();
			firstPersonController.EnableInput();
			if (isClothes)
			{
				Object.Destroy(base.gameObject);
			}
			else if (GetComponentInChildren<ParticleSystem>() != null)
			{
				GetComponentInChildren<ParticleSystem>().Play();
				ItemCompleted();
			}
		}
		UpdateUI();
	}

	private void UpdateUI()
	{
		progressImg.fillAmount = holdingTime / targetHoldTime;
	}

	public override void Interact()
	{
		holdingKey = true;
	}

	public override void Activate()
	{
	}

	public override void Deactivate()
	{
		holdingKey = false;
		holdingTime = 0f;
		UpdateUI();
	}

	public override string GetActionType()
	{
		return "Hold";
	}

	private void ItemCompleted()
	{
		GetComponent<Collider>().enabled = false;
		GetComponentInChildren<InteractableLight>().transform.gameObject.SetActive(value: false);
	}

	private new void PlayInteractSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayOnPickUp);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}
}
