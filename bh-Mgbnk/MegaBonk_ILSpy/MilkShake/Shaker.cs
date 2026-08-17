using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace MilkShake;

public class Shaker : MonoBehaviour
{
	public static List<Shaker> GlobalShakers;

	private bool addToGlobalShakers;

	private List<ShakeInstance> activeShakes;

	public static ShakeInstance ShakeAll(IShakeParameters shakeData, int? seed = null)
	{
		ShakeInstance shakeInstance = new ShakeInstance(shakeData, seed);
		int num = 0;
		while (true)
		{
			List<Shaker> globalShakers = GlobalShakers;
			if (GlobalShakers == null)
			{
				break;
			}
			if (num >= globalShakers._size)
			{
				return shakeInstance;
			}
			if (GlobalShakers == null)
			{
				break;
			}
			Shaker shaker = GlobalShakers.get_Item(num);
			if ((object)shaker == null)
			{
				break;
			}
			GameObject gameObject = shaker.gameObject;
			if ((object)gameObject == null)
			{
				break;
			}
			if (gameObject.activeInHierarchy)
			{
				if (GlobalShakers == null)
				{
					break;
				}
				Shaker shaker2 = GlobalShakers.get_Item(num);
				if ((object)shaker2 == null)
				{
					break;
				}
				shaker2.AddShake(shakeInstance);
			}
			num++;
		}
		return (ShakeInstance)(object)new NullReferenceException();
	}

	public static void ShakeAllSeparate(IShakeParameters shakeData, List<ShakeInstance> shakeInstances = null, int? seed = null)
	{
		if (shakeInstances != null)
		{
			int version = shakeInstances._version + 1;
			shakeInstances._version = version;
			shakeInstances._size = 0;
			if (shakeInstances._size > 0)
			{
				Array.Clear(shakeInstances._items, 0, shakeInstances._size);
			}
		}
		int num = 0;
		while (true)
		{
			List<Shaker> globalShakers = GlobalShakers;
			if (num >= globalShakers._size)
			{
				break;
			}
			Shaker shaker = GlobalShakers.get_Item(num);
			GameObject gameObject = shaker.gameObject;
			if (gameObject.activeInHierarchy)
			{
				Shaker shaker2 = GlobalShakers.get_Item(num);
				ShakeInstance shakeInstance = shaker2.Shake(shakeData, seed);
				if (shakeInstances != null && shakeInstance != null)
				{
					shakeInstances.Add(shakeInstance);
				}
			}
			num++;
		}
	}

	public unsafe static void ShakeAllFromPoint(Vector3 point, float maxDistance, IShakeParameters shakeData, List<ShakeInstance> shakeInstances = null, int? seed = null)
	{
		//IL_0136: Expected O, but got Ref
		if (shakeInstances != null)
		{
			int version = shakeInstances._version + 1;
			shakeInstances._version = version;
			shakeInstances._size = 0;
			if (shakeInstances._size > 0)
			{
				Array.Clear(shakeInstances._items, 0, shakeInstances._size);
			}
		}
		int num = 0;
		float x = default(float);
		int? seed2 = default(int?);
		while (true)
		{
			List<Shaker> globalShakers = GlobalShakers;
			if (num >= globalShakers._size)
			{
				break;
			}
			Shaker shaker = GlobalShakers.get_Item(num);
			GameObject gameObject = shaker.gameObject;
			if (gameObject.activeInHierarchy)
			{
				Shaker shaker2 = GlobalShakers.get_Item(num);
				ShakeInstance shakeInstance = shaker2.ShakeFromPoint((Vector3)(&x), maxDistance, shakeData, seed2);
				if (shakeInstances != null)
				{
					bool flag = shakeInstance == null;
					x = point.x;
					if (!flag)
					{
						shakeInstances.Add(shakeInstance);
						x = point.x;
					}
				}
			}
			num++;
		}
	}

	public static void AddShakeAll(ShakeInstance shakeInstance)
	{
		int num = 0;
		while (true)
		{
			List<Shaker> globalShakers = GlobalShakers;
			if (num < globalShakers._size)
			{
				Shaker shaker = GlobalShakers.get_Item(num);
				GameObject gameObject = shaker.gameObject;
				if (gameObject.activeInHierarchy)
				{
					Shaker shaker2 = GlobalShakers.get_Item(num);
					shaker2.AddShake(shakeInstance);
				}
				num++;
				continue;
			}
			break;
		}
	}

