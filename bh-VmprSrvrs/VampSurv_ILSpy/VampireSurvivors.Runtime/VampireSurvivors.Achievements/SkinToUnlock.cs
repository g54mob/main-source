using System;
using VampireSurvivors.Data;

namespace VampireSurvivors.Achievements;

[Serializable]
public class SkinToUnlock
{
	public CharacterType character;

	public SkinType skin;

	public bool weaponOnly;
}
