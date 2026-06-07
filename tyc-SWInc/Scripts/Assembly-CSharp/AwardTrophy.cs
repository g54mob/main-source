using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AwardTrophy : MonoBehaviour
{
	[Serializable]
	public class AwardData
	{
		public readonly AwardType Type;

		public readonly AwardTier Tier;

		public readonly int Year;

		public readonly string For;

		public AwardData()
		{
		}

		public AwardData(AwardType type, AwardTier tier, int year, string isFor)
		{
			Type = type;
			Tier = tier;
			Year = year;
			For = isFor;
		}

		public AwardData(Furniture f)
		{
			AwardTrophy component = f.GetComponent<AwardTrophy>();
			Type = component.Type;
			Tier = component.Tier;
			Year = component.Year;
			For = component.For;
		}

		public AwardData(AwardTrophy t)
		{
			Type = t.Type;
			Tier = t.Tier;
			Year = t.Year;
			For = t.For;
		}

		public void AddToSearch()
		{
			string name = AwardFurn[(int)Type];
			Furniture furn = ObjectDatabase.Instance.GetFurnitureComponent(name);
			GlobalSearchPanel.Instance.AddSearchItem(this, "AwardPostFix".Loc(Type.ToString().Loc()) + " " + Year, delegate
			{
				BuildController.Instance.BeginBuildFurniture(furn.gameObject);
				BuildController.Instance.CurrentFurnitureBuilder.AwardData = this;
			}, ObjectDatabase.Instance.GetAwardSprite(Type, Tier), true);
		}

		public void RemoveFromSearch()
		{
			GlobalSearchPanel.Instance.RemoveSearchItem(this);
		}
	}

	public enum AwardType
	{
		BestEmployer = 0,
		BestProduct = 1,
		BestDesigner = 2,
		MostProfitable = 3
	}

	public enum BuffType
	{
		HungerBladder = 0,
		FurnitureBreakage = 1,
		SocialStress = 2,
		Dirt = 3
	}

	public enum AwardTier
	{
		Platinum = 0,
		Gold = 1,
		Silver = 2,
		Bronze = 3
	}

	public const int Awards = 4;

	private static float[] _buffs = new float[4] { 1f, 1f, 0.5f, 0.25f };

	public static string[] AwardFurn = new string[4] { "Best Employer Award", "Best Product Award", "Best Designer Award", "Most Profitable Award" };

	public AwardType Type;

	public Furniture Furn;

	public Renderer YearRend;

	[NonSerialized]
	public AwardTier Tier;

	[NonSerialized]
	public int Year;

	[NonSerialized]
	public string For;

	private static float[] _employerAwardScores = new float[3] { 0.95f, 0.9f, 0.85f };

	public BuffType Buff
	{
		get
		{
			return (BuffType)Type;
		}
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["AwardYear"] = Year;
		dict["AwardTier"] = Tier;
		dict["AwardFor"] = For;
	}

	public void Deserialize(WriteDictionary dict)
	{
		Year = dict.Get("AwardYear", 0);
		Tier = dict.Get("AwardTier", AwardTier.Bronze);
		For = dict.Get<string>("AwardFor", null);
	}

	public void Start()
	{
		if (!Furn.isTemporary)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			Vector4 zero = Vector4.zero;
			int num = Year;
			for (int i = 0; i < 4; i++)
			{
				zero[3 - i] = num % 10;
				num /= 10;
			}
			materialPropertyBlock.SetVector("_YearNum", zero);
			YearRend.SetPropertyBlock(materialPropertyBlock);
			switch (Tier)
			{
			case AwardTier.Platinum:
				Furn.Colorable[0].sharedMaterial = ObjectDatabase.Instance.GlassMaterial;
				break;
			case AwardTier.Gold:
				Furn.ColorPrimary = new Color32(byte.MaxValue, 193, 81, byte.MaxValue);
				break;
			case AwardTier.Silver:
				Furn.ColorPrimary = Color.white;
				break;
			case AwardTier.Bronze:
				Furn.ColorPrimary = new Color32(233, 112, 80, byte.MaxValue);
				break;
			}
			Furn.DisableInitColor = true;
		}
	}

	public void Init(AwardData d)
	{
		Type = d.Type;
		Tier = d.Tier;
		Year = d.Year;
		For = d.For;
	}

	public static float GetAgeFactor(AwardTier tier, int year)
	{
		if (tier == AwardTier.Platinum)
		{
			return 1f;
		}
		float years = SDateTime.GetYears(new SDateTime(0, 0, 0, 6, year - 1900), SDateTime.Now());
		if (years >= 2f)
		{
			return 0.25f;
		}
		if (years >= 1f)
		{
			return 0.5f;
		}
		return 1f;
	}

	public static float GetAwardEffectiveness(AwardTier tier, int year)
	{
		return _buffs[(int)tier] * GetAgeFactor(tier, year);
	}

	public static float GetAwardWorth(AwardTier tier, int year)
	{
		if (tier == AwardTier.Platinum)
		{
			return 1000000f;
		}
		return 100000f * GetAwardEffectiveness(tier, year);
	}

	public float GetEffectiveness()
	{
		return GetAwardEffectiveness(Tier, Year);
	}

	public float GetWorth()
	{
		return GetAwardWorth(Tier, Year);
	}

	private static List<KeyValuePair<Company, string>> GetBestDesigners(List<ValueTuple<SoftwareProduct, Company>> ps)
	{
		HashSet<Employee> hashSet = new HashSet<Employee>();
		List<KeyValuePair<Company, string>> list = new List<KeyValuePair<Company, string>>();
		int num = 0;
		foreach (var p in ps.OrderByDescending((ValueTuple<SoftwareProduct, Company> x) => x.Item1.CreativityScore * x.Item1.RealQuality.WeightOne(0.10000000149011612)))
		{
			if (p.Item1.LeadDesigner != null && list.None((KeyValuePair<Company, string> x) => x.Key == p.Item2) && hashSet.Add(p.Item1.LeadDesigner))
			{
				list.Add(new ValueTuple<Company, string>(p.Item2, p.Item1.LeadDesigner.FullName).ToKeyValuePair());
				num++;
				if (num == 3)
				{
					break;
				}
			}
		}
		return list;
	}

	private static List<KeyValuePair<Company, string>> GetBestProduct(List<ValueTuple<SoftwareProduct, Company>> ps)
	{
		List<KeyValuePair<Company, string>> list = new List<KeyValuePair<Company, string>>();
		int num = 0;
		foreach (var p in ps.OrderByDescending((ValueTuple<SoftwareProduct, Company> x) => x.Item1.RealQuality * Utilities.Clamp01(x.Item1.Category.PerceivedMarketValue(x.Item1.Features, null, x.Item1.Submarkets, x.Item1.GetBigProjectFactor())) * x.Item1.SequelBonus * x.Item1.CreativityScore * (double)(1f - (float)x.Item1.Bugss / (float)SoftwareWorkItem.GetMaximumBugs(x.Item1.DevTime))))
		{
			if (list.None((KeyValuePair<Company, string> x) => x.Key == p.Item2))
			{
				list.Add(new ValueTuple<Company, string>(p.Item2, p.Item1.Name).ToKeyValuePair());
				num++;
				if (num == 3)
				{
					break;
				}
			}
		}
		return list;
	}

	private static List<KeyValuePair<Company, string>> GetMostProfitable()
	{
		List<ValueTuple<Company, string, float>> list = new List<ValueTuple<Company, string, float>>();
		foreach (SoftwareProduct allProduct in MarketSimulation.Active.GetAllProducts(false))
		{
			if (allProduct.ProfitAward != null)
			{
				Company company = (allProduct.Traded ? MarketSimulation.Active.GetCompany(allProduct.InventorID) : allProduct.DevCompany);
				if (company != null)
				{
					float item = ((allProduct.ProfitAward[0] > 1000000f) ? (allProduct.ProfitAward[0] / (allProduct.ProfitAward[0] + allProduct.ProfitAward[1])) : 0f);
					allProduct.ProfitAward = null;
					list.Add(new ValueTuple<Company, string, float>(company, allProduct.Name, item));
				}
			}
		}
		List<KeyValuePair<Company, string>> list2 = new List<KeyValuePair<Company, string>>();
		foreach (var t in list.OrderByDescending((ValueTuple<Company, string, float> x) => x.Item3))
		{
			if (list2.None((KeyValuePair<Company, string> x) => x.Key == t.Item1))
			{
				list2.Add(new ValueTuple<Company, string>(t.Item1, t.Item2).ToKeyValuePair());
				if (list2.Count == 3)
				{
					break;
				}
			}
		}
		return list2;
	}

	private static List<KeyValuePair<Company, string>> GetBestEmployer()
	{
		float employerScore = (GameSettings.Instance.EmployerAwardDis ? 0f : GameSettings.Instance.ApplicantScore.GetAwardScore());
		GameSettings.Instance.EmployerAwardDis = false;
		GameSettings.Instance.MyCompany.EmployerScore = employerScore;
		List<Company> list = (from x in MarketSimulation.Active.GetPlayerCompanies()
			orderby x.EmployerScore descending
			select x).Take(3).ToList();
		int num = list.Count - 1;
		while (num >= 0 && list[num].EmployerScore <= _employerAwardScores[2])
		{
			list.RemoveAt(num);
			num--;
		}
		if (list.Count < 3)
		{
			List<KeyValuePair<Company, string>> list2 = (from x in MarketSimulation.Active.Companies.Values.OrderByDescending((SimulatedCompany x) => x.BusinessSavy).Take(3)
				select new ValueTuple<Company, string>(x, null).ToKeyValuePair()).ToList();
			while (list.Count < 3 && list2.Count > 0)
			{
				int num2;
				for (num2 = 0; num2 < list.Count; num2++)
				{
					if (!(list[num2] is SimulatedCompany))
					{
						float num3 = _employerAwardScores[num2];
						if (list[num2].EmployerScore <= num3)
						{
							break;
						}
					}
				}
				list.Insert(num2, list2[0].Key);
				list2.RemoveAt(0);
			}
		}
		return list.SelectInPlaceList((Company x) => new KeyValuePair<Company, string>(x, null));
	}

	private static List<KeyValuePair<Company, string>> TestLength(List<KeyValuePair<Company, string>> res)
	{
		if (res.Count >= 3)
		{
			return res;
		}
		return new List<KeyValuePair<Company, string>>();
	}

	public static List<KeyValuePair<Company, string>>[] GetWinners()
	{
		List<KeyValuePair<Company, string>>[] array = new List<KeyValuePair<Company, string>>[4];
		int year = SDateTime.Now().Year;
		SDateTime sDateTime = new SDateTime(0, 0, 5, year - 1);
		List<ValueTuple<SoftwareProduct, Company>> list = new List<ValueTuple<SoftwareProduct, Company>>();
		foreach (SoftwareProduct allProduct in MarketSimulation.Active.GetAllProducts(false))
		{
			if (!allProduct.InHouse && allProduct.Release > sDateTime)
			{
				Company company = (allProduct.Traded ? MarketSimulation.Active.GetCompany(allProduct.InventorID) : allProduct.DevCompany);
				if (company != null)
				{
					list.Add(new ValueTuple<SoftwareProduct, Company>(allProduct, company));
				}
			}
		}
		array[2] = TestLength(GetBestDesigners(list));
		array[1] = TestLength(GetBestProduct(list));
		array[0] = TestLength(GetBestEmployer());
		array[3] = TestLength(GetMostProfitable());
		return array;
	}
}
