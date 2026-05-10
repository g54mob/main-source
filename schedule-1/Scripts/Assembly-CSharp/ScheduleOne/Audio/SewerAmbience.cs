using ScheduleOne.DevUtilities;
using ScheduleOne.Map;

namespace ScheduleOne.Audio
{
	public class SewerAmbience : Singleton<SewerAmbience>
	{
		public SewerCameraPresense SewerCameraPresense;

		public AudioSourceController SewerAmbienceSource;

		public float SewerAmbienceVolume => 0f;

		protected override void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
