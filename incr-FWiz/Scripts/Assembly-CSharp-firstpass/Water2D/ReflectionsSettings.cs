using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Water2D
{
	[Serializable]
	public class ReflectionsSettings
	{
		public WaterCryo<bool> enableTopDownReflections;

		public WaterCryo<bool> enablePlatformerReflections;

		public WaterCryo<bool> enableRaymarchedReflections;

		public Camera mainCamera;

		public WaterCryo<float> textureResolution;

		public WaterCryo<bool> overrideMainCamera;

		public WaterCryo<bool> reflectionObjectsVisible;

		public WaterCryo<bool> cameraVisible;

		public WaterCryo<bool> defaultReflectionSprflipx;

		public WaterCryo<float> angle;

		public WaterCryo<float> tilt;

		public WaterCryo<float> length;

		public WaterCryo<float> originalColor;

		public WaterCryo<Color> color;

		public WaterCryo<float> alpha;

		public WaterCryo<float> mirrorY;

		public List<int> layers;

		public WaterCryo<bool> usePerspective;

		public WaterCryo<Vector2> waterPerspective;

		public WaterCryo<Vector2> reflectionsPerspective;

		public WaterCryo<float> falloffStrength;

		public WaterCryo<float> falloffStart;

		public WaterCryo<bool> enableFalloff;

		public WaterCryo<bool> enableScrolling;

		public WaterCryo<bool> customReflectionStart;

		public Transform playerPosition;

		public WaterCryo<float> scrollingStrength;

		public WaterCryo<bool> DistortionFPRH;

		public List<int> raymarchlayers;

		public WaterCryo<int> raymarchSteps;

		public WaterCryo<bool> type2;

		public WaterCryo<float> raymarchFalloffStart;

		public WaterCryo<float> raymarchFalloffEnd;

		internal void onValueChanged(UnityAction onReflectionsChanged)
		{
		}
	}
}
