using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopHintComponent : MonoBehaviour
{
	[SerializeField]
	private UIContentAnimator animator;

	[SerializeField]
	private Transform content;

	[SerializeField]
	private HintBoxLibrary hintBoxLibrary;

	[SerializeField]
	private GraphicRaycaster graphicRaycaster;

	private List<HintBox> hintBoxes = new List<HintBox>();

	private GameObject activeHintBox;

	private GameStateManager.CharacterState incomingCharacterState;

	private bool IsDisabled;

	private void Start()
	{
		hintBoxes = hintBoxLibrary.GetCopy();
		animator.BeginWithNormalState();
		animator.OnFinishedReverse.AddListener(Clear);
		InputManager.OnCancelMenuWindow.AddListener(Hide);
	}

	public List<HintBox> GetHintBoxes()
	{
		return hintBoxes;
	}

	public HintBox GetHintBoxByTag(string tag)
	{
		return hintBoxes.Find((HintBox x) => x.hintBoxTag.ToLower() == tag.ToLower());
	}

	public void EnableHints()
	{
		IsDisabled = false;
	}

	public void DisableHints()
	{
		IsDisabled = true;
	}

	public bool TryShow(HintBox hintBox)
	{
		Clear();
		if (IsDisabled)
		{
			return false;
		}
		if (hintBox == null || hintBox.shown)
		{
			return false;
		}
		activeHintBox = hintBox.SpawnBox(content);
		animator.OnPlay();
		graphicRaycaster.enabled = true;
		incomingCharacterState = GameStateManager.GetCurrentCharacterState();
		WorldTime.PauseGame();
		if (GameStateManager.GetCurrentGameState() != GameStateManager.GameState.GamePaused)
		{
			GameStateManager.ChangeGameState(GameStateManager.GameState.GamePaused);
		}
		if (GameStateManager.GetCurrentCharacterState() != GameStateManager.CharacterState.MenuOpen)
		{
			GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
		}
		return true;
	}

	public void Hide()
	{
		animator.OnReverse();
		if (graphicRaycaster.enabled && !Object.FindFirstObjectByType<PauseMenuBar>().IsVisible())
		{
			graphicRaycaster.enabled = false;
		}
		WorldTime.ResumeGame();
		if (GameStateManager.GetCurrentGameState() == GameStateManager.GameState.GamePaused)
		{
			GameStateManager.ChangeGameState(GameStateManager.GameState.GameRunning);
			GameStateManager.ChangeCharacterState(incomingCharacterState);
		}
	}

	private void Clear()
	{
		if (!(activeHintBox == null))
		{
			Object.Destroy(activeHintBox);
		}
	}
}
