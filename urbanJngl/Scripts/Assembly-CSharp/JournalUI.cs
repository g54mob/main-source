using System;
using System.Collections.Generic;
using DG.Tweening;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JournalUI : MonoBehaviour
{
	public class OnToggleJournalEventArgs : EventArgs
	{
		public bool isActive;
	}

	[SerializeField]
	private List<Transform> collectionPages;

	[SerializeField]
	private Button nextPageButton;

	[SerializeField]
	private Button previousPageButton;

	[SerializeField]
	private Transform journalTransform;

	[SerializeField]
	private List<Transform> decorLeftList;

	[SerializeField]
	private List<Transform> decorRightList;

	private Transform decorLeftTransform;

	private Transform decorRightTransform;

	[SerializeField]
	private CanvasGroup darkBG_1;

	[SerializeField]
	private CanvasGroup darkBG_2;

	private int pageLimit;

	private List<Transform> totalPages = new List<Transform>();

	private List<JournalPlantUI> journalPlants = new List<JournalPlantUI>();

	private PlayerInputActions playerInputActions;

	private string sceneName;

	private int pageIndex;

	private int plantPageIndex;

	private float tabHeightOffset = 10f;

	private float tabHeightMin;

	private float tabHeightMax;

	private bool firstLeftClickOnPage = true;

	private int oddPlantPages;

	private Vector3 journalPosition;

	private Vector3 decorLeftPosition;

	private Vector3 decorRightPosition;

	private float yOffset = Screen.height;

	private float xOffset = (float)Screen.width / 4f * 3f;

	public static JournalUI Instance { get; private set; }

	public event EventHandler<OnToggleJournalEventArgs> OnToggleJournal;

	public event EventHandler OnShow;

	public event EventHandler OnHide;

	private void Awake()
	{
		Instance = this;
		playerInputActions = new PlayerInputActions();
		playerInputActions.Journal.Enable();
	}

	private void OnEnable()
	{
		playerInputActions.Journal.Enable();
	}

	private void OnDisable()
	{
		playerInputActions.Journal.Disable();
	}

	private void Start()
	{
		InputManager.Instance.OnEscape += InputManager_OnEscape;
		InputManager.Instance.OnJournal += InputManager_OnJournal;
		nextPageButton.onClick.AddListener(delegate
		{
			ChangePage(1);
		});
		previousPageButton.onClick.AddListener(delegate
		{
			ChangePage(-1);
		});
		playerInputActions.Journal.LeftPage.performed += LeftPageAction;
		playerInputActions.Journal.RightPage.performed += RightPageAction;
		playerInputActions.Journal.RightSkin.performed += RightSkinAction;
		playerInputActions.Journal.LeftSkin.performed += LeftSkinAction;
		playerInputActions.Journal.BuySkin.performed += BuySkinAction;
		playerInputActions.Journal.Quit.performed += QuitAction;
		foreach (Transform collectionPage in collectionPages)
		{
			totalPages.Add(collectionPage);
			JournalPlantUI[] componentsInChildren = collectionPage.GetComponentsInChildren<JournalPlantUI>();
			foreach (JournalPlantUI item in componentsInChildren)
			{
				journalPlants.Add(item);
			}
		}
		pageLimit = totalPages.Count;
		pageIndex = 0;
		foreach (Transform collectionPage2 in collectionPages)
		{
			HideJournalElement(collectionPage2);
		}
		ShowJournalElement(collectionPages[pageIndex]);
		if (pageIndex <= 1)
		{
			HideJournalElement(previousPageButton.transform);
		}
		if (pageIndex == pageLimit)
		{
			HideJournalElement(nextPageButton.transform);
		}
		CollectionManager instance = CollectionManager.Instance;
		instance.OnLoadCollection = (Action)Delegate.Combine(instance.OnLoadCollection, new Action(LoadCollection));
		PlantCreatingSystem.Instance.OnPlantCreated += PlantCreatingSystem_OnPlantCreated;
		int num2 = collectionPages.Count * 2;
		oddPlantPages = ((num2 >= journalPlants.Count || journalPlants[num2] == null) ? 1 : 0);
		sceneName = SceneManager.GetActiveScene().name;
		int decorIndexByLevel = GetDecorIndexByLevel(sceneName);
		decorLeftTransform = decorLeftList[decorIndexByLevel];
		decorRightTransform = decorRightList[decorIndexByLevel];
		decorLeftTransform.gameObject.SetActive(value: true);
		decorRightTransform.gameObject.SetActive(value: true);
		decorLeftPosition = decorLeftTransform.position;
		decorRightPosition = decorRightTransform.position;
		journalPosition = journalTransform.position;
		HideJournal();
	}

	private int GetDecorIndexByLevel(string levelName)
	{
		return levelName switch
		{
			"Level_0_New" => 0, 
			"Level_1_New" => 1, 
			"Level_2_New" => 2, 
			"Level_3_New" => 3, 
			"Level_4_New" => 4, 
			"Level_5_New" => 5, 
			"Level_6_New" => 6, 
			"Level_7_New" => 7, 
			"Level_8_New" => 8, 
			"Level_9_New" => 9, 
			"Level_10_New" => 10, 
			"Level_0_CreativeMode" => 0, 
			"Level_1_CreativeMode" => 1, 
			"Level_2_CreativeMode" => 2, 
			"Level_3_CreativeMode" => 3, 
			"Level_4_CreativeMode" => 4, 
			"Level_5_CreativeMode" => 5, 
			"Level_6_CreativeMode" => 6, 
			"Level_7_CreativeMode" => 7, 
			"Level_8_CreativeMode" => 8, 
			"Level_9_CreativeMode" => 9, 
			"Level_10_CreativeMode" => 10, 
			_ => 0, 
		};
	}

	private void BuySkinAction(InputAction.CallbackContext obj)
	{
		if (!base.isActiveAndEnabled)
		{
			journalPlants[plantPageIndex].buyButton.OnPointerDown(new PointerEventData(EventSystem.current));
			journalPlants[plantPageIndex].buyButton.OnPointerUp(new PointerEventData(EventSystem.current));
			journalPlants[plantPageIndex].buyButton.onClick.Invoke();
		}
	}

	private void LeftSkinAction(InputAction.CallbackContext obj)
	{
		if (base.isActiveAndEnabled)
		{
			return;
		}
		if (firstLeftClickOnPage)
		{
			firstLeftClickOnPage = false;
			if (plantPageIndex + 1 < collectionPages.Count * 2 - oddPlantPages)
			{
				journalPlants[++plantPageIndex].ChooseSkin(-100);
			}
			return;
		}
		firstLeftClickOnPage = false;
		if (!journalPlants[plantPageIndex].ChooseSkin(-1) && plantPageIndex % 2 != 0)
		{
			journalPlants[plantPageIndex].DeactivateChoose();
			journalPlants[--plantPageIndex].ChooseSkin(-100);
		}
	}

	private void RightSkinAction(InputAction.CallbackContext obj)
	{
		firstLeftClickOnPage = false;
		if (!base.isActiveAndEnabled && !journalPlants[plantPageIndex].ChooseSkin(1) && plantPageIndex % 2 == 0 && plantPageIndex + 1 < collectionPages.Count * 2 - oddPlantPages)
		{
			journalPlants[plantPageIndex].DeactivateChoose();
			journalPlants[++plantPageIndex].ChooseSkin(0);
		}
	}

	private void RightPageAction(InputAction.CallbackContext obj)
	{
		if (base.isActiveAndEnabled)
		{
			ChangePage(1);
		}
	}

	private void LeftPageAction(InputAction.CallbackContext obj)
	{
		if (base.isActiveAndEnabled)
		{
			ChangePage(-1);
		}
	}

	private void InputManager_OnJournal(object sender, EventArgs e)
	{
		if (!base.isActiveAndEnabled)
		{
			Show();
		}
	}

	private void QuitAction(InputAction.CallbackContext obj)
	{
		HideJournal();
	}

	private void InputManager_OnEscape(object sender, EventArgs e)
	{
		HideJournal();
	}

	private void PlantCreatingSystem_OnPlantCreated(object sender, PlantCreatingSystem.OnPlantCreatedEventArgs e)
	{
		UpdateJournal();
	}

	private void LoadCollection()
	{
		UpdateJournal();
	}

	private void OnDestroy()
	{
		InputManager.Instance.OnEscape -= InputManager_OnEscape;
		InputManager.Instance.OnJournal -= InputManager_OnJournal;
		nextPageButton.onClick.RemoveAllListeners();
		previousPageButton.onClick.RemoveAllListeners();
		CollectionManager instance = CollectionManager.Instance;
		instance.OnLoadCollection = (Action)Delegate.Remove(instance.OnLoadCollection, new Action(LoadCollection));
		PlantCreatingSystem.Instance.OnPlantCreated -= PlantCreatingSystem_OnPlantCreated;
		playerInputActions.Journal.LeftPage.performed -= LeftPageAction;
		playerInputActions.Journal.RightPage.performed -= RightPageAction;
		playerInputActions.Journal.RightSkin.performed -= RightSkinAction;
		playerInputActions.Journal.LeftSkin.performed -= LeftSkinAction;
		playerInputActions.Journal.BuySkin.performed -= BuySkinAction;
		playerInputActions.Journal.Disable();
	}

	public void HideJournal()
	{
		this.OnHide?.Invoke(this, EventArgs.Empty);
		HideAnimation();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void HideJournalElement(Transform transform)
	{
		transform.gameObject.SetActive(value: false);
	}

	public void Show()
	{
		this.OnShow?.Invoke(this, EventArgs.Empty);
		base.gameObject.SetActive(value: true);
		ShowAnimation();
		UpdateJournal();
	}

	public void ShowJournalElement(Transform transform)
	{
		transform.gameObject.SetActive(value: true);
	}

	private void UpdateJournal()
	{
		foreach (JournalPlantUI journalPlant in journalPlants)
		{
			journalPlant.UpdateSkins();
		}
	}

	private void ChangePage(int increment)
	{
		SoundManager.Instance.OnDiaryPageFlip();
		int num = pageIndex + increment;
		if (num >= 0 && num <= pageLimit - 1)
		{
			GoToPage(num);
		}
	}

	private void GoToPage(int newPageIndex)
	{
		HideJournalElement(totalPages[pageIndex]);
		ShowJournalElement(totalPages[newPageIndex]);
		pageIndex = newPageIndex;
		firstLeftClickOnPage = true;
		if (pageIndex == 0)
		{
			HideJournalElement(previousPageButton.transform);
		}
		else
		{
			ShowJournalElement(previousPageButton.transform);
		}
		if (pageIndex == pageLimit - 1)
		{
			HideJournalElement(nextPageButton.transform);
		}
		else
		{
			ShowJournalElement(nextPageButton.transform);
		}
	}

	public string GetTip(ObjectSO objectSO)
	{
		return journalPlants.Find((JournalPlantUI plant) => plant.GetObjectSO() == objectSO).GetTip();
	}

	public string GetPlantName(ObjectSO objectSO)
	{
		return journalPlants.Find((JournalPlantUI plant) => plant.GetObjectSO() == objectSO).GetPlantName();
	}

	public List<JournalPlantSkinUI> GetSkins(ObjectSO objectSO)
	{
		return journalPlants.Find((JournalPlantUI plant) => plant.GetObjectSO() == objectSO).GetSkins();
	}

	public List<string> GetCollectedSkins(ObjectSO objectSO)
	{
		return journalPlants.Find((JournalPlantUI plant) => plant.GetObjectSO() == objectSO).GetCollectedSkins();
	}

	private void ShowAnimation()
	{
		Sequence s = DOTween.Sequence();
		journalTransform.position = journalPosition;
		journalTransform.position = new Vector3(journalTransform.position.x, journalTransform.position.y - yOffset, journalTransform.position.z);
		s.Append(journalTransform.DOMoveY(journalPosition.y + 10f, 0.2f).SetEase(Ease.OutSine)).Append(journalTransform.DOMoveY(journalPosition.y, 0.1f).SetEase(Ease.InOutSine)).Play();
		decorLeftTransform.position = decorLeftPosition;
		decorLeftTransform.position = new Vector3(decorLeftTransform.position.x - xOffset, decorLeftTransform.position.y, decorLeftTransform.position.z);
		decorLeftTransform.DOMoveX(decorLeftPosition.x, 0.2f).SetEase(Ease.OutSine);
		decorRightTransform.position = decorRightPosition;
		decorRightTransform.position = new Vector3(decorRightTransform.position.x + xOffset, decorRightTransform.position.y, decorRightTransform.position.z);
		decorRightTransform.DOMoveX(decorRightPosition.x, 0.2f).SetEase(Ease.OutSine);
		darkBG_1.alpha = 0f;
		darkBG_1.DOFade(1f, 0.3f);
		darkBG_2.alpha = 0f;
		darkBG_2.DOFade(1f, 0.3f);
	}

	private void HideAnimation()
	{
		DOTween.Sequence().Append(journalTransform.DOMoveY(journalTransform.position.y + 10f, 0.1f).SetEase(Ease.InOutSine)).Append(journalTransform.DOMoveY(journalTransform.position.y - yOffset, 0.2f).SetEase(Ease.InSine))
			.AppendCallback(delegate
			{
				Hide();
			})
			.Play();
		decorLeftTransform.DOMoveX(decorLeftPosition.x - xOffset, 0.2f).SetEase(Ease.InSine);
		decorRightTransform.DOMoveX(decorRightPosition.x + xOffset, 0.2f).SetEase(Ease.InSine);
		darkBG_1.DOFade(0f, 0.3f);
		darkBG_2.DOFade(0f, 0.3f);
	}
}
