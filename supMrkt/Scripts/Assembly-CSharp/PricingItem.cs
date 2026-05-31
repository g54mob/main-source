using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using __Project__.Scripts.Computer;

public class PricingItem : MonoBehaviour
{
	[Header("Components")]
	[SerializeField]
	private Image m_ProductIconImage;

	[SerializeField]
	private TMP_Text m_ProductText;

	[SerializeField]
	private TMP_Text m_PreviousCostText;

	[SerializeField]
	private TMP_Text m_LastChangeDateText;

	[SerializeField]
	private TMP_Text m_CurrentCostText;

	[SerializeField]
	private TMP_Text m_AvgCostText;

	[SerializeField]
	private TMP_Text m_MarketPriceText;

	[SerializeField]
	private TMP_InputField m_PriceInput;

	[SerializeField]
	private TMP_Text m_DiscountedPriceText;

	[SerializeField]
	private TMP_Text m_ProfitText;

	[SerializeField]
	private Color m_ProfitColor;

	[SerializeField]
	private Color m_LossColor;

	[SerializeField]
	private GameObject m_CurrentCostUpArrow;

	[SerializeField]
	private GameObject m_CurrentCostDownArrow;

	[SerializeField]
	private GameObject m_DiscountButton;

	[SerializeField]
	private TMP_Text m_DiscountButtonText;

	[SerializeField]
	private LocalizedString m_Today;

	[SerializeField]
	private LocalizedString m_DayBefore;

	[SerializeField]
	private LocalizedString m_AWhileAgo;

	private PricingProductViewer m_PricingProductViewer;

	private Pricing m_pricingData;

	private Computer m_Computer;

	public Pricing PricingData => null;

	public string ProductName => null;

	public string ProductBrand => null;

	public DisplayType StorageType => default(DisplayType);

	public ProductSO.ProductCategory ProductType => default(ProductSO.ProductCategory);

	public TMP_Text DiscountButtonText
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public PricingProductViewer PricingProductViewer
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void EnableInputField()
	{
	}

	private void DisableInputField()
	{
	}

	private void SwitchInputFieldListeningState(bool willListen)
	{
	}

	public void Setup(Pricing data)
	{
	}

	public void SetupBakery(Pricing data)
	{
	}

	public void SetPrice(string input)
	{
	}

	public void SetupPopup()
	{
	}

	public void RemovePopup()
	{
	}

	public string LastChangeDate(Pricing data)
	{
		return null;
	}

	public void UpdateLastChangeDate(Locale _ = null)
	{
	}

	public void UpdateProfit(float newPrice = -1f)
	{
	}

	public void SwitchCurrentCostArrow(bool isReset = false)
	{
	}

	public void GamepadInputFieldOpen()
	{
	}
}
