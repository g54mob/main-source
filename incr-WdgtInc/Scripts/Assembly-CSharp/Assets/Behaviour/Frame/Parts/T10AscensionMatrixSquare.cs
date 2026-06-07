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

		[SerializeField]
		private SecretButton _secret;

		private bool _secretRevealed;

		private T10AscensionMatrixPuzzle _parent;

		[field: SerializeField]
		public Vector2Int Position { get; private set; }

		public int State { get; private set; }

		private void Start()
		{
			_parent = GetComponentInParent<T10AscensionMatrixPuzzle>();
			if ((bool)_secret)
			{
				_secret.SetActive(active: false);
			}
		}

		public void SetState(int state)
		{
			State = state;
			_renderer.enabled = state != 0;
			_renderer.sprite = ((state == 1) ? _spriteCross : _spriteNaught);
		}

		private void OnMouseDrag()
		{
			if ((bool)_secret && State == 1)
			{
				Vector2 mouseWorld = PlayerControls.MouseWorld;
				base.transform.position = new Vector3(mouseWorld.x, mouseWorld.y, base.transform.position.z);
				if (!_secretRevealed && Vector2.Distance(_secret.transform.position, base.transform.position) > 2f)
				{
					_secret.SetActive(active: true);
					UISounds.CraftFinished();
					_secretRevealed = true;
				}
			}
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
