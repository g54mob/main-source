using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Career;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Career.Exploration;
using Assets.Scripts.Career.Milestones;
using Assets.Scripts.Career.Research;
using Assets.Scripts.Flight;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers;
using ModApi.Flight.UI;
using ModApi.GameLoop;
using ModApi.Math;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.State
{
	public class CareerState : ICareerState
	{
		public delegate void MoneyDelegate(long money);

		public const string StockCareerPath = "Default";

		public const string XmlElementName = "Career";

		private List<string> _customersMet = new List<string>();

		private bool _debugMode;

		private FlightContext _flightContext;

		private XElement _flightContextXml;

		private GameState _gameState;

		public static bool IsDebugMode
		{
			get
			{
				if (!Application.isEditor)
				{
					CareerState career = Game.Instance.GameState.Career;
					if (career == null || !career._debugMode)
					{
						return false;
					}
				}
				return UnityEngine.Input.GetKey(KeyCode.LeftShift);
			}
		}

		public ContractContext Contracts { get; }

		public ExplorationContext Exploration { get; }

		public bool IsStock { get; }

		public MilestoneContext Milestones { get; private set; }

		public long Money { get; private set; }

		public long MoneyReceived { get; private set; }

		public long MoneyRecovered { get; private set; }

		public long MoneySpent { get; private set; }

		public int NumCraftsRecovered { get; private set; }

		public string Path { get; private set; }

		public string ResourcesAbsolutePath => System.IO.Path.Combine(Game.PersistentDataPath, "Career/", Path);

		public TechTree TechTree { get; private set; }

		public List<string> UnlockedLocations { get; private set; } = new List<string>();

		private static string ResourcesAbsoluteDefaultPath => System.IO.Path.Combine(Game.PersistentDataPath, "Career/", "Default");

		public event MoneyDelegate OnMoneyReceived;

		public event MoneyDelegate OnMoneyRecovered;

		public event MoneyDelegate OnMoneySpent;

		public CareerState(string path, XElement xml, GameState gameState)
		{
			try
			{
				_gameState = gameState;
				Path = path;
				IsStock = path == "Default";
				string resourcesAbsolutePath = ResourcesAbsolutePath;
				if (xml != null)
				{
					Path = xml.GetStringAttribute("path");
					Money = xml.GetLongAttribute("money", 0L);
					MoneyReceived = xml.GetLongAttribute("moneyReceived", 0L);
					MoneySpent = xml.GetLongAttribute("moneySpent", 0L);
					MoneyRecovered = xml.GetLongAttribute("moneyRecovered", 0L);
					NumCraftsRecovered = xml.GetIntAttribute("numCraftsRecovered");
					_customersMet = xml.GetStringList("customersMet", new List<string>());
					UnlockedLocations = xml.GetStringList("unlockedLocations", new List<string>());
				}
				XElement techTreeXml = XElement.Parse(File.ReadAllText(CheckOverridePath(resourcesAbsolutePath, "TechTree.xml")));
				TechTree = new TechTree(techTreeXml, Game.Instance.CachedDesignerParts, IsStock);
				TechTree.LoadStatusFromXml(xml?.Element("TechTree"));
				string path2 = CheckOverridePath(resourcesAbsolutePath, "Contracts/");
				string[] files = Directory.GetFiles(path2, "*.xml");
				path2 = System.IO.Path.Combine(resourcesAbsolutePath, "ExtraContracts/");
				ContractGenerator contractGenerator = ((!Directory.Exists(path2)) ? new ContractGenerator(files) : new ContractGenerator(files.Concat(Directory.GetFiles(path2, "*.xml")).ToArray()));
				string path3 = CheckOverridePath(resourcesAbsolutePath, "Customers.xml");
				string text = CheckOverridePath(resourcesAbsolutePath, "Images/");
				IEnumerable<XElement> enumerable = XElement.Parse(File.ReadAllText(path3)).Elements();
				List<Customer> list = new List<Customer>();
				foreach (XElement item in enumerable)
				{
					list.Add(new Customer(item, text));
				}
				List<ContractLocation> list2 = new List<ContractLocation>();
				string path4 = CheckOverridePath(resourcesAbsolutePath, "ContractLocations.xml");
				if (File.Exists(path4))
				{
					foreach (XElement item2 in XElement.Parse(File.ReadAllText(path4)).Elements())
					{
						list2.Add(new ContractLocation(item2));
					}
				}
				Contracts = new ContractContext(xml?.Element("Contracts"), list, list2, contractGenerator, this);
				contractGenerator.ReloadContractTemplatesFromFile(Contracts);
				_debugMode = contractGenerator.IsDebugMode;
				Contracts.ContractCompleted += OnContractCompleted;
				Contracts.ContractFailed += OnContractFailed;
				XElement xml2 = XElement.Parse(File.ReadAllText(CheckOverridePath(resourcesAbsolutePath, "Milestones.xml")));
				Milestones = new MilestoneContext(xml2, xml?.Element("Milestones"), TechTree);
				Milestones.MilestoneAdvancedToNextTier += OnMilestoneAdvancedToNextTier;
				XElement xml3 = XElement.Parse(File.ReadAllText(CheckOverridePath(resourcesAbsolutePath, "Exploration.xml")));
				Exploration = new ExplorationContext(this, xml3, xml?.Element("Exploration"));
				Exploration.LandmarkComplete += OnExplorationLandmarkComplete;
				if (gameState.LaunchLocations.Count == 0)
				{
					InitializeLaunchLocations(gameState, resourcesAbsolutePath);
				}
				foreach (LaunchLocation launchLocation in gameState.LaunchLocations)
				{
					if (!string.IsNullOrEmpty(launchLocation.Image))
					{
						launchLocation.ImagePath = System.IO.Path.Combine(text, launchLocation.Image);
					}
				}
				foreach (Contract item3 in Contracts.All)
				{
					foreach (string locationName in item3.UnlockLocations)
					{
						if (!gameState.LaunchLocations.Any((LaunchLocation x) => x.Name == locationName))
						{
							Debug.LogError("Could not find location to unlock with the name '" + locationName + "' referenced by contract '" + item3.Id + "'");
						}
					}
				}
				if (xml == null)
				{
					XElement careerInfoXml = GetCareerInfoXml(Path);
					Money = careerInfoXml.GetLongAttribute("startingMoney", 0L);
					TechTree.ResearchPoints = careerInfoXml.GetIntAttribute("startingTechPoints");
					foreach (string @string in careerInfoXml.GetStringList("unlockedLocations"))
					{
						UnlockLocation(@string);
					}
				}
				_flightContextXml = xml?.Element("Flight");
				if (UnlockedLocations.Count == 0)
				{
					if (IsStock)
					{
						UnlockLocation("Juno Village Pad");
						UnlockLocation("Juno Village Runway");
					}
					foreach (Contract item4 in Contracts.Completed)
					{
						foreach (string unlockLocation in item4.UnlockLocations)
						{
							UnlockLocation(unlockLocation);
						}
					}
				}
				CheckAchievementsCustomers();
				CheckAchievementsLaunchLocations();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public static string CheckOverridePath(string rootPath, string filePath)
		{
			string text = System.IO.Path.Combine(rootPath, filePath);
			if (!File.Exists(text) && !Directory.Exists(text))
			{
				return System.IO.Path.Combine(ResourcesAbsoluteDefaultPath, filePath);
			}
			return text;
		}

		public static List<string> GetAvailableCareerFolders()
		{
			string path = System.IO.Path.Combine(Game.PersistentDataPath, "Career/");
			List<string> list = new List<string>();
			DirectoryInfo[] directories = new DirectoryInfo(path).GetDirectories();
			foreach (DirectoryInfo directoryInfo in directories)
			{
				list.Add(directoryInfo.Name);
			}
			return list;
		}

		public static XElement GetCareerInfoXml(string careerFolderName)
		{
			return XElement.Parse(File.ReadAllText(System.IO.Path.Combine(System.IO.Path.Combine(Game.PersistentDataPath, "Career/", careerFolderName), "Career.xml")));
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Career");
			xElement.SetAttributeValue("path", Path);
			xElement.SetAttributeValue("money", Money);
			xElement.SetAttributeValue("moneyReceived", MoneyReceived);
			xElement.SetAttributeValue("moneySpent", MoneySpent);
			xElement.SetAttributeValue("moneyRecovered", MoneyRecovered);
			xElement.SetAttributeValue("numCraftsRecovered", NumCraftsRecovered);
			xElement.SetAttribute("customersMet", _customersMet);
			xElement.SetAttribute("unlockedLocations", UnlockedLocations);
			xElement.Add(Contracts?.GenerateXml());
			xElement.Add(TechTree?.GenerateStatusXml());
			xElement.Add(Milestones?.GenerateStatusXml());
			xElement.Add(Exploration?.GenerateStatusXml());
			if (_flightContext != null)
			{
				_flightContextXml = _flightContext.GenerateStatusXml();
			}
			if (_flightContextXml != null)
			{
				xElement.Add(_flightContextXml);
			}
			return xElement;
		}

		public Dictionary<int, string> GetContractNamesAndIDsForPayloadId(string payloadId)
		{
			return Contracts.GetContractNamesAndIDsForPayloadId(payloadId);
		}

		public void GiveReward(long money, int techPoints, string message, RewardMessageSoundType sound)
		{
			if (!string.IsNullOrEmpty(message))
			{
				_flightContext?.ShowRewardMessage(message, money, techPoints, sound);
			}
			ReceiveMoney(money);
			ReceiveTechPoints(techPoints);
		}

		public bool HasMetCustomer(string id)
		{
			return _customersMet.Contains(id);
		}

		public void MarkCustomerAsMet(string id)
		{
			if (!_customersMet.Contains(id))
			{
				_customersMet.Add(id);
			}
			CheckAchievementsCustomers();
		}

		public void OnFlightEnd()
		{
			if (_flightContext != null)
			{
				Exploration.OnFlightEnd();
				Contracts.OnFlightEnd();
				Milestones.OnFlightEnd();
				_flightContextXml = _flightContext.GenerateStatusXml();
				_flightContext.OnFlightEnd();
				_flightContext = null;
			}
		}

		public void OnFlightStart(FlightSceneScript flightScene, bool isNewLaunch)
		{
			if (isNewLaunch)
			{
				OnInitialLaunch(flightScene.CraftNode.CraftScript);
			}
			_flightContext = new FlightContext(flightScene, this, _flightContextXml, isNewLaunch, _gameState.LaunchLocations);
			Exploration.OnFlightStart(_flightContext);
			Contracts.OnFlightStart(_flightContext);
			Milestones.OnFlightStart(_flightContext, isNewLaunch);
		}

		public void OnFlightUpdate(in FlightFrameData frame)
		{
			if (_flightContext != null)
			{
				_flightContext.OnFlightUpdate(in frame);
				Exploration.OnFlightUpdate();
				Contracts.OnFlightUpdate();
				Milestones.OnFlightUpdate();
				_flightContext.OnFlightUpdateComplete();
			}
		}

		public void OnRecoverCraft(long totalPrice)
		{
			ReceiveMoney(totalPrice);
			MoneyRecovered += totalPrice;
			NumCraftsRecovered++;
			this.OnMoneyRecovered?.Invoke(totalPrice);
		}

		public void ReceiveMoney(long amount)
		{
			Money += amount;
			MoneyReceived += amount;
			if (MoneyReceived < 0)
			{
				MoneyReceived = 0L;
			}
			CheckAchievementsMoney();
			this.OnMoneyReceived?.Invoke(amount);
		}

		public void ReceiveTechPoints(int techPoints)
		{
			TechTree.ResearchPoints += techPoints;
			CheckAchievementsTechPoints();
		}

		public void SpendMoney(long amount)
		{
			Money -= amount;
			MoneySpent += amount;
			CheckAchievementsMoney();
			this.OnMoneySpent?.Invoke(amount);
		}

		private void CheckAchievementsCustomers()
		{
			if (IsStock)
			{
				if (_customersMet.Contains("buck"))
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerCustomerMetBuck);
				}
				if (_customersMet.Contains("pricklespac"))
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerCustomerMetPricklespac);
				}
				if (_customersMet.Contains("schafer"))
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerCustomerMetSchafer);
				}
				if (_customersMet.Contains("shotwell"))
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerCustomerMetShotwell);
				}
			}
		}

		private void CheckAchievementsLandmarks(ExplorationLandmark landmark)
		{
			if (IsStock)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.LandmarksFirst);
				if (landmark.ExplorationNode.Name == "Droo" && landmark.ExplorationNode.Landmarks.All((ExplorationLandmark x) => x.IsComplete))
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.LandmarksDroo);
				}
			}
		}

		private void CheckAchievementsLaunchLocations()
		{
			if (IsStock)
			{
				if (UnlockedLocations.Contains("Ali Pad") && UnlockedLocations.Contains("Ali 10L") && UnlockedLocations.Contains("Ali 28R"))
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerLaunchLocationsMilitaryBase);
				}
				if (UnlockedLocations.Contains("DSC Launch Pad") && UnlockedLocations.Contains("DSC Large Pad") && UnlockedLocations.Contains("DSC Eastward Runway") && UnlockedLocations.Contains("DSC Westward Runway") && UnlockedLocations.Contains("DSC Secondary Runway") && UnlockedLocations.Contains("DSC Bay"))
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerLaunchLocationsDrooSpaceCenter);
				}
				if (UnlockedLocations.Contains("Luna Base"))
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerLaunchLocationsLuna);
				}
			}
		}

		private void CheckAchievementsMoney()
		{
			if (IsStock)
			{
				if (Money < 0)
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerMoneyDebt);
				}
				if (Money >= 1000000)
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerMoneyFirstMillion);
				}
				if (Money >= 1000000000)
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerMoneyFirstBillion);
				}
				if (Money >= 1000000000000L)
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerMoneyFirstTrillion);
				}
			}
		}

		private void CheckAchievementsTechPoints()
		{
			if (!IsStock || TechTree.ResearchPoints < 250)
			{
				return;
			}
			int num = 0;
			foreach (TechNode allNode in TechTree.AllNodes)
			{
				if (!allNode.Researched)
				{
					num++;
					if (num >= 2)
					{
						Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TechTreeUnspentTechPoints);
						break;
					}
				}
			}
		}

		private void InitializeLaunchLocations(GameState gameState, string rootPath)
		{
			foreach (XElement item in XElement.Parse(File.ReadAllText(CheckOverridePath(rootPath, "LaunchLocations.xml"))).Elements("LaunchLocation"))
			{
				LaunchLocation launchLocation = new LaunchLocation(item);
				if (item.GetBoolAttribute("selected"))
				{
					gameState.SelectedLaunchLocation = launchLocation;
				}
				gameState.LaunchLocations.Add(launchLocation);
			}
			if (gameState.SelectedLaunchLocation == null)
			{
				throw new Exception("Career mode has launch location selected by default.");
			}
			gameState.SaveLaunchLocations();
		}

		private void OnContractCompleted(Contract contract)
		{
			bool crewedOnComplete = contract.Requirements.First().Parent.CrewedOnComplete;
			GiveReward(contract.RewardMoney + (crewedOnComplete ? contract.RewardCrewMoney : 0), contract.RewardResearchPoints + (crewedOnComplete ? contract.RewardCrewResearch : 0), "You have completed the contract [highlight]" + contract.Name + "[/highlight]", RewardMessageSoundType.None);
			if (contract.UnlockLocations.Count <= 0)
			{
				return;
			}
			foreach (string unlockLocation in contract.UnlockLocations)
			{
				UnlockLocation(unlockLocation);
				Debug.Log("Unlocked location '" + unlockLocation + "'");
			}
		}

		private void OnContractFailed(Contract contract)
		{
			Debug.Log("Contract failed: " + contract.Id + " and player has lost " + Units.GetMoneyString(contract.CancelCost));
			ReceiveMoney(-contract.CancelCost);
		}

		private void OnExplorationLandmarkComplete(ExplorationLandmark landmark)
		{
			string message = "You have visited the landmark [highlight]" + landmark?.Name + "[/highlight]";
			GiveReward(0L, landmark.Research, message, RewardMessageSoundType.Landmark);
			CheckAchievementsLandmarks(landmark);
		}

		private void OnInitialLaunch(ICraftScript craft)
		{
			foreach (PartData part in craft.Data.Assembly.Parts)
			{
				IPayload payload = part.Payload;
				if (payload != null && payload.ContractNumber > 0 && !Contracts.Active.Any((Contract x) => x.ContractNumber == part.Payload.ContractNumber))
				{
					Debug.Log($"Could not find contract with number {part.Payload.ContractNumber}");
					part.Payload.ContractNumber = 0;
				}
			}
		}

		private void OnMilestoneAdvancedToNextTier(Milestone milestone, Milestone.MilestoneTier tier)
		{
			int num = milestone.Tiers.IndexOf(tier) + 1;
			string text = tier.RewardMessage;
			if (string.IsNullOrWhiteSpace(text))
			{
				string text2 = (string.IsNullOrWhiteSpace(milestone.Planet) ? string.Empty : (milestone.Planet + ": "));
				text = $"You have completed tier [highlight]{num}[/highlight] of " + "[highlight]" + text2 + milestone.Name + "[/highlight] by exceeding " + StringProcessor.FormatDouble(tier.Value, milestone.ValueFormat) + "\n\n<size=85%><color=#ffffff50>" + milestone.Description + "</color></size>";
			}
			GiveReward(tier.Money, tier.Research, text, RewardMessageSoundType.Milestone);
		}

		private void UnlockLocation(string locationName)
		{
			if (!UnlockedLocations.Contains(locationName))
			{
				UnlockedLocations.Add(locationName);
			}
			CheckAchievementsLaunchLocations();
		}
	}
}
