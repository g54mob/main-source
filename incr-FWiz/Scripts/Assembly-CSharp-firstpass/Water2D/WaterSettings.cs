using System;
using UnityEngine;
using UnityEngine.Events;

namespace Water2D
{
	[Serializable]
	public class WaterSettings
	{
		public WaterCryo<Color> color;

		public WaterCryo<Color> depthColor;

		public ColoringType coloringType;

		public WaterCryo<Vector2> tiling;

		public WaterCryo<float> baseAlpha;

		public Texture2D alphaTexture;

		public WaterCryo<int> numOfPixels;

		public WaterCryo<bool> pixelPerfect;

		public WaterCryo<float> obstructionWidth;

		public WaterCryo<Color> obstructionColor;

		public WaterCryo<float> obstructionAlpha;

		public WaterCryo<Color> foamColor;

		public WaterCryo<float> foamSize;

		public WaterCryo<Vector2> foamSpeed;

		public WaterCryo<float> foamAlpha;

		public WaterCryo<Vector2> distortionSpeed;

		public WaterCryo<Vector2> distortionStrength;

		public WaterCryo<Vector2> distortionTiling;

		public WaterCryo<Vector2> distortionMinMax;

		public WaterCryo<Color> distortionColor;

		public Texture2D distortionTexture;

		public Texture2D sunStripsTexture;

		public WaterCryo<float> stripsSpeed;

		public WaterCryo<float> stripsScrollingSpeed;

		public WaterCryo<float> stripsSize;

		public SpriteRenderer surfaceSprite;

		public Texture2D surfaceTexture;

		public WaterCryo<Vector2> surfaceTiling;

		public WaterCryo<Vector2> surfaceSpeed;

		public WaterCryo<bool> useFoamSpeed;

		public WaterCryo<float> surfaceAlpha;

		public WaterCryo<float> stripsAlpha;

		public WaterCryo<float> stripsDensity;

		public WaterCryo<float> foamDensity;

		public WaterCryo<Vector2> perspective;

		public WaterCryo<bool> _useLighting;

		public WaterCryo<bool> depthFromObstructors;

		public WaterCryo<bool> enableBelowWater;

		public WaterCryo<Vector4> belowWaterUV;

		public WaterCryo<float> belowWaterDistortionStrength;

		public WaterCryo<float> belowWaterAlpha;

		public WaterCryo<Gradient> colorGradient;

		public WaterCryo<float> depthMlp;

		internal void onValueChanged(UnityAction onWaterChanged)
		{
		}
	}
}
