using System;
using System.Collections.Generic;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPool : MonoBehaviour
{
	private float timeout;

	private float returnTime;

	public ObjectPool<GameObject> pool;

	public void SetTime(float timeout, ObjectPool<GameObject> pool)
	{
		this.timeout = timeout;
		this.pool = pool;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		float num = timeout + MyTime.time;
		returnTime = num;
	}

	private void OnEnable()
	{
		float num = MyTime.time + timeout;
		returnTime = num;
	}

	private void Update()
	{
		if (MyTime.time < returnTime)
		{
			return;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		ObjectPool<GameObject> objectPool = pool;
		GameObject gameObject2 = base.gameObject;
		Action<GameObject> actionOnRelease = objectPool.m_ActionOnRelease;
		if (objectPool.m_ActionOnRelease != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v280 @ rax_v13 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
		}
		if ((object)objectPool.m_FreshlyReleased != null)
		{
			int countInactive = objectPool.CountInactive;
			if (countInactive >= objectPool.m_MaxSize)
			{
				int num = objectPool._003CCountAll_003Ek__BackingField - 1;
				objectPool._003CCountAll_003Ek__BackingField = num;
				Action<GameObject> actionOnDestroy = objectPool.m_ActionOnDestroy;
				if (objectPool.m_ActionOnDestroy != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ rax_v23 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
			List<object> list = (List<object>)(object)objectPool.m_List;
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
			objectPool.m_FreshlyReleased = gameObject2;
		}
	}
}
