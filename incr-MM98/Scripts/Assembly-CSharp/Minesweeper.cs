using System;
using Cysharp.Text;
using MessagePipe;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Minesweeper : MonoBehaviour
{
	[SerializeField]
	private MinesweeperPopup popup;

	[SerializeField]
	private Button restartButton;

	[SerializeField]
	private TMP_Text minecounterText;

	[SerializeField]
	private AudioDataType bombExplosionSfx;

	[SerializeField]
	private AudioDataType flagPlacementSfx;

	[SerializeField]
	private AudioDataType victorySfx;

	private MineBoard _board;

	private CellVisualizer[,] _cells;

	private void Start()
	{
		StartGame();
		EventHub.Scene.For().Subscribe(HandleCellReveal, (MinesweeperRevealed _) => IsInProgress()).Subscribe(HandleCellFlagged, (MinesweeperFlagged _) => IsInProgress())
			.Subscribe(delegate
			{
				StartGame();
			}, Array.Empty<MessageHandlerFilter<MinesweeperRestarted>>())
			.Build(this);
	}

	private bool IsInProgress()
	{
		return _board.CurrentState == MineBoard.State.Playing;
	}

	private void StartGame()
	{
		MinesweeperDifficultyPreset currentPreset = popup.CurrentPreset;
		popup.CreateBoard(currentPreset.Size, currentPreset.MineCount, out _board, out _cells);
		UpdateMineCounter();
	}

	private void HandleCellReveal(MinesweeperRevealed ctx)
	{
		foreach (Vector2Int item in _board.RevealCell(ctx.Position))
		{
			_cells[item.x, item.y].RefreshVisual();
		}
		UpdateMineCounter();
		if (_board.CurrentState == MineBoard.State.Won)
		{
			HandleWin();
		}
		else if (_board.CurrentState == MineBoard.State.Lost)
		{
			HandleLoss();
		}
	}

	private void HandleCellFlagged(MinesweeperFlagged ctx)
	{
		_board.ToggleFlag(ctx.Position);
		Audio.PlaySfx(flagPlacementSfx);
		_cells[ctx.Position.x, ctx.Position.y].RefreshVisual();
		UpdateMineCounter();
	}

	private void UpdateMineCounter()
	{
		if (_board.RemainingMines < 0)
		{
			minecounterText.SetTextFormat("-{0:00}", Math.Abs(_board.RemainingMines));
		}
		else
		{
			minecounterText.SetTextFormat("{0:000}", _board.RemainingMines);
		}
	}

	private void HandleWin()
	{
		Audio.PlaySfx(victorySfx);
		RevealAllCells();
		switch (popup.CurrentDifficulty)
		{
		case MinesweeperDifficulty.Beginner:
			Database.State.Metrics.BombdusterEasyWins.Increment();
			break;
		case MinesweeperDifficulty.Advanced:
			Database.State.Metrics.BombdusterAdvancedWins.Increment();
			break;
		case MinesweeperDifficulty.Expert:
			Database.State.Metrics.BombdusterExpertWins.Increment();
			break;
		}
		EventHub.Scene.Publish(new MinesweeperFinished(won: true));
	}

	private void HandleLoss()
	{
		Audio.PlaySfx(bombExplosionSfx);
		RevealAllCells();
		EventHub.Scene.Publish(new MinesweeperFinished(won: false));
	}

	private void RevealAllCells()
	{
		Vector2Int size = popup.CurrentPreset.Size;
		for (int i = 0; i < size.x; i++)
		{
			for (int j = 0; j < size.y; j++)
			{
				_board.GetCell(i, j).Reveal(force: true);
				_cells[i, j].RefreshVisual();
			}
		}
	}
}
