using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Achievements;
using SINetworking;
using UnityEngine;

[AltDeprecate("Autodidactic", typeof(float))]
[AltDeprecate("Leadership", typeof(float))]
[AltDeprecate("Diligence", typeof(float))]
[AltDeprecate("Fired", typeof(bool))]
public class Employee : IFormatColorObject, INetworkID
{
	[Serializable]
	public struct FriendKey
	{
		public readonly Employee E1;

		public readonly Employee E2;

		public FriendKey(Employee e1, Employee e2)
		{
			E1 = e1;
			E2 = e2;
		}

		public bool Equals(FriendKey other)
		{
			if (E1 != other.E1 || E2 != other.E2)
			{
				if (E1 == other.E2)
				{
					return E2 == other.E1;
				}
				return false;
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			object obj2;
			if ((obj2 = obj) is FriendKey)
			{
				FriendKey other = (FriendKey)obj2;
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return E1.Name.GetHashCode() * E2.Name.GetHashCode();
		}
	}

	[Serializable]
	public class ThoughtEffect
	{
		public string Thought;

		[NonSerialized]
		private MoodEffect _mood;

		public float Effect;

		public int Frames;

		public MoodEffect Mood
		{
			get
			{
				if (_mood == null)
				{
					_mood = GameData.MoodEffects[Thought];
				}
				return _mood;
			}
		}

		public ThoughtEffect()
		{
		}

		public ThoughtEffect(MoodEffect mood, float value)
		{
			Thought = mood.Thought;
			_mood = mood;
			Effect = value;
			Frames = 5;
		}

		public void ResetMood()
		{
			_mood = null;
		}
	}

	public enum EmployeeRole
	{
		Lead = 0,
		Programmer = 1,
		Designer = 2,
		Artist = 3,
		Service = 4
	}

	[Flags]
	public enum RoleBit
	{
		None = 0,
		Lead = 1,
		Programmer = 2,
		Designer = 4,
		Artist = 8,
		Service = 0x10,
		AnyRole = 0x1E,
		AllRoles = 0x1F
	}

	[Flags]
	public enum Trait : ulong
	{
		None = 0uL,
		FastLearner = 1uL,
		Independant = 2uL,
		BigBrain = 4uL,
		Humble = 8uL,
		Capacitor = 0x10uL,
		WalkItOff = 0x20uL,
		ThisIsFine = 0x40uL,
		NightOwl = 0x80uL,
		BornLeader = 0x100uL,
		FirmwareInc = 0x200uL,
		SuperFocus = 0x400uL,
		Unphased = 0x800uL,
		JustTheFlu = 0x1000uL,
		Detached = 0x2000uL,
		Stressed = 0x4000uL,
		Hypochondriac = 0x8000uL,
		SlowEater = 0x10000uL,
		NervousBladder = 0x20000uL,
		BumLeg = 0x40000uL,
		Forgetful = 0x80000uL,
		Cupholder = 0x100000uL,
		NeatFreak = 0x200000uL,
		SilentButDeadly = 0x400000uL,
		Watch = 0x800000uL,
		WalkInstead = 0x1000000uL,
		UnderTheWeather = 0x2000000uL,
		OldSole = 0x4000000uL,
		Sunshine = 0x8000000uL,
		Skyscraper = 0x10000000uL,
		RGBThumb = 0x20000000uL,
		FriendMaker = 0x40000000uL,
		Clean = 0x80000000uL,
		Claustrophobic = 0x100000000uL
	}

	public enum WageBracket
	{
		Low = 0,
		Medium = 1,
		High = 2
	}

	public enum Status
	{
		Enable = 0,
		Freeze = 1,
		Disable = 2
	}

	public static int RetirementAge = 65;

	public static int Youngest = 20;

	public const int RoleCount = 5;

	public static byte[] RoleToBit = new byte[5] { 1, 2, 4, 8, 16 };

	public static int MaxLeadSpec = 9;

	public static int MaxServiceSpec = 4;

	public static string[] LeadSpecs = new string[4] { "HR", "Automation", "Socialization", "Multitasking" };

	public static string[] ServiceSpecs = new string[4] { "Support", "Marketing", "Law", "Accounting" };

	public static RoleBit[] RoleToMask = new RoleBit[5]
	{
		RoleBit.Lead,
		RoleBit.Programmer,
		RoleBit.Designer,
		RoleBit.Artist,
		RoleBit.Service
	};

	public const Trait DeprecatedTraits = Trait.OldSole;

	public const Trait GoodTraits = Trait.FastLearner | Trait.Independant | Trait.BigBrain | Trait.Humble | Trait.Capacitor | Trait.WalkItOff | Trait.ThisIsFine | Trait.Sunshine | Trait.Skyscraper | Trait.RGBThumb | Trait.Clean;

	public const Trait NeutralTraits = Trait.NightOwl | Trait.BornLeader | Trait.FirmwareInc | Trait.SuperFocus | Trait.Unphased | Trait.JustTheFlu | Trait.Detached | Trait.Watch | Trait.FriendMaker;

	public const Trait BadTraits = Trait.Stressed | Trait.Hypochondriac | Trait.SlowEater | Trait.NervousBladder | Trait.BumLeg | Trait.Forgetful | Trait.Cupholder | Trait.NeatFreak | Trait.SilentButDeadly | Trait.WalkInstead | Trait.UnderTheWeather | Trait.Claustrophobic;

	public const Trait FounderTraits = Trait.FastLearner | Trait.BigBrain | Trait.Capacitor | Trait.ThisIsFine | Trait.BornLeader | Trait.FirmwareInc | Trait.SuperFocus | Trait.Detached | Trait.Stressed | Trait.BumLeg | Trait.Forgetful | Trait.Cupholder | Trait.NeatFreak | Trait.SilentButDeadly | Trait.Watch | Trait.WalkInstead | Trait.UnderTheWeather | Trait.Sunshine | Trait.Skyscraper | Trait.RGBThumb | Trait.FriendMaker | Trait.Clean | Trait.Claustrophobic;

	private static int[] RoleOrder = new int[5] { 32, 4, 8, 2, 1 };

	private static float[] RoleSalaryFactor = new float[5] { 2.25f, 1.25f, 1.5f, 0.75f, 1f };

	private static Dictionary<string, float> ServiceSalaryFactor = new Dictionary<string, float>
	{
		{ "Marketing", 1f },
		{ "Support", 0.5f },
		{ "Law", 1.75f },
		{ "Accounting", 1.5f }
	};

	private static KeyValuePair<string, float>[] ServiceSalaryFactorArr = new KeyValuePair<string, float>[4]
	{
		new KeyValuePair<string, float>("Support", 0.5f),
		new KeyValuePair<string, float>("Marketing", 1f),
		new KeyValuePair<string, float>("Law", 1.75f),
		new KeyValuePair<string, float>("Accounting", 1.5f)
	};

	[NonSerialized]
	private string _maxServiceSpec;

	public static float[] LowSkillCap = new float[5] { 0.2f, 0f, 0f, 0f, 0.2f };

	private Dictionary<string, int>[] SpecializationLevels = new Dictionary<string, int>[5]
	{
		new Dictionary<string, int>(),
		new Dictionary<string, int>(),
		new Dictionary<string, int>(),
		new Dictionary<string, int>(),
		new Dictionary<string, int>()
	};

	private float[] SpecializationExp = new float[5];

	private int[] SpecUsed = new int[5];

	public static float AverageWage = 750f;

	public readonly string Name;

	public readonly bool Female = true;

	public readonly float Creativity = 0.5f;

	public readonly float InspirationTime;

	public float CreativityKnown;

	public float Inspiration = 2f;

	public float LastDemandScore;

	public SDateTime LastInpirationUse = new SDateTime(0);

	public SDateTime LastBid = new SDateTime(0);

	public string NickName;

	public bool ActiveComplaint;

	public bool Filter;

	public bool PreviousEmployment;

	public Dictionary<string, float> CustomBenefits = new Dictionary<string, float>();

	public ActorBodyItem.BodyItemObject[] StyleGen;

	[Obsolete]
	public Dictionary<SoftwareType, float> LeadSpecialization;

	public Dictionary<string, float> LeadSpecializationFix = new Dictionary<string, float>();

	[NonSerialized]
	public string LeadSpecPick;

	[Obsolete]
	public List<SoftwareProduct> LeadProjects = new List<SoftwareProduct>();

	public List<uint> LeadProjectsFix = new List<uint>();

	public uint DemandsMet;

	public uint DemandsRequested;

	public readonly float InitialLeadExperience;

	public LeadDesignDemands.Demand DemandResults;

	[Obsolete]
	public Company Employer;

	public NetworkedID<uint> EmployerID = 0u;

	public float[] LastCreatity;

	public int AgeMonth = -1;

	public float SkillCeiling = 1f;

	public float LowestSatisfaction = -1f;

	[NonSerialized]
	public uint _leadUpdateCount;

	private RoleBit _currentRole = RoleBit.AnyRole;

	private RoleBit _secondaryRole;

	public static string[] ShortFormRole = new string[5] { "Lead", "Code", "Design", "Art", "Service" };

	public static int[] RoleOrderIndex = new int[5] { 0, 2, 1, 3, 4 };

	public EmployeeRole HiredFor;

	public static float HungerDrain = 0.0009259259f;

	public static float BladderDrain = 0.0010416667f;

	public static float EnergyDrain = 0.0013888889f;

	public static float StressDrain = 0.0013888889f;

	public static float SocialDrain = 0.00011574074f;

	public float Hunger = 1f;

	public float Energy = 1f;

	public float Bladder = 1f;

	public float Social = 1f;

	public float Stress = 1f;

	public float Posture = 1f;

	public float CoffeeQual;

	public bool SatisfactionHitZero;

	public bool InteractedWithBestFriend;

	private static Dictionary<FriendKey, float> _friendships = new Dictionary<FriendKey, float>();

	[Obsolete]
	public Dictionary<Employee, float> Friendships = new Dictionary<Employee, float>();

	public Trait Traits;

	[NonSerialized]
	private HashSet<Employee> _localFriendCache;

	private static List<ValueTuple<Employee, float>> _friendCache2 = new List<ValueTuple<Employee, float>>();

	public DictionaryList<string, ThoughtEffect> Thoughts = new DictionaryList<string, ThoughtEffect>();

	public bool HadProperFood;

	public float JobSatisfaction = 1f;

	private float[] Skill = new float[5];

	public string[] PersonalityTraits;

	public float Salary;

	public float AskedFor;

	public float Demanded;

	public float UpfrontDemand;

	public SDateTime Hired;

	public SDateTime LastWage;

	public SDateTime? PlayerQuarantine;

	public bool Founder;

	public bool MadeCEO;

	public bool Dismissed;

	public bool Retired;

	public SDateTime BirthDate;

	[NonSerialized]
	public Actor MyActor;

	private static readonly int[] _pointDist = new int[5] { 3, 3, 2, 2, 1 };

	private static int PersonalityNum = 2;

	public float SkillFact = 1f;

	public static float SkillBase = 0.65f;

	public static float SkillFactor = 0.6f;

	public static float SeniorityWeight = 0.1f;

	public static int[][] AgeBrackets = new int[3][]
	{
		new int[2] { 20, 30 },
		new int[2] { 30, 50 },
		new int[2] { 45, 62 }
	};

	private static FloatInterpolator _coffeeDrain = new FloatInterpolator(1f, 0.84f, 0.76f, 0.7f);

	public Company MyEmployer
	{
		get
		{
			if (Employer != null)
			{
				EmployerID = Employer.ID;
				Employer = null;
			}
			if ((uint)EmployerID != 0)
			{
				return MarketSimulation.Active.GetCompany(EmployerID);
			}
			return null;
		}
		set
		{
			EmployerID = ((value != null) ? value.ID : 0u);
		}
	}

	public string FullName
	{
		get
		{
			return NickName ?? Name;
		}
	}

	public string ExtraName
	{
		get
		{
			if (NickName == null)
			{
				return Name;
			}
			return Name + " (" + NickName + ")";
		}
	}

	public RoleBit CurrentRoleBit
	{
		get
		{
			return _currentRole;
		}
	}

	public RoleBit SecondaryRole
	{
		get
		{
			return _secondaryRole;
		}
	}

	public string RoleString
	{
		get
		{
			return GetRoleString(_currentRole);
		}
	}

	private HashSet<Employee> LocalFriendCache
	{
		get
		{
			if (_localFriendCache == null)
			{
				_localFriendCache = new HashSet<Employee>();
				foreach (KeyValuePair<FriendKey, float> friendship in _friendships)
				{
					if (friendship.Key.E1 == this)
					{
						_localFriendCache.Add(friendship.Key.E2);
					}
					else if (friendship.Key.E2 == this)
					{
						_localFriendCache.Add(friendship.Key.E1);
					}
				}
			}
			return _localFriendCache;
		}
	}

	public uint NetworkID { get; set; }

	public GameObject GO
	{
		get
		{
			return null;
		}
	}

	public static string[] GetTips(EmployeeRole role, string spec)
	{
		if (role == EmployeeRole.Designer || role == EmployeeRole.Programmer || role == EmployeeRole.Artist)
		{
			return new string[3]
			{
				"",
				"",
				"SpecThreeBoost".Loc(spec.LocTry(), string.Concat(role, "Work").Loc())
			};
		}
		return (role.ToString().ToUpper() + "SPECDESC" + spec).LocAll();
	}

	public static int TraitOrder(Trait t)
	{
		if ((Trait.FastLearner | Trait.Independant | Trait.BigBrain | Trait.Humble | Trait.Capacitor | Trait.WalkItOff | Trait.ThisIsFine | Trait.Sunshine | Trait.Skyscraper | Trait.RGBThumb | Trait.Clean).HasBits(t))
		{
			return 0;
		}
		if ((Trait.NightOwl | Trait.BornLeader | Trait.FirmwareInc | Trait.SuperFocus | Trait.Unphased | Trait.JustTheFlu | Trait.Detached | Trait.Watch | Trait.FriendMaker).HasBits(t))
		{
			return 1;
		}
		return 2;
	}

	public static IEnumerable<Trait> EnumTraits(Trait t)
	{
		ulong e = (ulong)t;
		for (int i = 0; i < 64; i++)
		{
			if ((e & 1) != 0L)
			{
				yield return (Trait)(1L << i);
			}
			e >>= 1;
		}
	}

	public static float RoleBitOrder(RoleBit role, bool mentor)
	{
		int num = 0;
		for (int i = 0; i < 5; i++)
		{
			if ((int)((uint)role & (uint)(1 << i)) > 0)
			{
				num += RoleOrder[i];
			}
		}
		if (mentor)
		{
			num += 16;
		}
		return num;
	}

	public static float GetRoleSalary(Employee emp, int role)
	{
		if (role == 4)
		{
			return GetRoleSalary(role, emp.GetMaxServiceSpec());
		}
		return GetRoleSalary(role);
	}

	public static float GetRoleSalary(EmployeeRole role, string spec = null)
	{
		if (role == EmployeeRole.Service)
		{
			if (spec != null)
			{
				return ServiceSalaryFactor[spec];
			}
			return 0.5f;
		}
		return RoleSalaryFactor[(int)role];
	}

	public static float GetRoleSalary(int role, string spec = null)
	{
		if (role == 4)
		{
			if (spec != null)
			{
				return ServiceSalaryFactor[spec];
			}
			return 0.5f;
		}
		return RoleSalaryFactor[role];
	}

	public string GetMaxSpec(int role)
	{
		if (role == 4)
		{
			return GetMaxServiceSpec();
		}
		return null;
	}

	public string GetMaxSpec(EmployeeRole role)
	{
		if (role == EmployeeRole.Service)
		{
			return GetMaxServiceSpec();
		}
		return null;
	}

	public string GetMaxServiceSpec()
	{
		if (_maxServiceSpec != null)
		{
			return _maxServiceSpec;
		}
		string text = null;
		float num = 0f;
		int num2 = -1;
		for (int i = 0; i < ServiceSalaryFactorArr.Length; i++)
		{
			KeyValuePair<string, float> keyValuePair = ServiceSalaryFactorArr[i];
			int specialization = GetSpecialization(EmployeeRole.Service, keyValuePair.Key);
			if (specialization > num2)
			{
				text = keyValuePair.Key;
				num2 = specialization;
				num = keyValuePair.Value;
			}
			else if (specialization == num2 && keyValuePair.Value > num)
			{
				text = keyValuePair.Key;
				num = keyValuePair.Value;
			}
		}
		_maxServiceSpec = text;
		return text;
	}

	public bool HasDemanded(LeadDesignDemands.Demand demand)
	{
		return (DemandResults & demand) > LeadDesignDemands.Demand.Fire;
	}

	public void AcceptDemand(LeadDesignDemands.DemandChoice d, int choice, bool player)
	{
		DemandsMet |= d.ID;
		DemandsRequested &= ~d.ID;
		LeadDesignDemands.Demand demand = ((choice == 0) ? d.Choice1 : d.Choice2);
		if (demand == LeadDesignDemands.Demand.Fire)
		{
			choice = 1 - choice;
			demand = ((choice == 0) ? d.Choice1 : d.Choice2);
		}
		DemandResults |= demand;
		Action<Employee> obj = ((choice == 0) ? d.Enact1 : d.Enact2);
		if (obj != null)
		{
			obj(this);
		}
		float num = ((choice == 0) ? d.Cost1 : d.Cost2);
		if (num > 0f && MyEmployer != null)
		{
			MyEmployer.MakeTransaction(0f - num, Company.TransactionCategory.Benefits, true, "LeadDemand" + demand);
			if (MyEmployer != null && MyEmployer.IsLocalPlayer)
			{
				UISoundFX.PlaySFX("Kaching");
			}
		}
		if (player)
		{
			RefreshDemands(false, 0);
		}
	}

	public void FinishLeadProject(SoftwareProduct p, float amount, bool owner, int rnd)
	{
		if (GameSettings.Instance.IsNetworkMode)
		{
			if (NetworkID == 0)
			{
				if (NetworkManager.Instance.Host)
				{
					NetworkMessaging.MoveLeadDesigner(this, MyEmployer, true, false);
					NetworkMessaging.SendFinishLeadProject(NetworkID, p.ID, amount, owner, rnd, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				}
				else
				{
					NetworkMessaging.SendLeadDesigner(NetworkManager.Instance.AddIDCallback(this, delegate
					{
						NetworkMessaging.SendFinishLeadProject(NetworkID, p.ID, amount, owner, rnd, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					}), this, MyEmployer.ID, false, NetworkMessaging.MessageTarget.Host, 0);
				}
			}
			else
			{
				NetworkMessaging.SendFinishLeadProject(NetworkID, p.ID, amount, owner, rnd, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
		}
		ActuallyFinishLeadProject(p, amount, owner, rnd);
	}

	public void ActuallyFinishLeadProject(SoftwareProduct p, float amount, bool owner, int rnd)
	{
		if (owner)
		{
			LeadProjectsFix.Add(p.ID);
			p.LeadDesigner = this;
			if (!AchievementController.HasAchievement("FULLMETA") && p.DevCompany.IsLocalPlayer && p.Type.Name.Equals("Game") && p.Category.Name.Equals("Simulation") && p.Name.ToLower().StartsWith("software inc") && p.DevCompany.Name.ToLower().StartsWith("coredumping") && Name.ToLower().Contains("kenneth"))
			{
				AchievementController.SetAchievement("FULLMETA");
			}
			if (HasDemanded(LeadDesignDemands.Demand.Royalties))
			{
				p.DesignerRoyalties = true;
			}
			if (HasDemanded(LeadDesignDemands.Demand.IPOwnership) && (p.SequelTo == null || (p.SequelTo.DesignerOwned && p.SequelTo.LeadDesigner == this)))
			{
				p.DesignerOwned = true;
			}
		}
		if (CreativityKnown < 1f)
		{
			CreativityKnown = Mathf.Min(1f, CreativityKnown + amount / 3f);
			if (MyEmployer != null && MyEmployer.IsLocalPlayer)
			{
				string text;
				if (CreativityKnown < 1f)
				{
					float[] creativityRange = GetCreativityRange();
					text = creativityRange[0].ToPercent(false) + " - " + creativityRange[1].ToPercent(false);
				}
				else
				{
					text = Creativity.ToPercent(false);
				}
				NotificationManager.AddNotification(new SingleEmployeeNotification("LeadDesignerCreativityChange".LocColor(this, text), "Lightbulb", NotificationManager.NotificationType.Good, this));
			}
		}
		_leadUpdateCount++;
		if (p.Type != MarketSimulation.Active.DigitalDistSoft)
		{
			float value;
			if (LeadSpecializationFix.TryGetValue(p.Type.Name, out value))
			{
				LeadSpecializationFix[p.Type.Name] = Mathf.Min(1f, value + amount / 2f);
			}
			else
			{
				LeadSpecializationFix[p.Type.Name] = amount / 2f;
			}
		}
		RefreshDemands(MyEmployer == null || MyEmployer is SimulatedCompany, rnd);
	}

	public void RevealCreativity(float amount)
	{
		if (!(CreativityKnown < 1f))
		{
			return;
		}
		CreativityKnown = Mathf.Min(1f, CreativityKnown + amount);
		if (MyEmployer != null && MyEmployer.IsLocalPlayer)
		{
			string text = null;
			if (CreativityKnown < 1f)
			{
				float[] creativityRange = GetCreativityRange();
				text = creativityRange[0].ToPercent(false) + " - " + creativityRange[1].ToPercent(false);
			}
			else
			{
				text = Creativity.ToPercent(false);
			}
			NotificationManager.AddNotification(new SingleEmployeeNotification("LeadDesignerCreativityChange".LocColor(this, text), "Lightbulb", NotificationManager.NotificationType.Good, this));
		}
		RefreshDemands(MyEmployer == null || MyEmployer is SimulatedCompany, Utilities.RNG.Next());
	}

	private void RandomizeLeadSpec(SoftwareType[] max)
	{
		int num = Mathf.CeilToInt(CreativityKnown.MapRange(0f, 1f, 0f, 5f));
		int y = SDateTime.Now().Year;
		if (num <= 0)
		{
			return;
		}
		HashSet<SoftwareType> hashSet = MarketSimulation.Active.SoftwareTypes.Values.Where((SoftwareType x) => !x.OneClient && x.IsUnlocked(y) && x.Categories.Values.Any((SoftwareCategory z) => z.IsUnlocked(y))).ToHashSet();
		if (max != null)
		{
			for (int num2 = 0; num2 < max.Length; num2++)
			{
				LeadSpecializationFix[max[num2].Name] = 1f;
				hashSet.Remove(max[num2]);
			}
			num -= max.Length;
		}
		float num3 = CreativityKnown / 0.5f;
		for (int num4 = 0; num4 < num; num4++)
		{
			SoftwareType random = hashSet.GetRandom(hashSet.Count);
			LeadSpecializationFix[random.Name] = Mathf.Min(1f, num3);
			num3 /= 2f;
			hashSet.Remove(random);
		}
	}

	public void RefreshDemands(bool forcePick, int rnd)
	{
		if (Founder || !(Creativity > 0.5f) || DemandsMet == LeadDesignDemands.AllDemands || DemandsRequested != 0)
		{
			return;
		}
		float num = InitialLeadExperience;
		for (int i = 0; i < LeadProjectsFix.Count; i++)
		{
			SoftwareProduct product = MarketSimulation.Active.GetProduct(LeadProjectsFix[i], true, true);
			if (product != null)
			{
				num += (float)(product.SubscriptionBased ? product.SubscriptionSum : product.UnitSum) / 5000000f;
			}
		}
		num /= GetLowerCreativity().MapRange(0f, 1f, 10f, 1f, true);
		LastDemandScore = Mathf.Clamp01(num);
		System.Random random = null;
		for (int j = 0; j < LeadDesignDemands.Demands.Length; j++)
		{
			LeadDesignDemands.DemandChoice demandChoice = LeadDesignDemands.Demands[j];
			if (!(demandChoice.Threshold <= num))
			{
				break;
			}
			if ((demandChoice.ID & DemandsMet) != 0)
			{
				continue;
			}
			if (forcePick)
			{
				int num2 = 0;
				if (demandChoice.Choice1 == LeadDesignDemands.Demand.Fire)
				{
					num2 = 1;
				}
				else if (demandChoice.Choice2 == LeadDesignDemands.Demand.Fire)
				{
					num2 = 0;
				}
				else
				{
					if (random == null)
					{
						random = new System.Random(rnd);
					}
					num2 = ((!(random.NextDouble() < 0.5)) ? 1 : 0);
				}
				AcceptDemand(demandChoice, num2, false);
				continue;
			}
			DemandsRequested = demandChoice.ID;
			break;
		}
	}

	public static string GetRoleString(RoleBit role)
	{
		if (role == RoleBit.None)
		{
			return "None".Loc();
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = (role & RoleBit.Lead) > RoleBit.None;
		if (flag)
		{
			stringBuilder.Append("Leader".Loc());
		}
		int num = 0;
		for (int i = 1; i < 5; i++)
		{
			if ((role & RoleToMask[i]) > RoleBit.None)
			{
				num++;
			}
		}
		bool flag2 = flag && num > 0;
		if (flag2)
		{
			stringBuilder.Append("(");
		}
		if (num == 4)
		{
			stringBuilder.Append("Anyrole".Loc());
		}
		else
		{
			bool flag3 = num > 2;
			int num2 = 0;
			for (int j = 1; j < 5; j++)
			{
				if ((role & RoleToMask[j]) <= RoleBit.None)
				{
					continue;
				}
				if (num2 != 0)
				{
					if (!flag3 || num + 1 == num2)
					{
						stringBuilder.Append("AndSeperator".Loc());
					}
					else
					{
						stringBuilder.Append(", ");
					}
				}
				num2++;
				string value;
				if (!flag3)
				{
					EmployeeRole employeeRole = (EmployeeRole)j;
					value = employeeRole.ToString().Loc();
				}
				else
				{
					value = ShortFormRole[j].Loc();
				}
				stringBuilder.Append(value);
				num--;
				if (num == 0)
				{
					break;
				}
			}
		}
		if (flag2)
		{
			stringBuilder.Append(")");
		}
		return stringBuilder.ToString();
	}

	public WorkItem.HasWorkReturn IsRoleSecondary(RoleBit role, bool includeSeconday)
	{
		if ((_currentRole & role) > RoleBit.None)
		{
			return WorkItem.HasWorkReturn.True;
		}
		if (!includeSeconday || (_secondaryRole & role) <= RoleBit.None)
		{
			return WorkItem.HasWorkReturn.NotApplicable;
		}
		return WorkItem.HasWorkReturn.Secondary;
	}

	public bool IsRole(RoleBit role, bool includeSeconday = false)
	{
		if (!includeSeconday)
		{
			return (_currentRole & role) > RoleBit.None;
		}
		return ((_currentRole | _secondaryRole) & role) > RoleBit.None;
	}

	public bool IsRole(int role, bool includeSeconday = false)
	{
		return IsRole((RoleBit)role, includeSeconday);
	}

	public bool IsRole(byte role, bool includeSeconday = false)
	{
		return IsRole((RoleBit)role, includeSeconday);
	}

	public bool IsRole(EmployeeRole role, bool includeSeconday = false)
	{
		return IsRole(RoleToMask[(int)role], includeSeconday);
	}

	public bool IsRoleIndex(int idx, bool includeSeconday = false)
	{
		return IsRole(RoleToMask[idx], includeSeconday);
	}

	public bool IsSecondaryRole(RoleBit role)
	{
		return (_secondaryRole & role) > RoleBit.None;
	}

	public bool IsSecondaryRole(EmployeeRole role)
	{
		return IsSecondaryRole(RoleToMask[(int)role]);
	}

	public bool IsSecondaryRoleIndex(int idx)
	{
		return IsSecondaryRole(RoleToMask[idx]);
	}

	public void SetRoles(RoleBit roles, RoleBit sRoles)
	{
		_currentRole = roles;
		_secondaryRole = sRoles & ~(RoleBit.Lead | _currentRole);
	}

	public int GetExpBit(Actor ac = null)
	{
		int num = 0;
		for (int i = 0; i < 5; i++)
		{
			if (!SpecPointsLeft(i, true))
			{
				continue;
			}
			float num2 = SpecializationExp[i];
			if (ac != null)
			{
				EmployeeRole r = (EmployeeRole)i;
				num2 -= (float)ac.Courses.Count((KeyValuePair<EmployeeRole, string> x) => x.Key == r);
			}
			if (num2 >= 1f)
			{
				num |= 1 << RoleOrderIndex[i];
			}
		}
		return num;
	}

	public static Dictionary<FriendKey, float> GetAllFriendships()
	{
		return _friendships;
	}

	public static void SetAllFriendships(Dictionary<FriendKey, float> friendData)
	{
		_friendships = friendData;
		foreach (KeyValuePair<FriendKey, float> friendship in _friendships)
		{
			if (friendship.Key.E1._localFriendCache == null)
			{
				friendship.Key.E1._localFriendCache = new HashSet<Employee>();
			}
			if (friendship.Key.E2._localFriendCache == null)
			{
				friendship.Key.E2._localFriendCache = new HashSet<Employee>();
			}
			friendship.Key.E1._localFriendCache.Add(friendship.Key.E2);
			friendship.Key.E2._localFriendCache.Add(friendship.Key.E1);
		}
	}

	public static float GetFriendship(Employee e1, Employee e2)
	{
		return _friendships.GetOrDefault(new FriendKey(e1, e2), 0f);
	}

	public static void ResetFriendships()
	{
		_friendships.Clear();
	}

	public static void SetFriendship(Employee e1, Employee e2, float amount)
	{
		if (amount == 0f)
		{
			DeleteFriendship(e1, e2);
		}
		else
		{
			_friendships[new FriendKey(e1, e2)] = Mathf.Min(amount, 2f);
		}
	}

	public static void AddToFriendship(Employee e1, Employee e2, float amount)
	{
		if (e1 == e2)
		{
			return;
		}
		FriendKey key = new FriendKey(e1, e2);
		if (e1.HasTrait(Trait.FriendMaker) || e2.HasTrait(Trait.FriendMaker))
		{
			if (!(amount > 0f))
			{
				return;
			}
			amount *= 2f;
		}
		float value;
		if (_friendships.TryGetValue(key, out value))
		{
			if (value < 2f)
			{
				if (value >= 1f)
				{
					amount *= 0.5f;
				}
				value = Mathf.Min(value + amount, 2f);
				if (value <= 0f)
				{
					e1.LocalFriendCache.Remove(e2);
					e2.LocalFriendCache.Remove(e1);
					_friendships.Remove(key);
				}
				else
				{
					e1.LocalFriendCache.Add(e2);
					e2.LocalFriendCache.Add(e1);
					_friendships[key] = value;
				}
			}
		}
		else if (amount > 0f)
		{
			float value2 = Mathf.Min(amount, 2f);
			e1.LocalFriendCache.Add(e2);
			e2.LocalFriendCache.Add(e1);
			_friendships[key] = value2;
		}
	}

	public static void DeleteFriendship(Employee e1, Employee e2)
	{
		e1.LocalFriendCache.Remove(e2);
		e2.LocalFriendCache.Remove(e1);
		_friendships.Remove(new FriendKey(e1, e2));
	}

	public static void DeleteFriendships(Employee e)
	{
		foreach (Employee item in e.LocalFriendCache)
		{
			item.LocalFriendCache.Remove(e);
			_friendships.Remove(new FriendKey(e, item));
		}
		e.LocalFriendCache.Clear();
	}

	public static List<ValueTuple<Employee, float>> GetFriendships(Employee e)
	{
		_friendCache2.Clear();
		foreach (Employee item in e.LocalFriendCache)
		{
			_friendCache2.Add(new ValueTuple<Employee, float>(item, GetFriendship(e, item)));
		}
		return _friendCache2;
	}

	public void RefreshFriendships(HashSet<Employee> others)
	{
		if (!MyActor.IsAliveNotNull())
		{
			return;
		}
		_friendCache2.Clear();
		foreach (Employee item2 in LocalFriendCache)
		{
			_friendCache2.Add(new ValueTuple<Employee, float>(item2, 0f));
		}
		for (int i = 0; i < _friendCache2.Count; i++)
		{
			Employee item = _friendCache2[i].Item1;
			if (item.MyActor.IsAliveNotNull() && MyActor.DID > item.MyActor.DID)
			{
				float num = Compatibility(item, false).MapRange(0.5f, 2f, 0f, 0.3f, true) / (float)GameSettings.DaysPerMonth;
				if (others.Remove(item))
				{
					AddToFriendship(this, item, num);
				}
				else
				{
					AddToFriendship(this, item, (0f - num) / 4f);
				}
			}
		}
		foreach (Employee other in others)
		{
			if (other.MyActor.IsAliveNotNull() && MyActor.DID > other.MyActor.DID)
			{
				float num2 = Compatibility(other, false).MapRange(0.5f, 2f, 0f, 0.3f, true) / (float)GameSettings.DaysPerMonth;
				if (num2 > 0f)
				{
					AddToFriendship(this, other, num2);
				}
			}
		}
	}

	public bool HasTrait(Trait t)
	{
		return (Traits & t) != 0;
	}

	public float ModTrait(Trait t, float has, float hasNot = 1f)
	{
		if ((Traits & t) == Trait.None)
		{
			return hasNot;
		}
		return has;
	}

	public float AddTrait(Trait t, float has, float hasNot = 0f)
	{
		if ((Traits & t) == Trait.None)
		{
			return hasNot;
		}
		return has;
	}

	private void UpdateMood(float delta, Actor act)
	{
		List<ThoughtEffect> list = Thoughts.List;
		for (int i = 0; i < list.Count; i++)
		{
			ThoughtEffect thoughtEffect = list[i];
			MoodEffect mood = thoughtEffect.Mood;
			if (thoughtEffect.Effect > 0f)
			{
				if (mood.Negative)
				{
					if (JobSatisfaction > 1f - mood.CutOff)
					{
						JobSatisfaction = Mathf.Max(1f - mood.CutOff, JobSatisfaction - Utilities.PerHour(thoughtEffect.Effect, delta, false));
					}
					if (JobSatisfaction <= 0f)
					{
						SatisfactionHitZero = true;
					}
				}
				else if (JobSatisfaction < 1f + mood.CutOff)
				{
					JobSatisfaction = Mathf.Min(1f + mood.CutOff, JobSatisfaction + Utilities.PerHour(thoughtEffect.Effect, delta, false));
				}
			}
			if (thoughtEffect.Frames > 0)
			{
				thoughtEffect.Frames--;
				continue;
			}
			float num = Utilities.PerHour(mood.Decrement, delta, false);
			if (num > thoughtEffect.Effect)
			{
				Thoughts.Remove(thoughtEffect.Mood.Thought);
				i--;
			}
			else
			{
				thoughtEffect.Effect -= num;
			}
		}
		JobSatisfaction = Mathf.Clamp(JobSatisfaction, 0f, 2f);
		if (JobSatisfaction < 0.1f)
		{
			act.AddMoodNotification(ActorMoodNotification.Issue.UnsatisfiedWarning);
		}
		if (LowestSatisfaction <= 0f)
		{
			LowestSatisfaction = JobSatisfaction;
		}
		else
		{
			LowestSatisfaction = Mathf.Min(LowestSatisfaction, JobSatisfaction);
		}
	}

	public void SkipMood(float minutes)
	{
		List<ThoughtEffect> list = Thoughts.List;
		for (int i = 0; i < list.Count; i++)
		{
			ThoughtEffect thoughtEffect = list[i];
			MoodEffect mood = thoughtEffect.Mood;
			if (mood.UpdateAlways)
			{
				thoughtEffect.Frames = 0;
				float num = minutes / 60f * mood.Decrement;
				if (num > thoughtEffect.Effect)
				{
					Thoughts.Remove(thoughtEffect.Mood.Thought);
					i--;
				}
				else
				{
					thoughtEffect.Effect -= num;
				}
			}
		}
	}

	public static float GetCreativityFor(float age, EmployeeRole main)
	{
		if (main == EmployeeRole.Designer)
		{
			float a = age.MapRange(Youngest, RetirementAge - 10, 0.4f, 0.5f, true);
			float b = age.MapRange(Youngest, RetirementAge - 10, 1f, 0.7f, true);
			float mean = age.MapRange(Youngest, RetirementAge - 10, 0.6f, 0.8f, true);
			return Mathf.Lerp(a, b, Utilities.RandomGaussClamped(mean));
		}
		return Utilities.RandomGaussClamped(0.5f, 0.1f);
	}

	public static float GetCreativityKnownFor(float age, EmployeeRole main)
	{
		if (main == EmployeeRole.Designer)
		{
			float min = age.MapRange(Youngest, RetirementAge - 10, 0f, 0.5f, true);
			float max = age.MapRange(Youngest, RetirementAge - 10, 0f, 1f, true);
			return Utilities.RandomRange(min, max);
		}
		return 0f;
	}

	public static float GetInitialExpecienceFor(float age, float known)
	{
		float min = age.MapRange(Youngest, RetirementAge - 10, 0f, 0.1f + known, true);
		float max = age.MapRange(Youngest, RetirementAge - 10, 0f, 5f, true);
		return Utilities.RandomRange(min, max) * known;
	}

	public static float GetInspirationReloadTime(float creativity)
	{
		float max = creativity.MapRange(0f, 1f, 1f, 6f);
		return Utilities.RandomRange(1f, max);
	}

	public void TakeInspiration(float amount)
	{
		SDateTime sDateTime = SDateTime.Now();
		if (SDateTime.DayHasPassed(LastInpirationUse, sDateTime))
		{
			Inspiration = Mathf.Min(2f, Inspiration + SDateTime.GetMonths(LastInpirationUse, sDateTime) / InspirationTime);
		}
		Inspiration = Mathf.Max(0f, Inspiration - amount);
		LastInpirationUse = sDateTime;
	}

	public float GetActualInspiration()
	{
		float num = Inspiration;
		SDateTime now = SDateTime.Now();
		if (SDateTime.DayHasPassed(LastInpirationUse, now))
		{
			num = Mathf.Min(2f, num + SDateTime.GetMonths(LastInpirationUse, now) / InspirationTime);
		}
		return num;
	}

	public float GetLowerCreativity()
	{
		if (CreativityKnown == 1f)
		{
			return Creativity;
		}
		if (CreativityKnown == 0f)
		{
			return 0f;
		}
		float num = (Utilities.GetRandomNumber(Name, 453434178) - 0.5f) * 2f;
		float num2 = (1f - CreativityKnown) * 0.5f;
		float num3 = Mathf.Clamp01(Creativity - num2 + num * num2);
		float num4 = Mathf.Clamp01(Creativity + num2 + num * num2);
		if (num4 - num3 < 1f - CreativityKnown)
		{
			float num5 = (num4 + num3) * 0.5f;
			num3 = num5 - num2;
			num4 = num5 + num2;
			if (num3 < 0f)
			{
				num4 -= num3;
				num3 = 0f;
			}
			if (num4 > 1f)
			{
				num3 -= num4 - 1f;
			}
			num3 = Mathf.Clamp01(num3);
		}
		return num3;
	}

	public float[] GetCreativityRange()
	{
		if (CreativityKnown != 1f)
		{
			if (CreativityKnown != 0f)
			{
				float num = (Utilities.GetRandomNumber(Name, 453434178) - 0.5f) * 2f;
				float num2 = (1f - CreativityKnown) * 0.5f;
				float num3 = Mathf.Clamp01(Creativity - num2 + num * num2);
				float num4 = Mathf.Clamp01(Creativity + num2 + num * num2);
				if (num4 - num3 < 1f - CreativityKnown)
				{
					float num5 = (num4 + num3) * 0.5f;
					num3 = num5 - num2;
					num4 = num5 + num2;
					if (num3 < 0f)
					{
						num4 -= num3;
						num3 = 0f;
					}
					if (num4 > 1f)
					{
						num3 -= num4 - 1f;
						num4 = 1f;
					}
					num3 = Mathf.Clamp01(num3);
					num4 = Mathf.Clamp01(num4);
				}
				return new float[2] { num3, num4 };
			}
			return new float[2] { 0f, 1f };
		}
		return new float[2] { Creativity, Creativity };
	}

	public int GetActiveLeadProjects(DesignDocument ignore = null)
	{
		if (MyActor == null)
		{
			return 0;
		}
		Team team = MyActor.GetTeam();
		if (team == null)
		{
			return 0;
		}
		return team.WorkItems.OfType<DesignDocument>().Count((DesignDocument x) => x != ignore && x.LeadDesigner == this);
	}

	public float GetWeightedLeadSpecFactor(SoftwareType type)
	{
		if (type == MarketSimulation.Active.DigitalDistSoft)
		{
			return 1f;
		}
		return LeadSpecializationFix.GetOrDefault(type.Name, 0f).MapRange(0f, 1f, 0.5f + (1f - Creativity) * 0.5f, 1f);
	}

	public float GetLeadDesignPriority(SoftwareType type, DesignDocument ignore = null)
	{
		float num = GetActualInspiration() - (float)GetActiveLeadProjects(ignore);
		if (num <= 1f)
		{
			return num - 1.1f;
		}
		return GetLowerCreativity() * num * ((type == null) ? 1f : GetWeightedLeadSpecFactor(type));
	}

	public float NextLevel(Actor ac)
	{
		float num = 0f;
		for (int i = 0; i < 5; i++)
		{
			EmployeeRole r = (EmployeeRole)i;
			if (SpecUsed[i] >= Mathf.Min(GameSettings.Instance.GetUnlockedSpecializations(r).Length * 3, GameSettings.GetMaxSpecPoints(r, HasTrait(Trait.BigBrain) && r == HiredFor)))
			{
				continue;
			}
			float num2 = GetSpecExperience(r);
			if (num2 > 0f)
			{
				num2 -= (float)ac.Courses.Count((KeyValuePair<EmployeeRole, string> x) => x.Key == r);
			}
			num = Mathf.Min(1f, Mathf.Max(num2, num));
			if (num >= 1f)
			{
				break;
			}
		}
		return num;
	}

	public void DecreaseMood(string effect, Actor act, float amount)
	{
		ThoughtEffect value;
		if (!Founder && !(amount <= 0f) && amount.IsValidFloat() && MyEmployer != null && Thoughts.TryGetValue(effect, out value))
		{
			if (amount >= value.Effect)
			{
				Thoughts.Remove(effect);
			}
			else
			{
				value.Effect -= amount;
			}
		}
	}

	public void AddInstantMood(string effect, Actor act, float factor = 1f)
	{
		if (Founder || factor <= 0f || !factor.IsValidFloat() || MyEmployer == null)
		{
			return;
		}
		float num = 1f;
		if (HasTrait(Trait.Unphased))
		{
			factor *= 0.25f;
			num = 0.1f;
		}
		ThoughtEffect thoughtEffect = Thoughts.GetOrNull(effect);
		float backValue = 0f;
		ThoughtEffect thoughtEffect2;
		if (thoughtEffect != null)
		{
			thoughtEffect2 = ((thoughtEffect.Mood.CounterMood == null) ? null : Thoughts.GetOrNull(thoughtEffect.Mood.CounterMood));
			float num2 = CalculateChange(thoughtEffect.Mood.Increment * factor, ref backValue, thoughtEffect2);
			if (thoughtEffect.Effect < thoughtEffect.Mood.Max * num)
			{
				thoughtEffect.Effect = Mathf.Min(thoughtEffect.Mood.Max * num, thoughtEffect.Effect + num2);
			}
			if (thoughtEffect.Mood.WarningThreshold > 0f && thoughtEffect.Effect > thoughtEffect.Mood.WarningThreshold)
			{
				AddWarning(thoughtEffect.Mood.Warning, act);
			}
		}
		else
		{
			MoodEffect moodEffect = GameData.MoodEffects[effect];
			thoughtEffect2 = ((moodEffect.CounterMood == null) ? null : Thoughts.GetOrNull(moodEffect.CounterMood));
			float value = CalculateChange(Mathf.Min(moodEffect.Max * num, moodEffect.StartValue * factor), ref backValue, thoughtEffect2);
			thoughtEffect = new ThoughtEffect(moodEffect, value);
			Thoughts[effect] = thoughtEffect;
		}
		thoughtEffect.Frames = 5;
		if (backValue > 0f && thoughtEffect2 != null)
		{
			thoughtEffect2.Effect = Mathf.Max(0f, thoughtEffect2.Effect - backValue);
		}
	}

	public void AddMood(string effect, Actor act)
	{
		AddMood(effect, act, Time.deltaTime);
	}

	public void AddMood(string effect, Actor act, float delta, float factor = 1f, bool useGameSpeed = true, bool scaleStart = true)
	{
		if (Founder || !factor.IsValidFloat() || MyEmployer == null)
		{
			return;
		}
		ThoughtEffect thoughtEffect = Thoughts.GetOrNull(effect);
		float backValue = 0f;
		float num = 1f;
		if (HasTrait(Trait.Unphased))
		{
			factor *= 0.25f;
			num = 0.1f;
		}
		ThoughtEffect thoughtEffect2;
		if (thoughtEffect != null)
		{
			thoughtEffect2 = ((thoughtEffect.Mood.CounterMood == null) ? null : Thoughts.GetOrNull(thoughtEffect.Mood.CounterMood));
			float num2 = thoughtEffect.Mood.StartValue;
			if (scaleStart)
			{
				num2 *= factor;
			}
			if (thoughtEffect.Effect < thoughtEffect.Mood.Max * num)
			{
				if (thoughtEffect.Effect < num2)
				{
					float num3 = CalculateChange(num2 - thoughtEffect.Effect, ref backValue, thoughtEffect2);
					thoughtEffect.Effect = Mathf.Min(thoughtEffect.Mood.Max * num, thoughtEffect.Effect + num3);
				}
				else
				{
					float num4 = CalculateChange(Utilities.PerHour(thoughtEffect.Mood.Increment * factor, delta, useGameSpeed), ref backValue, thoughtEffect2);
					thoughtEffect.Effect = Mathf.Min(thoughtEffect.Mood.Max * num, thoughtEffect.Effect + num4);
				}
			}
			if (thoughtEffect.Mood.WarningThreshold > 0f && thoughtEffect.Effect > thoughtEffect.Mood.WarningThreshold)
			{
				AddWarning(thoughtEffect.Mood.Warning, act);
			}
		}
		else
		{
			MoodEffect moodEffect = GameData.MoodEffects[effect];
			thoughtEffect2 = ((moodEffect.CounterMood == null) ? null : Thoughts.GetOrNull(moodEffect.CounterMood));
			float value = CalculateChange(Mathf.Min(moodEffect.Max * num, scaleStart ? (moodEffect.StartValue * factor) : moodEffect.StartValue), ref backValue, thoughtEffect2);
			thoughtEffect = new ThoughtEffect(moodEffect, value);
			Thoughts[effect] = thoughtEffect;
		}
		thoughtEffect.Frames = 5;
		if (backValue > 0f && thoughtEffect2 != null)
		{
			thoughtEffect2.Effect = Mathf.Max(0f, thoughtEffect2.Effect - backValue);
		}
	}

	private void AddWarning(string warning, Actor act)
	{
		ActorMoodNotification.Issue result;
		if (Enum.TryParse<ActorMoodNotification.Issue>(warning, false, out result))
		{
			act.AddMoodNotification(result);
		}
		else
		{
			Debug.LogError("Failed adding employee mood warning " + warning);
		}
	}

	private float CalculateChange(float effect, ref float backValue, ThoughtEffect thought)
	{
		float num = effect;
		if (thought != null)
		{
			num = Mathf.Max(0f, effect - thought.Effect);
			backValue = Mathf.Max(0f, effect - num);
		}
		return num;
	}

	public bool GetMood(string effect, out float value)
	{
		ThoughtEffect value2;
		if (Thoughts.TryGetValue(effect, out value2))
		{
			value = value2.Effect;
			return true;
		}
		value = 0f;
		return false;
	}

	public void SetMood(string effect, Actor act, float value)
	{
		if (Founder || value < 0f || !value.IsValidFloat() || MyEmployer == null)
		{
			return;
		}
		if (value == 0f)
		{
			Thoughts.Remove(effect);
			return;
		}
		float num = 1f;
		if (HasTrait(Trait.Unphased))
		{
			value *= 0.25f;
			num = 0.1f;
		}
		ThoughtEffect thoughtEffect = Thoughts.GetOrNull(effect);
		MoodEffect moodEffect = GameData.MoodEffects[effect];
		if (thoughtEffect != null)
		{
			thoughtEffect.Effect = Mathf.Min(moodEffect.Max * num, value);
		}
		else
		{
			thoughtEffect = new ThoughtEffect(moodEffect, Mathf.Min(moodEffect.Max * num, value));
			Thoughts[effect] = thoughtEffect;
		}
		if (moodEffect.WarningThreshold > 0f && thoughtEffect.Effect > moodEffect.WarningThreshold)
		{
			AddWarning(moodEffect.Warning, act);
		}
		thoughtEffect.Frames = 5;
	}

	public string GetHighestThought()
	{
		ThoughtEffect thoughtEffect = null;
		float num = 0f;
		for (int i = 0; i < Thoughts.Count; i++)
		{
			ThoughtEffect thoughtEffect2 = Thoughts[i];
			if (thoughtEffect2.Effect > num)
			{
				num = thoughtEffect2.Effect;
				thoughtEffect = thoughtEffect2;
			}
		}
		if (thoughtEffect != null)
		{
			return thoughtEffect.Mood.Thought;
		}
		return null;
	}

	public void Dismiss(bool transfer)
	{
		Dismissed = true;
		if (!transfer && MyEmployer != null)
		{
			PayForDemands(MyEmployer, true);
		}
		GameSettings.Instance.ConferenceController.RemoveFromBooth(MyEmployer, this);
	}

	public float GetAge()
	{
		return GetAge(SDateTime.Now());
	}

	public float GetAge(SDateTime time)
	{
		return SDateTime.GetYears(BirthDate, time);
	}

	public int GetAgeFlat()
	{
		return GetAgeFlat(SDateTime.Now());
	}

	public int GetAgeFlat(SDateTime time)
	{
		int num = (time.Year * 12 + time.Month) * GameSettings.DaysPerMonth + time.Day;
		int num2 = (BirthDate.Year * 12 + BirthDate.Month) * GameSettings.DaysPerMonth + BirthDate.Day;
		return (num - num2) / GameSettings.DaysPerMonth / 12;
	}

	public int GetAgeMonth()
	{
		return GetAgeMonth(SDateTime.Now());
	}

	public int GetAgeMonth(SDateTime time)
	{
		int num = (time.Year * 12 + time.Month) * GameSettings.DaysPerMonth + time.Day;
		int num2 = (BirthDate.Year * 12 + BirthDate.Month) * GameSettings.DaysPerMonth + BirthDate.Day;
		return (num - num2) / GameSettings.DaysPerMonth;
	}

	public void AddSpecExperience(EmployeeRole role, float value)
	{
		float num = SpecializationExp[(int)role];
		float num2 = num + value;
		SetSpecExperience(role, num2);
		if (num < 1f && num2 >= 1f)
		{
			HUD.Instance.employeeWindow.UpdateEdNumber();
		}
	}

	public void SetSpecExperience(EmployeeRole role, float value)
	{
		SpecializationExp[(int)role] = Mathf.Min(GameSettings.GetMaxSpecPoints(role, HasTrait(Trait.BigBrain) && role == HiredFor) - SpecUsed[(int)role], value);
	}

	public float GetSpecExperience(EmployeeRole role, Actor ac = null)
	{
		return SpecializationExp[(int)role] - (float)((!(ac == null)) ? ac.Courses.Count((KeyValuePair<EmployeeRole, string> x) => x.Key == role) : 0);
	}

	public bool AnySpecPoints(Actor ac = null, bool onlyActiveRoles = false)
	{
		for (int i = 0; i < SpecializationExp.Length; i++)
		{
			float num = SpecializationExp[i];
			if ((onlyActiveRoles && !IsRole((EmployeeRole)i, true)) || !SpecPointsLeft(i, true))
			{
				continue;
			}
			if (ac != null)
			{
				EmployeeRole r = (EmployeeRole)i;
				num -= (float)ac.Courses.Count((KeyValuePair<EmployeeRole, string> x) => x.Key == r);
			}
			if (num >= 1f)
			{
				return true;
			}
		}
		return false;
	}

	public bool AnySpecPoints(ref bool max, Actor ac)
	{
		for (int i = 0; i < SpecializationExp.Length; i++)
		{
			float num = SpecializationExp[i];
			EmployeeRole r = (EmployeeRole)i;
			if (!SpecPointsLeft(r, ac, true))
			{
				max |= num >= 1f;
				continue;
			}
			num -= (float)ac.Courses.Count((KeyValuePair<EmployeeRole, string> x) => x.Key == r);
			if (num >= 1f)
			{
				return true;
			}
		}
		return false;
	}

	public float GetEducationFactor(EmployeeRole role, SDateTime time)
	{
		return GetAge(time).MapRange(Youngest, RetirementAge, 1f, 0.9f, true) * Skill[(int)role].MapRange(0f, 0.5f, 0.75f, 1f, true) * ModTrait(Trait.FastLearner, 1.5f);
	}

	public void SetSpecialization(EmployeeRole role, string spec, int level)
	{
		level = Mathf.Clamp(level, 0, Mathf.Max(0, Mathf.Min(GameSettings.GetMaxSpecPoints(role, HasTrait(Trait.BigBrain)) - SpecUsed[(int)role], 3)));
		if (level == 0)
		{
			SpecUsed[(int)role] -= SpecializationLevels[(int)role].GetOrDefault(spec, 0);
			SpecializationLevels[(int)role].Remove(spec);
		}
		else
		{
			SpecUsed[(int)role] += level - SpecializationLevels[(int)role].GetOrDefault(spec, 0);
			SpecializationLevels[(int)role][spec] = level;
		}
		if (role == EmployeeRole.Service)
		{
			_maxServiceSpec = null;
		}
	}

	public bool SpecPointsLeft(EmployeeRole r)
	{
		return SpecUsed[(int)r] < GameSettings.GetMaxSpecPoints(r, HasTrait(Trait.BigBrain) && r == HiredFor);
	}

	public bool SpecPointsLeft(EmployeeRole r, Actor ac, bool limitToUnlocked = false)
	{
		return SpecUsed[(int)r] + ac.Courses.Count((KeyValuePair<EmployeeRole, string> x) => x.Key == r) < GameSettings.GetMaxSpecPoints(r, HasTrait(Trait.BigBrain) && r == HiredFor, limitToUnlocked);
	}

	public bool SpecPointsLeft(int r, bool limitToUnlocked = false)
	{
		return SpecUsed[r] < GameSettings.GetMaxSpecPoints((EmployeeRole)r, HasTrait(Trait.BigBrain) && r == (int)HiredFor, limitToUnlocked);
	}

	public int GetSpecPointsLeft(EmployeeRole r, Actor ac)
	{
		int num = ((!(ac == null)) ? ac.Courses.Count((KeyValuePair<EmployeeRole, string> x) => x.Key == r) : 0);
		return Mathf.Max(0, GameSettings.GetMaxSpecPoints(r, HasTrait(Trait.BigBrain) && r == HiredFor) - SpecUsed[(int)r] - num);
	}

	public int GetSpecPointsAvailable(EmployeeRole r, Actor ac)
	{
		return Mathf.Max(0, Mathf.FloorToInt(GetSpecExperience(r)) - ac.Courses.Count((KeyValuePair<EmployeeRole, string> x) => x.Key == r));
	}

	public bool AddSpecialization(EmployeeRole role, string spec, bool subtractExp = true, bool force = false, int amount = 1)
	{
		float specExperience = GetSpecExperience(role);
		if (force || specExperience >= 1f)
		{
			int value;
			if (SpecializationLevels[(int)role].TryGetValue(spec, out value))
			{
				int num = value;
				int num2 = Mathf.Clamp(value + amount, 0, 3);
				SpecUsed[(int)role] += num2 - num;
				SpecializationLevels[(int)role][spec] = num2;
			}
			else
			{
				int num3 = Mathf.Clamp(amount, 0, 3);
				SpecUsed[(int)role] += num3;
				SpecializationLevels[(int)role][spec] = num3;
			}
			if (subtractExp)
			{
				SetSpecExperience(role, Mathf.Max(0f, specExperience - 1f));
				HUD.Instance.employeeWindow.UpdateEdNumber();
			}
			if (role == EmployeeRole.Service)
			{
				_maxServiceSpec = null;
			}
			return true;
		}
		return false;
	}

	public int GetBestSpecialization(bool design, SoftwareWorkItem.FeatureProgress f)
	{
		int num = 0;
		if (design)
		{
			num = SpecializationLevels[2].GetOrDefault(f.Feature.Spec, 0);
		}
		if (!design && !f.ArtDone && f.Feature.CodeArtRatio < 1f)
		{
			num = Mathf.Max(num, SpecializationLevels[3].GetOrDefault(f.Feature.Spec, 0));
		}
		if (!design && !f.CodeDone && f.Feature.CodeArtRatio > 0f)
		{
			num = Mathf.Max(num, SpecializationLevels[1].GetOrDefault(f.Feature.Spec, 0));
		}
		return num;
	}

	public int GetSpecialization(EmployeeRole role, string spec, Actor ac = null)
	{
		int num = SpecializationLevels[(int)role].GetOrDefault(spec, 0);
		if (!ac.IsReferenceNull())
		{
			for (int i = 0; i < ac.Courses.Count; i++)
			{
				KeyValuePair<EmployeeRole, string> keyValuePair = ac.Courses[i];
				if (keyValuePair.Key == role && keyValuePair.Value.Equals(spec))
				{
					num++;
				}
			}
		}
		return num;
	}

	public Dictionary<string, int>[] GetAllSpecializations()
	{
		return SpecializationLevels.Select((Dictionary<string, int> x) => x.ToDictionary((KeyValuePair<string, int> z) => z.Key, (KeyValuePair<string, int> z) => z.Value)).ToArray();
	}

	public void LoseSpec()
	{
		int num = UnityEngine.Random.Range(0, 5);
		for (int i = 0; i < 5; i++)
		{
			int num2 = (i + num) % 5;
			Dictionary<string, int> dictionary = SpecializationLevels[num2];
			if (dictionary.Count > 0)
			{
				string random = (from x in dictionary
					where x.Value > 0
					select x.Key).GetRandom();
				if (random != null)
				{
					dictionary[random]--;
					SpecUsed[num2]--;
					AddSpecExperience((EmployeeRole)num2, 1f);
					break;
				}
			}
		}
	}

	public bool CanWorkOnFeature(SoftwareWorkItem.FeatureProgress prog, bool secondary, bool design)
	{
		FeatureBase feature = prog.Feature;
		return CanWorkOnFeature(feature.Spec, feature.Level, prog.CodeDone, prog.ArtDone, feature.CodeArtRatio, secondary, design);
	}

	public bool CanWorkOnFeature(string spec, int level, bool codeDone, bool artDone, float ratio, bool secondary, bool design)
	{
		if (design)
		{
			if (IsRole(EmployeeRole.Designer, secondary) && !codeDone)
			{
				return SpecializationLevels[2].GetOrDefault(spec, 0) >= level;
			}
			return false;
		}
		int num;
		int num2;
		if (ratio < 1f && IsRole(EmployeeRole.Artist, secondary) && !artDone)
		{
			num = ((SpecializationLevels[3].GetOrDefault(spec, 0) >= level) ? 1 : 0);
			if (num != 0)
			{
				num2 = 1;
				goto IL_008f;
			}
		}
		else
		{
			num = 0;
		}
		num2 = ((ratio > 0f && IsRole(EmployeeRole.Programmer, secondary) && !codeDone && SpecializationLevels[1].GetOrDefault(spec, 0) >= level) ? 1 : 0);
		goto IL_008f;
		IL_008f:
		bool flag = (byte)num2 != 0;
		return (byte)((uint)num | (flag ? 1u : 0u)) != 0;
	}

	public WorkItem.HasWorkReturn CanWorkOnFeatureSecondary(SoftwareWorkItem.FeatureProgress prog, bool secondary, bool design)
	{
		FeatureBase feature = prog.Feature;
		if (design)
		{
			if (!prog.CodeDone)
			{
				WorkItem.HasWorkReturn hasWorkReturn = IsRoleSecondary(RoleBit.Designer, secondary);
				if (hasWorkReturn != WorkItem.HasWorkReturn.NotApplicable && SpecializationLevels[2].GetOrDefault(feature.Spec, 0) >= feature.Level)
				{
					return hasWorkReturn;
				}
			}
			return WorkItem.HasWorkReturn.NotApplicable;
		}
		WorkItem.HasWorkReturn hasWorkReturn2 = WorkItem.HasWorkReturn.NotApplicable;
		if (feature.CodeArtRatio < 1f && !prog.ArtDone)
		{
			WorkItem.HasWorkReturn hasWorkReturn3 = IsRoleSecondary(RoleBit.Artist, secondary);
			if (hasWorkReturn3 != WorkItem.HasWorkReturn.NotApplicable && SpecializationLevels[3].GetOrDefault(feature.Spec, 0) >= feature.Level)
			{
				hasWorkReturn2 = WorkItem.CombineWorkResult(hasWorkReturn3, hasWorkReturn2);
			}
		}
		if (feature.CodeArtRatio > 0f && !prog.CodeDone)
		{
			WorkItem.HasWorkReturn hasWorkReturn4 = IsRoleSecondary(RoleBit.Programmer, secondary);
			if (hasWorkReturn4 != WorkItem.HasWorkReturn.NotApplicable && SpecializationLevels[1].GetOrDefault(feature.Spec, 0) >= feature.Level)
			{
				hasWorkReturn2 = WorkItem.CombineWorkResult(hasWorkReturn4, hasWorkReturn2);
			}
		}
		return hasWorkReturn2;
	}

	public float GetSkillAverage()
	{
		return Skill.Average();
	}

	public float GetSkillI(int i)
	{
		return Skill[i];
	}

	public float GetSkill(EmployeeRole role)
	{
		return Skill[(int)role];
	}

	public float GetHireSkill(EmployeeRole role)
	{
		return ConvertHireSkill(role, Skill[(int)role]);
	}

	public static float ConvertHireSkill(EmployeeRole role, float skill)
	{
		return skill.MapRange(LowSkillCap[(int)role], 1f, 0f, 1f, true);
	}

	public float Compatibility(Employee other, bool useFriendship = true)
	{
		if (other == this || GameSettings.Instance.IsReferenceNull() || PersonalityTraits == null || other.PersonalityTraits == null)
		{
			return 1f;
		}
		float num = 0f;
		for (int i = 0; i < PersonalityTraits.Length; i++)
		{
			for (int j = 0; j < other.PersonalityTraits.Length; j++)
			{
				num += GameSettings.Instance.Personalities[PersonalityTraits[i], other.PersonalityTraits[j]];
			}
		}
		float num2 = num / (float)(PersonalityTraits.Length * other.PersonalityTraits.Length);
		if (!useFriendship)
		{
			return num2;
		}
		return ModifyCompatibilityWithFriendship(other, num2);
	}

	public float ModifyCompatibilityWithFriendship(Employee other, float compatibility)
	{
		float friendship = GetFriendship(this, other);
		return compatibility + friendship * friendship / 8f;
	}

	public void InitializeSpecializations(string[] mainSpec, float skillFact, float age)
	{
		int num = Mathf.Clamp(Mathf.RoundToInt(age.MapRange(Youngest, RetirementAge - 20, 1f, 3f)), 0, 3);
		foreach (int item in from x in Enumerable.Range(0, 5)
			orderby Skill[x] descending
			select x)
		{
			int num2 = ((item == 4) ? Mathf.RoundToInt(skillFact.MapRange(0f, 1f, 1f, 4f, true)) : Mathf.RoundToInt((float)GameSettings.GetMaxSpecPoints((EmployeeRole)item, HasTrait(Trait.BigBrain) && item == (int)HiredFor) / skillFact.MapRange(0f, 1f, 2f, Mathf.Lerp(1.5f, 1f, age.MapRange(Youngest, RetirementAge - 20, 0f, 1f, true)))));
			string[] source = (GameSettings.Instance.IsReferenceNull() ? GameData.GetUnlockedSpecializations((EmployeeRole)item) : GameSettings.Instance.GetUnlockedSpecializations((EmployeeRole)item));
			int num3 = 0;
			foreach (string item2 in source.OrderBy(delegate(string x)
			{
				if (mainSpec == null)
				{
					return Utilities.RandomValue;
				}
				int num5 = Array.IndexOf(mainSpec, x);
				return (num5 >= 0) ? ((float)num5) : (Utilities.RandomValue + (float)mainSpec.Length);
			}))
			{
				int num4 = Mathf.Min(num, _pointDist[Mathf.Min(num3, _pointDist.Length - 1)]);
				AddSpecialization((EmployeeRole)item, item2, false, true, Mathf.Min(num4, num2));
				num2 -= num4;
				num3++;
				if (num2 <= 0)
				{
					break;
				}
			}
			num--;
			if (num <= 0)
			{
				break;
			}
		}
	}

	private void ChoosePersonality(PersonalityGraph p)
	{
		PersonalityTraits = new string[PersonalityNum];
		for (int i = 0; i < PersonalityNum; i++)
		{
			PersonalityTraits[i] = p.SelectRandom(PersonalityTraits);
		}
	}

	public RoleBit GetBestRoles(bool lead, float cutoff)
	{
		float num = 0f;
		for (int i = ((!lead) ? 1 : 0); i < Skill.Length; i++)
		{
			if (Skill[i] > num)
			{
				num = Skill[i];
			}
		}
		RoleBit roleBit = RoleBit.None;
		float num2 = num * cutoff;
		for (int j = ((!lead) ? 1 : 0); j < Skill.Length; j++)
		{
			if (Mathf.Approximately(Skill[j], num2) || Skill[j] >= num2)
			{
				roleBit |= RoleToMask[j];
			}
		}
		return roleBit;
	}

	private void ChoosePersonality(Team team, float leaderskill, PersonalityGraph p)
	{
		List<Actor> emp = team.GetEmployeesDirect();
		if (emp.Count == 0 || leaderskill < 0.25f)
		{
			ChoosePersonality(p);
			return;
		}
		PersonalityTraits = new string[PersonalityNum];
		int num = 0;
		HashSet<string> hashSet = new HashSet<string>();
		foreach (string item in GameSettings.Instance.Personalities.PersonalityTraits.OrderByDescending((string x) => emp.Count((Actor y) => y.employee.PersonalityTraits.Contains(x))))
		{
			foreach (KeyValuePair<string, float> item2 in from x in GameSettings.Instance.Personalities.GetCompatibilities(item)
				orderby x.Value descending
				select x)
			{
				if (Utilities.RandomValue >= leaderskill * 0.9f)
				{
					continue;
				}
				bool flag = true;
				hashSet.Clear();
				GameSettings.Instance.Personalities.GetIncompatibilities(item2.Key, hashSet);
				for (int num2 = 0; num2 < num; num2++)
				{
					if (hashSet.Contains(PersonalityTraits[num2]))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					PersonalityTraits[num] = item2.Key;
					num++;
					if (num == PersonalityNum || Utilities.RandomValue > 0.5f)
					{
						break;
					}
				}
			}
			if (num == PersonalityNum)
			{
				break;
			}
		}
		if (num < PersonalityNum)
		{
			ChoosePersonality(p);
		}
	}

	public Employee()
	{
	}

	public Employee(bool female, string style)
	{
		Female = female;
		Name = GameData.GenerateName(!female);
		StyleGen = ActorGenerator.Instance.GenerateStyle(Female, style, 20f);
	}

	public Employee(SDateTime currentTime, bool female, int age, string style)
	{
		Female = female;
		Hired = currentTime;
		Name = GameData.GenerateName(!female);
		BirthDate = currentTime - age * 12;
		StyleGen = ActorGenerator.Instance.GenerateStyle(Female, style, age);
	}

	public Employee(MissionGuide.CampaignCharacter character)
	{
		Female = character.Person.Female;
		Hired = character.Birthdate;
		Name = character.Name;
		BirthDate = character.Birthdate;
		StyleGen = character.Person.BodyItems;
	}

	private string GetFirstSpec(string[] specs)
	{
		if (specs == null || specs.Length == 0)
		{
			return null;
		}
		return specs[0];
	}

	public Employee(SDateTime currentTime, EmployeeRole role, bool female, WageBracket bracket, PersonalityGraph graph, string style, bool founder = false, string[] mainSpecs = null, Team team = null, float leaderSkill = 1f, float maxChance = 0.1f, Trait requireTrait = Trait.None, Trait traitFilter = Trait.None, bool HR = false, Dictionary<string, float> benefits = null)
		: this(currentTime, new EmployeeRole[1] { role }, female, bracket, graph, style, founder, mainSpecs, team, leaderSkill, maxChance, requireTrait, traitFilter, HR, benefits)
	{
	}

	public Employee(SDateTime currentTime, EmployeeRole[] roles, bool female, WageBracket bracket, PersonalityGraph graph, string style, bool founder = false, string[] mainSpecs = null, Team team = null, float leaderSkill = 1f, float maxChance = 0.1f, Trait requireTrait = Trait.None, Trait traitFilter = Trait.None, bool HR = false, Dictionary<string, float> benefits = null)
	{
		Female = female;
		LastWage = (Hired = currentTime);
		Name = GameData.GenerateName(!female);
		Founder = founder;
		CustomBenefits = ((benefits != null && benefits.Count > 0) ? benefits.ToDictionary() : CustomBenefits);
		if (team == null)
		{
			ChoosePersonality(GameSettings.Instance.Personalities);
		}
		else
		{
			ChoosePersonality(team, leaderSkill, GameSettings.Instance.Personalities);
		}
		Traits = PickTraits(PersonalityTraits, graph, requireTrait, traitFilter);
		if (founder)
		{
			Salary = 0f;
			_currentRole = RoleBit.AnyRole;
			Founder = true;
			FounderSkill();
			BirthDate = currentTime - Youngest * 12;
			SkillFact = 1f;
		}
		else
		{
			int role = (int)roles[0];
			int num = AgeFromBracket(bracket);
			BirthDate = currentTime - (num * 12 + Utilities.RandomRange(0, 11));
			float benefitScore = GetBenefitScore(team);
			Salary = GetEmployeeWorth(role, GetFirstSpec(mainSpecs), (float)(bracket + 1) / 3f, num, 0f, benefitScore);
			SkillFact = SkillFromBracket(bracket, role, maxChance, benefitScore);
			AskedFor = (Salary = WageFromSkillBracket(role, GetFirstSpec(mainSpecs), SkillFact, benefitScore) * ModTrait(Trait.Humble, 0.8f));
			ChooseSkillFrom(roles, GetAge(currentTime), SkillFact, benefitScore);
		}
		float age = GetAge(currentTime);
		Creativity = GetCreativityFor(age, roles[0]);
		CreativityKnown = GetCreativityKnownFor(age, roles[0]);
		InspirationTime = GetInspirationReloadTime(Creativity);
		InitialLeadExperience = (HR ? 0f : GetInitialExpecienceFor(age, CreativityKnown));
		RefreshDemands(true, Utilities.RNG.Next());
		if (roles[0] == EmployeeRole.Designer)
		{
			RandomizeLeadSpec(null);
		}
		InitializeSpecializations(mainSpecs, SkillFact, age);
		Demanded = Salary - Worth((int)roles[0]);
		HiredFor = roles[0];
		StyleGen = ActorGenerator.Instance.GenerateStyle(Female, style, GetAge(currentTime));
	}

	public void ReevaluateSalary(EmployeeRole[] roles, string[] mainSpecs, Team team)
	{
		AskedFor = (Salary = WageFromSkillBracket((int)roles[0], GetFirstSpec(mainSpecs), SkillFact, GetBenefitScore(team)) * ModTrait(Trait.Humble, 0.8f));
	}

	public float GetBenefitScore(Team team)
	{
		return EmployeeBenefit.GetBenefitScore(this, team);
	}

	public Employee(SDateTime currentTime, bool female, PersonalityGraph graph, SoftwareType[] focus, bool senior, string style)
	{
		Female = female;
		LastWage = (Hired = currentTime);
		Name = GameData.GenerateName(!female);
		Founder = false;
		ChoosePersonality(graph);
		Traits = PickTraits(PersonalityTraits, graph, Trait.None, Trait.None);
		int role = 2;
		int num = AgeFromBracket(WageBracket.High);
		BirthDate = currentTime - (num * 12 + Utilities.RandomRange(0, 11));
		float age = GetAge(currentTime);
		Salary = GetEmployeeWorth(role, null, 1f, num, 0f, 0f);
		float num2 = 1f;
		SkillFact = SkillFromBracket(WageBracket.High, role, 1f, num2);
		AskedFor = (Salary = WageFromSkillBracket(role, null, SkillFact, num2) * ModTrait(Trait.Humble, 0.8f));
		ChooseSkillFrom(new EmployeeRole[1] { EmployeeRole.Designer }, age, SkillFact, num2);
		PreviousEmployment = senior;
		Creativity = (senior ? Utilities.GaussRangeFloat(0.5f, 0.85f, 1f, 0.15f) : Utilities.GaussRangeFloat(0.1f, 0.6f, 1f, 0.15f));
		CreativityKnown = 1f;
		InspirationTime = GetInspirationReloadTime(Creativity);
		InitialLeadExperience = GetInitialExpecienceFor(age, CreativityKnown);
		RefreshDemands(true, Utilities.RNG.Next());
		RandomizeLeadSpec(focus);
		InitializeSpecializations(null, SkillFact, age);
		Demanded = Salary - Worth(role);
		HiredFor = EmployeeRole.Designer;
		StyleGen = ActorGenerator.Instance.GenerateStyle(Female, style, GetAge(currentTime));
	}

	public Employee(SDateTime currentTime, bool female, float salary, string style)
	{
		Female = female;
		LastWage = (Hired = currentTime);
		Name = GameData.GenerateName(!female);
		Founder = false;
		Traits = Trait.None;
		ChoosePersonality(GameSettings.Instance.Personalities);
		Demanded = (Salary = salary);
		_currentRole = RoleBit.AnyRole;
		Founder = false;
		BirthDate = currentTime - UnityEngine.Random.Range(Youngest * 12, (RetirementAge - 5) * 12);
		HiredFor = EmployeeRole.Service;
		StyleGen = ActorGenerator.Instance.GenerateStyle(Female, style, GetAge(currentTime));
	}

	public void RefreshUpfrontDemand(bool transfer)
	{
		UpfrontDemand = 0f;
		if (transfer)
		{
			return;
		}
		if (MyEmployer != null)
		{
			if (HasDemanded(LeadDesignDemands.Demand.GoldenHandshake))
			{
				UpfrontDemand = GetMonthlySalary(null) * 5f * 12f;
			}
			UpfrontDemand = (float)Math.Max(MyEmployer.Money * 0.05000000074505806, UpfrontDemand);
		}
		else if (PreviousEmployment)
		{
			UpfrontDemand = GetMonthlySalary(null) * 12f;
		}
	}

	public bool PayForDemands(Company c, bool refund = false)
	{
		bool flag = false;
		for (int i = 0; i < LeadDesignDemands.Demands.Length; i++)
		{
			LeadDesignDemands.DemandChoice demandChoice = LeadDesignDemands.Demands[i];
			if ((demandChoice.ID & DemandsMet) == 0)
			{
				break;
			}
			flag |= PayForDemand(c, demandChoice.Choice1, demandChoice.Cost1, refund) || PayForDemand(c, demandChoice.Choice2, demandChoice.Cost2, refund);
		}
		return flag;
	}

	private bool PayForDemand(Company c, LeadDesignDemands.Demand demand, float cost, bool refund)
	{
		if ((DemandResults & demand) > LeadDesignDemands.Demand.Fire && cost > 0f)
		{
			c.MakeTransaction(refund ? (cost * 0.75f) : (0f - cost), Company.TransactionCategory.Benefits, false, "LeadDemand" + demand);
			if (refund)
			{
				c.AddTax(TaxReport.TaxType.Depreciation, (0f - cost) * 0.25f);
			}
			return true;
		}
		return false;
	}

	public float GetDemandPrices(bool transfer)
	{
		float num = 0f;
		if (!transfer)
		{
			for (int i = 0; i < LeadDesignDemands.Demands.Length; i++)
			{
				LeadDesignDemands.DemandChoice demandChoice = LeadDesignDemands.Demands[i];
				if ((demandChoice.ID & DemandsMet) == 0)
				{
					break;
				}
				if ((DemandResults & demandChoice.Choice1) > LeadDesignDemands.Demand.Fire && demandChoice.Cost1 > 0f)
				{
					num += demandChoice.Cost1;
				}
				else if ((DemandResults & demandChoice.Choice2) > LeadDesignDemands.Demand.Fire && demandChoice.Cost2 > 0f)
				{
					num += demandChoice.Cost2;
				}
			}
		}
		return num;
	}

	public float GetUpfrontCost(bool transfer)
	{
		return UpfrontDemand + GetDemandPrices(transfer);
	}

	public void Employ(Company c, SDateTime time, bool transfer, bool useOffshore = false)
	{
		MarketSimulation.Active.FreeLeads.Remove(this);
		MyEmployer = c;
		Dismissed = false;
		bool flag = false;
		if (UpfrontDemand > 0f)
		{
			if (useOffshore)
			{
				GameSettings.Instance.OffshoreAccount -= UpfrontDemand;
				GameSettings.Instance.AddHeat(0.1f, true);
			}
			else
			{
				c.MakeTransaction(0f - UpfrontDemand, Company.TransactionCategory.Hire, true);
			}
			flag = true;
		}
		UpfrontDemand = 0f;
		if (!transfer)
		{
			flag |= PayForDemands(c);
		}
		if (flag && c.IsLocalPlayer)
		{
			UISoundFX.PlaySFX("Kaching");
		}
		Hired = time;
	}

	public void CleanUp()
	{
		Thoughts.Clear();
		CustomBenefits.Clear();
		Inspiration = 2f;
		JobSatisfaction = 1f;
		CoffeeQual = 0f;
		Hunger = 1f;
		HadProperFood = false;
		Energy = 1f;
		Bladder = 1f;
		UpfrontDemand = 0f;
		SatisfactionHitZero = false;
		SetRoles(RoleBit.AnyRole, RoleBit.None);
		MyActor = null;
		Filter = false;
		PreviousEmployment = true;
		Founder = false;
		LastBid = new SDateTime(0);
		DeleteFriendships(this);
	}

	public Employee(SDateTime currentTime, bool female, string name, float[] skills, float creativity, string[] person, Trait traits, Dictionary<string, int>[] specs, PersonalityGraph graph, ActorBodyItem.BodyItemObject[] style, EmployeeRole? forceBrain, int age = -1)
	{
		Female = female;
		LastWage = (Hired = currentTime);
		Name = name;
		Salary = 0f;
		_currentRole = RoleBit.AnyRole;
		if (forceBrain.HasValue)
		{
			HiredFor = forceBrain.Value;
		}
		else
		{
			int hiredFor = 0;
			float num = 0f;
			for (int i = 0; i < 5; i++)
			{
				if (skills[i] > num)
				{
					hiredFor = i;
					num = skills[i];
				}
			}
			HiredFor = (EmployeeRole)hiredFor;
		}
		Founder = true;
		Skill = skills;
		PersonalityTraits = person;
		BirthDate = new SDateTime(0, 0, 0, 0, currentTime.Year - ((age < 0) ? Youngest : age));
		Traits = traits;
		SpecializationLevels = specs;
		Creativity = creativity;
		CreativityKnown = 1f;
		InspirationTime = GetInspirationReloadTime(Creativity);
		for (int j = 0; j < SpecializationLevels.Length; j++)
		{
			SpecUsed[j] = SpecializationLevels[j].SumSafe((KeyValuePair<string, int> x) => x.Value);
		}
		StyleGen = style;
	}

	public static int GoodBadNeutral(Trait t)
	{
		if ((Trait.NightOwl | Trait.BornLeader | Trait.FirmwareInc | Trait.SuperFocus | Trait.Unphased | Trait.JustTheFlu | Trait.Detached | Trait.Watch | Trait.FriendMaker).HasBits(t))
		{
			return 1;
		}
		if ((Trait.Stressed | Trait.Hypochondriac | Trait.SlowEater | Trait.NervousBladder | Trait.BumLeg | Trait.Forgetful | Trait.Cupholder | Trait.NeatFreak | Trait.SilentButDeadly | Trait.WalkInstead | Trait.UnderTheWeather | Trait.Claustrophobic).HasBits(t))
		{
			return 2;
		}
		return 0;
	}

	public static void IncTraitType(int traitType, ref int good, ref int neutral, ref int bad)
	{
		switch (traitType)
		{
		case 0:
			good++;
			break;
		case 1:
			neutral++;
			break;
		case 2:
			bad++;
			break;
		}
	}

	public static Trait PickTraits(string[] personality, PersonalityGraph graph, Trait require, Trait filter)
	{
		int good = 0;
		int bad = 0;
		int neutral = 0;
		Trait trait = Trait.None;
		if (require != Trait.None)
		{
			trait = require;
			IncTraitType(GoodBadNeutral(trait), ref good, ref neutral, ref bad);
		}
		Trait traitFromPerson = GetTraitFromPerson(graph.Traits[personality[0]], trait, filter, good, neutral, bad);
		if (traitFromPerson != Trait.None)
		{
			trait |= traitFromPerson;
			IncTraitType(GoodBadNeutral(traitFromPerson), ref good, ref neutral, ref bad);
		}
		traitFromPerson = GetTraitFromPerson(graph.Traits[personality[1]], trait, filter, good, neutral, bad);
		if (traitFromPerson != Trait.None)
		{
			trait |= traitFromPerson;
			IncTraitType(GoodBadNeutral(traitFromPerson), ref good, ref neutral, ref bad);
		}
		if (neutral > 0)
		{
			if (good == 0)
			{
				trait |= PickRandomTrait((Trait.FastLearner | Trait.Independant | Trait.BigBrain | Trait.Humble | Trait.Capacitor | Trait.WalkItOff | Trait.ThisIsFine | Trait.Sunshine | Trait.Skyscraper | Trait.RGBThumb | Trait.Clean) & ~trait & ~filter);
			}
			if (bad == 0)
			{
				trait |= PickRandomTrait((Trait.Stressed | Trait.Hypochondriac | Trait.SlowEater | Trait.NervousBladder | Trait.BumLeg | Trait.Forgetful | Trait.Cupholder | Trait.NeatFreak | Trait.SilentButDeadly | Trait.WalkInstead | Trait.UnderTheWeather | Trait.Claustrophobic) & ~trait & ~filter);
			}
		}
		else
		{
			int num = 2 - good;
			for (int i = 0; i < num; i++)
			{
				trait |= PickRandomTrait((Trait.FastLearner | Trait.Independant | Trait.BigBrain | Trait.Humble | Trait.Capacitor | Trait.WalkItOff | Trait.ThisIsFine | Trait.Sunshine | Trait.Skyscraper | Trait.RGBThumb | Trait.Clean) & ~trait & ~filter);
			}
			num = 2 - bad;
			for (int j = 0; j < num; j++)
			{
				trait |= PickRandomTrait((Trait.Stressed | Trait.Hypochondriac | Trait.SlowEater | Trait.NervousBladder | Trait.BumLeg | Trait.Forgetful | Trait.Cupholder | Trait.NeatFreak | Trait.SilentButDeadly | Trait.WalkInstead | Trait.UnderTheWeather | Trait.Claustrophobic) & ~trait & ~filter);
			}
		}
		return trait;
	}

	public static Trait PickRandomTrait(Trait pool)
	{
		return (Trait)Utilities.GetRandomBit((ulong)pool);
	}

	private static Trait GetTraitFromPerson(Trait[] traits, Trait result, Trait filter, int good, int neutral, int bad)
	{
		if (traits.Length == 1)
		{
			if (neutral == 0 && !filter.HasBits(traits[0]) && good < 2 && bad < 2)
			{
				return traits[0];
			}
		}
		else
		{
			int num = ((good > 0) ? 1 : ((bad <= 0) ? Utilities.RandomRange(0, 2) : 0));
			if (result.HasBits(traits[num]) || filter.HasBits(traits[num]) || (neutral > 0 && ((num == 0 && good > 0) || (num == 1 && bad > 0))))
			{
				num = 1 - num;
			}
			int num2 = 2 - neutral;
			if (!result.HasBits(traits[num]) && !filter.HasBits(traits[num]) && ((num == 0 && good < num2) || (num == 1 && bad < num2)))
			{
				return traits[num];
			}
		}
		return Trait.None;
	}

	public void FounderSkill()
	{
		for (int i = 0; i < 5; i++)
		{
			Skill[i] = SkillCeiling;
		}
	}

	private void ChooseSkillFrom(EmployeeRole[] roles, float age, float skill, float benefit)
	{
		skill *= age.MapRange(20f, 35f, 0.25f, 1f, true);
		List<int> list = new List<int> { 0, 1, 2, 3, 4 };
		for (int i = 0; i < roles.Length; i++)
		{
			list.Remove((int)roles[i]);
		}
		list.Shuffle();
		for (int j = 0; j < roles.Length; j++)
		{
			list.Insert(j, (int)roles[j]);
		}
		float num = Mathf.Clamp01(benefit);
		float b = skill;
		b = Mathf.Max(0.05f, b);
		float num2 = age.MapRange(Youngest, RetirementAge, 4f, 2f, true);
		for (int k = 0; k < list.Count; k++)
		{
			Skill[list[k]] = Mathf.Clamp01(b * Utilities.RandomGaussClamped(1f, 0.05f + (1f - num) * 0.1f));
			if (k == 0)
			{
				Skill[list[k]] = Skill[list[k]].MapRange(0f, 1f, LowSkillCap[(int)roles[0]], 1f);
			}
			b /= Utilities.RandomRange(num2 - 1f, num2 + 1f);
		}
	}

	public EmployeeRole GetRoleOrNatural(bool lead = true, bool onlySoftware = false)
	{
		if ((!lead && HiredFor == EmployeeRole.Lead) || (onlySoftware && (HiredFor < EmployeeRole.Programmer || HiredFor > EmployeeRole.Artist)))
		{
			return NaturalRole(lead, onlySoftware, true);
		}
		return HiredFor;
	}

	public EmployeeRole NaturalRole(bool lead = true, bool onlySoftware = false, bool onlyActive = false)
	{
		int result = 1;
		float num = 0f;
		for (int i = ((!lead) ? 1 : 0); i < 5; i++)
		{
			if ((!onlyActive || IsRole(RoleToBit[i])) && (!onlySoftware || (i >= 1 && i <= 3)) && Skill[i] > num)
			{
				result = i;
				num = Skill[i];
			}
		}
		return (EmployeeRole)result;
	}

	public void ChangeToNaturalRole(bool lead = true)
	{
		_currentRole = RoleToMask[(int)NaturalRole(lead)];
	}

	public RoleBit BestRoles()
	{
		float num = 0f;
		for (int i = 1; i < 5; i++)
		{
			num = Mathf.Max(num, GetSkillI(i));
		}
		int num2 = 0;
		for (int num3 = 4; num3 >= 1; num3--)
		{
			if (GetSkillI(num3) > num * 0.8f)
			{
				num2 |= 1;
			}
			num2 <<= 1;
		}
		return (RoleBit)num2;
	}

	public float Worth(int role = -1, bool withDemands = true, bool asLeadDesigner = true)
	{
		bool flag = false;
		if (role == -1)
		{
			role = (int)NaturalRole(true, false, true);
		}
		if (role == -2)
		{
			flag = true;
			role = (int)NaturalRole();
		}
		SDateTime sDateTime = SDateTime.Now();
		int role2 = role;
		string maxSpec = GetMaxSpec(role);
		float skill = Skill[role];
		float age = GetAge(sDateTime);
		float seniority = SDateTime.GetMonths(Hired, sDateTime) / 12f;
		Actor myActor = MyActor;
		float num = GetEmployeeWorth(role2, maxSpec, skill, age, seniority, GetBenefitScore(((object)myActor != null) ? myActor.GetTeam() : null)) * ModTrait(Trait.Humble, 0.8f);
		if (asLeadDesigner)
		{
			float lastDemandScore = LastDemandScore;
			lastDemandScore *= Mathf.Pow(Creativity.MapRange(0.5f, 1f, 0f, 1f, true), 2f);
			num *= lastDemandScore.MapRange(0f, 1f, 1f, PreviousEmployment ? 6 : 4, true);
		}
		if (withDemands)
		{
			num += Demanded;
		}
		if (!flag)
		{
			return num;
		}
		return Mathf.Max(Salary, num);
	}

	public static string CheckSeniority(int role, string spec, float skill)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = Youngest; i <= RetirementAge; i += 5)
		{
			stringBuilder.AppendLine(i + ": " + GetEmployeeWorth(role, spec, skill, i, i - Youngest, 0f).Currency() + " v " + GetEmployeeWorth(role, spec, skill, i, 0f, 0f).Currency());
		}
		return stringBuilder.ToString();
	}

	public static float GetEmployeeWorth(int role, string spec, float skill, float age, float seniority, float benefitScore)
	{
		age = 1f - Mathf.Pow(1f - age / (float)RetirementAge, 2f);
		seniority = 1f - Mathf.Min(1f, seniority / 20f);
		return (SkillBase + skill * SkillFactor) * seniority.WeightOne(SeniorityWeight) * AverageWage * GetRoleSalary(role, spec) * age * benefitScore.MapRange(0f, 1f, 1f, 0.75f, true);
	}

	public static float GetMaxEmployeeWorth(int role, string spec)
	{
		return (SkillBase + SkillFactor) * AverageWage * GetRoleSalary(role, spec);
	}

	public static float SkillFromWage(int role, string spec, float wage, float age, float seniority)
	{
		age = 1f - Mathf.Pow(1f - age / (float)RetirementAge, 2f);
		seniority = Mathf.Min(1f, seniority / 10f);
		return (wage / AverageWage / GetRoleSalary(role, spec) / age / seniority.WeightOne(SeniorityWeight) - SkillBase) / SkillFactor;
	}

	public static int AgeFromBracket(WageBracket bracket)
	{
		switch (bracket)
		{
		case WageBracket.Low:
			return SubAgeBracket(0.3f, bracket);
		case WageBracket.Medium:
			return SubAgeBracket(0.5f, bracket);
		case WageBracket.High:
			return SubAgeBracket(0f, bracket);
		default:
			return 20;
		}
	}

	private static int SubAgeBracket(float mean, WageBracket bracket)
	{
		return Utilities.GaussRange(mean, AgeBrackets[(int)bracket][0], AgeBrackets[(int)bracket][1]);
	}

	public static int BracketFromAge(int age)
	{
		int num = int.MaxValue;
		int result = 0;
		for (int i = 0; i < AgeBrackets.GetLength(0); i++)
		{
			int num2 = (AgeBrackets[i][0] + AgeBrackets[i][1]) / 2;
			int num3 = Mathf.Abs(age - num2);
			if (num3 < num)
			{
				num = num3;
				result = i;
			}
		}
		return result;
	}

	public static float SkillFromBracket(WageBracket bracket, int role, float maxChance, float benefit)
	{
		float num = 0.25f;
		float num2 = (float)bracket * num;
		float num3 = num2 + num;
		float num4 = Mathf.Clamp01(benefit);
		maxChance *= num4;
		if (bracket == WageBracket.High && Utilities.RandomValue <= maxChance)
		{
			num2 += num;
			num3 += num;
		}
		return Utilities.GaussRangeFloat(0.5f + num4 * 0.25f, Mathf.Max(0.01f, num2), num3);
	}

	public static float WageFromSkillBracket(int role, string spec, float skillFact, float benefitScore)
	{
		int num = skillFact.Quantize(4);
		int num2 = Mathf.Min(2, num);
		float num3 = 0.25f;
		float employeeWorth = GetEmployeeWorth(role, spec, (float)num * num3, AgeBrackets[num2][0], 0f, benefitScore);
		float num4 = GetEmployeeWorth(role, spec, (float)num * num3 + num3, AgeBrackets[num2][1], 0f, benefitScore);
		if (num == 3)
		{
			num4 *= 1.25f;
		}
		float t = (skillFact - num3 * (float)num) / num3;
		return Mathf.Lerp(employeeWorth, num4, t);
	}

	public WageBracket GetWageBracket()
	{
		float maxEmployeeWorth = GetMaxEmployeeWorth((int)HiredFor, (HiredFor == EmployeeRole.Service) ? SpecializationLevels[(int)HiredFor].MaxInstance((KeyValuePair<string, int> x) => x.Value).Key : null);
		int b = (Salary / maxEmployeeWorth).Quantize(4);
		return (WageBracket)Mathf.Min(2, b);
	}

	public void RefreshSalary()
	{
		Salary = Worth();
		RefreshUpfrontDemand(false);
	}

	public void ChangeSalary(float newSalary, float askedFor, Actor act, bool negotiation)
	{
		if (!newSalary.IsValidFloat())
		{
			Debug.LogException(new UnityException(string.Format("Tried to change employee({0}) salary to invalid number, wanted: {1}", FullName, askedFor.Currency())));
			return;
		}
		LastWage = SDateTime.Now();
		AskedFor = (negotiation ? askedFor : Mathf.Max(askedFor, AskedFor));
		if (newSalary < askedFor)
		{
			if (newSalary < Salary - 1f)
			{
				AddInstantMood("SalaryCutComplaint", act, askedFor / newSalary - 1f);
			}
			else
			{
				AddInstantMood("LowerSalaryComplaint", act, 0.5f * (askedFor / newSalary - 1f) / (Salary / Worth(-1, false)));
			}
		}
		else if (newSalary > Salary)
		{
			AddInstantMood("HigherSalary", act, newSalary / Salary - 1f);
		}
		if (negotiation && newSalary > AskedFor)
		{
			Demanded += newSalary - AskedFor;
		}
		Salary = newSalary;
	}

	public void Spawn()
	{
		LowestSatisfaction = -1f;
		CoffeeQual = 0f;
		Hunger = (Founder ? 1f : (HadProperFood ? 0.55f : Utilities.RandomRange(0.2f, 1f)));
		HadProperFood = false;
		Energy = 1f;
		Bladder = (Founder ? 1f : Utilities.RandomRange(0.25f, 1f));
		InteractedWithBestFriend = false;
	}

	public void ChangeSkill(EmployeeRole role, float perDay, bool perday)
	{
		perDay *= ModTrait(Trait.FastLearner, 2f) * DifficultyValues.Difficulty.EmployeeSkillGainBonus;
		if (perday)
		{
			perDay = Utilities.PerDay(perDay);
		}
		Skill[(int)role] = Mathf.Clamp(Skill[(int)role] + perDay, 0f, SkillCeiling);
		AddSpecExperience(role, 10f * perDay * GetAge().MapRange(Youngest, RetirementAge, 1f, 0.5f));
	}

	public void ChangeSkillDirect(EmployeeRole role, float value)
	{
		Skill[(int)role] = Mathf.Clamp(value, 0f, SkillCeiling);
	}

	private float ScaleToOne(float val, float start)
	{
		return 1f - val / start;
	}

	public void Update(float delta, bool forFree, bool goingHome, bool disableNeeds, Status simBladder, Status simHunger, float stressFactor, float socialFactor, float needFactor, bool canStressOut, Actor act)
	{
		float num = Utilities.RandomGaussClamped() + 0.5f;
		float num2 = _coffeeDrain.Evaluate(CoffeeQual / 3f);
		Energy = Mathf.Max(0f, Energy - num2 * delta * EnergyDrain * num);
		if (Stress > 0f || canStressOut)
		{
			Stress = Mathf.Clamp01(Stress - delta * StressDrain * stressFactor * num);
		}
		if (Founder)
		{
			return;
		}
		if (!disableNeeds)
		{
			if (simHunger == Status.Enable)
			{
				Hunger = Mathf.Max(0f, Hunger - delta * HungerDrain * needFactor);
			}
			if (simBladder == Status.Enable)
			{
				Bladder = Mathf.Max(0f, Bladder - delta * BladderDrain * needFactor * num * ModTrait(Trait.NervousBladder, 3f));
			}
		}
		Social = Mathf.Clamp01(Social - delta * SocialDrain * socialFactor * num);
		if (Stress <= 0.5f)
		{
			AddMood("StressProblem", act, delta, ScaleToOne(Stress, 0.5f), false);
		}
		if (Social <= 0.5f)
		{
			AddMood("SocialProblem", act, delta, ScaleToOne(Social, 0.5f), false);
		}
		if (!HasTrait(Trait.WalkItOff))
		{
			if (Hunger <= 0.1f && simHunger != Status.Disable)
			{
				AddMood("Starving", act, delta, (disableNeeds || simHunger == Status.Freeze) ? 0f : ScaleToOne(Hunger, 0.1f), false, false);
			}
			if (Bladder <= 0.1f && simBladder != Status.Disable)
			{
				AddMood("HasToPee", act, delta, (disableNeeds || simBladder == Status.Freeze) ? 0f : ScaleToOne(Bladder, 0.1f), false, false);
			}
			float num3 = ModTrait(Trait.Capacitor, 0.01f, 0.1f);
			if (Energy <= num3 && !goingHome)
			{
				AddMood("WornOut", act, delta, ScaleToOne(Energy, num3), false, false);
			}
		}
		if (HasDemanded(LeadDesignDemands.Demand.LuxuryMeal) && Hunger < 0.1f && simHunger != Status.Disable)
		{
			SetMood("LeadDemandBreach", act, 1f);
		}
		if (!forFree && AskedFor > 0f)
		{
			if (Salary > AskedFor * 1.1f)
			{
				SetMood("GoodSalary", act, (Salary / AskedFor - 1f) * 0.5f);
			}
			else if (Salary < AskedFor * 0.9f)
			{
				SetMood("BadSalary", act, AskedFor / Salary - 1f);
			}
		}
		float months = SDateTime.GetMonths(Hired, SDateTime.Now());
		if (months > 12f)
		{
			SetMood("TiredOfJob", act, (months - 12f) / 12f * 0.02f);
		}
		if (Posture < 0.5f)
		{
			SetMood("BackAche", act, (1f - Posture * 2f) * 0.25f);
		}
		else
		{
			SetMood("BackAche", act, 0f);
		}
		if (LastDemandScore > 0.5f)
		{
			float months2 = SDateTime.GetMonths((LastInpirationUse > Hired) ? LastInpirationUse : Hired, SDateTime.Now());
			SetMood("LeadWastedTalent", act, (months2 > 6f) ? months2.MapRange(6f, 24f, 0.05f, 0.25f, true) : 0f);
		}
	}

	public void UpdateEmployeeMood(float delta, Actor act)
	{
		if (!ActiveComplaint)
		{
			UpdateMood(delta, act);
		}
	}

	private static float WeightTiredFactor(float factor, float weight)
	{
		return weight * factor - weight + 2f;
	}

	public override string ToString()
	{
		return FullName;
	}

	public string GetActualString()
	{
		return FullName;
	}

	public float GetBenefitValue(string benefit, Team team)
	{
		return EmployeeBenefit.GetBenefitValue(this, team, benefit);
	}

	public float GetMonthlySalary(Team team)
	{
		return (float)((HasDemanded(LeadDesignDemands.Demand.FixedRate) || team == null) ? 8 : team.WorkHours) * Salary;
	}

	public float GetCohesion(Team t)
	{
		if (t == null)
		{
			return 0f;
		}
		List<Actor> employeesDirect = t.GetEmployeesDirect();
		float num = 0f;
		int num2 = 0;
		for (int i = 0; i < employeesDirect.Count; i++)
		{
			Actor actor = employeesDirect[i];
			if (actor.employee != this)
			{
				num += Mathf.Min(1f, GetFriendship(this, actor.employee));
				num2++;
			}
		}
		if (num2 == 0)
		{
			return 0f;
		}
		return num / (float)num2;
	}

	public string GetExpression()
	{
		string value;
		if (GameSettings.Instance.Personalities.Expressions.TryGetValue(PersonalityTraits[0], out value))
		{
			return value;
		}
		if (!GameSettings.Instance.Personalities.Expressions.TryGetValue(PersonalityTraits[1], out value))
		{
			return null;
		}
		return value;
	}
}
