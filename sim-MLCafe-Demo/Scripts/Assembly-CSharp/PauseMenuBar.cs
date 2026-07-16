using Codecks.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuBar : MonoBehaviour
{
	[SerializeField]
	private GraphicRaycaster graphicRaycaster;

	[SerializeField]
	private UIContentAnimator animator;

	[SerializeField]
	private UIContentAnimator animatorCodecksPanel;

	[SerializeField]
	private UIContentAnimator animatorOptionsPanel;

	[SerializeField]
	private OptionsMenu optionsMenu;

	[SerializeField]
	private CodecksCardCreatorForm codecksForm;

	private bool isOpen;

	private bool subMenuOpen;

	private void Start()
	{
		InputManager.OnOpenSettingsWindow.AddListener(OpenMenuBar);
		InputManager.OnCancelMenuWindow.AddListener(CloseMenuBar);
		codecksForm.HideCodecksForm();
		optionsMenu.HideOptionsMenu();
		animator.OnFinishedReverse.AddListener(delegate
		{
			if (!subMenuOpen)
			{
				isOpen = false;
			}
		});
	}

	public bool IsVisible()
	{
		return isOpen;
	}

	public void OpenMenuBar()
	{
		if (!isOpen && !animator.ValidFromReverse())
		{
			isOpen = true;
			GameStateManager.ChangeGameState(GameStateManager.GameState.GamePaused);
			GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
			WorldTime.PauseGame();
			graphicRaycaster.enabled = true;
			animator.OnPlay();
		}
	}

	public void CloseMenuBar()
	{
		if (subMenuOpen)
		{
			CloseAnySubMenu();
		}
		if (isOpen && !animator.ValidFromPlay())
		{
			WorldTime.ResumeGame();
			graphicRaycaster.enabled = false;
			GameStateManager.ChangeGameState(GameStateManager.GameState.GameRunning);
			GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.CharacterMode);
			animator.OnReverse();
		}
	}

	public void CloseAnySubMenu()
	{
		CloseCodecksFeedbackPanel();
		CloseOptionsPanel();
		subMenuOpen = false;
	}

	public void ResetPosition()
	{
		Vector3 position = GlobalReferences.GetResetPositionArea().transform.position;
		GlobalReferences.GetCharacterController().SetPosition(position);
	}

	public void OnReturnToMainMenu()
	{
		WorldTime.ResumeGame();
		GameManager.ReturnToMenu();
	}

	public void OnExitGame()
	{
		Application.Quit();
	}

	private void ReOpenBar()
	{
		animator.OnPlay();
	}

	private void CloseBarForSubPanel()
	{
		animator.OnReverse();
	}

	public void OpenOptionsPanel()
	{
		if (!(animatorOptionsPanel == null))
		{
			CloseBarForSubPanel();
			optionsMenu.ShowOptionsMenu();
			animatorOptionsPanel.OnPlay();
			subMenuOpen = true;
		}
	}

	public void CloseOptionsPanel()
	{
		if (!(animatorOptionsPanel == null))
		{
			ReOpenBar();
			animatorOptionsPanel.OnReverse();
		}
	}

	public void OpenCodecksFeedbackPanel()
	{
		if (!(codecksForm == null) && !(animatorCodecksPanel == null))
		{
			codecksForm.ShowCodecksForm();
			CloseBarForSubPanel();
			animatorCodecksPanel.OnPlay();
			subMenuOpen = true;
		}
	}

	public void CloseCodecksFeedbackPanel()
	{
		if (!(codecksForm == null) && !(animatorCodecksPanel == null))
		{
			ReOpenBar();
			animatorCodecksPanel.OnReverse();
		}
	}
}
