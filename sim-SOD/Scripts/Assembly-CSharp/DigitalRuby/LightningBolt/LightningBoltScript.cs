using System;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.LightningBolt
{
	[RequireComponent(typeof(LineRenderer))]
	public class LightningBoltScript : MonoBehaviour
	{
		[Tooltip("The game object where the lightning will emit from. If null, StartPosition is used.")]
		public GameObject StartObject;

		[Tooltip("The start position where the lightning will emit from. This is in world space if StartObject is null, otherwise this is offset from StartObject position.")]
		public Vector3 StartPosition;

		[Tooltip("The game object where the lightning will end at. If null, EndPosition is used.")]
		public GameObject EndObject;

		[Tooltip("The end position where the lightning will end at. This is in world space if EndObject is null, otherwise this is offset from EndObject position.")]
		public Vector3 EndPosition;

		[Range(0f, 8f)]
		[Tooltip("How manu generations? Higher numbers create more line segments.")]
		public int Generations;

		[Tooltip("How long each bolt should last before creating a new bolt. In ManualMode, the bolt will simply disappear after this amount of seconds.")]
		[Range(0.01f, 1f)]
		public float Duration;

		private float timer;

		[Range(0f, 1f)]
		[Tooltip("How chaotic should the lightning be? (0-1)")]
		public float ChaosFactor;

		[Tooltip("In manual mode, the trigger method must be called to create a bolt")]
		public bool ManualMode;

		[Range(1f, 64f)]
		[Tooltip("The number of rows in the texture. Used for animation.")]
		public int Rows;

		[Range(1f, 64f)]
		[Tooltip("The number of columns in the texture. Used for animation.")]
		public int Columns;

		[Tooltip("The animation mode for the lightning")]
		public LightningBoltAnimationMode AnimationMode;

		[NonSerialized]
		[HideInInspector]
		public System.Random RandomGenerator;

		private LineRenderer lineRenderer;

		private List<KeyValuePair<Vector3, Vector3>> segments;

		private int startIndex;

		private Vector2 size;

		private Vector2[] offsets;

		private int animationOffsetIndex;

		private int animationPingPongDirection;

		private bool orthographic;

		private void GetPerpendicularVector(ref Vector3 directionNormalized, out Vector3 side)
		{
			side = default(Vector3);
		}

		private void GenerateLightningBolt(Vector3 start, Vector3 end, int generation, int totalGenerations, float offsetAmount)
		{
		}

		public void RandomVector(ref Vector3 start, ref Vector3 end, float offsetAmount, out Vector3 result)
		{
			result = default(Vector3);
		}

		private void SelectOffsetFromAnimationMode()
		{
		}

		private void UpdateLineRenderer()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Trigger()
		{
		}

		public void UpdateFromMaterialChange()
		{
		}
	}
}
