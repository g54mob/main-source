using System.Collections.Generic;
using DV.Utils;

namespace DV.ModularAudioCar
{
	public class CarModularAudio : TrainAudio
	{
		public List<CarAudioModule> audioModules;

		protected override void Initialize(TrainCar trainCar)
		{
			foreach (CarAudioModule audioModule in audioModules)
			{
				audioModule.Initialize(trainCar);
			}
			SingletonBehaviour<CarAudioManager>.Instance.carAudios.Add(this);
		}

		protected override void Deinitialize()
		{
			foreach (CarAudioModule audioModule in audioModules)
			{
				audioModule.Deinitialize();
			}
			SingletonBehaviour<CarAudioManager>.Instance.carAudios.Remove(this);
		}

		public void DoUpdate(float deltaTime)
		{
			foreach (CarAudioModule audioModule in audioModules)
			{
				if (audioModule.ExternalUpdate)
				{
					audioModule.UpdateModule(deltaTime);
				}
			}
		}
	}
}
