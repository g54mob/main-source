using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI
{
	public class SkinItem
	{
		private PlayerOptions _playerOptions;

		private CharacterType _characterType;

		private CharacterData _characterData;

		private SkinType _skinType;

		private Skin _skinData;

		private UIUnlockStates _unlockState;

		public UIUnlockStates UnlockState => default(UIUnlockStates);

		public CharacterType CharacterType => default(CharacterType);

		public CharacterData CharacterData => null;

		public SkinType SkinType => default(SkinType);

		public Skin SkinData => null;

		public SkinItem(PlayerOptions playerOptions, CharacterType characterType, CharacterData characterData, SkinType skinType, Skin skinData)
		{
		}

		public void RefreshUnlockState()
		{
		}

		public bool CanSeeSecrets()
		{
			return false;
		}

		public bool IsSkinAlwaysHidden()
		{
			return false;
		}

		public bool IsSkinSecret()
		{
			return false;
		}

		public bool IsSkinHidden()
		{
			return false;
		}

		public bool IsSkinBought()
		{
			return false;
		}

		public bool IsSkinCoffinOpen()
		{
			return false;
		}

		public bool IsSkinUnlocked()
		{
			return false;
		}
	}
}
