using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Audio
{
	public class CapeTown : MusicData
	{
		private List<Rhythm> _rhythms;

		public override void Injections()
		{
			_rhythms = Liszt.From<Rhythm>(new Rhythm(0f, 0.75f, 1.25f), new Rhythm(0f, 0.25f, 0.25f, 0.25f, 1.25f), new Rhythm(0f, 0.75f, 0.25f, 0.5f, 0.5f), new Rhythm(0f, 0.75f, 0.75f, 0.5f));
			Quality quality = new Quality("IMaj6/9", Liszt.From<int>(2, 2, 3, 2, 3), Liszt.From<int>(0, 12));
			quality.Scales.Add(new Scale(2, "II7", Liszt.From<int>(4, 3, 3, 2), Liszt.From<int>(0, 12)));
			quality.Scales.Add(new Scale(4, "III-7", Liszt.From<int>(3, 4, 3, 2), Liszt.From<int>(0, 12)));
			quality.Scales.Add(new Scale(5, "IVMaj9", Liszt.From<int>(2, 2, 3, 4, 1), Liszt.From<int>(0, 12)));
			quality.Scales.Add(new Scale(7, "V7", Liszt.From<int>(4, 3, 3, 2), Liszt.From<int>(0, 12)));
			quality.Scales.Add(new Scale(9, "VI-7", Liszt.From<int>(3, 4, 3, 2), Liszt.From<int>(0, 12)));
			SetKeyDeltas(Liszt.From<int>(-4, -2, 1, 3), D20.Range(0, 6));
			SetVoiceLimits(0.1, 4, 0.1, 1);
			SetTremolo(new Param.LFO(new Param.Data(2.4f), new Param.Data(0.25f, 0.5f)));
			SetRhythms(_rhythms);
			SetDrumSequencer(_rhythms.Pick(), boom: true, bap: true, hat: true);
			SetQualities(Liszt.From<Quality>(quality));
		}

		public override void OnHour()
		{
			if (Get.Hour % 4 == 0)
			{
				UpdateNoteWindow(Rando.Range(2, Get.MaxGroups - 1), 0.5f);
				float num = Time.time - timeAtStart;
				if (Rando.FlipCoin() && num > 3f)
				{
					Bass?.FadeOutAndStop(0.05);
					Bass = AudioPlayer.Default.PlaySample("bass_" + Note.SCALE[CurrentScale.Key], 0.5f, 0.2f, 1f, 0.0, Get.Pulse.Master.Next);
				}
				if (Rando.FlipCoin())
				{
					Rhythm rhythm = _rhythms.Pick().Scale(Get.Pulse.Scale.Scale);
					UpdateDrumSequencer(rhythm, boom: true, bap: true, hat: true);
				}
			}
		}
	}
}
