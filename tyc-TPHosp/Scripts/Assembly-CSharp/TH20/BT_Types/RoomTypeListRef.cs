using System;
using System.Collections.Generic;

namespace TH20.BT_Types
{
	[Serializable]
	public class RoomTypeListRef : ObjectRef<List<RoomDefinition.Type>>
	{
		public RoomTypeListRef()
		{
		}

		public RoomTypeListRef(List<RoomDefinition.Type> items)
			: base(items)
		{
		}
	}
}
