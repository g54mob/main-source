using TMPro;
using UnityEngine;

namespace Michsky.DreamOS.Examples
{
	public class TicTacToe : MonoBehaviour
	{
		public TextMeshProUGUI[] cells;

		public ButtonManager[] cellButtons;

		public GameObject gameOverPanel;

		public TextMeshProUGUI gameOverText;

		private string currentPlayer;

		private string[] board;

		private bool isGameOver;

		private void Start()
		{
			currentPlayer = "X";
			board = new string[9];
			isGameOver = false;
			gameOverPanel.SetActive(value: false);
		}

		public void CellClicked(int index)
		{
			if (!isGameOver && board[index] == null)
			{
				board[index] = currentPlayer;
				cells[index].text = currentPlayer;
				cellButtons[index].Interactable(value: false);
				CheckWinConditions();
				SwitchPlayer();
			}
		}

		private void CheckWinConditions()
		{
			for (int i = 0; i <= 6; i += 3)
			{
				if (board[i] == currentPlayer && board[i + 1] == currentPlayer && board[i + 2] == currentPlayer)
				{
					GameOver(currentPlayer + " wins!");
					return;
				}
			}
			for (int j = 0; j <= 2; j++)
			{
				if (board[j] == currentPlayer && board[j + 3] == currentPlayer && board[j + 6] == currentPlayer)
				{
					GameOver(currentPlayer + " wins!");
					return;
				}
			}
			if ((board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) || (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer))
			{
				GameOver(currentPlayer + " wins!");
			}
			else if (IsBoardFull())
			{
				GameOver("Draw!");
			}
		}

		private bool IsBoardFull()
		{
			for (int i = 0; i < board.Length; i++)
			{
				if (board[i] == null)
				{
					return false;
				}
			}
			return true;
		}

		private void GameOver(string message = "")
		{
			isGameOver = true;
			gameOverPanel.SetActive(value: true);
			gameOverText.text = message;
		}

		private void SwitchPlayer()
		{
			currentPlayer = ((currentPlayer == "X") ? "O" : "X");
		}

		public void RestartGame()
		{
			isGameOver = false;
			gameOverPanel.SetActive(value: false);
			currentPlayer = "X";
			board = new string[9];
			for (int i = 0; i < cells.Length; i++)
			{
				cells[i].text = "";
			}
			for (int j = 0; j < cellButtons.Length; j++)
			{
				cellButtons[j].Interactable(value: true);
			}
		}
	}
}
