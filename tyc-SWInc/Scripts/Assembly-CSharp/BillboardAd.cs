using System;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BillboardAd : Selectable
{
	public GameObject HasAdd;

	public GameObject NoAdd;

	public RawImage CompanyLogo;

	public RawImage ProductThumb;

	public Text CompanyLabel;

	public Text ProductLabel;

	public Text PriceLabel;

	public Text TagLabel;

	[NonSerialized]
	public uint ID;

	[NonSerialized]
	private RenderTexture _productTex;

	[NonSerialized]
	private float _currentPrice = -1f;

	[NonSerialized]
	private uint _company;

	[NonSerialized]
	private uint _product;

	[NonSerialized]
	private uint _addon;

	[NonSerialized]
	private bool _init;

	public static float DefaultPrice
	{
		get
		{
			return GameData.DefaultBillboardEffect * MarketingPlan.PostMarketingPrice * 2f;
		}
	}

	public void SetCompany(Company c, IMarketable m, float price, bool fromNetwork)
	{
		_company = c.ID;
		_currentPrice = price;
		_product = 0u;
		SetProduct(m);
		UpdateBillboard();
	}

	public void UnsetBillboard()
	{
		_company = 0u;
		_product = 0u;
		_currentPrice = DefaultPrice;
		UpdateBillboard();
	}

	private void SetProduct(IMarketable m)
	{
		SoftwareProduct softwareProduct;
		AddOnProduct addOnProduct;
		if (m == null)
		{
			_product = 0u;
		}
		else if ((softwareProduct = m as SoftwareProduct) != null)
		{
			_product = softwareProduct.ID;
			_addon = 0u;
		}
		else if ((addOnProduct = m as AddOnProduct) != null)
		{
			_product = addOnProduct.Parent.ID;
			_addon = addOnProduct.ID;
		}
	}

	public void UpdateBillboard()
	{
		if (_company != 0 && _product != 0)
		{
			Company company = MarketSimulation.Active.GetCompany(_company);
			CompanyLabel.text = company.Name;
			CompanyLogo.uvRect = LogoController.Instance.GetLogoRect(company);
			IMarketable target = GetTarget();
			HardwareDesignRenderer.Instance.RenderProduct(target as IDisplayable, _productTex, false);
			ProductLabel.text = target.GetName();
			SoftwareProduct softwareProduct;
			AddOnProduct addOnProduct;
			if ((softwareProduct = target as SoftwareProduct) != null)
			{
				PriceLabel.text = softwareProduct.Price.Currency();
			}
			else if ((addOnProduct = target as AddOnProduct) != null)
			{
				PriceLabel.text = addOnProduct.Price.Currency();
			}
			else
			{
				PriceLabel.text = "";
			}
			TagLabel.text = "Get it now!";
			HasAdd.SetActive(true);
			NoAdd.SetActive(false);
		}
		else
		{
			HasAdd.SetActive(false);
			NoAdd.SetActive(true);
		}
	}

	private IMarketable GetTarget()
	{
		if (_product == 0)
		{
			return null;
		}
		SoftwareProduct product = MarketSimulation.Active.GetProduct(_product, false);
		if (_addon != 0)
		{
			return product.GetAddon(_addon);
		}
		return product;
	}

	private void Start()
	{
		Init();
	}

	public void Test()
	{
		Company random = (from x in MarketSimulation.Active.GetAllCompanies()
			where x.Products.Count > 0
			select x).GetRandom();
		SetCompany(random, random.Products.GetRandom(), _currentPrice, false);
	}

	private void Init()
	{
		if (!_init)
		{
			_init = true;
			if (ID == 0)
			{
				_currentPrice = DefaultPrice;
				GameSettings.Instance.BillboardID++;
				ID = GameSettings.Instance.BillboardID;
			}
			GameSettings.Instance.Billboards[ID] = this;
			_productTex = new RenderTexture(256, 256, 0, RenderTextureFormat.ARGB32);
			ProductThumb.texture = _productTex;
			UpdateBillboard();
		}
	}

	private void OnDestroy()
	{
		GameSettings.Instance.IsReferenceNull();
		if (_productTex != null)
		{
			UnityEngine.Object.Destroy(_productTex);
		}
	}

	public void UpdateMe()
	{
		if (_company != 0 && _product != 0)
		{
			Company company = MarketSimulation.Active.GetCompany(_company);
			IMarketable target = GetTarget();
			if (target != null)
			{
				float num = _currentPrice / (float)GameSettings.DaysPerMonth;
				company.MakeTransaction(0f - num, Company.TransactionCategory.Marketing, true);
				target.AddLoss(num, SoftwareProduct.LossType.Marketing, true);
				target.AddToMarketing(GameData.DefaultBillboardEffect / (float)GameSettings.DaysPerMonth);
			}
		}
	}

	public void UpdatePrice()
	{
		_currentPrice = Mathf.Max(DefaultPrice, _currentPrice * 0.99f);
	}

	public void Serialize(WriteDictionary wr)
	{
		wr["BillboardID"] = ID;
		wr["BillboardPrice"] = _currentPrice;
		wr["BillboardCompany"] = _company;
		wr["BillboardProduct"] = _product;
		wr["BillboardAddon"] = _addon;
	}

	public void Deserialize(WriteDictionary wr)
	{
		ID = wr.Get("BillboardID", 0u);
		_currentPrice = wr.Get("BillboardPrice", DefaultPrice);
		_company = wr.Get("BillboardCompany", 0u);
		_product = wr.Get("BillboardProduct", 0u);
		_addon = wr.Get("BillboardAddon", 0u);
		Init();
	}

	public override int GetFloor()
	{
		return Mathf.FloorToInt((base.transform.position.y + 0.5f) / 2f);
	}

	public override Vector2 GetFlatPos()
	{
		return base.transform.position.FlattenVector3();
	}

	public override bool IsSelectableInView()
	{
		return GameSettings.Instance.ActiveFloor >= 0;
	}

	public override bool IsSelectableAboveFloor()
	{
		return true;
	}

	public override string GetInfo()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (_company != 0)
		{
			Company company = MarketSimulation.Active.GetCompany(_company);
			stringBuilder.AppendLine(company.Name);
			if (_product != 0)
			{
				stringBuilder.AppendLine(GetTarget().GetName());
			}
		}
		stringBuilder.AppendLine(_currentPrice.Currency() + "PerMonth".Loc());
		stringBuilder.AppendLine("BindingContract".Loc("Month".LocPlural(3)));
		return stringBuilder.ToString().TrimEnd();
	}
}
