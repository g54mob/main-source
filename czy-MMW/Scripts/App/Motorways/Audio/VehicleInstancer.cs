namespace Motorways.Audio
{
	public class VehicleInstancer : ImmediateAudioModule
	{
		public VehicleInstancer(AudioEventFilter filter)
			: base(filter, "")
		{
		}

		protected override void OnAudioEvent(AudioEvent e)
		{
			AudioEventFilter audioEventFilter = new AudioEventFilter
			{
				Vehicle = e.Vehicle
			};
			Playback playback = new Vehicle(e.Vehicle);
			IAudioModule dynamicModule = PulsedAudioModule.CreateModule("Vehicle " + e.Vehicle.Id, playback, null, 1);
			Get.Loadout.AddDynamicModule(dynamicModule);
		}
	}
}
