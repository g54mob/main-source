using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Tracker
{
	public class TrackerManager : MonoBehaviour
	{
		public float FollowDistance = 40f;

		public GameObject TrackerPrefab;

		internal bool Initialized;

		private RaceSpline _spline;

		private NimbatusDrone _masterDrone;

		private float _brainPositionAlongSpline;

		private readonly List<TrackerData> _trackers = new List<TrackerData>();

		public void Init(NimbatusDrone masterDrone, RaceSpline spline)
		{
			_spline = spline;
			_masterDrone = masterDrone;
			_brainPositionAlongSpline = GetCurrentPosition(_masterDrone.RootDronePart.transform, 0f, _spline.Length, 10f);
			Initialized = true;
		}

		public void AddDronePart(DronePart sensor)
		{
			if (Initialized)
			{
				TrackerData trackerData = new TrackerData();
				trackerData.Sensor = sensor;
				trackerData.PositionAlongSpline = GetCurrentPosition(sensor.transform, 0f, _spline.Length, 10f);
				float num = trackerData.PositionAlongSpline + FollowDistance;
				num = ((!(num < _spline.Length)) ? trackerData.PositionAlongSpline : (trackerData.PositionAlongSpline + FollowDistance));
				trackerData.TargetPosition = _spline.GetLocationAlongSplineAtDistance(num) + _spline.transform.position;
				trackerData.Visualizer = Object.Instantiate(TrackerPrefab, trackerData.TargetPosition, Quaternion.identity);
				_trackers.Add(trackerData);
			}
		}

		public void RemoveDronePart(DronePart part)
		{
			if (Initialized)
			{
				TrackerData trackerData = _trackers.FirstOrDefault((TrackerData t) => t.Sensor == part);
				if (trackerData != null && _trackers.Contains(trackerData))
				{
					_trackers.Remove(trackerData);
					Object.Destroy(trackerData.Visualizer);
					trackerData.Visualizer = null;
				}
			}
		}

		public void Update()
		{
			if (!Initialized)
			{
				return;
			}
			foreach (TrackerData tracker in _trackers)
			{
				if (tracker.Visualizer != null)
				{
					tracker.Visualizer.transform.position = Vector3.MoveTowards(tracker.Visualizer.transform.position, tracker.TargetPosition, (tracker.Visualizer.transform.position - tracker.TargetPosition).magnitude * (Time.deltaTime * 10f));
					tracker.Visualizer.transform.rotation = CubicBezierCurve.GetRotationFromTangent(_spline.GetTangentAlongSplineAtDistance(tracker.TargetPositionAlongSpline)) * Quaternion.Euler(90f, 0f, 90f);
				}
			}
		}

		public void FixedUpdate()
		{
			if (!Initialized)
			{
				return;
			}
			_brainPositionAlongSpline = GetCurrentPosition(_masterDrone.RootDronePart.transform, _brainPositionAlongSpline - 20f, _brainPositionAlongSpline + 20f, 1f) + 1f;
			if (_brainPositionAlongSpline > _spline.Length)
			{
				if (_spline.ForkTargetSpline != null)
				{
					_spline = _spline.ForkTargetSpline;
					_brainPositionAlongSpline = GetCurrentPosition(_masterDrone.RootDronePart.transform, 0f, _spline.Length, 10f);
				}
				else if (_spline.Loop)
				{
					_brainPositionAlongSpline -= _spline.Length;
				}
				else if (!_spline.Loop)
				{
					_brainPositionAlongSpline = _spline.Length;
				}
			}
			else if (_brainPositionAlongSpline < 0f)
			{
				if (_spline.Loop)
				{
					_brainPositionAlongSpline += _spline.Length;
				}
				else if (!_spline.Loop)
				{
					_brainPositionAlongSpline = 0f;
				}
			}
			foreach (TrackerData item in _trackers.ToList())
			{
				if (item != null && (item.Sensor == null || item.Sensor.IsBroken))
				{
					_trackers.Remove(item);
					Object.Destroy(item.Visualizer);
					item.Visualizer = null;
					continue;
				}
				item.PositionAlongSpline = GetCurrentPosition(item.Sensor.transform, item.PositionAlongSpline - 40f, item.PositionAlongSpline + 40f, 1f);
				item.TargetPositionAlongSpline = item.PositionAlongSpline + FollowDistance;
				if (item.TargetPositionAlongSpline > _spline.Length)
				{
					if (_spline.ForkTargetSpline != null)
					{
						_spline = _spline.ForkTargetSpline;
						item.PositionAlongSpline = GetCurrentPosition(item.Sensor.transform, 0f, _spline.Length, 10f);
						item.TargetPositionAlongSpline = item.PositionAlongSpline + FollowDistance;
					}
					else if (_spline.Loop)
					{
						item.PositionAlongSpline -= _spline.Length;
						item.TargetPositionAlongSpline -= _spline.Length;
					}
					else if (!_spline.Loop)
					{
						item.TargetPositionAlongSpline = _spline.Length;
					}
				}
				else if (item.TargetPositionAlongSpline < 0f)
				{
					if (_spline.Loop)
					{
						item.PositionAlongSpline += _spline.Length;
						item.TargetPositionAlongSpline += _spline.Length;
					}
					else
					{
						item.TargetPositionAlongSpline = 0f;
					}
				}
				item.TargetPosition = _spline.GetLocationAlongSplineAtDistance(item.TargetPositionAlongSpline) + _spline.transform.position;
				Debug.DrawLine(item.TargetPosition + Vector3.up * 50f, item.TargetPosition + Vector3.down * 50f, Color.magenta);
				Debug.DrawLine(item.TargetPosition + Vector3.left * 50f, item.TargetPosition + Vector3.right * 50f, Color.magenta);
			}
		}

		public float GetCurrentPosition(Transform t, float start, float end, float step)
		{
			float num = float.MaxValue;
			float result = start;
			for (float num2 = start; num2 <= end; num2 += step)
			{
				if (_spline.Loop || (!(num2 < 0f) && !(num2 > _spline.Length)))
				{
					Vector3 vector = _spline.GetLocationAlongSplineAtDistance(num2) + _spline.transform.position;
					float magnitude = (t.position - vector).magnitude;
					if (magnitude < num)
					{
						num = magnitude;
						result = num2;
					}
				}
			}
			return result;
		}

		public Vector3 GetTargetPosition(DronePart sensor)
		{
			TrackerData trackerData = _trackers.Where((TrackerData t) => t.Sensor == sensor).FirstOrDefault();
			if (trackerData != null)
			{
				return trackerData.TargetPosition;
			}
			return Vector3.zero;
		}

		public float GetLastPosition()
		{
			if (_spline.Loop)
			{
				Debug.LogWarning("Doesn't work on looping tracks as is");
				return 0f;
			}
			if (_masterDrone.RootDronePart.HealthPool.IsDead)
			{
				return float.MaxValue;
			}
			float num = float.MaxValue;
			if (_trackers.Count > 0)
			{
				foreach (TrackerData tracker in _trackers)
				{
					if (tracker.PositionAlongSpline < num)
					{
						num = tracker.PositionAlongSpline;
					}
				}
			}
			return Mathf.Min(_brainPositionAlongSpline, num);
		}

		public float GetDroneBrainPosition()
		{
			return _brainPositionAlongSpline;
		}
	}
}
