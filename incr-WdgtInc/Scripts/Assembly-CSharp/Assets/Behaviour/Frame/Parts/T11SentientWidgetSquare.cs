using System.Collections;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T11SentientWidgetSquare : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _background;

		[SerializeField]
		private SpriteRenderer _icon;

		[SerializeField]
		private Sprite _cardBack;

		[SerializeField]
		private Sprite _cardFront;

		[SerializeField]
		private Sprite[] _cardSprites;

		private bool _interactable;

		private T11SentientWidgetPuzzle _parent;

		public int Card { get; private set; }

		public bool FaceUp { get; private set; }

		private void Start()
		{
			_parent = GetComponentInParent<T11SentientWidgetPuzzle>();
		}

		public void SetCard(int card)
		{
			Card = card;
			_icon.sprite = _cardSprites[card];
			_icon.enabled = false;
			_background.sprite = _cardBack;
			base.transform.localScale = Vector3.one;
			_interactable = true;
			FaceUp = false;
		}

		private void OnMouseUpAsButton()
		{
			if (_interactable && !FaceUp && _parent.CanFlip(this))
			{
				UISounds.CraftStep();
				_parent.DoFlip(this);
				DoFlip();
			}
		}

		public void DoFlip()
		{
			StartCoroutine(_flipCard());
		}

		private IEnumerator _flipCard()
		{
			_interactable = false;
			float flipProgress = 0f;
			while (flipProgress < 1f)
			{
				flipProgress += Time.deltaTime * 8f;
				base.transform.localScale = new Vector3(1f - flipProgress, 1f, 1f);
				yield return null;
			}
			FaceUp = !FaceUp;
			_background.sprite = (FaceUp ? _cardFront : _cardBack);
			_icon.enabled = FaceUp;
			flipProgress = 0f;
			while (flipProgress < 1f)
			{
				flipProgress += Time.deltaTime * 8f;
				base.transform.localScale = new Vector3(flipProgress, 1f, 1f);
				yield return null;
			}
			base.transform.localScale = Vector3.one;
			if (!FaceUp)
			{
				_interactable = true;
			}
		}
	}
}
