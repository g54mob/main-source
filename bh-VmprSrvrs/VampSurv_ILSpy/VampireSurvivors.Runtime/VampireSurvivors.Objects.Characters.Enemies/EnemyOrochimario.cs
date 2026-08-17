using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyOrochimario : EnemyController
{
	private Vector2 _headOffset;

	private Vector2 _invHeadOffset;

	private List<EnemyOrochiHead> _headEnemies;

	private MultiTargetTween _fadeTrailTween;

	private EnemyType _headEnemyType;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_015b: Expected O, but got I
		//IL_040c: Expected O, but got I4
		//IL_01d5: Expected O, but got I
		//IL_0265: Expected O, but got I4
		//IL_03c7->IL02f4: Incompatible stack heights: 1 vs 0
		//IL_0465->IL02f4: Incompatible stack heights: 1 vs 0
		//IL_041a->IL0493: Incompatible stack heights: 2 vs 0
		//IL_048e->IL02f4: Incompatible stack heights: 1 vs 0
		//IL_022e->IL02f4: Incompatible stack heights: 1 vs 0
		//IL_02e4->IL0348: Incompatible stack heights: 1 vs 0
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		List<EnemyOrochiHead> headEnemies = _headEnemies;
		base._003CIsTeleportOnCull_003Ek__BackingField = true;
		if (_headEnemies != null)
		{
			int version = headEnemies._version + 1;
			headEnemies._version = version;
			headEnemies._size = 0;
			bool flag = headEnemies._size <= 0;
			object[] array = null;
			int num = 0;
			if (!flag)
			{
				Array.Clear(headEnemies._items, 0, headEnemies._size);
				array = null;
				num = 0;
			}
			object obj2 = default(object);
			bool flag5 = default(bool);
			while (true)
			{
				GameManager core = GM.Core;
				if ((object)GM.Core == null)
				{
					break;
				}
				if (body == null)
				{
					Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
					if ((object)cachedTrans == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v42 (UnityEngine.Transform)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v42 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
					if ((object)cachedTrans2 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v48 (UnityEngine.Transform)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v48 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 ret2);
					ret2 = (Vector3)0;
					object obj = obj2;
				}
				else
				{
					BaseBody baseBody = body;
					if (body == null)
					{
						break;
					}
					ArcadeTransform arcadeTransform = baseBody._transform;
					if (baseBody._transform == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v41 (ArcadeTransform)+4C]");
					object obj = 0;
				}
				if ((object)core._stage == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
				bool flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				if (!flag5)
				{
					break;
				}
				bool value = ((bool*)(flag5 ? 1 : 0))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v158 @ r9_v11 (System.Boolean)+358] (should have been resolved before IL gen)");
				bool flag6 = num != 0;
				object obj3 = obj2;
				if (!flag6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rax_v25 (System.Boolean)+1EC]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rax_v25 (System.Boolean)+1EC]");
					obj3 = num2 + 0;
				}
				List<object> headEnemies2 = (List<object>)(object)_headEnemies;
				if (_headEnemies == null)
				{
					break;
				}
				int version2 = headEnemies2._version + 1;
				headEnemies2._version = version2;
				array = headEnemies2._items;
				if (headEnemies2._items == null)
				{
					break;
				}
				if (headEnemies2._size >= array.Length)
				{
					((List<object>)(object)_headEnemies).AddWithResize((object)flag5);
				}
				else
				{
					int num3 = headEnemies2._size + 1;
					headEnemies2._size = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				num++;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rax_v25 (System.Boolean)+1EC]");
				float hp = (_maxHp = 0f + _maxHp);
				if (num >= 8)
				{
					_hp = hp;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void PlayDeathAnimations()
	{
	}

	protected override void Die()
	{
		//IL_00bd: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		base.Die();
		List<EnemyOrochiHead> headEnemies = _headEnemies;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < headEnemies._size)
			{
				List<EnemyOrochiHead> headEnemies2 = _headEnemies;
				if ((nint)obj >= headEnemies2._size)
				{
					break;
				}
				EnemyOrochiHead[] items = headEnemies2._items;
				EnemyOrochiHead enemyOrochiHead = items[obj];
				if (!((EnemyController)enemyOrochiHead)._003CIsDead_003Ek__BackingField)
				{
					enemyOrochiHead.Disappear();
				}
				headEnemies = _headEnemies;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Despawn()
	{
		base.Despawn();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		base.angle = 0f;
		Transform transform = _EnemyRenderer.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public EnemyOrochimario()
	{
		//IL_002b: Expected O, but got I8
		//IL_0040: Expected O, but got I4
		_headOffset = (Vector2)3196395192L;
		_ = 3193375293L;
		_invHeadOffset = (Vector2)1057300152;
		_ = 3193375293L;
		List<EnemyOrochiHead> headEnemies = new List<EnemyOrochiHead>();
		_headEnemies = headEnemies;
		_headEnemyType = EnemyType.MS_OROCHIHEAD;
		base._002Ector();
	}
}
