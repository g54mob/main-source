using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public abstract class SgtShadow : SgtLinkedBehaviour<SgtShadow>
	{
		private class ShadowProperties
		{
			public int Texture;

			public int Matrix;

			public int Ratio;
		}

		private static List<ShadowProperties> cachedShadowProperties;

		private static List<string> cachedShadowKeywords;

		private static List<SgtShadow> tempShadows;

		[NonSerialized]
		private bool calculatedThisFrame;

		[NonSerialized]
		protected bool cachedActive;

		[NonSerialized]
		protected Texture cachedTexture;

		[NonSerialized]
		protected Matrix4x4 cachedMatrix;

		[NonSerialized]
		protected float cachedRatio;

		[NonSerialized]
		protected float cachedRadius;

		public abstract Texture GetTexture();

		public abstract void CalculateShadow(SgtLight light);

		private static ShadowProperties GetShadowProperties(int index)
		{
			return null;
		}

		private static string GetShadowKeyword(int index)
		{
			return null;
		}

		public static List<SgtShadow> Find(bool lit, int mask, List<SgtLight> lights)
		{
			return null;
		}

		public static void FilterOutSphere(Vector3 center)
		{
		}

		public static void FilterOutRing(Vector3 center)
		{
		}

		public static void FilterOutMiss(Vector3 center, float radius)
		{
		}

		public static void Write(bool lit, int maxShadows)
		{
		}

		protected virtual void Update()
		{
		}
	}
}
