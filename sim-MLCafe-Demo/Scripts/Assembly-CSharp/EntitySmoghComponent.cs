using System;
using UnityEngine;
using UnityEngine.Events;

public class EntitySmoghComponent : MonoBehaviour
{
	[SerializeField]
	private EntityNameTag entityNameTag;

	[SerializeField]
	private EntityNameTag entityNameTagUnknown;

	[SerializeField]
	private Transform axisYaw;

	[SerializeField]
	private Transform axisPitch;

	[SerializeField]
	private float lookatRange = 3f;

	[SerializeField]
	private float lookatSpeed = 1f;

	[SerializeField]
	private float tutorialPopupProceedingDelay = 0.5f;

	[SerializeField]
	private GameObject gameobjectMuffleTape;

	[SerializeField]
	private GameObject hangingAttachment;

	[SerializeField]
	private GameObject standingAttachment;

	[SerializeField]
	private CustomerUIInfo uiInfo;

	[SerializeField]
	private Animator animator;

	[Header("Sound")]
	[SerializeField]
	private string soundSipping;

	[SerializeField]
	private string soundReactionWrongCoffee;

	[SerializeField]
	private string soundReactionGarbage;

	[SerializeField]
	private string soundMuffledSpeak;

	[SerializeField]
	private string soundNormalSpeak;

	[Header("Dialogs")]
	[SerializeField]
	private string dialogSleepTag;

	[SerializeField]
	private DialogSequence dialogSequenceReactionBringCoffee;

	[SerializeField]
	private DialogSequence dialogSequenceReactionReceiveCoffee;

	[Header("Localization")]
	[SerializeField]
	private string localizedReactionNotACoffee;

	[SerializeField]
	private string localizedReactionGarbageCan;

	private bool justReceivedCoffee;

	private bool receivedCoffee;

	private bool sequenceMakeCoffeeFinished;

	private bool sequenceRunCafeFinished;

	private bool isMuffled = true;

	private int muffleCounter;

	private bool isPlaying;

	private void Start()
	{
		entityNameTag = new EntityNameTag("dialog_name_smogh", PopupMessageManager.GetDefaultHighlightColor());
		entityNameTagUnknown = new EntityNameTag("", PopupMessageManager.GetDefaultHighlightColor(), usePreLocalization: true, "...");
		WorldTime.instance.OnTick.AddListener(UpdateTick);
		if (CafeDataLoader.IsLoadingOrHasLoaded())
		{
			UnmuffleWithoutStarting();
			return;
		}
		if (TutorialManager.IsAvailable())
		{
			TutorialManager.OnNextTutorialState.AddListener(PlayProceedToNextTutorialReaction);
			uiInfo.ShowPop();
		}
		else
		{
			uiInfo.HidePop();
			UnmuffleWithoutStarting();
		}
		if (base.transform.parent.GetComponent<LampComponent>() == null && base.transform.parent.GetComponent<ItemSocket>() == null)
		{
			OnRemove();
		}
		else
		{
			ActivateAttachment();
		}
	}

	private void OnDestroy()
	{
		TutorialManager.OnNextTutorialState.RemoveListener(PlayProceedToNextTutorialReaction);
		TutorialManager.StopTutorial();
		PopupMessageManager.GetInValidOrMissingPopUp().Hide();
	}

	public void OnInteraction()
	{
		if (isMuffled)
		{
			Unmuffle();
		}
		else
		{
			if (CheckCoffeeGiven())
			{
				return;
			}
			if (uiInfo.IsVisible() && TutorialManager.IsRunning())
			{
				uiInfo.HideInfo();
			}
			switch (TutorialManager.GetCurrentState())
			{
			case TutorialManager.TutorialState.Enter:
				PlayTutorialEnter();
				break;
			case TutorialManager.TutorialState.MakeCoffee:
				PlayTutorialMakeCoffee();
				break;
			case TutorialManager.TutorialState.BringCoffee:
				if (!sequenceMakeCoffeeFinished)
				{
					PopRepeatMakeCoffeeConfirmation();
				}
				else
				{
					PlayTutorialBringCoffee();
				}
				break;
			case TutorialManager.TutorialState.RunCafe:
				PlayTutorialRunCafe();
				break;
			case TutorialManager.TutorialState.Stopped:
				if (TutorialManager.GetLockByTutorial())
				{
					TutorialManager.StopTutorial();
				}
				PlayCasualTalk();
				break;
			default:
				PlayCasualTalk();
				break;
			}
		}
	}

	public void ActivateAttachment()
	{
		hangingAttachment.SetActive(value: true);
		standingAttachment.SetActive(value: false);
	}

	public void OnRemove()
	{
		hangingAttachment.SetActive(value: false);
		standingAttachment.SetActive(value: true);
	}

