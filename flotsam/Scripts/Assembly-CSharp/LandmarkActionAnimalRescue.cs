using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Landmarks/Actions/Animal Rescue")]
public class LandmarkActionAnimalRescue : LandmarkAction
{
	[SerializeField]
	private LandmarkActionAnimalRescueUI _uiPrefab;

	[HideInInspector]
	public List<LandmarkRescueable> Rescueables = new List<LandmarkRescueable>();

	public override GameEventType InteractableEventType => GameEventType.LandmarkActionAnimalRescueInteractable;

	public override void OnLandmarkSpawned(LandmarkActionPersistentData persistentData = null)
	{
		base.OnLandmarkSpawned(persistentData);
		LandmarkRescueable[] componentsInChildren = _landmarkBehaviour.Landmark.GetComponentsInChildren<LandmarkRescueable>();
		Rescueables = new List<LandmarkRescueable>();
		LandmarkRescueable[] array = componentsInChildren;
		foreach (LandmarkRescueable landmarkRescueable in array)
		{
			if (!(landmarkRescueable.Agent == null) || !(landmarkRescueable.Bird == null))
			{
				landmarkRescueable.IsInteractable = true;
				Rescueables.Add(landmarkRescueable);
			}
		}
		if (base.State == ILandmarkActionStates.Active)
		{
			GameEventDispatcher.AddListener(GameEventType.BirdRescue, OnBirdRescued);
		}
		if (base.State != ILandmarkActionStates.Completed)
		{
			_landmarkBehaviour.Landmark.StartCoroutine(PlayAttentionSoundCoroutine());
		}
	}

	public override void Uninitialize()
	{
		base.Uninitialize();
		GameEventDispatcher.RemoveListener(GameEventType.BirdRescue, OnBirdRescued);
	}

	protected override void OnProjectFinished(Project project, bool success)
	{
		base.OnProjectFinished(project, Rescueables.Count == 0);
	}

	protected override void OnActivated()
	{
		GameEventDispatcher.AddListener(GameEventType.BirdRescue, OnBirdRescued);
	}

	protected override void OnDeactivated()
	{
		GameEventDispatcher.RemoveListener(GameEventType.BirdRescue, OnBirdRescued);
	}

	protected override void OnCompleted()
	{
		GameEventDispatcher.RemoveListener(GameEventType.BirdRescue, OnBirdRescued);
	}

	private void OnBirdRescued(GameEvent gameEvent)
	{
		BirdEvent birdEvent = gameEvent as BirdEvent;
		if (Rescueables.RemoveAll((LandmarkRescueable rescuable) => rescuable.Bird == birdEvent.Bird) != 0 && Rescueables.Count == 0)
		{
			OnProjectFinished(base.Project, success: true);
		}
	}

	private IEnumerator PlayAttentionSoundCoroutine()
	{
		while (true)
		{
			float seconds = Random.Range(GameManager.Settings.AudioSettings.AttentionVoiceInterval.Minimum, GameManager.Settings.AudioSettings.AttentionVoiceInterval.Maximum);
			yield return new WaitForSeconds(seconds);
			Rescueables.RemoveAll((LandmarkRescueable rescuable) => !rescuable.HasValidRescueables());
			if (Rescueables.Count != 0)
			{
				Agent agent = Rescueables[Random.Range(0, Rescueables.Count - 1)].Agent;
				if (!(agent == null))
				{
					AudioManager.Play(agent.Descriptor.VoicePack.AttentionSounds, agent.transform);
					continue;
				}
				break;
			}
			break;
		}
	}

	public override Project ReturnProject()
	{
		return new Project(base.UseBoat ? GameManager.Settings.ProjectSettings.RescueAnimalLandmark : GameManager.Settings.ProjectSettings.RescueAnimalLandmarkSwimming, _landmarkBehaviour.Landmark.ProjectTarget.gameObject);
	}

	public override void InitializeUI(LandmarkPanel landmarkPanel)
	{
		landmarkPanel.ReturnLandmarkActionUI<LandmarkActionRescueUI>().Initialize(this);
	}
}
