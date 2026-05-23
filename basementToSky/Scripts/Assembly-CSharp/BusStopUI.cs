using System;
using System.Collections;
using RainbowArt.CleanFlatUI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BusStopUI : MonoBehaviour
{
	[SerializeField]
	private GameObject busUI;

	[SerializeField]
	private GameObject endOfTheRoadUI;

	[SerializeField]
	private GameObject loadingUI;

	[SerializeField]
	private ProgressBarLoop loadingProgressBar;

	[SerializeField]
	private Transform endOfTheRoadRespawnPos;

	[SerializeField]
	private GameObject retriveBtn;

	public GameObject currentRocket;

	private Image loadingUIImage;

	public float fadeDuration = 0.5f;

	[SerializeField]
	private GameObject airPlaneGO;

	[SerializeField]
	private GameObject crashedRocketBoxGO;

	public bool demoCompleted;

	public static event Action OnFadeInDone;

	public static event Action OnTotheField;

	public static event Action OnToTheHouse;

	public static event Action OnRocketRetrived;

	public static event Action OnFadeOutCompleteDemo;

	private void Awake()
	{
		loadingUIImage = loadingUI.GetComponent<Image>();
		Color color = loadingUIImage.color;
		color.a = 0f;
		loadingUIImage.color = color;
	}

	private void Start()
	{
		ConversationUI.OnPlayerKickedOut += ConversationUI_OnPlayerKickedOut;
		GameManager.S.OnBusStopInteracted += Gm_OnBusStopInteracted;
		QuestManager.S.OnGarageCleaningCompleted += Qm_OnGarageCleaningCompleted;
		GameManager.S.OnPlayerTryGetOut += Gm_OnPlayerTryGetOut;
		Rocket.OnRetriveRocketActive += Rocket_OnRetriveRocketActive1;
		FirstPersonController.S.OnArrivedOpenField += Player_OnArrivedOpenField;
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
		if (busUI != null)
		{
			busUI.SetActive(value: false);
		}
		loadingProgressBar.gameObject.SetActive(value: false);
		if (retriveBtn != null)
		{
			retriveBtn.gameObject.SetActive(value: false);
		}
		StartCoroutine(FadeIn());
	}

	private void ConversationUI_OnPlayerKickedOut()
	{
		StartCoroutine(FadeOutKickedOut());
	}

	public IEnumerator FadeOutSaveAndQuitRoutine()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < 1.5f)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(0f, 1f, time / 1.5f);
			loadingUIImage.color = color;
			yield return null;
		}
	}

	public IEnumerator FadeOutSaveAndQuitRoutineDemoClear()
	{
		FirstPersonController.S.playerInput.Player.Interact.performed -= Interact_performed;
		retriveBtn.SetActive(value: false);
		demoCompleted = true;
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < 3f)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(0f, 1f, time / 3f);
			loadingUIImage.color = color;
			yield return null;
		}
		Rocket currentLanchedRocket = GameManager.S.currentLanchedRocket;
		currentLanchedRocket.calculated = false;
		if (currentLanchedRocket.crashed)
		{
			CrashedRocketBox component = UnityEngine.Object.Instantiate(crashedRocketBoxGO, FirstPersonController.S.transform.position, Quaternion.identity).GetComponent<CrashedRocketBox>();
			component.PutRocketInBox(currentLanchedRocket);
			component.Interact();
		}
		else
		{
			RocketRecover(currentLanchedRocket);
			currentLanchedRocket.Interact();
		}
		BusStopUI.OnRocketRetrived?.Invoke();
		GameManager.S.RocketLanded();
	}

	public void InteractWithCurrentRocket()
	{
		if (currentRocket != null)
		{
			currentRocket.GetComponent<Rocket>().Interact();
		}
	}

	private void PauseUI_OnSaveAndQuit()
	{
		if (currentRocket != null)
		{
			currentRocket.GetComponent<Rocket>().Interact();
		}
	}

	private void Player_OnArrivedOpenField()
	{
		Debug.Log("A");
		if (FirstPersonController.S.itemOnHand != null)
		{
			Debug.Log("B");
			if (FirstPersonController.S.itemOnHand.TryGetComponent<Rocket>(out var component))
			{
				currentRocket = component.gameObject;
			}
		}
	}

	private void Rocket_OnRetriveRocketActive1(GameObject obj)
	{
		if (!demoCompleted)
		{
			FirstPersonController.S.playerInput.Player.Interact.performed += Interact_performed;
			currentRocket = obj;
			retriveBtn.gameObject.SetActive(value: true);
		}
	}

	private void Interact_performed(InputAction.CallbackContext obj)
	{
		if (!FirstPersonController.S.canControl)
		{
			FirstPersonController.S.playerInput.Player.Interact.performed -= Interact_performed;
			RetriveRocket();
		}
	}

	private void Gm_OnPlayerTryGetOut()
	{
		if (!endOfTheRoadUI.activeSelf)
		{
			endOfTheRoadUI.SetActive(value: true);
			endOfTheRoadUI.GetComponent<ModalWindow>().ShowModalWindow();
			Cursor.visible = true;
			GameManager.S.player.canControl = false;
		}
	}

	private void Qm_OnGarageCleaningCompleted()
	{
		StartCoroutine(FadeOutQuest());
	}

	private void OnDisable()
	{
		ConversationUI.OnPlayerKickedOut -= ConversationUI_OnPlayerKickedOut;
		GameManager.S.OnBusStopInteracted -= Gm_OnBusStopInteracted;
		QuestManager.S.OnGarageCleaningCompleted -= Qm_OnGarageCleaningCompleted;
		GameManager.S.OnPlayerTryGetOut -= Gm_OnPlayerTryGetOut;
		Rocket.OnRetriveRocketActive -= Rocket_OnRetriveRocketActive1;
		FirstPersonController.S.OnArrivedOpenField -= Player_OnArrivedOpenField;
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
	}

	private void OnDestroy()
	{
	}

	private void Gm_OnBusStopInteracted()
	{
		if (!busUI.activeSelf)
		{
			busUI.SetActive(value: true);
			busUI.GetComponent<ModalWindow>().ShowModalWindow();
			Cursor.visible = true;
			GameManager.S.player.canControl = false;
		}
	}

	private void Update()
	{
	}

	public void ToTheOpenField()
	{
		Cursor.visible = false;
		if (FirstPersonController.S.itemOnHand != null && FirstPersonController.S.itemOnHand.TryGetComponent<Mower>(out var _))
		{
			FirstPersonController.S.DropItem();
		}
		if (busUI.activeSelf)
		{
			busUI.GetComponent<ModalWindow>().HideModalWindow();
		}
		if (endOfTheRoadUI.activeSelf)
		{
			endOfTheRoadUI.GetComponent<ModalWindow>().HideModalWindow();
		}
		ES3AutoSaveMgr.Current.Save();
		BusStopUI.OnTotheField?.Invoke();
		StartCoroutine(FadeOut(2));
	}

	public void ToTheHouse()
	{
		Cursor.visible = false;
		if (busUI.activeSelf)
		{
			busUI.GetComponent<ModalWindow>().HideModalWindow();
		}
		if (endOfTheRoadUI.activeSelf)
		{
			endOfTheRoadUI.GetComponent<ModalWindow>().HideModalWindow();
		}
		StartCoroutine(FadeOut(1));
		BusStopUI.OnToTheHouse?.Invoke();
	}

	private IEnumerator LoadSceneSmooth(int index)
	{
		if (index == 1)
		{
			FirstPersonController.S.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
		}
		else
		{
			FirstPersonController.S.transform.rotation = Quaternion.identity;
		}
		loadingProgressBar.gameObject.SetActive(value: true);
		float minLoadTime = 1f;
		float timer = 0f;
		AsyncOperation op = SceneManager.LoadSceneAsync(index);
		op.allowSceneActivation = false;
		while (op.progress < 0.9f)
		{
			timer += Time.deltaTime;
			Mathf.Clamp01(op.progress / 0.9f);
			yield return null;
		}
		while (timer < minLoadTime)
		{
			timer += Time.deltaTime;
			yield return null;
		}
		op.allowSceneActivation = true;
	}

	public void OffToTheFieldUI()
	{
		Cursor.visible = false;
		GameManager.S.player.canControl = true;
		busUI.GetComponent<ModalWindow>().HideModalWindow();
	}

	public void OffEndOfTheRoadUI()
	{
		Cursor.visible = false;
		endOfTheRoadUI.GetComponent<ModalWindow>().HideModalWindow();
		StartCoroutine(FadeOutEndOfTheRoad());
	}

	public IEnumerator FadeOut(int index)
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(0f, 1f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
		if (index == 1)
		{
			currentRocket.GetComponent<Rocket>().Interact();
		}
		StartCoroutine(LoadSceneSmooth(index));
	}

	public IEnumerator FadeIn()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(1f, 0f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
		BusStopUI.OnFadeInDone?.Invoke();
	}

	public IEnumerator FadeInRocket()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(1f, 0f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
	}

	public IEnumerator FadeOutQuest()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(0f, 1f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
		StartCoroutine(FadeInQuest());
		QuestManager.S.GarageFadeOutDone();
	}

	public IEnumerator FadeOutKickedOut()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(0f, 1f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
		StartCoroutine(FadeInQuest());
		QuestManager.S.KickedOutFadeOutDone();
	}

	public IEnumerator FadeInQuest()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(1f, 0f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
		FirstPersonController.S.canControl = true;
	}

	public IEnumerator FadeOutEndOfTheRoad()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(0f, 1f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
		CharacterController component = FirstPersonController.S.GetComponent<CharacterController>();
		component.enabled = false;
		FirstPersonController.S.transform.position = endOfTheRoadRespawnPos.position;
		component.enabled = true;
		StartCoroutine(FadeInEndOfTheRoad());
	}

	public IEnumerator FadeInEndOfTheRoad()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(1f, 0f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
		FirstPersonController.S.canControl = true;
	}

	public void RetriveRocket()
	{
		StartCoroutine(FadeOutRocketRetrive());
	}

	public IEnumerator FadeOutRocketRetrive()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(0f, 1f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
		StartCoroutine(FadeInRocket());
		Rocket component = currentRocket.GetComponent<Rocket>();
		component.calculated = false;
		if (component.crashed)
		{
			CrashedRocketBox component2 = UnityEngine.Object.Instantiate(crashedRocketBoxGO, FirstPersonController.S.transform.position, Quaternion.identity).GetComponent<CrashedRocketBox>();
			component2.PutRocketInBox(component);
			component2.Interact();
		}
		else
		{
			RocketRecover(component);
			component.Interact();
		}
		BusStopUI.OnRocketRetrived?.Invoke();
		retriveBtn.SetActive(value: false);
		GameManager.S.RocketLanded();
		GameManager.S.rocketCamera.Priority = 0;
	}

	public void RocketRecover(Rocket rocketTemp)
	{
		if (rocketTemp.crashedPartPaint != null)
		{
			foreach (GameObject item in rocketTemp.crashedPartPaint)
			{
				MeshRenderer component = item.GetComponent<MeshRenderer>();
				if (component != null)
				{
					if (component.material.mainTexture is Texture2D obj)
					{
						UnityEngine.Object.Destroy(obj);
					}
					UnityEngine.Object.Destroy(component.material);
				}
				UnityEngine.Object.Destroy(item);
			}
			rocketTemp.crashedPartPaint.Clear();
		}
		if (rocketTemp.crashedPartsNonPaint != null)
		{
			foreach (GameObject item2 in rocketTemp.crashedPartsNonPaint)
			{
				UnityEngine.Object.Destroy(item2);
			}
			rocketTemp.crashedPartsNonPaint.Clear();
		}
		foreach (GameObject item3 in rocketTemp.rocketWing)
		{
			item3.transform.localScale = Vector3.one;
		}
		rocketTemp.head.gameObject.transform.localScale = Vector3.one;
		rocketTemp.rocketNozzle.gameObject.transform.localScale = Vector3.one;
	}
}
