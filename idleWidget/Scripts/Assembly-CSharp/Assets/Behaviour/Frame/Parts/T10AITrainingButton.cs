using System.Collections;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T10AITrainingButton : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		[SerializeField]
		private Sprite _spriteRed;

		[SerializeField]
		private Sprite _spriteGreen;

		[SerializeField]
		private Sprite _spriteInactive;

		private T10AITrainingPuzzle _parent;

		private float _activeTimer;

		public int State { get; private set; }

		private void Awake()
		{
			_parent = GetComponentInParent<T10AITrainingPuzzle>();
		}

		private void Update()
		{
			if (State == 1)
			{
				_activeTimer -= Time.deltaTime;
				if (_activeTimer < 0f)
				{
					SetState(0);
					_parent.ButtonMissed();
				}
			}
		}

		private void OnMouseUpAsButton()
		{
			if (State == 0)
			{
				UISounds.CraftStep();
				_parent.Punishment();
			}
			else if (State == 1)
			{
				UISounds.CraftStep();
				_parent.ButtonClicked();
				StartCoroutine(_buttonClicked());
			}
		}

		private IEnumerator _buttonClicked()
		{
			SetState(2);
			yield return new WaitForSeconds(1f);
			SetState(0);
		}

		public void SetState(int state, float timer = 0f)
		{
			State = state;
			switch (state)
			{
			case 0:
				_renderer.sprite = _spriteInactive;
				break;
			case 1:
				_renderer.sprite = _spriteRed;
				break;
			case 2:
				_renderer.sprite = _spriteGreen;
				break;
			}
			_activeTimer = timer;
		}
	}
}
