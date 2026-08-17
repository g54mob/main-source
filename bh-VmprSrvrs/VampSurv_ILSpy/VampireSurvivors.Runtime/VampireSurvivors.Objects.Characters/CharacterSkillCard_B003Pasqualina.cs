using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B003Pasqualina : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_ENEMIESCOUNT_ADDREVIVES;

	public CharacterSkillCard_B003Pasqualina(ArcanaType type)
		: base(type)
	{
		Dictionary<int, ModifierStats> dictionary = new Dictionary<int, ModifierStats>();
		bool flag = ((Dictionary<int, object>)(object)dictionary).TryInsert(5, (object)new ModifierStats
		{
			_003CSpeed_003Ek__BackingField = 0.1f,
			_003CDuration_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<int, object>)(object)dictionary).TryInsert(10, (object)new ModifierStats
		{
			_003CSpeed_003Ek__BackingField = 0.1f,
			_003CDuration_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<int, object>)(object)dictionary).TryInsert(15, (object)new ModifierStats
		{
			_003CSpeed_003Ek__BackingField = 0.1f,
			_003CDuration_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1860");
		InitialBonus = new ModifierStats
		{
			_003CRevivals_003Ek__BackingField = 1.0
		};
	}
}
