using System.Collections;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12RocketElectronicsPuzzle : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _0Prefab;

		[SerializeField]
		private SpriteRenderer _1Prefab;

		[SerializeField]
		private Transform _numbersParent;

		private SpriteRenderer[] _numbers;

		private bool[] _solution;

		private int _solutionIndex;

		private ActiveWorldFrame _parent;

		private bool _resetting;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			SetupPuzzle();
		}

		public void SetupPuzzle()
		{
			_solutionIndex = 0;
			_numbersParent.DestroyChildren();
			_numbers = new SpriteRenderer[8];
			_solution = new bool[8];
			for (int i = 0; i < 8; i++)
			{
				bool flag = SeededRandom.Global.RandomBool();
				_solution[i] = flag;
				_numbers[i] = Object.Instantiate(flag ? _1Prefab : _0Prefab, _numbersParent);
				_numbers[i].transform.localPosition = new Vector3(i, 0f, 0f);
			}
		}

		public void ButtonClicked(bool val)
		{
			if (_resetting)
			{
				return;
			}
			UISounds.CraftStep();
			if (_solution[_solutionIndex] == val)
			{
				_numbers[_solutionIndex].color = Color.red;
				_solutionIndex++;
				if (_solutionIndex == 8)
				{
					_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
					StartCoroutine(_resetPuzzle());
				}
			}
			else
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Input sequence mismatch!");
				StartCoroutine(_resetPuzzle());
			}
		}

		public IEnumerator _resetPuzzle()
		{
			_resetting = true;
			yield return new WaitForSeconds(1f);
			SetupPuzzle();
			_resetting = false;
		}
	}
}
