using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.AI
{
	public class AgentMovement : CTSBehaviour
	{
		private float _actualSpeed;

		private Dictionary<StringKey, float> _speedModifiers = new Dictionary<StringKey, float>();

		[Header("Path Finding")]
		[SerializeField]
		[NavArea(true)]
		private int _areaMask;

		[Header("Debug")]
		[SerializeField]
		private bool _debug;

		[Inject(false)]
		private Agent _agent;

		[Inject(false)]
		private AgentReplaceOnNavmesh _replacer;

		[field: Header("Steering")]
		[field: SerializeField]
		public float MaxSpeed { get; private set; } = 2f;

		[field: SerializeField]
		public float AngularSpeed { get; private set; } = 360f;

		[field: SerializeField]
		public float Acceleration { get; private set; } = 8f;

		[field: SerializeField]
		public float DistanceBeforeRotation { get; private set; } = 1f;

		public float ActualSpeed => _actualSpeed * SpeedModifier;

		public float SpeedModifier { get; private set; } = 1f;

		[field: Header("Obstacle Avoidance")]
		[field: SerializeField]
		public float Radius { get; private set; } = 0.25f;

		[field: SerializeField]
		public float DetectionRange { get; private set; } = 2f;

		public int DefaultAreaMask => _areaMask;

		public int AreaMask { get; private set; }

		public AgentPath CurrentPath { get; private set; }

		public AgentPath BufferPath { get; private set; }

		public MoveTarget CurrentTarget { get; private set; }

		public Tween RotationTween { get; set; }

		public bool HasPath
		{
			get
			{
				AgentPath.ECalculationStatus? eCalculationStatus = CurrentPath?.CalculationStatus;
				if (eCalculationStatus.HasValue)
				{
					return eCalculationStatus == AgentPath.ECalculationStatus.Completed;
				}
				return false;
			}
		}

		public Vector3 Velocity { get; set; }

		protected override void OnAwake()
		{
			base.OnAwake();
			_actualSpeed = MaxSpeed;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			AreaMask = _areaMask;
			Agents.Add(_agent);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			Agents.Remove(_agent);
			ResetPath();
			_speedModifiers.Clear();
			SpeedModifier = 1f;
		}

		private void LateUpdate()
		{
			CheckBufferPath();
		}

		private void CheckBufferPath()
		{
			if (BufferPath != null && BufferPath.CalculationStatus != AgentPath.ECalculationStatus.Pending)
			{
				CurrentPath = BufferPath;
				BufferPath = null;
			}
		}

		public void OverrideDefaultArea(int area)
		{
			bool num = _areaMask == AreaMask;
			_areaMask = area;
			if (num)
			{
				AreaMask = _areaMask;
			}
		}

		public void OverrideNavArea(int? newArea)
		{
			if (newArea.HasValue)
			{
				AreaMask = newArea.Value;
			}
			else
			{
				AreaMask = _areaMask;
			}
		}

		public void SetSpeed(float speed)
		{
			_actualSpeed = speed;
		}

		public NavMeshQueryFilter GetFilter(int? areaMask = null)
		{
			if (!areaMask.HasValue)
			{
				areaMask = AreaMask;
			}
			NavMeshQueryFilter baseQueryFilter = AgentsPathfinding.BaseQueryFilter;
			baseQueryFilter.areaMask = areaMask.Value;
			return baseQueryFilter;
		}

		public NavMeshQueryFilter GetFilter(ref NavMeshQueryFilter? filter)
		{
			if (filter.HasValue)
			{
				return filter.Value;
			}
			NavMeshQueryFilter baseQueryFilter = AgentsPathfinding.BaseQueryFilter;
			baseQueryFilter.areaMask = AreaMask;
			return baseQueryFilter;
		}

		public void SetDestination(Vector3 position, out AgentPath outPath, NavMeshQueryFilter? filter = null)
		{
			outPath = null;
			if (CurrentPath == null || BufferPath == null)
			{
				outPath = AgentsPathfinding.AskForPath(base.transform.position, position, GetFilter(ref filter));
				SetNewPath(outPath);
			}
		}

		public void SetDestination(MoveTarget target, out AgentPath outPath, NavMeshQueryFilter? filter = null)
		{
			outPath = null;
			if (CurrentPath == null || BufferPath == null)
			{
				CurrentTarget = target;
				target.SetUser(_agent);
				outPath = AgentsPathfinding.AskForPath(base.transform, target, GetFilter(ref filter));
				SetNewPath(outPath);
			}
		}

		public void SetDestinationLookAt(Transform target, float lookDistance, out AgentPath outPath, float fov = 0.5f, NavMeshQueryFilter? areaMask = null)
		{
			outPath = null;
			if (CurrentPath == null || BufferPath == null)
			{
				outPath = AgentsPathfinding.AskForPath(base.transform, target, AgentPath.EDestinationType.LookAtDistance, lookDistance, GetFilter(ref areaMask));
				SetNewPath(outPath);
			}
		}

		private void SetNewPath(AgentPath path)
		{
			if (CurrentPath == null)
			{
				CurrentPath = path;
			}
			else
			{
				BufferPath = path;
			}
		}

		public bool CheckDestination(MoveTarget target)
		{
			Vector3 direction = (target.Position - base.transform.position).FlattenY();
			float sqrMagnitude = direction.sqrMagnitude;
			switch (target.DestinationType)
			{
			case AgentPath.EDestinationType.LookAtDistance:
				return CheckDestinationLookAt(direction, target.maxDistance, 0.5f);
			case AgentPath.EDestinationType.Simple:
				if (sqrMagnitude < 0.25f)
				{
					return true;
				}
				break;
			case AgentPath.EDestinationType.Precise:
				if (sqrMagnitude <= 0.0025f && Vector3.Dot(target.transform.forward, base.transform.forward) >= 0.99f)
				{
					return true;
				}
				break;
			}
			return false;
		}

		public bool CheckDestinationLookAt(MoveTarget target, float lookDistance, float fov)
		{
			Vector3 direction = target.Position - base.transform.position;
			return CheckDestinationLookAt(direction, lookDistance, fov);
		}

		public bool CheckDestinationLookAt(Vector3 direction, float lookDistance, float fov)
		{
			lookDistance += 0.5f;
			if (direction.sqrMagnitude < lookDistance * lookDistance)
			{
				if (Vector3.Dot(direction.FlattenY().normalized, base.transform.forward) < fov)
				{
					return false;
				}
				Vector3 position = base.transform.position;
				return AgentsMover.IsLineValidOnStaticWorld(end: position + direction + Vector3.up, start: position + Vector3.up);
			}
			return false;
		}

		public bool IsPointAvailable(Vector3 point, float precision = 0.2f, int? areaMask = null)
		{
			NavMeshHit hit;
			return NavMesh.SamplePosition(point, out hit, precision, areaMask ?? AreaMask);
		}

		public bool IsPointAvailable(Vector3 point, float precision = 0.2f, NavMeshQueryFilter? areaMask = null)
		{
			NavMeshHit hit;
			return NavMesh.SamplePosition(point, out hit, precision, GetFilter(ref areaMask));
		}

		public static bool IsTransformAtDestination(Transform transform, MoveTarget target)
		{
			Vector3 direction = (target.Position - transform.position).FlattenY();
			float sqrMagnitude = direction.sqrMagnitude;
			switch (target.DestinationType)
			{
			case AgentPath.EDestinationType.LookAtDistance:
				return IsTransformAtDestinationLookAt(transform, direction, target.maxDistance, 0.5f);
			case AgentPath.EDestinationType.Simple:
				if (sqrMagnitude < 0.25f)
				{
					return true;
				}
				break;
			case AgentPath.EDestinationType.Precise:
				if (sqrMagnitude <= 0.0025f && Vector3.Dot(target.transform.forward, transform.forward) >= 0.99f)
				{
					return true;
				}
				break;
			}
			return false;
		}

		public static bool IsTransformAtDestinationSimple(Transform transform, Vector3 targetPosition, float distancePadding = 0.5f)
		{
			return Vector3.Distance(transform.position, targetPosition) < distancePadding;
		}

		public static bool IsTransformAtDestinationPrecise(Transform transform, Vector3 targetPosition, Vector3 targetForward)
		{
			if (Vector3.Distance(transform.position, targetPosition) < 0.04f && Vector3.Dot(transform.forward, targetForward) >= 0.99f)
			{
				return true;
			}
			return false;
		}

		public static bool IsTransformAtDestinationLookAt(Transform transform, MoveTarget target, float lookDistance, float fov)
		{
			Vector3 direction = target.Position - transform.position;
			return IsTransformAtDestinationLookAt(transform, direction, lookDistance, fov);
		}

		public static bool IsTransformAtDestinationLookAt(Transform transform, Vector3 direction, float lookDistance, float fov)
		{
			lookDistance += 0.5f;
			if (direction.sqrMagnitude < lookDistance * lookDistance)
			{
				if (Vector3.Dot(direction.FlattenY().normalized, transform.forward) < fov)
				{
					return false;
				}
				Vector3 position = transform.position;
				Vector3 end = position + direction;
				return AgentsMover.IsLineValidOnStaticWorld(position, end);
			}
			return false;
		}

		public void FaceDirection(Quaternion direction)
		{
			float num = Quaternion.Angle(base.transform.rotation, direction);
			RotationTween?.Kill();
			RotationTween = base.transform.DORotateQuaternion(direction, num * 0.005f).SetEase(Ease.OutQuad);
		}

		public void ResetPath()
		{
			if ((bool)CurrentTarget && CurrentTarget.User == _agent)
			{
				CurrentTarget.SetUser(null);
			}
			CurrentTarget = null;
			CurrentPath = null;
			BufferPath = null;
		}

		public void AddSpeedModifier(StringKey key, float value)
		{
			if (!_speedModifiers.TryGetValue(key, out var value2) || value2 != value)
			{
				_speedModifiers[key] = value;
				UpdateSpeedModifier();
			}
		}

		public void RemoveSpeedModifier(StringKey key)
		{
			_speedModifiers.Remove(key);
			UpdateSpeedModifier();
		}

		private void UpdateSpeedModifier()
		{
			SpeedModifier = 1f;
			foreach (KeyValuePair<StringKey, float> speedModifier in _speedModifiers)
			{
				SpeedModifier *= speedModifier.Value;
			}
		}

		private void OnDrawGizmos()
		{
			AgentPath.ECalculationStatus? eCalculationStatus = CurrentPath?.CalculationStatus;
			if (!eCalculationStatus.HasValue || eCalculationStatus != AgentPath.ECalculationStatus.Completed || !_debug)
			{
				return;
			}
			PathCorner[] corners = CurrentPath.Corners;
			for (int i = 0; i < corners.Length - 1; i++)
			{
				if (corners[i].IsOffLinkEntry)
				{
					Gizmos.color = Color.blue;
				}
				else
				{
					Gizmos.color = Color.white;
				}
				Gizmos.DrawLine(corners[i], corners[i + 1]);
				Gizmos.color = Color.red;
				Gizmos.DrawLine(corners[i], corners[i] + Vector3.up * corners[i].TurnAngle / 360f);
				Gizmos.color = Color.magenta;
				Gizmos.DrawLine(corners[i], corners[i] + corners[i].Normal.ToHorizontal3D());
			}
			Gizmos.color = Color.magenta;
			Gizmos.DrawSphere(CurrentPath.CurrentCorner, 0.5f);
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(base.transform.position, CurrentPath.CurrentCorner);
		}
	}
}
