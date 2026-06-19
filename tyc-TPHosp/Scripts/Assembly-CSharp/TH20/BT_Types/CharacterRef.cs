using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class CharacterRef : ObjectRef<Character>
	{
		public CharacterRef()
		{
		}

		public CharacterRef(Character character)
			: base(character)
		{
		}
	}
}
