using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rowlan.Yapp
{
	[Serializable]
	public class SplineSettings
	{
		public enum AttachMode
		{
			Bounds = 0,
			Between = 1
		}

		public enum Rotation
		{
			[Tooltip("Exactly along the spline")]
			Spline = 0,
			[Tooltip("Rotate along the spline, then add random rotation of prefab")]
			SplineRandom = 1,
			[Tooltip("Rotate according to prefab settings, ignore spline rotation")]
			Prefab = 2
		}

		public enum Separation
		{
			Fixed = 0,
			Range = 1,
			PrefabRadiusBounds = 2,
			PrefabForwardSize = 3,
			PrefabRightSize = 4,
			PrefabUpSize = 5
		}

		public enum SpawnMechanism
		{
			Automatic = 0,
			Manual = 1
		}

		public enum LanePosition
		{
			Both = 0,
			Left = 1,
			Right = 2
		}

		public SpawnMechanism spawnMechanism;

		[Range(0f, 10f)]
		public int curveResolution;

		public bool loop;

		public Separation separation;

		public float separationDistance = 1f;

		public float separationDistanceMin;

		public float separationDistanceMax = 1f;

		public Rotation instanceRotation = Rotation.Prefab;

		public AttachMode attachMode;

		public bool controlPointRotation;

		[Range(1f, 10f)]
		public int lanes = 1;

		public float laneDistance = 1f;

		public bool skipCenterLane;

		public LanePosition lanePosition;

		public bool snap;

		public bool reusePrefabs = true;

		public bool debug;

		public bool dirty;

		public List<GameObject> prefabInstances = new List<GameObject>();

		[SerializeField]
		public List<ControlPoint> controlPoints = new List<ControlPoint>();
	}
}
