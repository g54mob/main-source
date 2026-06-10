using System;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class UnityUnifiedKeyboardSource : IDisposable, IUnifiedKeyboardSource
	{
		private const int LlrUovCfTUxGGUgnbJAcjbLKjpNi = 132;

		private static HardwareControllerMap_Game QHWpuSHybsCpWwbHqQiDJLegBLk;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

		public InputSource inputSource => default(InputSource);

		public HardwareControllerMap_Game hardwareMap => null;

		public int buttonCount => 0;

		public Controller.Extension controllerExtension => null;

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
		}

		public void Clear()
		{
		}

		private static HardwareControllerMap_Game WKtVOpXzeTkyLFPPnaChpDWlCQH()
		{
			return null;
		}

		public void Dispose()
		{
		}

		~UnityUnifiedKeyboardSource()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			return default(ControllerElementType);
		}
	}
}
