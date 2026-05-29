using System.Collections;
using System.Collections.Generic;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T11SentientWidgetPuzzle : MonoBehaviour
	{
		[SerializeField]
		private T11SentientWidgetSquare _squarePrefab;

		[SerializeField]
		private Transform _squareParent;

		public T11SentientWidgetSquare _flippedCard;

		private int _flippingCount;

		private ActiveWorldFrame _parent;

		private List<T11SentientWidgetSquare> _cards = new List<T11SentientWidgetSquare>();

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void OnEnable()
		{
			SetupPuzzle();
		}

		public void SetupPuzzle()
		{
			_squareParent.DestroyChildren();
			_cards.Clear();
			List<int> list = new List<int>
			{
				0, 0, 1, 1, 2, 2, 3, 3, 4, 4,
				5, 5, 6, 6, 7, 7
			};
			SeededRandom.Global.Shuffle(list);
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					T11SentientWidgetSquare t11SentientWidgetSquare = Object.Instantiate(_squarePrefab, _squareParent);
					t11SentientWidgetSquare.transform.localPosition = new Vector3(i * 3, (float)j * -2.4f, 0f);
					t11SentientWidgetSquare.SetCard(list[0]);
					list.RemoveAt(0);
					_cards.Add(t11SentientWidgetSquare);
				}
			}
		}

		public bool CanFlip(T11SentientWidgetSquare card)
		{
			return _flippingCount < 2;
		}

		public void DoFlip(T11SentientWidgetSquare card)
		{
			_flippingCount++;
			if (_flippedCard == null)
			{
				_flippedCard = card;
			}
			else if (_flippedCard.Card == card.Card)
			{
				StartCoroutine(finishFlips(_flippedCard, card));
			}
			else
			{
				StartCoroutine(reverseFlips(_flippedCard, card));
			}
		}

		private IEnumerator reverseFlips(T11SentientWidgetSquare c1, T11SentientWidgetSquare c2)
		{
			yield return new WaitForSeconds(1f);
			c1.DoFlip();
			c2.DoFlip();
			_flippingCount = 0;
			_flippedCard = null;
		}

		private IEnumerator finishFlips(T11SentientWidgetSquare c1, T11SentientWidgetSquare c2)
		{
			yield return new WaitForSeconds(0.5f);
			_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			_flippingCount = 0;
			_flippedCard = null;
			foreach (T11SentientWidgetSquare card in _cards)
			{
				if (!card.FaceUp)
				{
					yield break;
				}
			}
			foreach (T11SentientWidgetSquare card2 in _cards)
			{
				card2.DoFlip();
			}
			yield return new WaitForSeconds(0.5f);
			SetupPuzzle();
		}
	}
}
