using System.Collections.Generic;
using Controllers;
using KitchenData;
using Sirenix.Utilities;
using UnityEngine;

namespace Kitchen.Modules
{
	public class CardScrollerElement : Element
	{
		public UnlockCardElement Card;

		public List<UnlockCardElement> CardBank = new List<UnlockCardElement>();

		public Vector3 CardViewOffsetChange;

		public GameObject Container;

		private List<ICard> Cards;

		private int Index;

		public override Bounds BoundingBox => Card.BoundingBox;

		private void MoveLeft()
		{
			SetIndex(Index - 1);
		}

		private void MoveRight()
		{
			SetIndex(Index + 1);
		}

		public void SetCardList(List<ICard> cards)
		{
			Cards = cards;
			foreach (UnlockCardElement item in CardBank)
			{
				item.Destroy();
			}
			Vector3 vector = Vector3.zero;
			foreach (ICard card in cards)
			{
				UnlockCardElement unlockCardElement = Object.Instantiate(Card, Container.transform, worldPositionStays: true);
				vector = (unlockCardElement.transform.localPosition = vector + CardViewOffsetChange);
				unlockCardElement.transform.localScale = Vector3.one;
				unlockCardElement.transform.localRotation = Quaternion.identity;
				unlockCardElement.SetUnlock(card);
				CardBank.Add(unlockCardElement);
			}
			SetIndex(0);
		}

		private void SetIndex(int index)
		{
			if (!Cards.IsNullOrEmpty())
			{
				Index = MathsHelpers.Wrap(index, 0, Cards.Count - 1);
				Card.SetUnlock(Cards[Index]);
				Vector3 zero = Vector3.zero;
				for (int i = 0; i < CardBank.Count; i++)
				{
					CardBank[i].transform.localPosition = ((i == Index) ? new Vector3(0.5f, 0f, 0f) : Vector3.zero) + (zero += CardViewOffsetChange);
				}
			}
		}

		public override bool HandleInteraction(InputState state)
		{
			if (state.MenuDown == ButtonState.Pressed)
			{
				SetIndex(Index - 1);
				return true;
			}
			if (state.MenuUp == ButtonState.Pressed)
			{
				SetIndex(Index + 1);
				return true;
			}
			return false;
		}
	}
}
