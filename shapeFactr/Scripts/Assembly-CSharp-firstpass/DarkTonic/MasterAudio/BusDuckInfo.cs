using System;
using System.Collections.Generic;

namespace DarkTonic.MasterAudio
{
	[Serializable]
	public class BusDuckInfo
	{
		public List<GroupBus> BusesToDuck;

		public bool IsActive;
	}
}
