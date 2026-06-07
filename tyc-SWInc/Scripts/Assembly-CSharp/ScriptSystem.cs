using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevConsole;
using StatementParser;
using UnityEngine;

public static class ScriptSystem
{
	[Flags]
	public enum EntryPoint
	{
		None = 0,
		ValidForProduct = 0xB,
		EndOfDay = 1,
		AfterSales = 2,
		OnRelease = 4,
		NewCopies = 8,
		WorkItemChange = 0x10,
		ValidForMultiplayer = 0xD
	}

	public class AddOnAmount : LineParse.ScriptWorld
	{
		private static AddOnAmount _instance = new AddOnAmount();

		public uint x;

		public SDateTime Now
		{
			get
			{
				return SDateTime.Now();
			}
		}

		public int DaysPerMonth
		{
			get
			{
				return GameSettings.DaysPerMonth;
			}
		}

		public string Localize(string input, params object[] arguments)
		{
			if (arguments.Length != 0)
			{
				return input.Loc(arguments);
			}
			return input.Loc();
		}

		public string LocalizePlural(string input, int number)
		{
			return input.LocPlural(number);
		}

		public string Currency(float input)
		{
			return input.Currency();
		}

		public string Currency(double input)
		{
			return input.Currency();
		}

		public string Bandwidth(float megaBytes)
		{
			return megaBytes.Bandwidth();
		}

		public string Bytes(float megaBytes)
		{
			return megaBytes.ByteSize();
		}

		public string Bandwidth(double megaBytes)
		{
			return Bandwidth((float)megaBytes);
		}

		public string Bytes(double megaBytes)
		{
			return Bytes((float)megaBytes);
		}

		public string Switch(int val, bool clamp, bool localize, params string[] switches)
		{
			string text = (clamp ? switches[Mathf.Clamp(val - 1, 0, switches.Length - 1)] : switches[(val - 1) % switches.Length]);
			if (localize)
			{
				return text.Loc();
			}
			return text;
		}

		public static AddOnAmount GetTemp(uint input)
		{
			_instance.x = input;
			return _instance;
		}

		public override Type GetTypeFromName(string name)
		{
			return null;
		}

		public override bool IsProtected()
		{
			return true;
		}
	}

	public class TaskScope : LineParse.ScriptWorld
	{
		public const string RivalCompanyName = "Rocketz Rule";

		public static TaskScope Scope = new TaskScope();

		public SDateTime Now
		{
			get
			{
				return SDateTime.Now();
			}
		}

		public int DaysPerMonth
		{
			get
			{
				return GameSettings.DaysPerMonth;
			}
		}

		public Company PlayerCompany
		{
			get
			{
				return GameSettings.Instance.MyCompany;
			}
		}

		public MarketSimulation MarketSimulation
		{
			get
			{
				return MarketSimulation.Active;
			}
		}

		public GameSettings GameSettings
		{
			get
			{
				return GameSettings.Instance;
			}
		}

		public ActorManager ActorManager
		{
			get
			{
				return GameSettings.Instance.sActorManager;
			}
		}

		public ActorCustomization Customizer
		{
			get
			{
				return ActorCustomization.Instance;
			}
		}

		public BuildController BuildController
		{
			get
			{
				return BuildController.Instance;
			}
		}

		public RoomManager RoomManager
		{
			get
			{
				return GameSettings.Instance.sRoomManager;
			}
		}

		public RoadManager RoadManager
		{
			get
			{
				return RoadManager.Instance;
			}
		}

		public MissionGuide MissionGuide
		{
			get
			{
				return MissionGuide.Instance;
			}
		}

		public TutorialSystem TutorialSystem
		{
			get
			{
				return TutorialSystem.Instance;
			}
		}

		public WindowManager WindowManager
		{
			get
			{
				return WindowManager.Instance;
			}
		}

		public HUD HUD
		{
			get
			{
				return HUD.Instance;
			}
		}

		public override Type GetTypeFromName(string name)
		{
			Type value;
			if (!ValidTypes.TryGetValue(name, out value))
			{
				return ExtraValidTypes.GetOrDefault(name);
			}
			return value;
		}

		public override bool IsProtected()
		{
			return false;
		}

