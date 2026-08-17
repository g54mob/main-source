using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Managers;
using Cpp2ILInjected;

namespace Assets.Scripts.Game.Spawning.New.Summoners;

public class SpecialSkeletonSummoner : BaseSummoner
{
	public SpecialSkeletonSummoner(int id, List<EEnemy> defaultEnemies)
		: base(id, defaultEnemies)
	{
	}

	protected override void Init()
	{
	}

	protected override List<EEnemy> GetEnemies()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0187: Expected O, but got I
		//IL_0116: Expected O, but got I
		List<EEnemy> list = new List<EEnemy>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v6+18]");
		if (num >= 0)
		{
			list.AddWithResize(EEnemy.GoldenSkeleton);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v6+18]");
			if (num2 >= 0)
			{
				goto IL_018c;
			}
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(EEnemy.XpSkeleton);
			return list;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
		object obj4 = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8+18]");
		if (num4 < 0)
		{
			_ = 2;
			return list;
		}
		goto IL_018c;
		IL_018c:
		return (List<EEnemy>)(object)new IndexOutOfRangeException();
	}

	public override List<Enemy> SpendCredits(bool useWeights = true)
	{
		EnemyCard randomCard = GetRandomCard(useWeights: true);
		if (randomCard == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return null;
		}
		if ((object)EnemyManager.Instance != null)
		{
			EEnemyFlag flag = default(EEnemyFlag);
			bool useDirectionBias = default(bool);
			Enemy enemy = EnemyManager.Instance.SpawnEnemy(randomCard.enemy, id, forceSpawn: true, flag, useDirectionBias);
			return null;
		}
		return (List<Enemy>)(object)new NullReferenceException();
	}

	public override float GetSummonInterval()
	{
		return 100f;
	}

	public override float GetBaseCreditsPerSecond()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	public override float GetInitialCredits()
	{
		return 1000f;
	}

	public override int GetNumTargetEnemies()
	{
		return 1;
	}

	protected override bool UseDirectionBias()
	{
		return false;
	}

	protected override bool ForceSpawn()
	{
		return true;
	}

	protected override bool UseMultiplier()
	{
		return false;
	}
}
