namespace Motorways.Audio
{
	public class Beijing : MusicData
	{
		private int bassFreq = 6;

		public override void Injections()
		{
			SetRhythms(Rhythm.Duplet.Patterns().Crop(2f));
			SetQualities(QualityDatabase.Gather("Quartal", "Overtone", "Penta Chromodal"));
			SetFadeInProgression(1.0, 0.0, asMultiplier: false);
			SetDrumSequencer(Rhythms.Shortest(), boom: true, bap: true, hat: true, useEuclideanGates: false, -1f, 50f);
		}

		public override void OnHour()
		{
			if (Get.Hour % bassFreq == 1)
			{
				bassFreq = Rando.Pick<int>(3, 6, 9, 12, 15, 18, 21, 24);
				string text = Rando.Pick(base.NoteWindow);
				Bass?.FadeOutAndStop(0.5);
				Bass = AudioPlayer.Default.PlaySample("bass_" + text.Substring(0, text.Length - 1), 0.5f, 0.4f, -1f, 0.5);
				UpdateDrumSequencer(Get.Loadout.DestinationGroupRhythms.Shortest(), boom: true, Rando.FlipCoin(), hat: true);
			}
		}
	}
}