	private void Awake()
	{
		if (addToGlobalShakers)
		{
			List<object> globalShakers = (List<object>)(object)GlobalShakers;
			int version = globalShakers._version + 1;
			globalShakers._version = version;
			object[] items = globalShakers._items;
			if (globalShakers._size >= items.Length)
			{
				globalShakers.AddWithResize((object)this);
				return;
			}
			int size = globalShakers._size + 1;
			globalShakers._size = size;
			int num = default(int);
			items[num] = this;
		}
	}

	private void OnDestroy()
	{
		if (addToGlobalShakers)
		{
			bool flag = ((List<object>)(object)GlobalShakers).Remove((object)this);
		}
	}

	private unsafe void Update()
	{
		//IL_011c: Expected O, but got Ref
		//IL_0138: Expected O, but got Ref
		List<ShakeInstance> list = activeShakes;
		int num = 0;
		object obj = default(object);
		object obj2 = default(object);
		for (int num2 = 0; num2 < list._size; num2 = num)
		{
			ShakeInstance shakeInstance = activeShakes.get_Item(num);
			if (shakeInstance._003CState_003Ek__BackingField != ShakeState.Stopped || !shakeInstance.RemoveWhenStopped)
			{
				ShakeInstance shakeInstance2 = activeShakes.get_Item(num);
				float deltaTime = Time.deltaTime;
				ShakeResult shakeResult = shakeInstance2.UpdateShake(deltaTime);
				obj = obj2;
			}
			else
			{
				((List<object>)(object)activeShakes).RemoveAt(num);
				num--;
			}
			list = activeShakes;
			num++;
		}
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm7,8\"");
		transform.localPosition = (Vector3)(&obj);
		Transform transform2 = base.transform;
		transform2.localEulerAngles = (Vector3)(&obj);
	}

	public ShakeInstance Shake(IShakeParameters shakeData, int? seed = null)
	{
		ShakeInstance shakeInstance = new ShakeInstance(shakeData, seed);
		AddShake(shakeInstance);
		return shakeInstance;
	}

	public ShakeInstance ShakeFromPoint(Vector3 point, float maxDistance, IShakeParameters shakeData, int? seed = null)
	{
		//IL_01df: Expected I, but got O
		//IL_00c5: Invalid comparison between F4 and I4
		//IL_0113: Invalid comparison between I4 and F4
		//IL_015e: Expected F4, but got I4
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			nint num = (nint)typeof(Math);
			float num2 = position.x - point.x;
			float num3 = position.y - point.y;
			float num4 = position.z - point.z;
			float num5 = num3 * num3;
			float num6 = num2 * num2;
			float num7 = num4 * num4;
			float num8 = num5 + num6;
			float num9 = num8 + num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v6 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			}
			else
			{
				double num10 = Math.Sqrt(num9);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
			ShakeInstance shakeInstance;
			if (!(maxDistance > 0f))
			{
				shakeInstance = null;
			}
			else
			{
				int? seed2 = default(int?);
				shakeInstance = new ShakeInstance(shakeData, seed2);
				float num11 = 0f / maxDistance;
				if (!(0f > num11))
				{
					if (num11 > 1f)
					{
						num11 = 1f;
					}
				}
				else
				{
					num11 = 0f;
				}
				if (shakeInstance == null)
				{
					goto IL_019c;
				}
				shakeInstance.RoughnessScale = (shakeInstance.StrengthScale = 1f - num11);
				AddShake(shakeInstance);
			}
			return shakeInstance;
		}
		goto IL_019c;
		IL_019c:
		return (ShakeInstance)(object)new NullReferenceException();
	}

	public void AddShake(ShakeInstance shakeInstance)
	{
		List<object> list = (List<object>)(object)activeShakes;
		int version = list._version + 1;
		list._version = version;
		object[] items = list._items;
		if (list._size >= items.Length)
		{
			list.AddWithResize((object)shakeInstance);
			return;
		}
		int size = list._size + 1;
		list._size = size;
		int num = default(int);
		items[num] = shakeInstance;
	}

	public Shaker()
	{
		List<ShakeInstance> list = new List<ShakeInstance>();
		activeShakes = list;
		base._002Ector();
	}

	static Shaker()
	{
		List<Shaker> globalShakers = new List<Shaker>();
		GlobalShakers = globalShakers;
	}
}
