using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.WorldObjects.Splines;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Events;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Spawners;
using Dreamteck.Splines;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains
{
	public class TrainTrackScript : MonoBehaviour
	{
		[Serializable]
		private struct SplineIndexAndOffset
		{
			public int SplineIndex;

			public float SnapToGroundOffset;
		}

		private static class Profile
		{
			public static readonly ProfilerMarker OnFloatingOriginRepositioned = new ProfilerMarker("TrainTrackScript.OnFloatingOriginRepositioned");
		}

		public const string TrackAssetsRootAssetsPath = "Assets/Content/Flight/WorldObjects/Vehicles/Land/Trains/Tracks/";

		public const string TrackPrefabsRootAssetsPath = "Assets/Resources/Flight/WorldObjects/Vehicles/Land/Trains/Tracks/";

		public const string TrackPrefabsRootResourcesPath = "Flight/WorldObjects/Vehicles/Land/Trains/Tracks/";

		[SerializeField]
		private string _id;

		private List<SplineMeshSegment> _segments;

		[SerializeField]
		private float _snapToGroundOffset;

		[SerializeField]
		private List<SplineIndexAndOffset> _snapToGroundOffsetsPerSplinePoint;

		[SerializeField]
		private TrainSpawnerClientScript _spawner;

		[SerializeField]
		private SplineComputer _spline;

		public HashSet<int> ColliderIds { get; private set; }

		public string Id => _id;

		public IReadOnlyList<SplineMeshSegment> Segments => _segments;

		public TrainSpawnerClientScript Spawner => _spawner;

		public SplineComputer Spline => _spline;

		protected virtual void Awake()
		{
			if (_spline == null)
			{
				Debug.LogError("Train track '" + _id + "' is unable to find its spline.");
				return;
			}
			if (_spline.sampleMode != SplineComputer.SampleMode.Uniform)
			{
				Debug.LogError("Train track '" + _id + "' uses a non-uniform sample mode.");
			}
			_spawner.TrainLoaded += OnTrainLoaded;
			_segments = new List<SplineMeshSegment>();
			GetComponentsInChildren(includeInactive: true, _segments);
			ColliderIds = new HashSet<int>();
			foreach (SplineMeshSegment segment in _segments)
			{
				ColliderIds.Add(segment.MeshCollider.GetInstanceID());
			}
			TrainManagerScript.EnqueueAction(delegate(TrainManagerScript x)
			{
				x.RegisterTrack(this);
			});
			FloatingOriginScript.Instance.Repositioned += OnFloatingOriginRepositioned;
		}

		protected virtual void OnDestroy()
		{
			_spawner.TrainLoaded -= OnTrainLoaded;
			foreach (TrainScript train in _spawner.Trains)
			{
				train.SetTrack(null);
			}
			TrainManagerScript.Instance?.UnregisterTrack(this);
			if ((object)FloatingOriginScript.Instance != null)
			{
				FloatingOriginScript.Instance.Repositioned -= OnFloatingOriginRepositioned;
			}
		}

		private void OnFloatingOriginRepositioned(object sender, FloatingOriginUpdatedEventArgs e)
		{
			using (Profile.OnFloatingOriginRepositioned.Auto())
			{
				Spline.RebuildImmediate(calculateSamples: false);
			}
		}

		private void OnTrainLoaded(object sender, TrainEventArgs e)
		{
			e.Train.SetTrack(this);
		}
	}
}
