using UnityEngine;

namespace Dreamteck.Splines
{
	[AddComponentMenu("Dreamteck/Splines/Users/Polygon Collider Generator")]
	[RequireComponent(typeof(PolygonCollider2D))]
	public class PolygonColliderGenerator : SplineUser
	{
		public enum Type
		{
			Path = 0,
			Shape = 1
		}

		[SerializeField]
		[HideInInspector]
		private Type _type;

		[SerializeField]
		[HideInInspector]
		private float _size;

		[SerializeField]
		[HideInInspector]
		private float _offset;

		[SerializeField]
		[HideInInspector]
		protected PolygonCollider2D polygonCollider;

		[SerializeField]
		[HideInInspector]
		protected Vector2[] vertices;

		[HideInInspector]
		public float updateRate;

		protected float lastUpdateTime;

		private bool updateCollider;

		public Type type
		{
			get
			{
				return default(Type);
			}
			set
			{
			}
		}

		public float size
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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

		private void GeneratePath()
		{
		}

		private void GenerateShape()
		{
		}
	}
}
