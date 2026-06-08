using System;

namespace GRP
{
	[Serializable]
	public class KitStepPartData
	{
		public ulong id;

		public ulong partId;

		public ModuleData module;

		public byte[] image;
	}
}
