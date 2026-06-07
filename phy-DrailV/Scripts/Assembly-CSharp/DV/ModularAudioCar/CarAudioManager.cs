using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.ModularAudioCar
{
	public class CarAudioManager : SingletonBehaviour<CarAudioManager>
	{
		private const int FRAME_SPREAD = 2;

		private const int AUDIO_FRAMERATE = 60;

		public readonly HashSet<CarModularAudio> carAudios = new HashSet<CarModularAudio>();

		public readonly HashSet<CarRollingAudioModule> carRollingAudioModules = new HashSet<CarRollingAudioModule>();

		private float lastTimeCheckedRolling;

		private float lastTimeRanUpdate;

		private int spreadCounter;

		public new static string AllowAutoCreate()
		{
			return "[CarAudioManager]";
		}

		private void Update()
		{
			if (!TimeUtil.IsFlowing)
			{
				return;
			}
			float num = Time.time - lastTimeRanUpdate;
			if (num > 1f / 60f)
			{
				spreadCounter++;
				num *= 2f;
				int num2 = spreadCounter % 2;
				foreach (CarModularAudio carAudio in carAudios)
				{
					if (num2 % 2 == 0)
					{
						carAudio.DoUpdate(num);
					}
					num2++;
				}
				lastTimeRanUpdate = Time.time;
			}
			if (!(Time.time - lastTimeCheckedRolling > 1f))
			{
				return;
			}
			lastTimeCheckedRolling = Time.time;
			foreach (CarRollingAudioModule carRollingAudioModule in carRollingAudioModules)
			{
				float absSpeed = carRollingAudioModule.car.GetAbsSpeed();
				carRollingAudioModule.SetBogiesAudioLOD((absSpeed > 0.1f) ? AudioLOD.SIMPLE : AudioLOD.NONE);
			}
		}
	}
}
