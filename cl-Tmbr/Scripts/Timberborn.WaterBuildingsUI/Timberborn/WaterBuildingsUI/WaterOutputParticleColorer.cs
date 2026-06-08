using Timberborn.BaseComponentSystem;
using Timberborn.EntitySystem;
using Timberborn.WaterBuildings;
using UnityEngine;

namespace Timberborn.WaterBuildingsUI
{
	internal class WaterOutputParticleColorer : BaseComponent, IInitializableEntity
	{
		private readonly WaterOutputParticleColors _waterOutputParticleColors;

		private ParticleSystem.MainModule _particlesMainModule;

		public WaterOutputParticleColorer(WaterOutputParticleColors waterOutputParticleColors)
		{
			_waterOutputParticleColors = waterOutputParticleColors;
		}

		public void InitializeEntity()
		{
			_particlesMainModule = GetComponent<WaterOutputParticle>().ParticleSystem.main;
			GetComponent<WaterOutput>().WaterAdded += OnWaterAdded;
		}

		private void OnWaterAdded(object sender, WaterAddition e)
		{
			ParticleSystem.MinMaxGradient startColor = _particlesMainModule.startColor;
			float time = e.ContaminatedWater / (e.CleanWater + e.ContaminatedWater);
			startColor.color = _waterOutputParticleColors.WaterContaminationParticleGradient.Evaluate(time);
			_particlesMainModule.startColor = startColor;
		}
	}
}
