using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;

namespace Aggro.Core
{
	public class Deck<T>
	{
		public struct InfiniteScope : IDisposable
		{
			public Deck<T> deck;

			public void Dispose()
			{
				deck.EndInfiniteCheck();
			}
		}

		private List<T> _cards = new List<T>();

		private int _nextIndex;

		private bool _canDestroyLastCard;

		private Unity.Mathematics.Random _random;

		private int _infiniteShuffleLimit = -1;

		public static readonly Deck<T> EMPTY_DECK = new Deck<T>(1);

		public int shuffleGeneration { get; private set; }

		public int cardCount => _cards.Count;

		public T this[int index] => _cards[index];

		private Deck()
		{
		}

		public Deck(int seed)
		{
			_random = MathUtil.GetRandom(seed);
		}

		public Deck<T> CreateCopy()
		{
			Deck<T> deck = new Deck<T>();
			deck._cards.AddRangeNoGarbage(_cards);
			deck._nextIndex = _nextIndex;
			deck._canDestroyLastCard = _canDestroyLastCard;
			deck._random = _random;
			deck._infiniteShuffleLimit = _infiniteShuffleLimit;
			deck.shuffleGeneration = shuffleGeneration;
			return deck;
		}

		public void AddCard(T card)
		{
			_cards.Add(card);
		}

		public void AddCard(T card, int count)
		{
			for (int i = 0; i < count; i++)
			{
				_cards.Add(card);
			}
		}

		public void AddCard(DeckCard<T> card)
		{
			AddCard(card.item, card.cardCount);
		}

		public void AddCards(IList<T> cards)
		{
			_cards.AddRangeNoGarbage(cards);
		}

		public void AddCards(IList<DeckCard<T>> cards)
		{
			for (int i = 0; i < cards.Count; i++)
			{
				AddCard(cards[i]);
			}
		}

		public T DrawCard()
		{
			if (_infiniteShuffleLimit >= 0 && shuffleGeneration >= _infiniteShuffleLimit)
			{
				throw new InfiniteLoopException();
			}
			if (_cards.Count == 0)
			{
				shuffleGeneration++;
				return default(T);
			}
			if (_nextIndex >= _cards.Count)
			{
				Shuffle();
			}
			_canDestroyLastCard = true;
			return _cards[_nextIndex++];
		}

		public void Shuffle()
		{
			_cards.Randomize(_random.NextInt());
			_nextIndex = 0;
			_canDestroyLastCard = false;
			shuffleGeneration++;
		}

		public void DestroyLastCard()
		{
			if (_canDestroyLastCard)
			{
				_canDestroyLastCard = false;
				_nextIndex--;
				_cards.RemoveAtSwapBack(_nextIndex);
			}
		}

		public void RemoveCardAt(int index)
		{
			_cards.RemoveAt(index);
		}

		public void RemoveCard(T item)
		{
			_cards.Remove(item);
		}

		public void RemoveCardAtSwapBack(int index)
		{
			_cards.RemoveAtSwapBack(index);
		}

		public void InsertCardAt(int index, T card)
		{
			_cards.Insert(index, card);
		}

		public void BeginInfiniteCheck()
		{
			if (_infiniteShuffleLimit < 0)
			{
				_infiniteShuffleLimit = shuffleGeneration + 2;
			}
		}

		public void EndInfiniteCheck()
		{
			_infiniteShuffleLimit = -1;
		}

		public InfiniteScope InfiniteDetection()
		{
			BeginInfiniteCheck();
			return new InfiniteScope
			{
				deck = this
			};
		}

		public void GetCards(List<T> cards)
		{
			cards.AddRangeNoGarbage(_cards);
		}

		public DeckCard<T>[] GetCards()
		{
			Dictionary<T, int> dictionary = new Dictionary<T, int>();
			for (int i = 0; i < _cards.Count; i++)
			{
				T key = _cards[i];
				dictionary.TryGetValue(key, out var value);
				dictionary[key] = value + 1;
			}
			List<DeckCard<T>> list = new List<DeckCard<T>>();
			foreach (KeyValuePair<T, int> item in dictionary)
			{
				DeckCard<T> deckCard = new DeckCard<T>();
				deckCard.item = item.Key;
				deckCard.cardCount = item.Value;
				list.Add(deckCard);
			}
			return list.ToArray();
		}

		public void Clear()
		{
			_cards.Clear();
		}

		public override string ToString()
		{
			return $"Count: {_cards.Count}";
		}
	}
}
