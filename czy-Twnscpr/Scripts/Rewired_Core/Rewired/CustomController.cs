using System;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int _sourceControllerId;

		private Func<int, float> axisUpdateCallback;

		private Func<int, bool> buttonUpdateCallback;

		private bool useUpdateCallbacks;

		private Guid _deviceInstanceGuid;

		public int sourceControllerId => 0;

		public override Guid deviceInstanceGuid => default(Guid);

		internal CustomController(TGUQndNLFmpDTHjZgDtVLRKZcPF data)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		private CustomController(int controllerId, int sourceControllerId, Guid hardwareTypeGuid, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		internal void FillData()
		{
		}

		public void SetAxisValue(int index, float value)
		{
		}

		public void SetAxisValue(string elementName, float value)
		{
		}

		public void SetAxisValueById(int elementId, float value)
		{
		}

		public void SetButtonValue(int index, bool value)
		{
		}

		public void SetButtonValue(string elementName, bool value)
		{
		}

		public void SetButtonValueById(int elementId, bool value)
		{
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
		}

		public void ClearAxisValue(int index)
		{
		}

		public void ClearAxisValue(string elementName)
		{
		}

		public void ClearAxisValueById(int elementId)
		{
		}

		public void ClearButtonValue(int index)
		{
		}

		public void ClearButtonValue(string elementName)
		{
		}

		public void ClearButtonValueById(int elementId)
		{
		}
	}
}
