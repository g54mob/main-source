using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B020Osole : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_ADDWEAPON_FLOWER2;

	public CharacterSkillCard_B020Osole(ArcanaType type)
		: base(type)
	{
		Dictionary<int, ModifierStats> dictionary = new Dictionary<int, ModifierStats>();
		bool flag = ((Dictionary<int, object>)(object)dictionary).TryInsert(10, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = 1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<int, object>)(object)dictionary).TryInsert(20, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = 1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<int, object>)(object)dictionary).TryInsert(30, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = 1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1860");
		InitialBonus = new ModifierStats
		{
			_003CLuck_003Ek__BackingField = 0.2f
		};
	}
}
