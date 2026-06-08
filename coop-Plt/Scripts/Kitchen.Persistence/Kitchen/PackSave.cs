using System.Collections.Generic;
using MessagePack;

namespace Kitchen
{
	[MessagePackObject(false)]
	public struct PackSave
	{
		[Key(0)]
		public int SaveVersion;

		[Key(1)]
		public List<ISaveObject> SaveObjects;
	}
}
