namespace RLD
{
	public class RTInputDevice : MonoSingleton<RTInputDevice>
	{
		private IInputDevice _inputDevice;

		public IInputDevice Device => _inputDevice;

		public InputDeviceType DeviceType => _inputDevice.DeviceType;

		public void Update_SystemCall()
		{
			_inputDevice.Update();
		}

		private void Awake()
		{
			_inputDevice = new MouseInputDevice();
		}
	}
}
