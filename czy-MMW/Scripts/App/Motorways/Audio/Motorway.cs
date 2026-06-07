using UnityEngine;

namespace Motorways.Audio
{
	public class Motorway : Playback
	{
		private string _n = "C3";

		public Motorway(AudioEventFilter filter)
			: base(filter)
		{
		}

		protected override void OnPulse()
		{
		}

		public override void AddEventListeners()
		{
			EventListener.Add(OnMotorwayHandle, AudioEventType.MotorwayHandlePulled | AudioEventType.MotorwayHandleReleased);
		}

		private void OnMotorwayHandle(AudioEvent e)
		{
			switch (e.Type)
			{
			case AudioEventType.MotorwayHandlePulled:
				_n = Rando.Pick(Get.Loadout.MusicData.NoteWindow);
				_n = Note.Transpose(-24, _n);
				AudioPlayer.Default.PlaySample("StationAdded_" + _n, e.Pan, 0.75f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				break;
			case AudioEventType.MotorwayHandleReleased:
			{
				float num = Maf.Normalize(e.Magnitude, 0f, 10f);
				if (!Mathf.Approximately(num, 0f))
				{
					float num2 = 1f + (float)Mathf.Min(Mathf.FloorToInt(num * 3f), 2) * 0.5f;
					AudioPlayer.Default.PlaySample("StationAdded_" + _n, e.Pan, Mathf.Lerp(0.1f, 1f, num), 1f, 0.0, -1.0, loop: false, new FX.Modulator(null, new FX.Modulator.Vibrato(Mathf.Lerp(10f, 20f, num), Maf.Lerp(0.0, 0.05, num), num2, UnityEngine.Random.value)), stereo: false, randomStart: false, 0f, isImportant: true);
				}
				break;
			}
			}
		}
	}
}
