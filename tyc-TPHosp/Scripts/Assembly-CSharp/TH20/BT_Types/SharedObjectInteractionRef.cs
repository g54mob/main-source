using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedObjectInteractionRef : SharedObjectRef<ObjectInteractionRef, ObjectInteraction>
	{
		public static implicit operator SharedObjectInteractionRef(ObjectInteractionRef value)
		{
			return new SharedObjectInteractionRef
			{
				Value = value
			};
		}
	}
}
