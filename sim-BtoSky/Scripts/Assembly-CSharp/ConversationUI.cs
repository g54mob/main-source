using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ConversationUI : MonoBehaviour
{
	public enum DialogueChoice
	{
		FirstMeet = 0,
		SecondMeet = 1,
		Greeting = 2,
		Food = 3,
		SellFood = 4,
		SellFoodDone = 5,
		GiveFood = 6,
		GiveFoodDone = 7,
		Trade = 8,
		Sell = 9,
		Exchange = 10,
		Done = 11,
		RejectTrade = 12,
		SellDone = 13,
		TradeDone = 14,
		GiveRocket = 15,
		PartTimeCompleted = 16,
		PartTimeDone = 17,
		ShopFirstGreeting = 18,
		ShopHowTo = 19,
		ShopWhatIf = 20,
		ShopAskPrice = 21,
		ShopBuy = 22,
		ShopNotBuy = 23,
		junkAskAbout = 24,
		junkAstHowTo = 25,
		junkBuy = 26,
		junkScaleSell = 27,
		GiveCookingDelivery = 28,
		CookingDeliveryDone = 29,
		AdmitTheft = 30,
		DenyTheft = 31,
		payTheft = 32,
		dontPayTheft = 33,
		KickedOut = 34
	}

	[Serializable]
	public struct Conversation
	{
		public LocalizedString[] friendlyDialogues;

		public LocalizedString[] interestDialogues;

		public DialogueChoice[] choice;
	}

	[Serializable]
	public class Reaction
	{
		public LocalizedString tag;

		public LocalizedString reactionLine;

		public bool isAlreadyAsked;
	}

	[SerializeField]
	private Transform dialogues;

	[SerializeField]
	private GameObject dialoguePrefab;

	[SerializeField]
	private TextMeshProUGUI npcDialogue;

	private NPC npc;

	private List<GameObject> dialogueGOs = new List<GameObject>();

	[Header("Conversations")]
	public Conversation firstConversation;

	public Conversation secondConversation;

	public Conversation partTime;

	public Conversation givePartTimeReward;

	public Conversation greeting;

	public Conversation cookingDelivery;

	public Conversation noDeliveryFood;

	public Conversation notWantedDeliveryFood;

	public Conversation takeDeliveryFood;

	public Conversation aboutFood;

	public Conversation noFood;

	public Conversation buyFood;

	public Conversation takeFood;

	public Conversation aboutTrade;

	public Conversation noWantedStuff;

	public Conversation noStuff;

	public Conversation buyStuff;

	public Conversation acceptTrade;

	public Conversation shopFirstMeet;

	public Conversation shopGreeting;

	public Conversation shopAbout;

	public Conversation shopHowTo;

	public Conversation shopWhatif;

	public Conversation shoppingDone;

	public Conversation shopTotalPrice;

	public Conversation shopNotEnoughMoney;

	public Conversation shopStolen;

	public Conversation shopKickeOut;

	public Conversation shopPriceStolen;

	public Conversation shopCompensated;

	public Conversation shopCompensatedNotenoughMoney;

	public Conversation junkFirstMeet;

	public Conversation junkAbout;

	public Conversation junkGreeting;

	public Conversation junkHowTo;

	public Conversation junkBuy;

	public Conversation junkScalePrice;

	public Conversation rcJunkScalePrice;

	public Conversation rcMeet;

	public Conversation rcMeetJunkyard;

	public Conversation rcDelivery;

	[Header("Reactions")]
	public Reaction sayHi;

	public Reaction questionFood;

	public Reaction sellingFood;

	public Reaction sellingFoodDone;

	public Reaction giveFood;

	public Reaction giveFoodDone;

	public Reaction questionTrade;

	public Reaction sellingStuff;

	public Reaction tradeStuff;

	public Reaction conversationDone;

	public Reaction sellingStuffDone;

	public Reaction tradeStuffDone;

	public Reaction partTimeCompleted;

	public Reaction partTimeConversationDone;

	public Reaction shopSayHi;

	public Reaction shopHowToQuestion;

	public Reaction shopWhatIfQuestion;

	public Reaction shopHowMuchQuestion;

	public Reaction shopBuyText;

	public Reaction shopNotBuyText;

	public Reaction junkAboutQuestion;

	public Reaction junkHowToQuestion;

	public Reaction junkBuyText;

	public Reaction junkScaleSellText;

	public Reaction rcjunkScaleSellText;

	public Reaction giveCookingDelivery;

	public Reaction cookingDeliveryDone;

	public Reaction apologizeShop;

	public Reaction dontApologizeShop;

	public Reaction tryCompensateShop;

	public Reaction dontCompensateShop;

	private List<Reaction> alreadyAskedReactions = new List<Reaction>();

	public DialogueChoice currentConversationType;

	private LocalizedString npcStuffRequest = new LocalizedString("MyTable", "npcStuffRequest");

	private LocalizedString reactionMoney = new LocalizedString("MyTable", "reaction_money");

	private LocalizedString reactionTotalPrice = new LocalizedString("MyTable", "npc-giveTotalPrice");

	private LocalizedString npcScalePrice = new LocalizedString("MyTable", "npc-junkscalePrice");

	private LocalizedString rcScalePrice = new LocalizedString("MyTable", "conversation_rcJunkPrice");

	private LocalizedString stolenPrice = new LocalizedString("MyTable", "conv-shopStolenPrice");

	[SerializeField]
	private JunkShopUI junkShopUI;

	[SerializeField]
	private Grocery grocery;

	public static event Action OnPlayerKickedOut;

	private void Start()
	{
		GameManager.S.OnConversationStart += GameManager_OnConversationStart;
		GameManager.S.OnDialogueChoiceBtnClicked += GameManager_OnDialogueChoiceBtnClicked;
		OffUI();
	}

	private void Gm_OnPlayerPressTab(object sender, EventArgs e)
	{
		EndConversation();
	}

	private void OnDestroy()
	{
		GameManager.S.OnConversationStart -= GameManager_OnConversationStart;
		GameManager.S.OnDialogueChoiceBtnClicked -= GameManager_OnDialogueChoiceBtnClicked;
	}

	private void GameManager_OnDialogueChoiceBtnClicked(object sender, GameManager.OnDialogueChoiceBtnClickedArg e)
	{
		NextConversation(e.choice);
	}

	private void GameManager_OnConversationStart(object sender, GameManager.OnConversatinoStartArg e)
	{
		OnUI();
		npc = e.npc;
		Cursor.visible = true;
		if (dialogueGOs != null)
		{
			foreach (GameObject dialogueGO in dialogueGOs)
			{
				UnityEngine.Object.Destroy(dialogueGO);
			}
			dialogueGOs.Clear();
		}
		Conversation conversation;
		if (npc.stat.place == NpcPlace.House)
		{
			if (!npc.haveMet)
			{
				if (FirstPersonController.S.rcControl)
				{
					conversation = rcMeet;
				}
				else
				{
					conversation = firstConversation;
					npc.haveMet = true;
				}
			}
			else
			{
				conversation = secondConversation;
				if (FirstPersonController.S.rcControl)
				{
					conversation = rcMeet;
				}
			}
		}
		else if (npc.stat.place == NpcPlace.Shop)
		{
			if (grocery.stolen)
			{
				conversation = shopStolen;
				npc.haveMet = true;
			}
			else if (!npc.haveMet)
			{
				if (FirstPersonController.S.rcControl)
				{
					conversation = rcMeet;
				}
				else
				{
					conversation = shopFirstMeet;
					npc.haveMet = true;
				}
			}
			else
			{
				conversation = shopGreeting;
				if (FirstPersonController.S.itemOnHand != null && FirstPersonController.S.itemOnHand.TryGetComponent<ShoppingBag>(out var component) && component.contents.Count > 0 && !component.isPayed)
				{
					conversation = shoppingDone;
				}
				if (FirstPersonController.S.rcControl)
				{
					conversation = rcMeet;
				}
			}
		}
		else if (npc.stat.place == NpcPlace.Junkyard)
		{
			if (!npc.haveMet)
			{
				if (FirstPersonController.S.rcControl)
				{
					conversation = rcMeetJunkyard;
					JunkScale junkScale = npc.GetComponent<ShopNPC>().junkScale;
					if (junkScale.scaledObject.Count > 0)
					{
						rcScalePrice.Arguments = new object[1] { junkScale.GetTotalValue() };
						npcDialogue.text = rcScalePrice.GetLocalizedString();
						conversation = rcJunkScalePrice;
						CreateChoiceUI(conversation);
						return;
					}
				}
				else
				{
					conversation = junkFirstMeet;
					npc.haveMet = true;
				}
			}
			else
			{
				conversation = ((!FirstPersonController.S.rcControl) ? junkGreeting : rcMeetJunkyard);
				JunkScale junkScale2 = npc.GetComponent<ShopNPC>().junkScale;
				if (junkScale2.scaledObject.Count > 0)
				{
					if (FirstPersonController.S.rcControl)
					{
						rcScalePrice.Arguments = new object[1] { junkScale2.GetTotalValue() };
						npcDialogue.text = rcScalePrice.GetLocalizedString();
						conversation = rcJunkScalePrice;
					}
					else
					{
						npcScalePrice.Arguments = new object[1] { junkScale2.GetTotalValue() };
						npcDialogue.text = npcScalePrice.GetLocalizedString();
						conversation = junkScalePrice;
					}
					CreateChoiceUI(conversation);
					return;
				}
			}
		}
		else
		{
			conversation = firstConversation;
		}
		if (npc.partTimeRequest)
		{
			conversation = ((!npc.cookingDeliveryRequest) ? partTime : ((!FirstPersonController.S.rcControl) ? cookingDelivery : rcDelivery));
		}
		if (npc.stat.npcAffinity == NpcAffinity.Interest)
		{
			int num = UnityEngine.Random.Range(0, conversation.interestDialogues.Length);
			npcDialogue.text = conversation.interestDialogues[num].GetLocalizedString();
		}
		else
		{
			int num2 = UnityEngine.Random.Range(0, conversation.friendlyDialogues.Length);
			npcDialogue.text = conversation.friendlyDialogues[num2].GetLocalizedString();
		}
		CreateChoiceUI(conversation);
	}

	private void NextConversation(DialogueChoice choice)
	{
		foreach (GameObject dialogueGO in dialogueGOs)
		{
			UnityEngine.Object.Destroy(dialogueGO);
		}
		dialogueGOs.Clear();
		Conversation conversation;
		switch (choice)
		{
		case DialogueChoice.Greeting:
			conversation = greeting;
			break;
		case DialogueChoice.Food:
			if (GameManager.S.player.itemOnHand != null)
			{
				if (GameManager.S.player.itemOnHand.TryGetComponent<Food>(out var _))
				{
					conversation = aboutFood;
					break;
				}
				conversation = noFood;
				questionFood.isAlreadyAsked = true;
				alreadyAskedReactions.Add(questionFood);
			}
			else
			{
				conversation = noFood;
				questionFood.isAlreadyAsked = true;
				alreadyAskedReactions.Add(questionFood);
			}
			break;
		case DialogueChoice.SellFood:
			conversation = buyFood;
			break;
		case DialogueChoice.SellFoodDone:
			GameManager.S.player.SellFood();
			EndConversation();
			return;
		case DialogueChoice.GiveFood:
			conversation = takeFood;
			break;
		case DialogueChoice.GiveFoodDone:
			GameManager.S.player.GiveFood();
			EndConversation();
			return;
		case DialogueChoice.Trade:
		{
			string localizedString = npc.wantedStuff.itemNameTemp.GetLocalizedString();
			string localizedString2 = npc.ownedStuff.GetComponent<Paint>().itemName.GetLocalizedString();
			npcStuffRequest.Arguments = new object[2] { localizedString, localizedString2 };
			npcDialogue.text = npcStuffRequest.GetLocalizedString();
			conversation = aboutTrade;
			CreateChoiceUI(conversation);
			return;
		}
		case DialogueChoice.Sell:
		{
			string itemName2 = npc.wantedStuff.itemName;
			conversation = ((!(GameManager.S.player.itemOnHand != null)) ? noStuff : ((!GameManager.S.player.itemOnHand.TryGetComponent<Item>(out var component5)) ? noWantedStuff : ((!(component5.itemName == itemName2)) ? noWantedStuff : buyStuff)));
			questionTrade.isAlreadyAsked = true;
			alreadyAskedReactions.Add(questionTrade);
			break;
		}
		case DialogueChoice.Exchange:
		{
			string itemName = npc.wantedStuff.itemName;
			conversation = ((!(GameManager.S.player.itemOnHand != null)) ? noStuff : ((!GameManager.S.player.itemOnHand.TryGetComponent<Item>(out var component)) ? noWantedStuff : ((!(component.itemName == itemName)) ? noWantedStuff : acceptTrade)));
			questionTrade.isAlreadyAsked = true;
			alreadyAskedReactions.Add(questionTrade);
			break;
		}
		case DialogueChoice.SellDone:
			GameManager.S.player.SellStuff();
			EndConversation();
			return;
		case DialogueChoice.TradeDone:
			GameManager.S.player.ComsumeItem();
			npc.ownedStuff.UnlockColor();
			EndConversation();
			return;
		case DialogueChoice.Done:
			EndConversation();
			return;
		case DialogueChoice.PartTimeCompleted:
			conversation = givePartTimeReward;
			break;
		case DialogueChoice.PartTimeDone:
			npc.partTimeRequest = false;
			QuestManager.S.GivePartTimeReward();
			EndConversation();
			return;
		case DialogueChoice.ShopFirstGreeting:
			conversation = shopAbout;
			break;
		case DialogueChoice.ShopHowTo:
			conversation = shopHowTo;
			shopHowToQuestion.isAlreadyAsked = true;
			alreadyAskedReactions.Add(shopHowToQuestion);
			break;
		case DialogueChoice.ShopWhatIf:
			conversation = shopWhatif;
			shopWhatIfQuestion.isAlreadyAsked = true;
			alreadyAskedReactions.Add(shopWhatIfQuestion);
			break;
		case DialogueChoice.ShopAskPrice:
		{
			float value = FirstPersonController.S.itemOnHand.GetComponent<ShoppingBag>().value;
			reactionTotalPrice.Arguments = new object[1] { value };
			npcDialogue.text = reactionTotalPrice.GetLocalizedString();
			conversation = shopTotalPrice;
			CreateChoiceUI(conversation);
			return;
		}
		case DialogueChoice.ShopBuy:
		{
			ShoppingBag component4 = FirstPersonController.S.itemOnHand.GetComponent<ShoppingBag>();
			if (FirstPersonController.S.money >= component4.value)
			{
				AudioManager.S.PlaySFX(AudioManager.S.money);
				FirstPersonController.S.MoneyUpdated(0f - component4.value);
				component4.isPayed = true;
				component4.UnlockStuff();
				EndConversation();
				return;
			}
			conversation = shopNotEnoughMoney;
			GameManager.S.player.ComsumeItem();
			AudioManager.S.PlaySFX(AudioManager.S.dropItem);
			break;
		}
		case DialogueChoice.ShopNotBuy:
			EndConversation();
			return;
		case DialogueChoice.junkAskAbout:
			conversation = junkAbout;
			break;
		case DialogueChoice.junkAstHowTo:
			conversation = junkHowTo;
			break;
		case DialogueChoice.junkBuy:
			JunkShop();
			return;
		case DialogueChoice.junkScaleSell:
		{
			AudioManager.S.PlaySFX(AudioManager.S.money);
			JunkScale junkScale = npc.GetComponent<ShopNPC>().junkScale;
			FirstPersonController.S.MoneyUpdated(junkScale.GetTotalValue());
			junkScale.ClearAll();
			GameManager.S.JunkScaleSell();
			EndConversation();
			return;
		}
		case DialogueChoice.GiveCookingDelivery:
		{
			conversation = ((!(FirstPersonController.S.itemOnHand != null)) ? noDeliveryFood : ((!FirstPersonController.S.itemOnHand.TryGetComponent<Food>(out var component2)) ? noDeliveryFood : ((!(component2.itemName == npc.wantedFood.itemName)) ? notWantedDeliveryFood : takeDeliveryFood)));
			break;
		}
		case DialogueChoice.CookingDeliveryDone:
			npc.partTimeRequest = false;
			npc.cookingDeliveryRequest = false;
			npc.wantedFood = null;
			FirstPersonController.S.ComsumeItem();
			QuestManager.S.GivePartTimeReward();
			EndConversation();
			return;
		case DialogueChoice.AdmitTheft:
		{
			float num = grocery.GetStolenPrice();
			stolenPrice.Arguments = new object[1] { num };
			npcDialogue.text = stolenPrice.GetLocalizedString();
			conversation = shopPriceStolen;
			CreateChoiceUI(conversation);
			return;
		}
		case DialogueChoice.DenyTheft:
			conversation = shopKickeOut;
			break;
		case DialogueChoice.payTheft:
			if (FirstPersonController.S.money >= grocery.GetStolenPrice())
			{
				FirstPersonController.S.MoneyUpdated(0f - grocery.GetStolenPrice());
				grocery.UnlockStore();
				conversation = shopCompensated;
			}
			else
			{
				conversation = shopCompensatedNotenoughMoney;
			}
			break;
		case DialogueChoice.dontPayTheft:
			conversation = shopKickeOut;
			break;
		case DialogueChoice.KickedOut:
			foreach (Reaction alreadyAskedReaction in alreadyAskedReactions)
			{
				alreadyAskedReaction.isAlreadyAsked = false;
			}
			alreadyAskedReactions.Clear();
			npc.ConversationEndKickOut();
			npc = null;
			GameManager.S.EndConversation();
			OffUI();
			ConversationUI.OnPlayerKickedOut?.Invoke();
			return;
		default:
			conversation = firstConversation;
			break;
		}
		if (npc.stat.npcAffinity == NpcAffinity.Interest)
		{
			int num2 = UnityEngine.Random.Range(0, conversation.interestDialogues.Length);
			npcDialogue.text = conversation.interestDialogues[num2].GetLocalizedString();
		}
		else
		{
			int num3 = UnityEngine.Random.Range(0, conversation.friendlyDialogues.Length);
			npcDialogue.text = conversation.friendlyDialogues[num3].GetLocalizedString();
		}
		CreateChoiceUI(conversation);
	}

	private void JunkShop()
	{
		foreach (Reaction alreadyAskedReaction in alreadyAskedReactions)
		{
			alreadyAskedReaction.isAlreadyAsked = false;
		}
		alreadyAskedReactions.Clear();
		npc.ConversationEndShop();
		npc = null;
		OffUI();
		junkShopUI.OpenUI();
	}

	private void EndConversation()
	{
		foreach (Reaction alreadyAskedReaction in alreadyAskedReactions)
		{
			alreadyAskedReaction.isAlreadyAsked = false;
		}
		alreadyAskedReactions.Clear();
		npc.ConversationEnd();
		npc = null;
		GameManager.S.EndConversation();
		OffUI();
	}

	private void CreateChoiceUI(Conversation conversation)
	{
		float num = 0f;
		float num2 = 0f;
		DialogueChoice[] choice = conversation.choice;
		foreach (DialogueChoice dialogueChoice in choice)
		{
			Reaction reaction;
			switch (dialogueChoice)
			{
			case DialogueChoice.Greeting:
				reaction = sayHi;
				break;
			case DialogueChoice.Food:
				reaction = questionFood;
				break;
			case DialogueChoice.Trade:
				reaction = questionTrade;
				break;
			case DialogueChoice.SellFood:
				reaction = sellingFood;
				break;
			case DialogueChoice.SellFoodDone:
				reaction = sellingFoodDone;
				reactionMoney.Arguments = new object[1] { FirstPersonController.S.itemOnHand.GetComponent<Food>().value };
				if (GameManager.S.intelPerkList[1])
				{
					reactionMoney.Arguments[0] = Mathf.FloorToInt(FirstPersonController.S.itemOnHand.GetComponent<Food>().value * 1.2f);
				}
				reaction.reactionLine = reactionMoney;
				reaction.reactionLine.GetLocalizedString();
				break;
			case DialogueChoice.GiveFood:
				reaction = giveFood;
				break;
			case DialogueChoice.GiveFoodDone:
				reaction = giveFoodDone;
				break;
			case DialogueChoice.Sell:
				reaction = sellingStuff;
				break;
			case DialogueChoice.SellDone:
				reaction = sellingStuffDone;
				reactionMoney.Arguments = new object[1] { MathF.Round(FirstPersonController.S.itemOnHand.GetComponent<Item>().value * 0.5f, 1) };
				reaction.reactionLine = reactionMoney;
				reaction.reactionLine.GetLocalizedString();
				break;
			case DialogueChoice.Exchange:
				reaction = tradeStuff;
				break;
			case DialogueChoice.TradeDone:
				reaction = tradeStuffDone;
				break;
			case DialogueChoice.Done:
				reaction = conversationDone;
				break;
			case DialogueChoice.PartTimeCompleted:
				reaction = partTimeCompleted;
				break;
			case DialogueChoice.PartTimeDone:
				reaction = partTimeConversationDone;
				break;
			case DialogueChoice.ShopFirstGreeting:
				reaction = shopSayHi;
				break;
			case DialogueChoice.ShopHowTo:
				reaction = shopHowToQuestion;
				break;
			case DialogueChoice.ShopWhatIf:
				reaction = shopWhatIfQuestion;
				break;
			case DialogueChoice.ShopAskPrice:
				reaction = shopHowMuchQuestion;
				break;
			case DialogueChoice.ShopBuy:
				reaction = shopBuyText;
				break;
			case DialogueChoice.ShopNotBuy:
				reaction = shopNotBuyText;
				break;
			case DialogueChoice.junkAskAbout:
				reaction = junkAboutQuestion;
				break;
			case DialogueChoice.junkAstHowTo:
				reaction = junkHowToQuestion;
				break;
			case DialogueChoice.junkBuy:
				reaction = junkBuyText;
				break;
			case DialogueChoice.junkScaleSell:
				reaction = ((!FirstPersonController.S.rcControl) ? junkScaleSellText : rcjunkScaleSellText);
				break;
			case DialogueChoice.GiveCookingDelivery:
				reaction = giveCookingDelivery;
				break;
			case DialogueChoice.CookingDeliveryDone:
				reaction = cookingDeliveryDone;
				break;
			case DialogueChoice.AdmitTheft:
				reaction = apologizeShop;
				break;
			case DialogueChoice.DenyTheft:
				reaction = dontApologizeShop;
				break;
			case DialogueChoice.payTheft:
				reaction = tryCompensateShop;
				break;
			case DialogueChoice.dontPayTheft:
				reaction = dontCompensateShop;
				break;
			case DialogueChoice.KickedOut:
				reaction = conversationDone;
				break;
			default:
				reaction = sayHi;
				break;
			}
			if (reaction.isAlreadyAsked)
			{
				continue;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(dialoguePrefab, dialogues);
			dialogueGOs.Add(gameObject);
			Dialogue component = gameObject.GetComponent<Dialogue>();
			component.GetComponent<Button>().onClick.AddListener(PlayClickedSound);
			if (reaction.tag == null || reaction.tag.IsEmpty)
			{
				if (reaction.reactionLine != null && !reaction.reactionLine.IsEmpty)
				{
					component.textmeshPro.text = reaction.reactionLine.GetLocalizedString();
				}
			}
			else if (reaction.reactionLine == null || reaction.reactionLine.IsEmpty)
			{
				component.textmeshPro.text = "[" + reaction.tag.GetLocalizedString() + "]";
			}
			else
			{
				component.textmeshPro.text = "[" + reaction.tag.GetLocalizedString() + "] " + reaction.reactionLine.GetLocalizedString();
			}
			switch (dialogueChoice)
			{
			case DialogueChoice.PartTimeDone:
			{
				int currentPartTimeReward2 = QuestManager.S.GetCurrentPartTimeReward();
				if (GameManager.S.intelPerkList[2])
				{
					int num4 = Mathf.FloorToInt((float)currentPartTimeReward2 * 1.5f);
					component.textmeshPro.text = $"+ {num4} Ticket";
				}
				else
				{
					component.textmeshPro.text = $"+ {currentPartTimeReward2} Ticket";
				}
				break;
			}
			case DialogueChoice.CookingDeliveryDone:
			{
				int currentPartTimeReward = QuestManager.S.GetCurrentPartTimeReward();
				if (GameManager.S.intelPerkList[2])
				{
					int num3 = Mathf.FloorToInt((float)currentPartTimeReward * 1.5f);
					component.textmeshPro.text = $"+ {num3} Ticket";
				}
				else
				{
					component.textmeshPro.text = $"+ {currentPartTimeReward} Ticket";
				}
				break;
			}
			}
			component.textmeshPro.ForceMeshUpdate(ignoreActiveState: true);
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			Vector2 anchoredPosition = component2.anchoredPosition;
			Vector2 sizeDelta = component2.sizeDelta;
			if (component.textmeshPro.textInfo.lineCount == 1)
			{
				sizeDelta.y = 50f;
			}
			else if (component.textmeshPro.textInfo.lineCount == 2)
			{
				sizeDelta.y = 70f;
			}
			component2.sizeDelta = sizeDelta;
			Vector2 sizeDelta2 = component2.sizeDelta;
			num = sizeDelta2.y / 2f;
			float num5 = (float)dialogueGOs.Count * 5f;
			anchoredPosition.y -= num2 + num + num5;
			component2.anchoredPosition = anchoredPosition;
			num2 += sizeDelta2.y;
			component.choice = dialogueChoice;
		}
	}

	private void Update()
	{
	}

	private void PlayClickedSound()
	{
		AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
	}

	private void OnUI()
	{
		base.gameObject.SetActive(value: true);
	}

	private void OffUI()
	{
		base.gameObject.SetActive(value: false);
	}
}
