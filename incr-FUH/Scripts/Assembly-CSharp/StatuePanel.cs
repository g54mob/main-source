using System;

public class StatuePanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow BuyYellowRow;

	public MixedRow BuyBlueRow;

	public MixedRow BuyBookRow;

	private int _yellowShardCost = 100000;

	private int _blueShardCost = 250000;

	public int _bookCost = 500000;

	private void Start()
	{
		BuyYellowRow.gameObject.SetActive(value: false);
		Title.Initialize(base.gameObject, "Statue");
		BuyBlueRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Blue Shard");
		BuyBookRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Book");
		BuyBlueRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Blue Shard", "", "Buy a blue shard.", _blueShardCost.ToNumber() + "$"));
		BuyBookRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Book", GetBookAmountBought() + "/" + GetBookTotalAmount(), "Buy a book.\n\nFor every book found in a building, two books will become available for purchase.", _bookCost.ToNumber() + "$"));
		BuyBlueRow.ButtonPressEvent += BuyBlueRowClick;
		BuyBookRow.ButtonPressEvent += BuyBookRowClick;
	}

	private void Update()
	{
		BuyBlueRow.gameObject.SetActive(value: true);
		BuyBookRow.gameObject.SetActive(value: true);
		SetButtonCost(BuyBlueRow, _blueShardCost);
		SetBookButtonCost(BuyBookRow, _bookCost);
		SetPanelHeight();
		if (!FreezeScale)
		{
			PanelHelper.SetSize(this);
		}
	}

	private void SetButtonCost(MixedRow row, int cost)
	{
		row.SetButton(cost.ToNumber() + "$");
		row.SetButtonColor(cost <= GameController.Instance.Money.Amount);
	}

	private void SetBookButtonCost(MixedRow row, int cost)
	{
		if (GetBookAmountBought() < GetBookTotalAmount())
		{
			row.SetButton(cost.ToNumber() + "$");
			row.SetButtonColor(cost <= GameController.Instance.Money.Amount);
		}
		else
		{
			row.SetButton("Max");
			row.SetButtonColor(isOn: false);
		}
	}

	public void BuyBlueRowClick(object o, EventArgs e)
	{
		if (GameController.Instance.Money.Amount >= _blueShardCost)
		{
			GameController.Instance.Money.AddAmount(-_blueShardCost);
			GameController.Instance.GainBluePoint(1);
		}
	}

	public void BuyBookRowClick(object o, EventArgs e)
	{
		if (GameController.Instance.Money.Amount >= _bookCost && GetBookAmountBought() < GetBookTotalAmount())
		{
			GameController.Instance.Money.AddAmount(-_bookCost);
			GameController.Instance.Book.AddAmount(1);
			GameController.Instance.BoughtBook.AddAmount(1);
		}
	}

	protected override int GetRowCount()
	{
		return 0 + (BuyBlueRow.gameObject.activeSelf ? 1 : 0) + (BuyBookRow.gameObject.activeSelf ? 1 : 0);
	}

	private int GetBookAmountBought()
	{
		return GameController.Instance.BoughtBook.TotalAmount;
	}

	private int GetBookTotalAmount()
	{
		return GetTotalBookFromBuildings() * 2;
	}

	private int GetTotalBookFromBuildings()
	{
		return 0 + (Catapult.GlobalInfo.HasSpawnBook ? 1 : 0) + (Compressor.GlobalInfo.HasSpawnBook ? 1 : 0) + (Drone.GlobalInfo.HasSpawnBook ? 1 : 0) + (Helicopter.GlobalInfo.HasSpawnBook ? 1 : 0) + (House.GlobalInfo.HasSpawnBook ? 1 : 0) + (Industry.GlobalInfo.HasSpawnBook ? 1 : 0) + (Power.GlobalInfo.HasSpawnBook ? 1 : 0) + (Research.GlobalInfo.HasSpawnBook ? 1 : 0) + (Temple.GlobalInfo.HasSpawnBook ? 1 : 0) + (Training.GlobalInfo.HasSpawnBook ? 1 : 0);
	}
}
