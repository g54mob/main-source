using System;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class WindowShuttersSaveData
	{
		public bool IsOpen;

		public bool WasOpenAtLeastOnce;
	}
}
