using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedCharacterActionRef : SharedObjectRef<CharacterActionRef, CharacterActionDefinition>
	{
		public static implicit operator SharedCharacterActionRef(CharacterActionRef value)
		{
			return new SharedCharacterActionRef
			{
				Value = value
			};
		}
	}
}
