using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyOnDefeat : EnemyController
{
	private Action _003COnDefeat_003Ek__BackingField;

	public Action OnDefeat
	{
		get
		{
			return _003COnDefeat_003Ek__BackingField;
		}
		set
		{
			_003COnDefeat_003Ek__BackingField = value;
		}
	}

	protected override void Die()
	{
		base.Die();
		Action action = _003COnDefeat_003Ek__BackingField;
		if (_003COnDefeat_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}
}
