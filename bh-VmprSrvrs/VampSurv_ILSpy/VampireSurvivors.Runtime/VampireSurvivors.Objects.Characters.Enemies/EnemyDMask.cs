using System;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDMask : EnemyController
{
	private MultiTargetTween _onEnterTween;

	protected bool _isInvul;

	private bool _canBreak;

	private bool _alreadyBroken;

	public bool CanBreak
	{
		get
		{
			return _canBreak;
		}
		set
		{
			_canBreak = value;
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_019a: Expected O, but got I4
		//IL_00ca: Expected I4, but got O
		//IL_0068->IL0110: Incompatible stack heights: 1 vs 0
		//IL_00d3->IL0110: Incompatible stack heights: 1 vs 0
		//IL_00b7->IL00b7: Incompatible stack heights: 2 vs 1
		base.InitEnemy(enemyType, asRemote);
		base._003CIsCullable_003Ek__BackingField = false;
		_alreadyBroken = false;
		if ((object)_EnemyRenderer != null)
		{
			Transform transform = _EnemyRenderer.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
			if (_onEnterTween != null)
			{
				_onEnterTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				if ((object)_cachedTransform != null)
				{
					object obj = array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj2 = default(object);
					bool flag2 = obj2 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if ((int)(~tweenConfig) == 0)
				{
					_ = 1120403456;
					_ = 1;
					MultiTargetTween onEnterTween = Tweens.Add(tweenConfig);
					_onEnterTween = onEnterTween;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (!_isInvul)
		{
			if (_canBreak && !_alreadyBroken)
			{
				BreakMask();
			}
			WeaponType damageType2 = default(WeaponType);
			bool hasKb2 = default(bool);
			base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
		}
	}

	public void DisappearMask()
	{
		base.Disappear();
	}

	private void BreakMask()
	{
		GameObject owner = _owner;
		_alreadyBroken = true;
		if ((object)_owner == null || ((UnityEngine.Object)owner).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		EnemyDirecter component = _owner.GetComponent<EnemyDirecter>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				component.PerformMaskBroken(this);
				return;
			}
			Action<long, CoherenceSync> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			object param = default(object);
			bool flag = ((EnemyController)component)._coherenceSync.SendCommand((Action<long, object>)action, MessageTarget.All, startingOnlineClientFrame, param);
		}
	}

	public override void Disappear()
	{
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_onEnterTween != null)
		{
			_onEnterTween.Kill();
		}
	}

	public void ScriptedDisappear()
	{
		base.Disappear();
	}

	public void BreakOnNextAttack(bool value)
	{
		_canBreak = value;
	}

	protected override void OnUpdate()
	{
		UpdateDepth();
		Transform transform = _EnemyRenderer.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	protected override void UpdateDepth()
	{
		//IL_0070: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		nint num = (nint)typeof(Math);
		int num2 = default(int);
		int sortingOrder = -num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v4 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 < (nint)0)
		{
			sortingOrder = num2;
		}
		_EnemyRenderer.sortingOrder = sortingOrder;
	}

	protected override void Die()
	{
	}
}
