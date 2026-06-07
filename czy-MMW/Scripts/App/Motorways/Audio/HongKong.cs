namespace Motorways.Audio
{
	public class HongKong : MusicData
	{
		private int _bassFreq = 6;

		public override void Injections()
		{
			SetRhythms(Rhythm.Duplet.Patterns().Crop(2f).Scale(0.75f));
			SetQualities(QualityDatabase.Gather("Quartal", "Overtone", "Penta Chromodal"));
			SetFadeInProgression(1.0, 0.0, asMultiplier: false);
			SetDrumSequencer(Rhythms.Shortest(), boom: true, bap: true, hat: true, useEuclideanGates: false, -1f, 50f);
		}

		public override void OnHour()
		{
			if (Get.Hour % _bassFreq == 1)
			{
				_bassFreq = Rando.Pick<int>(3, 6, 9, 12, 15, 18, 21, 24);
				string text = Rando.Pick(base.NoteWindow);
				Bass?.FadeOutAndStop(0.5);
				AudioPlayer audioPlayer = AudioPlayer.Default;
				string text2 = text;
				Bass = audioPlayer.PlaySample("bass_" + text2.Substring(0, text2.Length - 1), 0.5f, 0.4f, -1f, 0.5);
				UpdateDrumSequencer(Get.Loadout.DestinationGroupRhythms.Shortest().Scale(Get.Pulse.Scale.Scale), boom: true, Rando.FlipCoin(), hat: true);
			}
		}
	}
}
