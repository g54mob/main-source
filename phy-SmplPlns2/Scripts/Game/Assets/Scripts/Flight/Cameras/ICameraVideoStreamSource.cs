namespace Assets.Scripts.Flight.Cameras
{
	public interface ICameraVideoStreamSource
	{
		bool IsActive { get; }

		string Name { get; }

		void ReleaseVideoStream(ICameraVideoStreamConsumer consumer);

		ICameraVideoStream RequestVideoStream(ICameraVideoStreamConsumer consumer);
	}
}
