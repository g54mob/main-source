using System;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	public class ProductionSpeedMultiplier
	{
		[SerializeField]
		private float outside = 1f;

		[SerializeField]
		private float outsideRain = 1f;

		[SerializeField]
		private float outsideFog = 1f;

		[SerializeField]
		private float outsideSnow = 1f;

		[SerializeField]
		private float roofed = 1f;

		[SerializeField]
		private float inside = 1f;

		public float Outside => outside;

		public float OutsideRaid => outsideRain;

		public float OutsideFog => outsideFog;

		public float OutsideSnow => outsideSnow;

		public float Roofed => roofed;

		public float Inside => inside;

		public float Get(bool roofed, bool room, bool rain, bool fog, bool snow)
		{
			if (room)
			{
				return inside;
			}
			if (roofed)
			{
				return this.roofed;
			}
			if (rain)
			{
				return outsideRain;
			}
			if (snow)
			{
				return outsideSnow;
			}
			if (fog)
			{
				return outsideFog;
			}
			return outside;
		}
	}
}
