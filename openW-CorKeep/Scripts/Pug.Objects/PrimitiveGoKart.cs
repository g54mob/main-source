using Unity.Mathematics;

public class PrimitiveGoKart : GoKart
{
	protected override void SetMotorValues(float speed)
	{
		float volume = math.lerp(0.2f, 1f, speed);
		float pitch = math.lerp(0.5f, 0.8f, speed);
		if ((bool)audioLoop)
		{
			audioLoop.SetVolume(volume);
			audioLoop.SetPitch(pitch);
		}
	}
}