	private void Unmuffle()
	{
		isMuffled = false;
		isPlaying = false;
		gameobjectMuffleTape.SetActive(value: false);
		animator.SetBool("Speak", value: false);
		DialogSequenceManager.GetGlobalDialogBox().StopDialog();
		SoundManager.StopSoundContainingKey(soundMuffledSpeak);
		PlayTutorialEnter();
	}

	private void UnmuffleWithoutStarting()
	{
		isMuffled = false;
		gameobjectMuffleTape.SetActive(value: false);
		SoundManager.StopSoundContainingKey(soundMuffledSpeak);
	}

	private void PlayRandomMuffle()
	{
		if (WorldTime.GetCurrentDate().day == 1 && !CafeShopManager.IsCafeOpen())
		{
			WorldTime.PauseSimulation();
		}
		DialogSequence dialogSequence = DialogManager.GetSmoghDialogReactions().Find((DialogSequence x) => x.IsTag("Smogh Muffled"));
		if (dialogSequence == null)
		{
			return;
		}
		Dialog singleRandomAsDialog = dialogSequence.GetSingleRandomAsDialog(entityNameTag, soundMuffledSpeak);
		singleRandomAsDialog.autoProceed = true;
		singleRandomAsDialog.animationProperty = new DialogAnimationProperty(animator, "Speak", value: true);
		DialogBoxComponent globalDialogBox = DialogSequenceManager.GetGlobalDialogBox();
		globalDialogBox.OnFinished = (UnityAction)Delegate.Combine(globalDialogBox.OnFinished, (UnityAction)delegate
		{
			TweenerManager.TweenTimeAction("Wait For Muffle", 2f, delegate
			{
				isPlaying = false;
			});
		});
		if (DialogSequenceManager.PlayDialogSequence(singleRandomAsDialog))
		{
			isPlaying = true;
			muffleCounter++;
		}
	}

	public void PlayReactionMadeCoffee(int appliedFlavours)
	{
		if (!receivedCoffee)
		{
			DialogSequenceManager.GetGlobalDialogBox().StopDialogImmidiate();
			Dialog dialog = null;
			string[] names = new string[2] { "Hot", "Mild" };
			dialog = ((appliedFlavours != AnomalyTag.CreateByName(names).anomalyFlags) ? new Dialog(entityNameTag, new string[1] { localizedReactionNotACoffee }, soundReactionWrongCoffee, autoProceed: true) : DialogManager.GetSmoghDialogReactions().Find((DialogSequence x) => x.IsTag("Tutorial Step Finished")).AsDialog(entityNameTag, soundNormalSpeak));
			dialog.animationProperty = new DialogAnimationProperty(animator, "Speak", value: true);
			TutorialManager.PlayTutorialDialog(dialog);
		}
	}

	private void PlayTutorialEnter()
	{
		uiInfo.HidePop();
		TutorialManager.StartTutorial();
		TutorialManager.ChangeTutorialStateTo(TutorialManager.TutorialState.Enter);
		Dialog currentDialog = TutorialManager.GetCurrentDialog(entityNameTag);
		if (currentDialog != null)
		{
			currentDialog.animationProperty = new DialogAnimationProperty(animator, "Speak", value: true);
			TutorialManager.PlayTutorialDialog(currentDialog);
		}
	}

	private void PlayTutorialMakeCoffee()
	{
		Action onNextTutorialState = delegate
		{
			TutorialManager.ChangeTutorialStateTo(TutorialManager.TutorialState.BringCoffee);
		};
		Dialog currentDialog = TutorialManager.GetCurrentDialog(entityNameTag, onNextTutorialState);
		currentDialog.animationProperty = new DialogAnimationProperty(animator, "Speak", value: true);
		TutorialManager.PlayTutorialDialog(currentDialog);
		if (!justReceivedCoffee)
		{
			TutorialManager.TryShowCheckList(TutorialManager.GetSectionOfState(TutorialManager.TutorialState.MakeCoffee));
		}
	}

	private void PlayTutorialBringCoffee()
	{
		if (!GlobalReferences.GetCharacterController().socket.IsHoldingItem())
		{
			DialogSequenceManager.PlayDialogSequence(dialogSequenceReactionBringCoffee.AsDialog(entityNameTag));
		}
		else
		{
			CheckCoffeeGiven();
		}
	}

