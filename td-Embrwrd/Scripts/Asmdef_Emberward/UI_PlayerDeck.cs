using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerDeck : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private TMP_Text text_DeckCardCount;

	[SerializeField]
	private TMP_Text text_DrawCardCost;

	[SerializeField]
	private TMP_Text text_Free;

	[SerializeField]
	private Button button_DrawCard;

	[SerializeField]
	private GameObject node_DrawCardCost;

	[SerializeField]
	private Transform node_DrawCardInitialPosition;

	[SerializeField]
	private Transform node_HandFull;

	[SerializeField]
	private Transform node_NextCard;

	[SerializeField]
	private UI_CardFace cardFace_NextCard;

	[SerializeField]
	private Image image_Deck;

	[SerializeField]
	private Sprite sprite_Deck_WithQuestionMark;

	[SerializeField]
	private Sprite sprite_Deck_WithoutQuestionMark;

	[SerializeField]
	private Button button_Mulligan;

	[SerializeField]
	private Sprite sprite_Deck_Grayscale;

	[SerializeField]
	private GameObject prefab_CardFace;

	[SerializeField]
	private GameObject node_DeckCardList;

	[SerializeField]
	private UI_ShowPlayerDeckListButton button_ShowDeckList;

	private int registeredHideUIRequest;

	private bool isHidingCommonIngameUI;

	private int curDrawCardCost;

	private bool isMulliganUsed;

	private bool isForceDisabled;

	private List<UI_CardFace> list_CreatedCardFace;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnHandCardChanged(List<CardData> list)
	{
	}

	private void OnShowCommonIngameUI()
	{
	}

	private void OnHideCommonIngameUI()
	{
	}

	private void OnRequestHidePlayerDeckUI()
	{
	}

	private void OnRequestShowPlayerDeckUI()
	{
	}

	private void OnRequestDisablePlayerDeckUI()
	{
	}

	private void OnDeckChanged(List<CardData> list)
	{
	}

	private void OnStorageChanged(List<CardData> list)
	{
	}

	private void OnDrawCardCostChanged(int cost)
	{
	}

	private void OnApplyBuffCard(ABaseBuffSettingData data, bool isFromPlayer, bool isPlayerAction)
	{
	}

	private void OnBattleStart()
	{
	}

	private void OnPlayerOpenChest()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	private void OnPlayerDrawCard()
	{
	}

	private void OnCardDiscardedByPlayer(CardData data)
	{
	}

	private void DisableMulligan()
	{
	}

	private void OnGameStateChanged(eGameState fromState, eGameState toState)
	{
	}

	private void OnCoinChanged(int coin, int delta)
	{
	}

	public void OnClickButton_DrawCard()
	{
	}

	private void OnClickButton_Mulligan()
	{
	}

	public Vector3 GetDrawCardInitialPosition()
	{
		return default(Vector3);
	}

	private void OnRelicChanged(List<eItemType> list)
	{
	}

	private void CheckRelicUpdate()
	{
	}

	private void Update_Relic_ProphetGlobe()
	{
	}

	private void UpdateBackpackCardList()
	{
	}

	public void ShowDeckList()
	{
	}

	public void HideDeckList()
	{
	}

	private void UpdateHideStatus()
	{
	}
}
