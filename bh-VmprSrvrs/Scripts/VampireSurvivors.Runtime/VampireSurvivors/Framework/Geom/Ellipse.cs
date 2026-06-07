using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Framework.Geom
{
	public class Ellipse : BaseGeom
	{
		private float _x;

		private float _y;

		private float _width;

		private float _height;

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

		public float Width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector2 Position => default(Vector2);

		public bool IsEmpty => false;

		public float Left => 0f;

		public float Right => 0f;

		public float Top => 0f;

		public float Bottom => 0f;

		public Ellipse()
		{
		}

		public Ellipse(float x, float y, float width, float height)
		{
		}

		public void SetPosition(float x, float y)
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
	}
}
