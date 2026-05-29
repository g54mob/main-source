using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Geometry
{
	public class RingColliderProxy : ColliderProxy
	{
		public int _Segments;

		public float _Thickness;

		public Vector3 _Normal;

		public Vector3 _Forward;

		public float _Speed;

		protected float mSegmentAngle;

		protected bool mEnable;

		protected bool mIsUpdating;

		protected float mElapsedAngle;

		protected List<Collider> mColliders;

		public int Segments
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Thickness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 Normal
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 Forward
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float Speed
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

		protected void Start()
		{
		}

		public override void Reset()
		{
		}

		public override void EnableColliders(bool rEnable, float rSpeed = 0f)
		{
		}

		protected void Update()
		{
		}
	}
}
