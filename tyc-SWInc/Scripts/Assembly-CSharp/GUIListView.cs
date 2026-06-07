using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevConsole;
using SINetworking;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUIListView : MonoBehaviour
{
	public class ColumnDef
	{
		public GUIColumn.ColumnType? TypeOverride;

		public FilterType? FilterType;

		public string Header;

		public Func<object, object> Label;

		public Comparison<object> Comparison;

		public Action<object> Action;

		public Action<object, object> SetValue;

		public Func<object, object> FilterConversion;

		public Func<object, double> Total;

		public Func<double, object> TotalLabel;

		public GUIColumn.TotalType TotalDefault = GUIColumn.TotalType.Sum;

		public GUIColumn.TotalType TotalTypes = GUIColumn.TotalType.All;

		public float? Width;

		public bool Volatile;

		public bool DoubleClickAction;

		public string Tip;
	}

	public class ColumnDefinition<T> : ColumnDef
	{
		public ColumnDefinition(string header, Func<T, object> label, Func<T, string> comparison, bool vola, float? width = null, FilterType? filterType = null, Func<T, object> filter = null, GUIColumn.ColumnType? typeOverride = null, Action<T, object> setValue = null)
		{
			Header = header;
			Label = (object x) => label((T)x);
			Comparison = (object x, object y) => Utilities.CompareString(comparison, (T)x, (T)y);
			Volatile = vola;
			Width = width;
			FilterType = filterType;
			if (filter != null)
			{
				FilterConversion = (object x) => filter((T)x);
			}
			TypeOverride = typeOverride;
			if (setValue != null)
			{
				SetValue = delegate(object x, object y)
				{
					setValue((T)x, y);
				};
			}
		}

		public ColumnDefinition(string header, Func<T, float> label, bool vola, float? width = null, bool currency = true, bool includeDecimal = true, bool progressBar = false, bool withTotal = true, GUIColumn.TotalType totalOverride = GUIColumn.TotalType.None)
		{
			Header = header;
			if (withTotal)
			{
				Total = (object x) => label((T)x);
			}
			if (currency)
			{
				Label = (object x) => label((T)x).Currency();
				Comparison = (object x, object y) => Utilities.CompareNumber(label, (T)x, (T)y);
				FilterConversion = (object x) => label((T)x).CurrencyMul();
				if (withTotal)
				{
					TotalLabel = (double x) => x.Currency();
					TotalDefault = ((totalOverride == GUIColumn.TotalType.None) ? GUIColumn.TotalType.Sum : totalOverride);
				}
			}
			else if (progressBar)
			{
				Label = (object x) => label((T)x);
				Comparison = (object x, object y) => Utilities.CompareNumber(label, (T)x, (T)y);
				FilterConversion = (object x) => label((T)x) * 100f;
				TypeOverride = GUIColumn.ColumnType.ProgressBar;
				if (withTotal)
				{
					TotalLabel = (double x) => (float)x;
					TotalDefault = ((totalOverride == GUIColumn.TotalType.None) ? GUIColumn.TotalType.MathMean : totalOverride);
				}
				TotalTypes = GUIColumn.TotalType.Averages | GUIColumn.TotalType.Minimum | GUIColumn.TotalType.Maximum;
			}
			else
			{
				Label = (object x) => label((T)x).ToPercent(includeDecimal);
				Comparison = (object x, object y) => Utilities.CompareNumber(label, (T)x, (T)y);
				FilterConversion = (object x) => label((T)x) * 100f;
				if (withTotal)
				{
					TotalLabel = (double x) => x.ToPercent(includeDecimal);
					TotalDefault = ((totalOverride == GUIColumn.TotalType.None) ? GUIColumn.TotalType.MathMean : totalOverride);
				}
				TotalTypes = GUIColumn.TotalType.NoSum;
			}
			Volatile = vola;
			Width = width;
			FilterType = GUIListView.FilterType.Number;
		}

		public ColumnDefinition(string header, Func<T, double> label, bool vola, float? width = null, bool currency = true, bool includeDecimal = true, bool withTotal = true, GUIColumn.TotalType totalOverride = GUIColumn.TotalType.None)
		{
			Header = header;
			if (withTotal)
			{
				Total = (object x) => label((T)x);
			}
			if (currency)
			{
				Label = (object x) => label((T)x).Currency();
				Comparison = (object x, object y) => Utilities.CompareNumber(label, (T)x, (T)y);
				FilterConversion = (object x) => label((T)x).CurrencyMul();
				if (withTotal)
				{
					TotalLabel = (double x) => x.Currency();
					TotalDefault = ((totalOverride == GUIColumn.TotalType.None) ? GUIColumn.TotalType.Sum : totalOverride);
				}
			}
			else
			{
				Label = (object x) => label((T)x).ToPercent(includeDecimal);
				Comparison = (object x, object y) => Utilities.CompareNumber(label, (T)x, (T)y);
				FilterConversion = (object x) => label((T)x) * 100.0;
				if (withTotal)
				{
					TotalLabel = (double x) => x.ToPercent(includeDecimal);
					TotalDefault = ((totalOverride == GUIColumn.TotalType.None) ? GUIColumn.TotalType.MathMean : totalOverride);
				}
				TotalTypes = GUIColumn.TotalType.NoSum;
			}
			Volatile = vola;
			Width = width;
			FilterType = GUIListView.FilterType.Number;
		}

		public ColumnDefinition(string header, Func<T, int> label, bool vola, float? width = null, bool thouSep = true, bool withTotal = true, GUIColumn.TotalType totalOverride = GUIColumn.TotalType.Sum, GUIColumn.TotalType validTotals = GUIColumn.TotalType.All)
		{
			Header = header;
			if (withTotal)
			{
				Total = (object x) => label((T)x);
			}
			TotalTypes = validTotals;
			if (thouSep)
			{
				Label = (object x) => label((T)x).ToString("N0");
				if (withTotal)
				{
					TotalLabel = (double x) => x.ToString("N0");
				}
			}
			else
			{
				Label = (object x) => label((T)x).ToString();
				if (withTotal)
				{
					TotalLabel = (double x) => x.ToString();
				}
			}
			TotalDefault = totalOverride;
			Comparison = (object x, object y) => Utilities.CompareNumber((T z) => label(z), (T)x, (T)y);
			Volatile = vola;
			Width = width;
			FilterType = GUIListView.FilterType.Number;
			FilterConversion = (object x) => (float)label((T)x);
		}

		public ColumnDefinition(string header, Func<T, uint> label, bool vola, float? width = null, bool withTotal = true, GUIColumn.TotalType totalOverride = GUIColumn.TotalType.Sum)
		{
			Header = header;
			Label = (object x) => label((T)x).ToString("N0");
			if (withTotal)
			{
				Total = (object x) => label((T)x);
				TotalLabel = (double x) => x.ToString("N0");
			}
			TotalDefault = totalOverride;
			Comparison = (object x, object y) => Utilities.CompareNumber((T z) => label(z), (T)x, (T)y);
			Volatile = vola;
			Width = width;
			FilterType = GUIListView.FilterType.Number;
			FilterConversion = (object x) => (float)label((T)x);
		}

		public ColumnDefinition(string header, Func<T, SDateTime> label, bool vola, float? width = null)
		{
			Header = header;
			Label = (object x) => label((T)x).ToCompactString();
			Comparison = (object x, object y) => Utilities.CompareNumber((T z) => label(z).ToInt(), (T)x, (T)y);
			Volatile = vola;
			Width = width;
			Total = (object x) => label((T)x).ToInt();
			TotalLabel = (double x) => SDateTime.FromInt((int)Math.Round(x)).ToCompactString();
			TotalTypes = GUIColumn.TotalType.NoSum;
			TotalDefault = GUIColumn.TotalType.Range;
			FilterType = GUIListView.FilterType.Date;
			FilterConversion = (object x) => label((T)x);
		}

		public ColumnDefinition(string header, Func<T, SDateTime?> label, bool vola, float? width = null, bool fullDate = false)
		{
			Header = header;
			if (fullDate)
			{
				Label = delegate(object x)
				{
					SDateTime? sDateTime = label((T)x);
					return (sDateTime.HasValue ? sDateTime.GetValueOrDefault().ToCompactString2() : null) ?? "NotApplicableAbbr".Loc();
				};
			}
			else
			{
				Label = delegate(object x)
				{
					SDateTime? sDateTime = label((T)x);
					return (sDateTime.HasValue ? sDateTime.GetValueOrDefault().ToCompactString() : null) ?? "NotApplicableAbbr".Loc();
				};
			}
			Comparison = (object x, object y) => Utilities.CompareNumber(delegate(T z)
			{
				SDateTime? sDateTime = label(z);
				return sDateTime.HasValue ? sDateTime.GetValueOrDefault().ToInt() : (-1);
			}, (T)x, (T)y);
			Volatile = vola;
			Width = width;
			Total = delegate(object x)
			{
				SDateTime? sDateTime = label((T)x);
				return (!sDateTime.HasValue) ? double.NaN : ((double)sDateTime.Value.ToInt());
			};
			TotalLabel = delegate(double x)
			{
				int num = (int)Math.Round(x);
				return (num != 0) ? SDateTime.FromInt(num).ToCompactString() : "NotApplicableAbbr".Loc();
			};
			TotalTypes = GUIColumn.TotalType.NoSum;
			TotalDefault = GUIColumn.TotalType.Range;
			FilterType = GUIListView.FilterType.Date;
			FilterConversion = (object x) => label((T)x) ?? default(SDateTime);
		}

		public ColumnDefinition(string header, Func<T, bool> label, bool vola, float? width = null, Action<T, bool> setValue = null)
		{
			Header = header;
			Comparison = (object x, object y) => Utilities.CompareNumber((T z) => label(z) ? 1 : 0, (T)x, (T)y);
			Volatile = vola;
			Width = width;
			FilterType = GUIListView.FilterType.Bool;
			FilterConversion = (object x) => label((T)x);
			if (setValue != null)
			{
				Label = (object x) => label((T)x);
				TypeOverride = GUIColumn.ColumnType.Toggle;
				SetValue = delegate(object x, object y)
				{
					setValue((T)x, (bool)y);
				};
			}
			else
			{
				Label = (object x) => label((T)x).YesNo();
			}
		}

		public ColumnDefinition(string header, Func<T, string> label, bool vola, float? width = null, bool filter = true, bool filterQuery = false, bool filterRoom = false)
		{
			Header = header;
			Label = (object x) => label((T)x);
			Comparison = (object x, object y) => Utilities.CompareString((T z) => label(z), (T)x, (T)y);
			Volatile = vola;
			Width = width;
			if (filter)
			{
				FilterType = GUIListView.FilterType.Name;
			}
			else if (filterQuery)
			{
				FilterType = GUIListView.FilterType.Query;
			}
			else if (filterRoom)
			{
				FilterType = GUIListView.FilterType.RoomGroup;
			}
		}

		public ColumnDefinition(string header, Func<T, object> label, Func<T, float> comparison, bool vola, float? width = null, FilterType? filterType = null, Func<T, object> filter = null, GUIColumn.ColumnType? typeOverride = null, Action<T, object> setValue = null, Func<double, object> totalLabel = null, GUIColumn.TotalType validTotals = GUIColumn.TotalType.Averages, GUIColumn.TotalType defaultTotal = GUIColumn.TotalType.MathMean, Func<T, double> totalConversion = null)
		{
			Header = header;
			Label = (object x) => label((T)x);
			Comparison = (object x, object y) => Utilities.CompareNumber(comparison, (T)x, (T)y);
			Volatile = vola;
			Width = width;
			FilterType = filterType;
			if (filter != null)
			{
				FilterConversion = (object x) => filter((T)x);
			}
			if (totalLabel != null)
			{
				if (totalConversion != null)
				{
					Total = (object x) => totalConversion((T)x);
				}
				else
				{
					Total = (object x) => comparison((T)x);
				}
				TotalLabel = totalLabel;
			}
			TotalTypes = validTotals;
			TotalDefault = defaultTotal;
			TypeOverride = typeOverride;
			if (setValue != null)
			{
				SetValue = delegate(object x, object y)
				{
					setValue((T)x, y);
				};
			}
		}

		public ColumnDefinition(string header, Action<T> action, float? width = null)
		{
			Header = header;
			Action = delegate(object x)
			{
				action((T)x);
			};
			Width = width;
			Volatile = false;
		}
	}

	public enum FilterType
	{
		None = 0,
		Number = 1,
		Name = 2,
		Date = 3,
		Bool = 4,
		Bitmask = 5,
		Trait = 6,
		Query = 7,
		RoomGroup = 8
	}

	public Dictionary<string, ColumnDef> ColumnDefinitions = new Dictionary<string, ColumnDef>
	{
		{
			"GenericName",
			new ColumnDefinition<object>("Name", (object x) => x.ToString(), false, null, false, true)
		},
		{
			"SoftwareFeatureName",
			new ColumnDefinition<KeyValuePair<string, string>>("Name", (KeyValuePair<string, string> x) => Localization.GetFeature(x.Key, x.Value)[0], false, null, false)
		},
		{
			"AddonFeatureName",
			new ColumnDefinition<KeyValuePair<AddOnFeature, uint>>("Name", (KeyValuePair<AddOnFeature, uint> x) => x.Key.GetLocalizedName(), false, null, false)
		},
		{
			"AddonFeatureFactor",
			new ColumnDefinition<KeyValuePair<AddOnFeature, uint>>("Multiplier", (KeyValuePair<AddOnFeature, uint> x) => x.Key.GetAmount(x.Value), (KeyValuePair<AddOnFeature, uint> x) => x.Value, false)
		},
		{
			"EmployeeName",
			new ColumnDefinition<Actor>("Name", (Actor x) => x.employee.FullName, false, 145f, false, true)
		},
		{
			"EmployeeRole",
			new ColumnDefinition<Actor>("Role", (Actor x) => x, (Actor x) => Employee.RoleBitOrder(x.employee.CurrentRoleBit, x.IsMentor), true, 120f, FilterType.Bitmask, (Actor x) => x.employee.CurrentRoleBit, GUIColumn.ColumnType.Role)
		},
		{
			"EmployeeState",
			new ColumnDefinition<Actor>("Status", (Actor x) => x.CurrentState(false), true)
		},
		{
			"EmployeeArrival",
			new ColumnDefinition<Actor>("Arrival", GetArrival, (Actor x) => GetArrivalOrder(x), true)
		},
		{
			"EmployeeTeam",
			new ColumnDefinition<Actor>("Team", (Actor x) => x.Team ?? "None".Loc(), true)
		},
		{
			"EmployeeSalary",
			new ColumnDefinition<Actor>("Salary", (Actor x) => x.GetMonthlySalary(), true, 84f)
		},
		{
			"EmployeeWorth",
			new ColumnDefinition<Actor>("Request", (Actor x) => ((WageWindow.GetMinSalary(x, x.employee.Worth(-2), true) - x.GetRealSalary()) * (float)x.GetWorkHours(true)).CurrencyDiff(), (Actor x) => WageWindow.GetMinSalary(x, x.employee.Worth(-2), true) - x.GetRealSalary(), false, 92f, FilterType.Number, (Actor x) => (x.employee.Worth(-2) - x.GetRealSalary()).CurrencyMul())
		},
		{
			"EmployeeVacation",
			new ColumnDefinition<Actor>("Vacation", (Actor x) => (!x.employee.Founder && x.GetBenefitValue("Vacation months") != 0f) ? new SDateTime?(x.AlternateVacation) : ((SDateTime?)null), true)
		},
		{
			"EmployeeEffectiveness",
			new ColumnDefinition<Actor>("Effectiveness", (Actor x) => x.Effectiveness, true, null, false, true, true, true, GUIColumn.TotalType.Minimum)
		},
		{
			"EmployeeCompatibility",
			new ColumnDefinition<Actor>("Team Compatibility", (Actor x) => x.TeamCompatibility, true, 145f, false, true, true, true, GUIColumn.TotalType.Minimum)
		},
		{
			"EmployeeCohesion",
			new ColumnDefinition<Actor>("TeamCohesion", (Actor x) => x.employee.GetCohesion(x.GetTeam()), true, 60f, false, false, true, true, GUIColumn.TotalType.Minimum)
			{
				Tip = "TeamCohesionTip"
			}
		},
		{
			"EmployeeSatisfaction",
			new ColumnDefinition<Actor>("Satisfaction", (Actor z) => z.employee.JobSatisfaction, true, null, false, true, true, true, GUIColumn.TotalType.Minimum)
		},
		{
			"EmployeeAge",
			new ColumnDefinition<Actor>("Age", (Actor x) => x.employee.GetAgeFlat().ToString(), (Actor z) => z.employee.GetAge(), true, 65f, FilterType.Number, (Actor x) => x.employee.GetAge(), null, null, (double x) => x.ToString("0.#"), GUIColumn.TotalType.NoSum, GUIColumn.TotalType.Range, (Actor x) => x.employee.GetAgeFlat())
		},
		{
			"EmployeeYears",
			new ColumnDefinition<Actor>("Years", (Actor x) => (TimeOfDay.Instance.Year - x.employee.Hired.Year).ToString(), (Actor z) => -z.employee.Hired.ToInt(), false, 78f, FilterType.Number, (Actor x) => SDateTime.GetMonths(x.employee.Hired, SDateTime.Now()) / 12f, null, null, (double x) => x.ToString("F0"), GUIColumn.TotalType.All, GUIColumn.TotalType.Sum, (Actor x) => TimeOfDay.Instance.Year - x.employee.Hired.Year)
		},
		{
			"EmployeeSkillLead",
			new ColumnDefinition<Actor>("Lead skill", (Actor x) => x.employee.GetSkill(Employee.EmployeeRole.Lead), true, 75f, false, true, true)
		},
		{
			"EmployeeSkillCode",
			new ColumnDefinition<Actor>("Code skill", (Actor x) => x.employee.GetSkill(Employee.EmployeeRole.Programmer), true, 80f, false, true, true)
		},
		{
			"EmployeeSkillDesign",
			new ColumnDefinition<Actor>("Design skill", (Actor x) => x.employee.GetSkill(Employee.EmployeeRole.Designer), true, 90f, false, true, true)
		},
		{
			"EmployeeSkillArt",
			new ColumnDefinition<Actor>("Art skill", (Actor x) => x.employee.GetSkill(Employee.EmployeeRole.Artist), true, 75f, false, true, true)
		},
		{
			"EmployeeSkillMarketing",
			new ColumnDefinition<Actor>("Service skill", (Actor x) => x.employee.GetSkill(Employee.EmployeeRole.Service), true, 115f, false, true, true)
		},
		{
			"EmployeeValidEdu",
			new ColumnDefinition<Actor>("Valid", (Actor x) => CheckValidEdu(x, false, false), (Actor x) => (int)CheckValidEdu(x, true, false), true, 24f, FilterType.Bool, (Actor x) => CheckValidEdu(x, false, true), GUIColumn.ColumnType.WarningIcon)
		},
		{
			"EmployeeDetails",
			new ColumnDefinition<Actor>("Details", delegate(Actor x)
			{
				HUD.Instance.DetailWindow.Show(x, true, false);
			}, 64f)
		},
		{
			"EmployeeSickDays",
			new ColumnDefinition<Actor>("Sick days", (Actor x) => x.SickDays, true, 100f)
		},
		{
			"EmployeeXP",
			new ColumnDefinition<Actor>("Next class", (Actor x) => x.employee.NextLevel(x), true, null, false, true, true, true, GUIColumn.TotalType.Maximum)
		},
		{
			"EmployeeEdAvailable",
			new ColumnDefinition<Actor>("Available", (Actor x) => x.employee.GetSpecPointsAvailable(HUD.Instance.educationWindow.SelectedRole, x), true)
		},
		{
			"EmployeeEdLeft",
			new ColumnDefinition<Actor>("LeftToSpend", (Actor x) => x.employee.GetSpecPointsLeft(HUD.Instance.educationWindow.SelectedRole, x), true)
		},
		{
			"EmployeeTraits",
			new ColumnDefinition<Actor>("Traits", (Actor x) => x.employee.Traits, (Actor x) => (float)x.employee.Traits, false, 96f, FilterType.Trait, (Actor x) => x.employee.Traits, GUIColumn.ColumnType.Trait)
		},
		{
			"EmployeeCreativity",
			new ColumnDefinition<Actor>("Creativity", (Actor x) => (!(x.employee.CreativityKnown >= 1f)) ? (">" + x.employee.GetLowerCreativity().ToPercent(false)) : x.employee.GetLowerCreativity().ToPercent(), (Actor x) => x.employee.GetLowerCreativity(), true, 90f, FilterType.Number, (Actor x) => x.employee.GetLowerCreativity() * 100f, null, null, (double x) => x.ToPercent(), GUIColumn.TotalType.NoSum, GUIColumn.TotalType.Range)
		},
		{
			"EmployeeInspiration",
			new ColumnDefinition<Actor>("Inspiration", (Actor x) => Mathf.Min(1f, x.employee.GetActualInspiration()), true, 90f, false, true, true, true, GUIColumn.TotalType.Minimum)
		},
		{
			"ProductName",
			new ColumnDefinition<SoftwareProduct>("Name", (SoftwareProduct x) => x.Name, false, 220f, false, true)
		},
		{
			"ProductType",
			new ColumnDefinition<SoftwareProduct>("Category", (SoftwareProduct x) => x.Category.Name.LocSWC(x.Type.Name), (SoftwareProduct z) => z.Category.Name, false, 80f, FilterType.Name)
		},
		{
			"ProductNeedType",
			new ColumnDefinition<SoftwareProduct>("Type", (SoftwareProduct x) => x.Type.Name.LocSW(), (SoftwareProduct z) => z.Type.Name, false, 140f, FilterType.Name)
		},
		{
			"ProductCompany",
			new ColumnDefinition<SoftwareProduct>("Company", (SoftwareProduct x) => x.DevCompany.Name, false, 200f)
		},
		{
			"ProductInventor",
			new ColumnDefinition<SoftwareProduct>("Creator", (SoftwareProduct z) => z.InventorID == z.DevCompany.ID, false)
		},
		{
			"ProductArchived",
			new ColumnDefinition<SoftwareProduct>("Archived", (SoftwareProduct z) => z.Archived || z.PlayerArchived, false)
		},
		{
			"ProductRelease",
			new ColumnDefinition<SoftwareProduct>("Releasedate", (SoftwareProduct x) => (!x.IsMock) ? new SDateTime?(x.Release) : ((SDateTime?)null), false, 125f)
		},
		{
			"ProductReview",
			new ColumnDefinition<SoftwareProduct>("ReviewScore", (SoftwareProduct x) => RoundReviewScore(x.ReviewScore), (SoftwareProduct x) => x.ReviewScore, true, 85f, FilterType.Number, (SoftwareProduct x) => x.ReviewScore * 100f, GUIColumn.ColumnType.Stars5)
		},
		{
			"ProductQuality",
			new ColumnDefinition<SoftwareProduct>("Quality", (SoftwareProduct x) => (!x.IsMock) ? SoftwareType.GetQualityLabel(x.RealQuality) : "NotApplicableAbbr".Loc(), (SoftwareProduct z) => (float)z.RealQuality, false, 80f, FilterType.Name, null, null, null, SoftwareType.GetQualityLabel, GUIColumn.TotalType.NoSum, GUIColumn.TotalType.Range)
		},
		{
			"ProductCreativity",
			new ColumnDefinition<SoftwareProduct>("Creativity", (SoftwareProduct x) => SoftwareType.GetCreativityLabel(x.CreativityScore), (SoftwareProduct z) => (float)z.CreativityScore, false, 80f, FilterType.Name, null, null, null, (double x) => SoftwareType.GetCreativityLabel(x, false), GUIColumn.TotalType.NoSum, GUIColumn.TotalType.Range)
		},
		{
			"ProductAwareness",
			new ColumnDefinition<SoftwareProduct>("Marketing", (SoftwareProduct x) => SoftwareType.GetAwarenessLabel(x.GetAwareness()), (SoftwareProduct z) => z.GetAwareness(), true, null, FilterType.Name, null, null, null, (double x) => SoftwareType.GetAwarenessLabel((float)x), GUIColumn.TotalType.NoSum, GUIColumn.TotalType.Range)
		},
		{
			"ProductCost",
			new ColumnDefinition<SoftwareProduct>("License", (SoftwareProduct z) => z.HasToPay(GameSettings.Instance.MyCompany) ? z.GetLicenseCost(true) : 0f, false, null, true, true, true, GUIColumn.TotalType.Range)
		},
		{
			"ProductIncome",
			new ColumnDefinition<SoftwareProduct>("Profit", (SoftwareProduct z) => z.Sum - z.Loss, true)
		},
		{
			"ProductAddonIncome",
			new ColumnDefinition<SoftwareProduct>("AddonProfit", (SoftwareProduct z) => z.AddonProfit, true)
		},
		{
			"ProductSource",
			new ColumnDefinition<SoftwareProduct>("Open source", (SoftwareProduct z) => z.OpenSource, false)
		},
		{
			"ProductLoss",
			new ColumnDefinition<SoftwareProduct>("Expenses", (SoftwareProduct z) => z.Loss, true)
		},
		{
			"ProductUserBase",
			new ColumnDefinition<SoftwareProduct>("Active users", (SoftwareProduct z) => z.Userbase, true, 115f)
		},
		{
			"ProductPrice",
			new ColumnDefinition<SoftwareProduct>("Retail price", (SoftwareProduct z) => z.Price, false, null, true, true, true, GUIColumn.TotalType.Range)
		},
		{
			"ProductUnitSales",
			new ColumnDefinition<SoftwareProduct>("Net units sold", (SoftwareProduct z) => z.UnitSum, true)
		},
		{
			"ProductCopies",
			new ColumnDefinition<SoftwareProduct>("In stock", (SoftwareProduct z) => z.PhysicalCopies, true)
		},
		{
			"ProductStorage",
			new ColumnDefinition<SoftwareProduct>("In storage", (SoftwareProduct z) => GameSettings.Instance.GetPrintsInStorage(z), true)
			{
				Tip = "ProductStorageTip"
			}
		},
		{
			"ProductLastMonth",
			new ColumnDefinition<SoftwareProduct>("PastDayMonth", (SoftwareProduct z) => z.GetLastDayIncome(false), true)
		},
		{
			"ProductRefunds",
			new ColumnDefinition<SoftwareProduct>("Refunds", (SoftwareProduct z) => z.RefundSum, true)
		},
		{
			"ProductHasSequel",
			new ColumnDefinition<SoftwareProduct>("Has sequel", (SoftwareProduct z) => z.HasSequel, true)
		},
		{
			"ProductDetail",
			new ColumnDefinition<SoftwareProduct>("Details", delegate(SoftwareProduct x)
			{
				HUD.Instance.GetProductWindow(null).ShowProductDetails(x);
			})
		},
		{
			"ProductSupport",
			new ColumnDefinition<SoftwareProduct>("Supported", (SoftwareProduct x) => CheckCompat(x, false, false), (SoftwareProduct x) => (int)CheckCompat(x, true, false), false, 28f, FilterType.Name, (SoftwareProduct x) => CheckCompat(x, false, true), GUIColumn.ColumnType.WarningIcon)
		},
		{
			"ProductTechLevel",
			new ColumnDefinition<SoftwareProduct>("Tech level", (SoftwareProduct x) => (ProductWindow.TechSpecs != null) ? x.TechLevels.GetOrDefault(ProductWindow.TechSpecs[0], (TechLevel z) => z.ActualYear, 0) : 0, false, null, false, true, GUIColumn.TotalType.Range, GUIColumn.TotalType.NoSum)
		},
		{
			"ProductPublisher",
			new ColumnDefinition<SoftwareProduct>("Publisher", (SoftwareProduct z) => (z.Publishing == null) ? "None".Loc() : z.Publishing.Publisher.Name, true)
		},
		{
			"CompanyName",
			new ColumnDefinition<Company>("Name", (Company x) => x.Name, false, 160f, false, true)
		},
		{
			"CompanyWorth",
			new ColumnDefinition<Company>("Worth", (Company x) => x.GetMoneyWithInsurance(true, true), true, 125f)
		},
		{
			"CompanyBank",
			new ColumnDefinition<Company>("Bank", (Company x) => x.Money, true, 125f)
		},
		{
			"CompanyReputation",
			new ColumnDefinition<Company>("Reputation", (Company x) => x.BusinessReputation, true, null, false)
		},
		{
			"CompanyFans",
			new ColumnDefinition<Company>("Fans", (Company x) => x.Fans, true, null, true, GUIColumn.TotalType.Range)
		},
		{
			"CompanyBankrupt",
			new ColumnDefinition<Company>("Bankrupt", (Company x) => x.Bankrupt, true, 80f)
		},
		{
			"CompanyFounded",
			new ColumnDefinition<Company>("Founded", (Company x) => x.Founded, false, 125f)
		},
		{
			"CompanyProducts",
			new ColumnDefinition<Company>("Products", (Company x) => x.Products.Count, true, 90f)
		},
		{
			"CompanyPatents",
			new ColumnDefinition<Company>("Patents", (Company x) => x.Patents.Count, true, 73f)
		},
		{
			"CompanyDistribution",
			new ColumnDefinition<Company>("Distribution", (Company x) => x.GetPlatforms().Any((DistributionPlatform z) => z.Owner.IsLocalPlayer), true, 100f)
		},
		{
			"CompanySubsidiary",
			new ColumnDefinition<Company>("Subsidiary", (Company x) => GetIsSubsidiary(x), true, 93f)
		},
		{
			"CompanyListed",
			new ColumnDefinition<Company>("StockPubliclyListed", (Company x) => 1.0 - x.GetShare(), true, 66f, false, true, true, GUIColumn.TotalType.Range)
			{
				Tip = "StockListedTip"
			}
		},
		{
			"CompanyOwnedShares",
			new ColumnDefinition<Company>("Shares", (Company x) => x.GetCompanyShares(GameSettings.Instance.MyCompany), true, 72f, false, true, true, GUIColumn.TotalType.Maximum)
		},
		{
			"CompanyChart",
			new ColumnDefinition<Company>("Chart", delegate(Company x)
			{
				HUD.Instance.companyChart.Show(x);
			}, 60f)
		},
		{
			"CompanyStock",
			new ColumnDefinition<Company>("Details", delegate(Company x)
			{
				if (!x.Bankrupt)
				{
					HUD.Instance.companyWindow.ShowCompanyDetails(x);
				}
			}, 60f)
		},
		{
			"CompanyProductList",
			new ColumnDefinition<Company>("Products", delegate(Company y)
			{
				ProductWindow productWindow = HUD.Instance.GetProductWindow("AllRelease");
				productWindow.Show(true, "CompanyReleases".Loc(y.Name));
				productWindow.SetFilters(false, true);
				productWindow.SetCompany(y.ID);
			}, 80f)
		},
		{
			"CompanyDistributionLoad",
			new ColumnDefinition<Company>("Bandwidth", (Company x) => (!x.DistributionLoad.HasValue) ? "NotApplicableAbbr".Loc() : x.DistributionLoad.Value.BandwidthFactor(SDateTime.Now()).Bandwidth(), (Company x) => x.DistributionLoad ?? 0f, true, null, FilterType.Number, (Company x) => x.DistributionLoad ?? 0f, null, null, (double x) => ((float)x).BandwidthFactor(SDateTime.Now()).Bandwidth(), GUIColumn.TotalType.All, GUIColumn.TotalType.Sum, (Company x) => ((double?)x.DistributionLoad) ?? double.NaN)
		},
		{
			"CompanyDistributionActive",
			new ColumnDefinition<Company>("Active", (Company x) => x.GetPlatforms().Any((DistributionPlatform z) => z.Owner.IsLocalPlayer), true, 70f, ToggleDistributionDeal)
		},
		{
			"CompanyLogo",
			new ColumnDefinition<Company>("Logo", (Company x) => x, (Company x) => x.Name, true, 24f, FilterType.None, null, GUIColumn.ColumnType.Logo)
		},
		{
			"CompanyPlayer",
			new ColumnDefinition<Company>("NetworkPlayer", GetCompanyPlayer, (Company x) => (int)x.NetworkPlayerID, false, 80f)
		},
		{
			"CompanyTimeline",
			new ColumnDefinition<Company>("Timeline", delegate(Company x)
			{
				HUD.Instance.TimeLineWindow.Show(x);
			}, 60f)
		},
		{
			"StockOwner",
			new ColumnDefinition<NewStock>("Owner", (NewStock x) => x.Buyer.Name, false, 130f)
		},
		{
			"StockCompany",
			new ColumnDefinition<NewStock>("Company", (NewStock x) => x.Seller.Name, false, 130f)
		},
		{
			"StockShare",
			new ColumnDefinition<NewStock>("Share", (NewStock x) => x.Percentage, false, 70f, false)
		},
		{
			"StockChange",
			new ColumnDefinition<NewStock>("Change", (NewStock x) => x.Change, true, 70f, false)
		},
		{
			"StockWorth",
			new ColumnDefinition<NewStock>("Worth", (NewStock x) => x.TotalWorth, true, 80f)
		},
		{
			"StockSell",
			new ColumnDefinition<NewStock>("Sell", SellStock, 60f)
		},
		{
			"StockDetail",
			new ColumnDefinition<NewStock>("Details", delegate(NewStock x)
			{
				Company seller = x.Seller;
				if (!seller.Bankrupt)
				{
					HUD.Instance.companyWindow.ShowCompanyDetails(seller);
				}
			}, 60f)
		},
		{
			"TeamName",
			new ColumnDefinition<Team>("Name", (Team x) => x.Name, false, null, false, true)
		},
		{
			"TeamColor",
			new ColumnDefinition<Team>("Color", (Team x) => "#" + ColorUtility.ToHtmlStringRGB(x.TeamColor), (Team x) => Utilities.RGBToHSV(x.TeamColor).x, true, 24f, null, null, GUIColumn.ColumnType.Color, delegate(Team x, object c)
			{
				x.TeamColor = (Color)c;
			})
		},
		{
			"TeamCount",
			new ColumnDefinition<Team>("Count", (Team x) => x.Count, true, 60f)
		},
		{
			"TeamCompatibility",
			new ColumnDefinition<Team>("Compatibility", (Team x) => x.Compatibility, true, 60f, false, true, true, true, GUIColumn.TotalType.Minimum)
		},
		{
			"TeamCohesion",
			new ColumnDefinition<Team>("TeamCohesion", (Team x) => x.Cohesion, true, 60f, false, true, true, true, GUIColumn.TotalType.Minimum)
			{
				Tip = "TeamCohesionTip"
			}
		},
		{
			"TeamWork",
			new ColumnDefinition<Team>("Tasks", (Team x) => x.WorkItems.Count, true, 60f, true, true, GUIColumn.TotalType.Range)
		},
		{
			"TeamStart",
			new ColumnDefinition<Team>("Arrival", (Team x) => Utilities.HourString(x.WorkStart), (Team z) => z.WorkStart, true, 74f, FilterType.Number, (Team x) => (float)x.WorkStart, GUIColumn.ColumnType.PlusMinus, delegate(Team x, object y)
			{
				x.ChangeWorkStart(ChangeHour(x.WorkStart, x.WorkEnd, (int)y));
			})
		},
		{
			"TeamEnd",
			new ColumnDefinition<Team>("Departure", (Team x) => Utilities.HourString(x.WorkEnd), (Team z) => z.WorkEnd, true, 85f, FilterType.Number, (Team x) => (float)x.WorkEnd, GUIColumn.ColumnType.PlusMinus, delegate(Team x, object y)
			{
				x.ChangeWorkEnd(ChangeHour(x.WorkEnd, x.WorkStart, (int)y));
			})
		},
		{
			"TeamVacation",
			new ColumnDefinition<Team>("Vacation", GetVacationMonths, (Team z) => z.VacationMonth, true, null, FilterType.Name)
		},
		{
			"TeamVacationSpread",
			new ColumnDefinition<Team>("Vacation range", (Team x) => "Month".LocPlural(x.VacationSpread + 1), (Team z) => z.VacationSpread, true, 120f, FilterType.Number, (Team x) => (float)x.VacationSpread)
		},
		{
			"TeamHR",
			new ColumnDefinition<Team>("HR", (Team x) => x.HR.AnyActiveFunctions && x.CheckHRLevel(1), true, 50f)
		},
		{
			"TeamCrunch",
			new ColumnDefinition<Team>("Crunch", (Team x) => x.CrunchMode, true, 70f, delegate(Team x, bool y)
			{
				x.CrunchMode = y;
			})
			{
				Tip = "CrunchHint"
			}
		},
		{
			"TeamStartMinus",
			new ColumnDefinition<Team>("-", delegate(Team x)
			{
				x.ChangeWorkStart(ChangeHour(x.WorkStart, x.WorkEnd, -1));
			}, 25f)
		},
		{
			"TeamStartPlus",
			new ColumnDefinition<Team>("+", delegate(Team x)
			{
				x.ChangeWorkStart(ChangeHour(x.WorkStart, x.WorkEnd, 1));
			}, 25f)
		},
		{
			"TeamEndMinus",
			new ColumnDefinition<Team>("-", delegate(Team x)
			{
				x.ChangeWorkEnd(ChangeHour(x.WorkEnd, x.WorkStart, -1));
			}, 25f)
		},
		{
			"TeamEndPlus",
			new ColumnDefinition<Team>("+", delegate(Team x)
			{
				x.ChangeWorkEnd(ChangeHour(x.WorkEnd, x.WorkStart, 1));
			}, 25f)
		},
		{
			"TeamVacationMinus",
			new ColumnDefinition<Team>("-", delegate(Team x)
			{
				x.VacationMonth = ((x.VacationMonth == 0) ? 11 : (x.VacationMonth - 1));
				x.RescheduleVacations();
			}, 25f)
		},
		{
			"TeamVacationPlus",
			new ColumnDefinition<Team>("+", delegate(Team x)
			{
				x.VacationMonth = (x.VacationMonth + 1) % 12;
				x.RescheduleVacations();
			}, 25f)
		},
		{
			"TeamVacationSpreadMinus",
			new ColumnDefinition<Team>("-", delegate(Team x)
			{
				x.VacationSpread = ((x.VacationSpread == 0) ? 11 : (x.VacationSpread - 1));
				x.RescheduleVacations();
			}, 25f)
		},
		{
			"TeamVacationSpreadPlus",
			new ColumnDefinition<Team>("+", delegate(Team x)
			{
				x.VacationSpread = (x.VacationSpread + 1) % 12;
				x.RescheduleVacations();
			}, 25f)
		},
		{
			"TeamSalary",
			new ColumnDefinition<Team>("Salaries", (Team x) => x.GetEmployeesDirect().SumSafe((Actor z) => z.GetMonthlySalary()), true, 78f)
		},
		{
			"TeamLeader",
			new ColumnDefinition<Team>("Leader", (Team x) => (!(x.Leader == null)) ? x.Leader.employee.FullName : "None".Loc(), true, 78f, false, true)
		},
		{
			"StaffType",
			new ColumnDefinition<Actor>("Type", (Actor x) => x.AItype.ToString().Loc(), false)
		},
		{
			"StaffStart",
			new ColumnDefinition<Actor>("Arrival", (Actor x) => (!x.OnCall) ? Utilities.HourString(x.StaffOn) : "Immediately".Loc(), (Actor x) => x.OnCall ? (-1) : x.StaffOn, true, 70f, FilterType.Number, (Actor x) => x.OnCall ? (-1f) : ((float)x.StaffOn))
		},
		{
			"StaffEnd",
			new ColumnDefinition<Actor>("Departure", (Actor x) => (!x.OnCall) ? Utilities.HourString(x.StaffOff) : "NotApplicableAbbr".Loc(), (Actor x) => x.OnCall ? (-1) : x.StaffOff, true, 80f, FilterType.Number, (Actor x) => x.OnCall ? (-1f) : ((float)x.StaffOff))
		},
		{
			"StaffWorkPlus",
			new ColumnDefinition<Actor>("+", delegate(Actor x)
			{
				x.StaffOn = (x.StaffOn + 1) % 24;
				x.StaffOff = (x.StaffOn + x.GetStaffHours()) % 24;
				CalendarWindow.ScheduleRefresh = true;
				StaffWindow.RefreshStaffTime(x);
			}, 25f)
		},
		{
			"StaffWorkMinus",
			new ColumnDefinition<Actor>("-", StaffWorkMinus, 25f)
		},
		{
			"StaffRooms",
			new ColumnDefinition<Actor>("Rooms", (Actor x) => x.AssignedRoomGroups.GetListAbbrev("Group", (string z) => GameSettings.Instance.GetRoomGroup(z).Name), true, 90f, false, false, true)
		},
		{
			"StaffDismiss",
			new ColumnDefinition<Actor>("Dismiss", delegate(Actor x)
			{
				x.Fire(false);
			}, 70f)
		},
		{
			"ContractCompany",
			new ColumnDefinition<ContractWork>("Company", (ContractWork x) => x.Company, false, null, false)
		},
		{
			"ContractMonths",
			new ColumnDefinition<ContractWork>("Months", (ContractWork x) => x.Months, false, 70f, true, true, GUIColumn.TotalType.Range)
		},
		{
			"ContractIncome",
			new ColumnDefinition<ContractWork>("Income", (ContractWork x) => x.GetIncome(), false, 95f, true, true, true, GUIColumn.TotalType.Range)
		},
		{
			"ContractType",
			new ColumnDefinition<ContractWork>("Type", (ContractWork x) => x.SoftwareType.Name.LocSW(), false, 188f)
		},
		{
			"ContractIcon",
			new ColumnDefinition<ContractWork>("Type", (ContractWork x) => HWSWIcon(x, false, false), (ContractWork x) => (int)HWSWIcon(x, true, false), true, 24f, FilterType.Name, (ContractWork x) => HWSWIcon(x, false, true), GUIColumn.ColumnType.WarningIcon)
		},
		{
			"LoanTotal",
			new ColumnDefinition<Loan>("Total", (Loan x) => (double)x.Months * x.Monthly, true, 90f)
		},
		{
			"LoanPrincipal",
			new ColumnDefinition<Loan>("Principal", (Loan x) => x.Principal, true, 90f)
		},
		{
			"LoanMonthly",
			new ColumnDefinition<Loan>("Monthly", (Loan x) => x.Monthly, false, 85f)
		},
		{
			"LoanMonths",
			new ColumnDefinition<Loan>("Months", (Loan x) => x.Months, true, 70f, true, true, GUIColumn.TotalType.Maximum)
		},
		{
			"LoanPayout",
			new ColumnDefinition<Loan>("Payout", LoanPayout, 65f)
		},
		{
			"HireName",
			new ColumnDefinition<Employee>("Name", (Employee x) => x.FullName, false, 125f, false)
		},
		{
			"HireAge",
			new ColumnDefinition<Employee>("Age", (Employee x) => x.GetAgeFlat().ToString(), (Employee x) => x.GetAge(), false, 56f, FilterType.Number, (Employee x) => x.GetAge(), null, null, (double x) => x.ToString("F0"), GUIColumn.TotalType.NoSum, GUIColumn.TotalType.Range)
		},
		{
			"HireScore",
			new ColumnDefinition<Employee>("Skill", (Employee x) => (float)x.GetHireSkill((Employee.EmployeeRole)HUD.Instance.hireWindow.RoleCombo.Selected).Quantize(4) + 1f, (Employee x) => x.GetSkill((Employee.EmployeeRole)HUD.Instance.hireWindow.RoleCombo.Selected), false, 78f, null, null, GUIColumn.ColumnType.Stars, null, (double x) => (float)Employee.ConvertHireSkill((Employee.EmployeeRole)HUD.Instance.hireWindow.RoleCombo.Selected, (float)x).Quantize(4) + 1f, GUIColumn.TotalType.NoRange)
		},
		{
			"HireSalary",
			new ColumnDefinition<Employee>("Salary", (Employee x) => x.GetMonthlySalary(HUD.Instance.hireWindow.HireWin.GetSelectedTeam()), false, 72f, true, true, true, GUIColumn.TotalType.Range)
		},
		{
			"HireCompatibility",
			new ColumnDefinition<Employee>("Compatibility", (Employee x) => (HUD.Instance.hireWindow.HireWin.Compatibility.Count <= 0) ? "TeamCompat0".Loc() : Team.GetCompatDesc(HUD.Instance.hireWindow.HireWin.Compatibility[x]), (Employee z) => (HUD.Instance.hireWindow.HireWin.Compatibility.Count <= 0) ? 0f : HUD.Instance.hireWindow.HireWin.Compatibility[z], true, null, FilterType.Name, null, null, null, (double x) => Team.GetCompatDesc((float)x), GUIColumn.TotalType.NoSum, GUIColumn.TotalType.Range)
		},
		{
			"HireHire",
			new ColumnDefinition<Employee>("Hire", delegate(Employee x)
			{
				HUD.Instance.hireWindow.HireWin.HireEmployee(x);
			}, 60f)
		},
		{
			"HireReject",
			new ColumnDefinition<Employee>("Reject", delegate(Employee x)
			{
				HUD.Instance.hireWindow.HireWin.RemoveEmployee(x);
			}, 60f)
		},
		{
			"HireTraits",
			new ColumnDefinition<Employee>("Traits", (Employee x) => x.Traits, (Employee x) => (float)x.Traits, false, 96f, FilterType.Trait, (Employee x) => x.Traits, GUIColumn.ColumnType.Trait)
		},
		{
			"SaveGameName",
			new ColumnDefinition<SaveGame>("Name", (SaveGame x) => x.ActualName, false, 100f, false)
		},
		{
			"SaveGameServerName",
			new ColumnDefinition<SaveGame>("Server", (SaveGame x) => x.NetworkData.ServerName, false, 100f, false)
		},
		{
			"SaveGameCompany",
			new ColumnDefinition<SaveGame>("Company", (SaveGame x) => x.CompanyName, false, 150f)
		},
		{
			"SaveGameGameDate",
			new ColumnDefinition<SaveGame>("GameDate", (SaveGame x) => x.InGameTime, false, 120f)
		},
		{
			"SaveGameDate",
			new ColumnDefinition<SaveGame>("Date", (SaveGame x) => x.RealTime.ToString("yyyy MMM dd HH:mm"), (SaveGame x) => x.RealTime.ToString("yyyyMMMddHHmm"), false, 125f)
		},
		{
			"SaveGameDateDiff",
			new ColumnDefinition<SaveGame>("Date", (SaveGame x) => (DateTime.Now - x.RealTime).GetString(), (SaveGame x) => x.RealTime.ToString("yyyyMMMddHHmm"), true, 125f)
		},
		{
			"SaveGameMoney",
			new ColumnDefinition<SaveGame>("Money", (SaveGame x) => x.Money, false, 110f)
		},
		{
			"SaveGameProducts",
			new ColumnDefinition<SaveGame>("Products", (SaveGame x) => x.Products, false, 75f)
		},
		{
			"SaveGameEmployees",
			new ColumnDefinition<SaveGame>("Employees", (SaveGame x) => x.Employees, false, 85f)
		},
		{
			"SaveGameSize",
			new ColumnDefinition<SaveGame>("Size", (SaveGame x) => x.FileSize.ByteSize(), (SaveGame x) => x.FileSize, false, 64f, FilterType.Number, (SaveGame x) => x.FileSize, null, null, (double x) => ((float)x).ByteSize(), GUIColumn.TotalType.All, GUIColumn.TotalType.Sum)
		},
		{
			"SaveGameDelete",
			new ColumnDefinition<SaveGame>("Delete", DeleteSaveFile)
		},
		{
			"SaveGameUUID",
			new ColumnDefinition<SaveGame>("UUID", CopySaveUUID)
		},
		{
			"ModName",
			new ColumnDefinition<ModPackage>("Name", (ModPackage x) => x.ItemTitle + (x.GetSteamID().HasValue ? " (Steam)" : ""), (ModPackage x) => x.ItemTitle, false, 210f, FilterType.Name, (ModPackage x) => x.ItemTitle)
		},
		{
			"ModActive",
			new ColumnDefinition<ModPackage>("Enabled", (ModPackage x) => x.Enabled, true, 70f)
		},
		{
			"ModAction",
			new ColumnDefinition<ModPackage>("Toggle", (ModPackage x) => x.Enabled, true, 24f, ToggleMod)
		},
		{
			"SrvName",
			new ColumnDefinition<ServerGroup>("Name", (ServerGroup x) => x.GetDisplayName(), true, 125f, false, true)
		},
		{
			"SrvColor",
			new ColumnDefinition<ServerGroup>("Color", (ServerGroup x) => "#" + ColorUtility.ToHtmlStringRGB(x.WireColor), (ServerGroup x) => Utilities.RGBToHSV(x.WireColor).x, true, 24f, null, null, GUIColumn.ColumnType.Color, UpdateServerColor)
		},
		{
			"SrvPower",
			new ColumnDefinition<ServerGroup>("Bandwidth", (ServerGroup x) => x.PowerSum.Bandwidth(), (ServerGroup x) => x.PowerSum, true, 95f, null, null, null, null, (double x) => ((float)x).Bandwidth(), GUIColumn.TotalType.All, GUIColumn.TotalType.Sum)
		},
		{
			"SrvServers",
			new ColumnDefinition<ServerGroup>("Servers", (ServerGroup x) => x.Servers.Count, true, 77f)
		},
		{
			"SrvLoad",
			new ColumnDefinition<ServerGroup>("ServerLoad", (ServerGroup x) => 1f - x.Available, true, 70f, false, true, true, true, GUIColumn.TotalType.Maximum)
		},
		{
			"SrvWatt",
			new ColumnDefinition<ServerGroup>("Electricity", (ServerGroup x) => GetServerWatt(x).GetWatt(false), (ServerGroup x) => GetServerWatt(x), true, null, null, null, null, null, (double x) => ((float)x).GetWatt(false), GUIColumn.TotalType.All, GUIColumn.TotalType.Sum)
		},
		{
			"SrvItems",
			new ColumnDefinition<ServerGroup>("Processes", (ServerGroup x) => x.Items.Count, true, 85f)
		},
		{
			"SrvCost",
			new ColumnDefinition<ServerGroup>("Cost", (ServerGroup x) => x.GetCost(), true, 60f)
		},
		{
			"SrvFallback",
			new ColumnDefinition<ServerGroup>("Fallback", (ServerGroup x) => x.Fallback ?? "None".Loc(), true)
		},
		{
			"SrvSelectFallback",
			new ColumnDefinition<ServerGroup>("Select fallback", SelectServerFallback)
		},
		{
			"SrvStatus",
			new ColumnDefinition<ServerGroup>("Status", (ServerGroup x) => ServerStatus(x, false, false), (ServerGroup x) => (int)ServerStatus(x, true, false), true, 28f, FilterType.Name, (ServerGroup x) => ServerStatus(x, false, true), GUIColumn.ColumnType.WarningIcon)
		},
		{
			"SrvView",
			new ColumnDefinition<ServerGroup>("View", ViewServer, 60f)
			{
				DoubleClickAction = true
			}
		},
		{
			"SrvItemName",
			new ColumnDefinition<IServerItem>("Name", (IServerItem x) => x.GetDescription(), false, 235f, false, true)
		},
		{
			"SrvItemPower",
			new ColumnDefinition<IServerItem>("Bandwidth", (IServerItem x) => x.GetLoadRequirement().BandwidthFactor(SDateTime.Now()).Bandwidth(), (IServerItem x) => x.GetLoadRequirement(), true, 135f, null, null, null, null, (double x) => ((float)x).BandwidthFactor(SDateTime.Now()).Bandwidth(), GUIColumn.TotalType.All, GUIColumn.TotalType.Sum)
		},
		{
			"SrvItemMove",
			new ColumnDefinition<IServerItem>("Move", delegate(IServerItem x)
			{
				HUD.Instance.serverWindow.DelegateItems(x);
			})
		},
		{
			"SrvItemServer",
			new ColumnDefinition<IServerItem>("Server", (IServerItem x) => GetServerForProc(x), true, 125f, false, true)
		},
		{
			"ContractResultCompany",
			new ColumnDefinition<ContractResult>("Company", (ContractResult x) => x.Contract.Company, false, 116f, false)
		},
		{
			"ContractResultIncome",
			new ColumnDefinition<ContractResult>("NetProfit", (ContractResult x) => x.FinalResult, false)
		},
		{
			"ContractResultStatus",
			new ColumnDefinition<ContractResult>("Status", (ContractResult x) => x.Status.ToString().Loc(), (ContractResult x) => (float)x.Status, false, null, FilterType.Name)
		},
		{
			"ContractResultDate",
			new ColumnDefinition<ContractResult>("Date", (ContractResult x) => x.Date, false)
		},
		{
			"ContractResultType",
			new ColumnDefinition<ContractResult>("Type", (ContractResult x) => x.Contract.SoftwareType.Name.LocSW(), false, 145f)
		},
		{
			"ContractResultIcon",
			new ColumnDefinition<ContractResult>("Type", (ContractResult x) => HWSWIcon(x.Contract, false, false), (ContractResult x) => (int)HWSWIcon(x.Contract, true, false), true, 24f, FilterType.Name, (ContractResult x) => HWSWIcon(x.Contract, false, true), GUIColumn.ColumnType.WarningIcon)
		},
		{
			"DealDesc",
			new ColumnDefinition<Deal>("Description", (Deal x) => x.Description(), false, null, false)
		},
		{
			"DealClient",
			new ColumnDefinition<Deal>("Company", (Deal x) => x.CompanyName, false, null, false)
		},
		{
			"DealWorth",
			new ColumnDefinition<Deal>("Offer", (Deal x) => x.Worth(), false)
		},
		{
			"DealSatisfaction",
			new ColumnDefinition<Deal>("Performance", (Deal x) => DealPerf(x.PerfDiff), true)
		},
		{
			"DealCancel",
			new ColumnDefinition<Deal>("Cancel", delegate(Deal x)
			{
				HUD.Instance.dealWindow.CancelDeal(x);
			})
		},
		{
			"ProducProtoName",
			new ColumnDefinition<SimulatedCompany.IProjectPrototype>("Name", (SimulatedCompany.IProjectPrototype x) => x.GetName(), false, 175f, false, true)
		},
		{
			"ProducProtoCat",
			new ColumnDefinition<SimulatedCompany.IProjectPrototype>("Category", (SimulatedCompany.IProjectPrototype x) => x.GetCategory(), false)
		},
		{
			"ProducProtoType",
			new ColumnDefinition<SimulatedCompany.IProjectPrototype>("Type", (SimulatedCompany.IProjectPrototype x) => x.GetSWType(), false, 135f)
		},
		{
			"ProducProtoCompany",
			new ColumnDefinition<SimulatedCompany.IProjectPrototype>("Company", (SimulatedCompany.IProjectPrototype x) => x.GetDevCompany().Name, false, 175f)
		},
		{
			"ProducProtoRelease",
			new ColumnDefinition<SimulatedCompany.IProjectPrototype>("Releasedate", (SimulatedCompany.IProjectPrototype x) => x.GetReleaseDate(), false, 125f)
		},
		{
			"ProducProtoCancel",
			new ColumnDefinition<SimulatedCompany.IProjectPrototype>("Cancel", delegate(SimulatedCompany.IProjectPrototype x)
			{
				x.RemoveProject();
			})
		},
		{
			"WorkItemType",
			new ColumnDefinition<WorkItem>("Type", (WorkItem x) => x.GetIdentifyingTypeName().Loc(), false)
		},
		{
			"WorkItemProject",
			new ColumnDefinition<WorkItem>("Project", (WorkItem x) => x.Name, false, null, false)
		},
		{
			"WorkItemActualProject",
			new ColumnDefinition<WorkItem>("Project", (WorkItem x) => x.GetSubjectName(), false, null, false)
		},
		{
			"WorkItemTeam",
			new ColumnDefinition<WorkItem>("Team", (WorkItem x) => x.GetTeam(), true)
		},
		{
			"WorkItemStatus",
			new ColumnDefinition<WorkItem>("Status", (WorkItem x) => x.CollapseLabel(), true, null, false)
		},
		{
			"WorkItemTakeOver",
			new ColumnDefinition<WorkItem>("Takeover", TakeOverItem)
		},
		{
			"PatentName",
			new ColumnDefinition<TechLevel>("Name", (TechLevel x) => x.Spec.LocTry(), false, 135f, false)
		},
		{
			"PatentResearched",
			new ColumnDefinition<TechLevel>("Tech level", (TechLevel x) => x.ActualYear, true, 95f, false, true, GUIColumn.TotalType.Range, GUIColumn.TotalType.NoSum)
		},
		{
			"PatentOwner",
			new ColumnDefinition<TechLevel>("PatentOwner", (TechLevel x) => (x.PatentOwner != 0) ? GameSettings.Instance.simulation.GetCompany(x.PatentOwner).Name : "None".Loc(), true, 110f)
		},
		{
			"PatentRoyalty",
			new ColumnDefinition<TechLevel>("Royalty", (TechLevel x) => x.GetActualRoyalty(), false, 70f, false, true, false, true, GUIColumn.TotalType.Range)
		},
		{
			"PatentIncome",
			new ColumnDefinition<TechLevel>("Income", (TechLevel x) => x.Income, true)
		},
		{
			"PatentCount",
			new ColumnDefinition<TechLevel>("Companies", (TechLevel x) => GetResearchedCount(x), true, null, true, true, GUIColumn.TotalType.Range)
		},
		{
			"WorkshopName",
			new ColumnDefinition<IWorkshopItem>("Name", (IWorkshopItem x) => x.ItemTitle, true, 250f, false)
		},
		{
			"WorkshopType",
			new ColumnDefinition<IWorkshopItem>("Type", (IWorkshopItem x) => x.GetWorkshopType(), false)
		},
		{
			"WorkshopStatus",
			new ColumnDefinition<IWorkshopItem>("Status", (IWorkshopItem x) => x.SteamStatus(), true, 190f)
		},
		{
			"WorkshopUpload",
			new ColumnDefinition<IWorkshopItem>("Upload", UploadWorkshopItem)
		},
		{
			"WorkshopToggle",
			new ColumnDefinition<IWorkshopItem>("Toggle", (IWorkshopItem x) => x.IsEnabled(), true, 24f, delegate(IWorkshopItem x, bool y)
			{
				x.Enable(y);
			})
		},
		{
			"WorkshopLoadTime",
			new ColumnDefinition<IWorkshopItem>("LoadTime", (IWorkshopItem x) => x.LoadTime.SecondsToTime(), (IWorkshopItem x) => x.LoadTime, false, null, null, null, null, null, (double x) => ((float)x).SecondsToTime(), GUIColumn.TotalType.All, GUIColumn.TotalType.Sum)
		},
		{
			"WorkshopCount",
			new ColumnDefinition<IWorkshopItem>("Amount", (IWorkshopItem x) => x.GetCount(), false)
		},
		{
			"BlueprintDelete",
			new ColumnDefinition<BuildingPrefab>("Delete", DeleteBlueprint)
		},
		{
			"WaypointTime",
			new ColumnDefinition<WayPointEditorWindow.WayPoint>("Duration", (WayPointEditorWindow.WayPoint x) => x.Time, true)
		},
		{
			"WaypointSetTime",
			new ColumnDefinition<WayPointEditorWindow.WayPoint>("Set duration", delegate(WayPointEditorWindow.WayPoint wp)
			{
				WindowManager.SpawnInputDialog("Time:", "Set time", wp.Time.ToString(), delegate(string z)
				{
					wp.Time = (float)Convert.ToDouble(z);
				});
			})
		},
		{
			"WaypointDelete",
			new ColumnDefinition<WayPointEditorWindow.WayPoint>("Delete", delegate(WayPointEditorWindow.WayPoint x)
			{
				WayPointEditorWindow.Instance.WayPointList.Items.Remove(x);
			})
		},
		{
			"WaypointFreeze",
			new ColumnDefinition<WayPointEditorWindow.WayPoint>("Freeze", FreezeWaypoint)
		},
		{
			"AutoDevName",
			new ColumnDefinition<AutoDevWorkItem.AutoDevItem>("Name", (AutoDevWorkItem.AutoDevItem x) => x.Name, false, null, false)
		},
		{
			"AutoDevStatus",
			new ColumnDefinition<AutoDevWorkItem.AutoDevItem>("Queued", (AutoDevWorkItem.AutoDevItem x) => x.Queued, true)
		},
		{
			"AutoDevPhase",
			new ColumnDefinition<AutoDevWorkItem.AutoDevItem>("Phase", (AutoDevWorkItem.AutoDevItem x) => x.Phase().Loc(), true)
		},
		{
			"AutoDevNext",
			new ColumnDefinition<AutoDevWorkItem.AutoDevItem>("NextPhase", (AutoDevWorkItem.AutoDevItem x) => x.GetNextCutDesc(), (AutoDevWorkItem.AutoDevItem x) => x.GetNextCut().ToInt(), true)
		},
		{
			"AutoDevRelease",
			new ColumnDefinition<AutoDevWorkItem.AutoDevItem>("Releasedate", (AutoDevWorkItem.AutoDevItem x) => x.ReleaseDateText, (AutoDevWorkItem.AutoDevItem x) => x.ReleaseDateInt, true)
		},
		{
			"AutoDevFollowers",
			new ColumnDefinition<AutoDevWorkItem.AutoDevItem>("Followers", (AutoDevWorkItem.AutoDevItem x) => Mathf.RoundToInt(x.SWWorkItem.Followers), true)
		},
		{
			"AutoDevInfo",
			new ColumnDefinition<AutoDevWorkItem.AutoDevItem>("Info", delegate(AutoDevWorkItem.AutoDevItem x)
			{
				GUIWorkItem.SpawnDevInfoWindow(x.SWWorkItem, x.Design);
			})
		},
		{
			"AutoDevLeadDesigner",
			new ColumnDefinition<AutoDevWorkItem.AutoDevItem>("LeadDesigner", delegate(AutoDevWorkItem.AutoDevItem x)
			{
				x.ChangeLead();
			})
		},
		{
			"AutoDevTakeover",
			new ColumnDefinition<AutoDevWorkItem.AutoDevItem>("Takeover", delegate(AutoDevWorkItem.AutoDevItem x)
			{
				x.Release();
			})
		},
		{
			"AutoDevCancel",
			new ColumnDefinition<AutoDevWorkItem.AutoDevItem>("Cancel", delegate(AutoDevWorkItem.AutoDevItem x)
			{
				x.Cancel();
			})
		},
		{
			"TerminationName",
			new ColumnDefinition<EmployeeTermination>("Name", (EmployeeTermination x) => x.Name, false, null, false, true)
		},
		{
			"TerminationRole",
			new ColumnDefinition<EmployeeTermination>("Role", (EmployeeTermination x) => x.Role, (EmployeeTermination x) => Employee.RoleBitOrder(x.Role, false), true, 120f, FilterType.Bitmask, (EmployeeTermination x) => x.Role, GUIColumn.ColumnType.Role)
		},
		{
			"TerminationTeam",
			new ColumnDefinition<EmployeeTermination>("Team", (EmployeeTermination x) => x.Team, false)
		},
		{
			"TerminationYears",
			new ColumnDefinition<EmployeeTermination>("Years", (EmployeeTermination x) => (int)x.YearsHired, false, null, true, true, GUIColumn.TotalType.Range)
		},
		{
			"TerminationType",
			new ColumnDefinition<EmployeeTermination>("Reason", (EmployeeTermination x) => x.Termination.ToString().Loc(), false)
		},
		{
			"TerminationDate",
			new ColumnDefinition<EmployeeTermination>("Date", (EmployeeTermination x) => x.Date, false)
		},
		{
			"TerminationPayout",
			new ColumnDefinition<EmployeeTermination>("Payout", (EmployeeTermination x) => x.Payout, false)
		},
		{
			"TerminationDetails",
			new ColumnDefinition<EmployeeTermination>("Details", delegate(EmployeeTermination x)
			{
				HUD.Instance.SpecializationWindow.Show(x.Name, x.Specs, x.Skills);
			})
			{
				DoubleClickAction = true
			}
		},
		{
			"PrintProductName",
			new ColumnDefinition<PrintJob>("Product", (PrintJob x) => x.Target.GetName(), false, null, false, true)
		},
		{
			"PrintCompanyName",
			new ColumnDefinition<PrintJob>("Company", (PrintJob x) => x.CompanyName, false)
		},
		{
			"PrintInStock",
			new ColumnDefinition<PrintJob>("In stock", (PrintJob x) => x.PhysicalCopies, true)
			{
				Tip = "ProductStockTip"
			}
		},
		{
			"PrintInStorage",
			new ColumnDefinition<PrintJob>("In storage", (PrintJob x) => GameSettings.Instance.GetPrintsInStorage(x.Target), true)
			{
				Tip = "ProductStorageTip"
			}
		},
		{
			"PrintPerMonth",
			new ColumnDefinition<PrintJob>("PerMonth", (PrintJob x) => x.PrintPerMonthLabel(), (PrintJob x) => x.PrintPerMonth(), true, null, FilterType.Number, (PrintJob x) => (float)x.PrintPerMonth(), null, null, (double x) => x.ToString("N0"), GUIColumn.TotalType.All, GUIColumn.TotalType.Sum)
		},
		{
			"PrintGoal",
			new ColumnDefinition<PrintJob>("Goal", (PrintJob x) => x.GetGoal(), (PrintJob x) => x.GetGoalSort(), true, null, FilterType.Number, (PrintJob x) => x.GetGoalSort())
		},
		{
			"PrintDeadline",
			new ColumnDefinition<PrintJob>("Deadline", (PrintJob x) => x.GetDeadlineDate(), true, null, true)
		},
		{
			"PrintPriority",
			new ColumnDefinition<PrintJob>("Priority", (PrintJob x) => x.Priority, (PrintJob x) => x.Priority, false, null, FilterType.Number, (PrintJob x) => x.Priority * 100f, GUIColumn.ColumnType.Slider, delegate(PrintJob x, object y)
			{
				x.Priority = (float)y;
			})
		},
		{
			"PrintHWPriority",
			new ColumnDefinition<PrintJob>("Priority", (PrintJob x) => x.Priority / 10f, (PrintJob x) => x.Priority, true, null, FilterType.Number, (PrintJob x) => x.Priority * 10f, GUIColumn.ColumnType.Slider, SetManufacturePriority)
		},
		{
			"PrintCopiesSold",
			new ColumnDefinition<PrintJob>("Prints sold", (PrintJob x) => GetStockableCopies(x), true)
		},
		{
			"PrintLastMonth",
			new ColumnDefinition<PrintJob>("PastDayMonth", (PrintJob x) => x.Target.GetLastPhysicalSales(), true)
		},
		{
			"PrintDetails",
			new ColumnDefinition<PrintJob>("Details", DetailForPrintProduct)
		},
		{
			"PrintAssembly",
			new ColumnDefinition<PrintJob>("AssemblyLines", (PrintJob x) => x.AssemblyLines, true)
		},
		{
			"PrintAssignAssembly",
			new ColumnDefinition<PrintJob>("Assign", TaskToAssembly, 60f)
		},
		{
			"PrintHighlight",
			new ColumnDefinition<PrintJob>("Highlight", (PrintJob x) => GameSettings.Instance.BoxController.Highlight == x.Target, true, 24f, SetPrintHighlight)
		},
		{
			"RoomGroupName",
			new ColumnDefinition<RoomGroup>("Name", (RoomGroup x) => x.Name, true, 124f, true, true)
		},
		{
			"RoomGroupCount",
			new ColumnDefinition<RoomGroup>("Count", (RoomGroup x) => x.Count, true, 72f)
		},
		{
			"RoomGroupIndoorStyle",
			new ColumnDefinition<RoomGroup>("Indoor style", delegate(RoomGroup x)
			{
				RoomStyle indoor = x.Indoor;
				return StringOrNone((indoor != null) ? indoor.Name : null);
			}, true, 88f)
		},
		{
			"RoomGroupOutdoorStyle",
			new ColumnDefinition<RoomGroup>("Outdoor style", delegate(RoomGroup x)
			{
				RoomStyle outdoor = x.Outdoor;
				return StringOrNone((outdoor != null) ? outdoor.Name : null);
			}, true, 97f)
		},
		{
			"RoomGroupRename",
			new ColumnDefinition<RoomGroup>("Rename", delegate(RoomGroup x)
			{
				GameSettings.Instance.RenameRoomGroup(x);
			}, 66f)
		},
		{
			"RoomGroupRemove",
			new ColumnDefinition<RoomGroup>("Remove", delegate(RoomGroup x)
			{
				GameSettings.Instance.RemoveRoomGroup(x.Name);
			}, 66f)
		},
		{
			"FrameworkName",
			new ColumnDefinition<SoftwareFramework>("Name", (SoftwareFramework x) => x.Name, false, 143f, false, true)
		},
		{
			"FrameworkCompany",
			new ColumnDefinition<SoftwareFramework>("Company", (SoftwareFramework x) => (x.Owner != null) ? x.Owner.Name : "None".Loc(), false, 123f)
		},
		{
			"FrameworkDate",
			new ColumnDefinition<SoftwareFramework>("Releasedate", (SoftwareFramework x) => x.Release, false, 108f)
		},
		{
			"FrameworkRoyalty",
			new ColumnDefinition<SoftwareFramework>("Royalty", (SoftwareFramework x) => x.GetActualRoyalty(GameSettings.Instance.MyCompany), false, 76f, false, true, true, GUIColumn.TotalType.Range)
		},
		{
			"FrameworkRealRoyalty",
			new ColumnDefinition<SoftwareFramework>("Royalty", (SoftwareFramework x) => x.GetRoyalty(), true, 76f, false, true, true, GUIColumn.TotalType.Range)
		},
		{
			"FrameworkType",
			new ColumnDefinition<SoftwareFramework>("Type", (SoftwareFramework x) => x.Category.GetPrettyName(), false)
		},
		{
			"FrameworkIncome",
			new ColumnDefinition<SoftwareFramework>("Income", (SoftwareFramework x) => x.Income, true)
		},
		{
			"FrameworkVersion",
			new ColumnDefinition<SoftwareFramework>("Version", (SoftwareFramework x) => x.Updated + 1, true, 75f, false, true, GUIColumn.TotalType.Maximum, GUIColumn.TotalType.Ranges)
		},
		{
			"FrameworkUpdate",
			new ColumnDefinition<SoftwareFramework>("Update", (SoftwareFramework x) => x.LastUpdate ?? x.Release, true, 108f)
		},
		{
			"InvestmentAmount",
			new ColumnDefinition<Investment>("MonetaryAmount", (Investment x) => x.CurrentValue, true, 130f)
		},
		{
			"InvestmentInitial",
			new ColumnDefinition<Investment>("InitialInvestment", (Investment x) => x.Amount, false, 130f)
		},
		{
			"InvestmentChange",
			new ColumnDefinition<Investment>("Change", (Investment x) => (x.CurrentValue - x.Amount) / x.Amount, true, 80f, false, true, true, GUIColumn.TotalType.Range)
		},
		{
			"InvestmentStock",
			new ColumnDefinition<Investment>("Stock", (Investment x) => x.Stock.Name, false, 60f, false)
		},
		{
			"InvestmentPayout",
			new ColumnDefinition<Investment>("Withdraw", PayoutInvestment, 100f)
		},
		{
			"ComplaintName",
			new ColumnDefinition<Complaint>("Name", (Complaint x) => x.Target.FullName, false, null, false, true)
		},
		{
			"ComplaintDate",
			new ColumnDefinition<Complaint>("Date", (Complaint x) => x.Date, false)
		},
		{
			"ComplaintSalary",
			new ColumnDefinition<Complaint>("Salary", (Complaint x) => x.Target.MyActor.GetMonthlySalary(), true, 84f, true, true, false, true, GUIColumn.TotalType.Range)
		},
		{
			"ComplaintRole",
			new ColumnDefinition<Complaint>("Role", (Complaint x) => x.Target.CurrentRoleBit, (Complaint x) => Employee.RoleBitOrder(x.Target.CurrentRoleBit, false), true, 120f, FilterType.Bitmask, (Complaint x) => x.Target.CurrentRoleBit, GUIColumn.ColumnType.Role)
		},
		{
			"ComplaintTeam",
			new ColumnDefinition<Complaint>("Team", (Complaint x) => x.Target.MyActor.Team ?? "None".Loc(), true)
		},
		{
			"ComplaintSeniority",
			new ColumnDefinition<Complaint>("Years", (Complaint x) => (TimeOfDay.Instance.Year - x.Target.Hired.Year).ToString(), (Complaint z) => -z.Target.Hired.ToInt(), false, 78f, FilterType.Number, (Complaint x) => SDateTime.GetMonths(x.Target.Hired, SDateTime.Now()) / 12f, null, null, (double x) => x.ToString("F0"), GUIColumn.TotalType.All, GUIColumn.TotalType.Sum, (Complaint x) => TimeOfDay.Instance.Year - x.Target.Hired.Year)
		},
		{
			"ComplaintDetails",
			new ColumnDefinition<Complaint>("Details", delegate(Complaint x)
			{
				HUD.Instance.DetailWindow.Show(x.Target.MyActor);
			}, 64f)
		},
		{
			"AssemblyName",
			new ColumnDefinition<AssemblyLine>("Name", (AssemblyLine x) => x.Name, true, 125f, false, true)
		},
		{
			"AssemblyColor",
			new ColumnDefinition<AssemblyLine>("Color", (AssemblyLine x) => "#" + ColorUtility.ToHtmlStringRGB(x.AColor), (AssemblyLine x) => Utilities.RGBToHSV(x.AColor).x, true, 24f, null, null, GUIColumn.ColumnType.Color, UpdateAssemblyColor)
		},
		{
			"AssemblyCategory",
			new ColumnDefinition<AssemblyLine>("Category", (AssemblyLine x) => x.Category.GetPrettyName(), false, 182f)
		},
		{
			"AssemblyTasks",
			new ColumnDefinition<AssemblyLine>("Tasks", (AssemblyLine x) => x.GetTasksUnsafe().Count, true, 66f)
		},
		{
			"AssemblyAssign",
			new ColumnDefinition<AssemblyLine>("Assign", AssignToAssembly, 60f)
		},
		{
			"AssemblyRename",
			new ColumnDefinition<AssemblyLine>("Rename", RenameAssembly, 66f)
		},
		{
			"AssemblyView",
			new ColumnDefinition<AssemblyLine>("View", ViewAssembly, 60f)
			{
				DoubleClickAction = true
			}
		},
		{
			"AssemblyEffectiveness",
			new ColumnDefinition<AssemblyLine>("Effectiveness", (AssemblyLine x) => x.GetEffectiveness(), true, null, false, true, true, true, GUIColumn.TotalType.Minimum)
		},
		{
			"LicenseName",
			new ColumnDefinition<LicenseData>("Name", (LicenseData x) => x.Name, true, 125f, false)
		},
		{
			"LicensePaid",
			new ColumnDefinition<LicenseData>("Paid", (LicenseData x) => x.Paid, false)
		},
		{
			"LicenseReversePaid",
			new ColumnDefinition<LicenseData>("Paid", (LicenseData x) => x.ReversePaid, false)
		},
		{
			"LicenseDetails",
			new ColumnDefinition<LicenseData>("Details", delegate(LicenseData x)
			{
				x.ShowDetails();
			})
		},
		{
			"AResearchYear",
			new ColumnDefinition<KeyValuePair<Company, SimulatedCompany.TechResearch>>("Techlevel", (KeyValuePair<Company, SimulatedCompany.TechResearch> x) => x.Value.Year + 1900, false, 95f, false, true, GUIColumn.TotalType.Range, GUIColumn.TotalType.NoSum)
		},
		{
			"AResearchCompany",
			new ColumnDefinition<KeyValuePair<Company, SimulatedCompany.TechResearch>>("Company", (KeyValuePair<Company, SimulatedCompany.TechResearch> x) => x.Key.Name, false, 114f, false, true)
		},
		{
			"AResearchETA",
			new ColumnDefinition<KeyValuePair<Company, SimulatedCompany.TechResearch>>("ETA", (KeyValuePair<Company, SimulatedCompany.TechResearch> x) => x.Value.ETA.ToQuarterString(), (KeyValuePair<Company, SimulatedCompany.TechResearch> x) => x.Value.ETA.ToInt(), false, 66f)
		},
		{
			"AResearchStatus",
			new ColumnDefinition<KeyValuePair<Company, SimulatedCompany.TechResearch>>("Status", (KeyValuePair<Company, SimulatedCompany.TechResearch> x) => ((x.Value.Patent == null) ? "Researching" : "Patenting").Loc(), false, 92f)
		},
		{
			"AddOnName",
			new ColumnDefinition<AddOnProduct>("Name", (AddOnProduct x) => x.Name, false, 220f, false, true)
		},
		{
			"AddOnCategory",
			new ColumnDefinition<AddOnProduct>("Category", (AddOnProduct x) => x.SWCat.Name.LocSWC(x.Type.Name), (AddOnProduct z) => z.SWCat.Name, false, 80f, FilterType.Name)
		},
		{
			"AddOnSWType",
			new ColumnDefinition<AddOnProduct>("Type", (AddOnProduct x) => x.SWType.Name.LocSW(), (AddOnProduct z) => z.SWType.Name, false, 140f, FilterType.Name)
		},
		{
			"AddOnType",
			new ColumnDefinition<AddOnProduct>("Addon", (AddOnProduct x) => x.Type.Name.LocSW(), (AddOnProduct z) => z.Type.Name, false, 140f, FilterType.Name)
		},
		{
			"AddOnParent",
			new ColumnDefinition<AddOnProduct>("Product", (AddOnProduct x) => x.Parent.Name, false, 200f)
		},
		{
			"AddOnCompany",
			new ColumnDefinition<AddOnProduct>("Company", (AddOnProduct x) => x.Owner.Name, false, 200f)
		},
		{
			"AddOnInventor",
			new ColumnDefinition<AddOnProduct>("Creator", (AddOnProduct z) => !z.Traded, false)
		},
		{
			"AddOnRelease",
			new ColumnDefinition<AddOnProduct>("Releasedate", (AddOnProduct x) => x.Release, false, 125f)
		},
		{
			"AddOnQuality",
			new ColumnDefinition<AddOnProduct>("Quality", (AddOnProduct x) => SoftwareType.GetQualityLabel(x.RealQuality), (AddOnProduct z) => (float)z.RealQuality, false, 80f, FilterType.Name, null, null, null, (double x) => SoftwareType.GetQualityLabel(x), GUIColumn.TotalType.NoSum, GUIColumn.TotalType.Range)
		},
		{
			"AddOnReview",
			new ColumnDefinition<AddOnProduct>("ReviewScore", (AddOnProduct x) => RoundReviewScore(x.ReviewScore), (AddOnProduct x) => x.ReviewScore, true, 85f, FilterType.Number, (AddOnProduct x) => x.ReviewScore * 100f, GUIColumn.ColumnType.Stars5)
		},
		{
			"AddOnAwareness",
			new ColumnDefinition<AddOnProduct>("Marketing", (AddOnProduct x) => SoftwareType.GetAwarenessLabel(x.GetAwareness()), (AddOnProduct z) => z.GetAwareness(), true, null, FilterType.Name, null, null, null, (double x) => SoftwareType.GetAwarenessLabel((float)x), GUIColumn.TotalType.NoSum, GUIColumn.TotalType.Range)
		},
		{
			"AddOnIncome",
			new ColumnDefinition<AddOnProduct>("Profit", (AddOnProduct z) => z.Gross - z.Loss, true)
		},
		{
			"AddOnLastMonth",
			new ColumnDefinition<AddOnProduct>("PastDayMonth", (AddOnProduct z) => z.GetLastDayIncome(false), true)
		},
		{
			"AddOnLoss",
			new ColumnDefinition<AddOnProduct>("Expenses", (AddOnProduct z) => z.Loss, true)
		},
		{
			"AddOnPrice",
			new ColumnDefinition<AddOnProduct>("Retail price", (AddOnProduct z) => z.Price, false, null, true, true, false, true, GUIColumn.TotalType.Range)
		},
		{
			"AddOnUnitSales",
			new ColumnDefinition<AddOnProduct>("Net units sold", (AddOnProduct z) => z.Sales, true, 115f)
		},
		{
			"AddOnCopies",
			new ColumnDefinition<AddOnProduct>("In stock", (AddOnProduct z) => z.PhysicalCopies, true)
		},
		{
			"AddOnStorage",
			new ColumnDefinition<AddOnProduct>("In storage", (AddOnProduct z) => GameSettings.Instance.GetPrintsInStorage(z), true)
			{
				Tip = "ProductStorageTip"
			}
		},
		{
			"AddOnRefunds",
			new ColumnDefinition<AddOnProduct>("Refunds", (AddOnProduct z) => z.Refunds, true)
		},
		{
			"AddOnDetail",
			new ColumnDefinition<AddOnProduct>("Details", delegate(AddOnProduct x)
			{
				HUD.Instance.GetProductWindow(null).ShowAddonDetails(x);
			})
		},
		{
			"AddOnArchived",
			new ColumnDefinition<AddOnProduct>("Archived", (AddOnProduct x) => x.Parent.Archived || x.Parent.PlayerArchived, false)
		},
		{
			"PlatformName",
			new ColumnDefinition<DistributionPlatform>("Name", (DistributionPlatform x) => x.Software.Name, true, 160f, false)
		},
		{
			"PlatformActive",
			new ColumnDefinition<DistributionPlatform>("Interested", (DistributionPlatform x) => GameSettings.Instance.MyCompany.IsInterested(x), true, 30f, TogglePlayerDistributionDeal)
		},
		{
			"PlatformAccepted",
			new ColumnDefinition<DistributionPlatform>("Accepted", DistributionAccepted, (DistributionPlatform x) => GameSettings.Instance.MyCompany.IsSigned(x) ? 1 : 0, true, 30f, FilterType.Bool, (DistributionPlatform x) => GameSettings.Instance.MyCompany.IsSigned(x), GUIColumn.ColumnType.WarningIcon)
		},
		{
			"PlatformFounded",
			new ColumnDefinition<DistributionPlatform>("Founded", (DistributionPlatform x) => x.Founded, false, 108f)
		},
		{
			"PlatformCompany",
			new ColumnDefinition<DistributionPlatform>("Company", (DistributionPlatform x) => x.Owner.Name, false, 150f, false)
		},
		{
			"PlatformCut",
			new ColumnDefinition<DistributionPlatform>("Cut", (DistributionPlatform x) => x.GetCut(), true, 55f, false, false, false, true, GUIColumn.TotalType.Range)
		},
		{
			"PlatformShare",
			new ColumnDefinition<DistributionPlatform>("MarketShare", (DistributionPlatform x) => x.MarketShare, true, 80f, false, true, true)
		},
		{
			"PlatformCount",
			new ColumnDefinition<DistributionPlatform>("SignedCompanies", (DistributionPlatform x) => MarketSimulation.Active.GetAllCompanies().Count((Company z) => z.IsSigned(x)), true, 80f, true, true, GUIColumn.TotalType.Range)
		},
		{
			"PlatformDetails",
			new ColumnDefinition<DistributionPlatform>("Company", delegate(DistributionPlatform x)
			{
				HUD.Instance.companyWindow.ShowCompanyDetails(x.Owner);
			}, 80f)
		},
		{
			"LobbyName",
			new ColumnDefinition<NetworkLobby>("Name", (NetworkLobby x) => x.Name, true, 160f, false, true)
		},
		{
			"LobbyHost",
			new ColumnDefinition<NetworkLobby>("MultiplayerHost", (NetworkLobby x) => x.Host, true, 100f, false, true)
		},
		{
			"LobbyID",
			new ColumnDefinition<NetworkLobby>("ID", (NetworkLobby x) => x.UniqueID, true, 160f, false)
		},
		{
			"LobbyJoin",
			new ColumnDefinition<NetworkLobby>("JoinGame", JoinLobby, 80f)
		},
		{
			"LobbyAvailable",
			new ColumnDefinition<NetworkLobby>("AvailableSpots", (NetworkLobby x) => (!x.HasLocalSave()) ? x.AvailableSpots.ToString() : (x.AvailableSpots + " *"), (NetworkLobby x) => x.AvailableSpots, true, 50f, FilterType.Number, (NetworkLobby x) => x.AvailableSpots)
			{
				Tip = "AvailableSpotsHint"
			}
		},
		{
			"LobbyPlayers",
			new ColumnDefinition<NetworkLobby>("Players", (NetworkLobby x) => x.Players, true, 64f, false, false)
		},
		{
			"LobbyYear",
			new ColumnDefinition<NetworkLobby>("Year", (NetworkLobby x) => x.CurrentYear + 1900, true, 50f, false, false)
		},
		{
			"LobbyModded",
			new ColumnDefinition<NetworkLobby>("Modded", (NetworkLobby x) => x.DataMods, false, 70f)
		},
		{
			"LobbyCodeMods",
			new ColumnDefinition<NetworkLobby>("CodeMods", (NetworkLobby x) => x.CodeMods, false, 88f)
		},
		{
			"LobbyFurniture",
			new ColumnDefinition<NetworkLobby>("FurnitureMods", (NetworkLobby x) => x.FurnitureMods, false, 76f)
		},
		{
			"LobbyPassword",
			new ColumnDefinition<NetworkLobby>("Password", (NetworkLobby x) => x.PasswordProtected, false, 80f)
		},
		{
			"LobbyDifficulty",
			new ColumnDefinition<NetworkLobby>("Difficulty", (NetworkLobby x) => x.GetDifficultyName().Loc(), (NetworkLobby x) => x.Difficulty, false, 80f, FilterType.Name, (NetworkLobby x) => x.GetDifficultyName())
		},
		{
			"LobbyDPM",
			new ColumnDefinition<NetworkLobby>("DaysPerMonth", (NetworkLobby x) => x.DaysPerMonth, false, 120f, true, false)
		},
		{
			"LobbyIPO",
			new ColumnDefinition<NetworkLobby>("ForcedIPO", (NetworkLobby x) => x.ForcedIPO, false, 90f, false, true, false, false)
			{
				Tip = "ForcedIPOHint"
			}
		},
		{
			"LobbyRoundLimit",
			new ColumnDefinition<NetworkLobby>("DayLimit", (NetworkLobby x) => (!float.IsInfinity(x.RoundLimit)) ? "Minute".LocPlural(Mathf.RoundToInt(x.RoundLimit / 60f)) : "Unlimited".Loc(), (NetworkLobby x) => x.RoundLimit, false, 105f)
		},
		{
			"LobbyRoundType",
			new ColumnDefinition<NetworkLobby>("DayLimitType", (NetworkLobby x) => x.GetRoundType(), (NetworkLobby x) => (float)x.RoundType, false, 105f)
		},
		{
			"LobbyLocal",
			new ColumnDefinition<NetworkLobby>("HavePlayed", (NetworkLobby x) => x.HasLocalSave(), false, 100f)
		},
		{
			"LobbyVersion",
			new ColumnDefinition<NetworkLobby>("Version", (NetworkLobby x) => x.VersionHighlight, (NetworkLobby x) => x.V.SortNumber, false, null, FilterType.Name, (NetworkLobby x) => x.ProtocolVersion)
		},
		{
			"PrintDealProductName",
			new ColumnDefinition<NetworkPrintDeal>("Product", (NetworkPrintDeal x) => x.ProductName, false, null, false, true)
		},
		{
			"PrintDealCompanyName",
			new ColumnDefinition<NetworkPrintDeal>("Company", delegate(NetworkPrintDeal x)
			{
				Company playerCompany = MarketSimulation.Active.GetPlayerCompany(x.Printer);
				return (playerCompany == null) ? null : playerCompany.Name;
			}, false, null, false, true)
		},
		{
			"PrintDealTotalPrinted",
			new ColumnDefinition<NetworkPrintDeal>("TotalPrinted", (NetworkPrintDeal x) => x.PhysicalCopies, true)
		},
		{
			"PrintDealInStock",
			new ColumnDefinition<NetworkPrintDeal>("In stock", (NetworkPrintDeal x) => x.Target.PhysicalCopies, true)
			{
				Tip = "ProductStockTip"
			}
		},
		{
			"PrintDealInStorage",
			new ColumnDefinition<NetworkPrintDeal>("In storage", (NetworkPrintDeal x) => GameSettings.Instance.GetPrintsInStorage(x.Target), true)
			{
				Tip = "ProductStorageTip"
			}
		},
		{
			"PrintDealGoal",
			new ColumnDefinition<NetworkPrintDeal>("Goal", (NetworkPrintDeal x) => (x.PerDay == 0) ? x.MaxCopies : x.PerDay, false)
		},
		{
			"PrintDealDeadline",
			new ColumnDefinition<NetworkPrintDeal>("Deadline", (NetworkPrintDeal x) => x.Deadline, true, null, true)
		},
		{
			"PrintDealCancel",
			new ColumnDefinition<NetworkPrintDeal>("Cancel", delegate(NetworkPrintDeal x)
			{
				x.Cancel();
			})
		}
	};

	[NonSerialized]
	private EventList<object> _items;

	[NonSerialized]
	public List<object> ActualItems = new List<object>();

	public readonly EventList<int> Selected = new EventList<int>();

	public bool MultiSelect;

	public Rect lastSize;

	public GameObject ContentPanel;

	public string[] Columns;

	[NonSerialized]
	public List<GUIColumn> GUIColumns = new List<GUIColumn>();

	public GUIColumn LastSort;

	public Scrollbar scrollbar;

	[NonSerialized]
	private RectTransform _rect;

	[NonSerialized]
	public Action OnDoubleClick;

	[NonSerialized]
	private GUIColumn _doubleClickColumn;

	[NonSerialized]
	private RectTransform _contentRect;

	private bool dirty;

	public bool LastSelectDirect;

	[NonSerialized]
	private bool _canDoubleClick = true;

	public Action<bool> OnSelectChange;

	public bool IgnoreTranslation;

	public float NextRefresh;

	public GameObject NoFilterMatch;

	public UnityEvent OnFilterUpdate;

	public int ColumnConfDirty;

	public bool DisableRefresh;

	public string SpecialID = "";

	[NonSerialized]
	public bool CreatedInGame;

	[NonSerialized]
	private bool _anyTotals;

	private bool _delayedLoad;

	private static Dictionary<object, int> _sortMaintain = new Dictionary<object, int>();

	[NonSerialized]
	private object[] SelectedBeforeChange;

	[NonSerialized]
	private bool Initialized;

	private int _updateIDX;

	[NonSerialized]
	private float _lastSelection;

	public EventList<object> Items
	{
		get
		{
			return _items;
		}
		set
		{
			SaveSelected();
			_items = value;
			_items.OnChange = delegate
			{
				UpdateActiveList();
			};
			_items.PreChange = delegate
			{
				if (SelectedBeforeChange == null)
				{
					SelectedBeforeChange = GetSelected<object>();
				}
			};
			Action onChange = Selected.OnChange;
			Selected.OnChange = null;
			Selected.Clear();
			Selected.OnChange = onChange;
			dirty = true;
			UpdateActiveList();
		}
	}

	public RectTransform rectTransform
	{
		get
		{
			if (_rect == null)
			{
				_rect = GetComponent<RectTransform>();
			}
			return _rect;
		}
	}

	public RectTransform ContentRect
	{
		get
		{
			if (_contentRect == null)
			{
				_contentRect = ContentPanel.GetComponent<RectTransform>();
			}
			return _contentRect;
		}
	}

	public GUIColumn this[string key]
	{
		get
		{
			Initialize();
			return GUIColumns.FirstOrDefault((GUIColumn x) => x.name.Equals(key));
		}
		set
		{
		}
	}

	public int Scroll
	{
		get
		{
			return Mathf.FloorToInt(scrollbar.value * (float)Mathf.Max(0, ActualItems.Count - Mathf.FloorToInt(ContentRect.rect.height / 24f) + 1 + (_anyTotals ? 1 : 0)));
		}
	}

	public bool IsFocused
	{
		get
		{
			if (ListViewFocus.ActiveListView == this && ActualItems.Count > 0)
			{
				return !DevConsole.Console.isOpen;
			}
			return false;
		}
	}

	private static string GetCompanyPlayer(Company c)
	{
		if (c.Player)
		{
			NetworkPlayer player = NetworkManager.GetPlayer(c.NetworkPlayerID);
			if (player == null)
			{
				return "Yes".Loc();
			}
			return player.Name;
		}
		return "No".Loc();
	}

	private static void JoinLobby(NetworkLobby lobby)
	{
		NetworkManager.Instance.HandleJoinLobby(lobby);
	}

	private static int GetResearchedCount(TechLevel t)
	{
		int num = 0;
		foreach (Company allCompany in MarketSimulation.Active.GetAllCompanies())
		{
			if (allCompany.GetLocalLatestResearch(t.Spec, 0) >= t.Year)
			{
				num++;
			}
		}
		return num;
	}

	private static void TakeOverItem(WorkItem item)
	{
		if (!item.AutoDev)
		{
			return;
		}
		using (IEnumerator<AutoDevWorkItem> enumerator = GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>().GetEnumerator())
		{
			while (enumerator.MoveNext() && !enumerator.Current.TakeOverTask(item))
			{
			}
		}
	}

	private static void SetPrintHighlight(PrintJob job, bool highlight)
	{
		if (highlight)
		{
			GameSettings.Instance.BoxController.Highlight = job.Target;
		}
		else if (GameSettings.Instance.BoxController.Highlight == job.Target)
		{
			GameSettings.Instance.BoxController.Highlight = null;
		}
	}

	private static void SetManufacturePriority(PrintJob p, object priority)
	{
		float priority2 = p.Priority;
		p.Priority = Mathf.RoundToInt((float)priority * 10f);
		if (p.Priority != priority2)
		{
			DistributionWindow.RefreshHardwareStats();
		}
	}

	private static string GetVacationMonths(Team t)
	{
		if (t.VacationSpread == 11)
		{
			return "Allyear".Loc();
		}
		if (t.VacationSpread == 0)
		{
			return SDateTime.Months[t.VacationMonth].Loc();
		}
		return (SDateTime.Months[t.VacationMonth] + "Abbr").Loc() + " - " + (SDateTime.Months[(t.VacationMonth + t.VacationSpread) % 12] + "Abbr").Loc();
	}

	private static void RoomGroupStyling(RoomGroup group, bool outdoor)
	{
		List<RoomStyle> styles = GameSettings.Instance.RoomStyles.Where((RoomStyle x) => !x.RoofStyle && x.OutdoorStyle == outdoor).ToList();
		WindowManager.Instance.MultiWindow.Show("Room style", styles.Select((RoomStyle x) => x.StyleName), delegate(int x)
		{
			RoomStyle roomStyle = ((x < 0) ? null : styles[x]);
			if (outdoor)
			{
				group.Outdoor = roomStyle;
			}
			else
			{
				group.Indoor = roomStyle;
			}
			if (roomStyle != null)
			{
				foreach (Room room in group.GetRooms())
				{
					roomStyle.Apply(room, null);
				}
			}
		}, true);
	}

	private static void DeleteSaveFile(SaveGame file)
	{
		DialogWindow diag = WindowManager.SpawnDialog();
		diag.Show("DeleteSaveConf".Loc(), false, DialogWindow.DialogType.Warning, new KeyValuePair<string, Action>("Yes", delegate
		{
			SaveGameManager.Instance.DeleteSave(file, true);
			diag.Window.Close();
		}), new KeyValuePair<string, Action>("No", delegate
		{
			diag.Window.Close();
		}));
		if (MainMenuController.Instance != null && MainMenuController.Instance.NetworkWindow.Window.Shown)
		{
			diag.Window.SetParentWindow(MainMenuController.Instance.NetworkWindow.Window);
		}
	}

	private static void ToggleMod(ModPackage x, bool enabled)
	{
		if (x.Enabled == enabled)
		{
			return;
		}
		x.Enabled = enabled;
		if (x.Enabled)
		{
			ModPackage[] mods = GameData.ModPackages.Where((ModPackage z) => z.Enabled).ToArray();
			Dictionary<string, RandomNameGenerator> generators = GameData.MergeGenerators(GameData.AllNameGenerators(mods));
			string text;
			try
			{
				SoftwareType[] types = GameData.AllSoftwareTypes(mods).ToArray();
				text = GameData.CheckForErrors(types) ?? ModPackage.OtherErrors(types, GameData.AllCompanyTypes(mods).ToArray(), generators);
			}
			catch (Exception ex)
			{
				text = ex.Message;
			}
			if (text != null)
			{
				x.Enabled = false;
				WindowManager.SpawnDialog("ModEnableError".Loc(), true, DialogWindow.DialogType.Error);
			}
		}
		ActorCustomization.Instance.UpdatePersonalities();
		ActorCustomization.Instance.UpdateSpec();
		ActorCustomization.Instance.ScaleAllSkillStats();
		ActorCustomization.Instance.UpdateLeadFocusCombo();
	}

	private static void StaffWorkMinus(Actor x)
	{
		x.StaffOn--;
		if (x.StaffOn == -1)
		{
			x.StaffOn = 23;
		}
		x.StaffOff = (x.StaffOn + x.GetStaffHours()) % 24;
		CalendarWindow.ScheduleRefresh = true;
		StaffWindow.RefreshStaffTime(x);
	}

	private static void SelectServerFallback(ServerGroup x)
	{
		List<ServerGroup> servers = GameSettings.Instance.GetAllServerGroups().ToList();
		servers.Remove(x);
		if (servers.Count > 0)
		{
			WindowManager.Instance.MultiWindow.Show("Select fallback", servers.Select((ServerGroup z) => z.GetDisplayName()), delegate(int i)
			{
				x.Fallback = ((i == -1) ? null : servers[i].Name);
			}, true);
		}
	}

	private static void UploadWorkshopItem(IWorkshopItem item)
	{
		if (item.CanUpload)
		{
			bool hasShownError;
			if (item.PrepareForUpload(out hasShownError))
			{
				string text = SteamWorkshop.CheckValid(item.GetValidExts(), item.FolderPath());
				if (text == null)
				{
					SteamWorkshop.Instance.UploadMod(item);
				}
				else
				{
					WindowManager.SpawnDialog(text, true, DialogWindow.DialogType.Error);
				}
			}
			else if (!hasShownError)
			{
				WindowManager.SpawnDialog("SteamUploadPrepareError".Loc(), true, DialogWindow.DialogType.Error);
			}
		}
		else
		{
			WindowManager.SpawnDialog("SteamUploadDenied".Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	private static void DeleteBlueprint(BuildingPrefab item)
	{
	}

	private static void FreezeWaypoint(WayPointEditorWindow.WayPoint x)
	{
		int num = WayPointEditorWindow.Instance.WayPointList.Items.IndexOf(x);
		if (WayPointEditorWindow.Instance.CurrentWayPoint != num)
		{
			WayPointEditorWindow.Instance.FreezeFrame = true;
			WayPointEditorWindow.Instance.CurrentWayPoint = num;
		}
		else
		{
			WayPointEditorWindow.Instance.FreezeFrame = !WayPointEditorWindow.Instance.FreezeFrame;
		}
	}

	private static void SellStock(NewStock stock)
	{
		MarketSimulation.Active.FindBuyer(stock, stock.Shares, SDateTime.Now());
	}

	private static uint GetStockableCopies(PrintJob order)
	{
		return order.Target.GetTotalPhysicalSales();
	}

	private static int ChangeHour(int hour, int refHour, int change)
	{
		int num = hour.AddHour(change);
		if (num == refHour)
		{
			num = num.AddHour(change);
		}
		return num;
	}

	private static string DealPerf(float performance)
	{
		if (performance < -0.1f)
		{
			return "QualityAmount1".Loc();
		}
		if (performance < 0f)
		{
			return "QualityAmount2".Loc();
		}
		if (performance == 0f)
		{
			return "NotApplicableAbbr".Loc();
		}
		if (performance < 0.1f)
		{
			return "QualityAmount4".Loc();
		}
		return "QualityAmount5".Loc();
	}

	private static object CheckValidEdu(Actor a, bool forComp, bool filter)
	{
		if (HUD.Instance.educationWindow.ValidForEdu(a))
		{
			if (forComp)
			{
				return 2;
			}
			if (filter)
			{
				return true;
			}
			return "|Checkmark|#00AA00";
		}
		if (forComp)
		{
			return 2;
		}
		if (filter)
		{
			return false;
		}
		return "NotValidEducation".Loc() + "|Stop|#AA0000";
	}

	private static object HWSWIcon(ContractWork work, bool forComp, bool filter)
	{
		if (work.Hardware)
		{
			if (forComp)
			{
				return 1;
			}
			if (filter)
			{
				return "Hardware".Loc();
			}
			return "Hardware".Loc() + "|Hardware|#323232";
		}
		if (forComp)
		{
			return 0;
		}
		if (filter)
		{
			return "Software".Loc();
		}
		return "Software".Loc() + "|Software|#323232";
	}

	private static object CheckCompat(SoftwareProduct p, bool forComp, bool filter)
	{
		if (ProductWindow.CurrentTechs != null)
		{
			if (ProductWindow.TechSpecs == null)
			{
				foreach (KeyValuePair<string, TechLevel> currentTech in ProductWindow.CurrentTechs)
				{
					if (p.TechLevels.GetOrDefault(currentTech.Key) == null)
					{
						if (forComp)
						{
							return 3;
						}
						if (filter)
						{
							return "NotCompatibleFeat".Loc();
						}
						return "NotCompatibleFeat".Loc() + "|Stop|#AA0000";
					}
				}
			}
			else
			{
				int num = 0;
				for (int i = 0; i < ProductWindow.TechSpecs.Length; i++)
				{
					string key = ProductWindow.TechSpecs[i];
					TechLevel orDefault = p.TechLevels.GetOrDefault(key);
					if (orDefault == null)
					{
						num = 3;
						break;
					}
					TechLevel orDefault2 = ProductWindow.CurrentTechs.GetOrDefault(key);
					if (orDefault2 != null && orDefault.Year < orDefault2.Year)
					{
						num = 2;
					}
				}
				switch (num)
				{
				case 2:
					if (forComp)
					{
						return 2;
					}
					if (filter)
					{
						return "NotCompatibleTech".Loc();
					}
					return "NotCompatibleTech".Loc() + "|Exclamation|#AAAA00";
				case 3:
					if (forComp)
					{
						return 3;
					}
					if (filter)
					{
						return "NotCompatibleFeat".Loc();
					}
					return "NotCompatibleFeat".Loc() + "|Stop|#AA0000";
				}
			}
		}
		if (p.IsMock)
		{
			if (forComp)
			{
				return 1;
			}
			if (filter)
			{
				return "Indevelopment".Loc();
			}
			return "Indevelopment".Loc() + "|Info|#0000AA";
		}
		if (forComp)
		{
			return 0;
		}
		if (filter)
		{
			return "OK".Loc();
		}
		return "|Checkmark|#00AA00";
	}

	private static string GetServerForProc(IServerItem item)
	{
		if (!GameSettings.Instance.UnsupportedServerItems.Contains(item))
		{
			foreach (ServerGroup allServerGroup in GameSettings.Instance.GetAllServerGroups())
			{
				if (allServerGroup.Items.Contains(item))
				{
					return allServerGroup.Name;
				}
			}
		}
		return "None".Loc().FontColor(Color.red);
	}

	private static object ServerStatus(ServerGroup s, bool forComp, bool filter)
	{
		if (s.Broken)
		{
			if (s.Fallback != null)
			{
				if (forComp)
				{
					return 1;
				}
				if (filter)
				{
					return "Fallback".Loc();
				}
				return "Fallback".Loc() + "|ArrowRight|#00AAAA";
			}
			if (forComp)
			{
				return 3;
			}
			if (filter)
			{
				return "Broken".Loc();
			}
			return "Broken".Loc() + "|Lightning|#AA0000";
		}
		if (s.Available == 0f)
		{
			if (forComp)
			{
				return 2;
			}
			if (filter)
			{
				return "Overloaded".Loc();
			}
			return "Overloaded".Loc() + "|Exclamation|#AAAA00";
		}
		if (forComp)
		{
			return 0;
		}
		if (filter)
		{
			return "OK".Loc();
		}
		return "OK".Loc() + "|Checkmark|#00AA00";
	}

	private static object DistributionAccepted(DistributionPlatform p)
	{
		if (!GameSettings.Instance.MyCompany.IsSigned(p))
		{
			return "|Stop|#323232";
		}
		return "|Checkmark|#323232";
	}

	private static void DetailForPrintProduct(PrintJob job)
	{
		SoftwareProduct product;
		AddOnProduct product2;
		if ((product = job.Target as SoftwareProduct) != null)
		{
			HUD.Instance.GetProductWindow(null).ShowProductDetails(product);
		}
		else if ((product2 = job.Target as AddOnProduct) != null)
		{
			HUD.Instance.GetProductWindow(null).ShowAddonDetails(product2);
		}
		else
		{
			WindowManager.SpawnDialog("Nodataavailable".Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	private static void UpdateServerColor(ServerGroup g, object c)
	{
		g.WireColor = (Color)c;
		CameraScript.Instance.WireRender.ForceDirty = true;
	}

	private static void UpdateAssemblyColor(AssemblyLine g, object c)
	{
		g.AColor = (Color)c;
		g.PlayerEdited = true;
	}

	private static void RenameAssembly(AssemblyLine g)
	{
		WindowManager.SpawnInputDialog("NameChangeTitle".Loc(), "Rename".Loc(), g.Name, delegate(string x)
		{
			if (GameSettings.Instance.GetAssemblyLines().Any((AssemblyLine z) => z.Name.Equals(x)))
			{
				WindowManager.SpawnDialog("AssemblyNameError".Loc(), true, DialogWindow.DialogType.Error);
			}
			else
			{
				g.Name = x;
				g.PlayerEdited = true;
			}
		});
	}

	private static void AssignToAssembly(AssemblyLine g)
	{
		Dictionary<PrintJob, int> dictionary = new Dictionary<PrintJob, int>();
		lock (GameSettings.Instance.PrintOrders)
		{
			foreach (PrintJob printOrder in GameSettings.Instance.PrintOrders)
			{
				int num = g.IsCompatible(printOrder);
				if (num > 0)
				{
					dictionary[printOrder] = num;
				}
			}
		}
		List<PrintJob> tasksUnsafe = g.GetTasksUnsafe();
		for (int i = 0; i < tasksUnsafe.Count; i++)
		{
			PrintJob printJob = tasksUnsafe[i];
			if (!dictionary.ContainsKey(printJob))
			{
				dictionary[printJob] = g.IsCompatible(printJob);
			}
		}
		if (dictionary.Count > 0)
		{
			List<PrintJob> keys = dictionary.Keys.ToList();
			bool[] selected = keys.SelectInPlace((PrintJob x) => g.HasTask(x));
			WindowManager.Instance.MultiWindow.ShowMulti("Assign", dictionary.Select((KeyValuePair<PrintJob, int> x) => x.Key.Target.GetIdentifyingName() + ((x.Value > 1) ? "" : "^")), selected, delegate(int[] xs)
			{
				xs.IndexToBool(selected);
				for (int j = 0; j < selected.Length; j++)
				{
					if (selected[j])
					{
						g.AddTask(keys[j], true);
					}
					else
					{
						g.RemoveTask(keys[j], true);
					}
				}
			}, true, false, false, false, "AssemblyLineWarning");
		}
		else
		{
			WindowManager.SpawnDialog("NoValidPrintTasks".Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	private static void TaskToAssembly(PrintJob t)
	{
		if (t.Hardware)
		{
			GameSettings.Instance.PromptPrintAssignment(t, false);
		}
	}

	private static string GetArrival(Actor ac)
	{
		if (ac.isActiveAndEnabled)
		{
			return "Now".Loc();
		}
		SDateTime value;
		if (!GameSettings.Instance.sActorManager.GetAwaitingDict().TryGetValue(ac, out value))
		{
			return "NotApplicableAbbr".Loc();
		}
		return value.ToCompactString2();
	}

	private static float GetArrivalOrder(Actor ac)
	{
		if (ac.isActiveAndEnabled)
		{
			return -1f;
		}
		SDateTime value;
		return GameSettings.Instance.sActorManager.GetAwaitingDict().TryGetValue(ac, out value) ? value.ToInt() : 0;
	}

	private static void ViewAssembly(AssemblyLine g)
	{
		if (g.Printers.Count <= 0)
		{
			return;
		}
		int num = g.Printers.Mode((ProductPrinter x) => x.Furn.Floor, 0);
		Vector3 zero = Vector3.zero;
		int num2 = 0;
		foreach (ProductPrinter printer in g.Printers)
		{
			if (printer.Furn.Floor == num)
			{
				zero += printer.transform.position;
				num2++;
			}
		}
		zero /= (float)num2;
		CameraScript.Instance.MoveTo(zero.FlattenVector3(), num);
		SelectorController.Instance.SetSelection(g.Printers.Select((ProductPrinter x) => x.Furn));
	}

	private static void ViewServer(ServerGroup g)
	{
		List<Server> list = (from x in g.Servers.OfType<Server>()
			where !x.furn.IsReferenceNull()
			select x).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		int num = list.Mode((Server x) => x.furn.Floor, 0);
		Vector3 zero = Vector3.zero;
		int num2 = 0;
		foreach (Server item in list)
		{
			if (item.furn.Floor == num)
			{
				zero += item.transform.position;
				num2++;
			}
		}
		zero /= (float)num2;
		CameraScript.Instance.MoveTo(zero.FlattenVector3(), num);
		SelectorController.Instance.SetSelection(list.SelectNotNull((Server x) => x.furn));
	}

	private static float GetServerWatt(ServerGroup g)
	{
		return (from x in g.Servers.OfType<Server>()
			where !x.furn.IsReferenceNull()
			select x).SumSafe((Server x) => x.furn.CurrentWattage);
	}

	private static void PayoutInvestment(Investment x)
	{
		GameSettings.Instance.MyCompany.MakeTransaction(x.CurrentValue, Company.TransactionCategory.Stocks, false, x.Stock.Name);
		if (x.LastTaxValue >= 0f)
		{
			GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Investments, x.CurrentValue - x.LastTaxValue);
		}
		GameSettings.Instance.Investments.Remove(x);
		HUD.Instance.insuranceWindow.UpdateInvestments();
		GameSettings.Instance.RegisterStat("StockExchange", x.CurrentValue - x.Amount);
		GameSettings.Instance.TransmitExtraWorth();
	}

	private static void ToggleDistributionDeal(Company c, bool active)
	{
		if (GameSettings.Instance.MyCompany.Distribution != null)
		{
			c.SignPlatform(GameSettings.Instance.MyCompany.Distribution, active);
		}
	}

	private static void TogglePlayerDistributionDeal(DistributionPlatform p, bool active)
	{
		GameSettings.Instance.MyCompany.MarkInterested(p.Owner, active, 0);
		if (!active)
		{
			GameSettings.Instance.MyCompany.SignPlatform(p, false);
		}
		HUD.Instance.digitalDistributionWindow.UpdateInfo();
	}

	private static void LoanPayout(Loan loanItem)
	{
		double amount = (double)loanItem.Months * loanItem.Monthly - (double)((float)loanItem.Months * loanItem.MonthlyInterest);
		if (!GameSettings.Instance.MyCompany.CanMakeTransaction(0.0 - amount))
		{
			return;
		}
		WindowManager.Instance.ShowMessageBox("LoanPayoutConfirmation".Loc(amount.Currency(), ((float)loanItem.Months * loanItem.MonthlyInterest).Currency()), true, DialogWindow.DialogType.Question, delegate
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0.0 - amount, Company.TransactionCategory.Loan, false);
			if (loanItem.Payee != null)
			{
				loanItem.Payee.MakeTransaction(amount, Company.TransactionCategory.Loan, GameSettings.Instance.MyCompany.Name);
			}
			GameSettings.Instance.Loans.Remove(loanItem);
			HUD.Instance.loanWindow.UpdateLoans();
			GameSettings.Instance.TransmitExtraWorth();
		});
	}

	private static string GetIsSubsidiary(Company c)
	{
		Company ownerCompany = c.OwnerCompany;
		if (ownerCompany != null)
		{
			if (ownerCompany.OwnerCompany != GameSettings.Instance.MyCompany)
			{
				return ownerCompany.Name;
			}
			return "Yes".Loc();
		}
		return "No".Loc();
	}

	private static float RoundReviewScore(float score)
	{
		return (float)Mathf.RoundToInt(score * 10f) / 2f;
	}

	private static void CopySaveUUID(SaveGame s)
	{
		GUIUtility.systemCopyBuffer = s.ActualName + "\nPlayer ID: " + s.NetworkData.LocalUniqueID + "\n" + s.InGameTime.ToCompactString() + "\n" + string.Join("\n", s.NetworkData.SaveUUIDs);
	}

	private static string StringOrNone(string s)
	{
		return s ?? "None".Loc();
	}

	public void RefreshTotals()
	{
		_anyTotals = GUIColumns.Any((GUIColumn x) => x.Total != null);
	}

	public void UpdateActiveList(bool forceRefresh = true)
	{
		bool flag = forceRefresh;
		if (forceRefresh)
		{
			SaveSelected();
			ActualItems.Clear();
		}
		bool flag2 = false;
		for (int i = 0; i < GUIColumns.Count; i++)
		{
			GUIColumn gUIColumn = GUIColumns[i];
			if ((gUIColumn.isActiveAndEnabled || gUIColumn.ForceFilter) && gUIColumn.FilterActive && gUIColumn.Filter != FilterType.None)
			{
				flag2 = true;
				break;
			}
		}
		if (flag2)
		{
			if (!forceRefresh)
			{
				SaveSelected();
				for (int j = 0; j < ActualItems.Count; j++)
				{
					_sortMaintain[ActualItems[j]] = j;
				}
				ActualItems.Clear();
				flag = true;
			}
			for (int k = 0; k < Items.Count; k++)
			{
				bool flag3 = true;
				object item = Items[k];
				for (int l = 0; l < GUIColumns.Count; l++)
				{
					GUIColumn column = GUIColumns[l];
					if (!FilterItem(item, column))
					{
						flag3 = false;
						break;
					}
				}
				if (flag3)
				{
					ActualItems.Add(item);
				}
			}
			if (_sortMaintain.Count > 0)
			{
				ActualItems.Sort((object x, object y) => _sortMaintain.GetOrDefault(x, int.MaxValue).CompareTo(_sortMaintain.GetOrDefault(y, int.MaxValue)));
			}
			OnFilterUpdate.Invoke();
			_sortMaintain.Clear();
		}
		else if (forceRefresh)
		{
			ActualItems.AddRange(Items);
			OnFilterUpdate.Invoke();
		}
		if (NoFilterMatch != null)
		{
			NoFilterMatch.SetActive(flag2 && ActualItems.Count == 0 && Items.Count > 0);
		}
		if (flag)
		{
			dirty = true;
		}
		GUIColumns.ForEach(delegate(GUIColumn x)
		{
			x.TotalDirty = true;
		});
		NextRefresh = Time.realtimeSinceStartup + UnityEngine.Random.Range(5f, 10f);
	}

	public bool FilterItem(object item, GUIColumn column)
	{
		if ((!column.ForceFilter && !column.isActiveAndEnabled) || !column.FilterActive || column.Filter == FilterType.None)
		{
			return true;
		}
		object obj = ((column.GetFilterValue != null) ? column.GetFilterValue(item) : ((column.Filter == FilterType.Name) ? column.Label(item) : item));
		if (obj == null)
		{
			return true;
		}
		switch (column.Filter)
		{
		case FilterType.Date:
		{
			int num3 = ((SDateTime)obj).ToInt();
			if ((double)num3 >= column.FilterNumber[0])
			{
				return (double)num3 <= column.FilterNumber[1];
			}
			return false;
		}
		case FilterType.Bool:
			return (bool)obj == column.FilterBool;
		case FilterType.Name:
			return column.FilterName.Contains(obj.ToString());
		case FilterType.Number:
		{
			object obj2;
			double num2;
			if ((obj2 = obj) is float)
			{
				float num = (float)obj2;
				num2 = num;
			}
			else
			{
				num2 = (double)obj;
			}
			if (num2 >= column.FilterNumber[0])
			{
				return num2 <= column.FilterNumber[1] + 0.01;
			}
			return false;
		}
		case FilterType.Bitmask:
			return ((int)obj & column.FilterMask) > 0;
		case FilterType.Trait:
		{
			Employee.Trait trait = (Employee.Trait)obj;
			if (column.RequireAllTraits)
			{
				return (trait & column.TraitMask) == column.TraitMask;
			}
			return (trait & column.TraitMask) != 0;
		}
		case FilterType.Query:
			return obj.ToString().ToLower().Contains(column.FilterQuery.text.ToLower());
		case FilterType.RoomGroup:
		{
			Actor actor;
			if ((object)(actor = item as Actor) != null)
			{
				return actor.AssignedRoomGroups.Any((string x) => column.FilterName.Contains(x));
			}
			return false;
		}
		default:
			return true;
		}
	}

	public void KeepWithin()
	{
	}

	public void Awake()
	{
		if (_items == null)
		{
			Items = new EventList<object>();
		}
	}

	private void OnEnable()
	{
		if (MultiSelect)
		{
			HelpTipPanel.Show(HintController.Hints.HintMultiSelectList, rectTransform);
		}
		if (_delayedLoad)
		{
			_delayedLoad = false;
			LoadOrder();
			GUIColumns.ForEach(delegate(GUIColumn x)
			{
				x.LoadActiveState();
			});
		}
	}

	public void Initialize()
	{
		if (!Initialized)
		{
			Initialized = true;
			string[] columns = Columns;
			foreach (string column in columns)
			{
				AddColumn(column);
			}
			if (!GameSettings.Instance.IsReferenceNull() && !GameSettings.Instance.ColumnDataLoaded)
			{
				_delayedLoad = true;
			}
			else
			{
				LoadOrder();
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(ContentRect);
			UpdateElements();
			lastSize = rectTransform.rect;
			Selected.OnChange = delegate
			{
				if (OnSelectChange != null)
				{
					OnSelectChange(LastSelectDirect);
					LastSelectDirect = false;
				}
			};
			GetComponent<ScrollRect>().onValueChanged.AddListener(delegate
			{
				UpdateInUI();
			});
		}
		CreatedInGame = !GameSettings.Instance.IsReferenceNull();
	}

	public void LoadOrder()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		string path = GetPath();
		string[] value;
		if (!GameSettings.Instance.ColumnOrder.TryGetValue(path, out value))
		{
			return;
		}
		List<ValueTuple<GUIColumn, int>> list = null;
		foreach (GUIColumn gUIColumn2 in GUIColumns)
		{
			if (!value.Contains(gUIColumn2.name))
			{
				if (list == null)
				{
					list = new List<ValueTuple<GUIColumn, int>>();
				}
				list.Add(new ValueTuple<GUIColumn, int>(gUIColumn2, gUIColumn2.transform.GetSiblingIndex()));
			}
		}
		int num = 0;
		for (int i = 0; i < value.Length; i++)
		{
			GUIColumn gUIColumn = this[value[i]];
			if (gUIColumn != null)
			{
				gUIColumn.transform.SetSiblingIndex(num);
				num++;
			}
		}
		if (list != null)
		{
			list.ForEach(delegate(ValueTuple<GUIColumn, int> x)
			{
				x.Item1.transform.SetSiblingIndex(x.Item2);
			});
		}
	}

	private void Start()
	{
		Initialize();
	}

	public bool ValidInAnyScene(FilterType? type)
	{
		if (type.HasValue)
		{
			switch (type.Value)
			{
			case FilterType.Name:
			case FilterType.Bool:
			case FilterType.Bitmask:
			case FilterType.Query:
				return true;
			}
		}
		return false;
	}

	private void AddColumn(string column)
	{
		bool flag = false;
		if (column.StartsWith("*"))
		{
			flag = true;
			column = column.Substring(1);
		}
		ColumnDef orNull = ColumnDefinitions.GetOrNull(column);
		if (orNull != null)
		{
			FilterType filterType = ((WindowManager.Instance.MainScene || ValidInAnyScene(orNull.FilterType)) ? (orNull.FilterType ?? FilterType.None) : FilterType.None);
			GUIColumn gUIColumn = UnityEngine.Object.Instantiate(ObjectDatabase.Instance.GetColumnPrefab(filterType));
			gUIColumn.transform.SetParent(ContentPanel.transform, false);
			gUIColumn.name = column;
			gUIColumn.Filter = filterType;
			gUIColumn.SetVariable = orNull.SetValue;
			gUIColumn.GetFilterValue = orNull.FilterConversion;
			gUIColumn.HeaderValue = orNull.Header;
			gUIColumn.ReverseHide = flag;
			if (orNull.Action != null)
			{
				gUIColumn.Action = orNull.Action;
				gUIColumn.Type = GUIColumn.ColumnType.Action;
				gUIColumn.Header.text = "Action".Loc();
			}
			else
			{
				gUIColumn.Label = orNull.Label;
				gUIColumn.Total = orNull.Total;
				gUIColumn.TotalLabel = orNull.TotalLabel;
				gUIColumn.TotalFunc = orNull.TotalDefault;
				gUIColumn.TotalValid = orNull.TotalTypes;
				gUIColumn.Comparison = orNull.Comparison;
				gUIColumn.Type = orNull.TypeOverride ?? GUIColumn.ColumnType.Label;
				gUIColumn.Header.text = (IgnoreTranslation ? gUIColumn.HeaderValue.LocDef(gUIColumn.HeaderValue) : gUIColumn.HeaderValue.LocNoColor());
				gUIColumn.ContinuallyUpdate = orNull.Volatile;
			}
			gUIColumn.Parent = this;
			float result;
			if (Options.GetColumnWidth(SpecialID + column, out result))
			{
				gUIColumn.layoutElement.preferredWidth = result;
			}
			else if (orNull.Width.HasValue)
			{
				gUIColumn.layoutElement.preferredWidth = orNull.Width.Value + (float)((filterType != FilterType.None) ? 8 : 0);
			}
			if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.ColumnsDisabled.Contains(SpecialID + column))
			{
				gUIColumn.ToggleActive(true, flag);
			}
			else if (flag)
			{
				gUIColumn.ToggleActive(true, false);
			}
			gUIColumn.TipPanel.TooltipDescription = orNull.Tip;
			GUIColumns.Add(gUIColumn);
			if (orNull.DoubleClickAction)
			{
				_doubleClickColumn = gUIColumn;
			}
			RefreshTotals();
		}
	}

	public void AddColumn(ColumnDef c)
	{
		FilterType filterType = (WindowManager.Instance.MainScene ? (c.FilterType ?? FilterType.None) : FilterType.None);
		GUIColumn gUIColumn = UnityEngine.Object.Instantiate(ObjectDatabase.Instance.GetColumnPrefab(filterType));
		gUIColumn.transform.SetParent(ContentPanel.transform, false);
		gUIColumn.name = c.Header;
		gUIColumn.Filter = filterType;
		gUIColumn.SetVariable = c.SetValue;
		gUIColumn.GetFilterValue = c.FilterConversion;
		gUIColumn.HeaderValue = c.Header;
		if (c.Action != null)
		{
			gUIColumn.Action = c.Action;
			gUIColumn.Type = GUIColumn.ColumnType.Action;
			gUIColumn.Header.text = "Action".Loc();
		}
		else
		{
			gUIColumn.Label = c.Label;
			gUIColumn.Total = c.Total;
			gUIColumn.TotalLabel = c.TotalLabel;
			gUIColumn.TotalFunc = c.TotalDefault;
			gUIColumn.TotalValid = c.TotalTypes;
			gUIColumn.Comparison = c.Comparison;
			gUIColumn.Type = c.TypeOverride ?? GUIColumn.ColumnType.Label;
			gUIColumn.Header.text = (IgnoreTranslation ? gUIColumn.HeaderValue.LocDef(gUIColumn.HeaderValue) : gUIColumn.HeaderValue.LocNoColor());
			gUIColumn.ContinuallyUpdate = c.Volatile;
		}
		gUIColumn.Parent = this;
		if (c.Width.HasValue)
		{
			gUIColumn.layoutElement.preferredWidth = c.Width.Value + (float)((filterType != FilterType.None) ? 8 : 0);
		}
		gUIColumn.TipPanel.TooltipDescription = c.Tip;
		GUIColumns.Add(gUIColumn);
		if (c.DoubleClickAction)
		{
			_doubleClickColumn = gUIColumn;
		}
		RefreshTotals();
	}

	public void AddColumn(string label, Func<object, object> content, Comparison<object> comparison, bool isVolatile, float defaultWidth = 128f, string tip = null)
	{
		GUIColumn gUIColumn = UnityEngine.Object.Instantiate(ObjectDatabase.Instance.GetColumnPrefab(FilterType.None));
		gUIColumn.transform.SetParent(ContentPanel.transform, false);
		gUIColumn.name = label;
		gUIColumn.HeaderValue = label;
		gUIColumn.Label = content;
		gUIColumn.Comparison = comparison;
		gUIColumn.Type = GUIColumn.ColumnType.Label;
		gUIColumn.Header.text = gUIColumn.HeaderValue.LocNoColor();
		gUIColumn.ContinuallyUpdate = isVolatile;
		gUIColumn.Parent = this;
		gUIColumn.layoutElement.preferredWidth = defaultWidth;
		gUIColumn.TipPanel.ToolTipValue = tip;
		GUIColumns.Add(gUIColumn);
		RefreshTotals();
	}

	public void AddFilterColumn(string label, Func<object, object> content, Comparison<object> comparison, bool isVolatile, FilterType filterType, Func<object, object> filterConversion, float defaultWidth = 128f, string tip = null)
	{
		GUIColumn gUIColumn = UnityEngine.Object.Instantiate(ObjectDatabase.Instance.GetColumnPrefab(filterType));
		gUIColumn.transform.SetParent(ContentPanel.transform, false);
		gUIColumn.name = label;
		gUIColumn.HeaderValue = label;
		gUIColumn.Label = content;
		gUIColumn.Comparison = comparison;
		gUIColumn.Type = GUIColumn.ColumnType.Label;
		gUIColumn.Header.text = gUIColumn.HeaderValue.LocNoColor();
		gUIColumn.ContinuallyUpdate = isVolatile;
		gUIColumn.Filter = filterType;
		gUIColumn.GetFilterValue = filterConversion;
		gUIColumn.Parent = this;
		gUIColumn.layoutElement.preferredWidth = defaultWidth;
		gUIColumn.TipPanel.ToolTipValue = tip;
		GUIColumns.Add(gUIColumn);
		RefreshTotals();
	}

	public void AddActionColumn(string label, Action<object> action, bool isVolatile, float defaultWidth = 128f, string tip = null)
	{
		GUIColumn gUIColumn = UnityEngine.Object.Instantiate(ObjectDatabase.Instance.GetColumnPrefab(FilterType.None));
		gUIColumn.transform.SetParent(ContentPanel.transform, false);
		gUIColumn.name = label;
		gUIColumn.HeaderValue = label;
		gUIColumn.Action = action;
		gUIColumn.Type = GUIColumn.ColumnType.Action;
		gUIColumn.Header.text = "Action".Loc();
		gUIColumn.Parent = this;
		gUIColumn.layoutElement.preferredWidth = defaultWidth;
		gUIColumn.TipPanel.ToolTipValue = tip;
		GUIColumns.Add(gUIColumn);
		RefreshTotals();
	}

	public void ResetSortHeaders()
	{
		GUIColumns.ForEach(delegate(GUIColumn x)
		{
			x.SetSort(false, false);
		});
	}

	public void UpdateElements(bool sort = true)
	{
		if (sort && LastSort != null && LastSort.isActiveAndEnabled)
		{
			LastSort.Sort(!LastSort.SortAsc, false);
		}
		foreach (GUIColumn item in GUIColumns.Where((GUIColumn x) => x != null && x.gameObject.activeInHierarchy))
		{
			item.UpdateElements();
		}
		UpdateSelected();
	}

	public void UpdateSelected()
	{
		foreach (GUIColumn item in GUIColumns.Where((GUIColumn x) => x != null))
		{
			item.UpdateSelected();
		}
	}

	public void UpdateInUI()
	{
		for (int i = 0; i < GUIColumns.Count; i++)
		{
			GUIColumn gUIColumn = GUIColumns[i];
			if (gUIColumn != null && gUIColumn.gameObject.activeInHierarchy)
			{
				gUIColumn.UpdateElements();
				gUIColumn.UpdateSelected();
			}
		}
	}

	public void SaveSelected()
	{
		if (SelectedBeforeChange == null)
		{
			SelectedBeforeChange = GetSelected<object>();
		}
		else if (!dirty)
		{
			SelectedBeforeChange = SelectedBeforeChange.Concat(GetSelected<object>().AsEnumerable()).Distinct().ToArray();
		}
	}

	private int GetIndexOf(object obj)
	{
		for (int i = 0; i < ActualItems.Count; i++)
		{
			if (ActualItems[i] == obj)
			{
				return i;
			}
		}
		return -1;
	}

	private void Update()
	{
		if (CreatedInGame && GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (ColumnConfDirty > 0)
		{
			ColumnConfDirty--;
			if (ColumnConfDirty <= 0)
			{
				RefreshTotals();
				UpdateInUI();
			}
		}
		scrollbar.size = Mathf.Clamp01(ContentRect.rect.height / ((float)(ActualItems.Count + 1 + (_anyTotals ? 1 : 0)) * 24f));
		scrollbar.numberOfSteps = Mathf.Max(0, ActualItems.Count + 2 + (_anyTotals ? 1 : 0) - Mathf.FloorToInt(ContentRect.rect.height / 24f));
		if (ListViewFocus.ActiveListView == this && ActualItems.Count > 1 && !DevConsole.Console.isOpen)
		{
			int num = -1;
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (Selected.Count > 0)
				{
					int num2 = Selected[Selected.Count - 1];
					num = Mathf.Max(0, num2 - 1);
				}
				InputController.LockKey(KeyCode.UpArrow);
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (Selected.Count > 0)
				{
					int num3 = Selected[Selected.Count - 1];
					num = Mathf.Min(ActualItems.Count - 1, num3 + 1);
				}
				InputController.LockKey(KeyCode.DownArrow);
			}
			else if (Input.GetKeyDown(KeyCode.Home))
			{
				num = 0;
				InputController.LockKey(KeyCode.Home);
			}
			else if (Input.GetKeyDown(KeyCode.End))
			{
				num = ActualItems.Count - 1;
				InputController.LockKey(KeyCode.End);
			}
			else if (MultiSelect && (Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightCommand) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.A))
			{
				if (Selected.Count < ActualItems.Count)
				{
					LastSelectDirect = true;
					Action onChange = Selected.OnChange;
					Selected.OnChange = null;
					Selected.Clear();
					Selected.AddRange(Enumerable.Range(0, ActualItems.Count));
					if (onChange != null)
					{
						onChange();
					}
					Selected.OnChange = onChange;
					SelectedBeforeChange = GetSelected<object>();
					UpdateSelected();
				}
				InputController.LockKey(KeyCode.A);
				HelpTipPanel.DismissHint(HintController.Hints.HintMultiSelectList);
			}
			if (num >= 0)
			{
				_canDoubleClick = false;
				LastSelectDirect = true;
				Select(num);
				KeepIdxInView(num);
				_canDoubleClick = true;
			}
		}
		if (lastSize != rectTransform.rect)
		{
			UpdateElements();
		}
		else if (dirty)
		{
			Action onChange2 = Selected.OnChange;
			int num4 = Selected.Count;
			Selected.OnChange = null;
			if (SelectedBeforeChange != null)
			{
				Selected.Clear();
				for (int i = 0; i < SelectedBeforeChange.Length; i++)
				{
					int indexOf = GetIndexOf(SelectedBeforeChange[i]);
					if (indexOf >= 0)
					{
						if (!Selected.Contains(indexOf))
						{
							Selected.Add(indexOf);
						}
					}
					else
					{
						num4 = -1;
					}
				}
				SelectedBeforeChange = null;
			}
			for (int j = 0; j < Selected.Count; j++)
			{
				if (Selected[j] >= ActualItems.Count)
				{
					Selected.RemoveAt(j);
					j--;
				}
			}
			Selected.OnChange = onChange2;
			if (onChange2 != null && num4 != Selected.Count)
			{
				onChange2();
			}
			UpdateElements();
			dirty = false;
		}
		else if (Time.realtimeSinceStartup >= NextRefresh && !DisableRefresh)
		{
			UpdateActiveList(false);
		}
		else if (ActualItems.Count > 0 && !DisableRefresh)
		{
			_updateIDX = (_updateIDX + 1) % ActualItems.Count;
			UpdateAtI(_updateIDX);
		}
		lastSize = rectTransform.rect;
	}

	private void UpdateAtI(int idx)
	{
		bool flag = false;
		idx %= ActualItems.Count;
		object obj = ActualItems[idx];
		bool flag2 = false;
		for (int i = 0; i < GUIColumns.Count; i++)
		{
			GUIColumn gUIColumn = GUIColumns[i];
			if ((gUIColumn.isActiveAndEnabled || gUIColumn.ForceFilter) && gUIColumn.FilterActive && gUIColumn.Filter != FilterType.None)
			{
				flag2 = true;
				break;
			}
		}
		bool flag3 = true;
		if (flag2)
		{
			for (int j = 0; j < GUIColumns.Count; j++)
			{
				GUIColumn column = GUIColumns[j];
				if (!FilterItem(obj, column))
				{
					flag3 = false;
					break;
				}
			}
			if (!flag3)
			{
				Selected.Remove(idx);
				ActualItems.Remove(obj);
				flag = true;
				OnFilterUpdate.Invoke();
			}
		}
		if (flag3 && LastSort != null && LastSort.isActiveAndEnabled && idx > 0)
		{
			object obj2 = ActualItems[idx - 1];
			int num = LastSort.Comparison(obj, obj2);
			if ((LastSort.SortAsc && num > 0) || (!LastSort.SortAsc && num < 0))
			{
				ActualItems[idx] = obj2;
				ActualItems[idx - 1] = obj;
				flag = true;
				bool flag4 = Selected.Contains(idx);
				bool flag5 = Selected.Contains(idx - 1);
				if (flag4 ^ flag5)
				{
					if (flag4)
					{
						Selected.Remove(idx);
						Selected.Add(idx - 1);
					}
					else
					{
						Selected.Remove(idx - 1);
						Selected.Add(idx);
					}
				}
			}
		}
		if (flag)
		{
			UpdateInUI();
		}
	}

	public void OnScroll(BaseEventData data)
	{
		int scroll = Scroll;
		PointerEventData pointerEventData = (PointerEventData)data;
		int num = ActualItems.Count + 1 + (_anyTotals ? 1 : 0) - Mathf.FloorToInt(ContentRect.rect.height / 24f);
		if (num > 0)
		{
			scrollbar.value -= pointerEventData.scrollDelta.y / (float)num;
		}
		if (Scroll != scroll)
		{
			UpdateElements();
		}
		float x = pointerEventData.scrollDelta.x;
		if (x == 0f)
		{
			return;
		}
		float width = ContentRect.rect.width;
		if (!(width > 0f))
		{
			return;
		}
		ScrollRect component = GetComponent<ScrollRect>();
		float num2 = width - rectTransform.rect.width;
		float num3 = component.horizontalScrollbar.value * num2;
		float num4 = 0f;
		int num5 = 0;
		for (int i = 0; i < GUIColumns.Count; i++)
		{
			GUIColumn gUIColumn = GUIColumns[i];
			if (!gUIColumn.gameObject.activeSelf)
			{
				continue;
			}
			num4 += gUIColumn.rectTransform.rect.width;
			if (num4 > num3 + x)
			{
				if (x < 0f)
				{
					num5++;
				}
				break;
			}
			num5++;
		}
		num5 = Mathf.Clamp(num5 + (int)x, 0, GUIColumns.Count - 1);
		num4 = 0f;
		int num6 = 0;
		for (int j = 0; j < GUIColumns.Count; j++)
		{
			GUIColumn gUIColumn2 = GUIColumns[j];
			if (gUIColumn2.gameObject.activeSelf)
			{
				if (num5 == num6)
				{
					component.horizontalScrollbar.value = num4 / num2;
					break;
				}
				num4 += gUIColumn2.rectTransform.rect.width;
				num6++;
			}
		}
	}

	public void KeepItemInView(object o)
	{
		int num = ActualItems.IndexOf(o);
		if (num >= 0)
		{
			KeepIdxInView(num);
		}
	}

	public void KeepIdxInView(int idx)
	{
		int num = ActualItems.Count + 1 + (_anyTotals ? 1 : 0) - Mathf.FloorToInt(ContentRect.rect.height / 24f);
		float num2 = Mathf.Clamp01((float)idx / (float)num);
		if (scrollbar.value > num2)
		{
			scrollbar.value = num2;
			return;
		}
		num2 = (float)idx / (float)num;
		float num3 = Mathf.Floor(ContentRect.rect.height / 24f - 2f) / (float)num;
		if (scrollbar.value + num3 < num2)
		{
			scrollbar.value = num2 - num3;
		}
	}

	public void ClearSelected()
	{
		Selected.Clear();
		SelectedBeforeChange = GetSelected<object>();
		UpdateSelected();
	}

	public void Select(int i)
	{
		if (MultiSelect && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
		{
			if (Selected.Contains(i))
			{
				Selected.Remove(i);
			}
			else
			{
				Selected.Add(i);
			}
		}
		else if (MultiSelect && Selected.Count > 0 && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			int num = Selected[0];
			Action onChange = Selected.OnChange;
			Selected.OnChange = null;
			Selected.Clear();
			if (i > num)
			{
				for (int j = 0; j < ActualItems.Count; j++)
				{
					if (j > num && j <= i)
					{
						Selected.Add(j);
					}
				}
			}
			else
			{
				for (int num2 = ActualItems.Count - 1; num2 >= 0; num2--)
				{
					if (num2 >= i && num2 < num)
					{
						Selected.Add(num2);
					}
				}
			}
			Selected.Insert(0, num);
			if (onChange != null)
			{
				onChange();
			}
			Selected.OnChange = onChange;
		}
		else
		{
			bool lastSelectDirect = LastSelectDirect;
			if (_canDoubleClick && lastSelectDirect && Time.realtimeSinceStartup - _lastSelection < 0.3f && Selected.Count == 1 && Selected[0] == i)
			{
				if (OnDoubleClick != null)
				{
					OnDoubleClick();
				}
				else if (_doubleClickColumn != null)
				{
					_doubleClickColumn.Action(ActualItems[Selected[0]]);
				}
				else
				{
					IListDoubleClickable firstSelected = GetFirstSelected<IListDoubleClickable>();
					if (firstSelected != null)
					{
						firstSelected.OnDoubleClick();
					}
				}
			}
			else
			{
				LastSelectDirect = false;
				Action onChange2 = Selected.OnChange;
				Selected.OnChange = null;
				Selected.Clear();
				Selected.OnChange = onChange2;
				LastSelectDirect = lastSelectDirect;
				Selected.Add(i);
				if (lastSelectDirect && _canDoubleClick)
				{
					_lastSelection = Time.realtimeSinceStartup;
				}
			}
		}
		SelectedBeforeChange = GetSelected<object>();
		UpdateSelected();
	}

	public void Select(object obj, bool keepInView = true)
	{
		int num = ActualItems.IndexOf(obj);
		if (num > -1)
		{
			Select(num);
			if (keepInView)
			{
				KeepIdxInView(num);
			}
		}
	}

	public void SelectAll()
	{
		Action onChange = Selected.OnChange;
		Selected.OnChange = null;
		Selected.Clear();
		int[] array = new int[ActualItems.Count];
		for (int i = 0; i < ActualItems.Count; i++)
		{
			array[i] = i;
		}
		Selected.OnChange = onChange;
		Selected.AddRange(array);
		SelectedBeforeChange = GetSelected<object>();
		UpdateSelected();
	}

	public void ClearFilters()
	{
		for (int i = 0; i < GUIColumns.Count; i++)
		{
			GUIColumn gUIColumn = GUIColumns[i];
			if (gUIColumn.FilterActive)
			{
				gUIColumn.ToggleFilter();
			}
		}
	}

	public void SelectAll<T>(Func<T, bool> select) where T : class
	{
		Action onChange = Selected.OnChange;
		Selected.OnChange = null;
		Selected.Clear();
		KeyValuePair<int, object>[] array = new KeyValuePair<int, object>[ActualItems.Count];
		for (int i = 0; i < ActualItems.Count; i++)
		{
			array[i] = new KeyValuePair<int, object>(i, ActualItems[i]);
		}
		Selected.OnChange = onChange;
		Selected.AddRange(array.WhereSelect(delegate(KeyValuePair<int, object> x)
		{
			T val = x.Value as T;
			return val != null && select(val);
		}, (KeyValuePair<int, object> x) => x.Key));
		SelectedBeforeChange = GetSelected<object>();
		UpdateSelected();
	}

	public T[] GetSelected<T>() where T : class
	{
		return Selected.WhereSelectNotNull((int x) => x < ActualItems.Count, (int x) => ActualItems[x] as T).ToArray();
	}

	public T GetFirstSelected<T>() where T : class
	{
		for (int i = 0; i < Selected.Count; i++)
		{
			int num = Selected[i];
			if (num < ActualItems.Count)
			{
				T val = ActualItems[num] as T;
				if (val != null)
				{
					return val;
				}
			}
		}
		return null;
	}

	public IEnumerable<T> GetSelectedEnum<T>()
	{
		for (int i = 0; i < Selected.Count; i++)
		{
			int num = Selected[i];
			if (num < ActualItems.Count)
			{
				yield return (T)ActualItems[num];
			}
		}
	}

	internal void ResetScroll()
	{
		scrollbar.value = 0f;
		UpdateElements();
	}

	public void ExportCSV()
	{
		List<GUIColumn> list = GUIColumns.Where((GUIColumn x) => x.Type != GUIColumn.ColumnType.Action && x.gameObject.activeSelf).ToList();
		StringBuilder stringBuilder = new StringBuilder();
		for (int num = 0; num < list.Count; num++)
		{
			GUIColumn gUIColumn = list[num];
			stringBuilder.Append(gUIColumn.HeaderValue + ";");
		}
		stringBuilder.AppendLine("");
		for (int num2 = 0; num2 < ActualItems.Count; num2++)
		{
			object arg = ActualItems[num2];
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				GUIColumn gUIColumn2 = list[num3];
				stringBuilder.Append(gUIColumn2.Label(arg).ToString() + ";");
			}
			stringBuilder.AppendLine("");
		}
		GUIUtility.systemCopyBuffer = stringBuilder.ToString();
	}

	public GUIWindow FindParentWindow()
	{
		Transform parent = base.transform.parent;
		while (parent != null)
		{
			GUIWindow component = parent.GetComponent<GUIWindow>();
			if (component != null)
			{
				return component;
			}
			parent = parent.parent;
		}
		return null;
	}

	public string GetPath()
	{
		string text = base.name;
		Transform parent = base.transform.parent;
		while (parent != null)
		{
			text = parent.name + "/" + text;
			parent = parent.parent;
		}
		return text;
	}

	public void SaveColumnOrder()
	{
		if (GameSettings.Instance.IsReferenceNull() || GUIColumns.Count <= 1)
		{
			return;
		}
		string path = GetPath();
		bool flag = false;
		int num = GUIColumns[0].transform.GetSiblingIndex();
		for (int i = 1; i < GUIColumns.Count; i++)
		{
			int siblingIndex = GUIColumns[i].transform.GetSiblingIndex();
			if (siblingIndex < num)
			{
				flag = true;
				break;
			}
			num = siblingIndex;
		}
		if (flag)
		{
			GameSettings.Instance.ColumnOrder[path] = (from x in GUIColumns
				orderby x.transform.GetSiblingIndex()
				select x.name).ToArray();
		}
		else
		{
			GameSettings.Instance.ColumnOrder.Remove(path);
		}
	}
}
