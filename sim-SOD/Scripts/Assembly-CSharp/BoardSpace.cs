using System;
using UnityEngine;
using UnityEngine.UI;

public class BoardSpace : MonoBehaviour
{
	public bool occupied;

	public TerritoryOwner owner;

	public Wizcard myWizcard;

	public Sprite emptySprite;

	public Sprite enemyTileSprite;

	public Sprite playerTileSprite;

	public Sprite blankSprite;

	[NonSerialized]
	public Image iconImage;

	[NonSerialized]
	public Image boardSpaceImage;

	[NonSerialized]
	public Animator animator;

	private WizcardsApp app;

	private ComputerController comp;

	private ComputerOSUIComponent hoverComponent;

	private bool isHovered;

	private RectTransform rectTransform;

	public WizcardStats[] wizcardStats;

	private void Update()
	{
	}

	public void UpdateStatsAndImage()
	{
	}

	private bool IsCursorOverCard()
	{
		return false;
	}

	private void Start()
	{
	}

	public void BecomeTerritory(bool isEnemyTerritory)
	{
	}

	public void BecomeNoMansLand()
	{
	}

	public void PlaceHere()
	{
	}

	public void ForcePlaceHere()
	{
	}
}
