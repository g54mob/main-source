using FMOD.Studio;
using FMODUnity;
using TMPro;
using UnityEngine;

public class StoryClue : Collectible
{
	public delegate void StoryCluePickup();

	[Space]
	[SerializeField]
	private TMP_Text noteText;

	[TextArea]
	[SerializeField]
	private string storyText;

	public StoryCluePickup OnStoryCluePickup;

	public EventReference soundToPlayOnPickUp;

	private new void Start()
	{
		base.Start();
		if (noteText != null)
		{
			noteText.text = storyText;
		}
	}

	private new void Update()
	{
		base.Update();
	}

	public override void Interact()
	{
		PlayOnInteract();
		firstPersonController.isWalking = false;
		if (OnStoryCluePickup != null)
		{
			OnStoryCluePickup();
		}
		base.Interact();
	}

	public void PlayOnInteract()
	{
		EventInstance instance = RuntimeManager.CreateInstance(soundToPlayOnPickUp);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public override void Activate()
	{
	}

	public override void Deactivate()
	{
	}

	public override string GetActionName()
	{
		return "pick up";
	}
}
