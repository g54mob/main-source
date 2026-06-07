using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Framework.Geom
{
	public class Rectangle : BaseGeom
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

		public Rectangle()
		{
		}

		public Rectangle(float x, float y, float width, float height)
		{
		}

		public bool Contains(float x, float y)
		{
			return false;
		}

		public bool UnitySpaceContains(float2 position)
		{
			return false;
		}
	}
}
