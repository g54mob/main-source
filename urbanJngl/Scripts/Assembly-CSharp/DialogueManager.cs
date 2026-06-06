using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.LocalizationService;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
	public class OnDialogueLeftEventArgs : EventArgs
	{
		public bool isPhone;
	}

	[SerializeField]
	private List<Dialogue> dialogues;

	private Dialogue currentDialogue;

	private DialoguePart currentDialoguePart;

	private int currentDialogueIndex;

	private int currentDialoguePartIndex;

	private IPersistentProgressService _progressService;

	private string currentSceneName;

	public Action StartTutorial;

	private bool isActive;

	private bool isDialogueWithIDOneFinished;

	private bool isDialogueWithIDTwoFinished;

	public static DialogueManager Instance { get; private set; }

	public event EventHandler OnDialogueStart;

	public event EventHandler OnDialogueFinish;

	public event EventHandler<OnDialogueLeftEventArgs> OnDialogueLeft;

	public event EventHandler OnLastDialogueFinish;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		currentDialogue = dialogues[currentDialogueIndex];
		currentDialoguePart = currentDialogue.dialogueParts[currentDialoguePartIndex];
		_progressService = AllServices.Container.Single<IPersistentProgressService>();
		currentSceneName = SceneManager.GetActiveScene().name;
		SetupCharacterNames();
		Localize();
		LocalizationManager.OnLocalizationChanged += Localize;
		DialogueUI.Instance.OnNextDialogue += DialogueUI_OnNextDialogue;
		TotalScoreCalculator.Instance.OnTotalScoreChanged += TotalScoreCalculator_OnTotalScoreChanged;
		if (!_progressService.Progress.CreativeMode)
		{
			isDialogueWithIDOneFinished = !_progressService.Progress.DialogsStart[currentSceneName + 1];
		}
	}

	public void OnDestroy()
	{
		LocalizationManager.OnLocalizationChanged -= Localize;
		DialogueUI.Instance.OnNextDialogue -= DialogueUI_OnNextDialogue;
		TotalScoreCalculator.Instance.OnTotalScoreChanged -= TotalScoreCalculator_OnTotalScoreChanged;
	}

	private void TotalScoreCalculator_OnTotalScoreChanged(object sender, EventArgs e)
	{
		int totalScore = TotalScoreCalculator.Instance.GetTotalScore();
		int scoreMax = CollectionManager.Instance.GetScoreMax();
		if ((float)totalScore >= (float)scoreMax / 2f && IsThereDialogueWithID(1) && !isDialogueWithIDOneFinished)
		{
			this.OnDialogueLeft?.Invoke(this, new OnDialogueLeftEventArgs
			{
				isPhone = IsItPhoneCallWithID(1)
			});
			isDialogueWithIDOneFinished = true;
		}
	}

	private IEnumerator ShowDialogueWithDelay()
	{
		yield return new WaitForSeconds(2f);
		this.OnDialogueLeft?.Invoke(this, new OnDialogueLeftEventArgs
		{
			isPhone = dialogues[1].isPhone
		});
		isDialogueWithIDOneFinished = true;
	}

	public void ShowStartingDialogue()
	{
		if (_progressService.Progress.DialogsStart.ContainsKey(currentSceneName + 0) && _progressService.Progress.DialogsStart[currentSceneName + 0])
		{
			_progressService.Progress.DialogsStart[currentSceneName + 0] = false;
			if (currentSceneName == "Level_0_New")
			{
				StartTutorial?.Invoke();
			}
			InputManager.Instance.gamePause = true;
			SetDialogWithID(0);
			this.OnDialogueStart?.Invoke(this, EventArgs.Empty);
			isActive = true;
			ShowDialogue();
		}
	}

	public void ShowNextDialogueWithID(int ID)
	{
		if (_progressService.Progress.DialogsStart.ContainsKey(currentSceneName + ID) && _progressService.Progress.DialogsStart[currentSceneName + ID])
		{
			_progressService.Progress.DialogsStart[currentSceneName + ID] = false;
			InputManager.Instance.gamePause = true;
			SetDialogWithID(ID);
			if (!currentDialogue.isFinished)
			{
				this.OnDialogueStart?.Invoke(this, EventArgs.Empty);
				isActive = true;
				ShowDialogue();
			}
		}
	}

	public void NextDialogue()
	{
		currentDialoguePartIndex++;
		if (currentDialogue.TryGetDialoguePart(currentDialoguePartIndex))
		{
			currentDialoguePart = currentDialogue.dialogueParts[currentDialoguePartIndex];
			ShowDialogue();
			return;
		}
		currentDialogueIndex++;
		currentDialoguePartIndex = 0;
		if (currentDialogueIndex < dialogues.Count && dialogues[currentDialogueIndex - 1].ID == dialogues[currentDialogueIndex].ID)
		{
			currentDialogue = dialogues[currentDialogueIndex];
			currentDialoguePart = currentDialogue.dialogueParts[currentDialoguePartIndex];
			ShowDialogue();
			return;
		}
		currentDialogue.isFinished = true;
		this.OnDialogueFinish?.Invoke(this, EventArgs.Empty);
		isActive = false;
		if (currentDialogue.ID == 2)
		{
			isDialogueWithIDTwoFinished = true;
			this.OnLastDialogueFinish?.Invoke(this, EventArgs.Empty);
		}
	}

	public bool IsDialogueWithIDTwoFinished()
	{
		if (isDialogueWithIDTwoFinished)
		{
			return true;
		}
		return false;
	}

	private void DialogueUI_OnNextDialogue(object sender, EventArgs e)
	{
		NextDialogue();
	}

	public bool IsActive()
	{
		return isActive;
	}

	public void ShowDialogue()
	{
		Sprite characterSprite = null;
		foreach (Emotion emotion in currentDialogue.characterSO.emotions)
		{
			if (currentDialoguePart.emotionType == emotion.emotion)
			{
				characterSprite = emotion.sprite;
				break;
			}
		}
		DialogueUI.Instance.SetDialogue(currentDialogue.characterSO, currentDialogue.characterName, characterSprite, currentDialogue.onRight, currentDialoguePart.text, currentDialoguePart.answer_1, currentDialoguePart.answer_2);
	}

	public void ShowDialogueWithCharacter(CharacterSO characterSO)
	{
		for (int i = 0; i < dialogues.Count; i++)
		{
			if (dialogues[i].characterSO == characterSO && dialogues[i].ID != 0)
			{
				currentDialogue = dialogues[i];
				currentDialogueIndex = i;
				currentDialoguePartIndex = 0;
				currentDialoguePart = dialogues[currentDialogueIndex].dialogueParts[currentDialoguePartIndex];
				break;
			}
		}
		this.OnDialogueStart?.Invoke(this, EventArgs.Empty);
		isActive = true;
		ShowDialogue();
	}

	private void SetDialogWithID(int ID)
	{
		for (int i = 0; i < dialogues.Count; i++)
		{
			if (dialogues[i].ID == ID)
			{
				currentDialogue = dialogues[i];
				currentDialogueIndex = i;
				currentDialoguePartIndex = 0;
				currentDialoguePart = dialogues[currentDialogueIndex].dialogueParts[currentDialoguePartIndex];
				break;
			}
		}
	}

	private void SetupCharacterNames()
	{
		foreach (Dialogue dialogue in dialogues)
		{
			dialogue.characterName = dialogue.characterSO.characterName;
		}
	}

	public bool IsThereDialogueWithID(int ID)
	{
		foreach (Dialogue dialogue in dialogues)
		{
			if (dialogue.ID == ID)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsItPhoneCallWithID(int ID)
	{
		foreach (Dialogue dialogue in dialogues)
		{
			if (dialogue.ID == ID)
			{
				if (dialogue.isPhone)
				{
					return true;
				}
				return false;
			}
		}
		return false;
	}

	private void Localize()
	{
		foreach (Dialogue dialogue in dialogues)
		{
			foreach (DialoguePart dialoguePart in dialogue.dialogueParts)
			{
				dialoguePart.text = LocalizationManager.Localize(dialoguePart.textLocalizationKey);
				dialoguePart.answer_1 = LocalizationManager.Localize(dialoguePart.answer_1LocalizationKey);
				dialoguePart.answer_2 = LocalizationManager.Localize(dialoguePart.answer_2LocalizationKey);
			}
			dialogue.characterName = LocalizationManager.Localize(dialogue.characterSO.localizationKey);
		}
	}

	private void SetupLocalizationKeys()
	{
		int num = SceneManager.GetActiveScene().name switch
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
			_ => 0, 
		};
		string text = "";
		int num2 = 1;
		int num3 = 0;
		foreach (Dialogue dialogue in dialogues)
		{
			if (dialogue.ID != num3)
			{
				num2 = 1;
			}
			foreach (DialoguePart dialoguePart in dialogue.dialogueParts)
			{
				if (num3 != dialogue.ID)
				{
					num2 = 1;
				}
				text = "Dialogue" + num + "_" + dialogue.ID + "." + dialogue.characterSO.characterName + "_" + num2;
				dialoguePart.textLocalizationKey = text;
				num2++;
				if (dialoguePart.answer_1 != "")
				{
					text = "Dialogue" + num + "_" + dialogue.ID + ".Answer_" + num2;
					dialoguePart.answer_1LocalizationKey = text;
					num2++;
					if (dialoguePart.answer_2 != "")
					{
						text = "Dialogue" + num + "_" + dialogue.ID + ".Answer_" + num2;
						dialoguePart.answer_2LocalizationKey = text;
						num2++;
					}
				}
			}
		}
	}
}
