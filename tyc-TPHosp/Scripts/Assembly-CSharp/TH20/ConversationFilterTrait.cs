using System;
using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class ConversationFilterTrait : ConversationFilter
	{
		[SerializeField]
		private SharedInstance_TH20TH20_CharacterTraitDefinition _trait;

		public bool IsValid(Character character)
		{
			if (_enabled)
			{
				if (character.Traits != null && _trait.NotNull())
				{
					return character.Traits.HasTrait(_trait.Instance);
				}
				return false;
			}
			return true;
		}
	}
}
