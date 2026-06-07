using System.Collections;
using System.Collections.Generic;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T10AscensionMatrixPuzzle : MonoBehaviour
	{
		private Dictionary<Vector2Int, T10AscensionMatrixSquare> _squares = new Dictionary<Vector2Int, T10AscensionMatrixSquare>();

		private bool _puzzleActive;

		private ActiveWorldFrame _parent;

		private Vector2Int[][] _lines = new Vector2Int[8][]
		{
			new Vector2Int[3]
			{
				new Vector2Int(0, 0),
				new Vector2Int(0, 1),
				new Vector2Int(0, 2)
			},
			new Vector2Int[3]
			{
				new Vector2Int(1, 0),
				new Vector2Int(1, 1),
				new Vector2Int(1, 2)
			},
			new Vector2Int[3]
			{
				new Vector2Int(2, 0),
				new Vector2Int(2, 1),
				new Vector2Int(2, 2)
			},
			new Vector2Int[3]
			{
				new Vector2Int(0, 0),
				new Vector2Int(1, 0),
				new Vector2Int(2, 0)
			},
			new Vector2Int[3]
			{
				new Vector2Int(0, 1),
				new Vector2Int(1, 1),
				new Vector2Int(2, 1)
			},
			new Vector2Int[3]
			{
				new Vector2Int(0, 2),
				new Vector2Int(1, 2),
				new Vector2Int(2, 2)
			},
			new Vector2Int[3]
			{
				new Vector2Int(0, 0),
				new Vector2Int(1, 1),
				new Vector2Int(2, 2)
			},
			new Vector2Int[3]
			{
				new Vector2Int(0, 2),
				new Vector2Int(1, 1),
				new Vector2Int(2, 0)
			}
		};

		private void Awake()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			T10AscensionMatrixSquare[] componentsInChildren = GetComponentsInChildren<T10AscensionMatrixSquare>();
			foreach (T10AscensionMatrixSquare t10AscensionMatrixSquare in componentsInChildren)
			{
				_squares[t10AscensionMatrixSquare.Position] = t10AscensionMatrixSquare;
			}
		}

		private void OnEnable()
		{
			SetupPuzzle();
		}

		public void SetupPuzzle()
		{
			foreach (T10AscensionMatrixSquare value in _squares.Values)
			{
				value.SetState(0);
			}
			StartCoroutine(_tagSquareEnemy());
			_puzzleActive = true;
		}

		public void CheckPuzzleSolved(bool doEnemyMove)
		{
			int num = 0;
			Vector2Int[][] lines = _lines;
			foreach (Vector2Int[] array in lines)
			{
				int state = _squares[array[0]].State;
				if (state > 0 && _squares[array[1]].State == state && _squares[array[2]].State == state)
				{
					num = state;
					break;
				}
			}
			switch (num)
			{
			case 1:
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T10AscensionMatrixLoss");
				StartCoroutine(_resetPuzzle(1f));
				return;
			case 2:
				_parent.ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
				StartCoroutine(_resetPuzzle(0.5f));
				return;
			}
			bool flag = true;
			foreach (T10AscensionMatrixSquare value in _squares.Values)
			{
				if (value.State == 0)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T10AscensionMatrixDraw");
				StartCoroutine(_resetPuzzle(0.5f));
			}
			else if (doEnemyMove)
			{
				StartCoroutine(_tagSquareEnemy());
			}
		}

		public void TagSquarePlayer(T10AscensionMatrixSquare square)
		{
			if (_puzzleActive)
			{
				UISounds.CraftStep();
				square.SetState(2);
				CheckPuzzleSolved(doEnemyMove: true);
			}
		}

		private IEnumerator _tagSquareEnemy()
		{
			_puzzleActive = false;
			yield return new WaitForSeconds(0.2f);
			List<T10AscensionMatrixSquare> list = new List<T10AscensionMatrixSquare>(_squares.Values);
			T10AscensionMatrixSquare t10AscensionMatrixSquare = null;
			while (list.Count > 0)
			{
				t10AscensionMatrixSquare = SeededRandom.Global.Choose(list);
				if (t10AscensionMatrixSquare.State == 0)
				{
					break;
				}
				list.Remove(t10AscensionMatrixSquare);
				t10AscensionMatrixSquare = null;
			}
			if ((bool)t10AscensionMatrixSquare)
			{
				t10AscensionMatrixSquare.SetState(1);
			}
			_puzzleActive = true;
			CheckPuzzleSolved(doEnemyMove: false);
		}

		private IEnumerator _resetPuzzle(float delay)
		{
			_puzzleActive = false;
			yield return new WaitForSeconds(delay);
			SetupPuzzle();
		}
	}
}
