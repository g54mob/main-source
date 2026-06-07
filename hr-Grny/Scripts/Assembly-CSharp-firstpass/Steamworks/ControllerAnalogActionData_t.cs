using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 1, Size = 13)]
	public struct ControllerAnalogActionData_t
	{
		public EControllerSourceMode eMode;

		public float x;

		public float y;

		public byte bActive;
	}
}
