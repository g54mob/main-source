namespace ModApi.Input
{
	public interface IGameInput
	{
		string DescriptiveName { get; }

		bool Enabled { get; set; }

		string Id { get; }

		bool IsBound { get; set; }

		float GetAxis();

		float GetAxisIfEnabled();

		bool GetButton();

		bool GetButtonDown();

		bool GetButtonDownIfEnabled();

		bool GetButtonIfEnabled();

		bool GetButtonRepeating();

		float GetButtonTimePressed();

		bool GetButtonUp();

		bool GetButtonUpIfEnabled();

		string GetControllerBindingText();

		string GetControllerNegativeBindingText();

		string GetControllerPositiveBindingText();

		string GetFirstBindingText();

		string GetKeyboardPrimaryBindingText();

		string GetKeyboardPrimaryNegativeBindingText();

		string GetKeyboardPrimaryPositiveBindingText();

		string GetKeyboardSecondaryBindingText();

		string GetMouseBindingText();
	}
}
