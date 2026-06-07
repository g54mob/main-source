namespace Assets.Scripts.Input
{
	public class DummyInput : IGameInput
	{
		public string DescriptiveName => "DummyInput-" + Id;

		public bool Enabled { get; set; }

		public string Id { get; private set; }

		public DummyInput(string id)
		{
			Id = id;
		}

		public float GetAxis()
		{
			return 0f;
		}

		public float GetAxisIfEnabled()
		{
			return 0f;
		}

		public bool GetButton()
		{
			return false;
		}

		public bool GetButtonDown()
		{
			return false;
		}

		public bool GetButtonDownIfEnabled()
		{
			return false;
		}

		public bool GetButtonIfEnabled()
		{
			return false;
		}

		public bool GetButtonUp()
		{
			return false;
		}

		public bool GetButtonUpIfEnabled()
		{
			return false;
		}

		public string GetControllerBindingText()
		{
			return string.Empty;
		}

		public string GetFirstBindingText()
		{
			return string.Empty;
		}

		public string GetKeyboardPrimaryBindingText()
		{
			return string.Empty;
		}

		public string GetKeyboardSecondaryBindingText()
		{
			return string.Empty;
		}

		public string GetMouseBindingText()
		{
			return string.Empty;
		}
	}
}
