using System;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Flight.StartLocations;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class AutoUprightScript : MonoBehaviour
	{
		private AircraftScript _aircraftScript;

		private AiCsFollowCourse _followCourseControlSystem;

		private float _notUprightStartTime;

		private Transform _orientedCom;

		[SerializeField]
		private bool _pointTowardNextWaypointOnUpright = true;

		[SerializeField]
		private bool _showAutoRightCountdownMessage = true;

		private float _timeToDisplayAutoRightMessage;

		[SerializeField]
		private float _timeToSelfRight = 5f;

		public bool ShowAutoRightCountdownMessage
		{
			get
			{
				return _showAutoRightCountdownMessage;
			}
			set
			{
				_showAutoRightCountdownMessage = value;
			}
		}

		public float TimeToSelfRight
		{
			get
			{
				return _timeToSelfRight;
			}
			set
			{
				_timeToSelfRight = value;
				_timeToDisplayAutoRightMessage = _timeToSelfRight * 0.5f;
			}
		}

		public float TimeUpsideDown
		{
			get
			{
				if (_notUprightStartTime > 0f)
				{
					return Time.time - _notUprightStartTime;
				}
				return 0f;
			}
		}

		private Vector3 NextWaypoint
		{
			get
			{
				if (_followCourseControlSystem != null)
				{
					return _followCourseControlSystem.CurrentLocation;
				}
				throw new NotImplementedException();
			}
		}

		public void SetUpright()
		{
			if (_pointTowardNextWaypointOnUpright)
			{
				_aircraftScript.LookAt(NextWaypoint, Vector3.up);
			}
			PositionUtility.PositionAtAvailableLocation(new StartLocation(_aircraftScript.GlobalPosition, new Vector3(0f, _aircraftScript.Rotation.y, 0f), 0f, true), _aircraftScript, allowRepositioning: false, floatOriginToLocation: true);
		}

		protected virtual void Start()
		{
			_aircraftScript = GetComponentInParent<AircraftScript>();
			if (_aircraftScript == null)
			{
				Debug.LogError("AutoUprightScript requires an AircraftScript", this);
			}
			_orientedCom = _aircraftScript.MainCockpit.transform.Find("CenterOfMass");
			_timeToDisplayAutoRightMessage = _timeToSelfRight * 0.5f;
			if (_pointTowardNextWaypointOnUpright)
			{
				throw new NotImplementedException();
			}
			ShowAutoRightCountdownMessage = _aircraftScript.IsPrimaryLocalPlayer;
		}

		protected virtual void Update()
		{
			if (ShowAutoRightCountdownMessage && TimeUpsideDown >= _timeToDisplayAutoRightMessage)
			{
				float num = TimeToSelfRight - TimeUpsideDown;
				if (num > 0f)
				{
					FlightSceneScript.Instance.FlightUI.ShowMessage($"Auto flip in {num:n1}s...", 0.2f);
				}
			}
			MonitorUprightStatus();
			if (UnityEngine.Input.GetKeyUp(KeyCode.U))
			{
				SetUpright();
			}
		}

		private bool IsUpright()
		{
			Vector3 lhs = -_orientedCom.TransformDirection(Vector3.up);
			bool result = true;
			if (Vector3.Dot(lhs, Vector3.up) > 0f)
			{
				lhs *= -1f;
				result = false;
			}
			return result;
		}

		private void MonitorUprightStatus()
		{
			if (!IsUpright())
			{
				if (_notUprightStartTime <= 0f)
				{
					_notUprightStartTime = Time.time;
				}
				else if (TimeUpsideDown >= TimeToSelfRight)
				{
					SetUpright();
				}
			}
			else
			{
				_notUprightStartTime = 0f;
			}
		}
	}
}
