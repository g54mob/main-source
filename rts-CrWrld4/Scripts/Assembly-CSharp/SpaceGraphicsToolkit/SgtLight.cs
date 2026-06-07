using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtLight : SgtLinkedBehaviour<SgtLight>
	{
		private class LightProperties
		{
			public int Direction;

			public int Position;

			public int Color;

			public int Scatter;
		}

		public bool TreatAsPoint;

		[NonSerialized]
		private Light cachedLight;

		[NonSerialized]
		private bool cachedLightSet;

		private static List<LightProperties> cachedLightProperties;

		private static List<string> cachedLightKeywords;

		private static List<SgtLight> tempLights;

		public Light CachedLight => null;

		public static List<SgtLight> Find(bool lit, int mask)
		{
			return null;
		}

		public static void FilterOut(Vector3 center)
		{
		}

		public static void Calculate(SgtLight light, Vector3 center, Transform directionTransform, Transform positionTransform, ref Vector3 position, ref Vector3 direction, ref Color color)
		{
		}

		public static void Write(bool lit, Vector3 center, Transform directionTransform, Transform positionTransform, float scatterStrength, int maxLights)
		{
		}

		private static LightProperties GetLightProperties(int index)
		{
			return null;
		}

		private static string GetLightKeyword(int index)
		{
			return null;
		}
	}
}
