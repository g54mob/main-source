using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class BoraWeapon : Weapon
{
	private Camera _camera;

	private List<Vector2> _targetPoints;

	private int _lastRadiusIndex;

	private const int MaxAngles = 12;

	private bool _cooldownAffectedByMovement;

	private const float Mul = 333.33334f;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		Camera main = Camera.main;
		_camera = main;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float radius = renderer.height * 0.5f;
		List<Vector2> pointsOnCircle = MathTools.GetPointsOnCircle(12, radius);
		_targetPoints = pointsOnCircle;
	}

	public Vector2 GetTargetPoint()
	{
		//IL_004b: Expected O, but got I4
		//IL_0063: Expected O, but got I
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_00b4: Expected I4, but got O
		List<Vector2> targetPoints = _targetPoints;
		object obj = _lastRadiusIndex + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		nint num = default(nint);
		object obj2 = num >> 1;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 * 2;
		object obj6 = obj4 + obj5;
		object obj7 = obj6 << 2;
		int num2 = (_lastRadiusIndex = obj - obj7);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		Vector2 result = default(Vector2);
		if ((nint)num2 < (nint)0)
		{
			return result;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Vector2 result2 = default(Vector2);
		return result2;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		bool flag = !_cooldownAffectedByMovement;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		if (!flag)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = deltaTime2 * 1000f;
			float num4 = frameWalk * 100f;
			num2 = num3 / 333.33334f;
			float num5 = num4 * num2;
			float num6 = num5 + base._003CTotalTime_003Ek__BackingField;
			base._003CTotalTime_003Ek__BackingField = num6;
		}
		float num7 = base.PInterval();
		if (!(base._003CTotalTime_003Ek__BackingField < num2))
		{
			float num8 = base.PInterval();
			float num9 = base._003CTotalTime_003Ek__BackingField - num2;
			base._003CTotalTime_003Ek__BackingField = num9;
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	public BoraWeapon()
	{
		List<Vector2> targetPoints = new List<Vector2>();
		_targetPoints = targetPoints;
		base._002Ector();
	}
}
