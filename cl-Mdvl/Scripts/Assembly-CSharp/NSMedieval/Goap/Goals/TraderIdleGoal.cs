using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class TraderIdleGoal : Goal
	{
		private float walkSpeed;

		private System.Random random;

		private TradingPostComponentInstance nearestTradingPost;

		private TraderBehaviour traderBehaviour;

		private static object syncObj = new object();

		private HumanoidInstance HumanoidInstance => base.AgentOwner as HumanoidInstance;

		public TraderIdleGoal(Agent selfAgent)
			: base("TraderIdleGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (traderBehaviour != null)
			{
				traderBehaviour.TradingPostReservedPosition = Vec3Int.zero;
			}
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IPathfindingAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<StockpileManager>.IsInstantiated() || !MonoSingleton<AnimationController>.IsInstantiated() || !MonoSingleton<NPCController>.IsInstantiated())
			{
				return false;
			}
			if (HumanoidInstance == null || HumanoidInstance.HasDisposed)
			{
				return false;
			}
			return !HumanoidInstance.IsOnFire;
		}

		private bool ShouldNpcWalkIdle()
		{
			foreach (GameEventInstance runningEvent in MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.RunningEvents)
			{
				if (runningEvent is TraderEvent traderEvent && traderEvent.Contains(HumanoidInstance) && traderEvent.Trader != null && !traderEvent.Trader.HasDisposed && traderEvent.Trader.ActiveBehaviour is TraderBehaviour traderBehaviour && traderBehaviour.TraderType.IdleDoNotWalk)
				{
					return false;
				}
			}
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(walkSpeed).FailAtCondition(ShouldFail);
			GoapAction traderIdleWaitStart = GeneralActions.Instant("Trader-Idle-Wait");
			traderIdleWaitStart.OnInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.GenerateNewAnimationRnd(base.AgentOwner);
			};
			yield return traderIdleWaitStart;
			yield return GeneralActions.Instant().TriggerAnimation("Bored", ActionAnimationMode.WaitForCompletion);
			yield return GeneralActions.Wait(UnityEngine.Random.value * 0.8f + 0.25f);
			if (!ShouldNpcWalkIdle())
			{
				yield return GeneralActions.Wait(UnityEngine.Random.value * 3f + 0.5f);
				yield return JumpActions.Jump(traderIdleWaitStart);
			}
			yield return GeneralActions.Instant().FailAtCondition(delegate
			{
				if (traderBehaviour == null)
				{
					return true;
				}
				if (ShouldFail())
				{
					return true;
				}
				if (nearestTradingPost == null)
				{
					return false;
				}
				RotateHuman(HumanoidInstance, nearestTradingPost);
				MonoSingleton<NPCController>.Instance.ShowGoodsOnTradingPost(nearestTradingPost, traderBehaviour);
				return false;
			});
			yield return GeneralActions.Wait(UnityEngine.Random.value * 2f + 0.75f);
		}

		private void RotateHuman(HumanoidInstance humanoidInstance, TradingPostComponentInstance tradingPostComponentInstance)
		{
			if (tradingPostComponentInstance != null && humanoidInstance != null && !(tradingPostComponentInstance.Blueprint == null) && !tradingPostComponentInstance.HasDisposed)
			{
				Vec3Int.GetBounds(tradingPostComponentInstance.Positions, out var min, out var max);
				Vector3 objectPosition = (GridUtils.GetWorldPosition(min) + GridUtils.GetWorldPosition(max)) * 0.5f;
				if (tradingPostComponentInstance.Blueprint.TurnAwayFromCenter)
				{
					humanoidInstance.FaceAway(objectPosition);
				}
				else if (tradingPostComponentInstance.Blueprint.TurnTowardsCenter)
				{
					humanoidInstance.FaceObject(objectPosition);
				}
			}
		}

		private bool PrepareData()
		{
			if (!MonoSingleton<NPCController>.IsInstantiated() || base.AgentOwner == null || base.AgentOwner.HasDisposed)
			{
				return false;
			}
			if (random == null)
			{
				random = new System.Random();
			}
			walkSpeed = (float)random.NextDouble() * 0.05f + 0.575f;
			Vec3Int lhs = Vec3Int.zero;
			CreatureBase creatureBase = HumanoidInstance.CombatAi.GetState<CreatureBase>(CombatAiState.FollowTarget);
			if (this.traderBehaviour == null && creatureBase != null)
			{
				lhs = creatureBase.Map.IdlePoints.GetIdlePointForEnemy(creatureBase).Position;
				SetTarget(TargetIndex.A, new TargetObject(lhs));
				return true;
			}
			CreatureBase creatureBase2 = (CreatureBase)base.AgentOwner;
			TraderBehaviour traderBehaviour = (creatureBase2 as HumanoidInstance)?.ActiveBehaviour as TraderBehaviour;
			if (traderBehaviour != null && traderBehaviour.TraderType == null)
			{
				return false;
			}
			if (traderBehaviour?.TraderType != null && traderBehaviour.TraderType.StandsOnTheMapEdge)
			{
				lhs = creatureBase2.Map.IdlePoints.GetIdlePointForTrader(creatureBase2).Position;
				SetTarget(TargetIndex.A, new TargetObject(lhs));
				return true;
			}
			SetTarget(TargetIndex.A, new TargetObject(lhs));
			lock (syncObj)
			{
				if (nearestTradingPost != null && !CanUseTradingPost(nearestTradingPost))
				{
					if (this.traderBehaviour != null)
					{
						this.traderBehaviour.TradingPostComponentInstance = null;
						this.traderBehaviour.TradingPostReservedPosition = Vec3Int.zero;
					}
					nearestTradingPost = null;
					this.traderBehaviour = null;
				}
				if (this.traderBehaviour == null && creatureBase2 is HumanoidInstance { ActiveBehaviour: TraderBehaviour activeBehaviour })
				{
					this.traderBehaviour = activeBehaviour;
					if (this.traderBehaviour.TradingPostComponentInstance != null)
					{
						nearestTradingPost = this.traderBehaviour.TradingPostComponentInstance;
						MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
						{
							MonoSingleton<NPCController>.Instance.ShowGoodsOnTradingPost(nearestTradingPost, this.traderBehaviour);
						});
					}
					else
					{
						nearestTradingPost = IdlePointManager.GetNearestTradingPost(creatureBase2);
					}
				}
				if (this.traderBehaviour != null && nearestTradingPost == null && this.traderBehaviour.TradingPostComponentInstance == null)
				{
					nearestTradingPost = IdlePointManager.GetNearestTradingPost(creatureBase2);
				}
				if (this.traderBehaviour != null && nearestTradingPost != null)
				{
					using PooledList<Vec3Int> pooledList = nearestTradingPost.WorkplacePositions.WherePooled(CheckMarketStallPositionValid);
					Vec3Int humanPosition = HumanoidInstance.GetGridPosition();
					if (pooledList.Contains(humanPosition))
					{
						if (MonoSingleton<NPCManager>.Instance.AnyNpc(delegate(HumanoidInstance npc)
						{
							if (this.traderBehaviour != npc.TraderBehaviour)
							{
								TraderBehaviour obj = npc.TraderBehaviour;
								if (obj == null)
								{
									return false;
								}
								return obj.TradingPostReservedPosition == humanPosition;
							}
							return false;
						}))
						{
							pooledList.Remove(humanPosition);
						}
						else
						{
							lhs = humanPosition;
							this.traderBehaviour.TradingPostReservedPosition = lhs;
							this.traderBehaviour.TradingPostReservedPositionIndex = nearestTradingPost.WorkplacePositions.IndexOf(lhs);
							this.traderBehaviour.TradingPostBuildingInstance = nearestTradingPost.OwnerBuilding;
							this.traderBehaviour.TradingPostComponentInstance = nearestTradingPost;
						}
					}
					if (lhs == Vec3Int.zero)
					{
						pooledList.ShuffleInPlace();
						while (pooledList.Count > 0)
						{
							Vec3Int pos = pooledList[0];
							pooledList.RemoveAt(0);
							Debug.Log($"**** GETTING POS {pos} ---- ");
							bool flag = MonoSingleton<NPCManager>.Instance.AnyNpc(delegate(HumanoidInstance npc)
							{
								if (npc.TraderBehaviour != this.traderBehaviour)
								{
									TraderBehaviour obj = npc.TraderBehaviour;
									if (obj == null)
									{
										return false;
									}
									return obj.TradingPostReservedPosition == pos;
								}
								return false;
							});
							Debug.Log($"****  {pos} othersAlreadyGotThisPosition  {flag} ---- ");
							if (!flag)
							{
								lhs = pos;
								this.traderBehaviour.TradingPostReservedPosition = lhs;
								this.traderBehaviour.TradingPostReservedPositionIndex = nearestTradingPost.WorkplacePositions.IndexOf(lhs);
								this.traderBehaviour.TradingPostBuildingInstance = nearestTradingPost.OwnerBuilding;
								this.traderBehaviour.TradingPostComponentInstance = nearestTradingPost;
								break;
							}
						}
					}
				}
			}
			if (lhs.Equals(Vec3Int.zero))
			{
				MapNode idlePointForTrader = creatureBase2.Map.IdlePoints.GetIdlePointForTrader(creatureBase2);
				if (idlePointForTrader == null)
				{
					return false;
				}
				lhs = idlePointForTrader.Position;
			}
			SetTarget(TargetIndex.A, new TargetObject(lhs));
			return true;
		}

		private bool CanUseTradingPost(TradingPostComponentInstance tradingPost)
		{
			if (tradingPost.HasDisposed || tradingPost.Underwater || tradingPost.IsOnFire)
			{
				return false;
			}
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				if (!item.HasDied && !item.HasDisposed && item.IsTrader() && item.TraderBehaviour != traderBehaviour && item.TraderBehaviour.TradingPostComponentInstance == tradingPost)
				{
					return false;
				}
			}
			return true;
		}

		private bool CheckMarketStallPositionValid(Vec3Int item)
		{
			if (!PathfinderUtil.IsPathPossible(traderBehaviour.Humanoid, item, traderBehaviour.GetGridPosition()))
			{
				return false;
			}
			foreach (HumanoidInstance item2 in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				if (!item2.HasDied && !item2.HasDisposed && item2 != traderBehaviour.Humanoid && item2.IsTrader() && item2.TraderBehaviour != null && item2.TraderBehaviour.TradingPostBuildingInstance != null && item2.TraderBehaviour.TradingPostReservedPosition == item)
				{
					return false;
				}
			}
			return true;
		}

		private bool ShouldFail()
		{
			if (nearestTradingPost == null || nearestTradingPost.HasDisposed)
			{
				return false;
			}
			if (!nearestTradingPost.Underwater)
			{
				return nearestTradingPost.IsOnFire;
			}
			return true;
		}
	}
}
