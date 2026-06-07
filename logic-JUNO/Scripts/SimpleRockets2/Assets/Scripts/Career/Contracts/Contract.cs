using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Career.Contracts.Requirements;
using Assets.Scripts.Career.Contracts.Requirements.Tutorial;
using Assets.Scripts.State;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts
{
	public class Contract
	{
		public const string ElementName = "Contract";

		private const double DayToSeconds = 86400.0;

		private static Dictionary<string, Func<XElement, Contract, ContractRequirement>> _requirementFactory;

		private float _difficulty;

		private List<ContractRequirement> _requirements = new List<ContractRequirement>();

		private EmptyRequirement _rootRequirement;

		private XElement _xml;

		public long CancelCost { get; private set; }

		public bool CanReject { get; }

		public IContractContext Context { get; }

		public int ContractNumber { get; set; }

		public Customer Customer { get; set; }

		public int DeadlineLength { get; private set; }

		public string Description { get; set; }

		public string DescriptionShort { get; set; }

		public string DesignerTutorialId { get; }

		public float Difficulty => _difficulty;

		public string DifficultyLabel
		{
			get
			{
				if (_difficulty < 2f)
				{
					return "Easy";
				}
				if (_difficulty >= 3f)
				{
					return "Hard";
				}
				return "Medium";
			}
		}

		public int ExpirationLength { get; }

		public string FlairText { get; }

		public string Id { get; }

		public bool IsActive
		{
			get
			{
				if (Status != ContractStatus.Active)
				{
					return Status == ContractStatus.Failed;
				}
				return true;
			}
		}

		public bool IsClosed
		{
			get
			{
				if (Status != ContractStatus.Complete)
				{
					return Status == ContractStatus.Terminated;
				}
				return true;
			}
		}

		public bool IsComplete => Status == ContractStatus.Complete;

		public int MaxInstances { get; set; }

		public string Name { get; set; }

		public int Priority { get; private set; }

		public double Probability { get; }

		public IReadOnlyList<ContractRequirement> Requirements => _requirements;

		public bool RequiresReset { get; set; }

		public long RewardCrewMoney { get; private set; }

		public int RewardCrewResearch { get; private set; }

		public long RewardMoney { get; private set; }

		public long RewardMoneyAdvance { get; private set; }

		public int RewardResearchPoints { get; private set; }

		public ContractStatus Status { get; set; } = ContractStatus.Generated;

		public string Subtitle { get; private set; }

		public double? TimeAccepted { get; set; }

		public double TimeGenerated { get; set; }

		public List<string> UnlockLocations { get; private set; } = new List<string>();

		static Contract()
		{
			_requirementFactory = new Dictionary<string, Func<XElement, Contract, ContractRequirement>>();
			_requirementFactory["Any"] = (XElement xml, Contract c) => new AnyRequirement(xml, c);
			_requirementFactory["Bypass"] = (XElement xml, Contract c) => new BypassRequirement(xml, c);
			_requirementFactory["CraftEvent"] = (XElement xml, Contract c) => new CraftEventRequirement(xml, c);
			_requirementFactory["CraftExpression"] = (XElement xml, Contract c) => new CraftExpressionRequirement(xml, c);
			_requirementFactory["Empty"] = (XElement xml, Contract c) => new EmptyRequirement(xml, c);
			_requirementFactory["Expression"] = (XElement xml, Contract c) => new ExpressionRequirement(xml, c);
			_requirementFactory["Fuel"] = (XElement xml, Contract c) => new FuelRequirement(xml, c);
			_requirementFactory["Location"] = (XElement xml, Contract c) => new LocationRequirement(xml, c);
			_requirementFactory["Orbit"] = (XElement xml, Contract c) => new OrbitRequirement(xml, c);
			_requirementFactory["PartCount"] = (XElement xml, Contract c) => new PartCountRequirement(xml, c);
			_requirementFactory["Payload"] = (XElement xml, Contract c) => new PayloadRequirement(xml, c);
			_requirementFactory["PayloadDetached"] = (XElement xml, Contract c) => new PayloadDetachedRequirement(xml, c);
			_requirementFactory["Planet"] = (XElement xml, Contract c) => new PlanetRequirement(xml, c);
			_requirementFactory["Race"] = (XElement xml, Contract c) => new RaceRequirement(xml, c);
			_requirementFactory["SpawnCraft"] = (XElement xml, Contract c) => new SpawnCraftRequirement(xml, c);
			_requirementFactory["SurfaceDistance"] = (XElement xml, Contract c) => new SurfaceDistanceRequirement(xml, c);
			_requirementFactory["Timer"] = (XElement xml, Contract c) => new TimerRequirement(xml, c);
			_requirementFactory["TrackedLaunch"] = (XElement xml, Contract c) => new TrackedLaunchRequirement(xml, c);
			_requirementFactory["TrackSpawnedCraft"] = (XElement xml, Contract c) => new TrackSpawnedCraftRequirement(xml, c);
			_requirementFactory["SpawnedCraftDistance"] = (XElement xml, Contract c) => new SpawnedCraftDistanceRequirement(xml, c);
			_requirementFactory["Tutorial"] = (XElement xml, Contract c) => new TutorialStepRequirement(xml, c);
			_requirementFactory["StepText"] = (XElement xml, Contract c) => new StepTextRequirement(xml, c);
			_requirementFactory["Controls"] = (XElement xml, Contract c) => new ControlsRequirement(xml, c);
			_requirementFactory["Pause"] = (XElement xml, Contract c) => new PauseRequirement(xml, c);
			_requirementFactory["Button"] = (XElement xml, Contract c) => new ButtonRequirement(xml, c);
		}

		public Contract(XElement xml, IContractContext context)
		{
			Context = context;
			_xml = new XElement(xml);
			ContractNumber = _xml.GetIntAttribute("number");
			Id = _xml.GetStringAttribute("id");
			string stringAttribute = _xml.GetStringAttribute("customer");
			Customer = context.GetCustomer(stringAttribute);
			Name = _xml.GetStringAttribute("name")?.Trim();
			Subtitle = _xml.GetStringAttribute("subtitle");
			MaxInstances = (int)_xml.GetFloatAttribute("maxInstances", 1f);
			Priority = (int)_xml.GetFloatAttribute("priority");
			Probability = Math.Max(0.0, _xml.GetDoubleAttribute("probability", 1.0));
			DesignerTutorialId = _xml.GetStringAttribute("designerTutorial");
			CanReject = _xml.GetBoolAttribute("canReject", defaultValue: true);
			FlairText = _xml.GetStringAttribute("flairText");
			long num = (long)_xml.GetFloatAttribute("money");
			double num2 = Mathd.Clamp01(_xml.GetDoubleAttribute("moneyAdvance", 0.2));
			double num3 = Mathd.Clamp01(_xml.GetDoubleAttribute("cancelPenalty", 0.3));
			RewardMoneyAdvance = (long)((double)num * num2);
			RewardMoney = num - RewardMoneyAdvance;
			CancelCost = (long)((double)num * num3);
			RewardResearchPoints = (int)_xml.GetFloatAttribute("research");
			RewardCrewMoney = (int)_xml.GetFloatAttribute("crewMoney");
			RewardCrewResearch = (int)_xml.GetFloatAttribute("crewResearch");
			_difficulty = _xml.GetFloatAttribute("difficulty", 2f);
			string stringAttribute2 = _xml.GetStringAttribute("unlockLocations");
			if (!string.IsNullOrWhiteSpace(stringAttribute2))
			{
				UnlockLocations.AddRange(stringAttribute2.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries));
			}
			ExpirationLength = (int)_xml.GetFloatAttribute("expiration");
			DeadlineLength = (int)_xml.GetFloatAttribute("deadline");
			GetDescription(context);
			if (string.IsNullOrWhiteSpace(DescriptionShort))
			{
				DescriptionShort = Description;
			}
			_rootRequirement = new EmptyRequirement(_xml.Element("Requirements"), this);
			XElement xElement = _xml.Element("Status");
			Status = xElement?.GetEnumAttributeOrNull<ContractStatus>("status") ?? ContractStatus.Generated;
			TimeAccepted = xElement?.GetDoubleAttributeOrNull("accepted");
			TimeGenerated = xElement?.GetDoubleAttribute("generated") ?? 0.0;
			_requirements = OrderRequirements(_rootRequirement.Children, new List<ContractRequirement>());
			for (int i = 0; i < _requirements.Count; i++)
			{
				ContractRequirement contractRequirement = _requirements[i];
				contractRequirement.OnRequirementsCreated();
				contractRequirement.AnalyticsId = i;
			}
		}

		public string CanWarp()
		{
			foreach (ContractRequirement requirement in _requirements)
			{
				if (requirement.IsActive)
				{
					string text = requirement.CanWarp();
					if (text != null)
					{
						return text;
					}
				}
			}
			return null;
		}

		public void CloseContract(FlightStateData flightStateData)
		{
			foreach (ContractRequirement requirement in Requirements)
			{
				requirement.OnContractClosed(flightStateData);
			}
		}

		public ContractRequirement CreateRequirement(XElement xml)
		{
			string localName = xml.Name.LocalName;
			if (_requirementFactory.TryGetValue(localName, out var value))
			{
				ContractRequirement contractRequirement = value(xml, this);
				if (contractRequirement.Id == null || GetRequirementById(contractRequirement.Id) == null)
				{
					_requirements.Add(contractRequirement);
					return contractRequirement;
				}
				throw new ContractException("Cannot use ID '" + contractRequirement.Id + "' because it's already being used by another requirement.");
			}
			throw new ArgumentException("Requirement type " + localName + " does not exist.");
		}

		public XElement GenerateXml()
		{
			XElement xml = _xml;
			xml.SetAttributeValue("number", ContractNumber);
			xml.Element("Status")?.Remove();
			XElement xElement = new XElement("Status");
			xml.AddFirst(xElement);
			xElement.SetAttributeValue("status", Status);
			xElement.SetAttributeValue("accepted", TimeAccepted);
			xElement.SetAttributeValue("generated", TimeGenerated);
			foreach (ContractRequirement requirement in Requirements)
			{
				requirement.SaveStatusToXml();
			}
			return xml;
		}

		public string GetContractNumberText()
		{
			if (MaxInstances <= 1)
			{
				return string.Empty;
			}
			return $"#{ContractNumber}";
		}

		public double GetDaysUntilDeadline(double currentTime)
		{
			return ((TimeAccepted ?? currentTime) + (double)DeadlineLength * 86400.0 - currentTime) / 86400.0;
		}

		public double GetDaysUntilExpiration(double currentTime)
		{
			return (TimeGenerated + (double)ExpirationLength * 86400.0 - currentTime) / 86400.0;
		}

		public ContractRequirement GetRequirementById(string id)
		{
			return _requirements.Where((ContractRequirement x) => x.Id == id).FirstOrDefault();
		}

		public void OnFlightEnd()
		{
			_rootRequirement.OnFlightEnd();
		}

		public void OnFlightStart(IFlightContext flightContext)
		{
			_rootRequirement.OnFlightStart(flightContext);
		}

		public void OnFlightUpdate(IFlightContext flightContext)
		{
			if (Status != ContractStatus.Active)
			{
				return;
			}
			if (DeadlineLength > 0 && GetDaysUntilDeadline(flightContext.Time) <= 0.0)
			{
				Status = ContractStatus.Terminated;
				return;
			}
			_rootRequirement.OnFlightUpdate(flightContext.CraftNode, parentsPassing: true);
			if (_rootRequirement.Status == RequirementStatus.Complete)
			{
				Status = ContractStatus.Complete;
			}
		}

		public void OnTheFlyUpdateFromTargetContract(Contract target)
		{
			Name = target.Name;
			Subtitle = target.Subtitle;
			DescriptionShort = target.DescriptionShort;
			Description = target.Description;
			DeadlineLength = target.DeadlineLength;
			RewardMoney = target.RewardMoney;
			RewardMoneyAdvance = target.RewardMoneyAdvance;
			RewardResearchPoints = target.RewardResearchPoints;
			RewardCrewMoney = target.RewardCrewMoney;
			RewardCrewResearch = target.RewardCrewResearch;
			UnlockLocations = target.UnlockLocations;
			if (Requirements.Count != target.Requirements.Count)
			{
				return;
			}
			for (int i = 0; i < target.Requirements.Count; i++)
			{
				if (Requirements[i].GetType().FullName == target.Requirements[i].GetType().FullName)
				{
					Requirements[i].OnTheFlyUpdateFromTargetRequirement(target.Requirements[i]);
				}
				else
				{
					Debug.LogError($"Could not update requirement #{i} of type {Requirements[i].GetType().Name} because it does not match the target type.");
				}
			}
		}

		public void ResetStatus()
		{
			Debug.Log("Resetting Contract '" + Id + "'");
			RequiresReset = false;
			_rootRequirement.ResetRequirementStatusRecursive();
			Status = ContractStatus.Active;
		}

		public ValidationResult Validate()
		{
			ValidationResult result = new ValidationResult();
			foreach (ContractRequirement requirement in Requirements)
			{
				requirement.Validate(result);
			}
			return result;
		}

		private static List<ContractRequirement> OrderRequirements(IEnumerable<ContractRequirement> requirements, List<ContractRequirement> orderedList)
		{
			foreach (ContractRequirement requirement in requirements)
			{
				orderedList.Add(requirement);
				OrderRequirements(requirement.Children, orderedList);
			}
			return orderedList;
		}

		private void GetDescription(IContractContext context)
		{
			int numberOfCompletions = context.GetNumberOfCompletions(Id);
			foreach (XElement item in _xml.Elements("Description"))
			{
				int intAttribute = item.GetIntAttribute("completions");
				if (intAttribute == 0 || intAttribute == numberOfCompletions)
				{
					Description = item.GetStringAttribute("long");
					DescriptionShort = item.GetStringAttribute("short");
				}
			}
		}
	}
}
