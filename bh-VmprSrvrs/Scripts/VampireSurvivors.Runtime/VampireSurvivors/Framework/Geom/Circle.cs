using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Framework.Geom
{
	public class Circle : BaseGeom
	{
		private float _x;

		private float _y;

		private float _radius;

		private float _diameter;

		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Diameter
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector2 Position
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public bool IsEmpty => false;

		public float Left => 0f;

		public float Right => 0f;

		public float Top => 0f;

		public float Bottom => 0f;

		public Circle()
		{
		}

		public Circle(float x, float y, float radius)
		{
		}

		public List<Vector2> GetPoints(int quantity)
		{
			return null;
		}

		public Vector2 CircumferencePoint(float angle)
		{
			return default(Vector2);
		}

		public void SetPosition(float x, float y)
		{
		}

		public Vector2 GetRandomPoint()
		{
			return default(Vector2);
		}

		public bool Contains(Vector2 point)
		{
			return false;
		}
	}
}
