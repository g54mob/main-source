namespace PugMod
{
	public interface IInput
	{
		bool GetButton(int action);

		bool GetButtonDown(int action);

		bool GetButtonUp(int action);

		float GetAxis(int action);
	}
}