		public void InitialContract()
		{
			if (HUD.BuildMode)
			{
				HUD.BuildMode = false;
			}
			ContractWork contractWork = ContractWork.GenerateWork(MarketSimulation.Active.SoftwareTypes["Website"].Categories.Values.First(), 0f, 0f, false);
			contractWork.GetType().GetField("Company").SetValue(contractWork, "Mom's pilates");
			DesignDocument designDocument = contractWork.GenerateWorkItem(null);
			designDocument.NextPhaseTeam = GameSettings.Instance.sActorManager.Teams.Keys.ToSHashSet();
			GameSettings.Instance.MyCompany.AddWorkItem(designDocument);
			NotificationManager.AddNotification("ContractIncomeMsg".Loc(contractWork.Initial.CurrencyInt()), "Paper", NotificationManager.NotificationType.Good);
			GameSettings.Instance.MyCompany.MakeTransaction(contractWork.Initial, Company.TransactionCategory.Contracts, true);
		}

		public void HireEmployees()
		{
			Team team = GameSettings.Instance.sActorManager.Teams.Values.FirstOrDefault();
			if (team == null)
			{
				team = new Team("Core");
				GameSettings.Instance.sActorManager.Teams.Add(team.Name, team);
			}
			Employee[] array = HUD.Instance.hireWindow.HireWin.GenerateEmployees(5, Employee.WageBracket.Medium, Employee.EmployeeRole.Programmer, false, Employee.EmployeeRole.Designer, new string[2] { "System", "2D" }, team, Employee.Trait.None, Employee.Trait.None, null, team);
			foreach (Employee employee in array)
			{
				employee.CreativityKnown = 1f;
				employee.Employ(GameSettings.Instance.MyCompany, SDateTime.Now(), false);
				GameSettings.Instance.RegisterStat("Hired", 1f);
				GameSettings.Instance.SpawnActor(employee).Team = team.Name;
			}
			MissionGuide.CampaignCharacter character = MissionGuide.Instance.GetCharacter("Bob");
			Employee employee2 = new Employee(SDateTime.Now(), character.Person.Female, character.Name, character.Person.Skills, 0f, character.Person.Personality, character.Person.Traits.Aggregate(Employee.Trait.None, (Employee.Trait x, Employee.Trait y) => x | y), character.Person.Specs, GameSettings.Instance.Personalities, character.Person.BodyItems, null);
			Actor actor = GameSettings.Instance.sActorManager.Actors.FirstOrDefault((Actor x) => x.employee.Founder);
			if (actor != null)
			{
				employee2.BirthDate = actor.employee.BirthDate + 6;
			}
			employee2.SkillCeiling = 0f;
			employee2.Employ(GameSettings.Instance.MyCompany, SDateTime.Now(), false);
			GameSettings.Instance.RegisterStat("Hired", 1f);
			GameSettings.Instance.SpawnActor(employee2).Team = team.Name;
		}

		public void LaunchSuitAndRemoveBob()
		{
			MissionGuide.CampaignCharacter ch = MissionGuide.Instance.GetCharacter("Bob");
			Actor actor = GameSettings.sActorManager.Actors.FirstOrDefault((Actor x) => x.employee.Founder && x.employee.Name.Equals(ch.Name));
			if (actor != null)
			{
				Employee employee = actor.employee;
				actor.Dismiss(false);
				CompanyType companyType = MarketSimulation.Active.CompanyTypes["Games"];
				SimulatedCompany simulatedCompany = new SimulatedCompany("Rocketz Rule", SDateTime.Now(), companyType, companyType.GetTypes(), 0.5f, MarketSimulation.Active);
				simulatedCompany.Logo = SDFCreator.GetTreeFromString("Y2NgZGTn3rxkTo5on6KZMUPD///MTE3/wxj+39djaGBhZpyUEj+dgYWB+f/sle2Rwv+BgIGVgXlSi8ocCI+JjeWZKgM7E3tDCUPpeWcGhTDDpXOYOICCzJxNjhvBGhpYuBgYuNn4q/zE/S/yMyjot92/teg5M0/Tf13d/0+fAuV5GTiZmBiZmZmYmNlYWJk52NiZODmYuZg5mXi4mXm5eAA=");
				simulatedCompany.LeadDesigner = employee;
				employee.Employ(simulatedCompany, SDateTime.Now(), false);
				simulatedCompany.CampaignProtected = true;
				MarketSimulation.Active.AddCompany(simulatedCompany);
			}
			GameSettings.Instance.AddHeat(1f, true);
		}

