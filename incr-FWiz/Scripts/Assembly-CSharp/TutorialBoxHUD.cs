using OUSystems.Basics.UI;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBoxHUD : MonoBehaviour
{
	public ClickListener ToggleButton;

	public Image ToggleButtonImage;

	public Sprite ToggleOpenButtonSprite;

	public Sprite ToggleClosedButtonSprite;

	public ButtonGuideHoverTrigger ButtonGuideTrigger;

	public Transform ContentTransform;

	public Transform TutorialView;

	public TutorialBoxItem CurrentTutorialPrefab;

	public TutorialBoxItem CurrentTutorialInstance;

	public static TutorialBoxHUD Instance { get; private set; }

	public void Initiate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void SetTutorial(TutorialBoxItem tutorialPrefab)
	{
	}

	public void RemoveTutorial(TutorialBoxItem tutorialPrefab)
	{
	}

	public void ToggleShowTutorial()
	{
	}

	public void EvaluateViews()
	{
	}
}
