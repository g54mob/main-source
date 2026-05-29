using UnityEngine;

namespace Rewired.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IUnifiedMouseSource
	{
		InputSource inputSource { get; }

		HardwareControllerMap_Game hardwareMap { get; }

		int axisCount { get; }

		int buttonCount { get; }

		Vector2 mousePosition { get; }

		Controller.Extension controllerExtension { get; }

		void UpdateInputData(ControllerDataUpdater dataUpdater);

		void Clear();
	}
}
