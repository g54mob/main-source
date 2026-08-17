using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyStaticVaseMoon : EnemyStaticVase
{
	private MultiTargetTween _despawnTween;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		((EnemyStatic)this).InitEnemy(enemyType, asRemote);
		base.SetFlipX(flip: false);
		base.SetFlipX(flip: false);
		SetTint();
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		((EnemyController)this)._003CIsTeleportOnCull_003Ek__BackingField = true;
	}

	public override void Despawn()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			((EnemyController)this).Despawn();
			if (((EnemyStatic)this)._onEnterTween != null)
			{
				((EnemyStatic)this)._onEnterTween.Pause();
			}
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween despawnTween = Tweens.Add(tweenConfig);
		_despawnTween = despawnTween;
	}

	protected override void OnUpdate()
	{
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			UpdateDepth();
			if (!((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField)
			{
				ProcessWiggle();
			}
		}
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rbx_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rbx_v2 (System.Object)+10]");
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected((IntPtr)0, ref value);
	}

	protected override void ProcessWiggle()
	{
	}

	protected override void Die()
	{
		//IL_014f->IL00bf: Incompatible stack heights: 1 vs 0
		//IL_0097->IL00bf: Incompatible stack heights: 1 vs 0
		//IL_01b5->IL00bf: Incompatible stack heights: 2 vs 0
		((EnemyController)this).Die();
		if (((EnemyStatic)this)._onEnterTween != null)
		{
			((EnemyStatic)this)._onEnterTween.Pause();
		}
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
		}
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			Action<Pickup> callback = delegate(Pickup c)
			{
				if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
				{
					float2 float5 = base.position;
					bool includeFollowers = default(bool);
					CharacterController closestPlayer = _gameManager.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
					bool flag3 = c.Vacuum(closestPlayer);
				}
			};
			if ((object)_gameManager != null)
			{
				Vector2 pos = default(Vector2);
				_gameManager.MakeCoin(pos, 0f, callback);
				Action<Pickup> cachedTransform2 = (Action<Pickup>)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v8 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v8 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					Action<Pickup> callback2 = delegate(Pickup c)
					{
						if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
						{
							float2 float5 = base.position;
							bool includeFollowers = default(bool);
							CharacterController closestPlayer = _gameManager.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
							bool flag3 = c.Vacuum(closestPlayer);
						}
					};
					if ((object)_gameManager != null)
					{
						_gameManager.MakeCoin(pos, 0f, callback2);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnDeathAnimationComplete()
	{
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null && ((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0)
		{
			bool hasStateAuthority = _coherenceSync.HasStateAuthority;
			if (!hasStateAuthority && ((EnemyController)this)._003CKilledByAuthority_003Ek__BackingField == hasStateAuthority)
			{
				_EnemyRenderer.enabled = false;
				FireKilledSignal();
				return;
			}
		}
		((EnemyController)this).Despawn();
		if (((EnemyStatic)this)._onEnterTween != null)
		{
			((EnemyStatic)this)._onEnterTween.Pause();
		}
	}

	private void SetTint()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_01e7: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0157: Expected O, but got I
		//IL_0233: Expected O, but got I4
		//IL_017d: Expected O, but got I
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v7+18]");
		if (num >= 0)
		{
			list.AddWithResize(4504575u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 4504575;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v9+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(8978431u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8978431;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		uint num3 = 0u;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v11 (System.UInt32)+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(4521983u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj5 = (nint)0 + (nint)1;
			_ = 4521983;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		object obj6 = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		bool flag = (nint)obj6 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v19+20+v85 @ rax_v19*4]");
		_saveTint = 0u;
		SpriteRenderer enemyRenderer = _EnemyRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v19+20+v85 @ rax_v19*4]");
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(enemyRenderer, 0u);
	}

	public EnemyStaticVaseMoon()
	{
		//IL_001b: Expected I4, but got I8
		((EnemyStatic)this)._prevDepth = -1;
		((EnemyController)this)._002Ector();
	}

	private void _003CDespawn_003Eb__2_0()
	{
		((EnemyController)this).Despawn();
		if (((EnemyStatic)this)._onEnterTween != null)
		{
			((EnemyStatic)this)._onEnterTween.Pause();
		}
	}

	private void _003CDie_003Eb__5_0(Pickup c)
	{
		if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
		{
			float2 float5 = base.position;
			bool includeFollowers = default(bool);
			CharacterController closestPlayer = _gameManager.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
			bool flag = c.Vacuum(closestPlayer);
		}
	}
}
