using System;

namespace VampireSurvivors.Graphics.Blitters
{
	[Serializable]
	public class BobData
	{
		public float Vx { get; set; }

		public float Vy { get; set; }

		public float Bounce { get; set; }

		public float Right { get; set; }

		public float Left { get; set; }

		public float Top { get; set; }

		public float Bottom { get; set; }

		public int ID { get; set; }

		public void Reset()
		{
		}
	}
}
