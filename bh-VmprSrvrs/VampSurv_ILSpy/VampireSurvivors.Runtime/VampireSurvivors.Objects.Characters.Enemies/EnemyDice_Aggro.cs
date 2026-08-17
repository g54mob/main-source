using System;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDice_Aggro : EnemyDice
{
	protected override float ItemChance => 0.0615f;

	protected override bool IsImmovable => false;

	protected override bool IsAxe => false;

	protected override bool IsSnake => false;

	protected override bool DoBaseUpdate => true;

	public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
	{
		//IL_001e: Expected O, but got I
		//IL_0084: Expected O, but got I8
		base.InitEnemy(enemyType, asRemote);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		EnemyDice_Aggro enemyDice_Aggro = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			enemyDice_Aggro = (EnemyDice_Aggro)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v49 @ rax_v3 (should have been resolved before IL gen)");
		float num = 1f * ((EnemyController)this)._003CSpeed_003Ek__BackingField;
		((EnemyController)this)._003CSpeed_003Ek__BackingField = num;
	}

	public EnemyDice_Aggro()
	{
		base._grav = 0.3125f;
		((EnemyDiamond)this)._002Ector();
	}
}
