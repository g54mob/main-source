using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyPatrolWitch : EnemyGallo
{
	private float _sineF = 1f;

	private float _patrolDuration;

	private Tween _onEnterTween;

	private Tween _onFireTimer;

	private Tween _onSineTween;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0013: Invalid comparison between F4 and I4
		//IL_0294: Expected I4, but got O
		//IL_0307: Expected I, but got O
		//IL_0344: Expected O, but got Ref
		//IL_0379: Expected I4, but got O
		//IL_03c4: Expected I4, but got O
		//IL_0382->IL0269: Incompatible stack heights: 1 vs 0
		//IL_03cd->IL0269: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		((EnemyController)this)._003CIsPatrolling_003Ek__BackingField = true;
		if (_currentEnemyData != null)
		{
			float num = ((!(currentEnemyData._003CpatrolDuration_003Ek__BackingField > 0f)) ? 2000f : currentEnemyData._003CpatrolDuration_003Ek__BackingField);
			float patrolDuration = num * 0.001f;
			_patrolDuration = patrolDuration;
			bool flag = (byte)(int)_cachedTransform != 0;
			_sineF = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdi_v5 (System.Boolean)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdi_v5 (System.Boolean)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			if (_onEnterTween != null)
			{
				TweenExtensions.Kill(_onEnterTween);
			}
			nint num2 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v22 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ rcx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float val = 0f * _scaleMul;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&value), 1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((int)(~tweenerCore) == 0)
			{
				_onEnterTween = tweenerCore;
				if (_onSineTween != null)
				{
					TweenExtensions.Kill(_onSineTween);
				}
				DOGetter<float> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter = null;
				((EnemyPatrolWitch)(object)dOSetter)._003CInitEnemy_003Eb__5_1(val);
				TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, -1f, _patrolDuration);
				TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, 0.1f);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 4;
							_ = 0;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if ((int)(~tweenerCore2) == 0)
				{
					_onSineTween = tweenerCore2;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void SetOwner(GameObject owner)
	{
		_owner = owner;
		Transform targetTransform = owner.transform;
		((EnemyController)this)._targetTransform = targetTransform;
	}

	public override void Despawn()
	{
		((EnemyController)this).Despawn();
		if (base._onFireTimer != null)
		{
			TweenExtensions.Kill(base._onFireTimer);
		}
		ObjectPool enemyLancetPool = base._enemyLancetPool;
		if ((object)base._enemyLancetPool != null && ((UnityEngine.Object)enemyLancetPool).m_CachedPtr != (IntPtr)0)
		{
			base._enemyLancetPool.Purge();
			base._enemyLancetPool = null;
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
	}

	protected override void OnUpdate()
	{
		SetLancetPoolItemsDuration(1f);
		if (((EnemyController)this)._003CIsPatrolling_003Ek__BackingField)
		{
			GameObject owner = _owner;
			float defaultSpeed;
			if ((object)_owner != null)
			{
				bool flag = ((UnityEngine.Object)owner).m_CachedPtr == (IntPtr)0;
				defaultSpeed = _defaultSpeed;
				if (!flag)
				{
					float num = _defaultSpeed * _sineF;
					((EnemyController)this)._003CSpeed_003Ek__BackingField = num;
					base.OnUpdate();
					return;
				}
			}
			else
			{
				defaultSpeed = _defaultSpeed;
			}
			((EnemyController)this)._003CSpeed_003Ek__BackingField = defaultSpeed;
			float2 float5 = base.position;
			bool includeFollowers = default(bool);
			CharacterController closestPlayer = _gameManager.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
			Transform transform = closestPlayer.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180BA5BF0");
			((EnemyController)this)._003CIsPatrolling_003Ek__BackingField = false;
		}
		else
		{
			base.OnUpdate();
		}
	}

	public EnemyPatrolWitch()
	{
		base._keepMoving = 1;
		base._fireDelay = 1f;
		List<EnemyLancet> enemyLancetProjectiles = new List<EnemyLancet>();
		base._enemyLancetProjectiles = enemyLancetProjectiles;
		((EnemyController)this)._002Ector();
	}

	private float _003CInitEnemy_003Eb__5_0()
	{
		return _sineF;
	}

	private void _003CInitEnemy_003Eb__5_1(float val)
	{
		_sineF = val;
	}
}
