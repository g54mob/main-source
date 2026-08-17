using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

public class Borgar : MonoBehaviour
{
	private int flatHeal;

	private float ratioHeal;

	private float timeoutAtTime;

	private float timeoutTime = 30f;

	public void Set(int flatHeal, float ratioHeal)
	{
		this.ratioHeal = ratioHeal;
		this.flatHeal = flatHeal;
		float num = MyTime.time + timeoutTime;
		timeoutAtTime = num;
	}

	private void FixedUpdate()
	{
	}

	private unsafe void OnCollisionEnter(Collision collision)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_028b: Expected F4, but got I4
		//IL_0248: Expected O, but got Ref
		GameObject gameObject = collision.gameObject;
		int layer = gameObject.layer;
		int num = LayerMask.NameToLayer("Player");
		if (layer != num)
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		int combinedMaxHp = inventory.playerHealth.GetCombinedMaxHp();
		object obj = combinedMaxHp * ratioHeal;
		PoolManager instance2 = default(PoolManager);
		if (flatHeal >= (nint)obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			int num2 = inventory.playerHealth.Heal(combinedMaxHp);
			DestroyBorgar();
			instance2 = PoolManager.Instance;
		}
		ObjectPool<GameObject> eatPool = instance2.eatPool;
		UnityEngine.Object obj2;
		if ((nint)eatPool.m_FreshlyReleased <= 0)
		{
			List<GameObject> list = eatPool.m_List;
			if (list._size != 0)
			{
				int index = list._size - 1;
				GameObject gameObject2 = eatPool.m_List.get_Item(index);
				int index2 = list._size - 1;
				((List<object>)(object)eatPool.m_List).RemoveAt(index2);
				obj2 = gameObject2;
			}
			else
			{
				Func<GameObject> createFunc = eatPool.m_CreateFunc;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ rax_v31 (System.Func`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				int num3 = eatPool._003CCountAll_003Ek__BackingField + 1;
				eatPool._003CCountAll_003Ek__BackingField = num3;
				UnityEngine.Object obj3 = default(UnityEngine.Object);
				obj2 = obj3;
			}
		}
		else
		{
			obj2 = eatPool.m_FreshlyReleased;
			eatPool.m_FreshlyReleased = null;
		}
		Action<GameObject> actionOnGet = eatPool.m_ActionOnGet;
		if (eatPool.m_ActionOnGet != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v432 @ rax_v17 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
		}
		if (obj2 != null)
		{
			Transform transform = ((GameObject)obj2).transform;
			Transform transform2 = base.transform;
			Vector3 position = transform2.position;
			object obj4 = default(object);
			transform.position = (Vector3)(&obj4);
			((GameObject)obj2).SetActive(true);
		}
	}

	private void Update()
	{
		if (MyTime.time > timeoutAtTime)
		{
			DestroyBorgar();
		}
	}

	private void DestroyBorgar()
	{
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy)
		{
			GameObject gameObject2 = base.gameObject;
			gameObject2.SetActive(value: false);
			PoolManager instance = PoolManager.Instance;
			GameObject element = base.gameObject;
			instance.borgorPool.Release(element);
		}
	}
}
