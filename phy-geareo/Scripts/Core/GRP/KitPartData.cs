using System;

namespace GRP
{
	[Serializable]
	public class KitPartData
	{
		public ulong id;

		public ModuleData module;

		public int count;

		public byte[] image;
	}
}
