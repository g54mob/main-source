using System;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class UnityUnifiedKeyboardSource : IUnifiedKeyboardSource, IGetSetEnabled, IDisposable
	{
		private const int BhwGLTIfGdGVHZAXBGVqFSpdHiFK = 132;

		private static HardwareControllerMap_Game WREeZWzGUsYHlZPgpUwnrdVyYXpR;

		private bool rziBsDbhFmFyBrEkgKFpmMlrrcrX;

		private bool rmIInyynvahnBrTcpbrUPEabFbFm;

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

		internal static HardwareControllerMap_Game CreateHardwareMap()
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
