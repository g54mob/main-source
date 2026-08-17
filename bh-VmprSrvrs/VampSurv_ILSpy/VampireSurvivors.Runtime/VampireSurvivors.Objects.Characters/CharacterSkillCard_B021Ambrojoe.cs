using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B021Ambrojoe : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_ENEMIESCOUNT_ADDAMOUNT;

	public CharacterSkillCard_B021Ambrojoe(ArcanaType type)
		: base(type)
	{
		Dictionary<int, ModifierStats> dictionary = new Dictionary<int, ModifierStats>();
		bool flag = ((Dictionary<int, object>)(object)dictionary).TryInsert(5, (object)new ModifierStats
		{
			_003CMagnet_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<int, object>)(object)dictionary).TryInsert(10, (object)new ModifierStats
		{
			_003CMagnet_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<int, object>)(object)dictionary).TryInsert(15, (object)new ModifierStats
		{
			_003CMagnet_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<int, object>)(object)dictionary).TryInsert(20, (object)new ModifierStats
		{
			_003CMagnet_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag5 = ((Dictionary<int, object>)(object)dictionary).TryInsert(25, (object)new ModifierStats
		{
			_003CMagnet_003Ek__BackingField = 0.1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1860");
		Dictionary<int, ModifierStats> dictionary2 = new Dictionary<int, ModifierStats>();
		bool flag6 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(2, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = -1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag7 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(3, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = -1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag8 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(4, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = -1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag9 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(5, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = -1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag10 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(6, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = -1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag11 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(7, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = -1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag12 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(8, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = -1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag13 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(9, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = -1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag14 = ((Dictionary<int, object>)(object)dictionary2).TryInsert(10, (object)new ModifierStats
		{
			_003CAmount_003Ek__BackingField = -1f
		}, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1860");
		InitialBonus = new ModifierStats
		{
			_003CAmount_003Ek__BackingField = 10f
		};
	}
}
