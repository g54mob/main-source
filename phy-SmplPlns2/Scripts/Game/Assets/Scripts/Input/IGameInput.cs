namespace Assets.Scripts.Input
{
	public interface IGameInput
	{
		string DescriptiveName { get; }

		bool Enabled { get; set; }

		string Id { get; }

		float GetAxis();

		float GetAxisIfEnabled();

		bool GetButton();

		bool GetButtonDown();

		bool GetButtonDownIfEnabled();

		bool GetButtonIfEnabled();

		bool GetButtonUp();

		bool GetButtonUpIfEnabled();

		string GetControllerBindingText();

		string GetFirstBindingText();

		string GetKeyboardPrimaryBindingText();

		string GetKeyboardSecondaryBindingText();

		string GetMouseBindingText();
	}
}
