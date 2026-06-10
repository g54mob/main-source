using System;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class HeraldryTransforms
	{
		[SerializeField]
		private float x;

		[SerializeField]
		private float y;

		[SerializeField]
		private float angle;

		[SerializeField]
		private float scale;

		[SerializeField]
		private bool flipX;

		[SerializeField]
		private bool flipY;

		public float X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public float Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public float Angle
		{
			get
			{
				return angle;
			}
			set
			{
				angle = value;
			}
		}

		public float Scale
		{
			get
			{
				return scale;
			}
			set
			{
				scale = value;
			}
		}

		public bool FlipX
		{
			get
			{
				return flipX;
			}
			set
			{
				flipX = value;
			}
		}

		public bool FlipY
		{
			get
			{
				return flipY;
			}
			set
			{
				flipY = value;
			}
		}
	}
}
