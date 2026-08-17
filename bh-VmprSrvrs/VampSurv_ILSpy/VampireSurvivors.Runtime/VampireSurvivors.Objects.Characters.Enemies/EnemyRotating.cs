using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyRotating : EnemyController
{
	private float _previousDistance;

	private bool _isRotating;

	private Tween _onEnterTween;

	private Tween _onFireTimer;

	private Tween _rotateTween;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_028e: Expected O, but got I4
		//IL_0067: Expected O, but got Ref
		//IL_007d: Expected O, but got I8
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0316: Expected O, but got I4
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected O, but got Unknown
		_spritePivot = (Vector2)1056964608;
		_ = 1056964608;
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		base._003CSpeed_003Ek__BackingField = currentEnemyData._003Cspeed_003Ek__BackingField;
		_isRotating = false;
		if (_rotateTween != null)
		{
			goto IL_024f;
		}
		Transform target = _EnemyRenderer.transform;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&obj), 0.3f, RotateMode.FastBeyond360);
		object obj2 = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					object obj3 = tweenerCore + 184;
					object obj4 = obj3 >> 12;
					object obj5 = obj4 & 0x1FFFFF;
					object obj6 = obj5 >> 6;
					object obj7 = obj5 & 0x3F;
					nint num2;
					do
					{
						object obj8 = 1 << (int)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbp_v4+462E0+v334 @ rdx_v20*8]");
						object obj9 = 0 | obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbp_v4+462E0+v334 @ rdx_v20*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbp_v4+462E0+v334 @ rdx_v20*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbp_v4+462E0+v334 @ rdx_v20*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbp_v4+462E0+v334 @ rdx_v20*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = delegate
					{
						//IL_017c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0181: Expected O, but got Unknown
						//IL_0127->IL00cb: Incompatible stack heights: 1 vs 0
						//IL_019e->IL00d2: Incompatible stack heights: 2 vs 0
						bool flag3 = !base._fixedDirection;
						_isRotating = false;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018774789Bh\"");
							if ((object)_currentDirection != null)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018774789Bh\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRotating)+1E4]");
							if ((nint)0 != 0)
							{
								return;
							}
						}
						RetargetIfNecessary();
						Transform targetTransform = base._targetTransform;
						if ((object)base._targetTransform != null)
						{
							bool flag4 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
							Transform cachedTransform = _cachedTransform;
							if ((object)_cachedTransform != null)
							{
								bool flag5 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
								Vector2 currentDirection = ret - ret2;
								object obj11 = default(object);
								object obj12 = default(object);
								object obj10 = obj11 - obj12;
								Vector2 vector = (Vector2)(this + 480);
								_currentDirection = currentDirection;
								((Vector2*)vector)->Normalize();
								return;
							}
						}
						throw new NullReferenceException();
					};
					tweenCallback2 = tweenCallback;
					goto IL_01a3;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Expected O, but got Unknown
			//IL_0127->IL00cb: Incompatible stack heights: 1 vs 0
			//IL_019e->IL00d2: Incompatible stack heights: 2 vs 0
			bool flag3 = !base._fixedDirection;
			_isRotating = false;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018774789Bh\"");
				if ((object)_currentDirection != null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018774789Bh\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRotating)+1E4]");
				if ((nint)0 != 0)
				{
					return;
				}
			}
			RetargetIfNecessary();
			Transform targetTransform = base._targetTransform;
			if ((object)base._targetTransform != null)
			{
				bool flag4 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
				Transform cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag5 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
					Vector2 currentDirection = ret - ret2;
					object obj11 = default(object);
					object obj12 = default(object);
					object obj10 = obj11 - obj12;
					Vector2 vector = (Vector2)(this + 480);
					_currentDirection = currentDirection;
					((Vector2*)vector)->Normalize();
					return;
				}
			}
			throw new NullReferenceException();
		};
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag2)
		{
			goto IL_01a3;
		}
		goto IL_02e0;
		IL_02e0:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_rotateTween = tweenerCore;
		goto IL_024f;
		IL_01a3:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 0;
				}
			}
		}
		goto IL_02e0;
		IL_024f:
		if (_rotateTween != null)
		{
			Tween tween = TweenExtensions.Pause(_rotateTween);
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (!_isRotating)
		{
			float num = base._003CSpeed_003Ek__BackingField + 40f;
			EnemyData currentEnemyData = _currentEnemyData;
			_isRotating = true;
			base._003CSpeed_003Ek__BackingField = num;
			float num2 = currentEnemyData._003Cspeed_003Ek__BackingField + currentEnemyData._003Cspeed_003Ek__BackingField;
			if (num > num2)
			{
				base._003CSpeed_003Ek__BackingField = num2;
			}
			if (_rotateTween != null)
			{
				TweenExtensions.Restart(_rotateTween);
			}
		}
		bool hasKb2 = default(bool);
		base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb2);
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_01af: Expected O, but got F4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0135: Expected O, but got F4
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		base.UpdateDepth();
		if (base._003CIsTimeStopped_003Ek__BackingField)
		{
			return;
		}
		if (!_isRotating)
		{
			if (!base._fixedDirection)
			{
				goto IL_00cc;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018774753Ch\"");
			if ((object)_currentDirection == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018774753Ch\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRotating)+1E4]");
				if ((nint)0 == 0)
				{
					goto IL_00cc;
				}
			}
		}
		goto IL_0148;
		IL_0148:
		float num2;
		if (_receivingDamage)
		{
			float num = base._003CKnockBack_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = num ^ 0;
			num2 = (float)obj * _damageKb;
		}
		else
		{
			num2 = 1f;
		}
		bool flag = (nint)_currentDirection < 0;
		bool flag2 = (object)_currentDirection == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		base.SetFlipX(flag5);
		float num3 = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
		float num4 = num3 / 100f;
		float num5 = num4 * num2;
		float num6 = num5 * base._003CSlow_003Ek__BackingField;
		float num7 = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRotating)+1E4]");
		float num8 = num7 * 0f;
		float num9 = num6 * (float)_currentDirection;
		BaseBody baseBody = body;
		baseBody._velocity = (float2)num9;
		ProcessWiggle();
		return;
		IL_00cc:
		RetargetIfNecessary();
		Vector3 vector = base._targetTransform.position;
		Vector3 vector2 = _cachedTransform.position;
		float num10 = vector.x - vector2.x;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		Vector2 vector3 = (Vector2)(this + 480);
		_currentDirection = (Vector2)num10;
		((Vector2*)vector3)->Normalize();
		goto IL_0148;
	}

	protected override void ProcessWiggle()
	{
		if (!_isRotating)
		{
			base.ProcessWiggle();
		}
	}

	private void StartRotate()
	{
		float num = base._003CSpeed_003Ek__BackingField + 40f;
		EnemyData currentEnemyData = _currentEnemyData;
		base._003CSpeed_003Ek__BackingField = num;
		float num2 = currentEnemyData._003Cspeed_003Ek__BackingField + currentEnemyData._003Cspeed_003Ek__BackingField;
		if (num > num2)
		{
			base._003CSpeed_003Ek__BackingField = num2;
		}
		if (_rotateTween != null)
		{
			TweenExtensions.Restart(_rotateTween);
		}
	}

	private unsafe void _003CInitEnemy_003Eb__5_0()
	{
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0127->IL00cb: Incompatible stack heights: 1 vs 0
		//IL_019e->IL00d2: Incompatible stack heights: 2 vs 0
		bool flag = !base._fixedDirection;
		_isRotating = false;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018774789Bh\"");
			if ((object)_currentDirection != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018774789Bh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRotating)+1E4]");
			if ((nint)0 != 0)
			{
				return;
			}
		}
		RetargetIfNecessary();
		Transform targetTransform = base._targetTransform;
		if ((object)base._targetTransform != null)
		{
			bool flag2 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
				Vector2 currentDirection = ret - ret2;
				object obj2 = default(object);
				object obj3 = default(object);
				object obj = obj2 - obj3;
				Vector2 vector = (Vector2)(this + 480);
				_currentDirection = currentDirection;
				((Vector2*)vector)->Normalize();
				return;
			}
		}
		throw new NullReferenceException();
	}
}
