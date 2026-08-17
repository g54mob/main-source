using Rewired;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Framework;

public class CoopSlotData
{
	public CharacterType SelectedCharacter;

	public AIType AIType;

	public Player RewiredPlayer;

	public bool HasAControlInfluence()
	{
		if (RewiredPlayer != null)
		{
			return true;
		}
		bool flag = AIType < AIType.None;
		bool flag2 = AIType == AIType.None;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public void Reset()
	{
		SelectedCharacter = CharacterType.VOID;
		RewiredPlayer = null;
	}
}
