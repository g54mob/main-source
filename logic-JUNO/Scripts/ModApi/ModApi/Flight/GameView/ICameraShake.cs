namespace ModApi.Flight.GameView
{
	public interface ICameraShake
	{
		void AddShake(CameraShakeFloat intensity, CameraShakeFloat frequency);

		void RemoveShake(CameraShakeFloat intensity, CameraShakeFloat frequency);
	}
}
