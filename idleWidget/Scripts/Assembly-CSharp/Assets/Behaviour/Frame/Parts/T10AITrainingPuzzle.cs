using System;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T10AITrainingPuzzle : MonoBehaviour
	{
		private ActiveWorldFrame _parent;

		private float _nextButton;

		private T10AITrainingButton[] _buttons;

		private int _streak;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			_buttons = GetComponentsInChildren<T10AITrainingButton>();
			_nextButton = 1f;
		}

		private void Update()
		{
			_nextButton -= Time.deltaTime;
			if (_nextButton < 0f)
			{
				T10AITrainingButton t10AITrainingButton = SeededRandom.Global.Choose(_buttons);
				if (t10AITrainingButton.State == 0)
				{
					float num = Mathf.Pow(0.9f, _streak);
					t10AITrainingButton.SetState(1, SeededRandom.Global.RandomRange(2f, 4f) * num);
					_nextButton = SeededRandom.Global.RandomRange(1f, 2f) * num;
				}
			}
		}

		public void Punishment()
		{
			_streak = 0;
			_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Sequence interrupted!");
			_nextButton = Mathf.Min(5f, _nextButton + 1f);
		}

		public void ButtonClicked()
		{
			_streak++;
			_parent.ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
		}

		public void ButtonMissed()
		{
			_streak = Math.Max(_streak - 1, 0);
		}
	}
}
