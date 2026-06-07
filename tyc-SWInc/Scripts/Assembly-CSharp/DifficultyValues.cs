using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public static class DifficultyValues
{
	[Serializable]
	public class DifficultySetting : IByteData
	{
		public readonly string Name;

		[DifficultyTip("Startingfunds", DifficultyTip.TipType.Money, Free = true, ActualMaxValue = 100000f, Discretization = 5000f, Importance = 0f)]
		public float DefaultStartMoney = 50000f;

		[DifficultyTip("MaxSkillPoints", DifficultyTip.TipType.Straight, Importance = 0f)]
		public float MaxSkillPoints = 2.5f;

		[DifficultyTip("MaxSpecPoints", DifficultyTip.TipType.Percent, Importance = 0f)]
		public float MaxSpecPoints = 1f;

		[DifficultyTip("DesignPhaseSpeedBonus", DifficultyTip.TipType.Percent, Free = true, Discretization = 0.05f)]
		public float DesignDocumentSpeedBonus = 3f;

		[DifficultyTip("AlphaPhaseSpeedBonus", DifficultyTip.TipType.Percent, Free = true, Discretization = 0.05f)]
		public float AlphaSpeedBonus = 1.2f;

		[DifficultyTip("EmployeeSkillGainBonus", DifficultyTip.TipType.Percent, Free = true, Discretization = 0.05f)]
		public float EmployeeSkillGainBonus = 2f;

		[DifficultyTip("ContractBonusIncome", DifficultyTip.TipType.Percent, Free = true, Discretization = 0.05f)]
		public float ContractIncomeFactor = 1.5f;

		[DifficultyTip("LicenseDiscount", DifficultyTip.TipType.Percent, Free = true, ActualMinValue = 0f, Discretization = 0.05f)]
		public float PlayerLicenseCostFactor = 0.5f;

		[DifficultyTip("RentDiscount", DifficultyTip.TipType.Percent, Free = true, ActualMinValue = 0f, Discretization = 0.05f)]
		public float RentCostFactor = 0.5f;

		[DifficultyTip("CreativityFactor", DifficultyTip.TipType.Desc, -1f, 2f, new string[] { "None", "Low", "Medium", "High" }, ActualMaxValue = -1f)]
		public float CreativityFactor;

		[DifficultyTip("HypeDeadline", DifficultyTip.TipType.Months)]
		public float PressReleaseHypeDeadline = 32f;

		[DifficultyTip("AudienceQualityEstimate", DifficultyTip.TipType.Percent)]
		public float MarketingEndQualityEstimate = 1.4f;

		[DifficultyTip("RecognitionInitialImportance", DifficultyTip.TipType.Desc, 0.0001f, 0.004f, new string[] { "Veryhigh", "High", "Medium", "Low" })]
		public float ProductReputationFactor = 0.004f;

		[DifficultyTip("RecognitionAffectOnSales", DifficultyTip.TipType.Desc, 0.6f, 0.8f, new string[] { "Low", "Medium", "High" }, CustomType = DifficultyTip.TipType.PercentStraight)]
		public float RecognitionSalesFactor = 0.6f;

		[DifficultyTip("AverageAIIntelligence", DifficultyTip.TipType.Percent, Free = true, ActualMinValue = 0.25f, Discretization = 0.05f, CustomType = DifficultyTip.TipType.PercentStraight)]
		public float AICompanyAverageSavy = 0.75f;

		[DifficultyTip("TaxRate", DifficultyTip.TipType.PercentStraight, Free = true, ActualMaxValue = 0.75f, Discretization = 0.05f)]
		public float Taxes = 0.1f;

		[DifficultyTip("BuyoutMonths", DifficultyTip.TipType.Straight, Free = true, Importance = 0f)]
		public float TakeoverMonths = 6f;

		[DifficultyTip("Burglaries", DifficultyTip.TipType.Bool, ActualMinValue = 0f, Importance = 0f)]
		public float Burglaries = 1f;

		[DifficultyTip("Fires", DifficultyTip.TipType.Bool, ActualMinValue = 0f, Importance = 0f)]
		public float Fires = 1f;

		[DifficultyTip("FounderDividend", DifficultyTip.TipType.PercentStraight, Importance = 0f)]
		public float FounderDividend = 0.25f;

		[DifficultyTip("Contracts", DifficultyTip.TipType.Bool, ActualMinValue = 0f)]
		public float Contracts = 1f;

		[DifficultyTip("Deals", DifficultyTip.TipType.Bool, ActualMinValue = 0f)]
		public float Deals = 1f;

		[DifficultyTip("Loans", DifficultyTip.TipType.Bool, ActualMinValue = 0f)]
		public float Loans = 1f;

		[DifficultyTip("Publisher", DifficultyTip.TipType.Bool, ActualMinValue = 0f)]
		public float Publisher = 1f;

		[DifficultyTip("ResearchAggressiveness", DifficultyTip.TipType.PercentStraight)]
		public float ResearchAggressiveness;

		public DifficultySetting()
		{
		}

		public DifficultySetting(string name)
		{
			Name = name;
		}

		public DifficultySetting(string name, DifficultySetting setting)
		{
			Name = name;
			DefaultStartMoney = setting.DefaultStartMoney;
			MaxSkillPoints = setting.MaxSkillPoints;
			MaxSpecPoints = setting.MaxSpecPoints;
			DesignDocumentSpeedBonus = setting.DesignDocumentSpeedBonus;
			AlphaSpeedBonus = setting.AlphaSpeedBonus;
			EmployeeSkillGainBonus = setting.EmployeeSkillGainBonus;
			ContractIncomeFactor = setting.ContractIncomeFactor;
			PlayerLicenseCostFactor = setting.PlayerLicenseCostFactor;
			RentCostFactor = setting.RentCostFactor;
			CreativityFactor = setting.CreativityFactor;
			PressReleaseHypeDeadline = setting.PressReleaseHypeDeadline;
			MarketingEndQualityEstimate = setting.MarketingEndQualityEstimate;
			ProductReputationFactor = setting.ProductReputationFactor;
			RecognitionSalesFactor = setting.RecognitionSalesFactor;
			AICompanyAverageSavy = setting.AICompanyAverageSavy;
			Taxes = setting.Taxes;
			TakeoverMonths = setting.TakeoverMonths;
			Burglaries = setting.Burglaries;
			Fires = setting.Fires;
			FounderDividend = setting.FounderDividend;
			Contracts = setting.Contracts;
			Deals = setting.Deals;
			Loans = setting.Loans;
			Publisher = setting.Publisher;
			ResearchAggressiveness = setting.ResearchAggressiveness;
		}

		public string GetHintString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<ValueTuple<FieldInfo, DifficultyTip>> allFields = GetAllFields();
			for (int i = 0; i < allFields.Count; i++)
			{
				ValueTuple<FieldInfo, DifficultyTip> valueTuple = allFields[i];
				float diffFieldValue = GetDiffFieldValue(valueTuple.Item1);
				string description = valueTuple.Item2.GetDescription(diffFieldValue, false);
				if (description != null)
				{
					stringBuilder.AppendLine(description);
				}
			}
			return stringBuilder.ToString().TrimEnd();
		}

		public float GetDiffFieldValue(FieldInfo difficultyField)
		{
			object value;
			if ((value = difficultyField.GetValue(this)) is float)
			{
				return (float)value;
			}
			return 0f;
		}

		public void SetDiffFieldValue(FieldInfo difficultyField, float val)
		{
			if (difficultyField.FieldType == typeof(float))
			{
				difficultyField.SetValue(this, val);
			}
		}

		public override string ToString()
		{
			return Name;
		}

		public void WriteData(Stream st)
		{
			st.WriteStringUTF8(Name);
			List<ValueTuple<FieldInfo, DifficultyTip>> allFields = GetAllFields();
			for (int i = 0; i < allFields.Count; i++)
			{
				st.WriteFloat((float)allFields[i].Item1.GetValue(this));
			}
		}

		public bool IsSame(DifficultySetting setting)
		{
			List<ValueTuple<FieldInfo, DifficultyTip>> allFields = GetAllFields();
			for (int i = 0; i < allFields.Count; i++)
			{
				if (!allFields[i].Item1.GetValue(this).Equals(allFields[i].Item1.GetValue(setting)))
				{
					return false;
				}
			}
			return true;
		}

		public static DifficultySetting ReadData(Stream st)
		{
			DifficultySetting difficultySetting = new DifficultySetting(st.ReadStringUTF8());
			List<ValueTuple<FieldInfo, DifficultyTip>> allFields = GetAllFields();
			for (int i = 0; i < allFields.Count; i++)
			{
				allFields[i].Item1.SetValue(difficultySetting, st.ReadFloat());
			}
			return difficultySetting;
		}
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class DifficultyTip : Attribute
	{
		public enum TipType
		{
			Percent = 0,
			Money = 1,
			Months = 2,
			Straight = 3,
			Desc = 4,
			PercentStraight = 5,
			Bool = 6
		}

		public string Loc;

		public string[] Desc;

		public float Min;

		public float Max;

		public float Importance = 1f;

		public TipType Type;

		public TipType CustomType;

		public bool Free;

		public float Discretization = 1f;

		public float ActualMinValue = float.MaxValue;

		public float ActualMaxValue = float.MinValue;

		public DifficultyTip(string loc, TipType type)
		{
			Loc = loc;
			Type = type;
			CustomType = type;
		}

		public DifficultyTip(string loc, TipType type, float min, float max, params string[] desc)
			: this(loc, type)
		{
			Min = min;
			Max = max;
			Desc = desc;
			Type = type;
			CustomType = type;
		}

		public string GetDescription(float v, bool forCustom)
		{
			string text;
			switch (forCustom ? CustomType : Type)
			{
			case TipType.Percent:
				if (!forCustom && v == 1f)
				{
					return null;
				}
				text = (v - 1f).ToPercent(true, true);
				break;
			case TipType.Money:
				text = v.Currency();
				break;
			case TipType.Months:
				text = SDateTime.DateDiff(Mathf.RoundToInt(v * (float)GameSettings.DaysPerMonth));
				break;
			case TipType.Straight:
				text = v.ToString("0.#");
				break;
			case TipType.Desc:
				text = Desc[v.MapRange(Min, Max, 0f, 1f, true).Quantize(Desc.Length)].Loc();
				break;
			case TipType.PercentStraight:
				text = v.ToPercent();
				break;
			case TipType.Bool:
				if (v > 0f)
				{
					if (!forCustom)
					{
						return null;
					}
					text = "Yes".Loc();
				}
				else
				{
					text = "No".Loc();
				}
				break;
			default:
				return null;
			}
			if (forCustom)
			{
				return text;
			}
			return Loc.Loc() + ": " + text.BlueHighlight();
		}
	}

	public static DifficultySetting[] NetworkDifficultyComp;

	public static readonly DifficultySetting DefaultSettings;

	private static List<ValueTuple<FieldInfo, DifficultyTip>> _difficultyFields;

	public static Dictionary<string, DifficultySetting> Difficulties;

	public static DifficultySetting Difficulty
	{
		get
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				return GameSettings.Instance.Difficulty;
			}
			return DefaultSettings;
		}
	}

	static DifficultyValues()
	{
		DefaultSettings = new DifficultySetting("Easy");
		_difficultyFields = null;
		Difficulties = new Dictionary<string, DifficultySetting>
		{
			{
				"Beginner",
				new DifficultySetting("Beginner")
				{
					DefaultStartMoney = 50000f,
					MaxSkillPoints = 2.5f,
					MaxSpecPoints = 1f,
					DesignDocumentSpeedBonus = 3f,
					AlphaSpeedBonus = 1.2f,
					EmployeeSkillGainBonus = 2f,
					ContractIncomeFactor = 1.5f,
					PlayerLicenseCostFactor = 0.5f,
					RentCostFactor = 0.5f,
					CreativityFactor = 0f,
					PressReleaseHypeDeadline = 32f,
					ProductReputationFactor = 0.004f,
					RecognitionSalesFactor = 0.6f,
					AICompanyAverageSavy = 0.75f,
					Taxes = 0f,
					MarketingEndQualityEstimate = 1.4f,
					FounderDividend = 0.2f
				}
			},
			{ "Easy", DefaultSettings },
			{
				"Medium",
				new DifficultySetting("Medium")
				{
					DefaultStartMoney = 25000f,
					MaxSkillPoints = 2f,
					MaxSpecPoints = 0.75f,
					DesignDocumentSpeedBonus = 2f,
					AlphaSpeedBonus = 1.05f,
					EmployeeSkillGainBonus = 1.5f,
					ContractIncomeFactor = 1.25f,
					PlayerLicenseCostFactor = 1f,
					RentCostFactor = 1f,
					CreativityFactor = 1f,
					PressReleaseHypeDeadline = 24f,
					ProductReputationFactor = 0.003f,
					RecognitionSalesFactor = 0.65f,
					AICompanyAverageSavy = 0.875f,
					Taxes = 0.15f,
					MarketingEndQualityEstimate = 1.2f,
					TakeoverMonths = 3f,
					FounderDividend = 0.3f,
					ResearchAggressiveness = 0.5f
				}
			},
			{
				"Hard",
				new DifficultySetting("Hard")
				{
					DefaultStartMoney = 10000f,
					MaxSkillPoints = 1.5f,
					MaxSpecPoints = 0.75f,
					DesignDocumentSpeedBonus = 2f,
					AlphaSpeedBonus = 1.05f,
					EmployeeSkillGainBonus = 1.5f,
					ContractIncomeFactor = 1f,
					PlayerLicenseCostFactor = 1f,
					RentCostFactor = 1f,
					CreativityFactor = 2f,
					PressReleaseHypeDeadline = 24f,
					ProductReputationFactor = 0.002f,
					RecognitionSalesFactor = 0.7f,
					AICompanyAverageSavy = 0.875f,
					Taxes = 0.2f,
					MarketingEndQualityEstimate = 1f,
					TakeoverMonths = 2f,
					FounderDividend = 0.5f,
					ResearchAggressiveness = 0.75f
				}
			},
			{
				"VeryHard",
				new DifficultySetting("VeryHard")
				{
					DefaultStartMoney = 0f,
					MaxSkillPoints = 1f,
					MaxSpecPoints = 0.5f,
					DesignDocumentSpeedBonus = 1f,
					AlphaSpeedBonus = 1f,
					EmployeeSkillGainBonus = 1f,
					ContractIncomeFactor = 1f,
					PlayerLicenseCostFactor = 1f,
					RentCostFactor = 1f,
					CreativityFactor = 2f,
					PressReleaseHypeDeadline = 16f,
					ProductReputationFactor = 0.0001f,
					RecognitionSalesFactor = 0.8f,
					AICompanyAverageSavy = 1f,
					Taxes = 0.25f,
					MarketingEndQualityEstimate = 1f,
					TakeoverMonths = 1f,
					FounderDividend = 0.75f,
					ResearchAggressiveness = 1f
				}
			},
			{
				"Impossible",
				new DifficultySetting("Impossible")
				{
					DefaultStartMoney = 100000f,
					MaxSkillPoints = 1f,
					MaxSpecPoints = 0.5f,
					DesignDocumentSpeedBonus = 1f,
					AlphaSpeedBonus = 1f,
					EmployeeSkillGainBonus = 1f,
					ContractIncomeFactor = 1f,
					PlayerLicenseCostFactor = 1f,
					RentCostFactor = 1f,
					CreativityFactor = 2f,
					PressReleaseHypeDeadline = 16f,
					ProductReputationFactor = 0.0001f,
					RecognitionSalesFactor = 0.8f,
					AICompanyAverageSavy = 1f,
					Taxes = 0.25f,
					MarketingEndQualityEstimate = 1f,
					TakeoverMonths = 1f,
					FounderDividend = 0.75f,
					Contracts = 0f,
					Deals = 0f,
					Loans = 0f,
					Publisher = 0f,
					ResearchAggressiveness = 1f
				}
			}
		};
		NetworkDifficultyComp = new DifficultySetting[6]
		{
			GetDifficulty("Beginner"),
			GetDifficulty("Easy"),
			GetDifficulty("Medium"),
			GetDifficulty("Hard"),
			GetDifficulty("VeryHard"),
			GetDifficulty("Impossible")
		};
	}

	public static DifficultySetting GetDifficulty(string difficulty)
	{
		return Difficulties.GetOrDefault(difficulty, DefaultSettings);
	}

	public static List<ValueTuple<FieldInfo, DifficultyTip>> GetAllFields()
	{
		if (_difficultyFields == null)
		{
			_difficultyFields = new List<ValueTuple<FieldInfo, DifficultyTip>>();
			FieldInfo[] fields = typeof(DifficultySetting).GetFields(BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				DifficultyTip customAttribute = fieldInfo.GetCustomAttribute<DifficultyTip>();
				if (customAttribute != null)
				{
					_difficultyFields.Add(new ValueTuple<FieldInfo, DifficultyTip>(fieldInfo, customAttribute));
				}
			}
		}
		return _difficultyFields;
	}

	public static DifficultySetting TryGetEquivalent(DifficultySetting setting)
	{
		foreach (DifficultySetting value in Difficulties.Values)
		{
			if (setting.IsSame(value))
			{
				return value;
			}
		}
		return null;
	}

	public static DifficultySetting FindClosest(DifficultySetting setting, IEnumerable<DifficultySetting> settings)
	{
		List<ValueTuple<FieldInfo, DifficultyTip>> allFields = GetAllFields();
		Dictionary<DifficultySetting, float> dictionary = Difficulties.Values.ToDictionary((DifficultySetting x) => x, (DifficultySetting x) => 0f);
		foreach (var item in allFields)
		{
			if (!(item.Item2.Importance > 0f))
			{
				continue;
			}
			float num = item.Item2.ActualMinValue;
			float num2 = item.Item2.ActualMaxValue;
			float num3 = (float)item.Item1.GetValue(setting);
			foreach (DifficultySetting setting2 in settings)
			{
				float b = Mathf.Min((float)item.Item1.GetValue(setting2));
				num = Mathf.Min(num, b);
				num2 = Mathf.Max(num2, b);
			}
			foreach (DifficultySetting setting3 in settings)
			{
				float value = Mathf.Abs(Mathf.Min((float)item.Item1.GetValue(setting3)) - num3) / (num2 - num) * item.Item2.Importance;
				dictionary.AddUp(setting3, value);
			}
		}
		return dictionary.MinInstance((KeyValuePair<DifficultySetting, float> x) => x.Value).Key;
	}
}
