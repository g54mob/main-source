using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

public class SpawnInteractables : MonoBehaviour
{
	public GameObject chest;

	public GameObject chestFree;

	private float chestDensity = 0.00012f;

	private float shrineDensity = 4.2E-05f;

	private float chanceForFreeChest = 0.05f;

	public const int numChestsPerStage = 46;

	public const int numShrines = 14;

	private int numRails;

	public GameObject[] rails;

	private Vector3 worldArea;

	private Vector3 worldCenter;

	private float areaMagnitude;

	public void SetArea(Vector3 worldArea, Vector3 worldCenter, float mag)
	{
		//IL_000f: Expected O, but got F4
		//IL_0028: Expected O, but got F4
		this.worldArea = (Vector3)worldArea.x;
		_ = worldArea.z;
		this.worldCenter = (Vector3)worldCenter.x;
		_ = worldCenter.z;
		areaMagnitude = mag;
	}

	public void SpawnShit()
	{
		SpawnRails();
		SpawnChests();
		SpawnShrines();
		SpawnOther();
	}

	public unsafe void SpawnChests()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0092: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_0126: Expected O, but got Ref
		//IL_0134: Expected O, but got Ref
		//IL_0190: Expected F4, but got I4
		//IL_0190: Expected F4, but got I4
		//IL_01a2: Expected I, but got O
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_02f2: Expected O, but got Ref
		//IL_0300: Expected O, but got Ref
		//IL_034e: Expected O, but got Ref
		//IL_0379: Expected O, but got Ref
		//IL_03a4: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (ChallengesTracker.HasChallengeModifier("no_items"))
		{
			return;
		}
		_ = 46;
		int num = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		string text = ((int*)num)->ToString();
		string text2 = "numChests: " + text;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		float stat = PlayerStats.GetStat(EStat.ChestIncreaseMultiplier);
		GameObject gameObject = UnityEngine.Object.Instantiate((GameObject)33, (Vector3)0, (Quaternion)0);
		if (ChallengesTracker.HasChallengeModifier("turbo"))
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r13d,xmm0\"");
		List<GameObject> original = new List<GameObject>();
		object obj3 = default(object);
		if ((nint)obj3 <= 0)
		{
			return;
		}
		object obj4 = 0;
		int layerMask = default(int);
		ref Vector3 normal = default(ref Vector3);
		int attempts = default(int);
		bool onlyUseGroundLayer = default(bool);
		bool debug = default(bool);
		object obj5 = default(object);
		do
		{
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			Vector3 size = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			Vector3 center = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			_ = worldArea;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SpawnInteractables)+50]");
			_ = 0;
			_ = worldCenter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SpawnInteractables)+5C]");
			_ = 0;
			Vector3 objectSpawnPosition = SpawnPositions.GetObjectSpawnPosition(center, size, 0.5f, layerMask, out normal, attempts, onlyUseGroundLayer, debug, (byte)(&obj5) != 0, 50f, 1f);
			nint num2 = (nint)typeof(SpawnPositions);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rax_v28 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
			nint num3 = 0;
			float num4 = objectSpawnPosition.x - (float)SpawnPositions.INVALID_POS;
			float num5 = objectSpawnPosition.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ rcx_v25 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
			float num6 = num5 - 0f;
			float num7 = objectSpawnPosition.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ rcx_v25 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
			float num8 = num7 - 0f;
			float num9 = num6 * num6;
			float num10 = num4 * num4;
			float num11 = num8 * num8;
			float num12 = num9 + num10;
			float num13 = num12 + num11;
			if (!(9.9999994E-11f > num13))
			{
				GameObject original2 = chest;
				double num14 = MyRandom.random.NextDouble();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
				if ((nint)MyRandom.random > 0)
				{
					original2 = chestFree;
				}
				Transform transform = chest.transform;
				Quaternion rotation = transform.rotation;
				Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
				Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
				_ = objectSpawnPosition.z;
				_ = rotation.x;
				GameObject gameObject2 = UnityEngine.Object.Instantiate(original2, position, rotation2);
				Transform transform2 = gameObject2.transform;
				Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
				_ = 0;
				Quaternion quaternion = Quaternion.LookRotation(forward);
				Quaternion rotation3 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
				_ = quaternion.x;
				transform2.rotation = rotation3;
				GameObject gameObject3 = UnityEngine.Object.Instantiate((GameObject)(object)original, (Vector3)gameObject2, (Quaternion)0);
				nint num15 = 0;
			}
			obj4++;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3));
	}

	public unsafe void SpawnShrines()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0056: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_0072: Expected O, but got Ref
		//IL_012d: Expected O, but got I
		//IL_017c: Expected O, but got I4
		//IL_019e: Expected O, but got Ref
		//IL_01ac: Expected O, but got Ref
		//IL_0208: Expected F4, but got I4
		//IL_0208: Expected F4, but got I4
		//IL_021a: Expected I, but got O
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected O, but got Unknown
		//IL_034a: Expected O, but got Ref
		//IL_0358: Expected O, but got Ref
		//IL_03a6: Expected O, but got Ref
		//IL_03d1: Expected O, but got Ref
		//IL_0453: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 14;
		int num = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		string text = ((int*)num)->ToString();
		string text2 = "numShrines: " + text;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		List<GameObject> list = new List<GameObject>();
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		GameObject[] shrines = mapData.shrines;
		_ = 0;
		object obj3 = 0;
		for (object obj4 = 0; (nint)obj4 < shrines.Length; Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]"), obj3 = (nint)0 + (nint)1, obj4 = obj3)
		{
			Enum obj5 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 32));
			_ = typeof(EMyStat);
			_ = -1;
			_ = 22;
			string statName = obj5.ToString();
			float stat = MyStats.GetStat(statName);
			if (!(2f < stat))
			{
				InteractableShrineCursed componentInChildren = shrines[obj3].GetComponentInChildren<InteractableShrineCursed>();
				if ((bool)componentInChildren)
				{
					continue;
				}
			}
			list.Add(shrines[obj3]);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r13d,xmm0\"");
		object obj6 = default(object);
		if ((nint)obj6 <= 0)
		{
			return;
		}
		object obj7 = 0;
		int layerMask = default(int);
		ref Vector3 normal = default(ref Vector3);
		int attempts = default(int);
		bool onlyUseGroundLayer = default(bool);
		bool debug = default(bool);
		object obj8 = default(object);
		do
		{
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			Vector3 size = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			Vector3 center = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			_ = worldArea;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SpawnInteractables)+50]");
			_ = 0;
			_ = worldCenter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SpawnInteractables)+5C]");
			_ = 0;
			Vector3 objectSpawnPosition = SpawnPositions.GetObjectSpawnPosition(center, size, 0.5f, layerMask, out normal, attempts, onlyUseGroundLayer, debug, (byte)(&obj8) != 0, 50f, 1f);
			nint num2 = (nint)typeof(SpawnPositions);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ rax_v30 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
			nint num3 = 0;
			float num4 = objectSpawnPosition.x - (float)SpawnPositions.INVALID_POS;
			float num5 = objectSpawnPosition.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ rcx_v26 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
			float num6 = num5 - 0f;
			float num7 = objectSpawnPosition.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ rcx_v26 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
			float num8 = num7 - 0f;
			float num9 = num6 * num6;
			float num10 = num4 * num4;
			float num11 = num8 * num8;
			float num12 = num9 + num10;
			float num13 = num12 + num11;
			if (!(9.9999994E-11f > num13))
			{
				int index = MyRandom.random.Next(0, list._size);
				GameObject original = list.get_Item(index);
				Transform transform = chest.transform;
				Quaternion rotation = transform.rotation;
				Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
				Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
				_ = objectSpawnPosition.z;
				_ = rotation.x;
				GameObject gameObject = UnityEngine.Object.Instantiate(original, position, rotation2);
				Transform transform2 = gameObject.transform;
				Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
				_ = 0;
				Quaternion quaternion = Quaternion.LookRotation(forward);
				Quaternion rotation3 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
				_ = quaternion.x;
				transform2.rotation = rotation3;
				Transform transform3 = gameObject.transform;
				Transform transform4 = gameObject.transform;
				Vector3 forward2 = transform4.forward;
				float angle = UnityEngine.Random.Range(0f, 360f);
				_ = forward2.x;
				_ = forward2.z;
				Vector3 axis = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
				transform3.Rotate(axis, angle, Space.World);
				Space space = Space.World;
			}
			obj7++;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6));
	}

	private unsafe void SpawnOther()
	{
		//IL_0073: Expected F4, but got I4
		//IL_0073: Expected O, but got Ref
		//IL_0073: Expected O, but got Ref
		//IL_00c0: Expected O, but got Ref
		//IL_00c0: Expected O, but got Ref
		if (!MyAchievements.IsAchievementDone("a_bananarang"))
		{
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			object obj = default(object);
			Vector3 vector = default(Vector3);
			int layerMask = default(int);
			ref Vector3 normal = default(ref Vector3);
			int attempts = default(int);
			bool onlyUseGroundLayer = default(bool);
			bool debug = default(bool);
			object obj2 = default(object);
			Vector3 objectSpawnPosition = SpawnPositions.GetObjectSpawnPosition((Vector3)(&obj), (Vector3)(&vector), 0.5f, layerMask, out normal, attempts, onlyUseGroundLayer, debug, (byte)(&obj2) != 0, 100f);
			EffectManager instance2 = EffectManager.Instance;
			EffectManager instance3 = EffectManager.Instance;
			Transform transform = instance3.bananaQuest.transform;
			Quaternion rotation = transform.rotation;
			object obj3 = default(object);
			GameObject gameObject = UnityEngine.Object.Instantiate(instance2.bananaQuest, (Vector3)(&vector), (Quaternion)(&obj3));
		}
	}

	private unsafe void SpawnRails()
	{
		//IL_06e3: Expected F4, but got I4
		//IL_0052: Expected O, but got I4
		//IL_0802: Expected O, but got I4
		//IL_07db: Expected I, but got O
		//IL_009c: Expected F4, but got I4
		//IL_009c: Expected F4, but got I4
		//IL_009c: Expected O, but got Ref
		//IL_009c: Expected O, but got Ref
		//IL_00ae: Expected I, but got O
		//IL_016d: Expected O, but got Ref
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected O, but got Unknown
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Expected O, but got Unknown
		//IL_01d9: Expected I, but got O
		//IL_0204: Expected I, but got O
		//IL_0248: Expected I, but got O
		//IL_0283: Expected O, but got Ref
		//IL_0283: Expected O, but got Ref
		//IL_02a7: Expected I, but got O
		//IL_070b: Expected I, but got O
		//IL_0732: Expected O, but got I
		//IL_0770: Invalid comparison between O and F4
		//IL_085d: Expected O, but got I4
		//IL_085d: Expected O, but got Ref
		//IL_085d: Expected O, but got Ref
		//IL_0894: Expected O, but got I
		//IL_08b5: Expected O, but got I4
		//IL_08b5: Expected O, but got Ref
		//IL_08b5: Expected O, but got Ref
		//IL_02db: Expected O, but got Ref
		//IL_02db: Expected O, but got Ref
		//IL_0311: Expected O, but got Ref
		//IL_07c4: Expected I, but got O
		//IL_033e: Expected O, but got Ref
		//IL_0367: Expected I, but got O
		//IL_04d2: Expected I, but got O
		//IL_051b: Expected O, but got I4
		//IL_03c4: Expected I, but got O
		//IL_040d: Expected O, but got I4
		//IL_0432: Expected I, but got O
		//IL_045e: Expected I, but got O
		//IL_04a4: Expected O, but got I
		List<GameObject> list = new List<GameObject>();
		bool flag = numRails <= 0;
		float num = 0f;
		if (flag)
		{
			goto IL_0578;
		}
		Space space2 = default(Space);
		Space space = space2;
		object obj = 0;
		Vector3 vector = default(Vector3);
		Vector3 vector2 = default(Vector3);
		int layerMask = default(int);
		ref Vector3 normal = default(ref Vector3);
		int attempts = default(int);
		bool onlyUseGroundLayer = default(bool);
		bool debug = default(bool);
		object obj3 = default(object);
		object obj4 = default(object);
		float x = default(float);
		object obj7 = default(object);
		object obj8 = default(object);
		object obj12 = default(object);
		float num17 = default(float);
		object obj14 = default(object);
		nint num19 = default(nint);
		object obj15 = default(object);
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		Vector3 upVector = default(Vector3);
		object obj16 = default(object);
		while (true)
		{
			object obj2 = 0;
			while (true)
			{
				nint num2 = (nint)GameManager.Instance;
				if ((object)GameManager.Instance == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				Vector3 objectSpawnPosition = SpawnPositions.GetObjectSpawnPosition((Vector3)(&vector), (Vector3)(&vector2), 1f, layerMask, out normal, attempts, onlyUseGroundLayer, debug, (byte)(&obj3) != 0, 50f, 1f);
				nint num3 = (nint)typeof(SpawnPositions);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ rax_v40 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
				num2 = 0;
				float num4 = objectSpawnPosition.x - (float)SpawnPositions.INVALID_POS;
				float num5 = objectSpawnPosition.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v998 @ rcx_v6 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
				float num6 = num5 - 0f;
				float num7 = objectSpawnPosition.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v998 @ rcx_v6 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
				float num8 = num7 - 0f;
				float num9 = num8 * num8;
				num = num6 * num6;
				float num10 = num4 * num4;
				float num11 = num10 + num;
				float num12 = num11 + num9;
				bool flag2 = 9.9999994E-11f > num12;
				Vector3 vector3 = (Vector3)(&vector2);
				float num13 = 1f;
				if (!flag2)
				{
					GameObject[] array = rails;
					if (rails == null)
					{
						break;
					}
					int num14 = UnityEngine.Random.Range(0, array.Length);
					bool flag3 = num14 >= array.Length;
					num2 = unchecked((nint)null);
					if (flag3)
					{
						throw new IndexOutOfRangeException();
					}
					bool flag4 = (object)array[num14] == null;
					num2 = unchecked((nint)null);
					if (flag4)
					{
						break;
					}
					Transform transform = array[num14].transform;
					bool flag5 = (object)transform == null;
					num2 = (nint)array[num14];
					if (flag5)
					{
						break;
					}
					Quaternion rotation = transform.rotation;
					GameObject gameObject = UnityEngine.Object.Instantiate(array[num14], (Vector3)(&obj4), (Quaternion)(&x));
					bool flag6 = (object)gameObject == null;
					num2 = (nint)array[num14];
					if (flag6)
					{
						break;
					}
					gameObject.SetActive(value: true);
					nint num15 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1409 @ rcx_v40 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1410 @ rax_v50 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
					object obj5 = (nint)0 * (nint)0;
					object obj6 = obj7 * obj8;
					object obj9 = (object)Vector3.rightVector * obj3;
					object obj10 = obj9 + obj6;
					object obj11 = obj10 + obj5;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.99f))
					{
					}
					GameObject gameObject2 = UnityEngine.Object.Instantiate((GameObject)(&obj12), (Vector3)(&num17), (Quaternion)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1488 @ rax_v52 (UnityEngine.GameObject)+8]");
					num13 = 0f * (float)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1488 @ rax_v52 (UnityEngine.GameObject)+4]");
					object obj13 = (nint)0 * (nint)0;
					float num18 = (float)obj13 - num13;
					GameObject gameObject3 = UnityEngine.Object.Instantiate((GameObject)(&obj14), (Vector3)(&num17), (Quaternion)0);
					Transform transform2 = gameObject.transform;
					Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num19), (Vector3)(&obj15));
					bool flag7 = (object)transform2 == null;
					num2 = (nint)(&enumerator);
					if (flag7)
					{
						break;
					}
					transform2.rotation = (Quaternion)(&x);
					Transform transform3 = gameObject.transform;
					num = UnityEngine.Random.Range(0f, 360f);
					bool flag8 = (object)transform3 == null;
					num2 = (nint)typeof(Vector3);
					if (flag8)
					{
						break;
					}
					transform3.Rotate((Vector3)(&upVector), num, Space.Self);
					Rail componentInChildren = gameObject.GetComponentInChildren<Rail>();
					bool flag9 = (object)componentInChildren == null;
					num2 = (nint)gameObject;
					if (flag9)
					{
						break;
					}
					if (componentInChildren.IsValidPosition())
					{
						bool isStatic = gameObject.isStatic;
						bool flag10 = !isStatic;
						upVector = Vector3.upVector;
						num19 = (nint)gameObject3;
						obj15 = obj3;
						num17 = num18;
						space = Space.Self;
						obj4 = obj16;
						x = quaternion.x;
						num9 = 360f;
						num12 = num;
						vector3 = (Vector3)0;
						if (!flag10)
						{
							bool flag11 = list == null;
							num2 = (nint)gameObject;
							if (flag11)
							{
								break;
							}
							list.Add(gameObject);
							upVector = Vector3.upVector;
							num19 = (nint)gameObject3;
							obj15 = obj3;
							num17 = num18;
							space = Space.Self;
							obj4 = obj16;
							x = quaternion.x;
							num9 = 360f;
							num12 = num;
							vector3 = (Vector3)0;
						}
					}
					else
					{
						UnityEngine.Object.Destroy(gameObject);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						upVector = Vector3.upVector;
						num19 = (nint)gameObject3;
						obj15 = obj3;
						num17 = num18;
						space = Space.Self;
						obj4 = obj16;
						x = quaternion.x;
						num9 = 360f;
						num12 = num;
						vector3 = (Vector3)0;
					}
				}
				obj2++;
				if ((nint)obj2 < 5)
				{
					continue;
				}
				goto IL_054c;
			}
			break;
			IL_054c:
			obj++;
			if ((nint)obj < numRails)
			{
				continue;
			}
			goto IL_0578;
		}
		goto IL_069f;
		IL_0578:
		if (list != null)
		{
			if (list._size <= 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text = $"RandomObjectsParent{arg}";
			GameObject gameObject4 = new GameObject(text);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			GameObject gameObject5 = default(GameObject);
			while (true)
			{
				if (enumerator2.MoveNext())
				{
					if ((object)gameObject5 != null)
					{
						Transform transform4 = gameObject5.transform;
						if ((object)gameObject4 != null)
						{
							Transform parentInternal = gameObject4.transform;
							if ((object)transform4 == null)
							{
								break;
							}
							transform4.parentInternal = parentInternal;
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				((List<GameObject>.Enumerator*)(&enumerator2))->Dispose();
				StaticBatchingUtility.Combine(gameObject4);
				return;
			}
			throw new NullReferenceException();
		}
		goto IL_069f;
		IL_069f:
		throw new NullReferenceException();
	}
}
