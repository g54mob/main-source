using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class EnemySpecialAttackSpinningLasers : EnemySpecialAttackPrefab
{
	public Rigidbody rb;

	public Transform disk;

	public Transform laserParent;

	private Transform[] lasers;

	private float overAtTime;

	private float startedAtTime;

	private float laserLength = 250f;

	private float maxLaserLength = 250f;

	private Vector3 defaultScale;

	private float defaultVolume;

	public AudioSource audio;

	private float audioFadeTime = 1f;

	private float damageCooldown = 0.1f;

	private float nextDamageReadyTime;

	public float defaultSpinSpeed;

	public float diskRotationSpeed;

	private float spinSpeed;

	private float spinAngle;

	private float spinPhaseOffset;

	protected override void Init()
	{
		//IL_0129: Expected I, but got O
		//IL_0166: Expected O, but got I
		//IL_0183: Expected O, but got I
		//IL_01cd: Invalid comparison between F4 and O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		object obj = defaultScale - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EnemySpecialAttackSpinningLasers)+84]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj2 = num3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EnemySpecialAttackSpinningLasers)+88]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj3 = num4 - 0;
		object obj4 = obj2 * obj2;
		object obj5 = obj * obj;
		object obj6 = obj3 * obj3;
		object obj7 = obj4 + obj5;
		object obj8 = obj7 + obj6;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
		{
			OnceInit();
		}
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		startedAtTime = MyTime.time;
		float num5 = MyTime.time + enemySpecialAttack.duration;
		overAtTime = num5;
		float num6 = MyTime.time + 0.75f;
		laserLength = 1f;
		nextDamageReadyTime = num6;
		audio.volume = 0f;
		spinSpeed = defaultSpinSpeed;
		if (MapController.index > 0)
		{
			float num7 = (float)MapController.index * 0.4f;
			float num8 = num7 + 1f;
			float num9 = num8 * spinSpeed;
			spinSpeed = num9;
		}
	}

	private void OnceInit()
	{
		//IL_002e: Expected O, but got F4
		//IL_005a: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_00ee: Expected O, but got I4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_015c: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		//IL_0293: Expected O, but got I4
		//IL_029c: Expected O, but got I4
		//IL_033e: Expected O, but got I4
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_0395: Expected O, but got I4
		//IL_02d7: Expected I, but got O
		//IL_02e7: Expected O, but got I
		//IL_0309: Expected O, but got I4
		//IL_03b4: Expected O, but got I4
		Transform transform = base.transform;
		bool flag = (object)transform == null;
		Transform transform2 = null;
		Component component = this;
		if (!flag)
		{
			Vector3 localScale = transform.localScale;
			float x = localScale.x;
			defaultScale = (Vector3)localScale.x;
			_ = localScale.z;
			bool flag2 = (object)audio == null;
			transform2 = transform;
			object obj = 0;
			component = audio;
			if (!flag2)
			{
				x = audio.volume;
				component = laserParent;
				defaultVolume = x;
				bool flag3 = (object)laserParent == null;
				transform2 = null;
				obj = 0;
				if (!flag3)
				{
					Transform transform3 = laserParent.transform;
					bool flag4 = (object)transform3 == null;
					transform2 = null;
					obj = 0;
					if (!flag4)
					{
						int childCount = transform3.childCount;
						Transform[] array = new Transform[childCount];
						component = (Component)(this + 104);
						lasers = array;
						bool flag5 = (object)laserParent == null;
						int num = 0;
						int num2 = 0;
						object obj2 = 0;
						Component component2 = laserParent;
						transform2 = (Transform)(object)array;
						obj = 0;
						if (!flag5)
						{
							object obj3 = default(object);
							object obj4 = default(object);
							while (true)
							{
								Transform transform4 = component2.transform;
								bool flag6 = (object)transform4 == null;
								transform2 = null;
								obj = obj2;
								component = component2;
								if (flag6)
								{
									break;
								}
								int childCount2 = transform4.childCount;
								if (num >= childCount2)
								{
									return;
								}
								component = laserParent;
								bool flag7 = (object)laserParent == null;
								transform2 = null;
								obj = obj2;
								if (flag7)
								{
									break;
								}
								Transform[] array2 = lasers;
								Transform transform5 = laserParent.transform;
								bool flag8 = (object)transform5 == null;
								transform2 = null;
								obj = obj2;
								if (flag8)
								{
									break;
								}
								Transform child = transform5.GetChild(num2);
								bool flag9 = lasers == null;
								transform2 = (Transform)num2;
								obj = 0;
								component = transform5;
								if (flag9)
								{
									break;
								}
								if ((object)child != null)
								{
									nint num3 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdx_v19 (Il2CppClass<UnityEngine.Transform[]>)+40]");
									transform2 = (Transform)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									bool flag10 = obj3 == null;
									obj = 0;
									component = child;
									if (flag10)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
										throw obj4;
									}
								}
								array2[num2] = child;
								object obj5 = num2 + 4;
								object obj6 = obj5 * 8;
								component = (Component)(object)((object)lasers + obj6);
								component2 = laserParent;
								num2++;
								bool flag11 = (object)laserParent == null;
								transform2 = child;
								obj = 0;
								if (flag11)
								{
									break;
								}
								num = num2;
								obj2 = 0;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void FixedUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0589: Invalid comparison between I4 and F4
		//IL_018c: Expected F4, but got I4
		//IL_01cc: Invalid comparison between I4 and F4
		//IL_0512: Invalid comparison between I4 and F4
		//IL_0217: Expected F4, but got I4
		//IL_007d: Expected F4, but got I4
		//IL_00cc: Invalid comparison between I4 and F4
		//IL_0141: Expected F4, but got I4
		//IL_0280: Expected O, but got Ref
		//IL_02ab: Expected O, but got I4
		//IL_02b4: Expected O, but got I4
		//IL_0341: Expected O, but got Ref
		//IL_0341: Expected O, but got Ref
		//IL_03eb: Expected O, but got Ref
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_0402: Expected O, but got I4
		//IL_037b: Expected O, but got Ref
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected O, but got Unknown
		//IL_03ac: Expected F4, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (!(MyTime.time < overAtTime))
		{
			ReturnToPool();
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
			return;
		}
		float num = MyTime.time - startedAtTime;
		float num6;
		if (audioFadeTime > num)
		{
			float num2 = MyTime.time - startedAtTime;
			float num3 = num2 / audioFadeTime;
			float num4 = ((0f > num3) ? 0f : ((num3 > 1f) ? 1f : num3));
			float volume = defaultVolume * num4;
			audio.volume = volume;
			float num5 = Easing.InCirc(num3);
			if (!(0f > num5))
			{
				if (num5 > 1f)
				{
					num5 = 1f;
				}
			}
			else
			{
				num5 = 0f;
			}
			num6 = maxLaserLength * num5;
		}
		else
		{
			float num7 = overAtTime - audioFadeTime;
			if (MyTime.time < num7)
			{
				audio.volume = defaultVolume;
				num6 = maxLaserLength;
			}
			else
			{
				float num8 = overAtTime - audioFadeTime;
				float num9 = MyTime.time - num8;
				float num10 = num9 / audioFadeTime;
				float num11 = ((0f > num10) ? 0f : ((num10 > 1f) ? 1f : num10));
				float num12 = 0f - defaultVolume;
				float num13 = num12 * num11;
				float volume2 = num13 + defaultVolume;
				audio.volume = volume2;
				if (!(0f > num10))
				{
					if (num10 > 1f)
					{
						float num14 = 0f - maxLaserLength;
						float num15 = num14 * 1f;
						num6 = num15 + maxLaserLength;
						goto IL_04c6;
					}
				}
				else
				{
					num10 = 0f;
				}
				float num16 = 0f - maxLaserLength;
				float num17 = num16 * num10;
				num6 = num17 + maxLaserLength;
			}
		}
		goto IL_04c6;
		IL_04c6:
		laserLength = num6;
		Vector3 centerPosition = enemy.GetCenterPosition();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804AD730");
		object obj4 = default(object);
		object obj3 = (object)Vector3.downVector * obj4;
		float num18 = (float)obj3 * 0.15f;
		float num19 = num18 + centerPosition.x;
		float num20 = default(float);
		rb.MovePosition((Vector3)(&num20));
		RotationStuff();
		Transform[] array = lasers;
		num20 = num19;
		object obj5 = 0;
		object obj6 = 0;
		float x = default(float);
		float x2 = default(float);
		int layerMask = default(int);
		object obj7 = default(object);
		while ((nint)obj6 < array.Length)
		{
			Transform transform = array[obj5].transform;
			Vector3 position = transform.position;
			Transform transform2 = array[obj5].transform;
			Vector3 forward = transform2.forward;
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			if (!Physics.Raycast((Vector3)(&x), (Vector3)(&x2), out var _, laserLength, layerMask))
			{
				Transform transform3 = array[obj5].transform;
				transform3.localScale = (Vector3)(&num20);
				obj5++;
				x = position.x;
				x2 = forward.x;
				num20 = 1.0653532E+09f;
				obj6 = obj5;
			}
			else
			{
				Transform transform4 = array[obj5].transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C560");
				transform4.localScale = (Vector3)(&obj7);
				obj5++;
				obj7 = 1065353216;
				x = position.x;
				x2 = forward.x;
				obj6 = obj5;
			}
		}
	}

	private unsafe void OnTriggerStay(Collider other)
	{
		//IL_0067: Expected O, but got Ref
		if (!(nextDamageReadyTime > MyTime.time))
		{
			float num = MyTime.time + damageCooldown;
			nextDamageReadyTime = num;
			float damage = base._003CspecialAttack_003Ek__BackingField.GetDamage(enemy);
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			DcFlags damageFlags = GetDamageFlags();
			Vector3 vector = default(Vector3);
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage, 0f, (Vector3)(&vector), ignoreShield, damageSource, flags, damageEffect);
		}
	}

	private unsafe void RotationStuff()
	{
		//IL_0008: Expected O, but got Ref
		//IL_05e5: Expected I, but got O
		//IL_05f3: Expected O, but got Ref
		//IL_0601: Expected O, but got Ref
		//IL_0652: Expected O, but got Ref
		//IL_0660: Expected O, but got Ref
		//IL_06a9: Expected O, but got Ref
		//IL_06d0: Expected I, but got O
		//IL_009b: Invalid comparison between I4 and F4
		//IL_00e6: Expected F4, but got I4
		//IL_073f: Expected I, but got O
		//IL_0758: Expected F4, but got O
		//IL_076e: Expected F4, but got I
		//IL_077e: Expected F4, but got I
		//IL_08f7: Expected O, but got Ref
		//IL_0918: Expected O, but got Ref
		//IL_0926: Expected O, but got Ref
		//IL_09aa: Expected O, but got Ref
		//IL_080b: Expected I, but got O
		//IL_0824: Expected F4, but got O
		//IL_083a: Expected F4, but got I
		//IL_084a: Expected F4, but got I
		//IL_058a: Expected O, but got Ref
		//IL_0598: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		Vector3 position2 = disk.position;
		float num = position.z - position2.z;
		Quaternion rotation = disk.rotation;
		nint num2 = (nint)typeof(Vector3);
		Vector3 upwards = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num3 = 0;
		_ = Vector3.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		_ = 0;
		Quaternion quaternion = Quaternion.LookRotation(forward, upwards);
		Quaternion b = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Quaternion a = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = quaternion.x;
		_ = rotation.x;
		float t = diskRotationSpeed * MyTime.fixedDeltaTime;
		Quaternion quaternion2 = Quaternion.Slerp(a, b, t);
		Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = quaternion2.x;
		disk.rotation = rotation2;
		nint num4 = (nint)typeof(MyTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v21 (Il2CppClass<Assets.Scripts.Utility.MyTime>)+B8]");
		nint num5 = 0;
		float num6 = MyTime.fixedDeltaTime * spinSpeed;
		float num7 = num6 + spinAngle;
		float num8 = num7 / 360f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float num9 = num8 * 360f;
		float num10 = num7 - num9;
		if (!(0f > num10))
		{
			if (num10 > 360f)
			{
				num10 = 360f;
			}
		}
		else
		{
			num10 = 0f;
		}
		spinAngle = num10;
		Vector3 up = disk.up;
		nint num11 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rax_v25 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num12 = 0;
		float num13 = (float)Vector3.rightVector;
		_ = Vector3.rightVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-65]");
		float num14 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
		float num15 = 0f;
		float num16 = up.x * up.x;
		float num17 = up.y * up.y;
		float num18 = up.z * up.z;
		float num19 = num17 + num16;
		float num20 = num19 + num18;
		if (!(Mathf.Epsilon > num20))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-65]");
			float num21 = 0f * up.y;
			float num22 = up.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
			float num23 = num22 * 0f;
			float num24 = (float)Vector3.rightVector * up.x;
			float num25 = num21 + num24;
			float num26 = num25 + num23;
			float num27 = num26 * up.x;
			float num28 = num26 * up.y;
			float num29 = num26 * up.z;
			float num30 = num27 / num20;
			float num31 = num28 / num20;
			float num32 = num29 / num20;
			num13 -= num30;
			num14 -= num31;
			num15 -= num32;
		}
		float num33 = num14 * num14;
		float num34 = num13 * num13;
		float num35 = num15 * num15;
		float num36 = num33 + num34;
		float num37 = num36 + num35;
		if (1E-06f > num37)
		{
			nint num38 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rax_v37 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num39 = 0;
			float num40 = (float)Vector3.forwardVector;
			_ = Vector3.forwardVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-65]");
			float num41 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rdx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
			float num42 = 0f;
			float num43 = up.x * up.x;
			float num44 = up.y * up.y;
			float num45 = up.z * up.z;
			float num46 = num44 + num43;
			float num47 = num46 + num45;
			if (!(Mathf.Epsilon > num47))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-65]");
				float num48 = 0f * up.y;
				float num49 = (float)Vector3.forwardVector * up.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rdx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
				float num50 = 0f * up.z;
				float num51 = num48 + num49;
				float num52 = num51 + num50;
				float num53 = num52 * up.x;
				float num54 = num52 * up.y;
				float num55 = num52 * up.z;
				float num56 = num53 / num47;
				float num57 = num54 / num47;
				float num58 = num55 / num47;
				num40 -= num56;
				num41 -= num57;
				num42 -= num58;
			}
		}
		Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		((Vector3*)vector)->Normalize();
		_ = up.x;
		Vector3 upwards2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Vector3 forward2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-75]");
		float num59 = 0f * up.x;
		_ = up.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-79]");
		float num60 = 0f * up.y;
		_ = up.z;
		float num61 = num60 - num59;
		Quaternion quaternion3 = Quaternion.LookRotation(forward2, upwards2);
		Vector3 axis = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		float angle = spinPhaseOffset + spinAngle;
		_ = up.x;
		_ = up.y;
		_ = up.z;
		Quaternion quaternion4 = Quaternion.AngleAxis(angle, axis);
		Transform transform2 = laserParent.transform;
		Vector3 position3 = disk.position;
		float num62 = quaternion4.w * quaternion3.x;
		float num63 = quaternion4.y * quaternion3.z;
		float num64 = quaternion4.x * quaternion3.w;
		float num65 = quaternion4.y * quaternion3.w;
		float num66 = num64 + num62;
		float num67 = quaternion4.z * quaternion3.w;
		float num68 = quaternion4.z * quaternion3.y;
		float num69 = num66 + num63;
		float num70 = quaternion4.z * quaternion3.x;
		float num71 = quaternion4.z * quaternion3.z;
		float num72 = num69 - num68;
		float num73 = quaternion4.w * quaternion3.y;
		float num74 = num65 + num73;
		float num75 = quaternion4.x * quaternion3.z;
		float num76 = num74 + num70;
		float num77 = quaternion4.x * quaternion3.x;
		float num78 = quaternion4.x * quaternion3.y;
		float num79 = num76 - num75;
		float num80 = quaternion4.w * quaternion3.z;
		float num81 = quaternion4.w * quaternion3.w;
		float num82 = num67 + num80;
		float num83 = quaternion4.y * quaternion3.y;
		float num84 = num81 - num77;
		float num85 = quaternion4.y * quaternion3.x;
		float num86 = num82 + num78;
		float num87 = num84 - num83;
		float num88 = num86 - num85;
		float num89 = num87 - num71;
		Quaternion rotation3 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = position3.x;
		_ = position3.z;
		transform2.SetPositionAndRotation(position4, rotation3);
	}
}
