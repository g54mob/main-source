using System.Collections;
using System.Collections.Generic;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T11SentientCorePuzzle : MonoBehaviour
	{
		[SerializeField]
		private Color[] _colors;

		[SerializeField]
		private List<T11SentientCoreSquare> _exampleSquares;

		[SerializeField]
		private List<T11SentientCoreSquare> _activeSquares;

		private int _idx;

		private ActiveWorldFrame _parent;

		private bool _puzzleActive;

		private void Awake()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void OnEnable()
		{
			SetupPuzzle();
		}

		public void SquareClicked(T11SentientCoreSquare square)
		{
			if (!_puzzleActive)
			{
				return;
			}
			UISounds.CraftStep();
			if (square.Icon == _exampleSquares[_idx].Icon)
			{
				square.SetIcon(square.Icon, _exampleSquares[_idx].Color);
				_idx++;
				if (_idx > 3)
				{
					StartCoroutine(_doPuzzleSolved());
				}
			}
			else
			{
				StartCoroutine(_doPuzzleFailed());
			}
		}

		private IEnumerator _doPuzzleFailed()
		{
			_puzzleActive = false;
			_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Incorrect sequence!");
			yield return new WaitForSeconds(1f);
			SetupPuzzle();
		}

		private IEnumerator _doPuzzleSolved()
		{
			_puzzleActive = false;
			_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			yield return new WaitForSeconds(0.5f);
			SetupPuzzle();
		}

		public void SetupPuzzle()
		{
			_idx = 0;
			List<int> list = new List<int> { 0, 1, 2, 3 };
			List<int> list2 = new List<int> { 0, 1, 2, 3 };
			List<Color> list3 = new List<Color>(_colors);
			SeededRandom.Global.Shuffle(list);
			SeededRandom.Global.Shuffle(list2);
			SeededRandom.Global.Shuffle(list3);
			for (int i = 0; i < 4; i++)
			{
				_exampleSquares[i].SetIcon(list[i], list3[i]);
				_activeSquares[i].SetIcon(list2[i], new Color(0.8f, 0.8f, 0.8f));
			}
			_puzzleActive = true;
		}
	}
}
