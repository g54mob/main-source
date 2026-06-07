using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.AI.ControlFunctions;
using Jundroo.Common.Events;
using SWS;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlSystems
{
	public class AiCsFollowCourse : AiCsFlyToLocation<AiCfFlyToLocation>
	{
		public class NewWaypointTargetedEventArgs : EventArgs
		{
			public PathManager PathManager { get; private set; }

			public Transform PathWaypoint { get; private set; }

			public int WaypointNumber { get; private set; }

			public Vector3 WorldPosition { get; private set; }

			public NewWaypointTargetedEventArgs(Vector3 worldPosition, int waypointNumber, PathManager pathManager, Transform pathWaypoint)
			{
				WorldPosition = worldPosition;
				WaypointNumber = waypointNumber;
				PathManager = pathManager;
				PathWaypoint = pathWaypoint;
			}
		}

		private List<Vector3> _absoluteCourseLocations = new List<Vector3>();

		private int _currentLocation;

		private Func<Vector3> _getNextCourseLocationAction;

		private Transform _pathCurrentWaypointWorldLocation;

		private PathManager _pathManager;

		public bool AutoAdvanceWaypoint { get; set; }

		public Vector3 CurrentLocation => Utility.ConvertAbsoluteToFloatingOriginPosition(_absoluteCourseLocations[_currentLocation]);

		public int CurrentLocationNumber => _currentLocation;

		public event EventHandler<NewWaypointTargetedEventArgs> NewWaypointTargeted
		{
			add
			{
				_newWaypointTargeted += WeakEventHandler.Create(value, delegate(EventHandler<NewWaypointTargetedEventArgs> x)
				{
					_newWaypointTargeted -= x;
				});
			}
			remove
			{
				_newWaypointTargeted -= WeakEventHandler.FindUnregisterHandler(this._newWaypointTargeted, value);
			}
		}

		private event EventHandler<NewWaypointTargetedEventArgs> _newWaypointTargeted;

		public void ForceNextWaypoint()
		{
			GoToNextWaypoint();
		}

		public override void Initialize(AiControlledAircraftScript aiControlledAircraft)
		{
			base.Initialize(aiControlledAircraft);
			ClearCourseLocations();
			AutoAdvanceWaypoint = true;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			if (AutoAdvanceWaypoint && (base.AiControlledAircraft.DistanceToFinalTarget < 100f || (base.AiControlledAircraft.DistanceToFinalTarget < 200f && base.AiControlledAircraft.ClosingSpeed < 0f)) && _absoluteCourseLocations.Count > 0)
			{
				GoToNextWaypoint();
			}
		}

		public void SetCourseLocations(Func<Vector3> getNextCourseLocationActionWorldCoordinates)
		{
			ClearCourseLocations();
			_getNextCourseLocationAction = getNextCourseLocationActionWorldCoordinates;
			GoToNextWaypoint();
		}

		public void SetCourseLocations(List<Vector3> worldLocations)
		{
			ClearCourseLocations();
			if (worldLocations == null)
			{
				return;
			}
			foreach (Vector3 worldLocation in worldLocations)
			{
				_absoluteCourseLocations.Add(Utility.ConvertFloatingOriginToAbsolutePosition(worldLocation));
			}
			base.AiControlledAircraft.SetTarget(Utility.ConvertAbsoluteToFloatingOriginPosition(_absoluteCourseLocations[0]), mainTarget: true);
		}

		public void SetCourseLocations(PathManager pathManager)
		{
			ClearCourseLocations();
			_pathManager = pathManager;
			for (int i = 0; i < pathManager.transform.childCount; i++)
			{
				Vector3 position = pathManager.transform.GetChild(i).position;
				_absoluteCourseLocations.Add(Utility.ConvertFloatingOriginToAbsolutePosition(position));
			}
			_currentLocation = 0;
			_pathCurrentWaypointWorldLocation = _pathManager.waypoints[_currentLocation];
			base.AiControlledAircraft.SetTarget(_pathCurrentWaypointWorldLocation.position, mainTarget: true);
			RaiseNewWaypointTargeted(_pathCurrentWaypointWorldLocation.position, _currentLocation, _pathManager, _pathCurrentWaypointWorldLocation);
		}

		protected void ClearCourseLocations()
		{
			_getNextCourseLocationAction = null;
			_absoluteCourseLocations.Clear();
			_pathManager = null;
			_pathCurrentWaypointWorldLocation = null;
			_currentLocation = 0;
		}

		private void GoToNextWaypoint()
		{
			if (_getNextCourseLocationAction == null)
			{
				_currentLocation++;
				if (_absoluteCourseLocations.Count > 0)
				{
					if (_absoluteCourseLocations.Count <= _currentLocation)
					{
						_currentLocation = 0;
					}
					Vector3 vector = Utility.ConvertAbsoluteToFloatingOriginPosition(_absoluteCourseLocations[_currentLocation]);
					base.AiControlledAircraft.SetTarget(vector, mainTarget: true);
					Transform pathCurrentWaypointWorldLocation = null;
					if (_pathManager != null)
					{
						pathCurrentWaypointWorldLocation = _pathManager.waypoints[_currentLocation];
					}
					_pathCurrentWaypointWorldLocation = pathCurrentWaypointWorldLocation;
					RaiseNewWaypointTargeted(vector, _currentLocation, _pathManager, _pathCurrentWaypointWorldLocation);
				}
			}
			else
			{
				Vector3 vector2 = _getNextCourseLocationAction();
				base.AiControlledAircraft.SetTarget(vector2, mainTarget: true);
				RaiseNewWaypointTargeted(vector2, 0, null, null);
			}
		}

		private void RaiseNewWaypointTargeted(Vector3 worldPosition, int waypointNumber, PathManager pathManager, Transform pathWaypoint)
		{
			if (this._newWaypointTargeted == null)
			{
				return;
			}
			Delegate[] invocationList = this._newWaypointTargeted.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<NewWaypointTargetedEventArgs> eventHandler = (EventHandler<NewWaypointTargetedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new NewWaypointTargetedEventArgs(worldPosition, waypointNumber, pathManager, pathWaypoint));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}
	}
}
