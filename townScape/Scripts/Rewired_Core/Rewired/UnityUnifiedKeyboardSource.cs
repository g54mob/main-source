using System;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class UnityUnifiedKeyboardSource : IDisposable, IUnifiedKeyboardSource
	{
		private const int KHMUiUwFxgBkOdGppNpWfZanfjTr = 132;

		private static HardwareControllerMap_Game NztSjlvuLOiUKcxJaZrllbBRXkg;

		private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

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

		private static HardwareControllerMap_Game PkWgldifXdclmzHLbKNaGRabEUUc()
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
