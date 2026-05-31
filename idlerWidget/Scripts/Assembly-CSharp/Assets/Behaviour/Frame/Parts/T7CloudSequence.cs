using System.Collections;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T7CloudSequence : MonoBehaviour
	{
		[SerializeField]
		private T7CloudButton[] _buttons;

		public bool PuzzleActive;

		private ActiveWorldFrame _parent;

		private void OnEnable()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			SetupPuzzle();
		}

		public void SetupPuzzle()
		{
			PuzzleActive = true;
			T7CloudButton[] buttons = _buttons;
			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i].SetState(0);
			}
			for (int j = 0; j < 4; j++)
			{
				SeededRandom.Global.Choose(_buttons).SetState(1);
			}
		}

		public void PuzzleFailed()
		{
			StartCoroutine(_puzzleFailed());
		}

		private IEnumerator _puzzleFailed()
		{
			PuzzleActive = false;
			_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Sequence mismatch!");
			yield return new WaitForSeconds(1f);
			SetupPuzzle();
		}

		public void PuzzleProgress()
		{
			bool flag = true;
			T7CloudButton[] buttons = _buttons;
			foreach (T7CloudButton t7CloudButton in buttons)
			{
				if (t7CloudButton.State == 1)
				{
					t7CloudButton.HideState();
					flag = false;
				}
			}
			if (flag)
			{
				StartCoroutine(_puzzleFinished());
			}
		}

		private IEnumerator _puzzleFinished()
		{
			PuzzleActive = false;
			_parent.ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			yield return new WaitForSeconds(1f);
			SetupPuzzle();
		}
	}
}
