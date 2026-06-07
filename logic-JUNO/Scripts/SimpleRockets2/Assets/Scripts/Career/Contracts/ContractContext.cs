using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Career.Contracts.Requirements;
using Assets.Scripts.State;
using ModApi.Common.Extensions;
using ModApi.Flight.UI;
using ModApi.Scripts.State.Validation;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts
{
	public class ContractContext : IContractContext
	{
		public const string XmlElementName = "Contracts";

		private List<Contract> _active = new List<Contract>();

		private List<Contract> _all = new List<Contract>();

		private CareerState _careerState;

		private List<Customer> _customers = new List<Customer>();

		private ContractGenerator _generator;

		private Dictionary<string, ContractLocation> _locations = new Dictionary<string, ContractLocation>();

		private int _nextContractNumber;

		public IReadOnlyList<Contract> Active => _active;

		public IReadOnlyList<Contract> All => _all;

		public ICareerState Career => _careerState;

		public IReadOnlyList<Contract> Completed => _all.Where((Contract x) => x.Status == ContractStatus.Complete).ToList();

		public IFlightContext Flight { get; private set; }

		public List<Contract> Generated => _all.Where((Contract x) => x.Status == ContractStatus.Generated).ToList();

		public int NumContractsNotSeen { get; set; }

		public PayloadState Payloads { get; }

		public string ResourcesPath => _careerState.ResourcesAbsolutePath;

		public event ContractCompletedDelgate ContractCompleted;

		public event ContractCompletedDelgate ContractFailed;

		public ContractContext(XElement contextXml, List<Customer> customers, List<ContractLocation> contractLocations, ContractGenerator generator, CareerState careerState)
		{
			_nextContractNumber = contextXml?.GetIntAttribute("nextContractNumber") ?? 0;
			Payloads = new PayloadState(this, contextXml?.Element("Payloads"));
			NumContractsNotSeen = contextXml?.GetIntAttribute("numContractsNotSeen") ?? 0;
			_careerState = careerState;
			_customers.AddRange(customers);
			foreach (ContractLocation contractLocation in contractLocations)
			{
				AddContractLocation(contractLocation);
			}
			IEnumerable<XElement> enumerable = contextXml?.Elements("Contract");
			if (enumerable != null)
			{
				foreach (XElement item in enumerable)
				{
					try
					{
						Contract contract = new Contract(item, this);
						if (contract.ContractNumber == 0)
						{
							contract.ContractNumber = GetNextContractNumber();
						}
						_all.Add(contract);
					}
					catch (Exception exception)
					{
						Debug.LogError("Error reading contract '" + item?.Attribute("id")?.Value + "'");
						Debug.LogException(exception);
					}
				}
			}
			_generator = generator;
			RefreshActiveContracts();
		}

		public void AcceptContract(Contract contract, double currentTime)
		{
			contract.TimeAccepted = currentTime;
			contract.Status = ContractStatus.Active;
			if (contract.RewardMoneyAdvance > 0)
			{
				_careerState.ReceiveMoney(contract.RewardMoneyAdvance);
			}
			RefreshActiveContracts();
		}

		public void AddNewContract(Contract contract)
		{
			contract.ContractNumber = GetNextContractNumber();
			_all.Add(contract);
			if (contract.Status == ContractStatus.Active)
			{
				_active.Add(contract);
			}
		}

		public void CancelContract(Contract contract, FlightStateData flightStateData)
		{
			_careerState.ReceiveMoney(-contract.CancelCost);
			contract.TimeAccepted = null;
			contract.Status = ContractStatus.Generated;
			RemoveContract(contract);
			CloseContract(contract, flightStateData);
		}

		public string CanWarp()
		{
			foreach (Contract item in Active)
			{
				string text = item.CanWarp();
				if (text != null)
				{
					return text;
				}
			}
			return null;
		}

		public void CloseContract(Contract contract, FlightStateData flightStateData)
		{
			contract.CloseContract(flightStateData);
			if (contract.Status == ContractStatus.Complete)
			{
				string text = "The contract '" + contract.Name + "' has been completed!";
				Game.Instance.FlightScene?.FlightSceneUI.FlightLog.AddLog(text, FlightLogEntryCategory.Default);
				this.ContractCompleted?.Invoke(contract);
			}
			else if (contract.Status == ContractStatus.Terminated)
			{
				string text2 = "The contract '" + contract.Name + "' has been failed!";
				Game.Instance.FlightScene?.FlightSceneUI.FlightLog.AddLog(text2, FlightLogEntryCategory.Default);
				Flight?.ShowMessage(text2);
				this.ContractFailed?.Invoke(contract);
			}
			CheckAchievements(contract);
			RefreshActiveContracts();
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Contracts");
			xElement.SetAttributeValue("nextContractNumber", _nextContractNumber);
			xElement.SetAttributeValue("numContractsNotSeen", NumContractsNotSeen);
			foreach (Contract item in All)
			{
				xElement.Add(item.GenerateXml());
			}
			return xElement;
		}

		public Contract GetContractFromPayloadTrackingId(string payloadTrackingId)
		{
			foreach (Contract item in Active)
			{
				foreach (ContractRequirement requirement in item.Requirements)
				{
					if (requirement is ISupportsPayload supportsPayload && supportsPayload.IsTrackingPayload(payloadTrackingId))
					{
						return item;
					}
				}
			}
			return null;
		}

		public ContractLocation GetContractLocation(string locationId)
		{
			if (_locations.ContainsKey(locationId))
			{
				return _locations[locationId].Clone();
			}
			throw new ContractException("Could not find a contract location with the id '" + locationId + "'");
		}

		public string GetContractName(string contractID)
		{
			return _generator.GetContractName(contractID);
		}

		public Dictionary<int, string> GetContractNamesAndIDsForPayloadId(string payloadId)
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			foreach (Contract item in Active)
			{
				foreach (ContractRequirement requirement in item.Requirements)
				{
					if (requirement is ISupportsPayload supportsPayload && supportsPayload.PayloadId == payloadId)
					{
						dictionary[item.ContractNumber] = item.Name;
						break;
					}
				}
			}
			return dictionary;
		}

		public Customer GetCustomer(string id)
		{
			Customer customer = _customers.Where((Customer x) => x.Id == id).FirstOrDefault();
			if (customer != null)
			{
				return customer;
			}
			throw new Exception("Unable to find customer with id '" + id + "'");
		}

		public int GetNextContractNumber()
		{
			_nextContractNumber++;
			return _nextContractNumber;
		}

		public int GetNumberOfCompletions(string id)
		{
			return Completed.Where((Contract x) => x.Id == id).Count();
		}

		public bool IsTechNodeResearched(string techNodeId)
		{
			return _careerState.TechTree.GetNode(techNodeId).Researched;
		}

		public void OnFlightEnd()
		{
			foreach (Contract item in _active)
			{
				item.OnFlightEnd();
			}
			Flight = null;
		}

		public void OnFlightStart(IFlightContext flightContext)
		{
			RestartFailedContracts();
			Flight = flightContext;
			RefreshActiveContracts();
			foreach (Contract item in _active)
			{
				if (item.Status == ContractStatus.Error)
				{
					continue;
				}
				try
				{
					item.OnFlightStart(Flight);
					if (item.RequiresReset)
					{
						item.ResetStatus();
					}
				}
				catch (Exception innerException)
				{
					Debug.LogException(new Exception("Contract " + item.Id + " has encountered an error and has been disabled.", innerException));
					item.Status = ContractStatus.Error;
				}
			}
		}

		public void OnFlightUpdate()
		{
			List<Contract> list = new List<Contract>();
			foreach (Contract item in _active)
			{
				if (item.Status == ContractStatus.Error)
				{
					continue;
				}
				try
				{
					item.OnFlightUpdate(Flight);
					if (item.Status == ContractStatus.Complete || item.Status == ContractStatus.Terminated)
					{
						list.Add(item);
					}
				}
				catch (Exception innerException)
				{
					Debug.LogException(new Exception("Contract " + item.Id + " has encountered an error and has been disabled.", innerException));
					item.Status = ContractStatus.Error;
				}
			}
			foreach (Contract item2 in list)
			{
				CloseContract(item2, null);
			}
		}

		public void PopulateContracts()
		{
			double currentTime = Game.Instance.GameState.GetCurrentTime();
			List<Contract> list = new List<Contract>();
			foreach (Contract item in All)
			{
				if (!item.IsComplete && !item.IsActive && item.ExpirationLength > 0 && item.GetDaysUntilExpiration(currentTime) <= 0.0)
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				foreach (Contract item2 in list)
				{
					_all.Remove(item2);
				}
			}
			RefreshActiveContracts();
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			NumContractsNotSeen += _generator.PopulateContext(this, Payloads, currentTime, (int)validator.ItemValue("MaxContractsOffered"));
		}

		public void RefreshActiveContracts()
		{
			_active.Clear();
			_active.AddRange(All.Where((Contract x) => x.IsActive).ToList());
			if (_active.Count >= 5 && _careerState.IsStock)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerActiveContracts);
			}
		}

		public Contract RegenerateContract(Contract contract, bool removeExisting = true)
		{
			Game.Instance.InstallResources();
			_generator.ReloadContractTemplatesFromFile(this);
			ContractTemplate contractTemplate = _generator.ContractTemplates.Where((ContractTemplate x) => x.Id == contract.Id).FirstOrDefault();
			Contract contract2 = _generator.GenerateContract(Game.Instance.GameState.Career.Contracts, contractTemplate);
			contract2.Status = contract.Status;
			contract2.TimeGenerated = contract.TimeGenerated;
			contract2.TimeAccepted = contract.TimeAccepted;
			if (removeExisting)
			{
				_all.Remove(contract);
				_all.Add(contract2);
				RefreshActiveContracts();
			}
			Debug.Log("Contract " + contract.Id + " has been regenerated");
			return contract2;
		}

		public void RemoveContract(Contract contract)
		{
			_all.Remove(contract);
			_active.Remove(contract);
		}

		private void AddContractLocation(ContractLocation contractLocation)
		{
			if (!_locations.ContainsKey(contractLocation.Id))
			{
				_locations[contractLocation.Id] = contractLocation;
				return;
			}
			throw new Exception("A contract location with the id '" + contractLocation.Id + "' already exists.");
		}

		private void CheckAchievements(Contract closedContract)
		{
			if (_careerState.IsStock && closedContract.Status == ContractStatus.Complete)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerFirstContract);
				if (Completed.Count >= 10)
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerCompletedContracts1);
				}
				if (GetNumberOfCompletions(closedContract.Id) >= 10)
				{
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CareerRepeatedContracts1);
				}
			}
		}

		private void RestartFailedContracts()
		{
			foreach (Contract item in _all.Where((Contract x) => x.Status == ContractStatus.Failed).ToList())
			{
				item.RequiresReset = true;
				item.Status = ContractStatus.Active;
			}
		}
	}
}
