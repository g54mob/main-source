using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI
{
	public class CharacterItem
	{
		private PlayerOptions _playerOptions;

		private CharacterType _characterType;

		private CharacterData _characterData;

		private UIUnlockStates _unlockState;

		private Dictionary<SkinType, SkinItem> _skinItems;

		public UIUnlockStates UnlockState => default(UIUnlockStates);

		public CharacterType CharacterType => default(CharacterType);

		public CharacterData CharacterData => null;

		public CharacterItem(PlayerOptions playerOptions, CharacterType characterType, CharacterData characterData)
		{
		}

		public void RefreshUnlockState()
		{
		}

		public SkinItem GetCurrentSkinItem()
		{
			return null;
		}

		public Dictionary<SkinType, SkinItem> GetSkinItems()
		{
			return null;
		}

		public bool CanSeeSecrets()
		{
			return false;
		}

		public bool IsCharacterAlwaysHidden()
		{
			return false;
		}

		public bool IsCharacterSecret()
		{
			return false;
		}

		public bool IsCharacterHidden()
		{
			return false;
		}

		public bool IsCharacterBought()
		{
			return false;
		}

		public bool IsCharacterCoffinOpen()
		{
			return false;
		}

		public bool IsCharacterUnlocked()
		{
			return false;
		}

		public bool HasCharacterRequirements()
		{
			return false;
		}

		public bool HasCharacterRequirementsOrUnlock()
		{
			return false;
		}
	}
}
