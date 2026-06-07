using DV.Utils;
using DV.VFX;
using DV.WeatherSystem;
using Unity.Profiling;
using UnityEngine;

namespace DV.ModularAudioCar
{
	public class RainAudioModule : CarAudioModule
	{
		private static ProfilerMarker PROFILE_MARKER = new ProfilerMarker("RainAudioModule");

		private const float RAIN_LERP_SPEED = 3f;

		private const float HEIGHT_ABOVE_LOCO = 0.5f;

		public LayeredAudio rainAudio;

		private TrainCar car;

		private Transform cachedTransform;

		private float rainValue;

		public override bool ExternalUpdate => true;

		public override void Deinitialize()
		{
			car = null;
		}

		public override void Initialize(TrainCar car)
		{
			if (rainAudio != null)
			{
				rainAudio.Reset();
			}
			cachedTransform = base.transform;
			this.car = car;
		}

		public override void UpdateModule(float deltaTime)
		{
			if (!SingletonBehaviour<WeatherDriver>.Instance)
			{
				return;
			}
			float b = SingletonBehaviour<WeatherDriver>.Instance.RainValue.CurrentValue;
			CeilingDetection instance = SingletonBehaviour<CeilingDetection>.Instance;
			if ((bool)instance)
			{
				CeilingDetection.WorldPositionedArray worldPositionedArray = instance.worldPositionedArray;
				int index = worldPositionedArray.GetIndex(cachedTransform.position);
				if (index >= 0 && instance.copiedResults[index].point.y - car.transform.TransformPoint(Vector3.up * (car.Bounds.center.y + car.Bounds.extents.y)).y > 0.5f)
				{
					b = 0f;
				}
			}
			rainValue = Mathf.Lerp(rainValue, b, deltaTime * 3f);
			rainAudio.Set(rainValue);
		}
	}
}
