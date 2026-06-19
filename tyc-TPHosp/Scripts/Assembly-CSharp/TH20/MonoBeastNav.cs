using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace TH20
{
	public class MonoBeastNav : MonoBeastState
	{
		private int _pathPoint;

		private List<Vector3> _pathPoints;

		protected MonoBeastNav(MonoBeast beast)
			: base(beast)
		{
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			ReachedDestination();
		}

		protected bool MoveTo(Vector3 destination)
		{
			NavMeshPath navMeshPath = new NavMeshPath();
			_pathPoint = 0;
			UnityEngine.AI.NavMesh.CalculatePath(_beast.Position, destination, -1, navMeshPath);
			if (navMeshPath.status != NavMeshPathStatus.PathInvalid)
			{
				_pathPoints = navMeshPath.corners.ToList();
				_pathPoints.Add(destination);
				return true;
			}
			return false;
		}

		public override void Update()
		{
			base.Update();
			if (_pathPoints == null)
			{
				return;
			}
			Vector3 position = _beast.Position;
			Vector3 normalized = (_pathPoints[_pathPoint] - position).normalized;
			position += normalized * _beast.Definition.MovementSpeed * GameTime.deltaTime;
			if (Vector3.Distance(position, _pathPoints[_pathPoint]) < 0.5f)
			{
				_pathPoint++;
				if (_pathPoint == _pathPoints.Count)
				{
					ReachedDestination();
				}
			}
			position.y = 0f;
			_beast.Position = position;
			_beast.Rotation = Mathf.Atan2(normalized.x, normalized.z) * 57.29578f + 90f;
		}

		public virtual void ReachedDestination()
		{
			_pathPoints = null;
		}
	}
}
