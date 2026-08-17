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
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyPatrol : EnemyController
{
	private Tween _scaleTween;

	private Tween _sineTween;

	private float _patrolDuration = 2f;

	private float _sineF = 1f;

	protected Pickup _ownerAsPickup;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0020: Invalid comparison between F4 and I4
		//IL_02b4: Expected I4, but got O
		//IL_030a: Expected O, but got I4
		//IL_0345->IL0289: Incompatible stack heights: 1 vs 0
		//IL_0396->IL0289: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		base._003CIsPatrolling_003Ek__BackingField = true;
		if (_currentEnemyData != null)
		{
			float num = currentEnemyData._003CpatrolDuration_003Ek__BackingField;
			if (!(currentEnemyData._003CpatrolDuration_003Ek__BackingField > 0f))
			{
				num = 2000f;
			}
			float patrolDuration = num * 0.001f;
			_patrolDuration = patrolDuration;
			bool flag = (byte)(int)_cachedTransform != 0;
			_sineF = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rbx_v5 (System.Boolean)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rbx_v5 (System.Boolean)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
			if (_scaleTween != null)
			{
				TweenExtensions.Kill(_scaleTween);
			}
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, _scaleMul, 1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (tweenerCore != null)
			{
				_scaleTween = tweenerCore;
				if (_sineTween != null)
				{
					TweenExtensions.Kill(_sineTween);
				}
				DOGetter<float> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter = null;
				((EnemyPatrol)(object)dOSetter)._003CInitEnemy_003Eb__5_1(_scaleMul);
				TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, -1f, _patrolDuration);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
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
				if (tweenerCore2 != null)
				{
					_sineTween = tweenerCore2;
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
		base._targetTransform = targetTransform;
		Pickup component = owner.GetComponent<Pickup>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			_ownerAsPickup = component;
		}
	}

	protected override void OnUpdate()
	{
		if (base._003CIsPatrolling_003Ek__BackingField)
		{
			GameObject owner = _owner;
			if ((object)_owner != null && ((UnityEngine.Object)owner).m_CachedPtr != (IntPtr)0)
			{
				Pickup ownerAsPickup = _ownerAsPickup;
				if ((object)_ownerAsPickup != null && ((UnityEngine.Object)ownerAsPickup).m_CachedPtr != (IntPtr)0)
				{
					Pickup ownerAsPickup2 = _ownerAsPickup;
					if (ownerAsPickup2.body != null)
					{
						BaseBody baseBody = ownerAsPickup2.body;
						if (baseBody._enable)
						{
							float num = _sineF * _defaultSpeed;
							base._003CSpeed_003Ek__BackingField = num;
							base.OnUpdate();
							return;
						}
					}
				}
			}
			base._003CSpeed_003Ek__BackingField = _defaultSpeed;
			float2 float5 = base.position;
			bool includeFollowers = default(bool);
			CharacterController closestPlayer = _gameManager.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
			Transform targetTransform = closestPlayer.transform;
			base._targetTransform = targetTransform;
			base._003CIsPatrolling_003Ek__BackingField = false;
		}
		else
		{
			base.OnUpdate();
		}
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
