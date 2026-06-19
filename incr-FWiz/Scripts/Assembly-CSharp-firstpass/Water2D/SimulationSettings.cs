using System;
using UnityEngine;
using UnityEngine.Events;

namespace Water2D
{
	[Serializable]
	public class SimulationSettings
	{
		public WaterCryo<Vector2Int> resolution;

		public ComputeShader waterCmp;

		public SpriteRenderer sr;

		public RenderTexture obstruction;

		public Camera mainCam;

		public WaterCryo<int> chunksX;

		public WaterCryo<int> chunksY;

		public WaterCryo<float> waveRad;

		public WaterCryo<float> waveHeight;

		public WaterCryo<float> dispersion;

		public WaterCryo<int> iterations;

		public WaterCryo<float> simulationSpeed;

		public WaterCryo<bool> enableRain;

		public WaterCryo<float> rainWaveHeight;

		public WaterCryo<float> rainSpeed;

		public WaterCryo<int> rainSizeX;

		public WaterCryo<int> rainSizeY;

		public WaterCryo<float> normalStrength;

		public WaterCryo<Color> waveColor;

		public WaterCryo<Vector2> waveColorMinMaxHeight;

		internal void onValueChanged(UnityAction onOSimulationChanged)
		{
		}
	}
}
