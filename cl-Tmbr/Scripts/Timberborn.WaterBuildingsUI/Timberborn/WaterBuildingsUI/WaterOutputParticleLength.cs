using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.EntitySystem;
using Timberborn.TickSystem;
using Timberborn.WaterBuildings;
using UnityEngine;

namespace Timberborn.WaterBuildingsUI
{
	internal class WaterOutputParticleLength : TickableComponent, IAwakableComponent, IInitializableEntity, IPostLoadableEntity, IFinishedStateListener
	{
		private static readonly float LengthMultiplier = 0.5f;

		private static readonly float NozzleLength = 0.1f;

		private ParticleSystem.MainModule _particlesMainModule;

		private WaterOutput _waterOutput;

		public void Awake()
		{
			_waterOutput = GetComponent<WaterOutput>();
			DisableComponent();
		}

		public void InitializeEntity()
		{
			_particlesMainModule = GetComponent<WaterOutputParticle>().ParticleSystem.main;
		}

		public void PostLoadEntity()
		{
			UpdateLifetime();
		}

		public override void Tick()
		{
			UpdateLifetime();
		}

		public void OnEnterFinishedState()
		{
			EnableComponent();
		}

		public void OnExitFinishedState()
		{
			DisableComponent();
		}

		private void UpdateLifetime()
		{
			float availableSpace = _waterOutput.AvailableSpace;
			_particlesMainModule.startLifetime = availableSpace * LengthMultiplier + NozzleLength;
		}
	}
}