	private bool CheckCoffeeGiven()
	{
		if (justReceivedCoffee || TutorialManager.GetCurrentState() > TutorialManager.TutorialState.BringCoffee)
		{
			return false;
		}
		ItemSocket socket = GlobalReferences.GetCharacterController().socket;
		if (!socket.IsHoldingItem() || (socket.IsHoldingItem() && socket.GetItemComponent().GetComponent<ProductComponent>() == null && TutorialManager.GetCurrentState() != TutorialManager.TutorialState.BringCoffee))
		{
			return false;
		}
		ProductComponent component = socket.GetItemComponent().GetComponent<ProductComponent>();
		if (component == null && TutorialManager.GetCurrentState() != TutorialManager.TutorialState.BringCoffee)
		{
			return false;
		}
		DialogSequenceManager.GetGlobalDialogBox().StopDialogImmidiate();
		if (component == null)
		{
			DialogSequenceManager.PlayDialogSequence(new Dialog(entityNameTag, new string[1] { localizedReactionNotACoffee }, soundReactionWrongCoffee, autoProceed: true));
			return false;
		}
		string[] names = new string[2] { "Hot", "Mild" };
		if (component.IsHoldingProduct() && component.GetProduct().appliedTags.anomalyFlags == AnomalyTag.CreateByName(names).anomalyFlags)
		{
			Dialog dialog = dialogSequenceReactionReceiveCoffee.AsDialog(entityNameTag, soundSipping);
			dialog.animationProperty = new DialogAnimationProperty(animator, "Speak", value: true);
			DialogSequenceManager.PlayDialogSequence(dialog);
			SoundManager.PlaySoundOnce(soundSipping);
			component.GetComponent<CupComponent>().MarkDirty();
			justReceivedCoffee = true;
			TutorialManager.TryCheckSectionChecklistOption("GiveCoffee", TutorialManager.TutorialState.MakeCoffee);
			TutorialManager.HideCheckList();
			TutorialManager.NextTutorialState();
			TutorialManager.ChangeTutorialStateTo(TutorialManager.TutorialState.RunCafe);
		}
		else
		{
			DialogSequenceManager.PlayDialogSequence(new Dialog(entityNameTag, new string[1] { localizedReactionNotACoffee }, soundReactionWrongCoffee, autoProceed: true)
			{
				animationProperty = new DialogAnimationProperty(animator, "Speak", value: true)
			});
		}
		return true;
	}

	private void PlayTutorialRunCafe()
	{
		if (justReceivedCoffee)
		{
			justReceivedCoffee = false;
			DialogSequenceManager.GetGlobalDialogBox().StopDialogImmidiate();
			TweenerManager.TweenTimeAction("DelayChecklistRunCafe", 2f, delegate
			{
				TutorialManager.TryShowCheckList(TutorialManager.GetSectionOfState(TutorialManager.TutorialState.RunCafe));
			});
			receivedCoffee = true;
			TutorialManager.ResetDialogIndex();
		}
		if (receivedCoffee)
		{
			TutorialManager.ChangeTutorialStateTo(TutorialManager.TutorialState.RunCafe);
			Action action = delegate
			{
				TutorialManager.StopTutorial();
			};
			Dialog currentDialog = TutorialManager.GetCurrentDialog(entityNameTag, action);
			if (currentDialog != null)
			{
				currentDialog.animationProperty = new DialogAnimationProperty(animator, "Speak", value: true);
				TutorialManager.PlayTutorialDialog(currentDialog, action);
			}
		}
	}

	private void PopRepeatMakeCoffeeConfirmation()
	{
		Action repeat = delegate
		{
			TutorialManager.ChangeTutorialStateTo(TutorialManager.TutorialState.MakeCoffee);
			sequenceMakeCoffeeFinished = false;
			OnInteraction();
		};
		Action next = delegate
		{
			sequenceMakeCoffeeFinished = true;
			OnInteraction();
		};
		PopConfirmation(repeat, next);
	}

	private void PopRepeatRunCafeConfirmation()
	{
		Action repeat = delegate
		{
			TutorialManager.ChangeTutorialStateTo(TutorialManager.TutorialState.RunCafe);
			sequenceRunCafeFinished = false;
			OnInteraction();
		};
		Action next = delegate
		{
			TutorialManager.StopTutorial();
			sequenceRunCafeFinished = true;
			OnInteraction();
		};
		PopConfirmation(repeat, next);
	}

	private void PopConfirmation(Action repeat, Action next)
	{
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
		PopupMessageManager.GetConfirmationPopUp().ShowConfirmationPopup(PopupMessageManager.GetInstance().popupLocalizationMsgProceedTutorial, repeat, next, PopupMessageManager.GetInstance().popupLocalizationCancleRepeat, PopupMessageManager.GetInstance().popupLocalizationConfirmNext);
	}

	private void PlayCasualTalk()
	{
		PlayCasualDialogByTag(dialogSleepTag);
	}

	public void PlayTrashcanScream()
	{
		DialogSequenceManager.GetGlobalDialogBox().StopDialogImmidiate();
		SoundManager.StopSoundContainingKey(soundNormalSpeak);
		SoundManager.StopSoundContainingKey(soundReactionWrongCoffee);
		SoundManager.StopSoundContainingKey(soundMuffledSpeak);
		DialogSequenceManager.PlayDialogSequence(new Dialog(entityNameTag, new string[1] { localizedReactionGarbageCan }, soundReactionGarbage, autoProceed: true));
	}

