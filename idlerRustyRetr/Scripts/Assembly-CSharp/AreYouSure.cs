using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AreYouSure : MonoBehaviour
{
	public static AreYouSure ins;

	private RectTransform rect;

	private bool canInteract;

	private Building buildingSelected;

	private SaveFileButton clearSave;

	private BlockedLand blockedLandSelected;

	private ChipButton chipButtonSelected;

	[SerializeField]
	private Image option1Image;

	[SerializeField]
	private Sprite demolishSprite;

	[SerializeField]
	private Sprite confirmSprite;

	private void Awake()
	{
		ins = this;
	}

	private void Start()
	{
		rect = GetComponent<RectTransform>();
		rect.localScale = new Vector3(1f, 0f, 1f);
	}

	private void SpawnAnimation()
	{
		rect.localScale = new Vector3(1f, 0f, 1f);
		rect.DOScaleY(1f, 0.2f).SetEase(Ease.OutBack);
		canInteract = true;
	}

	private void ClearAll()
	{
		buildingSelected = null;
		clearSave = null;
		blockedLandSelected = null;
		chipButtonSelected = null;
	}

	public void SpawnOn(Building building)
	{
		ClearAll();
		SpawnAnimation();
		buildingSelected = building;
		base.transform.position = building.center.position;
		option1Image.sprite = demolishSprite;
	}

	public void SpawnOn(SaveFileButton savefileButton, Transform buttonTransform)
	{
		ClearAll();
		SpawnAnimation();
		clearSave = savefileButton;
		base.transform.position = buttonTransform.position;
		option1Image.sprite = demolishSprite;
	}

	public void SpawnOn(BlockedLand blockedLand)
	{
		ClearAll();
		SpawnAnimation();
		blockedLandSelected = blockedLand;
		base.transform.position = blockedLand.button.transform.position;
		option1Image.sprite = demolishSprite;
	}

	public void SpawnOn(ChipButton chipButton, Transform buttonTransform)
	{
		ClearAll();
		SpawnAnimation();
		chipButtonSelected = chipButton;
		base.transform.position = buttonTransform.position;
		option1Image.sprite = confirmSprite;
	}

	public void Yes()
	{
		if (canInteract)
		{
			canInteract = false;
			DespawnBubble();
			if ((bool)buildingSelected)
			{
				buildingSelected.Demolish(moveTo: false);
			}
			if ((bool)clearSave)
			{
				clearSave.ClickedClearSave();
			}
			if ((bool)blockedLandSelected)
			{
				blockedLandSelected.MarkForClearing();
			}
			if ((bool)chipButtonSelected)
			{
				chipButtonSelected.PurchaseChip();
			}
		}
	}

	public void No()
	{
		if (canInteract)
		{
			canInteract = false;
			DespawnBubble();
		}
	}

	private void DespawnBubble()
	{
		rect.DOScaleY(0f, 0.15f).SetEase(Ease.InBack);
	}
}
