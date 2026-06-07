using TMPro;

public class MarketUI : OverlayUI
{
	public static MarketUI I;

	public CoolButton BtnQuantity1;

	public TextMeshProUGUI TxtQuantity1;

	public CoolButton BtnQuantity5;

	public TextMeshProUGUI TxtQuantity5;

	public CoolButton BtnQuantity10;

	public TextMeshProUGUI TxtQuantity10;

	public CoolButton BtnQuantity25;

	public TextMeshProUGUI TxtQuantity25;

	public CoolButton BtnQuantity100;

	public TextMeshProUGUI TxtQuantity100;

	public int TgtQuantity;

	public MarketItem[] BuyItems;

	public MarketItem[] SellItems;

	public CoolButton BtnClose;

	public CoolButton BtnUpgrade;

	public CoolButton BtnMobileToggleQuantity;

	private int _tgtMult;

	private void Awake()
	{
	}

	protected override void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnInputTypeChanged()
	{
	}

	public override void Activate()
	{
	}

	protected override void MyUpdate()
	{
	}

	private void SetMultiplier(int mult)
	{
	}

	private void RefreshBuyItems()
	{
	}

	private void RefreshSellItems()
	{
	}

	public void SelectItem(MarketItem item)
	{
	}

	private void OnCloseClicked()
	{
	}

	private void OnUpgradeClicked()
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	private void OnQuantity1Clicked()
	{
	}

	private void OnQuantity5Clicked()
	{
	}

	private void OnQuantity10Clicked()
	{
	}

	private void OnQuantity25Clicked()
	{
	}

	private void OnQuantity100Clicked()
	{
	}

	public void SetQuantity(int q)
	{
	}

	private void OnToggleQuantityClicked()
	{
	}
}
