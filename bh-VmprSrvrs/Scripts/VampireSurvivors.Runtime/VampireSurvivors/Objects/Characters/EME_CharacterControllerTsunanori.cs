using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class EME_CharacterControllerTsunanori : EME_CharacterControllerShowstopper
	{
		private WeaponType[] standardPassives;

		private CharacterType[] kugutsuTypes;

		private WeaponType[] kugutsuWeaponBackup;

		private int[] kugutsuLevels;

		private int kugutsuIndex;

		private List<CharacterType> currentFollowers;

		private bool _summonAllies;

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}

		private void MakeKugutsu(int index)
		{
		}
	}
}