		public void StartTakeOver()
		{
			SimulatedCompany simulatedCompany = MarketSimulation.Active.Companies.Values.FirstOrDefault((SimulatedCompany x) => "Rocketz Rule".Equals(x.Name));
			if (simulatedCompany != null)
			{
				KeyValuePair<uint, double> sharesAndPrice = PlayerCompany.GetSharesAndPrice(PlayerCompany.Money);
				PlayerCompany.Shares = sharesAndPrice.Key;
				uint shares = (uint)((float)sharesAndPrice.Key * 0.5f + 1f);
				NewStock item = new NewStock(PlayerCompany, simulatedCompany, shares, PlayerCompany.Money * 0.5);
				simulatedCompany.MakeTransaction(PlayerCompany.Money * 0.75, Company.TransactionCategory.NA, false, null, true);
				PlayerCompany.NewStock.Add(item);
				simulatedCompany.NewOwnedStock.Add(item);
				PlayerCompany.UpdateShare();
				PlayerCompany.BeginTakeover(simulatedCompany);
			}
		}

		public void EnableTaxes()
		{
			Options.Difficulty = new DifficultyValues.DifficultySetting("BeginnerWithTaxes", Options.Difficulty)
			{
				Taxes = 0.1f
			};
			if (GameSettings.BackgroundAccounting.DevTeams.Count != 0)
			{
				return;
			}
			Team team = GameSettings.Instance.sActorManager.Teams.Values.FirstOrDefault((Team x) => x.GetEmployeesDirect().Any((Actor z) => z.employee.GetSpecialization(Employee.EmployeeRole.Service, "Accounting") > 0));
			if (team == null)
			{
				team = GameSettings.Instance.sActorManager.Teams.Values.FirstOrDefault();
			}
			if (team != null)
			{
				GameSettings.BackgroundAccounting.AddDevTeam(team);
			}
		}

		public void UnprotectCompanies()
		{
			MarketSimulation.Active.Companies.Values.ForEachEnum(delegate(SimulatedCompany x)
			{
				x.CampaignProtected = false;
			});
		}

		public void KillPublishers()
		{
			SoftwareProduct softwareProduct = PlayerCompany.Products.FirstOrDefault((SoftwareProduct x) => x.SequelTo != null && x.Publishing != null);
			if (softwareProduct != null)
			{
				softwareProduct.Publishing.Publisher.MakeTransaction(0.0 - softwareProduct.Publishing.Publisher.Money - 100.0, Company.TransactionCategory.NA);
			}
		}

		public void ForceNetworking()
		{
			SimulatedCompany.ProductPrototype productPrototype = (from z in MarketSimulation.Active.Companies.Values.SelectMany((SimulatedCompany x) => x.Releases)
				where z.Type.Name.Equals("Operating System") && z.Category.Name.Equals("Computer")
				select z).MinInstance((SimulatedCompany.ProductPrototype x) => x.ReleaseDate.ToFloat());
			if (productPrototype != null)
			{
				if (productPrototype.Features.None((FeatureBase x) => x.Name.Equals("Network")))
				{
					productPrototype.Techs["Network"] = MarketSimulation.Active.TechLevels["Network"].Last();
					FeatureBase[] array = productPrototype.Features.Resize(productPrototype.Features.Length + 1);
					array[array.Length - 1] = productPrototype.Type.Features["Network"];
					productPrototype.Features = array;
				}
				SDateTime sDateTime = Now + 6;
				if (sDateTime < productPrototype.ReleaseDate)
				{
					productPrototype.ReleaseDate = sDateTime;
				}
			}
		}

		public void LoadBuildingPrefab(string path)
		{
			BuildController.Instance.CreateForcedPrefab().Init(BuildingPrefab.FromXMLNode(XMLParser.ParseXML(GameData.LoadFullTextAsset(path))));
		}

