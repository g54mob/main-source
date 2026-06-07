namespace ModApi.Flight.GameView.Events
{
	public class CameraUnderwaterStateChangedEventArgs
	{
		public bool IsCameraUnderWater { get; }

		public CameraUnderwaterStateChangedEventArgs(bool isCameraUnderWater)
		{
			IsCameraUnderWater = isCameraUnderWater;
		}
	}
}
