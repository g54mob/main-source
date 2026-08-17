using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

namespace Actors.Enemies;

public class EnemySpawnParticles : MonoBehaviour
{
	public RandomSfx audio;

	public ParticleSystem ps;

	public unsafe void Set(Enemy enemy)
	{
		//IL_006f: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831724C1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = base.transform;
		Vector3 feetPosition = enemy.GetFeetPosition();
		object obj = default(object);
		transform.position = (Vector3)(&obj);
		ps.Play();
		audio.Play();
		Invoke("Release", 2f);
	}

	public void Release()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		PoolManager instance = PoolManager.Instance;
		ObjectPool<GameObject> enemySpawnFxPool = instance.enemySpawnFxPool;
		GameObject gameObject2 = base.gameObject;
		Action<GameObject> actionOnRelease = enemySpawnFxPool.m_ActionOnRelease;
		if (enemySpawnFxPool.m_ActionOnRelease != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v250 @ rax_v12 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
		}
		if ((object)enemySpawnFxPool.m_FreshlyReleased != null)
		{
			int countInactive = enemySpawnFxPool.CountInactive;
			if (countInactive >= enemySpawnFxPool.m_MaxSize)
			{
				int num = enemySpawnFxPool._003CCountAll_003Ek__BackingField - 1;
				enemySpawnFxPool._003CCountAll_003Ek__BackingField = num;
				Action<GameObject> actionOnDestroy = enemySpawnFxPool.m_ActionOnDestroy;
				if (enemySpawnFxPool.m_ActionOnDestroy != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v312 @ rax_v24 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
			List<object> list = (List<object>)(object)enemySpawnFxPool.m_List;
			object[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			if (list._size >= items.Length)
			{
				list.AddWithResize((object)gameObject2);
				return;
			}
			int size = list._size + 1;
			list._size = size;
			int num2 = default(int);
			items[num2] = gameObject2;
		}
		else
		{
			enemySpawnFxPool.m_FreshlyReleased = gameObject2;
		}
	}
}
