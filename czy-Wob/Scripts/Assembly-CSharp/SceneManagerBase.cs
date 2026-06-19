using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBase : MonoBehaviour
{
	public delegate void PreloadCallback();

	protected string titleSceneName = "00_title";

	protected string homeSceneName = "01_home";

	protected string breedingSceneName = "02_breedingCenter";

	protected GameMode currentGameMode;

	protected bool isAtTitleScreen;

	protected Coroutine currentSaveRoutine;

	protected bool sceneTransitionInProgress;

	protected GameMode currentlyTransitioningToGameMode;

	protected bool forceTravelOnSaveFailure;

	protected bool isClearingBreedingDogs;

	protected SaveLoadManager.SaveFinishedCallback goToBreedingCenterCallback;

	protected SaveLoadManager.SaveFinishedCallback finalSceneTransitionCallback;

	protected bool sceneStarted;

	public virtual void PreloadScene(PreloadCallback newCallback)
	{
		sceneStarted = false;
		newCallback();
	}

	public virtual bool IsBreedingScene()
	{
		return false;
	}

	public virtual void StartScene()
	{
		SFXOverlord.RemoveAllSFXLocks();
		if (currentGameMode == GameMode.BREEDING && currentSaveRoutine != null)
		{
			StopCoroutine(currentSaveRoutine);
			currentSaveRoutine = null;
		}
		sceneStarted = true;
		currentSaveRoutine = null;
		ObjectIndicatorManager globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ObjectIndicatorManager>(GlobalObject.OBJECT_INDICATOR_MANAGER);
		if (globalComponent != null)
		{
			globalComponent.UpdateSceneRef(this);
		}
	}

	public bool HasSceneStarted()
	{
		return sceneStarted;
	}

	public bool IsAtTitleScreen()
	{
		return isAtTitleScreen;
	}

	public void CheckTitle()
	{
		isAtTitleScreen = false;
		if (SceneManager.GetActiveScene().name.Contains("title"))
		{
			isAtTitleScreen = true;
		}
	}

	public void SetGameMode()
	{
		isAtTitleScreen = false;
		string text = SceneManager.GetActiveScene().name;
		if (text.Contains("title"))
		{
			isAtTitleScreen = true;
			currentGameMode = GameMode.HOME;
		}
		else if (text.Contains("home"))
		{
			currentGameMode = GameMode.HOME;
		}
		else if (text.Contains("breeding"))
		{
			currentGameMode = GameMode.BREEDING;
		}
		else
		{
			Debug.LogError("No valid scene found");
		}
	}

	public GameMode GetGameMode()
	{
		return currentGameMode;
	}

	private void SceneTransitionFinishedCallback(bool saveResult)
	{
		if (!saveResult)
		{
			Debug.LogError("Something went wrong while transitioning between scenes. Unable to save.");
		}
	}

	public void GoToTitle()
	{
		StartCoroutine(TransitionToScene(GameMode.TITLE, SceneTransitionFinishedCallback, save: false, saveInventoryDateTimeAndGoalsOnly: false, forceTravelOnFailure: true));
	}

	public void GoHome(bool forceTravel = false, bool clearBreedingDogs = true)
	{
		if (isClearingBreedingDogs)
		{
			Debug.LogError("Attempting to clear breeding dogs but we're already doing that.");
		}
		else if (!forceTravel && currentGameMode == GameMode.HOME)
		{
			Debug.LogError("Attempting to travel home when we're already there.");
		}
		else if (clearBreedingDogs)
		{
			isClearingBreedingDogs = true;
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			StartCoroutine(registrationScript.saveLoadManager.ClearBreedingDogs(BreedingDogsClearedForGoHomeCallback));
		}
		else
		{
			BreedingDogsClearedForGoHomeCallback(result: true);
		}
	}

	private void BreedingDogsClearedForGoHomeCallback(bool result)
	{
		isClearingBreedingDogs = false;
		SFXOverlord.RemoveAllSFXLocks();
		StartCoroutine(TransitionToScene(GameMode.HOME, SceneTransitionFinishedCallback, save: true, saveInventoryDateTimeAndGoalsOnly: true, forceTravelOnFailure: true));
	}

	public IEnumerator GoToBreedingCenter(SaveableDog dogA, SaveableDog dogB, SaveLoadManager.SaveFinishedCallback callback)
	{
		goToBreedingCenterCallback = callback;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		yield return StartCoroutine(registrationScript.saveLoadManager.SaveDogsForBreeding(dogA, dogB, OnDogsSavedForBreeding));
	}

	private void OnDogsSavedForBreeding(bool result)
	{
		if (!result)
		{
			Debug.LogError("Unable to save dogs for breeding. Cancelling breeding request.");
			goToBreedingCenterCallback?.Invoke(result: false);
		}
		else
		{
			StartCoroutine(TransitionToScene(GameMode.BREEDING, goToBreedingCenterCallback));
		}
	}

	protected IEnumerator TransitionToScene(GameMode newSceneMode, SaveLoadManager.SaveFinishedCallback callback, bool save = true, bool saveInventoryDateTimeAndGoalsOnly = false, bool forceTravelOnFailure = false)
	{
		if (sceneTransitionInProgress)
		{
			Debug.LogError("Attempting to double-transition scenes.");
			callback?.Invoke(result: false);
			yield break;
		}
		sceneTransitionInProgress = true;
		finalSceneTransitionCallback = callback;
		forceTravelOnSaveFailure = forceTravelOnFailure;
		currentlyTransitioningToGameMode = newSceneMode;
		ObjectRegistration regRef = ObjectRegistration.GetRegistrationScript();
		PauseController globalComponent = regRef.GetGlobalComponent<PauseController>(GlobalObject.GLOBAL_CLOCK);
		DogRegistration globalComponent2 = regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		ConstructionManager globalComponent3 = regRef.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER, nullAllowed: true);
		globalComponent2.CancelAllDogRequests();
		if (globalComponent3 != null)
		{
			globalComponent3.PrepareForTravel();
		}
		if (globalComponent != null)
		{
			globalComponent.OnSceneChanged();
		}
		if (currentSaveRoutine != null)
		{
			Debug.LogError("Calling TransitionToScene while a save routine is still in progress. This is not expected.");
			yield return currentSaveRoutine;
			currentSaveRoutine = null;
		}
		if (saveInventoryDateTimeAndGoalsOnly)
		{
			currentSaveRoutine = StartCoroutine(regRef.saveLoadManager.SaveData(buildables: false, inventory: true, dateTime: true, worldObjects: false, dogs: false, tutorial: false, gameMode: true, research: false, floraUnlocks: false, dogDenManager: false, goals: true, TransitionToSceneInitialSaveCallback));
		}
		else if (save)
		{
			currentSaveRoutine = StartCoroutine(regRef.saveLoadManager.SaveEverything(TransitionToSceneInitialSaveCallback));
		}
		else
		{
			TransitionToSceneInitialSaveCallback(saveResult: true);
		}
	}

	private void TransitionToSceneInitialSaveCallback(bool saveResult)
	{
		currentSaveRoutine = null;
		if (!saveResult)
		{
			Debug.LogError("Save failure during TransitionToScene: " + currentlyTransitioningToGameMode);
			if (!forceTravelOnSaveFailure)
			{
				finalSceneTransitionCallback?.Invoke(result: false);
				finalSceneTransitionCallback = null;
				sceneTransitionInProgress = false;
				return;
			}
		}
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).StopAllDogBehaviors();
		TutorialController.OnSceneChange();
		DogDenManager.PrepareForTravel();
		registrationScript.PrepareForTravel();
		CheatEngine.DestroyAllDogs(null, safeDestroy: true, fromScript: true, fromTravel: true);
		TransitionToSceneGameModeSaveCallback(saveResult);
	}

	private void TransitionToSceneGameModeSaveCallback(bool saveResult)
	{
		currentSaveRoutine = null;
		if (!saveResult)
		{
			Debug.LogError("Save failure attempting to save the Game Mode during TransitionToScene: " + currentlyTransitioningToGameMode);
			finalSceneTransitionCallback?.Invoke(result: false);
			finalSceneTransitionCallback = null;
			sceneTransitionInProgress = false;
			return;
		}
		SceneTransition globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneTransition>(GlobalObject.SCENE_TRANSITION);
		if (currentlyTransitioningToGameMode == GameMode.HOME)
		{
			globalComponent.TransitionToScene(homeSceneName);
		}
		else if (currentlyTransitioningToGameMode == GameMode.BREEDING)
		{
			globalComponent.TransitionToScene(breedingSceneName);
		}
		else if (currentlyTransitioningToGameMode == GameMode.TITLE)
		{
			globalComponent.TransitionToScene(titleSceneName);
		}
		else
		{
			Debug.LogError("Invalid scene mode: " + currentlyTransitioningToGameMode);
		}
		finalSceneTransitionCallback?.Invoke(result: true);
		finalSceneTransitionCallback = null;
		sceneTransitionInProgress = false;
	}
}
