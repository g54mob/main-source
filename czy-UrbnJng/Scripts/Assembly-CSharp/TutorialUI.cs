using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using Tasks_for_levels;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialUI : MonoBehaviour
{
	[SerializeField]
	private List<Transform> tutorialList;

	[SerializeField]
	private NewPlantButtonUI newPlantButtonUI;

	[SerializeField]
	private ChooseNextPlantWindowUI chooseNextPlantWindowUI;

	[SerializeField]
	private JournalButtonUI journalButtonUI;

	[SerializeField]
	private NewScoreUI newScoreUI;

	[SerializeField]
	private ShowPlantInfoUI showPlantInfoUI;

	[SerializeField]
	private Task_Level_1 tasksLevelOne;

	[SerializeField]
	private Task_Level_2 tasksLevelTwo;

	[SerializeField]
	private SwitchFloorButton switchFloorButton;

	[SerializeField]
	private bool IsTutorial = true;

	[SerializeField]
	private GameObject background;

	private RectTransform tutorialPopup;

	private Vector2 offset = new Vector2(280f, -140f);

	[SerializeField]
	private Canvas canvas;

	private float scaleFactor;

	private int saveStep;

	private bool skipStep;

	private int tutorialStep;

	private int currentShowTutorialStep = -1;

	private Dictionary<int, bool> tutorialDictionary = new Dictionary<int, bool>();

	private PlayerProgress progress;

	private bool cameraMoveUpInput;

	private bool cameraMoveDownInput;

	private bool cameraMoveLeftInput;

	private bool cameraMoveRightInput;

	private bool cameraRotateLeftInput;

	private bool cameraRotateRightInput;

	private bool cameraZoomIn;

	private bool cameraZoomOut;

	private int plantCardClickCount;

	private int switchFloorClickCount;

	private bool dialogEnds;

	private void Awake()
	{
		for (int i = 0; i < tutorialList.Count; i++)
		{
			tutorialDictionary.Add(i, value: false);
		}
		progress = AllServices.Container.Single<IPersistentProgressService>().Progress;
	}

	private void Start()
	{
		DialogueManager instance = DialogueManager.Instance;
		instance.StartTutorial = (Action)Delegate.Combine(instance.StartTutorial, new Action(Show));
		PlantCreatingSystem.Instance.OnFirstObjectCreated += PlantCreatingSystem_OnFirstObjectCreated;
		newPlantButtonUI.OnFirstClick += NewPlantButtonUI_OnFirstClick;
		chooseNextPlantWindowUI.OnPlantCardClick += ChooseNextPlantWindowUI_OnPlantCardClick;
		chooseNextPlantWindowUI.OnFirstPlantChosen += ChooseNextPlantWindowUI_OnFirstPlantChosen;
		MovementSystem.Instance.OnFirstPlantPlaced += MovementSystem_OnFirstPlantPlaced;
		MovementSystem.Instance.OnFirstPlantMoved += MovementSystem_OnFirstPlantMoved;
		MovementSystem.Instance.OnFirstPlantCanceled += MovementSystem_OnFirstPlantCanceled;
		MovementSystem.Instance.OnFirstObjectRotate += MovementSystem_OnFirstObjectRotated;
		newScoreUI.OnTutorialScoreReached += NewScoreUI_OnTutorialScoreReached;
		showPlantInfoUI.OnFirstShowUIButtonClick += showPlantInfoUI_OnFirstShowUIButtonClick;
		if (switchFloorButton != null)
		{
			switchFloorButton.SwitchFloorAction += SwitchFloorButton_OnSwitchFloorAction;
		}
		IsTutorial = progress.IsTutorial;
		tutorialStep = progress.TutorialStep;
		InputManager.Instance.OnCameraMove += InputManager_OnCameraMove;
		InputManager.Instance.OnCameraRotation += InputManager_OnCameraRotation;
		InputManager.Instance.OnMouseScroll += InputManager_OnMouseScroll;
		if (tasksLevelOne != null)
		{
			tasksLevelOne.TaskFinished += TaskFinished;
		}
		if (tasksLevelTwo != null)
		{
			tasksLevelTwo.TaskFinished += TaskFinished;
		}
		NextLevelButtonUI.Instance.OnNextLevelButtonActivation += NextLevelButtonUI_OnButtonActivation;
		NextLevelButtonUI.Instance.OnButtonClickForTutorial += NextLevelButtonUI_OnButtonClick;
		tutorialPopup = GetComponent<RectTransform>();
		if (tutorialStep < tutorialDictionary.Count)
		{
			IsTutorial = true;
		}
		background.SetActive(value: false);
		if (progress.DialogsStart["Level_0_New0"])
		{
			Hide();
		}
	}

	private void OnDestroy()
	{
		DialogueManager instance = DialogueManager.Instance;
		instance.StartTutorial = (Action)Delegate.Remove(instance.StartTutorial, new Action(Show));
		newPlantButtonUI.OnFirstClick -= NewPlantButtonUI_OnFirstClick;
		chooseNextPlantWindowUI.OnFirstPlantChosen -= ChooseNextPlantWindowUI_OnFirstPlantChosen;
		chooseNextPlantWindowUI.OnPlantCardClick -= ChooseNextPlantWindowUI_OnPlantCardClick;
		PlantCreatingSystem.Instance.OnFirstObjectCreated -= PlantCreatingSystem_OnFirstObjectCreated;
		MovementSystem.Instance.OnFirstPlantPlaced -= MovementSystem_OnFirstPlantPlaced;
		MovementSystem.Instance.OnFirstPlantMoved -= MovementSystem_OnFirstPlantMoved;
		MovementSystem.Instance.OnFirstPlantCanceled -= MovementSystem_OnFirstPlantCanceled;
		MovementSystem.Instance.OnFirstObjectRotate -= MovementSystem_OnFirstObjectRotated;
		newScoreUI.OnTutorialScoreReached -= NewScoreUI_OnTutorialScoreReached;
		showPlantInfoUI.OnFirstShowUIButtonClick -= showPlantInfoUI_OnFirstShowUIButtonClick;
		if (switchFloorButton != null)
		{
			switchFloorButton.SwitchFloorAction -= SwitchFloorButton_OnSwitchFloorAction;
		}
		InputManager.Instance.OnCameraMove -= InputManager_OnCameraMove;
		InputManager.Instance.OnCameraRotation -= InputManager_OnCameraRotation;
		InputManager.Instance.OnMouseScroll -= InputManager_OnMouseScroll;
		if (tasksLevelOne != null)
		{
			tasksLevelOne.TaskFinished -= TaskFinished;
		}
		if (tasksLevelTwo != null)
		{
			tasksLevelTwo.TaskFinished -= TaskFinished;
		}
		NextLevelButtonUI.Instance.OnNextLevelButtonActivation -= NextLevelButtonUI_OnButtonActivation;
		NextLevelButtonUI.Instance.OnButtonClickForTutorial -= NextLevelButtonUI_OnButtonClick;
	}

	private void JournalButtonUI_OnFirstJournalButtonClick(object sender, EventArgs e)
	{
		tutorialDictionary[100] = true;
	}

	private void PlantCreatingSystem_OnFirstObjectCreated(object sender, EventArgs e)
	{
		tutorialDictionary[0] = true;
	}

	private void MovementSystem_OnFirstObjectRotated(object sender, EventArgs e)
	{
		tutorialDictionary[1] = true;
	}

	private void MovementSystem_OnFirstPlantPlaced(object sender, EventArgs e)
	{
		if (tutorialStep == 2)
		{
			tutorialDictionary[2] = true;
		}
	}

	private void NewScoreUI_OnTutorialScoreReached(object sender, EventArgs e)
	{
		if (tutorialStep == 3)
		{
			tutorialDictionary[3] = true;
		}
		if (tutorialStep == 14)
		{
			tutorialDictionary[14] = true;
		}
	}

	private void NewPlantButtonUI_OnFirstClick(object sender, EventArgs e)
	{
		tutorialDictionary[4] = true;
		if (tutorialStep < 4)
		{
			saveStep = tutorialStep;
			tutorialStep = 4;
		}
	}

	private void ChooseNextPlantWindowUI_OnPlantCardClick(object sender, EventArgs e)
	{
		plantCardClickCount++;
		skipStep = true;
		if (plantCardClickCount == 1)
		{
			tutorialDictionary[5] = true;
		}
		else if (plantCardClickCount == 2)
		{
			tutorialDictionary[6] = true;
		}
	}

	private void ChooseNextPlantWindowUI_OnFirstPlantChosen(object sender, EventArgs e)
	{
		tutorialDictionary[7] = true;
	}

	private void MovementSystem_OnFirstPlantMoved(object sender, EventArgs e)
	{
		tutorialDictionary[8] = true;
	}

	private void MovementSystem_OnFirstPlantCanceled(object sender, EventArgs e)
	{
		tutorialDictionary[9] = true;
	}

	private void InputManager_OnCameraMove(object sender, InputManager.OnCameraMoveEventArgs e)
	{
		if (tutorialStep == 10)
		{
			if (e.inputVector.y > 0f)
			{
				cameraMoveUpInput = true;
			}
			if (e.inputVector.y < 0f)
			{
				cameraMoveDownInput = true;
			}
			if (e.inputVector.x < 0f)
			{
				cameraMoveLeftInput = true;
			}
			if (e.inputVector.x > 0f)
			{
				cameraMoveRightInput = true;
			}
		}
	}

	private void InputManager_OnCameraRotation(object sender, InputManager.OnCameraRotationEventArgs e)
	{
		if (tutorialStep == 11)
		{
			if (e.rotationVector.x > 0f)
			{
				cameraRotateRightInput = true;
			}
			if (e.rotationVector.x < 0f)
			{
				cameraRotateLeftInput = true;
			}
		}
	}

	private void InputManager_OnMouseScroll(object sender, InputManager.OnMouseScrollEventArgs e)
	{
		if (tutorialStep == 12)
		{
			if (e.mouseScrollDeltaY > 0f)
			{
				cameraZoomIn = true;
			}
			if (e.mouseScrollDeltaY < 0f)
			{
				cameraZoomOut = true;
			}
		}
	}

	private void showPlantInfoUI_OnFirstShowUIButtonClick(object sender, EventArgs e)
	{
		tutorialDictionary[13] = true;
	}

	private void NextLevelButtonUI_OnButtonActivation(object sender, EventArgs e)
	{
		if (tutorialStep == 16)
		{
			tutorialDictionary[16] = true;
			Show();
		}
	}

	private void NextLevelButtonUI_OnButtonClick(object sender, EventArgs e)
	{
		tutorialDictionary[17] = true;
	}

	private void TaskFinished()
	{
		if (tutorialStep == 18)
		{
			tutorialDictionary[18] = true;
		}
	}

	private void SwitchFloorButton_OnSwitchFloorAction()
	{
		switchFloorClickCount++;
		if (tutorialStep == 20 && switchFloorClickCount == 2)
		{
			tutorialDictionary[20] = true;
		}
	}

	private void MovementSystem_OnFirstObjectMoved(object sender, EventArgs e)
	{
		tutorialDictionary[100] = true;
	}

	private void Update()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		scaleFactor = canvas.scaleFactor;
		Vector2 vector2 = offset * scaleFactor;
		Vector2 vector3 = vector + vector2;
		tutorialPopup.position = vector3;
		if (!InputManager.Instance.gamePause)
		{
			dialogEnds = true;
		}
		if (dialogEnds && IsTutorial)
		{
			Show();
			background.SetActive(value: true);
			ShowTutorial(tutorialStep);
		}
		if (!IsTutorial)
		{
			return;
		}
		if (tutorialStep == 0 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 1 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 2 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 3)
		{
			newScoreUI.StartTutorial();
			if (tutorialDictionary[tutorialStep])
			{
				tutorialStep++;
				progress.TutorialStep = tutorialStep;
				ShowTutorial(tutorialStep);
			}
		}
		else if (tutorialStep == 4 && tutorialDictionary[tutorialStep])
		{
			if (skipStep)
			{
				tutorialStep = 8;
				return;
			}
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 5 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 6 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 7)
		{
			if (tutorialDictionary[tutorialStep])
			{
				if (saveStep != 0)
				{
					tutorialStep = saveStep;
					return;
				}
				tutorialStep++;
				progress.TutorialStep = tutorialStep;
				ShowTutorial(tutorialStep);
			}
		}
		else if (tutorialStep == 8 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 9 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 10)
		{
			if (cameraMoveUpInput && cameraMoveDownInput && cameraMoveLeftInput && cameraMoveRightInput)
			{
				tutorialStep++;
				progress.TutorialStep = tutorialStep;
				ShowTutorial(tutorialStep);
			}
		}
		else if (tutorialStep == 11)
		{
			if (cameraRotateLeftInput && cameraRotateRightInput)
			{
				tutorialStep++;
				progress.TutorialStep = tutorialStep;
				ShowTutorial(tutorialStep);
			}
		}
		else if (tutorialStep == 12)
		{
			if (cameraZoomIn && cameraZoomOut)
			{
				tutorialStep++;
				progress.TutorialStep = tutorialStep;
				ShowTutorial(tutorialStep);
			}
		}
		else if (tutorialStep == 13 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 14 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 15)
		{
			progress.TutorialStep = tutorialStep;
			tutorialStep++;
			Hide();
		}
		else if (tutorialStep == 16 && tutorialDictionary[tutorialStep])
		{
			progress.TutorialStep = tutorialStep;
			tutorialStep++;
		}
		else if (tutorialStep == 17 && tutorialDictionary[tutorialStep])
		{
			progress.TutorialStep = tutorialStep;
			HideElement(tutorialList[tutorialStep]);
			Hide();
		}
		else if (tutorialStep == 18 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 19)
		{
			progress.TutorialStep = tutorialStep;
			Hide();
		}
		else if (tutorialStep == 20 && tutorialDictionary[tutorialStep])
		{
			tutorialStep++;
			progress.TutorialStep = tutorialStep;
			ShowTutorial(tutorialStep);
		}
		else if (tutorialStep == 21)
		{
			IsTutorial = false;
			progress.IsTutorial = false;
			progress.TutorialStep = tutorialStep;
			Hide();
		}
	}

	private void ShowTutorial(int index)
	{
		if (currentShowTutorialStep == index)
		{
			return;
		}
		currentShowTutorialStep = index;
		foreach (Transform tutorial in tutorialList)
		{
			HideElement(tutorial);
		}
		ShowElement(tutorialList[index]);
	}

	private void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	private void HideElement(Transform transform)
	{
		transform.gameObject.SetActive(value: false);
	}

	private void ShowElement(Transform transform)
	{
		transform.gameObject.SetActive(value: true);
	}
}
