using UnityEngine;

namespace Rewired.Interfaces
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IUnifiedMouseSource
	{
		InputSource inputSource { get; }

		HardwareControllerMap_Game hardwareMap { get; }

		int axisCount { get; }

		int buttonCount { get; }

		Vector2 mousePosition { get; }

		void UpdateInputData(ControllerDataUpdater dataUpdater);

		void Clear();
	}
}
