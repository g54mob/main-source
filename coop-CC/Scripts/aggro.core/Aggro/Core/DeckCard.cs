using System;
using UnityEngine;

namespace Aggro.Core
{
	[Serializable]
	public class DeckCard<T>
	{
		public T item;

		[Min(1f)]
		public int cardCount = 1;

		public override string ToString()
		{
			return $"Count: {cardCount}";
		}
	}
}
