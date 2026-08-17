using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B011Krochi : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_ONREVIVE_RAPIDFIRE;

	public CharacterSkillCard_B011Krochi(ArcanaType type)
		: base(type)
	{
		Dictionary<int, ModifierStats> dictionary = new Dictionary<int, ModifierStats>();
		bool flag = ((Dictionary<int, object>)(object)dictionary).TryInsert(11, (object)new ModifierStats
		{
			_003CRevivals_003Ek__BackingField = 1.0
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<int, object>)(object)dictionary).TryInsert(22, (object)new ModifierStats
		{
			_003CRevivals_003Ek__BackingField = 1.0
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<int, object>)(object)dictionary).TryInsert(33, (object)new ModifierStats
		{
			_003CRevivals_003Ek__BackingField = 1.0
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1860");
		InitialBonus = new ModifierStats
		{
			_003CMoveSpeed_003Ek__BackingField = 0.3f
		};
	}
}
