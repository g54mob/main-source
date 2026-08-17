using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyKitsune : EnemyController
{
	private Vector2 _headOffset;

	private Vector2 _invHeadOffset;

	private List<EnemyKitsuneTailTip> _headEnemies;

	private MultiTargetTween _fadeTrailTween;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0032: Expected O, but got I4
		//IL_00b9: Expected F4, but got I4
		//IL_00fb: Expected F4, but got I4
		//IL_01cf: Expected F4, but got I
		//IL_044b: Expected O, but got I4
		//IL_02db: Expected O, but got I4
		//IL_0406->IL0349: Incompatible stack heights: 1 vs 0
		//IL_04ac->IL0349: Incompatible stack heights: 1 vs 0
		//IL_0461->IL04da: Incompatible stack heights: 2 vs 0
		//IL_04d5->IL0349: Incompatible stack heights: 1 vs 0
		//IL_02a4->IL0349: Incompatible stack heights: 1 vs 0
		//IL_0337->IL0387: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		BaseBody baseBody = body;
		if (body != null)
		{
			nint num = (nint)baseBody;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v20 (Il2CppClass<BaseBody>)+230]");
			object[] array = (object[])0;
			BaseBody baseBody2 = body.setOffset(0f, (float?)(object)1);
			List<EnemyKitsuneTailTip> headEnemies = _headEnemies;
			base._003CIsTeleportOnCull_003Ek__BackingField = true;
			if (_headEnemies != null)
			{
				int version = headEnemies._version + 1;
				headEnemies._version = version;
				headEnemies._size = 0;
				bool flag = headEnemies._size <= 0;
				float num2 = 0f;
				int num3 = 0;
				if (!flag)
				{
					Array.Clear(headEnemies._items, 0, headEnemies._size);
					array = null;
					num2 = 0f;
					num3 = 0;
				}
				float num5 = default(float);
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v45 (UnityEngine.Transform)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v45 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 _);
						Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
						if ((object)cachedTrans2 == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v51 (UnityEngine.Transform)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v51 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 ret2);
						ret2 = (Vector3)0;
						float num4 = num5;
						num2 = num5;
					}
					else
					{
						BaseBody baseBody3 = body;
						if (body == null)
						{
							break;
						}
						ArcadeTransform arcadeTransform = baseBody3._transform;
						if (baseBody3._transform == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v44 (ArcadeTransform)+4C]");
						float num4 = 0f;
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
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v151 @ r9_v12 (System.Boolean)+358] (should have been resolved before IL gen)");
					bool flag6 = num3 != 0;
					float num6 = num5;
					if (!flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rax_v27 (System.Boolean)+1EC]");
						float num7 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rax_v27 (System.Boolean)+1EC]");
						num6 = num7 + 0f;
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
						int num8 = headEnemies2._size + 1;
						headEnemies2._size = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					num3++;
					if (num3 >= 9)
					{
						_hp = _maxHp;
						return;
					}
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
		List<EnemyKitsuneTailTip> headEnemies = _headEnemies;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < headEnemies._size)
			{
				List<EnemyKitsuneTailTip> headEnemies2 = _headEnemies;
				if ((nint)obj >= headEnemies2._size)
				{
					break;
				}
				EnemyKitsuneTailTip[] items = headEnemies2._items;
				EnemyKitsuneTailTip enemyKitsuneTailTip = items[obj];
				if (!((EnemyController)enemyKitsuneTailTip)._003CIsDead_003Ek__BackingField)
				{
					enemyKitsuneTailTip.Disappear();
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

	public EnemyKitsune()
	{
		//IL_0020: Expected O, but got I8
		//IL_0035: Expected O, but got I4
		_headOffset = (Vector2)3196395192L;
		_ = 3193375293L;
		_invHeadOffset = (Vector2)1057300152;
		_ = 3193375293L;
		List<EnemyKitsuneTailTip> headEnemies = new List<EnemyKitsuneTailTip>();
		_headEnemies = headEnemies;
		base._002Ector();
	}
}
