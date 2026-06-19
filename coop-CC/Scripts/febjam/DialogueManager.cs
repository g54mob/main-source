using System.Collections;
using Aggro.Core;
using FMODUnity;
using TMPro;
using UnityEngine;

public class DialogueManager : AggroManagerBase<DialogueManager>, IInputController
{
	private static readonly int Show = Animator.StringToHash("show");

	public GameObject container;

	public LocalizedText localizedText;

	public TextMeshProUGUI dialogueText;

	[Space]
	[Min(0f)]
	public float timeBetweenCharacters = 0.05f;

	public float sfxRate = 0.5f;

	[Header("Audio")]
	public EventReference characterSfx;

	public EventReference completeSfx;

	public GameObject portraitIdle;

	public GameObject portraitTalk;

	public GameObject portraitNod;

	public GameObject portraitLaugh;

	public Animator animator;

	protected override void OnEntityCreated()
	{
		container.SetActive(value: false);
	}

	public IEnumerator PlayDialogueCo(DialogueObject dialogue)
	{
		container.SetActive(value: true);
		animator.SetBool(Show, value: true);
		AggroInputManager.PushController(this);
		for (int i = 0; i < dialogue.dialogues.Length; i++)
		{
			string index = dialogue.dialogues[i];
			localizedText.onRefreshText = (string x) => GlobalScriptableObject<TextTagData>.instance.ParseText(x);
			localizedText.SetIndex(index);
			dialogueText.ForceMeshUpdate();
			dialogueText.maxVisibleCharacters = 0;
			float accumulated = 0f;
			float accumulatedBloop = 0f;
			while (dialogueText.maxVisibleCharacters < dialogueText.textInfo.characterCount)
			{
				yield return null;
				if (AggroInputManager.input.Dialogue.Complete.WasPerformedThisFrame())
				{
					dialogueText.maxVisibleCharacters = dialogueText.textInfo.characterCount;
					AudioManager.PlaySfx(completeSfx);
				}
				else
				{
					accumulated += Time.deltaTime;
					accumulatedBloop += Time.deltaTime;
					if (accumulated >= timeBetweenCharacters)
					{
						while (accumulated >= timeBetweenCharacters && dialogueText.maxVisibleCharacters < dialogueText.textInfo.characterCount)
						{
							accumulated -= timeBetweenCharacters;
							dialogueText.maxVisibleCharacters++;
						}
					}
					if (accumulatedBloop >= sfxRate)
					{
						AudioManager.PlaySfx(characterSfx);
						while (accumulatedBloop >= sfxRate)
						{
							accumulatedBloop -= sfxRate;
						}
					}
				}
				portraitIdle.SetActive(value: false);
				portraitTalk.SetActive(dialogue.portraitTypes[i] == DialogueObject.PortraitType.Talk);
				portraitNod.SetActive(dialogue.portraitTypes[i] == DialogueObject.PortraitType.Nod);
				portraitLaugh.SetActive(dialogue.portraitTypes[i] == DialogueObject.PortraitType.Laugh);
			}
			portraitIdle.SetActive(value: true);
			portraitTalk.SetActive(value: false);
			portraitNod.SetActive(value: false);
			portraitLaugh.SetActive(value: false);
			do
			{
				yield return null;
			}
			while (!AggroInputManager.input.Dialogue.Complete.WasPerformedThisFrame());
		}
		animator.SetBool(Show, value: false);
		AggroInputManager.RemoveController(this);
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.Dialogue.Enable();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.Dialogue.Disable();
	}
}
