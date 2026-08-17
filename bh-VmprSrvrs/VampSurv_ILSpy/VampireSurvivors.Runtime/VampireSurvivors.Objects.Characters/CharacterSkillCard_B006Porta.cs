using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B006Porta : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_PASSIVE_CHARMUP;

	public CharacterSkillCard_B006Porta(ArcanaType type)
		: base(type)
	{
		Rarity = 3;
		Dictionary<int, ModifierStats> dictionary = new Dictionary<int, ModifierStats>();
		bool flag = ((Dictionary<int, object>)(object)dictionary).TryInsert(5, (object)new ModifierStats
		{
			_003CArea_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<int, object>)(object)dictionary).TryInsert(10, (object)new ModifierStats
		{
			_003CArea_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<int, object>)(object)dictionary).TryInsert(15, (object)new ModifierStats
		{
			_003CArea_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<int, object>)(object)dictionary).TryInsert(20, (object)new ModifierStats
		{
			_003CArea_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag5 = ((Dictionary<int, object>)(object)dictionary).TryInsert(25, (object)new ModifierStats
		{
			_003CArea_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1860");
		Dictionary<int, ModifierStats> dictionary2 = new Dictionary<int, ModifierStats>();
		bool flag6 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(2, (object)new ModifierStats
		{
			_003CCooldown_003Ek__BackingField = 0.3f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag7 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(3, (object)new ModifierStats
		{
			_003CCooldown_003Ek__BackingField = 0.3f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag8 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(4, (object)new ModifierStats
		{
			_003CCooldown_003Ek__BackingField = 0.3f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1860");
		InitialBonus = new ModifierStats
		{
			_003CCooldown_003Ek__BackingField = -0.9f
		};
	}
}
