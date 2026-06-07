using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Career.Contracts.Requirements;
using Assets.Scripts.State;
using ModApi.Common.Extensions;
using ModApi.Scripts.State;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts
{
	public class ContractGenerator
	{
		private List<ContractTemplate> _contractTemplates = new List<ContractTemplate>();

		private string[] _paths;

		public List<ContractTemplate> ContractTemplates => _contractTemplates;

		public bool IsDebugMode { get; private set; }

		public ContractGenerator(string[] paths)
		{
			_paths = paths;
		}

		public static bool CheckContractPrereqs(ContractTemplate contractTemplate, IContractContext context, FlightStateData flightStateData = null)
		{
			if (contractTemplate.Prereqs.ContractIds != null)
			{
				string[] contractIds = contractTemplate.Prereqs.ContractIds;
				foreach (string contractId in contractIds)
				{
					if (!context.Completed.Where((Contract x) => x.Id == contractId).Any())
					{
						return false;
					}
				}
			}
			if (contractTemplate.Prereqs.TechNodeIds != null)
			{
				string[] contractIds = contractTemplate.Prereqs.TechNodeIds;
				foreach (string techNodeId in contractIds)
				{
					if (!context.IsTechNodeResearched(techNodeId))
					{
						return false;
					}
				}
			}
			if (contractTemplate.Prereqs.CraftNodes != null)
			{
				string[] contractIds = contractTemplate.Prereqs.CraftNodes;
				foreach (string contractTrackingId in contractIds)
				{
					if (!flightStateData.CraftNodes.Any((ICraftNodeData x) => x.ContractTrackingId == contractTrackingId))
					{
						return false;
					}
				}
			}
			return true;
		}

		public Contract GenerateContract(IContractContext context, ContractTemplate contractTemplate)
		{
			return new Contract(contractTemplate.GenerateContractXml(context), context)
			{
				Status = ContractStatus.Generated
			};
		}

		public string GetContractName(string contractID)
		{
			return _contractTemplates.Where((ContractTemplate x) => x.Id == contractID).FirstOrDefault()?.Name;
		}

		public int PopulateContext(IContractContext context, PayloadState payloads, double gameTime, int maxContracts = 10)
		{
			int num = maxContracts - context.Active.Count - context.Generated.Count;
			List<Contract> list = new List<Contract>();
			FlightStateData flightStateData = Game.Instance.GameState.LoadFlightStateData();
			IEnumerable<string> source = from x in context.All
				where x.Status == ContractStatus.Rejected
				select x.Name;
			List<ContractTemplate> list2 = _contractTemplates.ToList();
			while (num > 0)
			{
				List<Contract> list3 = new List<Contract>();
				List<ContractTemplate> list4 = new List<ContractTemplate>();
				foreach (ContractTemplate item in list2)
				{
					if ((item.Disabled || !CheckContractPrereqs(item, context, flightStateData)) && !item.IsDebug)
					{
						continue;
					}
					try
					{
						Contract contract = GenerateContract(context, item);
						contract.TimeGenerated = gameTime;
						if ((!(contract.Probability > 0.0) && !item.IsDebug) || (CountContracts(context, list, (Contract x) => x.Id == contract.Id) >= contract.MaxInstances && !item.IsDebug))
						{
							continue;
						}
						if (!item.IsDebug)
						{
							if (CountContracts(context, list, (Contract x) => x.Name == contract.Name && x.Subtitle == contract.Subtitle) == 0 && !source.Contains(contract.Name))
							{
								list3.Add(contract);
							}
							continue;
						}
						foreach (Contract item2 in context.All.Where((Contract x) => x.Id == contract.Id).ToList())
						{
							if (item2.Status == ContractStatus.Generated)
							{
								context.RemoveContract(item2);
							}
						}
						list4.Add(item);
						list.Add(contract);
						Debug.Log("Contract " + contract.Name + " is in debug mode.\n" + contract.GenerateXml().ToString());
					}
					catch (Exception exception)
					{
						Debug.LogError("ContractTemplate '" + item.Id + "' has encountered an error and has been disabled. See the following error for more details.");
						Debug.LogException(exception);
						item.Disabled = true;
					}
				}
				foreach (ContractTemplate item3 in list4)
				{
					list2.Remove(item3);
				}
				double num2 = list3.Sum((Contract x) => x.Probability);
				double num3 = (double)UnityEngine.Random.value * num2;
				double num4 = 0.0;
				foreach (Contract item4 in list3)
				{
					double num5 = num4 + item4.Probability;
					if (num3 >= num4 && num3 <= num5)
					{
						list.Add(item4);
						break;
					}
					num4 = num5;
				}
				num--;
			}
			foreach (Contract item5 in list)
			{
				context.AddNewContract(item5);
			}
			return list.Count;
		}

		public void ReloadContractTemplatesFromFile(IContractContext context)
		{
			_contractTemplates.Clear();
			string[] paths = _paths;
			foreach (string text in paths)
			{
				try
				{
					XElement xElement = XElement.Parse(File.ReadAllText(text));
					IsDebugMode = xElement.GetBoolAttribute("debug") || IsDebugMode;
					AddContractsFromXml(xElement, context);
				}
				catch (Exception ex)
				{
					Debug.LogError("Error reading contract file: '" + text + "'\n" + ex.ToString());
				}
			}
			foreach (ContractTemplate contractTemplate in _contractTemplates)
			{
				try
				{
					if (!contractTemplate.Disabled)
					{
						ValidateContract(context, contractTemplate);
					}
				}
				catch (Exception exception)
				{
					contractTemplate.Disabled = true;
					Debug.LogError("Error generating contract '" + contractTemplate.Id + ".' It has been disabled. See the next error for more details.");
					Debug.LogException(exception);
				}
			}
		}

		private static int CountContracts(IContractContext context, List<Contract> generatedContracts, Func<Contract, bool> condition)
		{
			return context.Active.Count(condition) + context.Generated.Count(condition) + generatedContracts.Count(condition);
		}

		private void AddContractsFromXml(XElement contractsXml, IContractContext context)
		{
			IEnumerable<XElement> enumerable = contractsXml?.Elements("ContractTemplate");
			if (enumerable == null)
			{
				return;
			}
			foreach (XElement item in enumerable)
			{
				ContractTemplate contractTemplate = new ContractTemplate(item);
				if (!contractTemplate.Disabled)
				{
					_contractTemplates.Add(contractTemplate);
				}
			}
		}

		private void PrintContracts(IContractContext context, string parentId, int indent, ref string output)
		{
			foreach (ContractTemplate contractTemplate in ContractTemplates)
			{
				string[] contractIds = contractTemplate.Prereqs.ContractIds;
				if ((contractIds != null && contractIds.Contains(parentId)) || (parentId == null && contractTemplate.Prereqs.ContractIds == null))
				{
					for (int i = 0; i < indent; i++)
					{
						output += "    ";
					}
					Contract contract = new Contract(contractTemplate.GenerateContractXml(context), context);
					output = output + contract.Name + " by " + contract.Customer.Name + " [" + contract.DifficultyLabel + "]";
					string[] contractIds2 = contractTemplate.Prereqs.ContractIds;
					if (contractIds2 != null && contractIds2.Length > 1)
					{
						List<string> list = contractTemplate.Prereqs.ContractIds.ToList();
						list.Remove(parentId);
						output = output + ", Other Prereqs: [" + string.Join(", ", list) + "]";
					}
					string[] techNodeIds = contractTemplate.Prereqs.TechNodeIds;
					if (techNodeIds != null && techNodeIds.Length > 1)
					{
						output = output + ", TechNodes: [" + string.Join(", ", contractTemplate.Prereqs.TechNodeIds) + "]";
					}
					if (contract.UnlockLocations.Count > 0)
					{
						output = output + ", Locations: " + string.Join(", ", contract.UnlockLocations);
					}
					output += "\n";
					PrintContracts(context, contractTemplate.Id, indent + 1, ref output);
				}
			}
		}

		private void ValidateContract(IContractContext context, ContractTemplate contractTemplate)
		{
			Contract contract = GenerateContract(context, contractTemplate);
			ValidationResult validationResult = contract.Validate();
			if (contractTemplate.Prereqs.TechNodeIds != null)
			{
				string[] techNodeIds = contractTemplate.Prereqs.TechNodeIds;
				foreach (string text in techNodeIds)
				{
					try
					{
						context.IsTechNodeResearched(text);
					}
					catch (Exception)
					{
						validationResult.AddMessage("Could not find prereq tech node with id " + text);
					}
				}
			}
			if (contractTemplate.Prereqs.ContractIds != null)
			{
				string[] techNodeIds = contractTemplate.Prereqs.ContractIds;
				foreach (string prereqContractId in techNodeIds)
				{
					if (!ContractTemplates.Where((ContractTemplate x) => x.Id == prereqContractId).Any())
					{
						validationResult.AddMessage("Could not find prereq contract with id " + prereqContractId);
					}
				}
			}
			if (validationResult.MessageCount > 0)
			{
				Debug.LogError($"Contract '{contract.Id}' has {validationResult.MessageCount} validation error(s):\n" + validationResult.Result);
			}
		}
	}
}
