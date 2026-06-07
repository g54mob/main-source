using UnityEngine;

namespace Assets.Scripts.Flight.Demo
{
	[CreateAssetMenu(fileName = "DemoData", menuName = "SimplePlanes 2/Demo Data")]
	public class DemoData : ScriptableObject
	{
		public class RotatedBounds
		{
			public Bounds Bounds { get; set; }

			public float Rotation { get; set; }

			public RotatedBounds(Vector3 center, Vector3 size, float rotation)
			{
				Bounds = new Bounds(center, size);
				Rotation = rotation;
			}

			public Vector3 ClosestPoint(Vector3 point)
			{
				Vector3 point2 = Quaternion.Euler(0f, 0f - Rotation, 0f) * (point - Bounds.center) + Bounds.center;
				Vector3 vector = Bounds.ClosestPoint(point2);
				return Quaternion.Euler(0f, Rotation, 0f) * (vector - Bounds.center) + Bounds.center;
			}

			public bool Contains(Vector3 point)
			{
				Vector3 point2 = Quaternion.Euler(0f, 0f - Rotation, 0f) * (point - Bounds.center) + Bounds.center;
				return Bounds.Contains(point2);
			}
		}

		[SerializeField]
		private Vector3 _boundsCenter;

		[SerializeField]
		private float _boundsRotation;

		[SerializeField]
		private Vector3 _boundsSizeInvisibleWall;

		[SerializeField]
		private Vector3 _boundsSizeRestricted;

		[SerializeField]
		private Vector3 _boundsSizeWarning;

		public Vector3 BoundsCenter => _boundsCenter;

		public RotatedBounds BoundsInvisibleWall { get; private set; }

		public RotatedBounds BoundsRestricted { get; private set; }

		public float BoundsRotation => _boundsRotation;

		public RotatedBounds BoundsWarning { get; private set; }

		protected virtual void Awake()
		{
			UpdateBounds();
		}

		protected virtual void OnValidate()
		{
			UpdateBounds();
		}

		private void UpdateBounds()
		{
			BoundsWarning = new RotatedBounds(_boundsCenter, _boundsSizeWarning, _boundsRotation);
			BoundsRestricted = new RotatedBounds(_boundsCenter, _boundsSizeRestricted, _boundsRotation);
			BoundsInvisibleWall = new RotatedBounds(_boundsCenter, _boundsSizeInvisibleWall, _boundsRotation);
		}
	}
}
