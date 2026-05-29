using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BulkDonationBoxUIScreen : GenericSliderScreen
{
	public CanvasGroup m_CanvasGrp;

	public BulkDonationBoxPlusMinusScreen m_CardPlusMinusScreen;

	public List<BulkDonationBoxCardPanelUI> m_BulkDonationBoxCardPanelUIList;

	public GameObject m_ScrollEndParent;

	public Transform m_CardScrollOffsetPosStart;

	public Transform m_CardScrollOffsetPosEnd;

	public Image m_BoxCapacityBarImage;

	public TextMeshProUGUI m_BoxCapacityText;

	private bool m_IsShowingCanvasGrpAlpha;

	private bool m_IsHidingCanvasGrpAlpha;

	private int m_CurrentSelectedSlotIndex;

	private int m_TotalCardCount;

	private float m_CanvasGrpAlphaLerpTimer;

	private InteractableBulkDonationBox m_InteractableBulkDonationBox;

	private List<CompactCardDataAmount> m_CompactCardDataList = new List<CompactCardDataAmount>();

	protected override void Awake()
	{
		base.Awake();
		for (int i = 0; i < m_BulkDonationBoxCardPanelUIList.Count; i++)
		{
			m_BulkDonationBoxCardPanelUIList[i].Init(this, i);
			m_BulkDonationBoxCardPanelUIList[i].SetActive(isActive: false);
		}
	}

	protected override void Init()
	{
		base.Init();
	}

	public void OpenBulkDonationBoxScreen(InteractableBulkDonationBox bulkDonationBox)
	{
		m_InteractableBulkDonationBox = bulkDonationBox;
		m_CompactCardDataList = bulkDonationBox.GetCompactCardDataAmountList();
		OpenScreen();
	}

	protected override void OnOpenScreen()
	{
		EvaluateCardPanelUI();
		m_PosX = 0f;
		m_LerpPosX = 0f;
		base.OnOpenScreen();
		SoundManager.GenericMenuOpen();
	}

	protected override void OnCloseScreen()
	{
		base.OnCloseScreen();
		SoundManager.GenericMenuClose();
		CSingleton<InteractionPlayerController>.Instance.m_WalkerCtrl.SetStopMovement(isStop: false);
		CSingleton<InteractionPlayerController>.Instance.ExitUIMode();
		m_InteractableBulkDonationBox.OnCloseBulkDonationBoxUIScreen();
	}

	protected override void RunUpdate()
	{
		base.RunUpdate();
		if (m_IsShowingCanvasGrpAlpha)
		{
			m_CanvasGrpAlphaLerpTimer += Time.deltaTime * 2f;
			m_CanvasGrp.alpha = Mathf.Lerp(0f, 1f, m_CanvasGrpAlphaLerpTimer);
			if (m_CanvasGrpAlphaLerpTimer >= 1f)
			{
				m_IsShowingCanvasGrpAlpha = false;
				m_CanvasGrpAlphaLerpTimer = 1f;
				CSingleton<InteractionPlayerController>.Instance.ExitSelectingCardFromGradedCardUIScreenResetCamera();
			}
		}
		else if (m_IsHidingCanvasGrpAlpha)
		{
			m_CanvasGrpAlphaLerpTimer -= Time.deltaTime * 2f;
			m_CanvasGrp.alpha = Mathf.Lerp(0f, 1f, m_CanvasGrpAlphaLerpTimer);
			if (m_CanvasGrpAlphaLerpTimer <= 0f)
			{
				m_IsShowingCanvasGrpAlpha = false;
				m_CanvasGrpAlphaLerpTimer = 0f;
			}
		}
	}

	public void OnPressEmptySlot(int index)
	{
		m_CurrentSelectedSlotIndex = index;
		CSingleton<InteractionPlayerController>.Instance.StartSelectingCardFromDeckBulkDonationBoxUIScreen();
		m_ControllerScreenUIExtension.SetControllerUIActive(isActive: false);
		SoundManager.GenericConfirm();
	}

	public void OnPressOpenEditCard(CardData cardData, int index)
	{
		m_CurrentSelectedSlotIndex = index;
		m_CardPlusMinusScreen.OpenPlusMinusScreen(cardData, m_CompactCardDataList[index].amount, m_TotalCardCount);
		SoundManager.GenericConfirm();
	}

	public void UpdateSelectedCardData(CardData cardData)
	{
		if (cardData != null)
		{
			if (m_TotalCardCount >= m_InteractableBulkDonationBox.GetBoxTotalCardCountMax())
			{
				CPlayerData.AddCard(cardData, 1);
				NotEnoughResourceTextPopup.ShowText(ENotEnoughResourceText.MaxDeckCardLimitReached);
			}
			else
			{
				m_CurrentSelectedSlotIndex = AddCardDataToCompactCardData(ref m_CompactCardDataList, cardData);
				EvaluateCardPanelUI();
				StartCoroutine(EvaluateActiveRestockUIScroller());
				if (CPlayerData.GetCardAmount(cardData) > 0)
				{
					m_CardPlusMinusScreen.OpenPlusMinusScreen(cardData, m_CompactCardDataList[m_CurrentSelectedSlotIndex].amount, m_TotalCardCount);
				}
				m_InteractableBulkDonationBox.SetCompactCardDataAmountList(m_CompactCardDataList);
			}
		}
		m_ControllerScreenUIExtension.SetControllerUIActive(isActive: true);
	}

	public void UpdateCompactData(int addCount)
	{
		m_CompactCardDataList[m_CurrentSelectedSlotIndex].amount += addCount;
		if (m_CompactCardDataList[m_CurrentSelectedSlotIndex].amount <= 0)
		{
			m_CompactCardDataList.RemoveAt(m_CurrentSelectedSlotIndex);
		}
		m_InteractableBulkDonationBox.SetCompactCardDataAmountList(m_CompactCardDataList);
	}

	private void EvaluateCardPanelUI()
	{
		for (int i = 0; i < m_BulkDonationBoxCardPanelUIList.Count; i++)
		{
			m_BulkDonationBoxCardPanelUIList[i].SetActive(isActive: false);
		}
		int num = 0;
		CardData cardData = null;
		List<CompactCardDataAmount> compactCardDataList = m_CompactCardDataList;
		for (int j = 0; j < compactCardDataList.Count + 1 && j < m_BulkDonationBoxCardPanelUIList.Count; j++)
		{
			if (num >= m_InteractableBulkDonationBox.GetBoxTotalCardCountMax())
			{
				break;
			}
			if (j == compactCardDataList.Count)
			{
				m_BulkDonationBoxCardPanelUIList[j].SetEmptyCardSlot();
				ScrollToUI(m_BulkDonationBoxCardPanelUIList[j].m_CountText.gameObject, instantSnapToPos: false, 0f);
			}
			else
			{
				cardData = CPlayerData.GetCardData(compactCardDataList[j].cardSaveIndex, compactCardDataList[j].expansionType, compactCardDataList[j].isDestiny);
				int amount = compactCardDataList[j].amount;
				m_BulkDonationBoxCardPanelUIList[j].SetCardUI(cardData, amount);
				num += amount;
			}
			m_BulkDonationBoxCardPanelUIList[j].SetActive(isActive: true);
			m_ScrollEndParent.transform.parent = m_BulkDonationBoxCardPanelUIList[j].transform;
			m_ScrollEndParent.transform.position = m_BulkDonationBoxCardPanelUIList[j].transform.position;
			Vector3 position = m_ScrollEndParent.transform.position;
			position.y += m_CardScrollOffsetPosEnd.position.y - m_CardScrollOffsetPosStart.position.y;
			m_ScrollEndParent.transform.position = position;
			m_ScrollEndPosParent = m_ScrollEndParent;
		}
		m_TotalCardCount = num;
		m_BoxCapacityText.text = m_TotalCardCount + " / " + m_InteractableBulkDonationBox.GetBoxTotalCardCountMax();
		m_BoxCapacityBarImage.fillAmount = (float)m_TotalCardCount / (float)m_InteractableBulkDonationBox.GetBoxTotalCardCountMax();
		m_InteractableBulkDonationBox.UpdateFillPercent(m_BoxCapacityBarImage.fillAmount);
	}

	public void OnCloseCardPlusMinusScreen()
	{
		EvaluateCardPanelUI();
		StartCoroutine(EvaluateActiveRestockUIScroller());
	}

	private int AddCardDataToCompactCardData(ref List<CompactCardDataAmount> compactCardDataAmountList, CardData cardData)
	{
		int result = 0;
		bool flag = false;
		int cardSaveIndex = CPlayerData.GetCardSaveIndex(cardData);
		for (int i = 0; i < compactCardDataAmountList.Count; i++)
		{
			if (compactCardDataAmountList[i].cardSaveIndex == cardSaveIndex && compactCardDataAmountList[i].expansionType == cardData.expansionType && compactCardDataAmountList[i].isDestiny == cardData.isDestiny)
			{
				flag = true;
				compactCardDataAmountList[i].amount++;
				result = i;
				break;
			}
		}
		if (!flag)
		{
			CompactCardDataAmount compactCardDataAmount = new CompactCardDataAmount();
			compactCardDataAmount.expansionType = cardData.expansionType;
			compactCardDataAmount.isDestiny = cardData.isDestiny;
			compactCardDataAmount.cardSaveIndex = cardSaveIndex;
			compactCardDataAmount.amount = 1;
			result = compactCardDataAmountList.Count;
			compactCardDataAmountList.Add(compactCardDataAmount);
		}
		return result;
	}

	public void SetGameUIVisible(bool isVisible)
	{
		if (isVisible)
		{
			if (m_CanvasGrp.alpha != 1f)
			{
				m_IsShowingCanvasGrpAlpha = true;
				m_IsHidingCanvasGrpAlpha = false;
				m_CanvasGrp.interactable = true;
				m_CanvasGrp.blocksRaycasts = true;
			}
		}
		else if (m_CanvasGrp.alpha != 0f)
		{
			m_IsShowingCanvasGrpAlpha = false;
			m_IsHidingCanvasGrpAlpha = true;
			m_CanvasGrp.interactable = false;
			m_CanvasGrp.blocksRaycasts = false;
		}
	}

	public int GetBoxTotalCardCountMax()
	{
		if (m_InteractableBulkDonationBox == null)
		{
			return 10000;
		}
		return m_InteractableBulkDonationBox.GetBoxTotalCardCountMax();
	}
}
