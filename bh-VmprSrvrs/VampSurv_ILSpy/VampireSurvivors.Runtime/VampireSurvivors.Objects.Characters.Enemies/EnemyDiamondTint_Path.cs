using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDiamondTint_Path : EnemyDiamondTint
{
	private PhaserSpline _spline;

	private float _curveTime;

	private float _maxPathWidth;

	private float _maxPathHeight;

	protected Vector2 _positionOffset;

	private float CurveSpeed;

	private float PathDuration;

	private readonly List<float> Curve2Data;

	protected override float ItemChance => 0.0615f;

	protected override bool IsImmovable => false;

	protected override bool IsAxe => false;

	protected override bool IsSnake => false;

	protected override bool DoBaseUpdate => false;

	protected override uint[] TintProgression => new uint[5] { 16764108u, 16746632u, 16729156u, 16720418u, 16711680u };

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		PhaserSpline spline = new PhaserSpline(Curve2Data);
		_spline = spline;
		InitPath();
	}

	protected override void OnRecycleEnemy()
	{
		base.OnRecycleEnemy();
		InitPath();
	}

	protected override void OnUpdate()
	{
		//IL_0078: Expected O, but got I4
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		base.OnUpdate();
		if (((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 float5 = gameSessionData._activeCharacter.position;
		float2 float6 = default(float2);
		base.position = float6;
		if (!((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField)
		{
			BaseBody baseBody = body;
			_ = 0;
			baseBody._velocity = (float2)0;
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * CurveSpeed;
			float num2 = (_curveTime = num + _curveTime);
			if (num2 < PathDuration)
			{
				float t = num2 / PathDuration;
				Vector2 point = _spline.GetPoint(t);
				Vector2 positionOffset = point * _maxPathWidth;
				_positionOffset = positionOffset;
				object obj = 0 * _maxPathHeight;
			}
			else
			{
				Disappear();
			}
		}
	}

	public void InitPath()
	{
		//IL_008d: Expected O, but got I4
		_curveTime = 0f;
		_positionOffset = (Vector2)0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float maxPathWidth = (float)renderer.pixelWidth * 0.01f;
		_maxPathWidth = maxPathWidth;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float maxPathHeight = (float)renderer2.pixelHeight * 0.01f;
		_maxPathHeight = maxPathHeight;
	}

	public void PositionRelativeToCenter()
	{
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 float5 = gameSessionData._activeCharacter.position;
		float2 float6 = default(float2);
		base.position = float6;
	}

	public EnemyDiamondTint_Path()
	{
		//IL_347e: Expected I, but got O
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_31ad: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_31d5: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_31fd: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_3225: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_324d: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_3275: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_329d: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_32c5: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_32ed: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_3315: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_333d: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_3365: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_338d: Expected O, but got I
		//IL_05e4: Expected O, but got I
		//IL_33b5: Expected O, but got I
		//IL_064e: Expected O, but got I
		//IL_33dd: Expected O, but got I
		//IL_06b8: Expected O, but got I
		//IL_3405: Expected O, but got I
		//IL_0722: Expected O, but got I
		//IL_342d: Expected O, but got I
		//IL_078c: Expected O, but got I
		//IL_3104: Expected O, but got I
		//IL_315e: Expected O, but got I
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_positionOffset = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		CurveSpeed = 1f;
		PathDuration = 65f;
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v14+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(0.0333f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1023960469;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v16+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v18+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(0.0667f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1032362498;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v20+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v22+18]");
		if (num10 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v24+18]");
		if (num11 >= 0)
		{
			list.AddWithResize(0.0333f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1023960469;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v26+18]");
		if (num12 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v28+18]");
		if (num13 >= 0)
		{
			list.AddWithResize(0.0667f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1032362498;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v30+18]");
		if (num14 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rcx_v32+18]");
		if (num15 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rcx_v34+18]");
		if (num16 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rcx_v36+18]");
		if (num17 >= 0)
		{
			list.AddWithResize(0.1333f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1040744396;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rcx_v38+18]");
		if (num18 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rcx_v40+18]");
		if (num19 >= 0)
		{
			list.AddWithResize(0.1667f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 1042985832;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rcx_v42+18]");
		if (num20 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		list.Add(0.2f);
		list.Add(0.1f);
		list.Add(0.2333f);
		list.Add(0.1f);
		list.Add(0.2667f);
		list.Add(0.1f);
		list.Add(0.3f);
		list.Add(0.1f);
		list.Add(0.3333f);
		list.Add(0.1f);
		list.Add(0.3667f);
		list.Add(0.1f);
		list.Add(0.4f);
		list.Add(0.1f);
		list.Add(0.4333f);
		list.Add(0.1f);
		list.Add(0.4667f);
		list.Add(0.1f);
		list.Add(0.5f);
		list.Add(0.1f);
		list.Add(0.5333f);
		list.Add(0.1f);
		list.Add(0.5667f);
		list.Add(0.1f);
		list.Add(0.6f);
		list.Add(0.1f);
		list.Add(0.6333f);
		list.Add(0.1f);
		list.Add(0.6667f);
		list.Add(0.1f);
		list.Add(0.7f);
		list.Add(0.1f);
		list.Add(0.7333f);
		list.Add(0.1f);
		list.Add(0.7667f);
		list.Add(0.1f);
		list.Add(0.8f);
		list.Add(0.1f);
		list.Add(0.8333f);
		list.Add(0.1f);
		list.Add(0.8667f);
		list.Add(0.1f);
		list.Add(0.9f);
		list.Add(0.1f);
		list.Add(0.9333f);
		list.Add(0.1f);
		list.Add(0.9667f);
		list.Add(0.1f);
		list.Add(1f);
		list.Add(0.1f);
		list.Add(1f);
		list.Add(0.1333f);
		list.Add(1f);
		list.Add(0.1667f);
		list.Add(1f);
		list.Add(0.2f);
		list.Add(0.9667f);
		list.Add(0.2f);
		list.Add(0.9333f);
		list.Add(0.2f);
		list.Add(0.9f);
		list.Add(0.2f);
		list.Add(0.8667f);
		list.Add(0.2f);
		list.Add(0.8333f);
		list.Add(0.2f);
		list.Add(0.8f);
		list.Add(0.2f);
		list.Add(0.7667f);
		list.Add(0.2f);
		list.Add(0.7333f);
		list.Add(0.2f);
		list.Add(0.7f);
		list.Add(0.2f);
		list.Add(0.6667f);
		list.Add(0.2f);
		list.Add(0.6333f);
		list.Add(0.2f);
		list.Add(0.6f);
		list.Add(0.2f);
		list.Add(0.5667f);
		list.Add(0.2f);
		list.Add(0.5333f);
		list.Add(0.2f);
		list.Add(0.5f);
		list.Add(0.2f);
		list.Add(0.4667f);
		list.Add(0.2f);
		list.Add(0.4333f);
		list.Add(0.2f);
		list.Add(0.4f);
		list.Add(0.2f);
		list.Add(0.3667f);
		list.Add(0.2f);
		list.Add(0.3333f);
		list.Add(0.2f);
		list.Add(0.3f);
		list.Add(0.2f);
		list.Add(0.2667f);
		list.Add(0.2f);
		list.Add(0.2333f);
		list.Add(0.2f);
		list.Add(0.2f);
		list.Add(0.2f);
		list.Add(0.1667f);
		list.Add(0.2f);
		list.Add(0.1333f);
		list.Add(0.2f);
		list.Add(0.1f);
		list.Add(0.2f);
		list.Add(0.0667f);
		list.Add(0.2f);
		list.Add(0.0333f);
		list.Add(0.2f);
		list.Add(0f);
		list.Add(0.2f);
		list.Add(0f);
		list.Add(0.2333f);
		list.Add(0f);
		list.Add(0.2667f);
		list.Add(0f);
		list.Add(0.3f);
		list.Add(0.0333f);
		list.Add(0.3f);
		list.Add(0.0667f);
		list.Add(0.3f);
		list.Add(0.1f);
		list.Add(0.3f);
		list.Add(0.1333f);
		list.Add(0.3f);
		list.Add(0.1667f);
		list.Add(0.3f);
		list.Add(0.2f);
		list.Add(0.3f);
		list.Add(0.2333f);
		list.Add(0.3f);
		list.Add(0.2667f);
		list.Add(0.3f);
		list.Add(0.3f);
		list.Add(0.3f);
		list.Add(0.3333f);
		list.Add(0.3f);
		list.Add(0.3667f);
		list.Add(0.3f);
		list.Add(0.4f);
		list.Add(0.3f);
		list.Add(0.4333f);
		list.Add(0.3f);
		list.Add(0.4667f);
		list.Add(0.3f);
		list.Add(0.5f);
		list.Add(0.3f);
		list.Add(0.5333f);
		list.Add(0.3f);
		list.Add(0.5667f);
		list.Add(0.3f);
		list.Add(0.6f);
		list.Add(0.3f);
		list.Add(0.6333f);
		list.Add(0.3f);
		list.Add(0.6667f);
		list.Add(0.3f);
		list.Add(0.7f);
		list.Add(0.3f);
		list.Add(0.7333f);
		list.Add(0.3f);
		list.Add(0.7667f);
		list.Add(0.3f);
		list.Add(0.8f);
		list.Add(0.3f);
		list.Add(0.8333f);
		list.Add(0.3f);
		list.Add(0.8667f);
		list.Add(0.3f);
		list.Add(0.9f);
		list.Add(0.3f);
		list.Add(0.9333f);
		list.Add(0.3f);
		list.Add(0.9667f);
		list.Add(0.3f);
		list.Add(1f);
		list.Add(0.3f);
		list.Add(1f);
		list.Add(0.3333f);
		list.Add(1f);
		list.Add(0.3667f);
		list.Add(1f);
		list.Add(0.4f);
		list.Add(0.9667f);
		list.Add(0.4f);
		list.Add(0.9333f);
		list.Add(0.4f);
		list.Add(0.9f);
		list.Add(0.4f);
		list.Add(0.8667f);
		list.Add(0.4f);
		list.Add(0.8333f);
		list.Add(0.4f);
		list.Add(0.8f);
		list.Add(0.4f);
		list.Add(0.7667f);
		list.Add(0.4f);
		list.Add(0.7333f);
		list.Add(0.4f);
		list.Add(0.7f);
		list.Add(0.4f);
		list.Add(0.6667f);
		list.Add(0.4f);
		list.Add(0.6333f);
		list.Add(0.4f);
		list.Add(0.6f);
		list.Add(0.4f);
		list.Add(0.5667f);
		list.Add(0.4f);
		list.Add(0.5333f);
		list.Add(0.4f);
		list.Add(0.5f);
		list.Add(0.4f);
		list.Add(0.4667f);
		list.Add(0.4f);
		list.Add(0.4333f);
		list.Add(0.4f);
		list.Add(0.4f);
		list.Add(0.4f);
		list.Add(0.3667f);
		list.Add(0.4f);
		list.Add(0.3333f);
		list.Add(0.4f);
		list.Add(0.3f);
		list.Add(0.4f);
		list.Add(0.2667f);
		list.Add(0.4f);
		list.Add(0.2333f);
		list.Add(0.4f);
		list.Add(0.2f);
		list.Add(0.4f);
		list.Add(0.1667f);
		list.Add(0.4f);
		list.Add(0.1333f);
		list.Add(0.4f);
		list.Add(0.1f);
		list.Add(0.4f);
		list.Add(0.0667f);
		list.Add(0.4f);
		list.Add(0.0333f);
		list.Add(0.4f);
		list.Add(0f);
		list.Add(0.4f);
		list.Add(0f);
		list.Add(0.4333f);
		list.Add(0f);
		list.Add(0.4667f);
		list.Add(0f);
		list.Add(0.5f);
		list.Add(0.0333f);
		list.Add(0.5f);
		list.Add(0.0667f);
		list.Add(0.5f);
		list.Add(0.1f);
		list.Add(0.5f);
		list.Add(0.1333f);
		list.Add(0.5f);
		list.Add(0.1667f);
		list.Add(0.5f);
		list.Add(0.2f);
		list.Add(0.5f);
		list.Add(0.2333f);
		list.Add(0.5f);
		list.Add(0.2667f);
		list.Add(0.5f);
		list.Add(0.3f);
		list.Add(0.5f);
		list.Add(0.3333f);
		list.Add(0.5f);
		list.Add(0.3667f);
		list.Add(0.5f);
		list.Add(0.4f);
		list.Add(0.5f);
		list.Add(0.4333f);
		list.Add(0.5f);
		list.Add(0.4667f);
		list.Add(0.5f);
		list.Add(0.5f);
		list.Add(0.5f);
		list.Add(0.5333f);
		list.Add(0.5f);
		list.Add(0.5667f);
		list.Add(0.5f);
		list.Add(0.6f);
		list.Add(0.5f);
		list.Add(0.6333f);
		list.Add(0.5f);
		list.Add(0.6667f);
		list.Add(0.5f);
		list.Add(0.7f);
		list.Add(0.5f);
		list.Add(0.7333f);
		list.Add(0.5f);
		list.Add(0.7667f);
		list.Add(0.5f);
		list.Add(0.8f);
		list.Add(0.5f);
		list.Add(0.8333f);
		list.Add(0.5f);
		list.Add(0.8667f);
		list.Add(0.5f);
		list.Add(0.9f);
		list.Add(0.5f);
		list.Add(0.9333f);
		list.Add(0.5f);
		list.Add(0.9667f);
		list.Add(0.5f);
		list.Add(1f);
		list.Add(0.5f);
		list.Add(1f);
		list.Add(0.5333f);
		list.Add(1f);
		list.Add(0.5667f);
		list.Add(1f);
		list.Add(0.6f);
		list.Add(0.9667f);
		list.Add(0.6f);
		list.Add(0.9333f);
		list.Add(0.6f);
		list.Add(0.9f);
		list.Add(0.6f);
		list.Add(0.8667f);
		list.Add(0.6f);
		list.Add(0.8333f);
		list.Add(0.6f);
		list.Add(0.8f);
		list.Add(0.6f);
		list.Add(0.7667f);
		list.Add(0.6f);
		list.Add(0.7333f);
		list.Add(0.6f);
		list.Add(0.7f);
		list.Add(0.6f);
		list.Add(0.6667f);
		list.Add(0.6f);
		list.Add(0.6333f);
		list.Add(0.6f);
		list.Add(0.6f);
		list.Add(0.6f);
		list.Add(0.5667f);
		list.Add(0.6f);
		list.Add(0.5333f);
		list.Add(0.6f);
		list.Add(0.5f);
		list.Add(0.6f);
		list.Add(0.4667f);
		list.Add(0.6f);
		list.Add(0.4333f);
		list.Add(0.6f);
		list.Add(0.4f);
		list.Add(0.6f);
		list.Add(0.3667f);
		list.Add(0.6f);
		list.Add(0.3333f);
		list.Add(0.6f);
		list.Add(0.3f);
		list.Add(0.6f);
		list.Add(0.2667f);
		list.Add(0.6f);
		list.Add(0.2333f);
		list.Add(0.6f);
		list.Add(0.2f);
		list.Add(0.6f);
		list.Add(0.1667f);
		list.Add(0.6f);
		list.Add(0.1333f);
		list.Add(0.6f);
		list.Add(0.1f);
		list.Add(0.6f);
		list.Add(0.0667f);
		list.Add(0.6f);
		list.Add(0.0333f);
		list.Add(0.6f);
		list.Add(0f);
		list.Add(0.6f);
		list.Add(0f);
		list.Add(0.6333f);
		list.Add(0f);
		list.Add(0.6667f);
		list.Add(0f);
		list.Add(0.7f);
		list.Add(0.0333f);
		list.Add(0.7f);
		list.Add(0.0667f);
		list.Add(0.7f);
		list.Add(0.1f);
		list.Add(0.7f);
		list.Add(0.1333f);
		list.Add(0.7f);
		list.Add(0.1667f);
		list.Add(0.7f);
		list.Add(0.2f);
		list.Add(0.7f);
		list.Add(0.2333f);
		list.Add(0.7f);
		list.Add(0.2667f);
		list.Add(0.7f);
		list.Add(0.3f);
		list.Add(0.7f);
		list.Add(0.3333f);
		list.Add(0.7f);
		list.Add(0.3667f);
		list.Add(0.7f);
		list.Add(0.4f);
		list.Add(0.7f);
		list.Add(0.4333f);
		list.Add(0.7f);
		list.Add(0.4667f);
		list.Add(0.7f);
		list.Add(0.5f);
		list.Add(0.7f);
		list.Add(0.5333f);
		list.Add(0.7f);
		list.Add(0.5667f);
		list.Add(0.7f);
		list.Add(0.6f);
		list.Add(0.7f);
		list.Add(0.6333f);
		list.Add(0.7f);
		list.Add(0.6667f);
		list.Add(0.7f);
		list.Add(0.7f);
		list.Add(0.7f);
		list.Add(0.7333f);
		list.Add(0.7f);
		list.Add(0.7667f);
		list.Add(0.7f);
		list.Add(0.8f);
		list.Add(0.7f);
		list.Add(0.8333f);
		list.Add(0.7f);
		list.Add(0.8667f);
		list.Add(0.7f);
		list.Add(0.9f);
		list.Add(0.7f);
		list.Add(0.9333f);
		list.Add(0.7f);
		list.Add(0.9667f);
		list.Add(0.7f);
		list.Add(1f);
		list.Add(0.7f);
		list.Add(1f);
		list.Add(0.7333f);
		list.Add(1f);
		list.Add(0.7667f);
		list.Add(1f);
		list.Add(0.8f);
		list.Add(0.9667f);
		list.Add(0.8f);
		list.Add(0.9333f);
		list.Add(0.8f);
		list.Add(0.9f);
		list.Add(0.8f);
		list.Add(0.8667f);
		list.Add(0.8f);
		list.Add(0.8333f);
		list.Add(0.8f);
		list.Add(0.8f);
		list.Add(0.8f);
		list.Add(0.7667f);
		list.Add(0.8f);
		list.Add(0.7333f);
		list.Add(0.8f);
		list.Add(0.7f);
		list.Add(0.8f);
		list.Add(0.6667f);
		list.Add(0.8f);
		list.Add(0.6333f);
		list.Add(0.8f);
		list.Add(0.6f);
		list.Add(0.8f);
		list.Add(0.5667f);
		list.Add(0.8f);
		list.Add(0.5333f);
		list.Add(0.8f);
		list.Add(0.5f);
		list.Add(0.8f);
		list.Add(0.4667f);
		list.Add(0.8f);
		list.Add(0.4333f);
		list.Add(0.8f);
		list.Add(0.4f);
		list.Add(0.8f);
		list.Add(0.3667f);
		list.Add(0.8f);
		list.Add(0.3333f);
		list.Add(0.8f);
		list.Add(0.3f);
		list.Add(0.8f);
		list.Add(0.2667f);
		list.Add(0.8f);
		list.Add(0.2333f);
		list.Add(0.8f);
		list.Add(0.2f);
		list.Add(0.8f);
		list.Add(0.1667f);
		list.Add(0.8f);
		list.Add(0.1333f);
		list.Add(0.8f);
		list.Add(0.1f);
		list.Add(0.8f);
		list.Add(0.0667f);
		list.Add(0.8f);
		list.Add(0.0333f);
		list.Add(0.8f);
		list.Add(0f);
		list.Add(0.8f);
		list.Add(0f);
		list.Add(0.8333f);
		list.Add(0f);
		list.Add(0.8667f);
		list.Add(0f);
		list.Add(0.9f);
		list.Add(0.0333f);
		list.Add(0.9f);
		list.Add(0.0667f);
		list.Add(0.9f);
		list.Add(0.1f);
		list.Add(0.9f);
		list.Add(0.1333f);
		list.Add(0.9f);
		list.Add(0.1667f);
		list.Add(0.9f);
		list.Add(0.2f);
		list.Add(0.9f);
		list.Add(0.2333f);
		list.Add(0.9f);
		list.Add(0.2667f);
		list.Add(0.9f);
		list.Add(0.3f);
		list.Add(0.9f);
		list.Add(0.3333f);
		list.Add(0.9f);
		list.Add(0.3667f);
		list.Add(0.9f);
		list.Add(0.4f);
		list.Add(0.9f);
		list.Add(0.4333f);
		list.Add(0.9f);
		list.Add(0.4667f);
		list.Add(0.9f);
		list.Add(0.5f);
		list.Add(0.9f);
		list.Add(0.5333f);
		list.Add(0.9f);
		list.Add(0.5667f);
		list.Add(0.9f);
		list.Add(0.6f);
		list.Add(0.9f);
		list.Add(0.6333f);
		list.Add(0.9f);
		list.Add(0.6667f);
		list.Add(0.9f);
		list.Add(0.7f);
		list.Add(0.9f);
		list.Add(0.7333f);
		list.Add(0.9f);
		list.Add(0.7667f);
		list.Add(0.9f);
		list.Add(0.8f);
		list.Add(0.9f);
		list.Add(0.8333f);
		list.Add(0.9f);
		list.Add(0.8667f);
		list.Add(0.9f);
		list.Add(0.9f);
		list.Add(0.9f);
		list.Add(0.9333f);
		list.Add(0.9f);
		list.Add(0.9667f);
		list.Add(0.9f);
		list.Add(1f);
		list.Add(0.9f);
		list.Add(1f);
		list.Add(0.9333f);
		list.Add(1f);
		list.Add(0.9667f);
		list.Add(1f);
		list.Add(1f);
		list.Add(0.9667f);
		list.Add(1f);
		list.Add(0.9333f);
		list.Add(1f);
		list.Add(0.9f);
		list.Add(1f);
		list.Add(0.8667f);
		list.Add(1f);
		list.Add(0.8333f);
		list.Add(1f);
		list.Add(0.8f);
		list.Add(1f);
		list.Add(0.7667f);
		list.Add(1f);
		list.Add(0.7333f);
		list.Add(1f);
		list.Add(0.7f);
		list.Add(1f);
		list.Add(0.6667f);
		list.Add(1f);
		list.Add(0.6333f);
		list.Add(1f);
		list.Add(0.6f);
		list.Add(1f);
		list.Add(0.5667f);
		list.Add(1f);
		list.Add(0.5333f);
		list.Add(1f);
		list.Add(0.5f);
		list.Add(1f);
		list.Add(0.4667f);
		list.Add(1f);
		list.Add(0.4333f);
		list.Add(1f);
		list.Add(0.4f);
		list.Add(1f);
		list.Add(0.3667f);
		list.Add(1f);
		list.Add(0.3333f);
		list.Add(1f);
		list.Add(0.3f);
		list.Add(1f);
		list.Add(0.2667f);
		list.Add(1f);
		list.Add(0.2333f);
		list.Add(1f);
		list.Add(0.2f);
		list.Add(1f);
		list.Add(0.1667f);
		list.Add(1f);
		list.Add(0.1333f);
		list.Add(1f);
		list.Add(0.1f);
		list.Add(1f);
		list.Add(0.0667f);
		list.Add(1f);
		list.Add(0.0333f);
		list.Add(1f);
		list.Add(0f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v22+18]");
		if (num21 >= 0)
		{
			list.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Curve2Data = list;
		base._grav = 0.3125f;
		((EnemyDiamond)this)._002Ector();
	}
}
