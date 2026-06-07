namespace Motorways.Audio
{
	public class Dubai : MusicData
	{
		private int tick;

		public override void Injections()
		{
			SetQualities(QualityDatabase.Gather("Sus2Min7", "Min7", "Min11", "Min9", "Sus"));
			SetDrumSequencer(new Rhythm(Rando.Pick<float>(0f, 1f / 3f, 0.5f, 2f / 3f, 0.75f), 0.25f, 0.25f, 0.25f, 0.25f), boom: true, bap: false, hat: false, useEuclideanGates: false);
		}

		public override void OnHour()
		{
			switch (Get.Week % 3)
			{
			case 0:
				DrumVolume = Get.WeekProgress;
				break;
			case 1:
				DrumVolume = 1f;
				break;
			case 2:
				DrumVolume = 1f - Get.WeekProgress;
				Bap = true;
				UseEuclideanDrumGates = true;
				break;
			default:
				Bap = false;
				UseEuclideanDrumGates = false;
				break;
			}
			Hat = Get.Week % 2 == 1;
		}

		public override void OnDrumPulse()
		{
			Boom = tick++ % 4 == 0;
		}
	}
}