		public void CreateGameTask()
		{
			SoftwareType softwareType = MarketSimulation.SoftwareTypes["Game"];
			SoftwareCategory softwareCategory = softwareType.Categories["Simulation"];
			List<FeatureBase> features = new List<FeatureBase>
			{
				softwareType.Features["Game design"],
				softwareType.Features["Dialog trees"],
				softwareType.Features["Mod support"],
				softwareType.Features["Customizable character"],
				softwareType.Features["2D Graphics"],
				softwareType.Features["Advanced HUD"],
				softwareType.Features["Post-processing"],
				softwareType.Features["Audio"]
			};
			Dictionary<string, TechLevel> dictionary = new Dictionary<string, TechLevel>();
			dictionary["System"] = MarketSimulation.GetLatestTech("System", Now, softwareCategory, PlayerCompany);
			Dictionary<string, SoftwareProduct> dictionary2 = new Dictionary<string, SoftwareProduct>();
			Dictionary<string, TechLevel> dictionary3 = dictionary;
			ValueTuple<SoftwareProduct, TechLevel> needTech = GetNeedTech("2D", "2D Editor", MarketSimulation.GetLatestTech("2D", Now, softwareCategory, PlayerCompany));
			SoftwareProduct softwareProduct = (dictionary2["2D"] = needTech.Item1);
			TechLevel techLevel = (dictionary3["2D"] = needTech.Item2);
			dictionary3 = dictionary;
			needTech = GetNeedTech("Audio", "Audio Tool", MarketSimulation.GetLatestTech("Audio", Now, softwareCategory, PlayerCompany));
			softwareProduct = (dictionary2["Audio"] = needTech.Item1);
			techLevel = (dictionary3["Audio"] = needTech.Item2);
			List<SoftwareProduct> oSs = AutoDevWorkItem.GetOSs(dictionary2, softwareType, false);
			DesignDocument designDocument = new DesignDocument("Stinky Hams", softwareType, softwareCategory, dictionary2, oSs.ToArray(), SimulatedCompany.PickPrice(softwareType, softwareCategory, false, features, dictionary, 1f), false, SimulatedCompany.PickMarketFocus(softwareCategory, 1f, SDateTime.Now()), Now, PlayerCompany, null, false, 0.0, features, dictionary, null, null, null, null, null, dictionary2.Values.ToList(), false);
			SHashSet<string> deals = new SHashSet<string> { "Printing", "Marketing" };
			float royalty = PublisherDeal.GetRoyalty(deals, softwareCategory, PlayerCompany);
			SimulatedCompany simulatedCompany = GameSettings.Instance.simulation.FindPublisher(PlayerCompany, softwareCategory, 0f, false);
			simulatedCompany.CampaignProtected = true;
			int num = 24;
			(designDocument.Publishing = new PublisherDeal(simulatedCompany, royalty, 0f, 0f, 0f, num, deals)).Affect(designDocument);
			GameSettings.Instance.MyCompany.AddWorkItem(designDocument);
			designDocument.AddDevTeams(ActorManager.Teams.Keys);
			Employee leadDesigner = null;
			float num2 = -0.5f;
			foreach (Team value in ActorManager.Teams.Values)
			{
				float score;
				Actor bestLeadDesigner = value.GetBestLeadDesigner(out score, softwareType, designDocument, designDocument);
				if (score > num2)
				{
					num2 = score;
					leadDesigner = bestLeadDesigner.employee;
				}
			}
			designDocument.SetLeadDesigner(leadDesigner);
			designDocument.NextPhaseTeam = ActorManager.Teams.Keys.ToSHashSet();
			designDocument.CheckCompetency();
		}

		private ValueTuple<SoftwareProduct, TechLevel> GetNeedTech(string spec, string swType, TechLevel maxTech)
		{
			SDateTime time = SDateTime.Now();
			SoftwareProduct softwareProduct = null;
			double num = -1.0;
			foreach (SoftwareProduct allProduct in MarketSimulation.Active.GetAllProducts(false))
			{
				if (!allProduct.Type.Name.Equals(swType))
				{
					continue;
				}
				TechLevel orDefault = allProduct.TechLevels.GetOrDefault(spec);
				if (((orDefault != null) ? new int?(orDefault.Year) : ((int?)null)) <= maxTech.Year)
				{
					double num2 = (double)allProduct.TechLevels[spec].Year + allProduct.RelativeFeatureScore(MarketSimulation.Active, time);
					if (num2 > num)
					{
						num = num2;
						softwareProduct = allProduct;
					}
				}
			}
			if (softwareProduct == null)
			{
				throw new Exception("Failed finding a " + swType + " for campaign mission first product!");
			}
			return new ValueTuple<SoftwareProduct, TechLevel>(softwareProduct, softwareProduct.TechLevels[spec]);
		}

