using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	[Header("Global Control")]
	[SerializeField]
	private GameObject dialogueUI;

	[SerializeField]
	private CanvasGroup WorldCanvasGroup;

	[SerializeField]
	private CanvasGroup UICanvasGroup;

	[SerializeField]
	private AudioSource clickAudioSource;

	[SerializeField]
	private AudioSource dialogueAudioSource;

	[Header("Text")]
	[SerializeField]
	private LocalizedString pressSpaceToContinueLocalizedText;

	[SerializeField]
	private LocalizedString pressAToContinueLocalizedText;

	[Header("Player Dialogue")]
	[SerializeField]
	private GameObject playerDialogueGO;

	[SerializeField]
	private Image playerDialogueCharacterImage;

	[SerializeField]
	private TextMeshProUGUI playerNameText;

	[SerializeField]
	private TextMeshProUGUI playerDialogueText;

	[SerializeField]
	private TextMeshProUGUI spaceContinuePlayerText;

	[SerializeField]
	private GameObject playergamepadContinue;

	[SerializeField]
	private GameObject playerkeyboardContinue;

	[Header("Correspondent Dialogue")]
	[SerializeField]
	private GameObject correspondentDialogueGO;

	[SerializeField]
	private Image correspondentDialogueCharacterImage;

	[SerializeField]
	private TextMeshProUGUI correspondentNameText;

	[SerializeField]
	private TextMeshProUGUI correspondentDialogueText;

	[SerializeField]
	private TextMeshProUGUI spaceContinueCorrespondentText;

	[SerializeField]
	private GameObject gamepadContinue;

	[SerializeField]
	private GameObject keyboardContinue;

	public WorldDialogueGroupsSO IterativeDialogueGroupsForWorlds;

	private bool isDialogueInProgress;

	private bool dialogueProgressInputTriggered;

	private bool dialogueProgressEventTriggered;

	private List<GameObject> additionalTempObjects;

	private List<GameObject> additionalTempUIElements;

	private int currentWorldIndex;

	private int currentWorldIterationIndex;

	private int currentLevelIndex;

	private WorldDialogueGroupsSO currentWorldDialogueGroup;

	private WorldDialogueIterationsSO currentWorldDialogueIterations;

	private WorldDialogueSO currentWorldDialogue;

	private LevelDialogueSO currentDialogue;

	private bool IsGamepad;

	[SerializeField]
	private AudioClip[] talkSounds;

	public static DialogueManager Instance { get; private set; }

	public event Action onCompleteDialogue;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	private void Start()
	{
		LevelManager.Instance.LevelCompleted += LevelManager_LevelCompleted;
	}

	public static void OnDialogueProgressTriggered()
	{
		Instance.TriggerDialogueProgressEvent();
	}

	private void Update()
	{
		if (isDialogueInProgress)
		{
			try
			{
				gamepadContinue.SetActive(IsGamepad);
				playergamepadContinue.SetActive(IsGamepad);
				keyboardContinue.SetActive(!IsGamepad);
				playerkeyboardContinue.SetActive(!IsGamepad);
			}
			catch (Exception)
			{
			}
			if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
			{
				ProgressDialogue(isGamepad: false);
			}
			else if (Gamepad.current != null && Gamepad.current.aButton.wasPressedThisFrame)
			{
				ProgressDialogue(isGamepad: true);
			}
		}
	}

	private void LevelManager_LevelCompleted()
	{
		CompleteDialogue();
	}

	public void TriggerDialogueProgressEvent()
	{
		dialogueProgressEventTriggered = true;
	}

	public void ProgressDialogue(bool isGamepad)
	{
		IsGamepad = isGamepad;
		dialogueProgressInputTriggered = true;
	}

	private IEnumerator WaitForEventProgress()
	{
		dialogueProgressEventTriggered = false;
		yield return new WaitUntil(() => dialogueProgressEventTriggered);
	}

	private IEnumerator WaitForInputProgress()
	{
		dialogueProgressInputTriggered = false;
		yield return new WaitUntil(() => dialogueProgressInputTriggered);
		clickAudioSource.PlayOneShot(talkSounds[UnityEngine.Random.Range(0, talkSounds.Length)], 0.5f);
	}

	public void TryStartDialogueForWorldInLevel(int worldIndex, int levelIndex)
	{
		int num = SaveManager.Instance.GetTimesWorldDialoguesPlayed(worldIndex);
		if (worldIndex == 0)
		{
			num = 0;
		}
		if (isDialogueInProgress)
		{
			Debug.Log("Dialogue is already in progress. Cannot start a new dialogue.");
		}
		else if (worldIndex < 0)
		{
			Debug.Log($"Invalid world index: {worldIndex}");
		}
		else if (levelIndex < 0)
		{
			Debug.Log($"Invalid level index: {levelIndex}");
		}
		else if (!IterativeDialogueGroupsForWorlds.WorldDialogueIterations.ContainsKey(worldIndex))
		{
			Debug.Log($"No dialogues for world {worldIndex}");
		}
		else if (!IterativeDialogueGroupsForWorlds.WorldDialogueIterations[worldIndex].WorldDialogues.ContainsKey(num))
		{
			Debug.Log($"No dialogues for world {worldIndex} at iteration {num}");
		}
		else if (!IterativeDialogueGroupsForWorlds.WorldDialogueIterations[worldIndex].WorldDialogues[num].LevelDialogues.ContainsKey(levelIndex))
		{
			Debug.Log($"No dialogues for world {worldIndex} at iteration {num} for level {levelIndex}");
		}
		else
		{
			StartDialogueForWorldOnLevel(worldIndex, num, levelIndex);
		}
	}

	public void StartDialogueForWorldOnLevel(int worldIndex, int iteration, int levelIndex)
	{
		Debug.Log($"Starting dialogue for world {worldIndex} at iteration {iteration} for level {levelIndex}.");
		currentWorldIndex = worldIndex;
		currentWorldDialogueIterations = IterativeDialogueGroupsForWorlds.WorldDialogueIterations[worldIndex];
		currentWorldIterationIndex = iteration;
		currentWorldDialogue = currentWorldDialogueIterations.WorldDialogues[iteration];
		currentLevelIndex = levelIndex;
		currentDialogue = currentWorldDialogue.LevelDialogues[levelIndex];
		isDialogueInProgress = true;
		playerDialogueGO.SetActive(value: false);
		correspondentDialogueGO.SetActive(value: false);
		dialogueUI.SetActive(value: true);
		StartCoroutine(StartDialogueCoroutine(currentDialogue));
	}

	public void StartDialogue(LevelDialogueSO dialogue)
	{
		isDialogueInProgress = true;
		playerDialogueGO.SetActive(value: false);
		correspondentDialogueGO.SetActive(value: false);
		dialogueUI.SetActive(value: true);
		StartCoroutine(StartDialogueCoroutine(dialogue));
	}

	public IEnumerator StartDialogueCoroutine(LevelDialogueSO dialogue)
	{
		GameManager.Instance.PauseGame(this);
		for (int i = 0; i < dialogue.DialogueLines.Count; i++)
		{
			DialogueLine line = dialogue.DialogueLines[i];
			if (line.conditionExpression != string.Empty && !DialogueConditionEvaluator.Evaluate(line.conditionExpression))
			{
				continue;
			}
			if (line.noPause)
			{
				GameManager.Instance.ResumeGame(this);
			}
			if (line.waitForEventToStart)
			{
				yield return StartCoroutine(WaitForEventProgress());
			}
			yield return new WaitForSeconds(line.preDelay);
			SetDialogueLine(line);
			CreateAdditionalObjects(line);
			if ((bool)line.sound)
			{
				dialogueAudioSource.clip = line.sound;
				dialogueAudioSource.Play();
			}
			if (!line.autoNext)
			{
				if (line.waitForEventToProgress)
				{
					yield return StartCoroutine(WaitForEventProgress());
				}
				else
				{
					yield return StartCoroutine(WaitForInputProgress());
				}
			}
			DestroyAdditionalObjects();
			if (dialogueAudioSource.isPlaying)
			{
				dialogueAudioSource.Stop();
			}
			yield return new WaitForSeconds(line.postDelay);
			if (line.noPause)
			{
				GameManager.Instance.PauseGame(this);
			}
		}
		CompleteDialogue();
		yield return null;
	}

	private void CompleteDialogue()
	{
		if (isDialogueInProgress)
		{
			this.onCompleteDialogue?.Invoke();
			Debug.Log($"Completed dialogue for world {currentWorldIndex} at iteration {currentWorldIterationIndex} for level {currentLevelIndex}.");
			isDialogueInProgress = false;
			StopAllCoroutines();
			if (currentWorldDialogue != null && currentLevelIndex == currentWorldDialogue.LastLevelIndex)
			{
				SaveManager.Instance.IncrementTimesDialoguesPlayed(currentWorldIndex);
			}
			ClearCurrentDialogue();
			dialogueUI.SetActive(value: false);
			DestroyAdditionalObjects();
			GameManager.Instance.ResumeGame(this);
		}
	}

	private void ClearCurrentDialogue()
	{
		currentWorldIndex = -1;
		currentWorldIterationIndex = -1;
		currentLevelIndex = -1;
		currentWorldDialogueGroup = null;
		currentWorldDialogueIterations = null;
		currentWorldDialogueGroup = null;
		currentDialogue = null;
	}

	private void CreateAdditionalObjects(DialogueLine line)
	{
		if (line.additionalObjectPrefabs != null && line.additionalObjectPrefabs.Length != 0)
		{
			additionalTempObjects = new List<GameObject>();
			GameObject[] additionalObjectPrefabs = line.additionalObjectPrefabs;
			foreach (GameObject original in additionalObjectPrefabs)
			{
				additionalTempObjects.Add(UnityEngine.Object.Instantiate(original, WorldCanvasGroup.transform));
			}
		}
		if (line.additionalUIElementPrefabs != null && line.additionalUIElementPrefabs.Length != 0)
		{
			additionalTempUIElements = new List<GameObject>();
			GameObject[] additionalObjectPrefabs = line.additionalUIElementPrefabs;
			foreach (GameObject original2 in additionalObjectPrefabs)
			{
				additionalTempUIElements.Add(UnityEngine.Object.Instantiate(original2, UICanvasGroup.transform));
			}
		}
	}

	private void DestroyAdditionalObjects()
	{
		if (additionalTempObjects != null && additionalTempObjects.Count > 0)
		{
			foreach (GameObject additionalTempObject in additionalTempObjects)
			{
				UnityEngine.Object.Destroy(additionalTempObject);
			}
			additionalTempObjects.Clear();
		}
		if (additionalTempUIElements == null || additionalTempUIElements.Count <= 0)
		{
			return;
		}
		foreach (GameObject additionalTempUIElement in additionalTempUIElements)
		{
			UnityEngine.Object.Destroy(additionalTempUIElement);
		}
		additionalTempUIElements.Clear();
	}

	private void SetDialogueLine(DialogueLine line)
	{
		if (line.noText)
		{
			playerDialogueGO.SetActive(value: false);
			correspondentDialogueGO.SetActive(value: false);
		}
		else if (line.characterName == "Player")
		{
			SetDialogueLineForPlayer(line);
		}
		else
		{
			SetDialogueLineForCorrespondent(line);
		}
	}

	private void SetDialogueLineForPlayer(DialogueLine line)
	{
		playerDialogueGO.SetActive(value: true);
		correspondentDialogueGO.SetActive(value: false);
		if ((bool)line.characterPortrait)
		{
			playerDialogueCharacterImage.sprite = line.characterPortrait;
		}
		else
		{
			playerDialogueCharacterImage.sprite = currentWorldDialogue.genericPortrait;
		}
		playerNameText.text = GetLocalizedName(line);
		playerDialogueText.text = GetLocalizedText(line);
	}

	private void SetDialogueLineForCorrespondent(DialogueLine line)
	{
		correspondentDialogueGO.SetActive(value: true);
		playerDialogueGO.SetActive(value: false);
		correspondentDialogueCharacterImage.sprite = line.characterPortrait;
		if ((bool)line.characterPortrait)
		{
			correspondentDialogueCharacterImage.sprite = line.characterPortrait;
		}
		else
		{
			correspondentDialogueCharacterImage.sprite = currentWorldDialogue.genericPortrait;
		}
		correspondentNameText.text = GetLocalizedName(line);
		correspondentDialogueText.text = GetLocalizedText(line);
	}

	private string GetLocalizedName(DialogueLine line)
	{
		try
		{
			if (line.localizedText != null)
			{
				return line.localizedCharacterName.GetLocalizedString();
			}
			return line.characterName;
		}
		catch (Exception)
		{
			return line.characterName;
		}
	}

	private string GetLocalizedText(DialogueLine line)
	{
		try
		{
			if (line.localizedText != null)
			{
				return line.localizedText.GetLocalizedString();
			}
			return line.fallbackDialogueText;
		}
		catch (Exception)
		{
			return line.fallbackDialogueText;
		}
	}
}
