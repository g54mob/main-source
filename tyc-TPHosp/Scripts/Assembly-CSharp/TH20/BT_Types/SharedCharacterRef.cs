using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class SharedCharacterRef : SharedObjectRef<CharacterRef, Character>
	{
		public static implicit operator SharedCharacterRef(CharacterRef value)
		{
			return new SharedCharacterRef
			{
				Value = value
			};
		}
	}
}
