using Rewired;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Framework
{
	public class CoopSlotData
	{
		public CharacterType SelectedCharacter;

		public AIType AIType;

		public Player RewiredPlayer;

		public bool HasAControlInfluence()
		{
			return false;
		}

		public void Reset()
		{
		}
	}
}
