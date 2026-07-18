using DG.Tweening;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
	public static TutorialController Instance;

	private bool playingTutorial;

	[SerializeField]
	private GameObject tutorialCanvas;

	[SerializeField]
	private GameObject fullgameTutorial;

	[SerializeField]
	private GameObject demoTutorial;

	[SerializeField]
	private GameObject[] tutorialSteps;

	[SerializeField]
	private int currentStep = -1;

	private void Awake()
	{
		Instance = this;
		if (PlayerPrefs.HasKey("tutorial"))
		{
			CloseTutorial();
		}
		else
		{
			ShowTutorial();
		}
	}

	public bool PlayingTutorial()
	{
		return playingTutorial;
	}

	public bool TutorialActive()
	{
		return tutorialCanvas.activeInHierarchy;
	}

	public void CloseTutorial()
	{
		playingTutorial = false;
		currentStep = 99;
		tutorialCanvas.SetActive(value: false);
		PlayerPrefs.SetString("tutorial", "done");
	}

	public void TemporarilyCloseTutorial()
	{
		tutorialCanvas.SetActive(value: false);
	}

	public void ReopenTutorial()
	{
		if (currentStep < tutorialSteps.Length)
		{
			tutorialCanvas.SetActive(value: true);
		}
	}

	private void ShowTutorial()
	{
		playingTutorial = true;
		tutorialCanvas.SetActive(value: true);
		ShowNextTutorialStep();
		if (DemoController.Instance.IsDemo())
		{
			demoTutorial.SetActive(value: true);
		}
		else
		{
			fullgameTutorial.SetActive(value: true);
		}
	}

	public void ShowNextTutorialStep()
	{
		if (!TutorialActive())
		{
			return;
		}
		try
		{
			SettingsManager.Instance.ShowButtonPreviewText("");
		}
		catch
		{
		}
		currentStep++;
		GameObject[] array = tutorialSteps;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		if (currentStep == tutorialSteps.Length)
		{
			CloseTutorial();
			return;
		}
		tutorialSteps[currentStep].SetActive(value: true);
		foreach (Transform item in tutorialSteps[currentStep].transform)
		{
			item.transform.localScale = Vector3.zero;
			item.DOScale(Vector3.one, 0.25f).SetEase(Ease.InOutBounce);
		}
	}

	public int GetCurrentTutorialStep()
	{
		return currentStep;
	}
}
