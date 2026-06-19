using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TutorialBox : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _tutorialText;

	private List<TutorialData> Tutorials;

	private TutorialData _tutorialShown;

	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private float _fadeDuration;

	private Tween _tween;

	public static TutorialBox Instance { get; private set; }

	public void Initiate()
	{
	}

	public void EnableTutorials()
	{
	}

	public void DisableTutorials()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void AddTutorial(TutorialData data)
	{
	}

	public void RemoveTutorial(TutorialData data)
	{
	}

	public void HideTutorial()
	{
	}

	public void OnTutorialHidden()
	{
	}

	public void HandleNextTutorial()
	{
	}

	public void OnTutorialShown()
	{
	}
}
