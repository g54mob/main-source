using DG.Tweening;
using TMPro;
using UnityEngine;

public class ResourceInventory : MonoBehaviour
{
	[SerializeField]
	private TMP_Text amount;

	private int currentAmount;

	private Vector2 startPos;

	private Color startCol;

	[Header("Overrides")]
	[SerializeField]
	private bool spareParts;

	[SerializeField]
	private bool biofuel;

	private void Start()
	{
		startPos = base.transform.localPosition;
		startCol = amount.color;
		if (spareParts)
		{
			Inventory.ins.sparePartsInventory.Add(this);
			Inventory.ins.AddSpareParts(0);
		}
		if (biofuel)
		{
			Inventory.ins.biofuelInventory.Add(this);
			Inventory.ins.AddBiofuel(0);
		}
	}

	public void ShakeText()
	{
		amount.transform.DOKill();
		amount.transform.localPosition = startPos;
		amount.transform.DOShakePosition(0.5f, 3f, 20);
	}

	public void RedText()
	{
		amount.DOKill();
		amount.color = Color.red;
		amount.DOColor(startCol, 0.5f);
	}

	public void SetAmountTo(int newAmount)
	{
		currentAmount = newAmount;
		amount.text = currentAmount.ToString();
	}

	public int GetAmount()
	{
		return currentAmount;
	}
}
