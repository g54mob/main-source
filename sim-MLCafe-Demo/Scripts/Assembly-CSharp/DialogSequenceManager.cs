using UnityEngine;

public class DialogSequenceManager : MonoBehaviour
{
	[SerializeField]
	private DialogBoxComponent globalDialogComponent;

	private static DialogSequenceManager instance;

	public static DialogBoxComponent GetGlobalDialogBox()
	{
		return instance.globalDialogComponent;
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Object.Destroy(instance);
		}
	}

	private void Start()
	{
		if (GameStateManager.GetCurrentGameState() == GameStateManager.GameState.TitleScreen)
		{
			return;
		}
		InputManager.OnCancleDialog.AddListener(delegate
		{
			if (TransitionManager.IsInStateType<DarkRoomTransitionState>())
			{
				if (globalDialogComponent.isVisible)
				{
					globalDialogComponent.PauseDialog();
				}
				else
				{
					globalDialogComponent.ContinueDialog();
				}
			}
			else
			{
				globalDialogComponent.StopDialog();
			}
		});
	}

	public static bool PlayDialogSequence(Dialog dialog, DialogBoxComponent targetDialogBox = null)
	{
		if (targetDialogBox == null)
		{
			targetDialogBox = GetGlobalDialogBox();
		}
		targetDialogBox.ValidateSentences();
		if (DialogManager.IsAnimationActivated() && targetDialogBox.IsPlayingTextAnimation() && !dialog.autoProceed)
		{
			targetDialogBox.StopDialogAnimation();
			return false;
		}
		if (!DialogManager.IsAutoplayActive() && targetDialogBox.IsPlaying())
		{
			targetDialogBox.DisplayNextSentence();
			return false;
		}
		if (DialogManager.IsAutoplayActive() && targetDialogBox.IsPlaying())
		{
			targetDialogBox.DisplayNextSentence();
			return false;
		}
		return targetDialogBox.PlayDialog(dialog);
	}
}