		public void MakeAssemblyLine()
		{
			PlotArea plotArea = GameSettings.Instance.Plots.Where((PlotArea plotArea2) => !plotArea2.PlayerOwned && plotArea2.AddonCost == 0f && plotArea2.MaxX - plotArea2.MinX >= 10f && plotArea2.MaxY - plotArea2.MinY >= 12f).MinInstance((PlotArea plotArea2) => plotArea2.Area);
			if (plotArea != null)
			{
				GameSettings.Instance.BuyPlot(plotArea, true);
				BuildingPrefab buildingPrefab = BuildingPrefab.FromXMLNode(XMLParser.ParseXML(GameData.LoadFullTextAsset("Campaign/CampaignAssembly")));
				float x = buildingPrefab.Edges.Average((SVector3 sVector) => sVector.x);
				float y = buildingPrefab.Edges.Average((SVector3 sVector) => sVector.y);
				RoomCloneTool.Instance.transform.rotation = Quaternion.identity;
				RoomCloneTool.Instance.transform.position = new Vector3(plotArea.MinX + 5.5f, 0f, plotArea.MinY + 4.5f);
				RoomCloneTool.Instance.Center = new Vector2(x, y);
				RoomCloneTool.Instance.MirrorX = false;
				RoomCloneTool.Instance.MirrorY = false;
				RoomCloneTool.Instance.SetOptions(null, true, RoomCloneTool.GroupOption.Copy, null, true);
				List<KeyValuePair<Room, BuildingPrefab.RoomObject>> list = RoomCloneTool.Instance.BuildPrefab(buildingPrefab, 0, false, false, true, false);
				if (list.Count > 0)
				{
					KeyValuePair<Room, BuildingPrefab.RoomObject> keyValuePair = list.FirstOrDefault();
					CameraScript.Instance.MoveTo(keyValuePair.Key.Center, keyValuePair.Key.Floor);
				}
			}
			ContractWork contractWork = ContractWork.GenerateWork(MarketSimulation.SoftwareTypes["Embedded System"].Categories.Values.First(), 0f, 0f, true);
			PrintJob job = new PrintJob(contractWork);
			GameSettings.Instance.AddPrintOrder(job, true);
			contractWork.GetType().GetField("Months").SetValue(contractWork, 12);
			contractWork.SetDeadline();
		}
	}

	[AllowScopeList]
	public abstract class DefaultScope : LineParse.ScriptWorld
	{
		public SDateTime Now
		{
			get
			{
				return SDateTime.Now();
			}
		}

		public int DaysPerMonth
		{
			get
			{
				return GameSettings.DaysPerMonth;
			}
		}

		public Company PlayerCompany
		{
			get
			{
				return GameSettings.Instance.MyCompany;
			}
		}

		public MarketSimulation MarketSimulation
		{
			get
			{
				return MarketSimulation.Active;
			}
		}

		public void Console(object o)
		{
			DevConsole.Console.Log(o.ToString());
		}

		public override bool IsProtected()
		{
			return true;
		}

		public override Type GetTypeFromName(string name)
		{
			return ValidTypes.GetOrDefault(name);
		}

		public string Localize(string input, params object[] arguments)
		{
			if (arguments.Length != 0)
			{
				return input.Loc(arguments);
			}
			return input.Loc();
		}

		public string LocalizePlural(string input, int number)
		{
			return input.LocPlural(number);
		}

		public void LaunchLawsuit(string subject, float amount, float difficulty)
		{
			GameSettings.Instance.LaunchSuit(new GameSettings.Lawsuit(subject, amount, difficulty));
		}

		public void LaunchLawsuit(string subject, double amount, float difficulty)
		{
			GameSettings.Instance.LaunchSuit(new GameSettings.Lawsuit(subject, amount, difficulty));
		}

		public SDateTime CreateDate(int year, int month, int day, int hour, int minute)
		{
			return new SDateTime(minute, hour, day, month, year);
		}

		public static NotificationManager.NotificationType NotificationTypeToType(PopupManager.NotificationSound sfx)
		{
			switch (sfx)
			{
			case PopupManager.NotificationSound.Issue:
				return NotificationManager.NotificationType.Issue;
			case PopupManager.NotificationSound.Warning:
				return NotificationManager.NotificationType.Warning;
			case PopupManager.NotificationSound.Good:
				return NotificationManager.NotificationType.Good;
			default:
				return NotificationManager.NotificationType.Neutral;
			}
		}

