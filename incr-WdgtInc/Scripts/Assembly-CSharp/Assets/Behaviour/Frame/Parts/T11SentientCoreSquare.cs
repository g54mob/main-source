using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T11SentientCoreSquare : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _symbol;

		[SerializeField]
		private Sprite[] _sprites;

		private T11SentientCorePuzzle _parent;

		[field: SerializeField]
		public bool Interactable { get; private set; }

		public int Icon { get; private set; }

		public Color Color => _symbol.color;

		private void Start()
		{
			_parent = GetComponentInParent<T11SentientCorePuzzle>();
		}

		private void OnMouseUpAsButton()
		{
			if (Interactable)
			{
				_parent.SquareClicked(this);
			}
		}

		public void SetIcon(int i, Color c)
		{
			Icon = i;
			_symbol.sprite = _sprites[i];
			_symbol.color = c;
		}
	}
}
