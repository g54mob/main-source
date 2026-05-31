using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CropInventory : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public CropType cropType;

	public CropSO cropSO;

	public int cropAmount;

	public bool isBeingUsed;

	[Header("References")]
	[SerializeField]
	private Image logo;

	[SerializeField]
	private Image beingUsedLogo;

	[SerializeField]
	private TMP_Text cropName;

	[SerializeField]
	private TMP_Text cropAmountText;

	private Sprite logoSp;

	private string cropN;

	private Coroutine showCoroutine;

	private void Start()
	{
		StorePrivateVariables();
		UpdateVisual();
		beingUsedLogo.enabled = false;
	}

	private void StorePrivateVariables()
	{
		cropSO = GameManager.ins.getCropSO(cropType);
		logoSp = GameManager.ins.getCropSprite(cropType);
		cropN = GameManager.ins.getCropName(cropType);
	}

	private void UpdateVisual()
	{
		logo.sprite = logoSp;
	}

	public void UpdateUsedState(bool usedOrNot)
	{
		isBeingUsed = usedOrNot;
		if (usedOrNot)
		{
			beingUsedLogo.enabled = true;
		}
		else
		{
			beingUsedLogo.enabled = false;
		}
	}

	public void UpdateAmountText()
	{
		cropAmountText.text = cropAmount.ToString();
	}

	public void SetToLocked()
	{
		cropName.text = "?????";
		cropAmountText.text = "";
		logo.color = GameManager.ins.lockedC;
	}

	public void SetToUnlockedAndHarvested()
	{
		cropName.text = cropN;
		cropAmountText.text = cropAmount.ToString();
		logo.color = Color.white;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (showCoroutine != null)
		{
			StopCoroutine(showCoroutine);
		}
		TooltipSystem.Hide();
	}
}
