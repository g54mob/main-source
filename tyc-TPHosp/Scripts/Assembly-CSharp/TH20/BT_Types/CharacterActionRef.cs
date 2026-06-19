using System;

namespace TH20.BT_Types
{
	[Serializable]
	public class CharacterActionRef : ObjectRef<CharacterActionDefinition>
	{
		public CharacterActionRef()
		{
		}

		public CharacterActionRef(CharacterActionDefinition characterActionDef)
			: base(characterActionDef)
		{
		}
	}
}
