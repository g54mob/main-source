using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct TeleportStateRequest : IStateRequester
{
	private const float MIN_DISTANCE_SQ_TO_ANY_PLAYER_TO_TELEPORT = 256f;

	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._teleportStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._objectDataGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.Teleport))
		{
			return;
		}
		TeleportStateCD value = c._teleportStateGroup[entity];
		LocalTransform localTransform = c._localTransformGroup[entity];
		ObjectDataCD objectDataCD = c._objectDataGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		if (stateInfo.IsCurrentState(StateID.BirdBossFlyingAbove) || stateInfo.IsCurrentState(StateID.OctopusBossLurkingBelow))
		{
			value.cooldownTimer.Start(d._elapsedTime, 4f);
		}
		else
		{
			if (c._spawnPointGroup.HasComponent(entity))
			{
				value.positionToStayWithin = c._spawnPointGroup[entity].position;
			}
			bool flag = math.all(value.positionToStayWithin == float3.zero) && math.distance(value.positionToStayWithin, localTransform.Position) < 3f;
			if (!value.cooldownTimer.isRunning || (!isInCombatCD.isInCombat && flag))
			{
				value.cooldownTimer.Start(d._elapsedTime, d._rng.NextFloat(value.minCooldown, value.maxCooldown));
			}
			else if (value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
			{
				value.cooldownTimer.Start(d._elapsedTime, 1f);
				bool flag2 = false;
				float3 float5 = float3.zero;
				for (int i = 0; i < d.playerExtrapolatedEntities.Length; i++)
				{
					float3 position = c._localTransformGroup[d.playerExtrapolatedEntities[i]].Position;
					if (math.distancesq(position, localTransform.Position) < 256f)
					{
						float5 = position;
						flag2 = true;
						break;
					}
				}
				if (math.any(value.positionToStayWithin != float3.zero))
				{
					float num = math.distance(value.positionToStayWithin, localTransform.Position);
					if (num > value.allowedRadiusToMoveFromPosition || (!isInCombatCD.isInCombat && num > 2f))
					{
						value.targetDestination = math.round(value.positionToStayWithin);
						stateInfo.EnterState(StateID.Teleport);
						goto IL_04ea;
					}
				}
				if (flag2 && !value.canOnlyTeleportBackToSpawn)
				{
					if (math.all(value.positionToStayWithin == float3.zero))
					{
						value.positionToStayWithin = localTransform.Position;
					}
					for (int j = 0; j < 10; j++)
					{
						bool flag3 = true;
						float3 float6;
						if (c._teleportLocationsBufferGroup.TryGetBuffer(entity, out var bufferData) && bufferData.Length > 0)
						{
							int length = bufferData.Length;
							int num2 = d._rng.NextInt(length);
							float6 = bufferData[num2].position;
							if (math.distancesq(float6, localTransform.Position) < 1f)
							{
								num2 = (num2 + d._rng.NextInt(1, length) - 1) % length;
								float6 = bufferData[num2].position;
							}
						}
						else
						{
							float3 x = d._rng.NextFloat3(-1f, 1f);
							x.y = 0f;
							x = math.normalizesafe(x);
							float6 = math.round(float5 + x * d._rng.NextFloat(value.minTeleportDistanceFromPlayer, value.maxTeleportDistanceFromPlayer));
							if (!isInCombatCD.isInCombat && math.any(value.positionToStayWithin != float3.zero) && math.distance(value.positionToStayWithin, float6) > value.allowedRadiusToMoveFromPosition)
							{
								continue;
							}
							ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, d.database);
							for (int k = entityObjectInfo.prefabCornerOffset.x; k < entityObjectInfo.prefabTileSize.x + entityObjectInfo.prefabCornerOffset.x; k++)
							{
								for (int l = entityObjectInfo.prefabCornerOffset.y; l < entityObjectInfo.prefabTileSize.y + entityObjectInfo.prefabCornerOffset.y; l++)
								{
									float3 float7 = float6 + new float3(k, 0f, l);
									bool num3 = d.tileLookup.HasTypeAndTileset(float7.RoundToInt2(), TileType.wall, 2);
									bool flag4 = value.canOnlyTeleportToNonBlockedGround && d.tileLookup.GetTopType(float7.RoundToInt2()).IsWalkableTile() && !TeleportStateSystem.PositionIsBlocked(d.collisionWorld, float7, 0.49f);
									bool flag5 = !value.canTeleportToPitAndWater && (d.tileLookup.HasType(float7.RoundToInt2(), TileType.water) || d.tileLookup.HasType(float7.RoundToInt2(), TileType.pit));
									flag3 = !num3 && !flag4 && !flag5;
									if (!flag3)
									{
										break;
									}
								}
								if (!flag3)
								{
									break;
								}
							}
						}
						if (flag3)
						{
							value.targetDestination = float6;
							stateInfo.EnterState(StateID.Teleport);
							break;
						}
					}
				}
			}
		}
		goto IL_04ea;
		IL_04ea:
		c._teleportStateGroup[entity] = value;
	}
}