	private void PlayProceedToNextTutorialReaction()
	{
	}

	private bool PlayReactionDialogByTag(string tag, bool randomizeSingleDialog = false, Action onFinished = null)
	{
		DialogSequence dialogSequence = DialogManager.GetSmoghDialogReactions().Find((DialogSequence x) => x.IsTag(tag));
		if (dialogSequence == null)
		{
			return false;
		}
		if (randomizeSingleDialog)
		{
			Dialog singleRandomAsDialog = dialogSequence.GetSingleRandomAsDialog(entityNameTag, soundMuffledSpeak);
			singleRandomAsDialog.animationProperty = new DialogAnimationProperty(animator, "Speak", value: true);
			DialogSequenceManager.PlayDialogSequence(singleRandomAsDialog);
		}
		else
		{
			Dialog singleRandomAsDialog2 = dialogSequence.GetSingleRandomAsDialog(entityNameTag, soundNormalSpeak);
			singleRandomAsDialog2.animationProperty = new DialogAnimationProperty(animator, "Speak", value: true);
			DialogBoxComponent globalDialogBox = DialogSequenceManager.GetGlobalDialogBox();
			globalDialogBox.OnFinished = (UnityAction)Delegate.Combine(globalDialogBox.OnFinished, (UnityAction)delegate
			{
				TweenerManager.TweenTimeAction(entityNameTag.GetID() + "CasualTalk", 2f, delegate
				{
					isPlaying = false;
					if (onFinished != null)
					{
						onFinished();
					}
				});
			});
			DialogSequenceManager.PlayDialogSequence(singleRandomAsDialog2);
		}
		isPlaying = true;
		return true;
	}

	private bool PlayCasualDialogByTag(string tag, Action onFinished = null)
	{
		DialogSequence dialogSequence = DialogManager.GetSmoghDialogCasual().Find((DialogSequence x) => x.IsTag(tag));
		if (dialogSequence == null)
		{
			return false;
		}
		Dialog singleRandomAsDialog = dialogSequence.GetSingleRandomAsDialog(entityNameTag, soundNormalSpeak);
		singleRandomAsDialog.autoProceed = true;
		singleRandomAsDialog.animationProperty = new DialogAnimationProperty(animator, "Speak", value: true);
		DialogBoxComponent globalDialogBox = DialogSequenceManager.GetGlobalDialogBox();
		globalDialogBox.OnFinished = (UnityAction)Delegate.Combine(globalDialogBox.OnFinished, (UnityAction)delegate
		{
			TweenerManager.TweenTimeAction(entityNameTag.GetID() + "CasualTalk", 2f, delegate
			{
				isPlaying = false;
				animator.SetBool("Speak", value: false);
			});
		});
		if (DialogSequenceManager.PlayDialogSequence(singleRandomAsDialog))
		{
			isPlaying = true;
		}
		return true;
	}

	private void UpdateTick()
	{
		if (!TransitionManager.IsTransitioning() && !TransitionManager.IsInStateType<DarkRoomTransitionState>())
		{
			if (TutorialManager.IsRunning() && !DialogSequenceManager.GetGlobalDialogBox().isVisible && !uiInfo.IsVisible())
			{
				uiInfo.ShowPop();
			}
			if (isMuffled && muffleCounter <= 5 && !isPlaying)
			{
				PlayRandomMuffle();
			}
		}
	}

	private void Update()
	{
		if (!isMuffled && CheckLookAtRange())
		{
			LookAtPlayer();
		}
	}

	private bool CheckLookAtRange()
	{
		return lookatRange >= Vector3.Distance(base.transform.position, GlobalReferences.GetCameraController().transform.position);
	}

	private void LookAtPlayer()
	{
		Vector3 position = GlobalReferences.GetCameraController().GetCamera().transform.position;
		Vector3 vector = base.transform.position - position;
		vector.Normalize();
		Quaternion quaternion = Quaternion.LookRotation(-vector);
		Quaternion quaternion2 = Quaternion.LookRotation(-vector);
		Quaternion rotation = Quaternion.Slerp(axisYaw.rotation, new Quaternion(0f, quaternion.y, 0f, quaternion.w), lookatSpeed * Time.deltaTime);
		axisYaw.rotation = rotation;
		Quaternion localRotation = Quaternion.Slerp(axisPitch.localRotation, new Quaternion(quaternion2.x, 0f, 0f, quaternion2.w), lookatSpeed * Time.deltaTime);
		axisPitch.localRotation = localRotation;
	}
}
