using System;
using Infrastructure.Services;
using MalbersAnimations;
using NewGameplayScripts;
using Tasks_for_levels;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance;

	private float volume = 1f;

	private ITask taskService;

	private float volumeMultiplier = 1.5f;

	[SerializeField]
	public AudioClipsRefsSO audioClipsRefsSO;

	[SerializeField]
	private AnimalAIClick cat;

	[SerializeField]
	private AnimalAIClick dog;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		taskService = AllServices.Container.Single<ITaskService>().GetCurrentTask();
		MovementSystem.Instance.OnStopGrabbing += OnObjectPlaced;
		MovementSystem.Instance.OnStartGrabbing += OnObjectRemoved;
		MovementSystem.Instance.OnCannotPlacedObject += OnCanNotPlaceObject;
		if (taskService != null)
		{
			taskService.TaskFinished += OnTaskFinished;
		}
		if (cat != null)
		{
			cat.OnCatInteracted += Cat_OnCatInteracted;
		}
		if (dog != null)
		{
			dog.OnDogInteracted += Dog_OnDogInteracted;
		}
	}

	private void OnDestroy()
	{
		MovementSystem.Instance.OnStopGrabbing -= OnObjectPlaced;
		MovementSystem.Instance.OnStartGrabbing -= OnObjectRemoved;
		MovementSystem.Instance.OnCannotPlacedObject -= OnCanNotPlaceObject;
		if (taskService != null)
		{
			taskService.TaskFinished -= OnTaskFinished;
		}
		if (cat != null)
		{
			cat.OnCatInteracted -= Cat_OnCatInteracted;
		}
		if (dog != null)
		{
			dog.OnDogInteracted -= Dog_OnDogInteracted;
		}
	}

	private void OnObjectPlaced(object sender, EventArgs e)
	{
		PlaySound(audioClipsRefsSO.objectPlaced, Camera.main.transform.position, Instance.GetVolume() * 0.5f * volumeMultiplier);
	}

	public void OnPlantPlaced()
	{
		PlaySound(audioClipsRefsSO.objectRemoved, Camera.main.transform.position, Instance.GetVolume() * 0.5f * volumeMultiplier);
	}

	private void OnObjectRemoved(object sender, EventArgs e)
	{
		PlaySound(audioClipsRefsSO.objectRemoved, Camera.main.transform.position, Instance.GetVolume() * 0.5f * volumeMultiplier);
	}

	private void OnCanNotPlaceObject(object sender, EventArgs e)
	{
		PlaySound(audioClipsRefsSO.canNotPlaceObject, Camera.main.transform.position, Instance.GetVolume() * 0.5f * volumeMultiplier);
	}

	private void Cat_OnCatInteracted(object sender, EventArgs e)
	{
		PlaySound(audioClipsRefsSO.catMeow, Camera.main.transform.position, Instance.GetVolume() * 0.2f * volumeMultiplier);
	}

	private void Dog_OnDogInteracted(object sender, EventArgs e)
	{
		PlaySound(audioClipsRefsSO.dogBark, Camera.main.transform.position, Instance.GetVolume() * 0.2f * volumeMultiplier);
	}

	public void OnButtonClick()
	{
		PlaySound(audioClipsRefsSO.buttonClicked, Camera.main.transform.position, Instance.GetVolume());
	}

	public void OnTyping()
	{
		PlaySound(audioClipsRefsSO.typing, Camera.main.transform.position, Instance.GetVolume() * 0.1f * volumeMultiplier);
	}

	public void OnDing()
	{
		PlaySound(audioClipsRefsSO.ding, Camera.main.transform.position, Instance.GetVolume() * 0.25f * volumeMultiplier);
	}

	public void OnBoxOpen()
	{
		PlaySound(audioClipsRefsSO.boxOpen, Camera.main.transform.position, Instance.GetVolume() * volumeMultiplier);
	}

	public void OnBoxTakeItem()
	{
		PlaySound(audioClipsRefsSO.boxTakeItem, Camera.main.transform.position, Instance.GetVolume() * 0.25f * volumeMultiplier);
	}

	public void OnBoxDisappear()
	{
		PlaySound(audioClipsRefsSO.boxDisappear, Camera.main.transform.position, Instance.GetVolume() * volumeMultiplier);
	}

	public void OnRecievePoints()
	{
		PlaySound(audioClipsRefsSO.recievePoints, Camera.main.transform.position, Instance.GetVolume() * 0.5f * volumeMultiplier);
	}

	public void OnCoinsNotEnough()
	{
		PlaySound(audioClipsRefsSO.coinsNotEnough, Camera.main.transform.position, Instance.GetVolume() * 0.25f * volumeMultiplier);
	}

	public void OnCardDraw()
	{
		PlaySound(audioClipsRefsSO.cardDraw, Camera.main.transform.position, Instance.GetVolume() * 0.25f * volumeMultiplier);
	}

	public void OnDiaryPageFlip()
	{
		PlaySound(audioClipsRefsSO.diaryPages, Camera.main.transform.position, Instance.GetVolume() * 0.1f * volumeMultiplier);
	}

	public void OnObjectTurnOn()
	{
		PlaySound(audioClipsRefsSO.objectTurnOn, Camera.main.transform.position, Instance.GetVolume() * 0.15f * volumeMultiplier);
	}

	public void OnObjectTurnOff()
	{
		PlaySound(audioClipsRefsSO.objectTurnOff, Camera.main.transform.position, Instance.GetVolume() * 0.15f * volumeMultiplier);
	}

	private void OnTaskFinished()
	{
		PlaySound(audioClipsRefsSO.taskCompleted, Camera.main.transform.position, Instance.GetVolume() * 0.25f * volumeMultiplier);
	}

	private void PlaySound(AudioClip audioClip, Vector3 position, float volume)
	{
		AudioSource.PlayClipAtPoint(audioClip, position, volume);
	}

	public void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume)
	{
		if (audioClipArray.Length != 0)
		{
			PlaySound(audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Length)], position, volume);
		}
	}

	public void MuteSounds(bool muted)
	{
		volume = (muted ? 0f : 1f);
	}

	public void ChangeVolume(float newVolume)
	{
		volume = newVolume;
	}

	private float GetVolume()
	{
		return volume;
	}
}
