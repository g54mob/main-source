using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Motorways.Audio
{
	public class Wellington : MusicData
	{
		private Rhythm BaseRhythm;

		private List<Rhythm> BaseRhythms;

		private float spreadDeltaInc = 0.05f;

		private float spreadDelta;

		private float drumVolume;

		private DrumSequencer DS => Get.Loadout.DrumSequencer;

		private Rhythm GenDrumRhythm()
		{
			return new Rhythm(0f, Liszt.Make(Rando.Range(4, 8), (int x) => Rando.Pick<float>(0.25f, 0.5f, 0.75f)).ToArray()).Crop(2f);
		}

		public override void Injections()
		{
			drumVolume = DrumVolume;
			SetQualities(Liszt.From<Quality>(new Quality("Wellington 1", Liszt.From<int>(2, 7, 3), Liszt.From<int>(0, 24)), new Quality("Wellington 2", Liszt.From<int>(2, 2, 7, 1), Liszt.From<int>(0, 24)), new Quality("Wellington 3", Liszt.From<int>(3, 2, 7), Liszt.From<int>(0, 24)), new Quality("Wellington 4", Liszt.From<int>(2, 3, 2, 5), Liszt.From<int>(0, 24)), new Quality("Wellington 5", Liszt.From<int>(2, 5, 2, 3), Liszt.From<int>(0, 24)), new Quality("Wellington 6", Liszt.From<int>(5, 3, 2, 2), Liszt.From<int>(0, 24)), new Quality("Wellington 7", Liszt.From<int>(7, 3, 2), Liszt.From<int>(0, 24))).Chromatic());
			SetKeyDeltas(Liszt.From<int>(default(int)), MusicData.MenuKey);
			SetWeekendChances(0f, 0f);
			BaseRhythm = Rhythm.Duplet.Pulse();
			BaseRhythms = BaseRhythm.Uniform();
			SetRhythms(BaseRhythms, RhythmUpdateType.LinearUniform);
			SetDrumSequencer(GenDrumRhythm(), boom: true, bap: true, hat: true);
			DrumVolume = 0f;
			SetPortamento(new Param.Portamento(-300, 0, 0.0, 0.5));
		}

		public override void OnDawn()
		{
			DS.Hat.Hits = Rando.Range((int)((double)DS.Hat.Steps * 0.75), DS.Hat.Steps);
			DS.Bap.Hits = Rando.Range((int)((double)DS.Bap.Steps * 0.75), DS.Bap.Steps);
			DS.Boom.Hits = Rando.Range(0, DS.Boom.Steps);
		}

		public override void OnDusk()
		{
			DS.Hat.Hits = Rando.Range(0, DS.Hat.Steps / 2);
			DS.Bap.Hits = Rando.Range(0, DS.Bap.Steps / 2);
			DS.Boom.Hits = Rando.Range(DS.Boom.Hits / 2, DS.Boom.Hits);
			DS.Parts.ForEach(delegate(DrumSequencer.Part x)
			{
				x.Reroll();
			});
		}

		public override void OnHour()
		{
			if (Get.Week == 0 && Get.Day == 6 && Get.Hour > 14 && Get.Hour < 24)
			{
				DrumVolume = drumVolume * Mathf.Pow(((float)Get.Hour - 14f) / 9f, 1.5f);
			}
		}

		public override void OnNewWeek()
		{
			base.OnNewWeek();
			if (Get.Week % 2 == 1)
			{
				UpdateDrumSequencer(GenDrumRhythm(), boom: true, bap: true, hat: true);
			}
		}

		public override void OnConnection()
		{
			spreadDelta += spreadDeltaInc;
			List<Rhythm> list = BaseRhythms.ToList().Spread(spreadDelta);
			for (int i = 0; i < Get.Loadout.DestinationGroups.Count; i++)
			{
				Get.Loadout.DestinationGroups[i].Module.ChangePulse(list[i]);
			}
		}

		public override float SamplePitchSign()
		{
			if (!Get.State.HasFlag(StateType.ModeNight))
			{
				return base.SamplePitchSign();
			}
			return -1f;
		}
	}
}
