using System;
using System.Collections;
using Assets.BeneathThePetals.Scripts.Steam;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour, IInteractable
{
	[Header("Scene variables")]
	[SerializeField]
	private string sceneToChangeTo;

	[SerializeField]
	private string objectToSpawnAt;

	[SerializeField]
	private float timeToLoad = 1f;

	[SerializeField]
	private float fadeInSpeed = 1f;

	[SerializeField]
	private string actionName;

	[SerializeField]
	private GameObject fadeToBlack;

	[SerializeField]
	private GameObject globalUiObject;

	[Header("Lock/Unlock")]
	[SerializeField]
	private UnlockRequirementType unlockRequirement;

	[SerializeField]
	private StoryClue requiredStoryClue;

	[SerializeField]
	private int notificationDuration;

	[SerializeField]
	[TextArea]
	private string notificationText;

	[SerializeField]
	private bool isAchivement;

	[SerializeField]
	private AchivementEnums.Achivement achivement;

	private bool canUse;

	public EventReference eventToPlayAtSceneChange;

	private Animator anim;

	private PauseMenu pauseMenu;

	private PlayerController playerController;

	public UnlockRequirementType UnlockRequirement => unlockRequirement;

	private void Start()
	{
		canUse = unlockRequirement == UnlockRequirementType.NoRequirement;
		pauseMenu = UnityEngine.Object.FindAnyObjectByType<PauseMenu>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		if (unlockRequirement == UnlockRequirementType.ItemRequired && (bool)requiredStoryClue)
		{
			StoryClue storyClue = requiredStoryClue;
			storyClue.OnStoryCluePickup = (StoryClue.StoryCluePickup)Delegate.Combine(storyClue.OnStoryCluePickup, (StoryClue.StoryCluePickup)delegate
			{
				canUse = true;
			});
		}
	}

	public void ChangeScene()
	{
		StaticStateManager component = globalUiObject.GetComponent<StaticStateManager>();
		component.setSceneToChangeTo(sceneToChangeTo);
		component.setObjectToSpawnAt(objectToSpawnAt);
		component.setTimeToLoad(timeToLoad);
		SceneManager.sceneLoaded += OnSceneLoaded;
		StartCoroutine(MetaFade(0.01f));
	}

	public void Interact()
	{
		if (canUse)
		{
			base.gameObject.layer = 13;
			PlayInteractSound();
			GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isCurrentlyChangingScenes = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			if (GetComponent<Animator>() != null)
			{
				GetComponent<Animator>().SetTrigger("OpenDoors");
			}
			if (isAchivement)
			{
				MonoBehaviour.print("Unlocking achievement: " + achivement);
				SteamManager.Instance.UnlockAchievement(achivement.ToString());
			}
			ChangeScene();
			pauseMenu.SetPause(setPause: true);
		}
		else
		{
			playerController.ScreenNoteManagerScript.ShowNoteNotification(notificationText, notificationDuration);
		}
	}

	public void Activate()
	{
	}

	public void Deactivate()
	{
	}

	public string GetName()
	{
		return " ";
	}

	public string GetActionName()
	{
		return actionName;
	}

	public string GetActionType()
	{
		return "Press";
	}

	private IEnumerator MetaFade(float waitTime)
	{
		if (fadeToBlack.GetComponent<Image>().color.a >= 1f)
		{
			yield return new WaitForSeconds(fadeInSpeed);
			SceneManager.LoadScene("LoadingScreen");
		}
		StartCoroutine(Fade(waitTime));
		yield return null;
	}

	private IEnumerator Fade(float waitTime)
	{
		Image component = fadeToBlack.GetComponent<Image>();
		float a = component.color.a;
		component.color = new Color(0f, 0f, 0f, a + 0.01f);
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(MetaFade(waitTime));
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name != "LoadingScreen")
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			StaticStateManager component = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StaticStateManager>();
			if (GameObject.Find(component.getObjectToSpawnAt()) != null)
			{
				gameObject.transform.position = GameObject.Find(component.getObjectToSpawnAt()).transform.position;
				gameObject.transform.rotation = GameObject.Find(component.getObjectToSpawnAt()).transform.rotation;
			}
			else
			{
				Debug.LogWarning("Object to spawn at not found: " + component.getObjectToSpawnAt());
			}
		}
		Debug.Log("OnSceneLoaded: " + scene.name);
		Debug.Log(mode);
	}

	public void PlayInteractSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(eventToPlayAtSceneChange);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public void OnQuestCompleted()
	{
		canUse = true;
	}
}
