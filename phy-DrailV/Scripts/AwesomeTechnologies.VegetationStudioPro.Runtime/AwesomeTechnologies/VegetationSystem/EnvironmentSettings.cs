using System;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class EnvironmentSettings
	{
		public float SnowAmount;

		public float SnowMinHeight;

		public float RainAmount;

		public Color SnowColor = new Color(0.75f, 0.75f, 0.75f, 1f);

		public Color SnowSpecularColor = new Color(0.2f, 0.2f, 0.2f, 0.25f);

		public Color BillboardSnowColor = new Color(0.75f, 0.75f, 0.75f, 1f);

		public float SnowBlendFactor = 2.75f;

		public float SnowBrightness = 1f;
	}
}
