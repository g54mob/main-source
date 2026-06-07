using System;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class UnityUnifiedKeyboardSource : IDisposable, IGetSetEnabled, IUnifiedKeyboardSource
	{
		private const int RXjRgsOMDkllwCDJkaPbnwoTSzQH = 132;

		private static HardwareControllerMap_Game MWUXdFVnrMGjoJuplFCUaTFIzejiB;

		private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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

		private static HardwareControllerMap_Game UbrfMNNvrvFcOBozobIHidyuqtTEb()
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
