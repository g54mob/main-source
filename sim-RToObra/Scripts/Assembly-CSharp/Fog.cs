using System;
using UnityEngine;

public class Fog : MonoBehaviour
{
	public enum Source
	{
		Walls = 0,
		Air = 1,
		Texture = 2
	}

	public enum Spread
	{
		Even = 0,
		Up = 1,
		Down = 2,
		Mesh = 3
	}

	[Serializable]
	public class Spec
	{
		public Source source;

		public Spread spread;

		public int dotsPerMeter = 20;

		public int blurSteps = 10;

		public float thickness = 1f;

		public float castHeight = 1f;

		public float waveHeight = 0.1f;

		public string textureName = string.Empty;

		public Vector2 textureSize = new Vector2(5f, 5f);

		public bool clampToShip = true;

		public bool debug;

		public Transform customAirTransform;

		public float layerBot
		{
			get
			{
				if (spread == Spread.Down)
				{
					return 0f - thickness;
				}
				if (spread == Spread.Up)
				{
					return 0f;
				}
				if (spread == Spread.Mesh)
				{
					return 0f;
				}
				return -0.5f * thickness;
			}
		}

		public float layerTop
		{
			get
			{
				return layerBot + thickness;
			}
		}
	}

	public Spec spec;
}
