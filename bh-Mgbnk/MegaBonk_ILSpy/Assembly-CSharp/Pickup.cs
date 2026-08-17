using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	public LinkedListNode<Pickup> linkedListNode;

	public EPickup ePickup;

	private int value = 1;

	private bool pickedUp;

	private Transform target;

	private float speed;

	public Collider collider;

	public Action<int> A_ValueUpdated;

	public static Action<Pickup> A_PickupTriggered;

	private Vector3 startPosition;

	private float readyForPickupTime;

	private bool ignoreMagnetMultiplier;

	public float floatOffset = 0.4f;

	public float floatSpeed = 0.25f;

	private float floatRandomOffset;

	public float floatRotationSpeed = 100f;

	public bool animateRotation;

	public bool animatePosition;

	private void OnEnable()
	{
		//IL_0060: Expected O, but got F4
		Action<int> a_ValueUpdated = A_ValueUpdated;
		value = value;
		if (A_ValueUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2 @ rax_v1 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		}
		pickedUp = false;
		target = null;
		speed = 0f;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		startPosition = (Vector3)position.x;
		_ = position.z;
		collider.enabled = true;
	}

	public unsafe void Set(Vector3 pos, int value, float pickupDelay)
	{
		//IL_0021: Expected O, but got Ref
		//IL_0030: Expected O, but got F4
		Action<int> a_ValueUpdated = A_ValueUpdated;
		this.value = value;
		if (A_ValueUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v36 @ rax_v2 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		}
		Transform transform = base.transform;
		object obj = default(object);
		transform.position = (Vector3)(&obj);
		startPosition = (Vector3)pos.x;
		_ = pos.z;
		bool flag = ePickup == EPickup.Xp;
		float num = pickupDelay + MyTime.time;
		readyForPickupTime = num;
		if (!flag && ePickup != EPickup.Gold)
		{
			ignoreMagnetMultiplier = true;
		}
		else
		{
			ignoreMagnetMultiplier = false;
		}
	}

	private void Awake()
	{
		float num = UnityEngine.Random.Range(0f, 100f);
		floatRandomOffset = num;
	}

	public void AddValue(int addValue)
	{
		int num = addValue + value;
		Action<int> a_ValueUpdated = A_ValueUpdated;
		value = num;
		if (A_ValueUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3 @ rax_v1 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}

	public void AddValue(Pickup other)
	{
		int num = other.value + value;
		Action<int> a_ValueUpdated = A_ValueUpdated;
		value = num;
		if (A_ValueUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v14 @ rax_v2 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}

	private void SetValue(int v)
	{
		Action<int> a_ValueUpdated = A_ValueUpdated;
		value = v;
		if (A_ValueUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!CanPickup() || readyForPickupTime > MyTime.time)
		{
			return;
		}
		GameObject gameObject = other.gameObject;
		if (!gameObject.CompareTag("Player"))
		{
			return;
		}
		bool flag = !ignoreMagnetMultiplier;
		Component component = other;
		if (!flag)
		{
			Transform transform = other.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			float num = position.x - position2.x;
			float num2 = position.y - position2.y;
			float num3 = position.z - position2.z;
			float num4 = num2 * num2;
			float num5 = num * num;
			float num6 = num3 * num3;
			float num7 = num4 + num5;
			float num8 = num7 + num6;
			if (16f < num8)
			{
				return;
			}
			component = other;
		}
		Transform transform3 = component.transform;
		StartFollowingPlayer(transform3);
	}

	public void StartFollowingPlayer(Transform target)
	{
		this.target = target;
		pickedUp = true;
		bool flag = ePickup != EPickup.Xp;
		float num = 1f;
		if (!flag)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			ItemInventory itemInventory = inventory.itemInventory;
			bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)itemInventory.items).ContainsKey((System.Int32Enum)31);
			bool flag3 = !flag2;
			num = 1f;
			if (!flag3)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance2.inventory;
				int amount = inventory2.itemInventory.GetAmount(EItem.ShatteredWisdom);
				float num2 = (float)amount * 3f;
				float num3 = num2 + 1f;
				num = num3;
			}
		}
		float num4 = num * -20f;
		speed = num4;
		collider.enabled = false;
	}

	private void ApplyPickup()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 43 Invalid \"Jump target not found in method: 0x1804D6DE0\"");
	}

	private unsafe void ShowUi(EPickup ePickup)
	{
		//IL_00d9: Expected O, but got I4
		//IL_000e: Expected O, but got Ref
		//IL_0056: Expected O, but got Ref
		object obj = ePickup - 3;
		if ((nint)obj <= 6)
		{
			object obj2 = default(object);
			string text = ((Enum)(&obj2)).ToString();
			string text2 = text.ToUpper();
			string key = text2 + "_NAME";
			string localizedString = LocalizationUtility.GetLocalizedString("Game_ScoreUi", key);
			IntPtr intPtr = default(IntPtr);
			string text3 = ((Enum)(&intPtr)).ToString();
			string text4 = text3.ToUpper();
			string key2 = text4 + "_DESC";
			string localizedString2 = LocalizationUtility.GetLocalizedString("Game_ScoreUi", key2);
			UiManager instance = UiManager.Instance;
			bool useSfx = default(bool);
			float sizeMultiplier = default(float);
			instance.scoreUi.AddScore(localizedString2, localizedString, isPositive: true, useSfx, sizeMultiplier);
		}
	}

	private unsafe void Update()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0306: Expected I, but got O
		//IL_039a: Invalid comparison between I4 and F4
		//IL_0060: Expected O, but got Ref
		//IL_0141: Expected F4, but got I4
		//IL_00c2: Expected O, but got Ref
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Expected O, but got Unknown
		//IL_0239: Expected O, but got Ref
		//IL_0247: Expected O, but got Ref
		//IL_0159: Expected O, but got Ref
		//IL_04a7: Expected O, but got Ref
		//IL_05cd: Invalid comparison between I4 and F4
		//IL_02d4: Expected F4, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (animateRotation)
		{
			Transform transform = base.transform;
			Transform transform2 = base.transform;
			Vector3 eulerAngles = transform2.eulerAngles;
			float deltaTime = Time.deltaTime;
			float num = deltaTime * floatRotationSpeed;
			Vector3 euler = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			_ = 0;
			_ = 0;
			float num2 = num + eulerAngles.y;
			float num3 = num2 * ((float)Math.PI / 180f);
			Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
			float x = quaternion.x;
			Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			_ = quaternion.x;
			transform.rotation = rotation;
		}
		if (animatePosition)
		{
			Transform transform3 = base.transform;
			nint num4 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rcx_v20 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num5 = 0;
			_ = Vector3.upVector;
			float time = Time.time;
			float num6 = time + floatRandomOffset;
			float num7 = floatOffset + floatOffset;
			float num8 = num6 * floatSpeed;
			float num9 = num8 / num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
			float num10 = num9 * num7;
			float num11 = num8 - num10;
			if (!(0f > num11))
			{
				if (num11 > num7)
				{
					num11 = num7;
				}
			}
			else
			{
				num11 = 0f;
			}
			float num12 = num11 - floatOffset;
			float x = floatOffset * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj3 = num12 & 0;
			float num13 = floatOffset - (float)obj3;
			float num14 = num13 - x;
			float num15 = (float)Vector3.upVector * num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-65]");
			float num16 = 0f * num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num17 = 0f * num14;
			float num18 = num15 + (float)startPosition;
			float num19 = num16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Pickup)+5C]");
			float num20 = num19 + 0f;
			float num21 = num17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Pickup)+60]");
			float num22 = num21 + 0f;
			Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			transform3.position = position;
		}
		if (!pickedUp)
		{
			return;
		}
		Transform transform4 = base.transform;
		Vector3 position2 = transform4.position;
		Vector3 position3 = target.position;
		Transform transform5 = base.transform;
		Vector3 position4 = transform5.position;
		float num23 = position3.x - position4.x;
		float num24 = position3.y - position4.y;
		float num25 = position3.z - position4.z;
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj6 = default(object);
		float num26 = (float)obj6 * MyTime.deltaTime;
		Vector3 position5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rax_v12+4]");
		float num27 = 0f * MyTime.deltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rax_v12+8]");
		float num28 = 0f * MyTime.deltaTime;
		float num29 = num26 * speed;
		float num30 = num27 * speed;
		float num31 = num28 * speed;
		float num32 = num29 + position2.x;
		float num33 = num30 + position2.y;
		float num34 = num31 + position2.z;
		transform4.position = position5;
		float num35;
		float num36;
		if (MyTime.finalSwarmTimer > 10f)
		{
			num35 = 4f;
			num36 = 150f;
		}
		else
		{
			num35 = 2.5f;
			num36 = 50f;
		}
		float num37 = num36 - 1f;
		if (!(num37 > speed))
		{
			return;
		}
		float num38 = num35 * MyTime.deltaTime;
		if (!(0f > num38))
		{
			if (num38 > 1f)
			{
				num38 = 1f;
			}
		}
		else
		{
			num38 = 0f;
		}
		float num39 = num36 - speed;
		float num40 = num39 * num38;
		float num41 = num40 + speed;
		speed = num41;
	}

	private void FixedUpdate()
	{
		if (pickedUp)
		{
			float num = ((!(speed > 50f)) ? 0.25f : 1f);
			Vector3 position = target.position;
			Transform transform = base.transform;
			Vector3 position2 = transform.position;
			float num2 = position.x - position2.x;
			float num3 = position.y - position2.y;
			float num4 = position.z - position2.z;
			float num5 = num3 * num3;
			float num6 = num2 * num2;
			float num7 = num4 * num4;
			float num8 = num5 + num6;
			float num9 = num8 + num7;
			if (num > num9)
			{
				ApplyPickup();
			}
		}
	}

	public virtual bool CanPickup()
	{
		//IL_00d7: Expected I4, but got O
		if (!pickedUp)
		{
			if (ePickup == EPickup.Health)
			{
				if ((object)GameManager.Instance != null)
				{
					PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
					if (playerInventory != null && playerInventory.playerHealth != null)
					{
						if (playerInventory.playerHealth.CanHeal())
						{
							goto IL_00bd;
						}
						goto IL_00c3;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_00bd;
		}
		goto IL_00c3;
		IL_00bd:
		return true;
		IL_00c3:
		return false;
	}

	public int GetValue()
	{
		return value;
	}
}
