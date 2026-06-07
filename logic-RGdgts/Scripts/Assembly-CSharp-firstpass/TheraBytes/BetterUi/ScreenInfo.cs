using System;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class ScreenInfo
	{
		[SerializeField]
		private Vector2 resolution;

		[SerializeField]
		private float dpi;

		public Vector2 Resolution
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float Dpi
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ScreenInfo()
		{
		}

		public ScreenInfo(Vector2 resolution, float dpi)
		{
		}
	}
}
