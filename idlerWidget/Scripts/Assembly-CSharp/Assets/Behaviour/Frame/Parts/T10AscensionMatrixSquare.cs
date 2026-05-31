using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T10AscensionMatrixSquare : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		[SerializeField]
		private Sprite _spriteCross;

		[SerializeField]
		private Sprite _spriteNaught;

		private T10AscensionMatrixPuzzle _parent;

		[field: SerializeField]
		public Vector2Int Position { get; private set; }

		public int State { get; private set; }

		private void Start()
		{
			_parent = GetComponentInParent<T10AscensionMatrixPuzzle>();
		}

		public void SetState(int state)
		{
			State = state;
			_renderer.enabled = state != 0;
			_renderer.sprite = ((state == 1) ? _spriteCross : _spriteNaught);
		}

		private void OnMouseUpAsButton()
		{
			if (State == 0)
			{
				_parent.TagSquarePlayer(this);
			}
		}
	}
}
