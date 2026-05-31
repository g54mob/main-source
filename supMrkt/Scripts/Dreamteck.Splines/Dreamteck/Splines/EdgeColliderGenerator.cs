using UnityEngine;

namespace Dreamteck.Splines
{
	[AddComponentMenu("Dreamteck/Splines/Users/Edge Collider Generator")]
	[RequireComponent(typeof(EdgeCollider2D))]
	public class EdgeColliderGenerator : SplineUser
	{
		[SerializeField]
		[HideInInspector]
		private float _offset;

		[SerializeField]
		[HideInInspector]
		protected EdgeCollider2D edgeCollider;

		[SerializeField]
		[HideInInspector]
		protected Vector2[] vertices;

		[HideInInspector]
		public float updateRate;

		protected float lastUpdateTime;

		private bool updateCollider;

		public float offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void Reset()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void LateRun()
		{
		}

		protected override void Build()
		{
		}

		protected override void PostBuild()
		{
		}
	}
}
