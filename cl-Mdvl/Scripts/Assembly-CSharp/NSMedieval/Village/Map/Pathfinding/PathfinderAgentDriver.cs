using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.DebugEvents;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class PathfinderAgentDriver : IGameDisposable, IDisposable
	{
		private const float RotationSpeed = 420f;

		private const float DestinationReachedThreshold = 0.005f;

		private IPathfindingAgent agent;

		private PathProcessingTask processingTask;

		private PathfinderDriverExecCfg execCfg;

		private int currentNodeIndex;

		private Vector3 velocity;

		private readonly int pathfindingCollidersLayerMask;

		private float goapTempSpeedMultiplier;

		private float quickUnstuckCheck;

		private bool autoRefreshActivePathEnable = true;

		private float timeWithoutPath;

		private bool clearPathEventDisabled;

		private PathDriverClimbDirection climbDirection;

		private bool isSwimming;

		public IPathfindingAgent Agent => agent;

		public Path CurrentPath => execCfg.Path;

		public Vec3Int FinalDestination { get; private set; }

		public MapNode FinalDestinationNode { get; private set; }

		public bool IsFloatingAllowed { get; set; }

		public MapNode NextStop { get; private set; }

		public int CurrentNodeIndex => currentNodeIndex;

		public Vector3 Velocity => velocity;

		public bool IsProcessing => processingTask != null;

		public bool IsMoving
		{
			get
			{
				if (currentNodeIndex > -1)
				{
					return NextStop != null;
				}
				return false;
			}
		}

		public PathDriverClimbDirection ClimbDirection => climbDirection;

		public bool IsClimbing => climbDirection != PathDriverClimbDirection.None;

		public bool IsSwimming => isSwimming;

		public float TimeWithoutPath => timeWithoutPath;

		public float GoapTempSpeedMultiplier
		{
			get
			{
				return goapTempSpeedMultiplier;
			}
			set
			{
				goapTempSpeedMultiplier = value;
			}
		}

		public PathfinderAgentDriver GoapTempMatchSpeedDriver { get; set; }

		public bool HasDisposed { get; protected set; }

		public event Action<PathfinderAgentDriver> OnStartTraversingPathEvent;

		public event Action<PathfinderAgentDriver, PathDriverCompletionState> OnClearPathEvent;

		public event Action<IGameDisposable> OnDisposedEvent;

		public PathfinderAgentDriver(IPathfindingAgent agent)
		{
			this.agent = agent;
			goapTempSpeedMultiplier = 1f;
			pathfindingCollidersLayerMask = 1 << LayerMask.NameToLayer("VoxelMapPathfinding");
			currentNodeIndex = -1;
			OnStartTraversingPathEvent += this.agent.Map.AntiPathCrowdingManager.OnAgentStartTraversingPath;
			OnClearPathEvent += this.agent.Map.AntiPathCrowdingManager.OnAgentStopTraversingPath;
		}

		public void Initialize()
		{
			MonoSingleton<SceneController>.Instance.Tick += Update;
			MonoSingleton<SceneController>.Instance.LateTick += LateUpdate;
		}

		public void Dispose()
		{
			if (!HasDisposed)
			{
				HasDisposed = true;
				if (MonoSingleton<SceneController>.IsInstantiated())
				{
					MonoSingleton<SceneController>.Instance.Tick -= Update;
					MonoSingleton<SceneController>.Instance.LateTick -= LateUpdate;
				}
				agent = null;
				if (execCfg.Path != null)
				{
					Path.ReleasePath(execCfg.Path);
				}
				execCfg.Path = null;
				execCfg.OnStopMoving = null;
				execCfg.CalcDirectYOffset = null;
				execCfg.OnNodeEnter = null;
				execCfg.StatusCb = null;
				FinalDestinationNode = null;
				NextStop = null;
				GoapTempMatchSpeedDriver = null;
				this.OnDisposedEvent = null;
				this.OnClearPathEvent = null;
				this.OnStartTraversingPathEvent = null;
				processingTask?.Abort();
				processingTask = null;
			}
		}

		public void ExecutePath(PathfinderDriverExecCfg execConfig)
		{
			if (HasDisposed)
			{
				return;
			}
			Path path = execConfig.Path;
			if (path == null)
			{
				Abort();
				execConfig.StatusCb?.Invoke(obj: false);
				return;
			}
			timeWithoutPath = 0f;
			if (path.State == PathState.Calculated)
			{
				Abort();
				StartFollowingPath(execConfig);
				execConfig.StatusCb?.Invoke(obj: true);
			}
			else if (path.State != PathState.Constructed)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(38, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Driver\\PathfinderAgentDriver.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can not execute path ");
					messageBuilder.AppendFormatted(path.Type);
					messageBuilder.AppendLiteral(". Invalid state: ");
					messageBuilder.AppendFormatted(path.State);
				}
				Log.Error(messageBuilder);
				execConfig.StatusCb?.Invoke(obj: false);
				Path.ReleasePath(path);
			}
			else
			{
				Abort();
				processingTask = MonoSingleton<PathProcessorManager>.Instance.ScheduleProcessPath(path);
				PathProcessingTask pathProcessingTask = processingTask;
				pathProcessingTask.OnComplete = (Action<PathProcessingTask>)Delegate.Combine(pathProcessingTask.OnComplete, (Action<PathProcessingTask>)delegate(PathProcessingTask task)
				{
					OnPathProcessingCompleted(task, execConfig);
				});
				PathProcessingTask pathProcessingTask2 = processingTask;
				pathProcessingTask2.OnComplete = (Action<PathProcessingTask>)Delegate.Combine(pathProcessingTask2.OnComplete, (Action<PathProcessingTask>)delegate(PathProcessingTask task)
				{
					execConfig.StatusCb?.Invoke(task.State == PathProcessingTaskState.Completed);
				});
			}
		}

		public void Teleport(Vec3Int gridPos)
		{
			Teleport(GridUtils.GetWorldPosition(gridPos));
		}

		public void Teleport(Vector3 worldPos)
		{
			if (!HasDisposed)
			{
				MapNode node = VillageManager.ActiveVillage.Map.GetNode(GridUtils.GetGridPosition(worldPos, 0.01f));
				if (node.IsWater)
				{
					worldPos = GetAgentWaterPosition(node);
				}
				Abort();
				agent?.UpdatePosition(worldPos);
				climbDirection = CalculateClimbingDirection(null);
			}
		}

		public void Abort()
		{
			if (!HasDisposed && (processingTask != null || execCfg.Path != null))
			{
				ClearCurrentPath(PathDriverCompletionState.Abort);
				processingTask?.Abort();
				processingTask = null;
			}
		}

		internal Vector3 GetDestinationWorldPos(MapNode nextNode)
		{
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return default(Vector3);
			}
			Vector3 worldPosition = nextNode.WorldPosition;
			MapNode node = agent.GetNode();
			bool flag = nextNode.IsWater != node.IsWater && ((!node.IsLayerRamp() && !nextNode.IsLayerRamp()) || node.WaterLevel.HasFlag(WaterDepthLevel.High));
			if (isSwimming || (flag && nextNode.WaterDepthLevel != WaterDepthLevel.Low))
			{
				worldPosition = GetAgentWaterPosition(nextNode);
				if (!node.IsWater && nextNode.IsWater)
				{
					worldPosition.y -= 0.2f;
				}
				if (node.IsWater && !nextNode.IsWater)
				{
					worldPosition.y += 0.2f;
				}
				return worldPosition;
			}
			if (!nextNode.IsLayerRamp() || (nextNode.Tag & MapNodeTags.Ladder) != MapNodeTags.None)
			{
				return worldPosition;
			}
			WorldObject layerRampObject = nextNode.GetLayerRampObject();
			Vec3Int pos = nextNode.Position;
			if (layerRampObject.Positions.FindIndex((Vec3Int item) => item.x == pos.x && item.y == pos.y && item.z == pos.z) < 0)
			{
				return worldPosition;
			}
			if (!Physics.Raycast(worldPosition + Vector3.up * 3.1f, Vector3.down, out var hitInfo, 3.1f, pathfindingCollidersLayerMask))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Driver\\PathfinderAgentDriver.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(agent);
					messageBuilder.AppendLiteral(" Should fall down. Mask:");
					messageBuilder.AppendFormatted(pathfindingCollidersLayerMask);
				}
				Log.Error(messageBuilder);
				return agent.GetPosition();
			}
			worldPosition.y = hitInfo.point.y + 0.01f;
			return worldPosition;
		}

		private void OnPathProcessingCompleted(PathProcessingTask task, PathfinderDriverExecCfg execConfig)
		{
			if (task != processingTask || HasDisposed)
			{
				if (execCfg.Path != null && task.Path == execCfg.Path)
				{
					Log.Error("This should never happen. Check trace. " + execCfg.Path.Agent, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Driver\\PathfinderAgentDriver.cs");
				}
				Path.ReleasePath(task.Path);
				return;
			}
			if (execConfig.Path != task.Path)
			{
				throw new Exception("execConfig.Path != task.Path. This should never happen.");
			}
			processingTask = null;
			if (task.State == PathProcessingTaskState.Completed && task.Path.State == PathState.Calculated)
			{
				StartFollowingPath(execConfig);
				return;
			}
			if (task.State == PathProcessingTaskState.Failed)
			{
				Path.ReleasePath(task.Path);
				return;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(84, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Driver\\PathfinderAgentDriver.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("[Soft ERR] Unexpected situation: Path processing completed with state: ");
				messageBuilder.AppendFormatted(task.State);
				messageBuilder.AppendLiteral(", path state ");
				messageBuilder.AppendFormatted(task.Path?.State);
			}
			Log.Info(messageBuilder);
			Path.ReleasePath(task.Path);
		}

		private void OnPathDestinationReached()
		{
			ClearCurrentPath(PathDriverCompletionState.DestinationReached);
		}

		private void ClearCurrentPath(PathDriverCompletionState state)
		{
			if (HasDisposed)
			{
				return;
			}
			using (ProfilerSampleJanitor.Begin("ClearCurrentPath"))
			{
				climbDirection = CalculateClimbingDirection(null);
				if (execCfg.Path == null)
				{
					currentNodeIndex = -1;
					NextStop = null;
					return;
				}
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Driver\\PathfinderAgentDriver.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ClearCurrentPath ");
					messageBuilder.AppendFormatted(agent);
				}
				Log.Trace(messageBuilder);
				if (!clearPathEventDisabled)
				{
					this.OnClearPathEvent?.Invoke(this, state);
				}
				currentNodeIndex = -1;
				execCfg.OnStopMoving?.Invoke(execCfg.Path, this);
				velocity = Vector3.zero;
				FinalDestination = Vec3Int.zero;
				FinalDestinationNode = null;
				NextStop = null;
				goapTempSpeedMultiplier = 1f;
				DetachNodeChangeListeners();
				Path path = execCfg.Path;
				execCfg = default(PathfinderDriverExecCfg);
				Path.ReleasePath(path);
			}
		}

		private void StartFollowingPath(PathfinderDriverExecCfg driverConfig)
		{
			if (driverConfig.Path == null || driverConfig.Path.State != PathState.Calculated)
			{
				throw new Exception("Can not StartFollowingPath. Invalid state: " + (driverConfig.Path?.State).ToString());
			}
			Path path = driverConfig.Path;
			if (path.NodePath.Count == 0)
			{
				Log.Warning("Can not StartFollowingPath. No nodes in path. Agent: " + Agent, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Driver\\PathfinderAgentDriver.cs");
				return;
			}
			execCfg = driverConfig;
			currentNodeIndex = path.NodePath.Count - 2;
			if (currentNodeIndex < 0)
			{
				currentNodeIndex = 0;
			}
			FinalDestination = path.NodePath[0].Position;
			FinalDestinationNode = path.NodePath[0];
			quickUnstuckCheck = 0f;
			AttachNodeChangeListeners();
			if (MonoSingleton<MapPathDebugManager>.IsInstantiated())
			{
				MonoSingleton<MapPathDebugManager>.Instance.DrawPath(path);
			}
			this.OnStartTraversingPathEvent?.Invoke(this);
		}

		private void Update(float delta)
		{
			if (agent == null || agent.HasDisposed || agent.IsInIncognitoMode())
			{
				return;
			}
			using (ProfilerSampleJanitor.Begin("PathfinderAgentDriver.Tick"))
			{
				using (ProfilerSampleJanitor.Begin(Agent.GetGoapAgentID()))
				{
					using (ProfilerSampleJanitor.Begin("Swimming"))
					{
						UpdateIsSwimming(agent.GetNode());
					}
					if (currentNodeIndex < 0 || execCfg.Path == null || delta <= 0.0005f || HasDisposed)
					{
						using (ProfilerSampleJanitor.Begin("Not moving"))
						{
							timeWithoutPath += Time.deltaTime;
							if (isSwimming)
							{
								UpdateWaterPosition(delta);
							}
							else
							{
								UpdateIsFalling(delta);
							}
							return;
						}
					}
					if (execCfg.Path.IsInPool || execCfg.Path.NodePath == null || currentNodeIndex >= execCfg.Path.NodePath.Count)
					{
						using (ProfilerSampleJanitor.Begin("Abort"))
						{
							Abort();
							return;
						}
					}
					MapNode node = agent.Map.GetNode(agent.GetGridPosition());
					if (node == null)
					{
						bool isEnabled;
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Driver\\PathfinderAgentDriver.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Could not find node agent ");
							messageBuilder.AppendFormatted(agent);
							messageBuilder.AppendLiteral(" was standing on... Aborting");
						}
						Log.Warning(messageBuilder);
						Abort();
						return;
					}
					timeWithoutPath = 0f;
					float movementSpeed;
					float num;
					if (GoapTempMatchSpeedDriver != null)
					{
						movementSpeed = GoapTempMatchSpeedDriver.Agent.GetMovementSpeed();
						num = GetSpeedMultiplier(node, GoapTempMatchSpeedDriver.Agent) * GoapTempMatchSpeedDriver.GoapTempSpeedMultiplier;
					}
					else
					{
						movementSpeed = agent.GetMovementSpeed();
						num = GetSpeedMultiplier(node, agent) * goapTempSpeedMultiplier;
					}
					float num2 = movementSpeed * num;
					NextStop = execCfg.Path.NodePath[currentNodeIndex];
					using (ProfilerSampleJanitor.Begin("CanTraverse"))
					{
						if (node != NextStop && agent.PathTraversalProvider != null && !agent.PathTraversalProvider.CanTraverse(NextStop, node))
						{
							ClearCurrentPath(PathDriverCompletionState.Abort);
							return;
						}
					}
					Vector3 position = agent.GetPosition();
					Vector3 worldPosition = node.WorldPosition;
					Vector3 destinationWorldPos = GetDestinationWorldPos(NextStop);
					Vector3 vector = Vector3.zero;
					climbDirection = CalculateClimbingDirection(NextStop);
					if (climbDirection != PathDriverClimbDirection.None)
					{
						destinationWorldPos.x = worldPosition.x;
						destinationWorldPos.z = worldPosition.z;
						WorldObject layerRampObject = node.GetLayerRampObject();
						if (layerRampObject != null)
						{
							vector.y = layerRampObject.Angle;
						}
						num2 *= 0.8f;
					}
					else
					{
						vector = destinationWorldPos - position;
					}
					if (execCfg.CalcDirectYOffset != null && Vector3.Distance(agent.GetPosition(), node.WorldPosition) <= VillageConstants.AgentPathfindingDriverAtNodeCenter)
					{
						destinationWorldPos.y += execCfg.CalcDirectYOffset(NextStop, this) - 0.001f;
					}
					if ((NextStop.DataType & GridDataType.SlopeOrStairs) == 0 && (NextStop.Tag & MapNodeTags.Ladder) == 0 && Math.Abs(position.y - destinationWorldPos.y) > 0.05f && Math.Abs(position.x - destinationWorldPos.x) > 0.25f)
					{
						destinationWorldPos.y = position.y;
					}
					Vector3 vector2 = Vector3.MoveTowards(position, destinationWorldPos, Time.deltaTime * num2);
					MapNode node2 = VillageManager.ActiveVillage.Map.GetNode(GridUtils.GetGridPosition(vector2, 0.01f));
					if (!node2.IsWalkable && (!node.IsWater || node.WaterLevel == WaterDepthLevel.Low) && NextStop.IsWater && NextStop.WaterLevel == WaterDepthLevel.High)
					{
						if (node2.GetNodeBelow() != null && node2.GetNodeBelow().IsWater)
						{
							vector2.y -= 0.2f;
						}
						else
						{
							vector2.y = position.y;
						}
					}
					if (!node2.IsWalkable && node.IsWater && !NextStop.IsWater && node2.GetNodeAbove() != null && node2.GetNodeAbove().IsWalkable)
					{
						vector2.y += 0.2f;
					}
					velocity = (vector2 - position).normalized * num2;
					if (climbDirection != PathDriverClimbDirection.None || Mathf.Sqrt(Mathf.Pow(vector.x, 2f) + Mathf.Pow(vector.z, 2f)) > Mathf.Epsilon)
					{
						Quaternion rotation = ((climbDirection != PathDriverClimbDirection.None) ? Quaternion.Euler(vector) : Quaternion.LookRotation(vector, Vector3.up));
						using (ProfilerSampleJanitor.Begin("UpdateRotation"))
						{
							agent.UpdateRotation(rotation);
						}
					}
					using (ProfilerSampleJanitor.Begin("UpdatePosition"))
					{
						agent.UpdatePosition(vector2);
					}
					if (Vector3.Distance(vector2, destinationWorldPos) > 0.005f)
					{
						return;
					}
					if (currentNodeIndex == 0)
					{
						using (ProfilerSampleJanitor.Begin("OnPathDestinationReached"))
						{
							OnPathDestinationReached();
						}
						currentNodeIndex = -1;
					}
					else
					{
						currentNodeIndex--;
					}
				}
			}
		}

		private static Vector3 GetAgentWaterPosition(MapNode node)
		{
			MapNode mapNode = node;
			MapNode nodeBelow = mapNode.GetNodeBelow();
			if (!node.IsWalkable && nodeBelow != null && nodeBelow.IsWater)
			{
				mapNode = nodeBelow;
			}
			WaterManager waterManager = node.Map.WaterManager;
			WaterSimLogic waterSimLogic = waterManager.WaterSimLogic;
			if (!mapNode.IsWater || !waterManager.IsWaterEnclosed(mapNode))
			{
				return mapNode.WorldPosition;
			}
			MapNode nodeAbove = mapNode.GetNodeAbove();
			Vector3 result = mapNode.Position.ToVector3World();
			result.y += waterSimLogic.GetWaterLevel(mapNode.Index) * (float)World.MapBlockHeight - 0.2f;
			if (waterManager.IsWaterFull(mapNode) && nodeAbove != null && (nodeAbove.IsVoxelFloor() || nodeAbove.IsVoxelWall() || !nodeAbove.IsVoxelAir()))
			{
				result.y -= 1f;
			}
			if (nodeAbove != null && nodeAbove.IsWater && !nodeAbove.WaterLevel.HasFlag(WaterDepthLevel.Low) && waterManager.IsWaterEnclosed(nodeAbove) && !nodeAbove.IsVoxelFloor() && !nodeAbove.IsVoxelWall() && nodeAbove.IsVoxelAir())
			{
				result.y += waterSimLogic.GetWaterLevel(nodeAbove.Index) * (float)World.MapBlockHeight;
			}
			return result;
		}

		private void UpdateWaterPosition(float delta)
		{
			float num = 3f;
			Vector3 vector = agent.GetPosition();
			Vector3 agentWaterPosition = GetAgentWaterPosition(agent.GetNode());
			if (Vector3.Distance(vector, agentWaterPosition) > 0.2f)
			{
				Vector3 normalized = (agentWaterPosition - vector).normalized;
				Vector3 vector2 = vector + normalized * (num * delta);
				if (vector.y > agentWaterPosition.y && vector2.y < agentWaterPosition.y)
				{
					DebugEventLog.Write(new GoapDebugEvent(agent, GoapDebugEventCode.UpdateWaterPosition_0));
					vector.y = agentWaterPosition.y;
				}
				else
				{
					DebugEventLog.Write(new GoapDebugEvent(agent, GoapDebugEventCode.UpdateWaterPosition_1));
					vector = vector2;
				}
			}
			agent.UpdatePosition(vector);
		}

		private void UpdateIsFalling(float delta)
		{
			MapNode node = agent.GetNode();
			if (Agent.GetGoapAgent().AgentOwner is CreatureBase creatureBase && node != null && !node.IsVoxelFloor() && !node.Tag.HasFlag(MapNodeTags.Floor) && !node.Tag.HasFlag(MapNodeTags.Wall) && creatureBase is HumanoidInstance humanoidInstance && node.Tag.HasFlag(MapNodeTags.Ladder) && node.GetNodeBelow() != null && (humanoidInstance.HasFainted || (humanoidInstance.CaptiveNpcBehaviour != null && humanoidInstance.CaptiveNpcBehaviour.GoapAgent.CurrentGoalName == "PrisonerSurrenderGoal")))
			{
				float num = 3f;
				Vector3 position = agent.GetPosition();
				Vector3 worldPosition = agent.GetNode().GetNodeBelow().WorldPosition;
				if (Vector3.Distance(position, worldPosition) > 0.2f)
				{
					Vector3 normalized = (worldPosition - position).normalized;
					position += normalized * (num * delta);
				}
				agent.UpdatePosition(position);
			}
		}

		private void UpdateIsSwimming(MapNode nextNode)
		{
			if (nextNode == null)
			{
				isSwimming = false;
				return;
			}
			using (ProfilerSampleJanitor.Begin("FaintedCarried"))
			{
				if (Agent.GetGoapAgent().AgentOwner is CreatureBase { HasFainted: not false, IsBeingCarried: not false })
				{
					isSwimming = false;
					return;
				}
			}
			WaterManager waterManager = VillageManager.ActiveVillage.Map.WaterManager;
			using (ProfilerSampleJanitor.Begin("LayerRamp"))
			{
				if ((nextNode.IsLayerRamp() || (nextNode.Tag & MapNodeTags.Ladder) != MapNodeTags.None) && !waterManager.GetWaterLevelAsDepth(nextNode.Index).HasFlag(WaterDepthLevel.High))
				{
					isSwimming = false;
					return;
				}
			}
			if (!waterManager.IsWaterEnclosed(nextNode) && nextNode.IsVoxelFloor())
			{
				isSwimming = false;
				return;
			}
			using (ProfilerSampleJanitor.Begin("CanWalkInside"))
			{
				if (nextNode.IsWater && !waterManager.CanWalkInside(nextNode))
				{
					isSwimming = true;
					return;
				}
			}
			isSwimming = false;
		}

		private PathDriverClimbDirection CalculateClimbingDirection(MapNode nextNode)
		{
			if (HasDisposed || CombatUtils.IsNullOrDisposed(agent))
			{
				return PathDriverClimbDirection.None;
			}
			MapNode node = agent.GetNode();
			if ((nextNode != null && nextNode.WaterLevel == WaterDepthLevel.High) || (node != null && node.WaterLevel == WaterDepthLevel.High))
			{
				return PathDriverClimbDirection.None;
			}
			Vector3 position = agent.GetPosition();
			if (nextNode == null || !IsMoving)
			{
				if (node == null)
				{
					return PathDriverClimbDirection.Center;
				}
				if ((node.Tag & MapNodeTags.Ladder) == 0)
				{
					return PathDriverClimbDirection.None;
				}
				if (!(Mathf.Abs(node.WorldPosition.y - position.y) > 0.035f))
				{
					return PathDriverClimbDirection.None;
				}
				return PathDriverClimbDirection.Center;
			}
			if (position.y % (float)World.MapBlockHeight <= 0.035f && (node.Tag & MapNodeTags.Ladder) == 0)
			{
				return PathDriverClimbDirection.None;
			}
			MapNode node2 = agent.Map.GetNode(GridUtils.GetGridPosition(position, 0.01f));
			if ((node2.Tag & MapNodeTags.Ladder) == 0)
			{
				return PathDriverClimbDirection.None;
			}
			if (nextNode == node2)
			{
				MapNode nodeBelow = nextNode.GetNodeBelow();
				if ((nodeBelow == null || (nodeBelow.Tag & MapNodeTags.Ladder) != MapNodeTags.None) && climbDirection == PathDriverClimbDirection.Down && currentNodeIndex > 0)
				{
					return PathDriverClimbDirection.Down;
				}
				float num = position.y - nextNode.WorldPosition.y;
				if (!(Mathf.Abs(num) <= 0.035f))
				{
					if (!(num > 0f))
					{
						return PathDriverClimbDirection.Up;
					}
					return PathDriverClimbDirection.Down;
				}
				return PathDriverClimbDirection.None;
			}
			if (nextNode.Position.y == node2.Position.y)
			{
				return PathDriverClimbDirection.None;
			}
			if (Mathf.Abs(node2.WorldPosition.y - position.y) < 0.035f)
			{
				if (nextNode.Position.y <= node2.Position.y)
				{
					return PathDriverClimbDirection.Down;
				}
				return PathDriverClimbDirection.Up;
			}
			if (!(position.y > nextNode.WorldPosition.y))
			{
				return PathDriverClimbDirection.Up;
			}
			return PathDriverClimbDirection.Down;
		}

		private void LateUpdate(float delta)
		{
			using (ProfilerSampleJanitor.Begin("PathfinderAgentDriver.LateTick"))
			{
				if (!HasDisposed && !CombatUtils.IsNullOrDisposed(agent) && (currentNodeIndex < 0 || execCfg.Path == null))
				{
					DriverQuickUnstuck.TickWhileNotMoving(this, ref quickUnstuckCheck);
				}
			}
		}

		private static float GetSpeedMultiplier(MapNode currentNode, IPathfindingAgent pathfindingAgent)
		{
			WalkSpeedMultiplier walkSpeedMultiplier = pathfindingAgent.WalkableModel?.WalkSpeedMultiplierBlueprint;
			if (walkSpeedMultiplier == null)
			{
				return 1f;
			}
			return WalkSpeedMultiplier.GetSpeedMultiplier(walkSpeedMultiplier, currentNode);
		}

		private void AttachNodeChangeListeners()
		{
			if (!autoRefreshActivePathEnable || execCfg.Path == null)
			{
				return;
			}
			if (execCfg.Path.NodePath == null)
			{
				throw new Exception("this.execCfg.Path.NodePath is NULL. Something is horribly wrong here... This should never happen");
			}
			List<MapNode> nodePath = execCfg.Path.NodePath;
			for (int i = 0; i < nodePath.Count; i++)
			{
				if (nodePath[i] != null)
				{
					nodePath[i].OnWalkabilityChangedEvent += OnNodeWalkabilityChangedEvent;
				}
			}
		}

		private void DetachNodeChangeListeners()
		{
			if (execCfg.Path == null)
			{
				return;
			}
			if (execCfg.Path.NodePath == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(76, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Driver\\PathfinderAgentDriver.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("this.execCfg.Path.NodePath is NULL. This should never happen. Type: ");
					messageBuilder.AppendFormatted(execCfg.Path.Type);
					messageBuilder.AppendLiteral(" Agent: ");
					messageBuilder.AppendFormatted(agent);
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				List<MapNode> nodePath = execCfg.Path.NodePath;
				for (int i = 0; i < nodePath.Count; i++)
				{
					nodePath[i].OnWalkabilityChangedEvent -= OnNodeWalkabilityChangedEvent;
				}
			}
		}

		private void OnNodeWalkabilityChangedEvent(MapNode node)
		{
			if (HasDisposed || !PathPool.IsInitialized || execCfg.Path == null)
			{
				return;
			}
			if (execCfg.Path.NodePath == null)
			{
				throw new Exception("this.execCfg.Path.NodePath is NULL. Something is horribly wrong here... This should never happen");
			}
			if (node.IsWalkable)
			{
				return;
			}
			if (FinalDestinationNode == node)
			{
				Abort();
				return;
			}
			Action<Path, PathfinderAgentDriver> execCfgOnStopMoving = execCfg.OnStopMoving;
			execCfg.OnStopMoving = null;
			Path oldPath = execCfg.Path;
			Vec3Int finalDestination = FinalDestination;
			clearPathEventDisabled = true;
			Abort();
			clearPathEventDisabled = false;
			P2PPath path = P2PPath.Construct(agent, finalDestination);
			PathfinderDriverExecCfg newCfg = new PathfinderDriverExecCfg
			{
				Path = path,
				StatusCb = OnDone,
				OnNodeEnter = execCfg.OnNodeEnter,
				OnStopMoving = execCfgOnStopMoving,
				CalcDirectYOffset = execCfg.CalcDirectYOffset
			};
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				ExecutePath(newCfg);
			});
			void OnDone(bool value)
			{
				if (!HasDisposed && !value)
				{
					execCfgOnStopMoving?.Invoke(oldPath, this);
					this.OnClearPathEvent?.Invoke(this, PathDriverCompletionState.FailedToReachDestination);
				}
			}
		}
	}
}
