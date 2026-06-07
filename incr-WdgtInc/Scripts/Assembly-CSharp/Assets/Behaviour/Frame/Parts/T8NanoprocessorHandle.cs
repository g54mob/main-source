using System.Collections;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T8NanoprocessorHandle : MonoBehaviour
	{
		[SerializeField]
		private float _speed;

		private ActiveWorldFrame _parent;

		private Vector2Int _current;

		private Vector2Int _target;

		private Vector3 _currentV3;

		private Vector3 _targetV3;

		private bool _puzzleActive;

		private bool _mouseOver;

		private void OnEnable()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			_target = new Vector2Int(3, -3);
			SetupPuzzle();
		}

		public void SetupPuzzle()
		{
			Vector2Int current = _current;
			_current = _target;
			_currentV3 = new Vector3(_current.x, _current.y, -0.5f);
			base.transform.localPosition = _currentV3;
			do
			{
				if (SeededRandom.Global.RandomBool())
				{
					int num = 3 * (SeededRandom.Global.RandomBool() ? 1 : (-1));
					int num2 = _current.x + num;
					if (num2 < 0 || num2 > 6)
					{
						num2 = _current.x - num;
					}
					_target = new Vector2Int(num2, _current.y);
				}
				else
				{
					int num3 = 3 * (SeededRandom.Global.RandomBool() ? 1 : (-1));
					int num4 = _current.y + num3;
					if (num4 > 0 || num4 < -6)
					{
						num4 = _current.y - num3;
					}
					_target = new Vector2Int(_current.x, num4);
				}
			}
			while (_target == current);
			_targetV3 = new Vector3(_target.x, _target.y, -0.5f);
		}

		private IEnumerator MovePuzzle()
		{
			_puzzleActive = true;
			float progress = 0f;
			while (progress < 1f && _puzzleActive)
			{
				progress += Time.deltaTime * _speed;
				if (progress >= 1f)
				{
					_parent.ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
					SetupPuzzle();
					if (_puzzleActive)
					{
						_puzzleActive = false;
						yield return new WaitForSeconds(0.5f);
						if (!_puzzleActive && _mouseOver)
						{
							StartCoroutine(MovePuzzle());
						}
					}
				}
				else
				{
					base.transform.localPosition = Vector3.Lerp(_currentV3, _targetV3, progress);
					yield return null;
				}
			}
		}

		private void OnMouseDown()
		{
			_mouseOver = true;
			if (!(_parent.ActiveFrame as T8Nanoprocessor).GetManualCrafter(0).Active)
			{
				UISounds.CraftStep();
				StartCoroutine(MovePuzzle());
			}
		}

		private void OnMouseUp()
		{
			if (_puzzleActive)
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T8NanoprocessorInterrupted");
				_resetPuzzle();
			}
			_mouseOver = false;
		}

		private void OnMouseExit()
		{
			if (_puzzleActive)
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T8NanoprocessorWarning");
				_resetPuzzle();
			}
			_mouseOver = false;
		}

		private void _resetPuzzle()
		{
			_puzzleActive = false;
			base.transform.localPosition = _currentV3;
		}
	}
}
