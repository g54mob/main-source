using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Coherence.Toolkit
{
	[AddComponentMenu("coherence/Queries/Coherence Live Query")]
	[DefaultExecutionOrder(900)]
	[NonBindable]
	[HelpURL("https://docs.coherence.io/v/1.6/manual/components/coherence-sync")]
	public sealed class CoherenceLiveQuery : CoherenceQuery
	{
		internal static class Properties
		{
			public const string Extent = "extent";

			public const string ExtentUpdateThreshold = "extentUpdateThreshold";

			public const string DistanceUpdateThreshold = "distanceUpdateThreshold";
		}

		[FormerlySerializedAs("radius")]
		[SerializeField]
		[Min(1f)]
		private float extent;

		[SerializeField]
		[Tooltip("Difference in the magnitude of the extent at which to trigger an update on the live query. Only relevant when the area is constrained.")]
		[Min(0f)]
		private float extentUpdateThreshold;

		[SerializeField]
		[Tooltip("Distance since last update at which an update on the live query is triggered.")]
		[Min(0f)]
		private float distanceUpdateThreshold;

		private Vector3 lastPosition;

		private float lastExtent;

		private Transform cachedTransform;

		private bool createdEntityID;

		public float Extent
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Deprecated("21/11/2024", 1, 4, 0)]
		[Obsolete("Use Extent instead.")]
		public float radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ExtentUpdateThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float DistanceUpdateThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private bool IsExtentPastThreshold => false;

		private bool IsDistancePastThreshold => false;

		private bool IsPastAnyThreshold => false;

		private bool IsChangingMode => false;

		protected override bool NeedsUpdate => false;

		private CoherenceLiveQuery()
		{
		}

		protected override void Reset()
		{
		}

		private void Awake()
		{
		}

		protected override void CreateQuery()
		{
		}

		private void CreateQueryImpl()
		{
		}

		protected override void OnFloatingOriginShifted(FloatingOriginShiftArgs _)
		{
		}

		protected override void UpdateQuery(bool queryActive = true)
		{
		}
	}
}
