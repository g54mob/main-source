using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class RitualAnimalEventGoal : Goal
	{
		private readonly AnimalInstance animalInstance;

		public RitualAnimalEventGoal(Agent selfAgent)
			: base("RitualAnimalEventGoal", selfAgent)
		{
			animalInstance = (AnimalInstance)base.AgentOwner;
			AddInitStep(new ThreadSequenceStep(StartCheck, ValidatePath));
		}

		public override bool CanStart(bool isForced = false)
		{
			return GetEventInstance() != null;
		}

		public override bool AgentTypeCheck()
		{
			return animalInstance != null;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (condition != GoalCondition.Succeeded)
			{
				Log.Debug("RitualAnimalEventGoal goal failed with condition " + condition.ToString() + " Action: " + base.CurrentAction?.Id + " Status: " + (base.CurrentAction?.CompletionStatus).ToString() + " " + base.AgentOwner, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RitualAnimalEventGoal.cs");
			}
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposed(TargetIndex.A).FailAtCondition(() => EventFailCondition() || EventEnded());
			goapAction.OnPreInit = delegate
			{
				animalInstance.CombatAi.SetState(CombatAiState.AnimalRetreatingNoPathToTrader, false);
				bool num = animalInstance.PathTraversalProvider is TagTraversalProvider tagTraversalProvider && (tagTraversalProvider.NotWalkableTags & MapNodeTags.Ladder) != 0;
				animalInstance.SetWalkableModel(Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID("animal_leave_map"));
				if (num)
				{
					((TagTraversalProvider)animalInstance.PathTraversalProvider).NotWalkableTags |= MapNodeTags.Ladder;
				}
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RitualAnimalEventGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Animal ");
					messageBuilder.AppendFormatted(animalInstance.GetFullName());
					messageBuilder.AppendLiteral(" is going to the event position");
				}
				Log.Debug(messageBuilder);
			};
			goapAction.OnTick = delegate
			{
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(40, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RitualAnimalEventGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("'goToTarget' Goal completed with status ");
					messageBuilder.AppendFormatted(status);
				}
				Log.Debug(messageBuilder);
				if (status != ActionCompletionStatus.Success)
				{
					messageBuilder = new FVLogDebugInterpolationHandler(49, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RitualAnimalEventGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Animal ");
						messageBuilder.AppendFormatted(animalInstance.GetFullName());
						messageBuilder.AppendLiteral(" can't PathFind to target, probably locked");
					}
					Log.Debug(messageBuilder);
					GetEventInstance().OnAnimalCanNotAttend(animalInstance);
					EndGoalWith(GoalCondition.Incompletable);
				}
				else
				{
					messageBuilder = new FVLogDebugInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RitualAnimalEventGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Animal ");
						messageBuilder.AppendFormatted(animalInstance.GetFullName());
						messageBuilder.AppendLiteral(" reached the event position");
					}
					Log.Debug(messageBuilder);
					ResetAnimal();
				}
			};
			yield return goapAction;
			GoapAction waitForever = GeneralActions.WaitForever().FailAtCondition(EventFailCondition).CompleteAtCondition(EventEnded);
			waitForever.OnInit = delegate
			{
				animalInstance.CombatAi.SetState(CombatAiState.AnimalRetreatingNoPathToTrader, false);
				waitForever.TriggerAnimation("Bored", ActionAnimationMode.Ignore);
			};
			waitForever.OnTick = delegate
			{
			};
			waitForever.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RitualAnimalEventGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("'waitForever' Goal completed with status ");
					messageBuilder.AppendFormatted(status);
				}
				Log.Debug(messageBuilder);
				if (GetEventInstance() != null && GetEventInstance().Completed())
				{
					MonoSingleton<AnimalController>.Instance.DepletedHealth(animalInstance);
				}
				else
				{
					ResetAnimal();
				}
			};
			yield return waitForever;
		}

		protected PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is RitualEventInstance result))
			{
				return null;
			}
			return result;
		}

		private bool EventFailCondition()
		{
			if (!animalInstance.HasDisposed && !animalInstance.HasDied && !GetEventInstance().Interrupted())
			{
				return GetEventInstance().Disposed();
			}
			return true;
		}

		private void ResetAnimal()
		{
			animalInstance.CombatAi.SetState(CombatAiState.AnimalRetreatingNoPathToTrader, true);
			animalInstance.ResetWalkableModel();
		}

		private bool EventEnded()
		{
			if (GetEventInstance() != null)
			{
				return GetEventInstance().Ended();
			}
			return true;
		}

		private bool StartCheck()
		{
			if (animalInstance == null || animalInstance.HasDisposed || animalInstance.HasDied)
			{
				return false;
			}
			return true;
		}

		private bool ValidatePath()
		{
			IGoapTargetable hostBuilding = GetEventInstance().HostBuilding;
			P2PPath p2PPath = P2PPath.Construct(animalInstance, hostBuilding.GetGridPosition());
			if (!(animalInstance.PathTraversalProvider is TagTraversalProvider tagTraversalProvider) || (tagTraversalProvider.NotWalkableTags & MapNodeTags.Ladder) == 0)
			{
				p2PPath.TraversalProvider = Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentWalkableDoors().StaticTraversalProvider;
			}
			else
			{
				p2PPath.TraversalProvider = Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentWalkableDoors().GenerateTraversalProvider();
				((TagTraversalProvider)p2PPath.TraversalProvider).NotWalkableTags |= MapNodeTags.Ladder;
			}
			MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(p2PPath);
			if (p2PPath.State != PathState.Calculated)
			{
				Path.ReleasePath(p2PPath);
				return false;
			}
			Path.ReleasePath(p2PPath);
			SetTarget(TargetIndex.A, new TargetObject(GetEventInstance().GetFurnitureCenterPosition()));
			return true;
		}
	}
}
