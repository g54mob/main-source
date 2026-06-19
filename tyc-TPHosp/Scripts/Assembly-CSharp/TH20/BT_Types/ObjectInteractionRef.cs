using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class ObjectInteractionRef : ObjectRef<ObjectInteraction>
	{
		public ObjectInteractionRef()
		{
		}

		public ObjectInteractionRef(ObjectInteraction value)
			: base(value)
		{
		}

		public override void NullIfDestroyed()
		{
			ObjectInteraction get = base.Get;
			if (get != null && (get.HasBeenDestroyed() || get.ParentRoomItem == null || get.ParentRoomItem.HasBeenDestroyed()))
			{
				base.Get = null;
			}
		}
	}
}
