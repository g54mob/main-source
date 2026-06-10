using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Actions
{
	public static class ProductionActions
	{
		private static VillageMap Map => VillageManager.ActiveVillage.Map;

		public static GoapAction Produce(TargetIndex target, ProductionInstance production)
		{
			GoapAction action = new GoapAction("ProduceAction")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			action.OnInit = delegate
			{
				ProductionComponentInstance productionComponentInstance = action.Goal.GetTarget(target).GetObjectAs<ProductionComponentInstance>();
				if (productionComponentInstance == null)
				{
					Log.Error("NULL building for production produce action.", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ProductionActions.cs");
					action.Complete(ActionCompletionStatus.Error);
				}
				else
				{
					ProductionSystemInstance productionSystemInstance = productionComponentInstance.ProductionSystemInstance;
					bool isEnabled;
					if (productionSystemInstance.OperatingAgent != action.AgentOwner)
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(34, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ProductionActions.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Mismatch operating agent. ");
							messageBuilder.AppendFormatted(productionComponentInstance.ComponentBlueprintID);
							messageBuilder.AppendLiteral("@(");
							messageBuilder.AppendFormatted(productionComponentInstance.GridDataPosition);
							messageBuilder.AppendLiteral(" - ");
							messageBuilder.AppendFormatted(productionSystemInstance.OperatingAgent);
							messageBuilder.AppendLiteral(" - ");
							messageBuilder.AppendFormatted(action.AgentOwner);
						}
						Log.Error(messageBuilder);
						action.Complete(ActionCompletionStatus.Error);
					}
					else if (!(production.CurrentStep is ProductionStepWorker productionStepWorker))
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(25, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ProductionActions.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Step is null found. ");
							messageBuilder.AppendFormatted(productionComponentInstance.ComponentBlueprintID);
							messageBuilder.AppendLiteral("@(");
							messageBuilder.AppendFormatted(productionComponentInstance.GridDataPosition);
							messageBuilder.AppendLiteral(" - ");
							messageBuilder.AppendFormatted(action.AgentOwner);
						}
						Log.Error(messageBuilder);
						action.Complete(ActionCompletionStatus.Error);
					}
					else
					{
						IProductionAgent agent = (IProductionAgent)action.AgentOwner;
						agent.IsProducing = true;
						productionStepWorker.AgentEntered(agent);
						production.OnLastStepCompleted += OnLastStepCompleted;
						string interactAnimation = productionComponentInstance.Blueprint.InteractAnimation;
						ProductionComponent component = Map.ProductionComponentBuildingManager.GetComponent(productionComponentInstance);
						if (component != null)
						{
							Transform targetTransform = component.BuildingUsePositionsComponent.GetUsePositionTransform(agent.GetPosition());
							if (targetTransform != null)
							{
								IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
								MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
								{
									if (targetTransform != null)
									{
										agent?.FaceObject(targetTransform);
										if (pathfindingAgent?.PathDriver != null)
										{
											pathfindingAgent.PathDriver.IsFloatingAllowed = true;
											pathfindingAgent.PathDriver.Teleport(targetTransform.position);
										}
									}
								});
							}
							else
							{
								MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
								{
									agent.FaceObject(productionComponentInstance.GetPosition());
								});
							}
						}
						if (!string.IsNullOrEmpty(interactAnimation))
						{
							action.TriggerAnimation(interactAnimation, ActionAnimationMode.Interrupt);
							string interactTool = productionComponentInstance.Blueprint.InteractTool;
							if (!string.IsNullOrEmpty(interactTool))
							{
								Transform socket = null;
								if (productionComponentInstance.Blueprint.ToolSocket == "left")
								{
									socket = (action.AgentOwner as HumanoidInstance)?.GetAgentView<HumanoidView>().BodyPreview.LeftHandSocket;
								}
								(action.AgentOwner as IToolAgent)?.SetTool(interactTool, socket);
							}
						}
						else
						{
							action.TriggerAnimation("Producing", ActionAnimationMode.Interrupt);
						}
					}
				}
			};
			action.OnTick = delegate(float delta)
			{
				if (production.HasDisposed || production.CurrentStep == null)
				{
					action.Goal.EndGoalWith(GoalCondition.Error);
				}
				else if (!(production.CurrentStep is ProductionStepWorker productionStepWorker))
				{
					action.Complete(ActionCompletionStatus.Success);
				}
				else if (!productionStepWorker.OwnerProductionInstance.OwnerProductionComponentInstance.TemperatureAllowsProduction())
				{
					action.Complete(ActionCompletionStatus.Fail);
				}
				else if (productionStepWorker.OwnerProductionInstance.OwnerProductionComponentInstance.OwnerBuilding.UnderWater())
				{
					action.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					productionStepWorker.Tick(delta);
					switch (productionStepWorker.State)
					{
					case ProductionStepWorker.ProcessState.Failed:
						action.Complete(ActionCompletionStatus.Fail);
						break;
					default:
						action.Complete(ActionCompletionStatus.Success);
						break;
					case ProductionStepWorker.ProcessState.InProgress:
						break;
					}
				}
			};
			action.OnComplete = delegate
			{
				IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
				if (pathfindingAgent?.PathDriver != null)
				{
					pathfindingAgent.PathDriver.IsFloatingAllowed = false;
				}
				production.OnLastStepCompleted -= OnLastStepCompleted;
				IProductionAgent productionAgent = (IProductionAgent)action.AgentOwner;
				ProductionComponentInstance objectAs = action.Goal.GetTarget(target).GetObjectAs<ProductionComponentInstance>();
				if (!string.IsNullOrEmpty(objectAs?.Blueprint?.InteractAnimation))
				{
					MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(action.AgentOwner, objectAs.Blueprint.InteractAnimation, value: false);
				}
				if (productionAgent != null)
				{
					productionAgent.IsProducing = false;
				}
				if (production.CurrentStep is ProductionStepWorker { State: ProductionStepWorker.ProcessState.InProgress } productionStepWorker)
				{
					productionStepWorker.Cancel();
				}
			};
			return action;
			void OnLastStepCompleted(ProductionInstance instance, ProductionStepInstance step)
			{
				if (instance == production)
				{
					action.Complete(ActionCompletionStatus.Success);
				}
			}
		}
	}
}
