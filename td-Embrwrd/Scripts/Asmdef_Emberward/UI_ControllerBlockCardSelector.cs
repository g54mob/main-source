using System.Collections.Generic;
using Rewired;
using Rewired.Glyphs.UnityUI;
using UnityEngine;

public class UI_ControllerBlockCardSelector : MonoBehaviour
{
	[SerializeField]
	private CardController cardController;

	[SerializeField]
	private GameObject node_SelectArrow;

	[SerializeField]
	private UnityUITextMeshProGlyphHelper text_ControllerInputHint;

	private bool isActive;

	private bool isSelecting;

	private int selectIndex;

	private List<AUICard> list_Cards;

	private AUICard currentSelectedCard;

	private float holdRightButtonTime;

	private float holdLeftButtonTime;

	private float timeSinceSwitchControlScheme;

	private void Awake()
	{
	}

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnControlSchemeChanged(eControlScheme scheme)
	{
	}

	private void UpdateControlScheme(eControlScheme scheme)
	{
	}

	private void Start()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void OnHandCardChanged(List<CardData> list_cards)
	{
	}

	private void Update()
	{
	}

	private void UpdateGlyphText()
	{
	}

	private void SelectFirstAvailableCard()
	{
	}

	private void SelectCardAtIndex(int index)
	{
	}
}
