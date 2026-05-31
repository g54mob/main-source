using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T7CloudButton : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		[SerializeField]
		private Sprite _spriteRed;

		[SerializeField]
		private Sprite _spriteGreen;

		[SerializeField]
		private Sprite _spriteInactive;

		private T7CloudSequence _parent;

		public int State { get; private set; }

		private void Awake()
		{
			_parent = GetComponentInParent<T7CloudSequence>();
		}

		private void OnMouseUpAsButton()
		{
			if (_parent.PuzzleActive && State != 2)
			{
				UISounds.CraftStep();
				if (State == 1)
				{
					State = 2;
					_renderer.sprite = _spriteGreen;
					_parent.PuzzleProgress();
				}
				else
				{
					_renderer.sprite = _spriteRed;
					_parent.PuzzleFailed();
				}
			}
		}

		public void SetState(int state)
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
		}

		public void HideState()
		{
			_renderer.sprite = _spriteInactive;
		}
	}
}
