namespace MateoRyhr
{
	public class CameraController
	{
		public float GetRotation(float current, float input, float sensivity)
		{
			return current + input * sensivity;
		}
	}
}
