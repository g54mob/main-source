using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
	public GameObject sceneStartGraphic;

	public GameObject sceneEndObject;

	public Transform canvasHolder;

	public TextMeshProUGUI loadingText;

	public GameObject portraitGenerationText;

	private ulong? loadingTextScaleKey;

	private float graphicExpandTime = 0.75f;

	private float graphicShrinkTime = 1f;

	private Vector3 scaleMax = new Vector3(10f, 10f, 1f);

	private Vector3 scaleMin = new Vector3(0.001f, 0.001f, 1f);

	private GameObject endObjRef;

	private GameObject instantiatedTransitionGraphic;

	private string sceneToLoad;

	private bool allDogsLoaded;

	private bool isTransitioning;

	private bool preloadCompleted;

	private Inchworm inchwormRef;

	private SceneManagerBase sceneManager;

	private void Awake()
	{
		allDogsLoaded = false;
		preloadCompleted = false;
		SFXOverlord.LockInWorldSFX(LockReason.SCENE_TRANSITION);
		loadingText.gameObject.SetActive(value: false);
		portraitGenerationText.SetActive(value: false);
	}

	private void Start()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		inchwormRef = registrationScript.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		sceneManager = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		PenFocus component = Camera.main.GetComponent<PenFocus>();
		if (component != null)
		{
			component.SetInputAllowed(val: false, LockReason.SCENE_TRANSITION);
		}
		StartSceneTransition();
	}

	public void TransitionToScene(string sceneName)
	{
		isTransitioning = true;
		sceneToLoad = sceneName;
		endObjRef = Object.Instantiate(sceneEndObject, canvasHolder);
		endObjRef.transform.localScale = scaleMin;
		inchwormRef.RequestEaseToScale(endObjRef, scaleMax, graphicExpandTime, Inchworm.EaseStyle.Sin, TransitionCallback);
	}

	public bool IsTransitioning()
	{
		return isTransitioning;
	}

	public void OnAllDogsLoaded(bool loadingFromMainMenu = false)
	{
		allDogsLoaded = true;
		LiftLoadingScreenIfPossible(loadingFromMainMenu);
	}

	private void TransitionCallback()
	{
		SceneManager.LoadSceneAsync(sceneToLoad);
	}

	private void StartSceneTransition()
	{
		instantiatedTransitionGraphic = Object.Instantiate(sceneStartGraphic, canvasHolder);
		instantiatedTransitionGraphic.transform.localScale = scaleMax;
		if (loadingTextScaleKey.HasValue)
		{
			TextScaleInEffect.RequestEffectEnd(loadingTextScaleKey.Value, loadingText);
			loadingTextScaleKey = null;
		}
		loadingText.gameObject.SetActive(value: true);
		loadingTextScaleKey = TextScaleInEffect.ScaleInText(loadingText, null, OnTextLoaded, 0.5f, 0.03f, null, scaleOut: false, 0.1f);
		if (!ObjectRegistration.GetRegistrationScript().saveLoadManager.HasGeneratedPortraits())
		{
			portraitGenerationText.SetActive(value: true);
		}
		else
		{
			portraitGenerationText.SetActive(value: false);
		}
		sceneManager.GetComponent<SceneManagerBase>().PreloadScene(PreloadComplete);
	}

	private void OnTextLoaded(ulong key)
	{
		loadingTextScaleKey = null;
	}

	private void PreloadComplete()
	{
		preloadCompleted = true;
		LiftLoadingScreenIfPossible();
	}

	private void LiftLoadingScreenIfPossible(bool loadingFromMainMenu = false)
	{
		if (preloadCompleted && allDogsLoaded)
		{
			bool flag = false;
			if (loadingFromMainMenu && !ObjectRegistration.GetRegistrationScript().GetGlobalComponent<EventController>(GlobalObject.EVENT_CONTROLLER).HasShownWarning())
			{
				flag = true;
			}
			if (loadingTextScaleKey.HasValue)
			{
				TextScaleInEffect.RequestEffectEnd(loadingTextScaleKey.Value, loadingText);
				loadingTextScaleKey = null;
			}
			loadingText.gameObject.SetActive(value: false);
			portraitGenerationText.SetActive(value: false);
			PenFocus component = Camera.main.GetComponent<PenFocus>();
			if (component != null)
			{
				component.RefreshRoomFocus();
				component.SetInputAllowed(val: true, LockReason.SCENE_TRANSITION);
			}
			SFXOverlord.UnlockInWorldSFX(LockReason.SCENE_TRANSITION);
			if (flag)
			{
				SceneTransitionEndCallback();
			}
			else
			{
				inchwormRef.RequestEaseToScale(instantiatedTransitionGraphic, scaleMin, graphicShrinkTime, Inchworm.EaseStyle.QuadraticOut, SceneTransitionEndCallback, Inchworm.EasePriority.Normal, 0.5f);
			}
		}
	}

	private void SceneTransitionEndCallback()
	{
		Object.Destroy(instantiatedTransitionGraphic);
		base.transform.localScale = Vector3.one;
		sceneManager.GetComponent<SceneManagerBase>().StartScene();
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerBase>(GlobalObject.GUI).OnSceneTransitionFinished();
	}
}
