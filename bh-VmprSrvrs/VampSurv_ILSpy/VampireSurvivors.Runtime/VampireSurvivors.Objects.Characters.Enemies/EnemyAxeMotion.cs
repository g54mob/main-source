using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyAxeMotion : EnemyController
{
	protected Vector2 _initialVelocity;

	private float _grav = 0.3125f;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0050: Expected O, but got F4
		base.InitEnemy(enemyType, asRemote);
		base._003CIsCullable_003Ek__BackingField = false;
		float2 float5 = base.position;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 float6 = gameSessionData._activeCharacter.position;
		float num3 = default(float);
		BaseBody baseBody = default(BaseBody);
		if (float5 <= float6 != 0)
		{
			float num = base._003CSpeed_003Ek__BackingField * 0.01f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,eax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A10818h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,qword ptr [188A10958h]\"");
			float num2 = 0f * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			num3 = num2 * num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			baseBody = body;
			float num4 = num2 * num;
		}
		baseBody._velocity = (float2)num3;
		BaseBody baseBody2 = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v15 (BaseBody)+74]");
		float num5 = 0f * -1f;
		BaseBody baseBody3 = body;
		_initialVelocity = baseBody3._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v16 (BaseBody)+74]");
		_ = 0;
	}

	protected override void OnUpdate()
	{
		//IL_01c3: Expected O, but got I4
		base.OnUpdate();
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
		if (!base._003CIsTimeStopped_003Ek__BackingField)
		{
			float2 float5 = base.position;
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 float6 = gameSessionData._activeCharacter.position;
			bool flag = (byte)(float5 < float6) != 0;
			object obj = float5 - float6;
			bool flag2 = obj == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			ArcadeSprite arcadeSprite2 = setFlipX(flag5);
			if (_receivingDamage)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,qword ptr [188A10510h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,xmm0\"");
			float deltaTime = PauseSystem.DeltaTime;
			float num2 = deltaTime * 1000f;
			float num3 = num2 * _grav;
			float num4 = num3 * 0.01f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyAxeMotion)+274]");
			float num5 = 0f - num4;
			float xVel = base._003CSpeed_003Ek__BackingField * (float)_initialVelocity;
			setVelocity(xVel, (float?)(object)1);
		}
	}
}
