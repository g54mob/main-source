using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Cart2Weapon : Weapon
{
	private float _mul = 83.333336f;

	private bool _cooldownAffectedByMovement;

	private ArcadeBodyBounds _003CCustomWorldBounds_003Ek__BackingField;

	private ArcadeBodyBounds _003CCustomWorldBoundsHoming_003Ek__BackingField;

	public ArcadeBodyBounds CustomWorldBounds
	{
		get
		{
			return _003CCustomWorldBounds_003Ek__BackingField;
		}
		private set
		{
			_003CCustomWorldBounds_003Ek__BackingField = value;
		}
	}

	public ArcadeBodyBounds CustomWorldBoundsHoming
	{
		get
		{
			return _003CCustomWorldBoundsHoming_003Ek__BackingField;
		}
		private set
		{
			_003CCustomWorldBoundsHoming_003Ek__BackingField = value;
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		ArcadeBodyBounds arcadeBodyBounds = new ArcadeBodyBounds();
		arcadeBodyBounds.x = 0f;
		arcadeBodyBounds.width = 0f;
		_003CCustomWorldBounds_003Ek__BackingField = arcadeBodyBounds;
		ArcadeBodyBounds arcadeBodyBounds2 = new ArcadeBodyBounds();
		arcadeBodyBounds2.x = 0f;
		arcadeBodyBounds2.width = 0f;
		_003CCustomWorldBoundsHoming_003Ek__BackingField = arcadeBodyBounds2;
		UpdateCollisionBounds();
		SetHomingCollisionBounds();
	}

	private void UpdateCollisionBounds()
	{
		ArcadeBodyBounds arcadeBodyBounds = _003CCustomWorldBounds_003Ek__BackingField;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		arcadeBodyBounds.width = renderer.width;
		ArcadeBodyBounds arcadeBodyBounds2 = _003CCustomWorldBounds_003Ek__BackingField;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float height = renderer2.height * 4f;
		arcadeBodyBounds2.height = height;
		ArcadeBodyBounds arcadeBodyBounds3 = _003CCustomWorldBounds_003Ek__BackingField;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		ArcadeBodyBounds arcadeBodyBounds4 = _003CCustomWorldBounds_003Ek__BackingField;
		float num = arcadeBodyBounds4.width * 0.5f;
		float x = (float)renderer3.screenCenter - num;
		arcadeBodyBounds3.x = x;
		ArcadeBodyBounds arcadeBodyBounds5 = _003CCustomWorldBounds_003Ek__BackingField;
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer4 = s_scene4._renderer;
		ArcadeBodyBounds arcadeBodyBounds6 = _003CCustomWorldBounds_003Ek__BackingField;
		float num2 = arcadeBodyBounds6.height * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v14 (PhaserScene+Renderer)+38]");
		float y = 0f - num2;
		arcadeBodyBounds5.y = y;
	}

	private void SetHomingCollisionBounds()
	{
		ArcadeBodyBounds arcadeBodyBounds = _003CCustomWorldBoundsHoming_003Ek__BackingField;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		arcadeBodyBounds.width = renderer.width;
		ArcadeBodyBounds arcadeBodyBounds2 = _003CCustomWorldBoundsHoming_003Ek__BackingField;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		arcadeBodyBounds2.height = renderer2.height;
		ArcadeBodyBounds arcadeBodyBounds3 = _003CCustomWorldBoundsHoming_003Ek__BackingField;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		ArcadeBodyBounds arcadeBodyBounds4 = _003CCustomWorldBoundsHoming_003Ek__BackingField;
		float num = arcadeBodyBounds4.width * 0.5f;
		float x = (float)renderer3.screenCenter - num;
		arcadeBodyBounds3.x = x;
		ArcadeBodyBounds arcadeBodyBounds5 = _003CCustomWorldBoundsHoming_003Ek__BackingField;
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer4 = s_scene4._renderer;
		ArcadeBodyBounds arcadeBodyBounds6 = _003CCustomWorldBoundsHoming_003Ek__BackingField;
		float num2 = arcadeBodyBounds6.height * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v13 (PhaserScene+Renderer)+38]");
		float y = 0f - num2;
		arcadeBodyBounds5.y = y;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_0133: Invalid comparison between O and F4
		//IL_004f: Expected F4, but got O
		//IL_0074->IL008a: Incompatible stack heights: 1 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Vector2 vector = default(Vector2);
				Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
				float num = base.PInterval();
				float num2 = _lastFiringInterval - (float)vector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				object obj = num2 & 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
				{
					float num3 = base.PInterval();
					_lastFiringInterval = (float)vector;
					ResetFiringTimer();
				}
				if (skipTriggers)
				{
					return;
				}
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		//IL_005e: Expected O, but got I
		//IL_00f9: Expected O, but got I
		//IL_0191: Expected O, but got I
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_020a: Expected O, but got I
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_0379: Expected O, but got I4
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Expected O, but got Unknown
		//IL_039e: Expected I4, but got O
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager3 = gameMan3._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb edi,edi\"");
		object obj5 = default(object);
		object obj4 = obj5 & 3;
		GameManager gameMan4 = _gameMan;
		ArcanaManager arcanaManager4 = gameMan4._arcanaManager;
		List<ArcanaType> list4 = arcanaManager4._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		bool flag;
		if ((nint)0 == 0)
		{
			flag = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj7 = default(object);
			object obj6 = obj7 - -1;
			bool flag2 = obj6 == null;
			flag = !flag2;
		}
		object obj8 = 0 - (flag ? 1 : 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb eax,eax\"");
		object obj9 = obj8 & 3;
		int bonusBounces = (int)(obj9 + obj4);
		_bonusBounces = bonusBounces;
		CheckBeginningArcana();
		if (_beginningArcana)
		{
			return;
		}
		GameManager gameMan5 = _gameMan;
		List<WeaponType> list5 = gameMan5._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 > (nint)0)
		{
			GameManager gameMan6 = _gameMan;
			List<WeaponType> list6 = gameMan6._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj10 = default(object);
			if (obj10 == null)
			{
				int beginningAmount = _beginningAmount + 1;
				_beginningAmount = beginningAmount;
				WeaponData currentWeaponData = _currentWeaponData;
				_beginningArcana = true;
				int num = currentWeaponData._003Camount_003Ek__BackingField + 1;
				currentWeaponData._003Camount_003Ek__BackingField = num;
			}
		}
	}

	public override int PBounces()
	{
		//IL_0005: Expected I, but got O
		//IL_002a: Expected O, but got I4
		//IL_0037: Expected I4, but got O
		nint num = (nint)this;
		float num2 = base.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj = _bonusBounces + _bounces;
		object obj2 = default(object);
		return (int)(obj2 + obj);
	}

	public override void InternalUpdate()
	{
		if (!IsHoming)
		{
			UpdateCollisionBounds();
		}
		else
		{
			SetHomingCollisionBounds();
		}
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
			float num5 = num3 / _mul;
			float num6 = num5 * num4;
			num2 = (base._003CTotalTime_003Ek__BackingField = num6 + base._003CTotalTime_003Ek__BackingField);
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
}
