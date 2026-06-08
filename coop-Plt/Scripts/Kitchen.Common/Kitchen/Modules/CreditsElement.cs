using System.Collections.Generic;
using Kitchen.Modules.Data;
using UnityEngine;

namespace Kitchen.Modules
{
	public class CreditsElement : LabelElement
	{
		public List<GameCredit> Credits = new List<GameCredit>();

		public int CreditIndex;

		public float ZOffset = -0.15f;

		public Animator CreditAnimator;

		public Transform CardContainer;

		public Transform MovingCardContainer;

		public UnlockCardElement CurrentlyMovingCard;

		private List<UnlockCardElement> UnlockCards = new List<UnlockCardElement>();

		public override void Initialise()
		{
			base.Initialise();
			float num = (float)Credits.Count * ZOffset;
			foreach (GameCredit credit in Credits)
			{
				UnlockCardElement unlockCardElement = Add<UnlockCardElement>();
				SetCardDetail(unlockCardElement, credit);
				Transform obj = unlockCardElement.transform;
				obj.parent = CardContainer;
				obj.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-5, 5));
				obj.localPosition = new Vector3(0f, 0f, num -= ZOffset);
				UnlockCards.Add(unlockCardElement);
			}
		}

		public void MoveNextCard()
		{
			if (CurrentlyMovingCard != null)
			{
				CurrentlyMovingCard.transform.parent = CardContainer;
			}
			if (CreditIndex >= UnlockCards.Count)
			{
				CreditAnimator.Play("MoveCardReverse", 0, 0f);
				CreditAnimator.Update(0.01f);
				return;
			}
			if (CreditIndex < 0)
			{
				CreditIndex = 0;
			}
			CreditAnimator.Play("MoveCard", 0, 0f);
			CreditAnimator.Update(0.01f);
			CurrentlyMovingCard = UnlockCards[CreditIndex++];
			Transform obj = CurrentlyMovingCard.transform;
			obj.parent = MovingCardContainer;
			Vector3 localPosition = obj.localPosition;
			localPosition.z = (float)Credits.Count * ZOffset + (float)CreditIndex * ZOffset;
			obj.localPosition = localPosition;
		}

		public void MoveNextCardReverse()
		{
			if (CurrentlyMovingCard != null)
			{
				Transform obj = CurrentlyMovingCard.transform;
				obj.parent = CardContainer;
				Vector3 localPosition = obj.localPosition;
				localPosition.z = (float)Credits.Count * ZOffset - (float)CreditIndex * ZOffset;
				obj.localPosition = localPosition;
			}
			if (CreditIndex < 0)
			{
				CreditAnimator.Play("MoveCard", 0, 0f);
				CreditAnimator.Update(0.01f);
				return;
			}
			if (CreditIndex >= UnlockCards.Count)
			{
				CreditIndex = UnlockCards.Count - 1;
			}
			CreditAnimator.Play("MoveCardReverse", 0, 0f);
			CreditAnimator.Update(0.01f);
			CurrentlyMovingCard = UnlockCards[CreditIndex--];
			CurrentlyMovingCard.transform.parent = MovingCardContainer;
		}

		private void SetCardDetail(UnlockCardElement card, GameCredit credit)
		{
			card.SetText("<sprite name=\"" + credit.Icon + "\">", "<align=left>" + credit.FirstName + "\n" + credit.SecondName, "<align=center>" + credit.Title + "</align>", "<align=center>" + credit.Affiliation + "</align>", credit.Colour);
		}
	}
}
