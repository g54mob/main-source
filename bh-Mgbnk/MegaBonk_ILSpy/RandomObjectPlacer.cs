using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Game.MapGeneration;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Managers;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;

public class RandomObjectPlacer : MonoBehaviour
{
	public Vector3 center;

	public Vector3 size;

	private int numChargeShrines = 15;

	public RandomMapObject[] randomObjects;

	public RandomMapObject chargeShrineSpawns;

	public RandomMapObject greedShrineSpawns;

	private int index;

	public void GenerateInteractables(MapData mapData)
	{
		//IL_018f: Expected O, but got I4
		//IL_0198: Expected O, but got I4
		//IL_007d: Expected I, but got O
		//IL_0085: Expected I, but got O
		//IL_0095: Expected O, but got I
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_00d1: Expected O, but got I
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected I4, but got Unknown
		if (MapController.HasPlayerInventory())
		{
			PlayerInventory playerInventory = MapController.GetPlayerInventory(null);
			ItemBase item = playerInventory.itemInventory.GetItem(EItem.Beacon);
			if (item != null)
			{
				nint num = (nint)typeof(ItemBeacon);
				nint num2 = (nint)item;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r8_v4 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemBeacon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r9_v7 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r8_v4 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemBeacon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r9_v7 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v14+FFFFFFF8+v93 @ rcx_v13*8]");
					if (0 == (nint)typeof(ItemBeacon))
					{
						RandomMapObject randomMapObject = chargeShrineSpawns;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180439050");
						object obj3 = default(object);
						int amount = obj3 + randomMapObject.amount;
						randomMapObject.amount = amount;
					}
				}
			}
		}
		RandomMapObject[] randomObjectsOverride = mapData.randomObjectsOverride;
		bool flag = randomObjectsOverride.Length != 0;
		RandomMapObject[] array = randomObjectsOverride;
		if (!flag)
		{
			array = randomObjects;
		}
		RandomObjectSpawner(chargeShrineSpawns, mapData.numShrinesPotsAndOtherMultiplier);
		RandomObjectSpawner(greedShrineSpawns, mapData.numShrinesPotsAndOtherMultiplier);
		object obj4 = 0;
		object obj5 = 0;
		while ((nint)obj4 < array.Length)
		{
			RandomObjectSpawner(array[obj5], mapData.numShrinesPotsAndOtherMultiplier);
			obj5++;
			obj4 = obj5;
		}
	}

	public void Generate(RandomMapObject[] objects, float amountMultiplier)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < objects.Length)
		{
			RandomObjectSpawner(objects[obj2], amountMultiplier);
			obj2++;
			obj = obj2;
		}
	}

	private unsafe void RandomObjectSpawner(RandomMapObject randomObject, float amountMultiplier = 1f)
	{
		//IL_004a: Expected I, but got O
		//IL_02f0: Expected I, but got O
		//IL_017b: Expected I, but got O
		//IL_0340: Expected O, but got I4
		//IL_0348: Expected I, but got O
		//IL_01ee: Expected I, but got O
		//IL_0528: Expected I, but got O
		//IL_0378: Expected O, but got I4
		//IL_037d: Expected I, but got O
		//IL_0227: Expected I, but got O
		//IL_0574: Expected I, but got O
		//IL_03ae: Expected I, but got O
		//IL_026b: Expected I, but got O
		//IL_0742: Expected I, but got O
		//IL_03dd: Expected I, but got O
		//IL_05a0: Expected I, but got O
		//IL_0762: Expected O, but got I4
		//IL_041a: Expected O, but got I4
		//IL_0427: Expected I, but got O
		//IL_0e24: Expected I, but got O
		//IL_05d1: Expected I, but got O
		//IL_043d: Expected I, but got O
		//IL_044b: Expected I, but got O
		//IL_0482: Expected O, but got I4
		//IL_0600: Expected I, but got O
		//IL_04c8: Expected O, but got I4
		//IL_07be: Expected F4, but got I4
		//IL_07be: Expected F4, but got I4
		//IL_07be: Expected O, but got Ref
		//IL_07be: Expected O, but got Ref
		//IL_0e50: Expected I, but got O
		//IL_0639: Expected I, but got O
		//IL_04f8: Expected I, but got O
		//IL_064f: Expected I, but got O
		//IL_065d: Expected I, but got O
		//IL_066d: Expected O, but got I
		//IL_0699: Expected I, but got O
		//IL_07fd: Expected I, but got O
		//IL_06b7: Expected O, but got I
		//IL_06e4: Expected I, but got O
		//IL_0841: Expected I, but got O
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_070c: Expected O, but got Unknown
		//IL_071a: Expected I, but got O
		//IL_087c: Expected O, but got Ref
		//IL_087c: Expected O, but got Ref
		//IL_08a0: Expected I, but got O
		//IL_0a16: Expected O, but got Ref
		//IL_0909: Expected I, but got O
		//IL_0a52: Expected O, but got Ref
		//IL_0ae7: Expected I, but got O
		//IL_09ad: Expected O, but got Ref
		//IL_0b07: Expected O, but got Ref
		//IL_0b15: Expected I, but got O
		//IL_0b3e: Expected I, but got O
		//IL_09e4: Expected O, but got Ref
		//IL_0b8f: Expected O, but got Ref
		//IL_0bb1: Expected I, but got O
		//IL_0bb9: Expected I, but got O
		//IL_0c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1a: Expected O, but got Unknown
		//IL_0bde: Expected I, but got O
		//IL_0c07: Expected I, but got O
		nint num = (nint)typeof(SaveManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v7 (Il2CppClass<SaveManager>)+B8]");
		nint num2 = 0;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null)
			{
				CFGameSettings cfGameSettings = config.cfGameSettings;
				if (config.cfGameSettings != null)
				{
					if (cfGameSettings.enable_silver_pots != 0)
					{
						goto IL_0279;
					}
					if (randomObject != null)
					{
						GameObject[] prefabs = randomObject.prefabs;
						if (randomObject.prefabs != null)
						{
							bool flag = (object)prefabs[0] == null;
							num2 = (nint)prefabs[0];
							if (!flag)
							{
								string text = prefabs[0].name;
								if (!(text != "PotSmallSilver"))
								{
									return;
								}
								GameObject[] prefabs2 = randomObject.prefabs;
								bool flag2 = randomObject.prefabs == null;
								num2 = (nint)text;
								if (!flag2)
								{
									bool flag3 = (object)prefabs2[0] == null;
									num2 = (nint)prefabs2[0];
									if (!flag3)
									{
										string text2 = prefabs2[0].name;
										bool flag4 = text2 != "PotBigSilver";
										num2 = (nint)text2;
										if (!flag4)
										{
											return;
										}
										goto IL_0279;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0d77;
		IL_0279:
		object obj;
		if (randomObject != null)
		{
			GameObject[] prefabs3 = randomObject.prefabs;
			if (randomObject.prefabs != null)
			{
				bool flag5 = (object)prefabs3[0] == null;
				num2 = (nint)prefabs3[0];
				if (!flag5)
				{
					string text3 = prefabs3[0].name;
					bool flag6 = text3 == "PotSmall";
					bool flag7 = !flag6;
					obj = 0;
					num2 = (nint)text3;
					if (!flag7)
					{
						bool flag8 = MapController.HasPlayerInventory();
						bool flag9 = !flag8;
						obj = 0;
						num2 = unchecked((nint)null);
						if (!flag9)
						{
							PlayerInventory playerInventory = MapController.GetPlayerInventory(null);
							bool flag10 = playerInventory == null;
							num2 = unchecked((nint)null);
							if (!flag10)
							{
								bool flag11 = playerInventory.itemInventory == null;
								num2 = (nint)playerInventory.itemInventory;
								if (!flag11)
								{
									ItemBase item = playerInventory.itemInventory.GetItem(EItem.Pumpkin);
									bool flag12 = item == null;
									obj = 0;
									num2 = (nint)playerInventory.itemInventory;
									if (!flag12)
									{
										nint num3 = (nint)item;
										nint num4 = (nint)typeof(ItemPumpkin);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1483 @ r8_v44 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPumpkin>)+130]");
										num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ r9_v9 (Il2CppMethodInfo)+130]");
										nint num5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1483 @ r8_v44 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPumpkin>)+130]");
										bool flag13 = num5 < 0;
										obj = 0;
										if (!flag13)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ r9_v9 (Il2CppMethodInfo)+C8]");
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1491 @ rcx_v85 (Il2CppStaticFields<SaveManager>)+FFFFFFF8+v440 @ rcx_v12 (Il2CppStaticFields<SaveManager>)*8]");
											bool flag14 = 0 != (nint)typeof(ItemPumpkin);
											obj = 0;
											num2 = num6;
											if (!flag14)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180439050");
												object obj2 = default(object);
												obj = obj2;
												num2 = (nint)item;
											}
										}
									}
									goto IL_0da9;
								}
							}
							goto IL_0d77;
						}
					}
					goto IL_0da9;
				}
			}
		}
		goto IL_0d77;
		IL_0c36:
		List<GameObject> list;
		if (list != null)
		{
			if (list._size <= 0)
			{
				return;
			}
			int num7 = index + 1;
			index = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text4 = $"RandomObjectsParent{arg}";
			GameObject gameObject = new GameObject(text4);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			GameObject gameObject2 = default(GameObject);
			while (true)
			{
				if (enumerator.MoveNext())
				{
					if ((object)gameObject2 != null)
					{
						Transform transform = gameObject2.transform;
						if ((object)gameObject != null)
						{
							Transform parentInternal = gameObject.transform;
							if ((object)transform == null)
							{
								break;
							}
							transform.parentInternal = parentInternal;
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				((List<GameObject>.Enumerator*)(&enumerator))->Dispose();
				StaticBatchingUtility.Combine(gameObject);
				return;
			}
			throw new NullReferenceException();
		}
		goto IL_0d77;
		IL_0d77:
		throw new NullReferenceException();
		IL_0da9:
		GameObject[] prefabs4 = randomObject.prefabs;
		if (randomObject.prefabs != null)
		{
			bool flag15 = (object)prefabs4[0] == null;
			num2 = (nint)prefabs4[0];
			if (!flag15)
			{
				string text5 = prefabs4[0].name;
				bool flag16 = text5 == "PotBig";
				bool flag17 = !flag16;
				nint num8 = unchecked((nint)null);
				if (!flag17)
				{
					bool flag18 = MapController.HasPlayerInventory();
					bool flag19 = !flag18;
					num8 = unchecked((nint)null);
					if (!flag19)
					{
						PlayerInventory playerInventory2 = MapController.GetPlayerInventory(null);
						bool flag20 = playerInventory2 == null;
						num2 = unchecked((nint)null);
						if (!flag20)
						{
							bool flag21 = playerInventory2.itemInventory == null;
							num2 = (nint)playerInventory2.itemInventory;
							if (!flag21)
							{
								ItemBase item2 = playerInventory2.itemInventory.GetItem(EItem.Pumpkin);
								bool flag22 = item2 == null;
								num8 = unchecked((nint)null);
								if (!flag22)
								{
									nint num3 = (nint)item2;
									nint num9 = (nint)typeof(ItemPumpkin);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ r8_v42 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPumpkin>)+130]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ r9_v9 (Il2CppMethodInfo)+130]");
									nint num10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ r8_v42 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPumpkin>)+130]");
									bool flag23 = num10 < 0;
									num8 = (nint)typeof(ItemPumpkin);
									if (!flag23)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ r9_v9 (Il2CppMethodInfo)+C8]");
										object obj4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1623 @ rcx_v77+FFFFFFF8+v1622 @ rcx_v76*8]");
										bool flag24 = 0 != (nint)typeof(ItemPumpkin);
										num8 = (nint)typeof(ItemPumpkin);
										if (!flag24)
										{
											int extraPotsBig = ((ItemPumpkin)item2).GetExtraPotsBig();
											obj += extraPotsBig;
											num8 = (nint)typeof(ItemPumpkin);
										}
									}
								}
								goto IL_0dd8;
							}
						}
						goto IL_0d77;
					}
				}
				goto IL_0dd8;
			}
		}
		goto IL_0d77;
		IL_0dd8:
		int amount = randomObject.GetAmount();
		float num12 = default(float);
		float num11 = (float)amount * num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		object obj6 = default(object);
		object obj5 = obj6 + obj;
		list = new List<GameObject>();
		list._002Ector();
		bool flag25 = (nint)obj5 <= 0;
		num2 = (nint)list;
		if (flag25)
		{
			goto IL_0c36;
		}
		float maxInclusive = 360f;
		object obj7 = 0;
		float num14 = default(float);
		Vector3 vector = default(Vector3);
		int layerMask = default(int);
		ref Vector3 normal = default(ref Vector3);
		int attempts = default(int);
		bool onlyUseGroundLayer = default(bool);
		bool debug = default(bool);
		object obj8 = default(object);
		float num23 = default(float);
		float num24 = default(float);
		float num31 = default(float);
		object obj9 = default(object);
		object obj10 = default(object);
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		float num35 = default(float);
		float num37 = default(float);
		while (true)
		{
			float num13 = UnityEngine.Random.Range(randomObject.scaleMin, randomObject.scaleMax);
			num2 = (nint)GameManager.Instance;
			if ((object)GameManager.Instance == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			float checkRadius = randomObject.checkRadius * num13;
			Vector3 objectSpawnPosition = SpawnPositions.GetObjectSpawnPosition((Vector3)(&num14), (Vector3)(&vector), checkRadius, layerMask, out normal, attempts, onlyUseGroundLayer, debug, (byte)(&obj8) != 0, 50f, 1f);
			nint num15 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ rax_v61 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num16 = 0;
			float num17 = randomObject.upOffset;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rcx_v46 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num18 = num17 * 0f;
			float num19 = randomObject.upOffset;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rcx_v46 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num20 = num19 * 0f;
			num12 = num13 * num18;
			float num21 = num13 * num20;
			GameObject[] prefabs5 = randomObject.prefabs;
			bool flag26 = randomObject.prefabs == null;
			num2 = num16;
			if (flag26)
			{
				break;
			}
			int num22 = UnityEngine.Random.Range(0, prefabs5.Length);
			bool flag27 = (object)prefabs5[num22] == null;
			num2 = unchecked((nint)null);
			if (flag27)
			{
				break;
			}
			Transform transform2 = prefabs5[num22].transform;
			bool flag28 = (object)transform2 == null;
			num2 = (nint)prefabs5[num22];
			if (flag28)
			{
				break;
			}
			Quaternion rotation = transform2.rotation;
			GameObject gameObject3 = UnityEngine.Object.Instantiate(prefabs5[num22], (Vector3)(&num23), (Quaternion)(&num24));
			bool flag29 = (object)gameObject3 == null;
			num2 = (nint)prefabs5[num22];
			if (flag29)
			{
				break;
			}
			if (!randomObject.alignWithNormal)
			{
				Transform transform3 = gameObject3.transform;
				Transform transform4 = gameObject3.transform;
				bool flag30 = (object)transform4 == null;
				num2 = (nint)gameObject3;
				if (flag30)
				{
					break;
				}
				Vector3 eulerAngles = transform4.eulerAngles;
				float num25 = UnityEngine.Random.Range(0f, maxInclusive);
				float num26 = UnityEngine.Random.Range(0f, 360f);
				float num27 = UnityEngine.Random.Range(0f, 360f);
				float num28 = num25 * (float)randomObject.randomRotationVector;
				float num29 = num28 + eulerAngles.x;
				float num30 = num29 * ((float)Math.PI / 180f);
				Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num31));
				bool flag31 = (object)transform3 == null;
				num2 = (nint)(&obj9);
				if (flag31)
				{
					break;
				}
				transform3.rotation = (Quaternion)(&num24);
				num31 = num30;
				maxInclusive = 360f;
				nint num3 = 0;
			}
			else
			{
				Transform transform5 = gameObject3.transform;
				Quaternion quaternion2 = Quaternion.LookRotation((Vector3)(&obj10));
				bool flag32 = (object)transform5 == null;
				num2 = (nint)(&enumerator2);
				if (flag32)
				{
					break;
				}
				transform5.rotation = (Quaternion)(&num24);
				float num32 = UnityEngine.Random.Range(0f, maxInclusive);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [randomObject @ rdx (Assets.Scripts.Game.MapGeneration.RandomMapObject)+3C]");
				float maxInclusive2 = 0f * 180f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [randomObject @ rdx (Assets.Scripts.Game.MapGeneration.RandomMapObject)+3C]");
				float minInclusive = 0f * -180f;
				float num33 = UnityEngine.Random.Range(minInclusive, maxInclusive2);
				float num34 = UnityEngine.Random.Range(0f, maxInclusive);
				Transform transform6 = gameObject3.transform;
				bool flag33 = (object)transform6 == null;
				num2 = (nint)gameObject3;
				if (flag33)
				{
					break;
				}
				transform6.Rotate((Vector3)(&num35), Space.Self);
				obj10 = obj8;
				nint num3 = unchecked((nint)null);
			}
			Transform transform7 = gameObject3.transform;
			bool flag34 = (object)transform7 == null;
			num2 = (nint)gameObject3;
			if (flag34)
			{
				break;
			}
			Vector3 localScale = transform7.localScale;
			float num36 = num13 * localScale.z;
			num11 = num13 * localScale.y;
			transform7.localScale = (Vector3)(&num37);
			bool isStatic = gameObject3.isStatic;
			bool flag35 = !isStatic;
			nint num8 = unchecked((nint)null);
			num2 = (nint)gameObject3;
			if (!flag35)
			{
				bool flag36 = list == null;
				num2 = (nint)gameObject3;
				if (flag36)
				{
					break;
				}
				list.Add(gameObject3);
				num8 = 0;
				num2 = (nint)list;
			}
			obj7++;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
			{
				continue;
			}
			goto IL_0c36;
		}
		goto IL_0d77;
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_000a: Expected O, but got Ref
		//IL_0017: Expected O, but got Ref
		//IL_0017: Expected O, but got Ref
		object obj = default(object);
		Gizmos.color = (Color)(&obj);
		object obj2 = default(object);
		Gizmos.DrawWireCube((Vector3)(&obj), (Vector3)(&obj2));
	}
}
