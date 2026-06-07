using System.Collections.Generic;
using CTS.AI;
using CTS.Core;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class PathLockerRecalculator : CTSSingleton<PathLockerRecalculator>
	{
		private List<PathLocker> _pathsLocked = new List<PathLocker>();

		private int _currentIndex;

		private NavMeshPath _dummyPath;

		protected override void SingletonAwake()
		{
			PathLocker.ObjectBecameUnpathable += OnObjectBecameUnpathable;
		}

		protected override void OnSingletonDestroy()
		{
			PathLocker.ObjectBecameUnpathable -= OnObjectBecameUnpathable;
		}

		private void Update()
		{
			if (_pathsLocked.Count > 0)
			{
				if (_currentIndex >= _pathsLocked.Count)
				{
					_currentIndex = 0;
				}
				RecalculateCurrent();
				_currentIndex++;
			}
		}

		private void RecalculateCurrent()
		{
			PathLocker pathLocker = _pathsLocked[_currentIndex];
			if (pathLocker == null)
			{
				_pathsLocked.RemoveAt(_currentIndex);
				_currentIndex--;
				return;
			}
			Transform exitNavMeshCheck = EntranceResolver.ExitNavMeshCheck;
			if (!(exitNavMeshCheck == null))
			{
				if (_dummyPath == null)
				{
					_dummyPath = new NavMeshPath();
				}
				NavMesh.CalculatePath(pathLocker.transform.position, exitNavMeshCheck.position, AgentsMover.AllAreas, _dummyPath);
				if (_dummyPath.status == NavMeshPathStatus.PathComplete)
				{
					pathLocker.SetPathable();
					_pathsLocked.Remove(pathLocker);
					_currentIndex--;
				}
			}
		}

		private void OnObjectBecameUnpathable(PathLocker pathLocker)
		{
			if (!_pathsLocked.Contains(pathLocker))
			{
				_pathsLocked.Add(pathLocker);
			}
		}
	}
}
