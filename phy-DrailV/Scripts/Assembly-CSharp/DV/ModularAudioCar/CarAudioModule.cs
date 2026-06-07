using UnityEngine;

namespace DV.ModularAudioCar
{
	public abstract class CarAudioModule : MonoBehaviour
	{
		public abstract bool ExternalUpdate { get; }

		public abstract void Initialize(TrainCar trainCar);

		public abstract void Deinitialize();

		public virtual void UpdateModule(float deltaTime)
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
