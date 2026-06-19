using System.Collections.Generic;
using Pug.UnityExtensions;
using QFSW.QC;
using UnityEngine;

public class TutorialRunner : MonoBehaviour
{
	private class TutorialContainer
	{
		public TutorialSequence Tutorial;

		public float FirstPreconditionsMetTime;
	}

	private const float CHECK_INTERVAL_SECONDS = 1f;

	public bool debugSkipDelayBetweenTutorials;

	public PlayerController playerController;

	private List<TutorialContainer> _tutorials = new List<TutorialContainer>();

	private TutorialID _activeTutorial;

	private TimerSimple _timer = new TimerSimple(1f, false, false);

	[Command("CompleteAllTutorials", "Marks all tutorials as completed for the currently active character.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void CompleteAllTutorials()
	{
		for (int i = 0; i < 6; i++)
		{
			Manager.saves.CompleteTutorial((TutorialID)i);
		}
	}

	[Command("SetTutorialDelay", "Enable/disable delay before a tutorial is triggered, for quicker testing.", MonoTargetType.AllInactive, QFSW.QC.Platform.AllPlatforms, 0u)]
	public void SetTutorialDelay(bool useDelay)
	{
		debugSkipDelayBetweenTutorials = !useDelay;
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
		if (Manager.saves.GetCharacterId() < 0)
		{
			return;
		}
		_tutorials.Clear();
		TutorialSequence[] componentsInChildren = GetComponentsInChildren<TutorialSequence>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if ((componentsInChildren[i].validForCreativeCharacters || !Manager.saves.IsCreativeModeCharacter()) && Manager.saves.GetCharacterId() != -1 && !Manager.saves.HasCompletedTutorial(componentsInChildren[i].tutorialID))
			{
				_tutorials.Add(new TutorialContainer
				{
					Tutorial = componentsInChildren[i],
					FirstPreconditionsMetTime = -1f
				});
			}
		}
	}

	public void LateUpdate()
	{
		if (playerController == null || !playerController.isLocal)
		{
			base.enabled = false;
		}
		else if (Manager.saves.GetCharacterId() < 0)
		{
			Debug.LogWarning("Tutorial runner active without a valid active character.");
		}
		else if (!Manager.prefs.enableTutorial)
		{
			if (_activeTutorial != TutorialID.__INVALID)
			{
				Debug.Log($"Aborting tutorial {_activeTutorial} due to tutorials being by user.");
				int tutorialIndex = GetTutorialIndex(_activeTutorial);
				_tutorials[tutorialIndex].Tutorial.AbortTutorialSequence();
				OnTutorialFinished(_activeTutorial, success: false);
			}
		}
		else
		{
			if (_activeTutorial != TutorialID.__INVALID || (_timer.isRunning && !_timer.isTimerElapsed))
			{
				return;
			}
			_timer.Start();
			for (int i = 0; i < _tutorials.Count; i++)
			{
				if (_tutorials[i].Tutorial.HasBeenBypassed())
				{
					OnTutorialFinished(_tutorials[i].Tutorial.tutorialID, success: true);
				}
			}
			if (_tutorials.Count != 0 && TryGetTutorialToRun(out var readyTutorial))
			{
				Debug.Log($"Starting tutorial {readyTutorial.tutorialID}");
				_activeTutorial = readyTutorial.tutorialID;
				readyTutorial.StartTutorialSequence(OnTutorialFinished);
			}
		}
	}

	private void OnTutorialFinished(bool success)
	{
		OnTutorialFinished(_activeTutorial, success);
	}

	private void OnTutorialFinished(TutorialID tutorialID, bool success)
	{
		if (success)
		{
			Debug.Log($"Finished tutorial {tutorialID}");
			Manager.saves.CompleteTutorial(tutorialID);
			int tutorialIndex = GetTutorialIndex(tutorialID);
			_tutorials.RemoveAt(tutorialIndex);
		}
		else
		{
			Debug.Log($"Failed tutorial {tutorialID}");
		}
		_activeTutorial = TutorialID.__INVALID;
	}

	private int GetTutorialIndex(TutorialID tutorialID)
	{
		for (int i = 0; i < _tutorials.Count; i++)
		{
			if (_tutorials[i].Tutorial.tutorialID == tutorialID)
			{
				return i;
			}
		}
		return -1;
	}

	private bool TryGetTutorialToRun(out TutorialSequence readyTutorial)
	{
		readyTutorial = null;
		foreach (TutorialContainer tutorial2 in _tutorials)
		{
			TutorialSequence tutorial = tutorial2.Tutorial;
			if (tutorial.ReadyToRun())
			{
				if (tutorial2.FirstPreconditionsMetTime < 0f)
				{
					tutorial2.FirstPreconditionsMetTime = Time.time;
				}
				if (!(Time.time - tutorial2.FirstPreconditionsMetTime < tutorial.delayAfterConditionsMet) || debugSkipDelayBetweenTutorials)
				{
					readyTutorial = tutorial;
					return true;
				}
			}
		}
		return false;
	}
}
