using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Career.Contracts.Requirements;
using Assets.Scripts.Career.Exploration;
using Assets.Scripts.Career.Milestones;
using Assets.Scripts.Career.Research;
using Assets.Scripts.State;
using ModApi.Flight;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Services.Analytics
{
	public class FlightSceneAnalytics
	{
		private List<Contract> _contracts;

		private List<(string Id, string PlanetName)> _landmarksVisited;

		private List<(string Id, int Tier)> _milestonesAdvanced;

		public int ContractsCompleted { get; private set; }

		public int ContractsFailed { get; private set; }

		public int ContractsIncomplete => GameState.Career?.Contracts.Active.Count ?? 0;

		public GameState GameState { get; }

		public int LandmarksCompleted { get; private set; }

		public int MilestonesUnlocked { get; private set; }

		public long Money => GameState.Career?.Money ?? 0;

		public long MoneyReceived { get; private set; }

		public long MoneyRecovered { get; private set; }

		public long MoneySpent { get; private set; }

		public FlightSceneAnalytics(GameState gameState)
		{
			GameState = gameState;
			_contracts = new List<Contract>();
			_milestonesAdvanced = new List<(string, int)>();
			_landmarksVisited = new List<(string, string)>();
		}

		public void OnFlightEnd(FlightState flightState, FlightSceneExitReason exitReason, bool isNewLaunch, bool saved)
		{
			try
			{
				if (GameState.Mode == GameStateMode.Career)
				{
					CareerState career = GameState.Career;
					career.OnMoneyReceived -= OnMoneyReceived;
					career.OnMoneyRecovered -= OnMoneyRecovered;
					career.OnMoneySpent -= OnMoneySpent;
					career.Contracts.ContractCompleted -= OnContractCompleted;
					career.Contracts.ContractFailed -= OnContractFailed;
					career.Exploration.LandmarkComplete -= OnLandmarkComplete;
					career.Milestones.MilestoneAdvancedToNextTier -= OnMilestoneAdvanced;
				}
				if (!Game.Instance.Analytics.Enabled)
				{
					return;
				}
				if (GameState.Mode == GameStateMode.Career)
				{
					ContractContext contracts = GameState.Career.Contracts;
					foreach (Contract contract in _contracts)
					{
						try
						{
							int num = -1;
							int num2 = -1;
							int num3 = -1;
							bool flag = false;
							bool flag2 = false;
							for (int i = 0; i < contract.Requirements.Count; i++)
							{
								ContractRequirement contractRequirement = contract.Requirements[i];
								if (contractRequirement is TutorialStepRequirement tutorialStepRequirement)
								{
									flag = tutorialStepRequirement.TutorialStarted;
									flag2 = tutorialStepRequirement.TutorialCompleted;
								}
								if (contractRequirement.HasPassedAtLeastOnce)
								{
									num = i;
									continue;
								}
								if (contractRequirement is RaceRequirement raceRequirement)
								{
									num2 = raceRequirement.LapsComplete;
									num3 = raceRequirement.CheckpointIndex;
								}
								break;
							}
							Dictionary<string, object> eventData = new Dictionary<string, object>
							{
								{ "ContractId", contract.Id },
								{
									"ContractStatus",
									contract.Status.ToString()
								},
								{
									"ContractCompleted",
									contract.Status == ContractStatus.Complete
								},
								{
									"ContractNumberOfCompletions",
									contracts.GetNumberOfCompletions(contract.Id)
								},
								{ "HighestRequirementCompletedIndex", num },
								{
									"HighestRequirementCompletedType",
									contract.Requirements.ElementAtOrDefault(num)?.Type ?? string.Empty
								},
								{ "OtherDataInt1", num2 },
								{ "OtherDataInt2", num3 },
								{
									"SimultaneousContractsTotal",
									_contracts.Count - 1
								},
								{
									"SimultaneousContractsPassed",
									ContractsCompleted - ((contract.Status == ContractStatus.Complete) ? 1 : 0)
								},
								{
									"SimultaneousContractsFailed",
									ContractsFailed - ((contract.Status == ContractStatus.Failed) ? 1 : 0)
								},
								{ "MoneySpent", MoneySpent },
								{
									"PlaytimeInSeconds",
									(int)(Game.Instance.Analytics.SceneTimeTracker?.TimeInScene ?? 0.0)
								},
								{
									"CareerPlaytimeInMinutes",
									(int)(flightState.TotalFlightTimeInRealtimeSeconds / 60.0)
								},
								{ "IsNewLaunch", isNewLaunch },
								{
									"ExitType",
									exitReason.ToString()
								},
								{ "Saved", saved }
							};
							Game.Instance.Analytics.LogEvent("ContractAttempt", eventData);
							if (flag)
							{
								Dictionary<string, object> eventData2 = new Dictionary<string, object>
								{
									{ "TutorialId", contract.Id },
									{ "TutorialCompleted", flag2 },
									{ "TutorialStepIndex", num },
									{
										"PlaytimeInSeconds",
										(int)(Game.Instance.Analytics.SceneTimeTracker?.TimeInScene ?? 0.0)
									},
									{
										"CareerPlaytimeInMinutes",
										(int)(flightState.TotalFlightTimeInRealtimeSeconds / 60.0)
									}
								};
								Game.Instance.Analytics.LogEvent("TutorialAttempt", eventData2);
							}
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
							Debug.LogError("An error occurred logging analytics data for contract: " + (contract?.Id ?? "Unknown"));
						}
					}
					foreach (var item in _milestonesAdvanced)
					{
						Dictionary<string, object> eventData3 = new Dictionary<string, object>
						{
							{ "MilestoneId", item.Id },
							{ "MilestoneTier", item.Tier },
							{ "ContractsIncomplete", ContractsIncomplete },
							{ "ContractsCompleted", ContractsCompleted },
							{ "ContractsFailed", ContractsFailed },
							{ "MilestonesUnlocked", MilestonesUnlocked },
							{ "LandmarksVisited", LandmarksCompleted },
							{
								"CareerPlaytimeInMinutes",
								(int)(flightState.TotalFlightTimeInRealtimeSeconds / 60.0)
							},
							{
								"ExitType",
								exitReason.ToString()
							},
							{ "Saved", saved }
						};
						Game.Instance.Analytics.LogEvent("MilestoneAdvanced", eventData3);
					}
					foreach (var item2 in _landmarksVisited)
					{
						Dictionary<string, object> eventData4 = new Dictionary<string, object>
						{
							{ "LandmarkId", item2.Id },
							{ "PlanetName", item2.PlanetName },
							{ "ContractsIncomplete", ContractsIncomplete },
							{ "ContractsCompleted", ContractsCompleted },
							{ "ContractsFailed", ContractsFailed },
							{ "MilestonesUnlocked", MilestonesUnlocked },
							{ "LandmarksVisited", LandmarksCompleted },
							{
								"CareerPlaytimeInMinutes",
								(int)(flightState.TotalFlightTimeInRealtimeSeconds / 60.0)
							},
							{
								"ExitType",
								exitReason.ToString()
							},
							{ "Saved", saved }
						};
						Game.Instance.Analytics.LogEvent("LandmarkVisited", eventData4);
					}
				}
				Dictionary<string, object> eventData5 = new Dictionary<string, object>
				{
					{
						"GameMode",
						GameState.Mode.ToString()
					},
					{ "ContractsIncomplete", ContractsIncomplete },
					{ "ContractsCompleted", ContractsCompleted },
					{ "ContractsFailed", ContractsFailed },
					{ "MilestonesUnlocked", MilestonesUnlocked },
					{ "LandmarksVisited", LandmarksCompleted },
					{ "Money", Money },
					{ "MoneySpent", MoneySpent },
					{ "MoneyReceived", MoneyReceived },
					{ "MoneyRecovered", MoneyRecovered },
					{
						"PlaytimeInSeconds",
						(int)(Game.Instance.Analytics.SceneTimeTracker?.TimeInScene ?? 0.0)
					},
					{ "IsNewLaunch", isNewLaunch },
					{
						"ExitType",
						exitReason.ToString()
					},
					{ "Saved", saved }
				};
				Game.Instance.Analytics.LogEvent("FlightExited", eventData5);
				if (saved && GameState.Mode == GameStateMode.Career)
				{
					CareerState career2 = GameState.Career;
					Dictionary<string, object> eventData6 = new Dictionary<string, object>
					{
						{
							"GameMode",
							GameState.Mode.ToString()
						},
						{ "Money", career2.Money },
						{
							"TechPoints",
							career2.TechTree.ResearchPoints
						},
						{
							"TechNodesUnlocked",
							career2.TechTree.AllNodes.Count((TechNode x) => x.Researched)
						},
						{
							"MilestonesUnlocked",
							career2.Milestones.Milestones.Count((Milestone x) => x.IsComplete)
						},
						{
							"LandmarksVisited",
							career2.Exploration.Nodes.SelectMany((ExplorationNode x) => x.Landmarks).Count((ExplorationLandmark x) => x.IsComplete)
						},
						{
							"CareerPlaytimeInMinutes",
							(int)(flightState.TotalFlightTimeInRealtimeSeconds / 60.0)
						}
					};
					Game.Instance.Analytics.LogEvent("GameProgressSaved", eventData6);
				}
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
				Debug.LogError("An error occurred logging analytics data on flight end.");
			}
		}

		public void OnFlightStart()
		{
			if (!Game.Instance.Analytics.Enabled)
			{
				return;
			}
			if (GameState.Mode == GameStateMode.Career)
			{
				CareerState career = GameState.Career;
				career.OnMoneyReceived += OnMoneyReceived;
				career.OnMoneyRecovered += OnMoneyRecovered;
				career.OnMoneySpent += OnMoneySpent;
				career.Contracts.ContractCompleted += OnContractCompleted;
				career.Contracts.ContractFailed += OnContractFailed;
				career.Exploration.LandmarkComplete += OnLandmarkComplete;
				career.Milestones.MilestoneAdvancedToNextTier += OnMilestoneAdvanced;
			}
			if (GameState.Mode == GameStateMode.Career)
			{
				ContractContext contracts = GameState.Career.Contracts;
				_contracts.AddRange(contracts.All.Where((Contract x) => x.Status == ContractStatus.Active));
			}
		}

		private void OnContractCompleted(Contract contract)
		{
			ContractsCompleted++;
		}

		private void OnContractFailed(Contract contract)
		{
			ContractsFailed++;
		}

		private void OnLandmarkComplete(ExplorationLandmark landmark)
		{
			LandmarksCompleted++;
			string item = GameState.Career?.Exploration.Flight.Planet?.PlanetData.Name ?? string.Empty;
			_landmarksVisited.Add((landmark.Id, item));
		}

		private void OnMilestoneAdvanced(Milestone milestone, Milestone.MilestoneTier tier)
		{
			MilestonesUnlocked++;
			_milestonesAdvanced.Add((milestone.Id, milestone.CurrentTierIndex));
		}

		private void OnMoneyReceived(long money)
		{
			MoneyReceived += money;
		}

		private void OnMoneyRecovered(long money)
		{
			MoneyRecovered += money;
		}

		private void OnMoneySpent(long money)
		{
			MoneySpent += money;
		}
	}
}
