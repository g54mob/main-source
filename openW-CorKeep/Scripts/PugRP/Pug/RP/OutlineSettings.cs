using System;
using UnityEngine;

namespace Pug.RP
{
	[Serializable]
	public struct OutlineSettings
	{
		[Serializable]
		public enum Type
		{
			Deferred = 0,
			PostProcessing = 1
		}

		public Type type;

		[Min(0f)]
		public float depthThreshold;

		[Min(0f)]
		public float depthThresholdSprite;

		[Range(0f, 1f)]
		public float slopeThreshold;

		public Texture2D colorLookup;

		public Texture2D colorLookup2;

		[Range(0f, 1f)]
		public float colorLookup2Threshold;

		public bool debugColorLookup;

		public static OutlineSettings baseSettings => new OutlineSettings
		{
			type = Type.Deferred,
			depthThreshold = 0.1f,
			depthThresholdSprite = 0.01f,
			slopeThreshold = 0.1f,
			colorLookup = null,
			colorLookup2 = null,
			colorLookup2Threshold = 0.5f,
			debugColorLookup = false
		};

		public Vector4 GetShaderParams()
		{
			return new Vector4(depthThreshold, depthThresholdSprite, 1f - slopeThreshold, colorLookup2Threshold);
		}
	}
}