		public void AddPopup(string text, float importance = 0.5f, string icon = "Info", PopupManager.NotificationSound sfx = PopupManager.NotificationSound.Neutral)
		{
			NotificationManager.AddNotification(new NotificationMessage(text, icon, SDateTime.Now(), NotificationTypeToType(sfx)));
		}
	}

	public class DevScope : DefaultScope
	{
		private static DevScope _instance = new DevScope();

		public WorkItem WorkItem;

		public bool Ended;

		public bool Cancelled;

		public static DevScope GetTempScope(WorkItem w, bool ended, bool cancelled, bool temp = false)
		{
			if (temp)
			{
				return new DevScope
				{
					WorkItem = w,
					Ended = ended,
					Cancelled = cancelled
				};
			}
			_instance.WorkItem = w;
			_instance.Ended = ended;
			_instance.Cancelled = cancelled;
			return _instance;
		}
	}

	public class SaleScope : DefaultScope
	{
		public SDateTime Time;

		public SoftwareProduct Product;

		public int PhysicalSales;

		public int DigitalSales;

		public int Refunds;

		public int MissedPhysicalSales;

		public void SetValues(int physicalSales, int digitalSales, int refunds, int missedPhysicalSales)
		{
			PhysicalSales = physicalSales;
			DigitalSales = digitalSales;
			Refunds = refunds;
			MissedPhysicalSales = missedPhysicalSales;
		}
	}

	public class ProductScope : DefaultScope, IByteData
	{
		private static ProductScope _instance = new ProductScope();

		public SoftwareProduct Product;

		public SDateTime Time;

		public static ProductScope GetTempScope(SoftwareProduct p, SDateTime time, bool temp = false)
		{
			if (temp)
			{
				return new ProductScope
				{
					Product = p,
					Time = time
				};
			}
			_instance.Product = p;
			_instance.Time = time;
			return _instance;
		}

		public void WriteData(Stream st)
		{
			st.WriteUInt(Product.ID);
			Time.WriteData(st);
		}

		public static ProductScope ReadData(Stream st)
		{
			return GetTempScope(MarketSimulation.Active.GetProduct(st.ReadUInt(), false), SDateTime.ReadData(st));
		}
	}

	public class CopyScope : DefaultScope, IByteData
	{
		private static CopyScope _instance = new CopyScope();

		public SoftwareProduct Product;

		public uint NewCopies;

		public static CopyScope GetTempScope(SoftwareProduct p, uint copiesAdded, bool temp = false)
		{
			if (temp)
			{
				return new CopyScope
				{
					Product = p,
					NewCopies = copiesAdded
				};
			}
			_instance.Product = p;
			_instance.NewCopies = copiesAdded;
			return _instance;
		}

		public void WriteData(Stream st)
		{
			st.WriteUInt(Product.ID);
			st.WriteUInt(NewCopies);
		}

		public static CopyScope ReadData(Stream st)
		{
			return GetTempScope(MarketSimulation.Active.GetProduct(st.ReadUInt(), false), st.ReadUInt());
		}
	}

	private static Type[] _validTypes;

	public static Dictionary<string, Type> ValidTypes;

	private static Type[] _extraValidTypes;

	public static Dictionary<string, Type> ExtraValidTypes;

	static ScriptSystem()
	{
		_validTypes = new Type[14]
		{
			typeof(SDateTime),
			typeof(WorkItem),
			typeof(SoftwareWorkItem),
			typeof(DesignDocument),
			typeof(SoftwareAlpha),
			typeof(AutoDevWorkItem),
			typeof(LegalWork),
			typeof(MarketingPlan),
			typeof(ResearchWork),
			typeof(ReviewWork),
			typeof(SoftwarePort),
			typeof(SupportWork),
			typeof(SoftwareUpdate),
			typeof(AccountingWork)
		};
		ValidTypes = new Dictionary<string, Type>();
		_extraValidTypes = new Type[7]
		{
			typeof(ContractWork),
			typeof(Vector2),
			typeof(Vector3),
			typeof(Vector4),
			typeof(Color),
			typeof(Color32),
			typeof(Rect)
		};
		ExtraValidTypes = new Dictionary<string, Type>();
		for (int i = 0; i < _validTypes.Length; i++)
		{
			Type type = _validTypes[i];
			ValidTypes[type.Name] = type;
		}
		for (int j = 0; j < _extraValidTypes.Length; j++)
		{
			Type type2 = _extraValidTypes[j];
			ExtraValidTypes[type2.Name] = type2;
		}
	}
}
