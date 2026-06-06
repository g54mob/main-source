namespace MalbersAnimations
{
	public interface IInputSystem
	{
		float GetAxis(string Axis);

		float GetAxisRaw(string Axis);

		bool GetButtonDown(string button);

		bool GetButtonUp(string button);

		bool GetButton(string button);
	}
}
