using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckPodUI : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerClickHandler
{
	public Character character;

	public GameObject pod;

	public Image protectedFrame;

	public Image podBG;

	public Image selectedSleeve;

	public Text tierText;

	public Text totalCostText;

	public Text effectNameText;

	public Text effectAmountText;

	public Text rarityText;

	public int deckID;

	public void updatePod()
	{
		if (character.cardsController.invalidID(deckID))
		{
			pod.gameObject.SetActive(value: false);
			return;
		}
		pod.gameObject.SetActive(value: true);
		Card card = character.cards.cards[deckID];
		tierText.text = card.tier.ToString();
		totalCostText.text = card.manaCosts.Sum().ToString();
		effectNameText.text = character.cardsController.getShortBonusName(card.bonusType);
		effectAmountText.text = character.cardsController.cardBonusAmountDeckPod(card.effectAmount);
		rarityText.text = "<b>" + character.cardsController.getRarityColorTag(card.cardRarity) + character.cardsController.getRarityNameShort(card.cardRarity) + "</color></b>";
		if (deckID == character.cardsController.curSelectedCard)
		{
			selectedSleeve.gameObject.SetActive(value: true);
		}
		else
		{
			selectedSleeve.gameObject.SetActive(value: false);
		}
		if (card.type == cardType.end)
		{
			podBG.sprite = character.cardsController.normalDeckBG;
			protectedFrame.sprite = character.cardsController.normalProtectFrame;
			effectNameText.text = "END";
			effectAmountText.text = "END";
			if (card.isProtected)
			{
				protectedFrame.gameObject.SetActive(value: true);
			}
			else
			{
				protectedFrame.gameObject.SetActive(value: false);
			}
		}
		else if (card.cardRarity == rarity.BigChonker)
		{
			podBG.sprite = character.cardsController.chonkerDeckBG;
			protectedFrame.sprite = character.cardsController.chonkerProtectFrame;
			if (card.isProtected)
			{
				protectedFrame.gameObject.SetActive(value: true);
			}
			else
			{
				protectedFrame.gameObject.SetActive(value: false);
			}
		}
		else if (card.type == cardType.foil)
		{
			podBG.sprite = character.cardsController.foilDeckBG;
			protectedFrame.sprite = character.cardsController.foilProtectFrame;
			if (card.isProtected)
			{
				protectedFrame.gameObject.SetActive(value: true);
			}
			else
			{
				protectedFrame.gameObject.SetActive(value: false);
			}
		}
		else if (card.type == cardType.normal)
		{
			podBG.sprite = character.cardsController.normalDeckBG;
			protectedFrame.sprite = character.cardsController.normalProtectFrame;
			if (card.isProtected)
			{
				protectedFrame.gameObject.SetActive(value: true);
			}
			else
			{
				protectedFrame.gameObject.SetActive(value: false);
			}
		}
	}

	public void trySelectCard()
	{
		if (deckID >= 0 && deckID < character.cards.cards.Count)
		{
			character.cardsController.selectNewCard(deckID);
		}
	}

	public void tryProtectCard()
	{
		if (deckID >= 0 && deckID < character.cards.cards.Count)
		{
			character.cardsController.protectCard(deckID);
		}
	}

	public void tryTrashCard()
	{
		if (deckID >= 0 && deckID < character.cards.cards.Count)
		{
			character.cardsController.trashCard(deckID);
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right && eventData.button != PointerEventData.InputButton.Middle && !character.cardsController.midDrag)
		{
			character.cardsController.beginDrag = deckID;
			character.cardsController.ghost.deckID = deckID;
			character.cardsController.midDrag = true;
			character.cardsController.updateGhostPod();
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		character.cardsController.ghost.transform.position = new Vector3(Input.mousePosition.x - 6f, Input.mousePosition.y + 6f);
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right && eventData.button != PointerEventData.InputButton.Middle)
		{
			character.cardsController.endDrag = deckID;
			character.cardsController.ghost.transform.position = new Vector3(-5000f, -5000f);
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right && eventData.button != PointerEventData.InputButton.Middle)
		{
			if (character.cardsController.endDrag == -1)
			{
				character.cardsController.endDrag = deckID;
			}
			character.cardsController.swapCards();
			character.cardsController.beginDrag = -1;
			character.cardsController.endDrag = -1;
			character.cardsController.midDrag = false;
			character.cardsController.ghost.deckID = 0;
			character.cardsController.ghost.transform.position = new Vector3(-5000f, -5000f);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!character.cardsController.midDrag)
		{
			if (Input.GetKey("left shift") || Input.GetKey("right shift"))
			{
				tryProtectCard();
			}
			else if (Input.GetKey("left ctrl") || Input.GetKey("right ctrl"))
			{
				tryTrashCard();
			}
			else
			{
				trySelectCard();
			}
		}
	}
}
