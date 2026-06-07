using System;

namespace Motorways.Audio
{
	public class DarEsSalaam : MusicData
	{
		private Rhythm initDrumRhythm;

		private int connCount;

		private int bassFreq = 6;

		public override void Injections()
		{
			SetRhythms(Rhythm.Quintuplet.Patterns().Edit((Rhythm x, int i) => x.InjectNoise(0.1f)));
			float duration = Math.Max(Rhythms.Shortest().Duration, 2f);
			initDrumRhythm = new Rhythm(0f, new D20().Frag(10, duration, 0f));
			SetDrumSequencer(initDrumRhythm, boom: false, bap: false, hat: true);
			SetNoteSequenceStyles(Liszt.Make(6, () => NoteSequenceType.PingPong));
			SetVoiceLimits(0.05, 1);
			SetQualities(Liszt.Flatten<Quality>(Liszt.From<Quality>(QualityDatabase.MAJOR_TETRA.Chromodal()), QualityDatabase.Gather("SUHMM Mixolydian", "SUHMM Lydian")));
		}

		public override void OnConnection()
		{
			if (Persistent.Connections >= 5)
			{
				DrumSequencer drumSequencer = Get.Loadout.DrumSequencer;
				switch (Rando.Pick<int>(1, 2, 3))
				{
				case 1:
					drumSequencer.Boom.Hits = Rando.Range(0, drumSequencer.Boom.Steps);
					drumSequencer.Boom.Reroll();
					break;
				case 2:
					drumSequencer.Bap.Hits = Rando.Range(0, drumSequencer.Bap.Steps);
					drumSequencer.Bap.Reroll();
					break;
				case 3:
					drumSequencer.Hat.Hits = Rando.Range(0, drumSequencer.Hat.Steps);
					drumSequencer.Hat.Reroll();
					break;
				}
				UpdateDrumSequencer(DrumSequencerRhythm, (connCount % 6 == 1 || connCount % 6 == 5) ? (!Boom) : Boom, (connCount % 6 == 2 || connCount % 6 == 4) ? (!Bap) : Bap, hat: true);
				connCount++;
			}
		}

		public override void OnDay()
		{
			UpdateDrumSequencer(initDrumRhythm.InjectNoise(Get.WeekProgress * 0.1f), Boom, Bap, Hat);
		}

		public override void OnHour()
		{
			if (Get.Clock.Hour >= 6 && Get.AudibleGroups >= 1 && Get.Hour % bassFreq == 1)
			{
				bassFreq = Rando.Pick<int>(3, 6, 9, 12, 15, 18, 21, 24);
				string text = Note.SCALE[CurrentScale.Key];
				if (Get.Week % 2 == 0)
				{
					text = Rando.Pick(base.NoteWindow);
					text = text.Substring(0, text.Length - 1);
				}
				Bass?.FadeOutAndStop(0.5);
				Bass = AudioPlayer.Default.PlaySample("bass_" + text, 0.5f, 0.4f, Get.State.HasFlag(StateType.ModeNight) ? Rando.Pick<float>(-0.5f, -1f) : 1f, 0.5);
			}
		}
	}
}
