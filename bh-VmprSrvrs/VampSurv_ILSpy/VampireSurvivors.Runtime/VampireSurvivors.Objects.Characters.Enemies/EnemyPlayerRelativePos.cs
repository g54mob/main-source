using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyPlayerRelativePos : EnemyController
{
	private PhaserSpline _spline;

	private float _curveTime;

	private float _maxPathWidth;

	private float _maxPathHeight;

	protected Vector2 _positionOffset;

	public float CurveSpeed;

	public float PathDuration;

	private readonly List<float> CurveData;

	private readonly List<float> Curve2Data;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		base._003CIsCullable_003Ek__BackingField = false;
		PhaserSpline spline = new PhaserSpline(CurveData);
		_spline = spline;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 91 Invalid \"Jump target not found in method: 0x18773BB80\"");
	}

	protected override void OnRecycleEnemy()
	{
		base.OnRecycleEnemy();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x18773BB80\"");
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

	protected override void OnUpdate()
	{
		//IL_0071: Expected O, but got I4
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		base.OnUpdate();
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
		float2 float5 = default(float2);
		base.position = float5;
		if (!base._003CIsTimeStopped_003Ek__BackingField)
		{
			BaseBody baseBody = body;
			_ = 0;
			baseBody._velocity = (float2)0;
			float deltaTime = PauseSystem.DeltaTime;
			float num2 = deltaTime * CurveSpeed;
			float num3 = (_curveTime = num2 + _curveTime);
			if (num3 < PathDuration)
			{
				float t = num3 / PathDuration;
				Vector2 point = _spline.GetPoint(t);
				Vector2 positionOffset = point * _maxPathWidth;
				_positionOffset = positionOffset;
				object obj = 0 * _maxPathHeight;
			}
			else
			{
				base.Disappear();
			}
		}
	}

	public void PositionRelativeToCenter()
	{
		float2 float5 = default(float2);
		base.position = float5;
	}

	public EnemyPlayerRelativePos()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A630F]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB70C0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB70C0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB70C0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB70C0");
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
		Vector2 positionOffset = default(Vector2);
		_positionOffset = positionOffset;
		CurveSpeed = 1f;
		PathDuration = 100f;
		List<float> list = new List<float>
		{
			0f, 0f, 0f, 0.0333f, 0f, 0.0667f, 0f, 0.1f, 0.0333f, 0.1f,
			0.0667f, 0.1f, 0.1f, 0.1f, 0.1333f, 0.1f, 0.1667f, 0.1f, 0.2f, 0.1f,
			0.2333f, 0.1f, 0.2667f, 0.1f, 0.3f, 0.1f, 0.3333f, 0.1f, 0.3667f, 0.1f,
			0.4f, 0.1f, 0.4333f, 0.1f, 0.4667f, 0.1f, 0.5f, 0.1f, 0.5333f, 0.1f,
			0.5667f, 0.1f, 0.6f, 0.1f, 0.6333f, 0.1f, 0.6667f, 0.1f, 0.7f, 0.1f,
			0.7333f, 0.1f, 0.7667f, 0.1f, 0.8f, 0.1f, 0.8333f, 0.1f, 0.8667f, 0.1f,
			0.9f, 0.1f, 0.9333f, 0.1f, 0.9667f, 0.1f, 1f, 0.1f, 1f, 0.1333f,
			1f, 0.1667f, 1f, 0.2f, 0.9667f, 0.2f, 0.9333f, 0.2f, 0.9f, 0.2f,
			0.8667f, 0.2f, 0.8333f, 0.2f, 0.8f, 0.2f, 0.7667f, 0.2f, 0.7333f, 0.2f,
			0.7f, 0.2f, 0.6667f, 0.2f, 0.6333f, 0.2f, 0.6f, 0.2f, 0.5667f, 0.2f,
			0.5333f, 0.2f, 0.5f, 0.2f, 0.4667f, 0.2f, 0.4333f, 0.2f, 0.4f, 0.2f,
			0.3667f, 0.2f, 0.3333f, 0.2f, 0.3f, 0.2f, 0.2667f, 0.2f, 0.2333f, 0.2f,
			0.2f, 0.2f, 0.1667f, 0.2f, 0.1333f, 0.2f, 0.1f, 0.2f, 0.0667f, 0.2f,
			0.0333f, 0.2f, 0f, 0.2f, 0f, 0.2333f, 0f, 0.2667f, 0f, 0.3f,
			0.0333f, 0.3f, 0.0667f, 0.3f, 0.1f, 0.3f, 0.1333f, 0.3f, 0.1667f, 0.3f,
			0.2f, 0.3f, 0.2333f, 0.3f, 0.2667f, 0.3f, 0.3f, 0.3f, 0.3333f, 0.3f,
			0.3667f, 0.3f, 0.4f, 0.3f, 0.4333f, 0.3f, 0.4667f, 0.3f, 0.5f, 0.3f,
			0.5333f, 0.3f, 0.5667f, 0.3f, 0.6f, 0.3f, 0.6333f, 0.3f, 0.6667f, 0.3f,
			0.7f, 0.3f, 0.7333f, 0.3f, 0.7667f, 0.3f, 0.8f, 0.3f, 0.8333f, 0.3f,
			0.8667f, 0.3f, 0.9f, 0.3f, 0.9333f, 0.3f, 0.9667f, 0.3f, 1f, 0.3f,
			1f, 0.3333f, 1f, 0.3667f, 1f, 0.4f, 0.9667f, 0.4f, 0.9333f, 0.4f,
			0.9f, 0.4f, 0.8667f, 0.4f, 0.8333f, 0.4f, 0.8f, 0.4f, 0.7667f, 0.4f,
			0.7333f, 0.4f, 0.7f, 0.4f, 0.6667f, 0.4f, 0.6333f, 0.4f, 0.6f, 0.4f,
			0.5667f, 0.4f, 0.5333f, 0.4f, 0.5f, 0.4f, 0.4667f, 0.4f, 0.4333f, 0.4f,
			0.4f, 0.4f, 0.3667f, 0.4f, 0.3333f, 0.4f, 0.3f, 0.4f, 0.2667f, 0.4f,
			0.2333f, 0.4f, 0.2f, 0.4f, 0.1667f, 0.4f, 0.1333f, 0.4f, 0.1f, 0.4f,
			0.0667f, 0.4f, 0.0333f, 0.4f, 0f, 0.4f, 0f, 0.4333f, 0f, 0.4667f,
			0f, 0.5f, 0.0333f, 0.5f, 0.0667f, 0.5f, 0.1f, 0.5f, 0.1333f, 0.5f,
			0.1667f, 0.5f, 0.2f, 0.5f, 0.2333f, 0.5f, 0.2667f, 0.5f, 0.3f, 0.5f,
			0.3333f, 0.5f, 0.3667f, 0.5f, 0.4f, 0.5f, 0.4333f, 0.5f, 0.4667f, 0.5f,
			0.5f, 0.5f, 0.5333f, 0.5f, 0.5667f, 0.5f, 0.6f, 0.5f, 0.6333f, 0.5f,
			0.6667f, 0.5f, 0.7f, 0.5f, 0.7333f, 0.5f, 0.7667f, 0.5f, 0.8f, 0.5f,
			0.8333f, 0.5f, 0.8667f, 0.5f, 0.9f, 0.5f, 0.9333f, 0.5f, 0.9667f, 0.5f,
			1f, 0.5f, 1f, 0.5333f, 1f, 0.5667f, 1f, 0.6f, 0.9667f, 0.6f,
			0.9333f, 0.6f, 0.9f, 0.6f, 0.8667f, 0.6f, 0.8333f, 0.6f, 0.8f, 0.6f,
			0.7667f, 0.6f, 0.7333f, 0.6f, 0.7f, 0.6f, 0.6667f, 0.6f, 0.6333f, 0.6f,
			0.6f, 0.6f, 0.5667f, 0.6f, 0.5333f, 0.6f, 0.5f, 0.6f, 0.4667f, 0.6f,
			0.4333f, 0.6f, 0.4f, 0.6f, 0.3667f, 0.6f, 0.3333f, 0.6f, 0.3f, 0.6f,
			0.2667f, 0.6f, 0.2333f, 0.6f, 0.2f, 0.6f, 0.1667f, 0.6f, 0.1333f, 0.6f,
			0.1f, 0.6f, 0.0667f, 0.6f, 0.0333f, 0.6f, 0f, 0.6f, 0f, 0.6333f,
			0f, 0.6667f, 0f, 0.7f, 0.0333f, 0.7f, 0.0667f, 0.7f, 0.1f, 0.7f,
			0.1333f, 0.7f, 0.1667f, 0.7f, 0.2f, 0.7f, 0.2333f, 0.7f, 0.2667f, 0.7f,
			0.3f, 0.7f, 0.3333f, 0.7f, 0.3667f, 0.7f, 0.4f, 0.7f, 0.4333f, 0.7f,
			0.4667f, 0.7f, 0.5f, 0.7f, 0.5333f, 0.7f, 0.5667f, 0.7f, 0.6f, 0.7f,
			0.6333f, 0.7f, 0.6667f, 0.7f, 0.7f, 0.7f, 0.7333f, 0.7f, 0.7667f, 0.7f,
			0.8f, 0.7f, 0.8333f, 0.7f, 0.8667f, 0.7f, 0.9f, 0.7f, 0.9333f, 0.7f,
			0.9667f, 0.7f, 1f, 0.7f, 1f, 0.7333f, 1f, 0.7667f, 1f, 0.8f,
			0.9667f, 0.8f, 0.9333f, 0.8f, 0.9f, 0.8f, 0.8667f, 0.8f, 0.8333f, 0.8f,
			0.8f, 0.8f, 0.7667f, 0.8f, 0.7333f, 0.8f, 0.7f, 0.8f, 0.6667f, 0.8f,
			0.6333f, 0.8f, 0.6f, 0.8f, 0.5667f, 0.8f, 0.5333f, 0.8f, 0.5f, 0.8f,
			0.4667f, 0.8f, 0.4333f, 0.8f, 0.4f, 0.8f, 0.3667f, 0.8f, 0.3333f, 0.8f,
			0.3f, 0.8f, 0.2667f, 0.8f, 0.2333f, 0.8f, 0.2f, 0.8f, 0.1667f, 0.8f,
			0.1333f, 0.8f, 0.1f, 0.8f, 0.0667f, 0.8f, 0.0333f, 0.8f, 0f, 0.8f,
			0f, 0.8333f, 0f, 0.8667f, 0f, 0.9f, 0.0333f, 0.9f, 0.0667f, 0.9f,
			0.1f, 0.9f, 0.1333f, 0.9f, 0.1667f, 0.9f, 0.2f, 0.9f, 0.2333f, 0.9f,
			0.2667f, 0.9f, 0.3f, 0.9f, 0.3333f, 0.9f, 0.3667f, 0.9f, 0.4f, 0.9f,
			0.4333f, 0.9f, 0.4667f, 0.9f, 0.5f, 0.9f, 0.5333f, 0.9f, 0.5667f, 0.9f,
			0.6f, 0.9f, 0.6333f, 0.9f, 0.6667f, 0.9f, 0.7f, 0.9f, 0.7333f, 0.9f,
			0.7667f, 0.9f, 0.8f, 0.9f, 0.8333f, 0.9f, 0.8667f, 0.9f, 0.9f, 0.9f,
			0.9333f, 0.9f, 0.9667f, 0.9f, 1f, 0.9f, 1f, 0.9333f, 1f, 0.9667f,
			1f, 1f, 0.9667f, 1f, 0.9333f, 1f, 0.9f, 1f, 0.8667f, 1f,
			0.8333f, 1f, 0.8f, 1f, 0.7667f, 1f, 0.7333f, 1f, 0.7f, 1f,
			0.6667f, 1f, 0.6333f, 1f, 0.6f, 1f, 0.5667f, 1f, 0.5333f, 1f,
			0.5f, 1f, 0.4667f, 1f, 0.4333f, 1f, 0.4f, 1f
		};
		throw new NullReferenceException();
	}
}
