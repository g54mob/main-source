using System.Collections.Generic;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Audio
{
	public class House : Playback
	{
		public House(AudioEventFilter filter)
			: base(filter)
		{
		}

		protected override void OnPulse()
		{
		}

		public override void AddEventListeners()
		{
			EventListener.Add(OnHouseSpawn, AudioEventType.HouseSpawned);
		}

		private void OnHouseSpawn(AudioEvent e)
		{
			HouseView h = e.House;
			if (e.Type == AudioEventType.HouseSpawned && !(Get.Loadout.MusicData is Menu))
			{
				int times = Rando.Pick<int>(5, 6, 7, 8);
				Maf.Repeat(times, delegate(int i)
				{
					AudioPlayer.UI.PlaySample("PeepAppears_" + Get.Loadout.MusicData.Timbres[h.groupIndex], dspTime: AudioPlayer.EarliestSchedulableTime + (double)i * Get.Pulse.Master.Duration / (double)times, pan: h.Pan.x, gain: h.GetAttenuation(zoom: false, 25f) * 1f * Maf.VolCurve(1f - (float)i / (float)times), pitch: Mathf.Lerp(1f, 0.5f, Twerp.Ease.In((float)i / (float)times, 2)), fadeTime: 0.0, loop: false, mix: null, stereo: false, randomStart: false, startPosition: 0f, isImportant: true);
				});
				List<DestinationGroup> destinationGroups = Get.Loadout.DestinationGroups;
				if (destinationGroups.Count > h.groupIndex)
				{
					List<string> notes = destinationGroups[h.groupIndex].Notes;
					AudioPlayer.Default.PlayChord("chordTone", notes, -1.0, (float)Get.Pulse.Master.Duration / (float)notes.Count, h.Attenuation * Settings.Gain.HOUSE_SPAWNED_CHORD[0], h.Attenuation * Settings.Gain.HOUSE_SPAWNED_CHORD[1], h.Pan.x, h.Pan.x);
				}
			}
		}
	}
}
