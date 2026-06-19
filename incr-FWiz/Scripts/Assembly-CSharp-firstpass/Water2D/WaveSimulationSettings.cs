using System;
using UnityEngine;
using UnityEngine.Events;

namespace Water2D
{
	[Serializable]
	public class WaveSimulationSettings
	{
		public WaterCryo<bool> automaticWaves;

		public WaterCryo<bool> enableBuoyancy;

		public WaterCryo<bool> enableRigidbodyCollisions;

		public WaterCryo<int> wavePoints;

		public WaterCryo<int> simulationSteps;

		public WaterCryo<float> waveDensity;

		public WaterCryo<float> waveDensity2;

		public WaterCryo<float> waveHeight;

		public WaterCryo<float> stringDampening;

		public WaterCryo<float> stringSpread;

		public WaterCryo<float> stringStiffness;

		public WaterCryo<float> edgeColoringSize;

		public WaterCryo<Color> edgeColor;

		public WaterCryo<bool> edgeIgnoreTransparency;

		public WaterCryo<float> splashForceMin;

		public WaterCryo<float> splashForceMax;

		public WaterCryo<float> splashVelMin;

		public WaterCryo<float> splashVelMax;

		public WaterCryo<int> splashNodesWidthMin;

		public WaterCryo<int> splashNodesWidthMax;

		public void OnValueChanged(UnityAction action)
		{
		}
	}
}
