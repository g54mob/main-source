using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.AI
{
	[Constructor("Construct")]
	public class AgentsMover : CTSSingleton<AgentsMover>
	{
		private struct AgentData
		{
			public AgentMovement MovementComponent;

			public Vector3 Position;

			public Vector3 Forward;

			public float MaxSpeed;

			public float Acceleration;

			public float DetectionRangeSqr;

			public AgentPath Path => MovementComponent.CurrentPath;
		}

		private struct AgentRVOData
		{
			public float Radius;

			public Vector3 LocalPosition;

			public float Distance;

			public AgentRVOData(float p_radius, Vector3 p_localPosition)
			{
				Radius = p_radius;
				LocalPosition = p_localPosition;
				Distance = LocalPosition.magnitude;
			}
		}

		[SerializeField]
		private LayerMask _staticWorldMask = -1;

		[SerializeField]
		[NavArea(true)]
		private int _allAreas = -1;

		[SerializeField]
		private bool _debug;

		private const float Drag = 3f;

		public static int StreetLayer { get; private set; } = 32;

		public static int AllAreas { get; private set; } = -1;

		public static int InteractionAgentID { get; private set; }

		private static int WallFloorLayers => (1 << LayerMask.NameToLayer("Wall")) | (1 << LayerMask.NameToLayer("Floor"));

		public static LayerMask StaticWorldMask { get; private set; }

		private void Construct()
		{
			AllAreas = _allAreas;
		}

		protected override void SingletonAwake()
		{
			StaticWorldMask = _staticWorldMask;
			InteractionAgentID = GetNavMeshAgentID("InteractionAgent").Value;
		}

		private int? GetNavMeshAgentID(string name)
		{
			for (int i = 0; i < NavMesh.GetSettingsCount(); i++)
			{
				NavMeshBuildSettings settingsByIndex = NavMesh.GetSettingsByIndex(i);
				if (name == NavMesh.GetSettingsNameFromID(settingsByIndex.agentTypeID))
				{
					return settingsByIndex.agentTypeID;
				}
			}
			return null;
		}

		protected override void OnSingletonDestroy()
		{
			Agents.ClearAgents();
		}

		private void Update()
		{
			foreach (Agent item in Agents.List)
			{
				UpdateAgentIntendedVelocity(item);
			}
			UpdateAgentsPosition();
			DrawGizmos();
		}

		private static void UpdateAgentIntendedVelocity(Agent p_agent)
		{
			if (ValidatePath(p_agent.Movement.CurrentPath))
			{
				AgentData agent = SetAgentData(p_agent);
				AgentVelocityUpdate(ref agent);
			}
		}

		private static void UpdateAgentsPosition()
		{
			foreach (Agent item in Agents.List)
			{
				Agent agent = item;
				if (agent.Movement.Velocity.sqrMagnitude <= 0f)
				{
					continue;
				}
				if (!agent.Movement.HasPath)
				{
					float num = 3f * Time.deltaTime;
					if (agent.Movement.Velocity.sqrMagnitude < num * num)
					{
						agent.Movement.Velocity = Vector3.zero;
						continue;
					}
					agent.Movement.Velocity -= agent.Movement.Velocity.normalized * num;
				}
				Transform agentTransform = agent.transform;
				agentTransform.position += agent.Movement.Velocity * Time.deltaTime;
				Quaternion currentRotation = agentTransform.rotation;
				if (!agent.Movement.HasPath)
				{
					DefaultRotation();
					continue;
				}
				AgentPath path = agent.Movement.CurrentPath;
				Vector3 vector = path.CurrentCorner - agentTransform.position;
				switch (path.DestinationType)
				{
				case AgentPath.EDestinationType.Precise:
				{
					float num2 = vector.magnitude + path.RemainingDistance;
					if (TryRotate(num2))
					{
						float magnitude = agent.Movement.Velocity.magnitude;
						agent.Movement.Velocity = vector.normalized * magnitude;
						float t = Mathf.InverseLerp(agent.Movement.DistanceBeforeRotation, 0f, num2);
						Quaternion rotation = Quaternion.Lerp(path.StartRotation, path.EndRotation, t);
						agentTransform.rotation = rotation;
					}
					break;
				}
				case AgentPath.EDestinationType.LookAtDistance:
				{
					float num2 = Math.Max(0f, vector.magnitude + path.RemainingDistance - path.DistanceToLookAt);
					if (TryRotate(num2))
					{
						Vector3 vector2 = (path.Target - agentTransform.position).FlattenY();
						path.EndRotation = Quaternion.LookRotation(vector2.normalized, Vector3.up);
						float t = Mathf.InverseLerp(agent.Movement.DistanceBeforeRotation, 0.1f, num2);
						Quaternion rotation = Quaternion.Lerp(path.StartRotation, path.EndRotation, t);
						agentTransform.rotation = rotation;
					}
					break;
				}
				default:
					DefaultRotation();
					break;
				}
				void DefaultRotation()
				{
					Quaternion to = Quaternion.LookRotation(agent.Movement.Velocity.FlattenY().normalized);
					agentTransform.rotation = Quaternion.RotateTowards(currentRotation, to, agent.Movement.AngularSpeed * Time.deltaTime);
				}
				bool TryRotate(float distanceFromEnd)
				{
					if (distanceFromEnd >= agent.Movement.DistanceBeforeRotation)
					{
						path.HasStartedRotating = false;
						DefaultRotation();
						return false;
					}
					if (!path.HasStartedRotating)
					{
						path.HasStartedRotating = true;
						path.StartRotation = currentRotation;
					}
					return true;
				}
			}
		}

		private static bool ValidatePath(AgentPath p_path)
		{
			if (p_path != null && p_path.CalculationStatus == AgentPath.ECalculationStatus.Completed)
			{
				return p_path.PathingStatus < AgentPath.EPathingStatus.Completed;
			}
			return false;
		}

		private static AgentData SetAgentData(Agent p_agent)
		{
			Transform transform = p_agent.transform;
			return new AgentData
			{
				MovementComponent = p_agent.Movement,
				Position = transform.position,
				Forward = transform.forward,
				DetectionRangeSqr = p_agent.Movement.DetectionRange * p_agent.Movement.DetectionRange,
				MaxSpeed = p_agent.Movement.ActualSpeed,
				Acceleration = p_agent.Movement.Acceleration
			};
		}

		private static List<AgentRVOData> SetupRVODataForAgent(ref AgentData agentData)
		{
			List<AgentRVOData> list = new List<AgentRVOData>();
			foreach (Agent item in Agents.List)
			{
				Vector3 p_localPosition = item.transform.position - agentData.Position;
				if (!(p_localPosition.sqrMagnitude > agentData.DetectionRangeSqr) && !(Vector3.Dot(p_localPosition.normalized, agentData.MovementComponent.Velocity.normalized) < 0.1f))
				{
					list.Add(new AgentRVOData(item.Movement.Radius, p_localPosition));
				}
			}
			return list;
		}

		private static void UpdateRVOPath(ref AgentData agentData, List<AgentRVOData> rvoData)
		{
		}

		public static bool IsLineValidOnStaticWorld(Vector3 start, Vector3 end)
		{
			start += Vector3.up;
			end += Vector3.up;
			RaycastHit hitInfo;
			return !Physics.Linecast(start, end, out hitInfo, StaticWorldMask);
		}

		private static void AgentVelocityUpdate(ref AgentData agent)
		{
			AgentPath path = agent.Path;
			Vector3 agentPos = agent.Position;
			Vector3 vectorFromAgentToCurrentCorner = path.CurrentCorner - agentPos;
			float distanceToCurrentCorner = vectorFromAgentToCurrentCorner.magnitude;
			Vector3 agentVelocity = agent.MovementComponent.Velocity;
			Vector3 velocityDir = agentVelocity.normalized;
			CheckIfPathCanBeSimplified(ref agent);
			float remainingDistance = distanceToCurrentCorner + path.RemainingDistance;
			if (path.DestinationType == AgentPath.EDestinationType.LookAtDistance && Math.Max(0f, remainingDistance - path.DistanceToLookAt) < 0.015f)
			{
				Vector3 position = agent.Position;
				Vector3 end = path.Corners[^1];
				if ((path.Target - agentPos).FlattenY().sqrMagnitude < path.DistanceToLookAt * path.DistanceToLookAt && IsLineValidOnStaticWorld(position, end))
				{
					Vector3 vector = path.Target - position;
					path.PathingStatus = AgentPath.EPathingStatus.Completed;
					agent.MovementComponent.ResetPath();
					agent.MovementComponent.Velocity = Vector3.zero;
					agent.MovementComponent.FaceDirection(Quaternion.LookRotation(vector.FlattenY().normalized));
					return;
				}
			}
			if (path.CurrentCorner.IsLastCorner)
			{
				if (distanceToCurrentCorner < 0.025f)
				{
					path.PathingStatus = AgentPath.EPathingStatus.Completed;
					agent.MovementComponent.ResetPath();
					if (path.DestinationType == AgentPath.EDestinationType.Precise)
					{
						agent.MovementComponent.transform.SetPositionAndRotation(path.CurrentCorner, path.EndRotation);
						agent.MovementComponent.Velocity = Vector3.zero;
					}
					return;
				}
			}
			else if (path.CurrentCorner.IsOffLinkEntry)
			{
				TrySetNewCorner(0.2f);
			}
			else
			{
				TrySetNewCorner(0.15f);
			}
			agentVelocity += vectorFromAgentToCurrentCorner.normalized * (Time.deltaTime * agent.Acceleration);
			velocityDir = agentVelocity.normalized;
			float velocityMagnitude = agentVelocity.magnitude;
			ClampVelocityToAgentSpeed(ref agent);
			BrakeIfNecessary(ref agent);
			agent.MovementComponent.Velocity = agentVelocity;
			void BrakeIfNecessary(ref AgentData p_agentData)
			{
				float num = velocityMagnitude * velocityMagnitude;
				float num2 = 1f / 6f;
				float num3 = p_agentData.MaxSpeed * 0.5f;
				float b = num * num2;
				float t = Mathf.InverseLerp(0f, b, remainingDistance);
				float num4 = Mathf.Lerp(0f, velocityMagnitude, t);
				num = num4 * num4;
				float num5 = (num - num3) * num2;
				float num6 = 0f;
				if (distanceToCurrentCorner < num5)
				{
					float num7 = distanceToCurrentCorner;
					foreach (PathCorner remainingCorner in path.RemainingCorners)
					{
						if (remainingCorner.IsLastCorner)
						{
							break;
						}
						float num8 = remainingCorner.TurnAngle * (1f / 180f) * num3;
						b = (num - num8) * num2;
						t = Mathf.InverseLerp(0f, b, distanceToCurrentCorner);
						num4 = Mathf.Lerp(num3, num4, t);
						num6 += num7;
						if (num6 + remainingCorner.DistanceToNext > num5)
						{
							break;
						}
						num7 = remainingCorner.DistanceToNext;
					}
				}
				agentVelocity = velocityDir * num4;
			}
			void CheckIfPathCanBeSimplified(ref AgentData p_agent)
			{
				if (!path.CurrentCorner.IsLastCorner)
				{
					PathCorner nextCorner = path.NextCorner;
					Vector3 vector2 = nextCorner - agentPos;
					NavMeshHit hit;
					if (path.CurrentCorner.IsOffLinkEntry || path.PreviousCorner.IsOffLinkEntry)
					{
						Vector3 dir = path.PreviousCorner.Position - path.CurrentCorner.Position;
						Vector3 dir2 = agentPos - path.CurrentCorner.Position;
						if (!(Vector3.Dot(dir2.normalized, dir.normalized) >= 0f))
						{
							Debug.DrawRay(path.CurrentCorner.Position, dir, Color.cyan, 2f);
							Debug.DrawRay(path.CurrentCorner.Position, dir2, Color.cyan, 2f);
							path.TrySetNextCorner();
							vectorFromAgentToCurrentCorner = vector2;
							distanceToCurrentCorner = vector2.magnitude;
						}
					}
					else if (!((path.NextCorner.Position - agentPos).magnitude > path.CurrentCorner.DistanceToNext) && NavMesh.SamplePosition(p_agent.Position, out hit, 0.025f, AllAreas) && !NavMesh.Raycast(p_agent.Position, nextCorner, out hit, AllAreas))
					{
						Debug.DrawLine(p_agent.Position, nextCorner, Color.green, 5f);
						path.TrySetNextCorner();
						vectorFromAgentToCurrentCorner = vector2;
						distanceToCurrentCorner = vector2.magnitude;
					}
				}
			}
			void ClampVelocityToAgentSpeed(ref AgentData p_agentData)
			{
				if (!(velocityMagnitude <= p_agentData.MaxSpeed))
				{
					agentVelocity = velocityDir * p_agentData.MaxSpeed;
					velocityMagnitude = p_agentData.MaxSpeed;
				}
			}
			void TrySetNewCorner(float distance)
			{
				if (!(distanceToCurrentCorner > distance))
				{
					path.TrySetNextCorner();
					vectorFromAgentToCurrentCorner = path.CurrentCorner - agentPos;
					distanceToCurrentCorner = vectorFromAgentToCurrentCorner.magnitude;
				}
			}
		}

		private void DrawGizmos()
		{
		}
	}
}
