using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;
using UnityEngine.Pool;
using Utility;

public class InteractableTumbleWeed : BaseInteractable
{
	public const int maxTumbleWeeds = 25;

	private bool broken;

	public Rigidbody rb;

	private Vector3 desiredVelocity;

	private float speed = 5f;

	private float actualSpeed = 5f;

	private Vector3 lastPos;

	public AudioSource audio;

	private float defaultVolume;

	private float startTime;

	private float stopTime;

	private float scaleMultiplier;

	public unsafe override bool Interact()
	{
		//IL_0188: Expected I4, but got O
		//IL_0037: Invalid comparison between F4 and I4
		//IL_0091: Expected O, but got Ref
		//IL_013b: Invalid comparison between F8 and I4
		//IL_0163: Expected I4, but got F8
		if (!broken)
		{
			broken = true;
			if (MyRandom.random != null)
			{
				double num = MyRandom.random.NextDouble();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm2,xmm0\"");
				if (0.75f < 0f)
				{
					Transform transform = base.transform;
					if ((object)transform != null)
					{
						Vector3 position = transform.position;
						float num2 = default(float);
						MoneyUtility.SpawnSilver((Vector3)(&num2));
						goto IL_0168;
					}
				}
				else
				{
					MyPlayer instance = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						PlayerInventory inventory = instance.inventory;
						if (instance.inventory != null)
						{
							PlayerXp playerXp = inventory.playerXp;
							if (inventory.playerXp != null)
							{
								int num3 = XpUtility.XpToNextLevelTotal(playerXp.xp);
								float num4 = (float)num3 * 0.1f;
								double num5 = Math.Ceiling(num4);
								bool flag = !(num5 > 5.0);
								int value = 5;
								if (!flag)
								{
									value = (int)num5;
								}
								SpawnXp(EPickup.Xp, value, 0.25f);
								goto IL_0168;
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
		IL_0168:
		Despawn();
		return true;
	}

	private unsafe void Despawn()
	{
		//IL_030b: Expected I, but got O
		//IL_00f5: Invalid comparison between F4 and I4
		//IL_02af: Expected O, but got Ref
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		nint num = (nint)typeof(Math);
		float num2 = position.x - position2.x;
		float num3 = position.y - position2.y;
		float num4 = position.z - position2.z;
		float num5 = num3 * num3;
		float num6 = num2 * num2;
		float num7 = num4 * num4;
		float num8 = num5 + num6;
		float num9 = num8 + num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rcx_v9 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
		}
		else
		{
			double num10 = Math.Sqrt(num9);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
		if (40f > 0f)
		{
			PoolManager instance = PoolManager.Instance;
			ObjectPool<GameObject> tumbleweedBreakPool = instance.tumbleweedBreakPool;
			UnityEngine.Object obj;
			if ((nint)tumbleweedBreakPool.m_FreshlyReleased <= 0)
			{
				List<GameObject> list = tumbleweedBreakPool.m_List;
				if (list._size != 0)
				{
					int index = list._size - 1;
					GameObject gameObject = tumbleweedBreakPool.m_List.get_Item(index);
					int index2 = list._size - 1;
					((List<object>)(object)tumbleweedBreakPool.m_List).RemoveAt(index2);
					obj = gameObject;
				}
				else
				{
					Func<GameObject> createFunc = tumbleweedBreakPool.m_CreateFunc;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v157 @ rax_v40 (System.Func`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
					int num11 = tumbleweedBreakPool._003CCountAll_003Ek__BackingField + 1;
					tumbleweedBreakPool._003CCountAll_003Ek__BackingField = num11;
					UnityEngine.Object obj2 = default(UnityEngine.Object);
					obj = obj2;
				}
			}
			else
			{
				obj = tumbleweedBreakPool.m_FreshlyReleased;
				tumbleweedBreakPool.m_FreshlyReleased = null;
			}
			Action<GameObject> actionOnGet = tumbleweedBreakPool.m_ActionOnGet;
			if (tumbleweedBreakPool.m_ActionOnGet != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v538 @ rax_v27 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			if (obj != null)
			{
				Transform transform3 = ((GameObject)obj).transform;
				Transform transform4 = base.transform;
				Vector3 position3 = transform4.position;
				object obj3 = default(object);
				transform3.position = (Vector3)(&obj3);
			}
		}
		GameObject gameObject2 = base.gameObject;
		gameObject2.SetActive(value: false);
		PoolManager instance2 = PoolManager.Instance;
		GameObject element = base.gameObject;
		instance2.tumbleweedPool.Release(element);
	}

	private unsafe void OnEnable()
	{
		//IL_0030: Expected O, but got Ref
		//IL_0044: Expected O, but got Ref
		broken = false;
		Vector3 randomSpawnPositionOnMap = SpawnPositions.GetRandomSpawnPositionOnMap(999f);
		Transform transform = base.transform;
		float num = default(float);
		transform.position = (Vector3)(&num);
		rb.MovePosition((Vector3)(&num));
		float num2 = UnityEngine.Random.Range(4f, 10f);
		speed = num2;
		FindNewDir();
		startTime = MyTime.time;
		float num3 = UnityEngine.Random.Range(45f, 60f);
		float num4 = num3 + MyTime.time;
		stopTime = num4;
	}

	private unsafe void SpawnXp(EPickup ePickup, int value, float pickupDelay)
	{
		//IL_000e: Expected O, but got I4
		//IL_0058: Expected O, but got Ref
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		if (value <= 0)
		{
			return;
		}
		object obj = 0;
		int num = value;
		float num4 = default(float);
		bool useRandomOffsetPosition = default(bool);
		float pickupDelay2 = default(float);
		bool flag2;
		do
		{
			bool flag = (nint)obj < 10;
			int num2 = 1;
			if (!flag)
			{
				num2 = num;
			}
			Transform transform = base.transform;
			float num3 = transform.position.x + (float)Vector3.upVector;
			Pickup pickup = PickupManager.Instance.SpawnPickup(ePickup, (Vector3)(&num4), num2, useRandomOffsetPosition, pickupDelay2);
			if (pickup != null)
			{
				MyPlayer player = GameManager.Instance.GetPlayer();
				Transform target = player.transform;
				pickup.StartFollowingPlayer(target);
			}
			num -= num2;
			if (num > 0)
			{
				obj++;
				flag2 = (nint)obj < value;
				num4 = num3;
				continue;
			}
			break;
		}
		while (flag2);
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C96]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "BREAK_TUMBLEWEED");
	}

	private unsafe void Spawn()
	{
		//IL_0025: Expected O, but got Ref
		//IL_0039: Expected O, but got Ref
		Vector3 randomSpawnPositionOnMap = SpawnPositions.GetRandomSpawnPositionOnMap(999f);
		Transform transform = base.transform;
		float num = default(float);
		transform.position = (Vector3)(&num);
		rb.MovePosition((Vector3)(&num));
		float num2 = UnityEngine.Random.Range(4f, 10f);
		speed = num2;
		FindNewDir();
		startTime = MyTime.time;
		float num3 = UnityEngine.Random.Range(45f, 60f);
		float num4 = num3 + MyTime.time;
		stopTime = num4;
	}

	private unsafe void FindNewDir()
	{
		//IL_0013: Expected O, but got Ref
		Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
		float num = default(float);
		Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		float num2 = speed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v5+8]");
		float num3 = num2 * 0f;
		actualSpeed = 5f;
		Vector3 vector2 = default(Vector3);
		desiredVelocity = vector2;
	}

	private unsafe void FixedUpdate()
	{
		//IL_00fd: Invalid comparison between I4 and F4
		//IL_0029: Expected O, but got Ref
		//IL_0047: Expected O, but got Ref
		//IL_00bb: Expected O, but got Ref
		//IL_00d3: Expected O, but got F4
		if (!MyTime.paused && 0f < MyTime.fixedDeltaTime)
		{
			Vector3 velocity = rb.velocity;
			Vector3 vector = default(Vector3);
			rb.velocity = (Vector3)(&vector);
			Vector3 position = rb.position;
			Vector3 vector2 = VectorExtensions.XZVector((Vector3)(&vector));
			float num = vector2.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (InteractableTumbleWeed)+80]");
			float num2 = num - 0f;
			float num3 = vector2.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (InteractableTumbleWeed)+84]");
			float num4 = num3 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			float num5 = num4 / MyTime.fixedDeltaTime;
			float num6 = num5 - actualSpeed;
			float num7 = num6 * 0.1f;
			if (3f > (actualSpeed = num7 + actualSpeed))
			{
				FindNewDir();
			}
			Vector3 position2 = rb.position;
			float num8 = default(float);
			Vector3 vector3 = VectorExtensions.XZVector((Vector3)(&num8));
			lastPos = (Vector3)vector3.x;
			_ = vector3.z;
			if (MyTime.time > stopTime)
			{
				Despawn();
			}
		}
	}

	public InteractableTumbleWeed()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
