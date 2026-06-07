using System;
using UnityEngine;

namespace Placemaker.Modules
{
	[Serializable]
	public class OutlineUv
	{
		public byte b;

		public int x
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int y
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Vector2 uv => default(Vector2);

		public bool border => false;
	}
}
