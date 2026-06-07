using System;
using UnityEngine;

namespace Brewery.ZoneDecorator
{
	[Serializable]
	public class ZonePrefabEntry
	{
		[Tooltip("The prefab to spawn")]
		public GameObject prefab;

		[Tooltip("Spawn weight (higher = more common)")]
		[Range(0.1f, 10f)]
		public float weight;

		[Tooltip("Can this item spawn as part of a bundle/group?")]
		public bool canBundle;

		[Tooltip("Minimum items in bundle (if canBundle)")]
		[Range(1f, 10f)]
		public int bundleMinCount;

		[Tooltip("Maximum items in bundle (if canBundle)")]
		[Range(1f, 15f)]
		public int bundleMaxCount;

		[Tooltip("Spacing between bundle items")]
		[Range(0.1f, 3f)]
		public float bundleSpacing;

		[Tooltip("Can bundle items stack vertically?")]
		public bool canStack;

		[Tooltip("Max stack height")]
		[Range(1f, 5f)]
		public int maxStackHeight;

		[Tooltip("Minimum scale")]
		[Range(0.5f, 1.5f)]
		public float minScale;

		[Tooltip("Maximum scale")]
		[Range(0.5f, 1.5f)]
		public float maxScale;

		[Tooltip("Allow random Y rotation")]
		public bool randomYRotation;

		[Tooltip("Align to ground surface")]
		public bool alignToGround;

		[Tooltip("Maximum tilt angle when aligning")]
		[Range(0f, 45f)]
		public float maxTiltAngle;

		[Tooltip("Vertical offset from ground")]
		public float groundOffset;

		[Tooltip("Minimum distance from other decorations")]
		[Range(0.1f, 5f)]
		public float clearanceRadius;
	}
}
