using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AssistantController : MonoBehaviour
{
	[SerializeField]
	private AssistantDialogue dialogue;

	[SerializeField]
	private Sprite messageIcon;

	[SerializeField]
	private Sprite folderIcon;

	[SerializeField]
	private Sprite arrestIcon;

	[SerializeField]
	private Sprite manualIcon;

	[SerializeField]
	private Sprite dataIcon;

	[SerializeField]
	private Sprite searchIcon;

	[SerializeField]
	private AssistantSpawner peeker;

	[SerializeField]
	private Settings settings;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private AssistantAudioManager audioManager;

	private static readonly int NEXT_HINT_DELAY_SECONDS = ((!CreateTables.DEV_MODE) ? 5 : 0);

	private static readonly float THINKING_TIME_SECONDS = ((!CreateTables.DEV_MODE) ? 2 : 0);

	private int iconClickedCount;

	private Action lastTutorialRightClick;

	private DateTime peekDelayTime;

	private bool isDancing;

	public IEnumerator Spawn(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		SetIsDancing(dancing: false);
		if (SpawnAssistant())
		{
			audioManager.PlaySwish();
			audioManager.PlayPop();
			StartCoroutine(PlayDialogue(SetNextText));
		}
	}

	private bool SpawnAssistant(bool spawnDancing = false)
	{
		if (settings.IsAssistantDisabled())
		{
			Debug.Log("Assistant disabled.");
			return false;
		}
		Debug.Log("Assistant enabled.");
		base.gameObject.SetActive(value: true);
		animator.Play("spawn");
		if (spawnDancing)
		{
			animator.SetBool("Dance", isDancing);
		}
		return true;
	}

	public void SetLast()
	{
		base.transform.SetAsLastSibling();
	}

	public void SetIsDancing(bool dancing)
	{
		isDancing = dancing;
		animator.SetBool("Dance", isDancing);
	}

	public bool IsDancing()
	{
		return isDancing;
	}

	public void SetNextText()
	{
		if (ShowTutorial())
		{
			animator.SetBool("Tutorial", value: true);
			SetTutorialDialogue();
		}
		else
		{
			animator.SetBool("Tutorial", value: false);
			SetHelpDialogue();
		}
	}

	public void SetLeftButton()
	{
		LevelManager.GetCurrLevel();
		if (ShowTutorial())
		{
			audioManager.PlayClick();
			dialogue.DisableIcon();
			dialogue.SetYesNoPrompt();
			dialogue.SetText("Are you sure you want to skip\nthe tour? This is the only time\nI'll show you around!");
			animator.Play("thinking");
			audioManager.PlayThinking();
			dialogue.SetRightDialogueAction(delegate
			{
				Skip();
			});
			dialogue.SetLeftDialogueAction(delegate
			{
				audioManager.PlayClick();
				lastTutorialRightClick();
				dialogue.SetLeftDialogueAction(delegate
				{
					SetLeftButton();
				});
			});
		}
		else
		{
			Skip();
		}
	}

	public IEnumerator PlayDialogue(Action setTextAction, bool skipWaitTime = false)
	{
		float currentAnimationLength = UIUtils.GetCurrentAnimationLength(animator);
		yield return new WaitForSeconds(skipWaitTime ? 0f : currentAnimationLength);
		dialogue.Enable();
		dialogue.PlayOpen();
		setTextAction();
	}

	public IEnumerator PlaySearchTutorialDialogue(float waitTime)
	{
		SetIsDancing(dancing: false);
		yield return new WaitForSeconds(waitTime);
		if (SpawnAssistant())
		{
			StartCoroutine(PlayDialogue(SetSearchTutorialDialogue));
		}
	}

	public void SetSearchTutorialDialogue()
	{
		animator.SetBool("Tutorial", value: false);
		SetIsDancing(dancing: false);
		dialogue.SetThanksPrompt();
		dialogue.ClearQuestionAnswers();
		dialogue.SetText("Here's a quick tip!\nIf you want to save your tables for later,\nmake sure to hit the <b>Save Table</b>\ncheckbox in the <i>Search Tables</i> window!");
		audioManager.PlayHey2();
		SetTutorialRightClick(delegate
		{
			Skip();
		});
	}

	public void SetTutorialDialogue()
	{
		dialogue.SetText("Hello detective!");
		audioManager.PlayHello();
		dialogue.SetNextPrompt();
		SetTutorialRightClick(delegate
		{
			dialogue.SetText("I haven't seen you around before!\nI'm an intern from the moleman\ndepartment, here to help out!");
			animator.Play("wave idle transition");
			audioManager.PlayHelloReal();
			dialogue.SetNextPrompt();
			SetTutorialRightClick(delegate
			{
				dialogue.SetText("Want me to show you around?");
				animator.Play("thinking");
				audioManager.PlayThinking();
				dialogue.SetYesNoPrompt();
				SetTutorialRightClick(delegate
				{
					dialogue.DisplayIcon(messageIcon);
					dialogue.SetText("Awesome! You should start by checking your messages if you\nhaven't already. It's always a good\nidea to listen to authority figures!");
					animator.Play("idea");
					audioManager.PlayAha2();
					dialogue.SetNextPrompt();
					SetTutorialRightClick(delegate
					{
						dialogue.DisplayIcon(folderIcon);
						dialogue.SetText("Once you got the debrief, you should\ngo through the pieces of evidence\nwe've collected for you.");
						animator.Play("idea transition");
						audioManager.PlayMhm();
						dialogue.SetNextPrompt();
						SetTutorialRightClick(delegate
						{
							dialogue.DisplayIcon(dataIcon);
							dialogue.SetText("Most of the time, you should also\nbe provided some data related\nto your case. Think of this data as\nanother important piece of evidence!");
							animator.Play("idle");
							audioManager.PlayMhm2();
							dialogue.SetNextPrompt();
							SetTutorialRightClick(delegate
							{
								dialogue.DisplayIcon(searchIcon);
								dialogue.SetText("There's usually a lot of data to go\nthrough. Use this application to write\na <i>SQL query</i> to fetch the specific data\nyou want! You probably won't need\nthis for your current case though.");
								animator.Play("idle");
								audioManager.PlayMhm4();
								dialogue.SetNextPrompt();
								SetTutorialRightClick(delegate
								{
									dialogue.DisplayIcon(manualIcon);
									dialogue.SetText("Not sure what a <i>SQL query</i> is?\nNo worries! Just read through this\nhelpful textbook to learn more!");
									animator.Play("idle");
									audioManager.PlayYeah();
									dialogue.SetNextPrompt();
									SetTutorialRightClick(delegate
									{
										dialogue.DisplayIcon(arrestIcon);
										dialogue.SetText("Once you're confident about who\nthe perpetrator is, just fill out the\narrest warrant using this icon to\nfinish the case!");
										animator.Play("idle");
										audioManager.PlayMhm();
										dialogue.SetNextPrompt();
										SetTutorialRightClick(delegate
										{
											dialogue.DisableIcon();
											dialogue.SetText("That's all for now!\nIf you need any help,\ndon't hesitate to ask!");
											dialogue.SetThanksPrompt();
											audioManager.PlayGibber();
											animator.Play("wave transition");
											SetTutorialRightClick(delegate
											{
												Skip();
											});
										});
									});
								});
							});
						});
					});
				});
			});
		});
	}

	private void SetTutorialRightClick(Action action)
	{
		lastTutorialRightClick = action;
		dialogue.SetRightDialogueAction(action.Invoke);
	}

	private UnityAction GetHelpWrapper(Action helpAction, string thinkingText = "Let me think...", float delaySeconds = 0f)
	{
		return delegate
		{
			audioManager.PlayClick();
			dialogue.DisablePrompts();
			dialogue.SetText(thinkingText);
			animator.Play("thinking");
			audioManager.PlayThinking();
			StartCoroutine(GetHelp());
		};
		IEnumerator GetHelp()
		{
			yield return new WaitForSeconds(THINKING_TIME_SECONDS);
			dialogue.SetThanksPrompt();
			helpAction();
			animator.Play("idea");
			audioManager.PlayOh();
			dialogue.SetRightDialogueAction(delegate
			{
				Skip(delaySeconds);
				peekDelayTime = DateTime.Now.AddSeconds(delaySeconds);
			});
		}
	}

	public float GetRemainingDelaySeconds()
	{
		_ = peekDelayTime;
		if (DateTime.Now > peekDelayTime)
		{
			return 0f;
		}
		return (float)(peekDelayTime - DateTime.Now).TotalSeconds;
	}

	public void SetHelpDialogue()
	{
		dialogue.ClearQuestionAnswers();
		dialogue.CreateQuestionAnswer("Writing SQL queries.", GetHelpWrapper(delegate
		{
			HintManager.GetQueryHelp(dialogue);
		}, "Let me think...", NEXT_HINT_DELAY_SECONDS));
		dialogue.CreateQuestionAnswer("Figuring out the case.", GetHelpWrapper(delegate
		{
			HintManager.GetCaseHelp(dialogue);
		}, "Let me think...", NEXT_HINT_DELAY_SECONDS));
		dialogue.CreateQuestionAnswer("My personal problems.", GetPersonalResponse());
		dialogue.CreateQuestionAnswer("Nothing.", Skip);
		dialogue.EnableQuestions();
		dialogue.SetText("Hey there detective!\nWhat do you need help with?");
		audioManager.PlayHey2();
	}

	private UnityAction GetPersonalResponse()
	{
		return delegate
		{
			audioManager.PlayClick();
			dialogue.ClearQuestionAnswers();
			dialogue.CreateQuestionAnswer("Feeling a lack of purpose.", GetHelpWrapper(delegate
			{
				dialogue.SetText("Are you not working hard enough?\nLazy bums who don't work hard\ntend to feel this way!");
			}, "Hmm..."));
			dialogue.CreateQuestionAnswer("Heartbreak.", GetHelpWrapper(delegate
			{
				dialogue.SetText("Couldn't be me!");
			}, "Hmm..."));
			dialogue.CreateQuestionAnswer("Health problems.", GetHelpWrapper(delegate
			{
				dialogue.SetText("The most important part of your health\nis your mental health! Did you know\nthe best way to improve mental health\nis spending more time at work?");
			}, "Hmm..."));
			dialogue.CreateQuestionAnswer("Financial problems.", GetHelpWrapper(delegate
			{
				dialogue.SetText("You should work harder!\nThat way, you'll get more experience,\nwhich is more valuable than money!");
			}, "Hmm..."));
			dialogue.CreateQuestionAnswer("I'm ugly.", GetHelpWrapper(delegate
			{
				dialogue.SetText("You should spend more time at\nwork so less people see your\nugly face!");
			}, "Hmm..."));
			dialogue.CreateQuestionAnswer("I'm bad at video games.", GetHelpWrapper(delegate
			{
				dialogue.SetText("That's not a problem at all! You\nshould spend more time here at work\ninstead of playing games anyways!");
			}, "Hmm..."));
			dialogue.SetText("What personal problems are you\nstruggling with?");
			audioManager.PlayYeah();
		};
	}

	public void IconClicked()
	{
		iconClickedCount++;
		dialogue.DisableIcon();
		dialogue.SetNextPrompt();
		if (iconClickedCount == 1)
		{
			dialogue.SetText("That's the spirit!\nThat wasn't the real icon you\nshould click on though, it should be\nsomewhere else on your desktop.");
		}
		else
		{
			dialogue.SetText("Did you not hear me?\nThat was just an example of what\nthe icon looks like. The real icon\nshould be somewhere else on your desktop.");
		}
	}

	public void Skip()
	{
		Skip(0f);
	}

	public void Skip(float delaySeconds = 0f)
	{
		audioManager.PlayClick();
		Despawn();
		if (!isDancing)
		{
			StartCoroutine(peeker.PeekRoutine(delaySeconds));
		}
	}

	public void Despawn()
	{
		if (!(animator == null))
		{
			SetIsDancing(dancing: false);
			audioManager.PlayWoosh();
			animator.Play("despawn transition");
			dialogue.Disable();
		}
	}

	public IEnumerator StartDancing()
	{
		if (peeker.IsPeeking())
		{
			float seconds = peeker.Cower();
			isDancing = true;
			yield return new WaitForSeconds(seconds);
			if (SpawnAssistant(spawnDancing: true))
			{
				peeker.DisableDialogue();
				StartCoroutine(PlayDialogue(PleaseHold));
			}
			else
			{
				SetIsDancing(dancing: false);
			}
		}
		else if (!settings.IsAssistantDisabled())
		{
			dialogue.Disable();
			StartCoroutine(PlayDialogue(PleaseHold, skipWaitTime: true));
			animator.Play("dance");
		}
		void PleaseHold()
		{
			dialogue.DisablePrompts();
			dialogue.SetText("Please hold...");
		}
	}

	public void ForceWave()
	{
		animator.SetBool("Dance", value: false);
		animator.SetBool("Tutorial", value: true);
		base.gameObject.SetActive(value: true);
		animator.Play("spawn");
		dialogue.gameObject.SetActive(value: false);
	}

	public void DespawnAssistants()
	{
		if (peeker.IsPeeking())
		{
			peeker.Cower();
		}
		else
		{
			Despawn();
		}
	}

	public IEnumerator PlaySearchTutorialDialogue()
	{
		if (settings.IsAssistantDisabled())
		{
			return null;
		}
		if (peeker.IsPeeking())
		{
			float waitTime = peeker.Cower();
			return PlaySearchTutorialDialogue(waitTime);
		}
		SetSearchTutorialDialogue();
		return null;
	}

	public bool ShowTutorial()
	{
		if (LevelManager.GetCurrLevel() == 0)
		{
			return !Save.HasSeenTutorial();
		}
		return false;
	}
}
