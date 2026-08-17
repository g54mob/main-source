using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B008Poe : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_HPCRITICAL_RECOVERHP;

	public CharacterSkillCard_B008Poe(ArcanaType type)
		: base(type)
	{
		Dictionary<int, ModifierStats> dictionary = new Dictionary<int, ModifierStats>();
		bool flag = ((Dictionary<int, object>)(object)dictionary).TryInsert(5, (object)new ModifierStats
		{
			_003CRegen_003Ek__BackingField = 0.2f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<int, object>)(object)dictionary).TryInsert(10, (object)new ModifierStats
		{
			_003CRegen_003Ek__BackingField = 0.2f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<int, object>)(object)dictionary).TryInsert(15, (object)new ModifierStats
		{
			_003CRegen_003Ek__BackingField = 0.2f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<int, object>)(object)dictionary).TryInsert(20, (object)new ModifierStats
		{
			_003CRegen_003Ek__BackingField = 0.2f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag5 = ((Dictionary<int, object>)(object)dictionary).TryInsert(25, (object)new ModifierStats
		{
			_003CRegen_003Ek__BackingField = 0.2f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1860");
		InitialBonus = new ModifierStats
		{
			_003CMagnet_003Ek__BackingField = 0.3f
		};
	}
}
