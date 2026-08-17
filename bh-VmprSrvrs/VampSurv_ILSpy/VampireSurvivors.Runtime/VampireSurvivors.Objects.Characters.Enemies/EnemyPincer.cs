using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyPincer : EnemyController
{
	private int _lives = 12;

	private Tween _onEnterTween;

	private Action _003COnDead_003Ek__BackingField;

	public Action OnDead
	{
		get
		{
			return _003COnDead_003Ek__BackingField;
		}
		set
		{
			_003COnDead_003Ek__BackingField = value;
		}
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0173: Expected I4, but got O
		//IL_0058: Expected I4, but got O
		//IL_01c3: Expected I4, but got O
		//IL_01d8: Expected I4, but got O
		//IL_0235: Expected O, but got Ref
		//IL_026a: Expected I4, but got O
		//IL_0067->IL0169: Incompatible stack heights: 1 vs 0
		//IL_0273->IL012b: Incompatible stack heights: 1 vs 0
		//IL_00bf->IL012b: Incompatible stack heights: 1 vs 0
		//IL_00eb->IL012b: Incompatible stack heights: 1 vs 0
		//IL_0221->IL0287: Incompatible stack heights: 2 vs 1
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData == null)
		{
			goto IL_012b;
		}
		if ((object)currentEnemyData._003Clives_003Ek__BackingField != null)
		{
			bool flag = (object)currentEnemyData._003Clives_003Ek__BackingField == null;
			int lives = (object?)currentEnemyData._003Clives_003Ek__BackingField >> 32;
			_lives = lives;
		}
		bool flag2 = (byte)(int)_cachedTransform != 0;
		base._003CIsCullable_003Ek__BackingField = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdi_v9 (System.Boolean)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdi_v9 (System.Boolean)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected((IntPtr)0, ref value);
		bool flag4 = (byte)(int)_owner != 0;
		if ((int)(~_owner) == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v10 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				if ((object)_owner != null)
				{
					Transform transform = _owner.transform;
					if ((object)transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v56 (UnityEngine.Transform)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v56 (UnityEngine.Transform)+10]");
						Transform.get_localScale_Injected((IntPtr)0, out value);
						goto IL_0287;
					}
				}
				goto IL_012b;
			}
		}
		goto IL_0287;
		IL_0287:
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&value), 0.3f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((int)(~tweenerCore) == 0)
		{
			_onEnterTween = tweenerCore;
			return;
		}
		goto IL_012b;
		IL_012b:
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
	}

	protected override void UpdateDepth()
	{
	}

	public void SetDepth(float newDepth)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm1\"");
		int sortingOrder = default(int);
		_EnemyRenderer.sortingOrder = sortingOrder;
	}

	protected override void Die()
	{
		//IL_024c->IL0270: Incompatible stack heights: 3 vs 0
		if (--_lives > 0)
		{
			base._003CIsDead_003Ek__BackingField = false;
			if (_blinkTimeout != null)
			{
				_blinkTimeout.Cancel();
			}
			PlayerOptionsData config = _playerOptions.Config;
			_playerOptions.TrackEnemyKill(_enemyType, config);
			PlayerOptionsData config2 = _playerOptions.Config;
			int num = config2._003CRunEnemies_003Ek__BackingField + 1;
			config2._003CRunEnemies_003Ek__BackingField = num;
			GameManager core = GM.Core;
			core._003CMainUI_003Ek__BackingField.UpdateKills();
			object cachedTransform = _cachedTransform;
			_hp = _maxHp;
			Transform cachedTransform2 = _cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out Vector3 ret);
			float num2 = (float)ret * 1.1f;
			if (4f > num2)
			{
			}
			bool flag2 = (object)_cachedTransform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rsi_v4 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rsi_v4 (System.Object)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			return;
		}
		base.Die();
		GameObject owner = _owner;
		if ((object)_owner != null && ((UnityEngine.Object)owner).m_CachedPtr != (IntPtr)0)
		{
			Action action = _003COnDead_003Ek__BackingField;
			if (_003COnDead_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v426.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}
}
