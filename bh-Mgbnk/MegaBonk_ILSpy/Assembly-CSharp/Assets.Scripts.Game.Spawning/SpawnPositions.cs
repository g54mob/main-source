using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.MapGeneration;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Spawning;

public static class SpawnPositions
{
	public static Vector3 INVALID_POS;

	private static RaycastHit[] spherecastBuffer;

	private static float nextFindBoundsTime;

	private static float minX;

	private static float minZ;

	private static float maxX;

	private static float maxZ;

	private static List<RaycastHit> myRaycastAllBuffer;

	private static RaycastHit[] myRaycastAllArrayBuffer;

	private static string layerNoSpawnArea;

	private static string layerCameraIgnore;

	private static string layerWater;

	private static string layerObject;

	private static string layerGround;

	private static string tagIgnore;

	public unsafe static Vector3 GetEnemySpawnPosition(EnemyData enemyData, int attempts = 50, bool useDirectionBias = true, float maxDistance = 3.4028235E+38f)
	{
		//IL_005d: Expected native int or pointer, but got O
		//IL_006f: Expected native int or pointer, but got O
		//IL_0032: Expected F4, but got I4
		if ((object)MyPlayer.Instance != null)
		{
			float spawnDirectionBias = MyPlayer.Instance.GetSpawnDirectionBias();
			float playerDirectionBias = spawnDirectionBias;
			if (!useDirectionBias)
			{
				playerDirectionBias = 0f;
			}
			float maxDistance2 = default(float);
			Vector3 enemySpawnPositionBiased = GetEnemySpawnPositionBiased(enemyData, playerDirectionBias, attempts, maxDistance2);
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = enemySpawnPositionBiased.x;
			((Vector3*)(nint)vector)->z = enemySpawnPositionBiased.z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Vector3 GetPositionAroundPlayer(float maxDistance)
	{
		//IL_002a: Expected native int or pointer, but got O
		//IL_003c: Expected native int or pointer, but got O
		float maxDistance2 = default(float);
		Vector3 enemySpawnPositionBiased = GetEnemySpawnPositionBiased(null, 0f, 50, maxDistance2);
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = enemySpawnPositionBiased.x;
		((Vector3*)(nint)vector)->z = enemySpawnPositionBiased.z;
		return vector;
	}

	public unsafe static Vector3 GetEnemySpawnPositionTest(EnemyData enemyData, int attempts = 50)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0265: Expected I, but got O
		//IL_0064: Expected O, but got I4
		//IL_023d: Expected F4, but got O
		//IL_0238: Expected native int or pointer, but got O
		//IL_0252: Expected F4, but got I
		//IL_024d: Expected native int or pointer, but got O
		//IL_02c2: Expected O, but got Ref
		//IL_0306: Expected O, but got Ref
		//IL_009e: Expected O, but got Ref
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_0135: Expected F4, but got I
		//IL_0150: Expected O, but got Ref
		//IL_0220: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		MyPlayer instance = MyPlayer.Instance;
		PlayerMovement playerMovement = instance.playerMovement;
		_ = playerMovement.rb.position.z;
		if (attempts > 0)
		{
			object obj3 = 0;
			float x = default(float);
			int layerMask = default(int);
			while (true)
			{
				Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
				Vector3 vector = VectorExtensions.XZVector((Vector3)(&x));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				float num = UnityEngine.Random.Range(10f, 30f);
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				GameManager instance2 = GameManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				Ray ray = (Ray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
				int num2 = Physics.SphereCastNonAlloc(ray, 0.5f, spherecastBuffer, 9999f, layerMask);
				bool flag = num2 <= 0;
				float num3 = 0.5f;
				if (!flag)
				{
					RaycastHit[] array = spherecastBuffer;
					if (array.Length <= 0)
					{
						return (Vector3)new IndexOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v26 (UnityEngine.RaycastHit[])+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v26 (UnityEngine.RaycastHit[])+30]");
					num3 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v26 (UnityEngine.RaycastHit[])+30]");
					_ = 0;
					RaycastHit raycastHit = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v26 (UnityEngine.RaycastHit[])+3C]");
					_ = 0;
					Collider collider = ((RaycastHit*)raycastHit)->collider;
					GameObject gameObject = collider.gameObject;
					int layer = gameObject.layer;
					int num4 = LayerMask.NameToLayer(layerGround);
					if (layer == num4)
					{
						break;
					}
				}
				obj3++;
				if ((nint)obj3 < attempts)
				{
					Vector3 downVector = Vector3.downVector;
					float x2 = vector.x;
					x = insideUnitSphere.x;
					continue;
				}
				goto IL_0257;
			}
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			goto IL_022f;
		}
		goto IL_0257;
		IL_022f:
		Vector3 vector2 = default(Vector3);
		((Vector3*)(nint)vector2)->x = (float)INVALID_POS;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v18 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
		((Vector3*)(nint)vector2)->z = 0f;
		return vector2;
		IL_0257:
		nint num5 = (nint)typeof(SpawnPositions);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ rax_v14 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
		nint num6 = 0;
		goto IL_022f;
	}

	private unsafe static void GetSpawnDistances(out float min, out float max)
	{
		//IL_0068: Expected Ref, but got F4
		//IL_0070: Expected Ref, but got F4
		float num = MyTime.runTimer / 60f;
		float num2 = num * 0.04f;
		float num3 = num2 + 1f;
		bool flag = 1f > num3;
		float num4 = 1f;
		if (!flag)
		{
			bool flag2 = !(num3 > 2f);
			num4 = 2f;
			if (flag2)
			{
				goto IL_0040;
			}
		}
		num3 = num4;
		goto IL_0040;
		IL_0040:
		float num5 = num3 * 40f;
		float num6 = num3 * 20f;
		ref float reference = ref *(float*)num6;
		ref float reference2 = ref *(float*)num5;
	}

	private static void FindBounds()
	{
		//IL_0185: Expected I, but got O
		//IL_021c: Expected I, but got O
		GameManager instance = GameManager.Instance;
		if (!instance._003CisCrypt_003Ek__BackingField)
		{
			if (RsgController.Instance != null)
			{
				RsgController instance2 = RsgController.Instance;
				GameObject gameObject = instance2.roomBoss.gameObject;
				if (gameObject.activeInHierarchy)
				{
					goto IL_02ff;
				}
			}
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			float num = (float)MapInfo.mapBoundsUpper - 2f;
			float num2 = position.x - 25f;
			if (num < num2)
			{
				num = num2;
			}
			maxX = num;
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position2 = transform2.position;
			float num3 = (float)MapInfo.mapBoundsLower + 2f;
			float num4 = position2.x + 25f;
			if (num3 > num4)
			{
				num3 = num4;
			}
			minX = num3;
			nint num5 = (nint)typeof(MapInfo);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v39 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
			nint num6 = 0;
			Transform transform3 = MyPlayer.Instance.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rdx_v11 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+14]");
			float num7 = 0f - 2f;
			float num8 = transform3.position.z - 25f;
			if (num7 < num8)
			{
				num7 = num8;
			}
			maxZ = num7;
			nint num9 = (nint)typeof(MapInfo);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ rax_v44 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
			nint num10 = 0;
			Transform transform4 = MyPlayer.Instance.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rdx_v14 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+8]");
			float num11 = 0f + 2f;
			float num12 = transform4.position.z + 25f;
			if (num11 > num12)
			{
				num11 = num12;
			}
			minZ = num11;
			return;
		}
		goto IL_02ff;
		IL_02ff:
		maxX = 9999f;
		minX = -9999f;
		maxZ = 9999f;
		minZ = -9999f;
	}

	private unsafe static Vector3 GetEnemySpawnPositionBiased(EnemyData enemyData, float playerDirectionBias, int attempts = 50, float maxDistance = 3.4028235E+38f)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_008e: Invalid comparison between I4 and F4
		//IL_00de: Expected F4, but got I4
		//IL_07bf: Invalid comparison between I and F4
		//IL_0182: Invalid comparison between I and F4
		//IL_0812: Invalid comparison between I and F4
		//IL_01a6: Expected F4, but got I
		//IL_02e6: Expected F4, but got I
		//IL_02ee: Expected F4, but got O
		//IL_0846: Expected I, but got O
		//IL_087c: Expected O, but got I
		//IL_0906: Expected F4, but got I
		//IL_090e: Expected O, but got Ref
		//IL_0c9c: Expected O, but got I4
		//IL_0cb1: Expected F4, but got O
		//IL_072f: Expected I, but got O
		//IL_092a: Expected I, but got O
		//IL_075f: Expected F4, but got O
		//IL_075a: Expected native int or pointer, but got O
		//IL_0774: Expected F4, but got I
		//IL_076f: Expected native int or pointer, but got O
		//IL_0412: Invalid comparison between I4 and F4
		//IL_0384: Expected F8, but got I4
		//IL_0aab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab0: Expected O, but got Unknown
		//IL_0acb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad0: Expected O, but got Unknown
		//IL_0aef: Expected F4, but got I
		//IL_0b06: Expected I, but got O
		//IL_047a: Invalid comparison between I4 and F4
		//IL_093d: Expected I, but got O
		//IL_0956: Expected F4, but got O
		//IL_0966: Expected F8, but got I
		//IL_0976: Expected F4, but got I
		//IL_04cd: Expected F4, but got I4
		//IL_09d6: Expected I, but got O
		//IL_09df: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e4: Expected O, but got Unknown
		//IL_0a23: Expected O, but got Ref
		//IL_0a30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a35: Expected O, but got Unknown
		//IL_0a3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a43: Expected O, but got Unknown
		//IL_0a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6c: Expected O, but got Unknown
		//IL_0a75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Expected O, but got Unknown
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_0619: Expected O, but got Unknown
		//IL_0642: Expected O, but got Ref
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Expected Ref, but got Unknown
		//IL_0689: Expected F4, but got I
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Expected O, but got Unknown
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d6: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 360;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		if (MyTime.time > nextFindBoundsTime)
		{
			float num = MyTime.time + 0.1f;
			nextFindBoundsTime = num;
			FindBounds();
		}
		float num2;
		if (!(0f > playerDirectionBias))
		{
			bool flag = playerDirectionBias > 0.96f;
			num2 = 0.96f;
			if (!flag)
			{
				num2 = playerDirectionBias;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = MyTime.runTimer / 60f;
		float num4 = num3 * 0.04f;
		float num5 = num4 + 1f;
		if (!(1f > num5))
		{
			if (num5 > 2f)
			{
				num5 = 2f;
			}
		}
		else
		{
			num5 = 1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+190]");
		bool flag2 = 0f == 3.4028235E+38f;
		float num6 = num5 * 20f;
		float num7 = num5 * 40f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804825CCh\"");
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+190]");
			if (!(0f > num7))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+190]");
				num7 = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+190]");
			if (!(0f > num6))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+190]");
				_ = 0;
			}
		}
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerMovement playerMovement = instance.playerMovement;
			if ((object)instance.playerMovement != null && (object)playerMovement.rb != null)
			{
				Vector3 position = playerMovement.rb.position;
				Vector3 velocity = playerMovement.rb.velocity;
				float num8 = Enemy.defaultTeleportTime * velocity.x;
				float num9 = num8 + position.x;
				float num10 = Enemy.defaultTeleportTime * velocity.y;
				float num11 = Enemy.defaultTeleportTime * velocity.z;
				float num12 = num10 + position.y;
				float num13 = num11 + position.z;
				MyPlayer instance2 = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rax_v31+8]");
					float num14 = 0f;
					object obj3 = default(object);
					float num15 = (float)obj3;
					nint num16 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v33 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num17 = 0;
					float num18 = (float)obj3 - (float)Vector3.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rcx_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
					object obj4 = -0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rax_v31+8]");
					float num19 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rcx_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					float num20 = num19 - 0f;
					object obj5 = obj4 * obj4;
					float num21 = num20 * num20;
					float num22 = num18 * num18;
					float num23 = (float)obj5 + num22;
					float num24 = num23 + num21;
					bool flag3 = !(9.9999994E-11f > num24);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rax_v31+8]");
					float num25 = 0f;
					float num26 = default(float);
					RaycastHit[] array = (RaycastHit[])(&num26);
					if (!flag3)
					{
						Vector3 onUnitSphere = UnityEngine.Random.onUnitSphere;
						nint num27 = (nint)typeof(Math);
						float num28 = onUnitSphere.x * onUnitSphere.x;
						float num29 = onUnitSphere.z * onUnitSphere.z;
						num22 = num28 + num29;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm2\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rcx_v74 (Il2CppClass<System.Math>)+E4]");
						double num30;
						if ((nint)0 <= (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm2\"");
							num30 = 0.0;
						}
						else
						{
							num30 = Math.Sqrt(num22);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
						if (num30 > 9.999999747378752E-06)
						{
							num15 = onUnitSphere.x / (float)num30;
							double num31 = 0.0 / num30;
							num14 = onUnitSphere.z / (float)num30;
						}
						else
						{
							nint num32 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1214 @ rax_v109 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num33 = 0;
							num15 = (float)Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rcx_v77 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
							double num31 = 0.0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rcx_v77 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
							num14 = 0f;
						}
						num24 = num22;
						num25 = num14;
						array = null;
					}
					bool flag4 = attempts <= 0;
					object obj6 = 0;
					int num34 = attempts;
					num26 = (float)instance2.averageMovingDirection;
					ref bool reference = ref *(bool*)null;
					if (flag4)
					{
						goto IL_0721;
					}
					float num36 = default(float);
					float num47 = default(float);
					Vector3 onUnitSphere2 = default(Vector3);
					object obj10 = default(object);
					Vector3 downVector = default(Vector3);
					int layerMask = default(int);
					int maxHits = default(int);
					while (true)
					{
						float num37;
						float num35;
						if (0f < num2)
						{
							if (!(num2 < 1f))
							{
								num35 = num36;
								num37 = num14;
								goto IL_0a9d;
							}
							float value = UnityEngine.Random.value;
							float num38 = num2 * 10f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
							float num39;
							if (!(0f > value))
							{
								bool flag5 = !(value > 1f);
								num39 = value;
								if (!flag5)
								{
									num39 = 1f;
								}
							}
							else
							{
								num39 = 0f;
							}
							float num40 = num39 * -2f;
							float num41 = num40 + 1f;
							float num42 = UnityEngine.Random.Range(0f, (float)Math.PI * 2f);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301200");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE090");
							float num43 = num42 * num41;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
							float num44 = num42 * num41;
							nint num45 = (nint)typeof(Vector3);
							Vector3 fromDirection = (Vector3)(obj - 96);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rax_v95 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num46 = 0;
							_ = Vector3.forwardVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1428 @ rax_v96 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
							_ = 0;
							Quaternion quaternion = Quaternion.FromToRotation(fromDirection, (Vector3)(&num47));
							Vector3 vector = (Vector3)(obj - 128);
							Quaternion quaternion2 = (Quaternion)(obj + 16);
							_ = quaternion.x;
							Vector3 vector2 = quaternion2 * vector;
							object obj7 = obj - 80;
							object obj8 = obj + 48;
							_ = vector2.x;
							_ = vector2.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
							num47 = num15;
							num34 = 0;
							num22 = (float)Math.PI * 2f;
						}
						else
						{
							onUnitSphere2 = UnityEngine.Random.onUnitSphere;
						}
						num37 = onUnitSphere2.z;
						num35 = onUnitSphere2.x;
						goto IL_0a9d;
						IL_0a9d:
						Vector3 v = (Vector3)(obj - 64);
						Vector3 vector3 = VectorExtensions.XZVector(v);
						object obj9 = obj - 48;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+170]");
						float num48 = UnityEngine.Random.Range(0f, num7);
						float num49 = (float)obj10 * num48;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1209 @ rax_v49+4]");
						float num50 = 0f * num48;
						float num51 = num49 + num9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1209 @ rax_v49+8]");
						float num52 = 0f * num48;
						float num53 = num50 + num12;
						float num54 = num52 + num13;
						nint num55 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ rax_v51 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num56 = 0;
						float num57 = (float)Vector3.upVector * 999f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1279 @ rcx_v34 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
						float num58 = 0f * 999f;
						float num59 = num57 + num51;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1279 @ rcx_v34 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						float num60 = 0f * 999f;
						float num61 = num58 + num53;
						float num62 = num60 + num54;
						if (!(num59 > maxX))
						{
							if (minX > num59)
							{
								num59 = minX;
							}
						}
						else
						{
							num59 = maxX;
						}
						if (!(num62 > maxZ))
						{
							if (minZ > num62)
							{
								num62 = minZ;
							}
						}
						else
						{
							num62 = maxZ;
						}
						GameManager instance3 = GameManager.Instance;
						if ((object)GameManager.Instance == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
						Vector3 origin = (Vector3)(obj - 112);
						RaycastHit[] array2 = MyRaycastAll(origin, (Vector3)(&downVector), layerMask, 9999f, maxHits);
						RaycastHit raycastHit = FindHitClosestToPlayerY(array2, out *(bool*)(obj + 384), canChooseObject: false);
						_ = raycastHit.m_Point;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v913 @ rax_v63 (UnityEngine.RaycastHit)+10]");
						num22 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v913 @ rax_v63 (UnityEngine.RaycastHit)+10]");
						_ = 0;
						_ = raycastHit.m_Distance;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+180]");
						if ((nint)0 == 0)
						{
							obj6++;
							bool flag6 = (nint)obj6 < attempts;
							downVector = Vector3.downVector;
							num34 = 0;
							num14 = num25;
							num26 = vector3.x;
							array = array2;
							if (flag6)
							{
								continue;
							}
							goto IL_0721;
						}
						goto IL_0734;
					}
				}
			}
		}
		return (Vector3)new NullReferenceException();
		IL_0751:
		Vector3 vector4 = default(Vector3);
		((Vector3*)(nint)vector4)->x = (float)INVALID_POS;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ rax_v35 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
		((Vector3*)(nint)vector4)->z = 0f;
		return vector4;
		IL_0721:
		nint num63 = (nint)typeof(SpawnPositions);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v40 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
		nint num64 = 0;
		goto IL_0751;
		IL_0734:
		object obj11 = obj - 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
		goto IL_0751;
	}

	private unsafe static RaycastHit[] MyRaycastAll(Vector3 origin, Vector3 dir, int layerMask, float maxDistance = 9999f, int maxHits = 10)
	{
		//IL_0008: Expected O, but got Ref
		//IL_002f: Expected O, but got I4
		//IL_005c: Expected O, but got Ref
		//IL_005c: Expected O, but got Ref
		//IL_008e: Expected O, but got I
		//IL_012c: Expected O, but got I
		//IL_00ec: Expected O, but got Ref
		//IL_0176: Expected O, but got I
		//IL_02a6: Expected native int or pointer, but got O
		//IL_02c8: Expected native int or pointer, but got O
		//IL_02f5: Expected native int or pointer, but got O
		//IL_01e1: Invalid comparison between O and F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		List<RaycastHit> list = myRaycastAllBuffer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v3 (System.Collections.Generic.List`1<UnityEngine.RaycastHit>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		object obj3 = 0;
		float x = default(float);
		float x2 = default(float);
		int layerMask2 = default(int);
		object obj7 = default(object);
		object obj8 = default(object);
		while (true)
		{
			float maxDistance2 = maxDistance - (float)obj3;
			if (Physics.Raycast((Vector3)(&x), (Vector3)(&x2), out var _, maxDistance2, layerMask2))
			{
				List<RaycastHit> list2 = myRaycastAllBuffer;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v20 (System.Collections.Generic.List`1<UnityEngine.RaycastHit>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v20 (System.Collections.Generic.List`1<UnityEngine.RaycastHit>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v20 (System.Collections.Generic.List`1<UnityEngine.RaycastHit>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v10+18]");
				if (num >= 0)
				{
					RaycastHit item = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
					_ = 0;
					_ = 0;
					list2.AddWithResize(item);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v20 (System.Collections.Generic.List`1<UnityEngine.RaycastHit>)+18]");
					object obj5 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v20 (System.Collections.Generic.List`1<UnityEngine.RaycastHit>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v10+18]");
					if (num2 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v20 (System.Collections.Generic.List`1<UnityEngine.RaycastHit>)+18]");
					object obj6 = (nint)0 * (nint)44;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
					_ = 0;
					_ = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
				float num3 = dir.x * 0.01f;
				float num4 = dir.y * 0.01f;
				float x3 = num3 + (float)obj7;
				float num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v28+4]");
				float y = num5 + 0f;
				((Vector3*)(nint)origin)->x = x3;
				float num6 = dir.z * 0.01f;
				((Vector3*)(nint)origin)->y = y;
				float num7 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v28+8]");
				float z = num7 + 0f;
				List<RaycastHit> list3 = myRaycastAllBuffer;
				((Vector3*)(nint)origin)->z = z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v13 (System.Collections.Generic.List`1<UnityEngine.RaycastHit>)+18]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
				if (num8 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C560");
					obj3 += obj8;
					bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)maxDistance);
					x = origin.x;
					x2 = dir.x;
					if (flag)
					{
						continue;
					}
				}
			}
			RaycastHit[] array = myRaycastAllBuffer.ToArray();
			myRaycastAllArrayBuffer = array;
			return myRaycastAllArrayBuffer;
		}
		return (RaycastHit[])(object)new IndexOutOfRangeException();
	}

	public unsafe static Vector3 GetEnemySpawnPositionAroundPoint(Vector3 pos, float minRadius, float maxRadius, int attempts = 50, bool onlyGround = false, float fromHeight = 999f)
	{
		//IL_015f: Expected I, but got O
		//IL_000e: Expected O, but got I4
		//IL_0239: Expected F4, but got O
		//IL_0234: Expected native int or pointer, but got O
		//IL_024e: Expected F4, but got I
		//IL_0249: Expected native int or pointer, but got O
		//IL_020d: Expected O, but got Ref
		//IL_00a2: Expected O, but got Ref
		//IL_00a2: Expected O, but got Ref
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		object obj = default(object);
		if ((nint)obj <= 0)
		{
			goto IL_0151;
		}
		object obj2 = 0;
		float x = default(float);
		object obj3 = default(object);
		object obj4 = default(object);
		Vector3 downVector = default(Vector3);
		float maxDistance = default(float);
		int layerMask = default(int);
		object obj5 = default(object);
		while (true)
		{
			float num = UnityEngine.Random.Range(minRadius, maxRadius);
			Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
			Vector3 vector = VectorExtensions.XZVector((Vector3)(&x));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			GameManager instance = GameManager.Instance;
			if ((object)GameManager.Instance != null)
			{
				if (obj3 == null)
				{
					LayerMask whatIsGroundAndObjects = instance.whatIsGroundAndObjects;
				}
				else
				{
					if ((object)GameManager.Instance == null)
					{
						goto IL_0173;
					}
					LayerMask whatIsGroundAndObjects = instance.whatIsGround;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				if (Physics.SphereCast((Vector3)(&obj4), 0.5f, (Vector3)(&downVector), out var hitInfo, maxDistance, layerMask))
				{
					Collider collider = hitInfo.collider;
					if ((object)collider == null)
					{
						goto IL_0173;
					}
					if (!collider.CompareTag(tagIgnore))
					{
						break;
					}
				}
				obj2++;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
				obj4 = obj5;
				downVector = Vector3.downVector;
				float x2 = vector.x;
				x = insideUnitSphere.x;
				if (flag)
				{
					continue;
				}
				goto IL_0151;
			}
			goto IL_0173;
			IL_0173:
			return (Vector3)new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
		goto IL_022b;
		IL_022b:
		Vector3 vector2 = default(Vector3);
		((Vector3*)(nint)vector2)->x = (float)INVALID_POS;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v2 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
		((Vector3*)(nint)vector2)->z = 0f;
		return vector2;
		IL_0151:
		nint num2 = (nint)typeof(SpawnPositions);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v7 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
		nint num3 = 0;
		goto IL_022b;
	}

	private unsafe static Vector3 SampleBiasedDirection(Vector3 biasedTowards, float bias)
	{
		//IL_0018: Invalid comparison between I4 and F4
		//IL_0177: Expected native int or pointer, but got O
		//IL_0189: Expected native int or pointer, but got O
		//IL_013d: Expected native int or pointer, but got O
		//IL_014f: Expected native int or pointer, but got O
		//IL_008a: Invalid comparison between I4 and F4
		//IL_00dd: Expected F4, but got I4
		//IL_01f5: Expected O, but got Ref
		//IL_01f5: Expected O, but got Ref
		//IL_0207: Expected O, but got Ref
		//IL_0207: Expected O, but got Ref
		//IL_010e: Expected F4, but got O
		//IL_0109: Expected native int or pointer, but got O
		//IL_0123: Expected F4, but got I
		//IL_011e: Expected native int or pointer, but got O
		Vector3 vector3 = default(Vector3);
		if (0f < bias)
		{
			if (bias < 1f)
			{
				float value = UnityEngine.Random.value;
				float num = bias * 10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
				float num2;
				if (!(0f > value))
				{
					bool flag = !(value > 1f);
					num2 = value;
					if (!flag)
					{
						num2 = 1f;
					}
				}
				else
				{
					num2 = 0f;
				}
				float num3 = num2 * -2f;
				float num4 = num3 + 1f;
				float num5 = UnityEngine.Random.Range(0f, (float)Math.PI * 2f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301200");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE090");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
				Vector3 vector = default(Vector3);
				float num6 = default(float);
				Quaternion quaternion = Quaternion.FromToRotation((Vector3)(&vector), (Vector3)(&num6));
				float num7 = default(float);
				Vector3 vector2 = (Quaternion)(&vector) * (Vector3)(&num7);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				object obj = default(object);
				((Vector3*)(nint)vector3)->x = (float)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v22+8]");
				((Vector3*)(nint)vector3)->z = 0f;
				return vector3;
			}
			((Vector3*)(nint)vector3)->x = biasedTowards.x;
			((Vector3*)(nint)vector3)->z = biasedTowards.z;
			return vector3;
		}
		Vector3 onUnitSphere = UnityEngine.Random.onUnitSphere;
		((Vector3*)(nint)vector3)->x = onUnitSphere.x;
		((Vector3*)(nint)vector3)->z = onUnitSphere.z;
		return vector3;
	}

	private unsafe static Vector3 GetPlayerMovementDirection()
	{
		//IL_0017: Expected F4, but got O
		//IL_0012: Expected native int or pointer, but got O
		//IL_002c: Expected F4, but got I
		//IL_0027: Expected native int or pointer, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)instance.averageMovingDirection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v5 (Assets.Scripts.Actors.Player.MyPlayer)+FC]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Vector3 GetPositionAroundPoint(Vector3 center, float minRadius, float maxRadius, float spherecastRadius, int attempts = 50)
	{
		//IL_01b5: Expected native int or pointer, but got O
		//IL_01c2: Expected native int or pointer, but got O
		//IL_000e: Expected O, but got I4
		//IL_019a: Expected O, but got Ref
		//IL_0080: Expected O, but got Ref
		//IL_0105: Expected F4, but got O
		//IL_010e: Expected F4, but got I4
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		object obj = default(object);
		if ((nint)obj <= 0)
		{
			goto IL_00de;
		}
		object obj2 = 0;
		float x = default(float);
		object obj3 = default(object);
		float num6 = default(float);
		float checkRadius = default(float);
		int layerMask = default(int);
		Vector3 hitPoint;
		ref Vector3 normal = default(ref Vector3);
		bool onlyUseGroundLayer = default(bool);
		bool canSpawnInWater = default(bool);
		float maxSlopeAngle = default(float);
		while (true)
		{
			Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
			Vector3 vector = VectorExtensions.XZVector((Vector3)(&x));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			float num = UnityEngine.Random.Range(minRadius, maxRadius);
			float num2 = (float)obj3 * num;
			float num3 = num2 + center.x;
			float num4 = (float)Vector3.upVector * 999f;
			float num5 = num4 + num3;
			GameManager instance = GameManager.Instance;
			if ((object)GameManager.Instance != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				if (TryGetPosition((Vector3)(&num6), checkRadius, layerMask, out hitPoint, out normal, onlyUseGroundLayer, canSpawnInWater, maxSlopeAngle))
				{
					break;
				}
				obj2++;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
				num6 = num5;
				float x2 = vector.x;
				x = insideUnitSphere.x;
				if (flag)
				{
					continue;
				}
				goto IL_00de;
			}
			return (Vector3)new NullReferenceException();
		}
		float x3 = (float)hitPoint;
		float z = 0f;
		goto IL_01ad;
		IL_00de:
		x3 = center.x;
		z = center.z;
		goto IL_01ad;
		IL_01ad:
		Vector3 vector2 = default(Vector3);
		((Vector3*)(nint)vector2)->x = x3;
		((Vector3*)(nint)vector2)->z = z;
		return vector2;
	}

	public unsafe static Vector3 GetObjectSpawnPosition(Vector3 center, Vector3 size, float checkRadius, int layerMask, out Vector3 normal, int attempts = 50, bool onlyUseGroundLayer = true, bool debug = false, bool canSpawnInWater = false, float maxSlopeAngle = 44f, float extraRayFromHeight = 0f)
	{
		//IL_0759: Expected I, but got O
		//IL_0779: Expected O, but got I
		//IL_079d: Expected I, but got O
		//IL_0048: Expected O, but got I4
		//IL_07b0: Expected F4, but got O
		//IL_07ab: Expected native int or pointer, but got O
		//IL_07c5: Expected F4, but got I
		//IL_07c0: Expected native int or pointer, but got O
		//IL_046c: Expected I, but got O
		//IL_0499: Expected O, but got I
		//IL_04b6: Expected O, but got I
		//IL_07d9: Expected O, but got Ref
		//IL_050a: Expected I, but got O
		//IL_013d: Expected O, but got Ref
		//IL_007f: Expected O, but got Ref
		//IL_007f: Expected O, but got Ref
		//IL_00a6: Expected O, but got I
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Expected O, but got Unknown
		//IL_01bc: Expected O, but got Ref
		//IL_0211: Expected O, but got Ref
		//IL_0569: Expected O, but got I
		//IL_0592: Expected O, but got I
		//IL_026a: Expected O, but got Ref
		//IL_0636: Expected I, but got O
		//IL_0644: Expected O, but got Ref
		//IL_0672: Expected O, but got Ref
		//IL_068d: Expected O, but got Ref
		//IL_02e8: Expected O, but got Ref
		//IL_03b0: Expected O, but got Ref
		//IL_03c8: Expected O, but got Ref
		//IL_03d8: Expected O, but got I
		RaycastHit hitInfo = default(RaycastHit);
		ref RaycastHit reference = ref hitInfo;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		reference = ref *(RaycastHit*)null;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+140]");
		if ((nint)0 > (nint)0)
		{
			float num = size.y + 999f;
			float num2 = size.z * 0.5f;
			float num3 = checkRadius;
			object obj = 0;
			object obj4 = default(object);
			Vector3 downVector = default(Vector3);
			float num17 = default(float);
			object obj5 = default(object);
			object obj6 = default(object);
			int layerMask2 = default(int);
			object obj12 = default(object);
			while (true)
			{
				float num4 = UnityEngine.Random.Range(-1f, 1f);
				float num5 = center.y + num;
				float num6 = UnityEngine.Random.Range(-1f, 1f);
				float num7 = num6 * num2;
				float num8 = num7 + center.z;
				nint num9 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+168]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				object obj2 = num11 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+168]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				object obj3 = num12 * 0;
				float num13 = (float)obj2 + num5;
				float num14 = (float)obj3 + num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+158]");
				float num19;
				object obj7;
				float num20;
				if ((nint)0 == 0)
				{
					nint num15 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v64 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+168]");
					num3 = 0f + 9999f;
					bool flag = Physics.Raycast((Vector3)(&obj4), (Vector3)(&downVector), out hitInfo, num3);
					bool flag2 = !flag;
					num17 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rcx_v50 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
					obj5 = 0;
					if (!flag2)
					{
						Collider collider = hitInfo.collider;
						if ((object)collider != null)
						{
							GameObject gameObject = collider.gameObject;
							if ((object)gameObject != null)
							{
								int layer = gameObject.layer;
								int num18 = LayerMask.NameToLayer(layerWater);
								bool flag3 = layer == num18;
								num17 = num14;
								obj4 = obj6;
								downVector = Vector3.downVector;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rcx_v50 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
								obj5 = 0;
								num19 = num14;
								obj4 = obj6;
								downVector = Vector3.downVector;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rcx_v50 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
								obj7 = 0;
								num20 = num3;
								if (flag3)
								{
									goto IL_0353;
								}
								goto IL_07ca;
							}
						}
						goto IL_0401;
					}
				}
				goto IL_07ca;
				IL_07ca:
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref hitInfo, 48));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				ref RaycastHit hitInfo2 = ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 80);
				Ray ray = (Ray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 32));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+168]");
				num20 = 0f + 9999f;
				bool flag4 = Physics.SphereCast(ray, checkRadius, out hitInfo2, num20, layerMask2);
				bool flag5 = !flag4;
				Vector3 downVector2 = Vector3.downVector;
				num19 = num17;
				obj7 = obj5;
				if (!flag5)
				{
					RaycastHit raycastHit = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 80));
					Collider collider2 = ((RaycastHit*)raycastHit)->collider;
					bool flag6 = collider2 != null;
					downVector2 = Vector3.downVector;
					num19 = num17;
					obj7 = obj5;
					if (flag6)
					{
						RaycastHit raycastHit2 = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 80));
						Collider collider3 = ((RaycastHit*)raycastHit2)->collider;
						if ((object)collider3 != null)
						{
							bool flag7 = collider3.CompareTag(tagIgnore);
							downVector2 = Vector3.downVector;
							num19 = num17;
							obj7 = obj5;
							if (flag7)
							{
								goto IL_0353;
							}
							RaycastHit raycastHit3 = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 80));
							Collider collider4 = ((RaycastHit*)raycastHit3)->collider;
							if ((object)collider4 != null)
							{
								bool flag8 = collider4.CompareTag(layerNoSpawnArea);
								downVector2 = Vector3.downVector;
								num19 = num17;
								obj7 = obj5;
								if (flag8)
								{
									goto IL_0353;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+148]");
								if ((nint)0 == 0)
								{
									goto IL_0628;
								}
								RaycastHit raycastHit4 = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 80));
								Collider collider5 = ((RaycastHit*)raycastHit4)->collider;
								if ((object)collider5 != null)
								{
									GameObject gameObject2 = collider5.gameObject;
									if ((object)gameObject2 != null)
									{
										int layer2 = gameObject2.layer;
										int num21 = LayerMask.NameToLayer(layerGround);
										bool flag9 = layer2 != num21;
										downVector2 = Vector3.downVector;
										num19 = num17;
										obj7 = obj5;
										if (flag9)
										{
											goto IL_0353;
										}
										goto IL_0628;
									}
								}
							}
						}
						goto IL_0401;
					}
				}
				goto IL_0353;
				IL_0628:
				nint num22 = (nint)typeof(Vector3);
				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 80));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v967 @ rax_v40 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				_ = Vector3.upVector;
				object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				_ = 0;
				object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 112));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v972 @ rax_v41+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+160]");
				bool flag10 = (nint)obj12 <= 0;
				downVector2 = Vector3.downVector;
				num19 = num17;
				obj7 = obj5;
				if (flag10)
				{
					break;
				}
				goto IL_0353;
				IL_0401:
				return (Vector3)new NullReferenceException();
				IL_0353:
				obj++;
				object obj13 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+140]");
				bool flag11 = (nint)obj13 < 0;
				num17 = num19;
				obj5 = obj7;
				num3 = num20;
				if (flag11)
				{
					continue;
				}
				goto IL_074b;
			}
			object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 80));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref hitInfo, 80));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+138]");
			object obj16 = 0;
			object obj17 = default(object);
			obj16 = obj17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v44+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			goto IL_07a2;
		}
		goto IL_074b;
		IL_07a2:
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)INVALID_POS;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v3 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
		IL_074b:
		nint num24 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.RaycastHit&)+138]");
		object obj18 = 0;
		obj18 = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num26 = (nint)typeof(SpawnPositions);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v11 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
		nint num27 = 0;
		goto IL_07a2;
	}

	private unsafe static bool TryGetPosition(Vector3 pos, float checkRadius, int layerMask, out Vector3 hitPoint, out Vector3 normal, bool onlyUseGroundLayer = true, bool canSpawnInWater = false, float maxSlopeAngle = 90f)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0490: Expected I, but got O
		//IL_04b0: Expected O, but got I
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Ref, but got Unknown
		//IL_0128: Expected O, but got Ref
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Ref, but got Unknown
		//IL_004b: Expected O, but got Ref
		//IL_004b: Expected O, but got Ref
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_0327: Expected I4, but got O
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 55;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+5F]");
		object obj3 = 0;
		obj3 = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		ref Vector3 reference = ref *(Vector3*)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+6F]");
		if ((nint)0 == 0)
		{
			float x = default(float);
			Vector3 downVector = default(Vector3);
			bool flag = Physics.Raycast((Vector3)(&x), (Vector3)(&downVector), out *(RaycastHit*)(obj - 57), 9999f);
			bool flag2 = !flag;
			downVector = Vector3.downVector;
			x = pos.x;
			float num3 = 9999f;
			if (!flag2)
			{
				RaycastHit raycastHit = (RaycastHit)(obj - 57);
				Collider collider = ((RaycastHit*)raycastHit)->collider;
				if ((object)collider != null)
				{
					GameObject gameObject = collider.gameObject;
					if ((object)gameObject != null)
					{
						int layer = gameObject.layer;
						int num4 = LayerMask.NameToLayer(layerWater);
						bool flag3 = layer == num4;
						downVector = Vector3.downVector;
						x = pos.x;
						num3 = 9999f;
						if (flag3)
						{
							goto IL_030b;
						}
						goto IL_039e;
					}
				}
				goto IL_0319;
			}
		}
		goto IL_039e;
		IL_039e:
		_ = 0;
		_ = pos.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v19+8]");
		_ = 0;
		Vector3 vector = default(Vector3);
		int layerMask2 = default(int);
		if (Physics.SphereCast((Ray)(&vector), checkRadius, out *(RaycastHit*)(obj - 105), 9999f, layerMask2))
		{
			RaycastHit raycastHit2 = (RaycastHit)(obj - 105);
			Collider collider2 = ((RaycastHit*)raycastHit2)->collider;
			if (collider2 != null)
			{
				RaycastHit raycastHit3 = (RaycastHit)(obj - 105);
				Collider collider3 = ((RaycastHit*)raycastHit3)->collider;
				if ((object)collider3 != null)
				{
					if (collider3.CompareTag(tagIgnore))
					{
						goto IL_030b;
					}
					RaycastHit raycastHit4 = (RaycastHit)(obj - 105);
					Collider collider4 = ((RaycastHit*)raycastHit4)->collider;
					if ((object)collider4 != null)
					{
						bool flag4 = collider4.CompareTag(layerNoSpawnArea);
						if (flag4)
						{
							goto IL_030b;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
						if ((nint)0 == (flag4 ? 1 : 0))
						{
							goto IL_0437;
						}
						RaycastHit raycastHit5 = (RaycastHit)(obj - 105);
						Collider collider5 = ((RaycastHit*)raycastHit5)->collider;
						if ((object)collider5 != null)
						{
							GameObject gameObject2 = collider5.gameObject;
							if ((object)gameObject2 != null)
							{
								int layer2 = gameObject2.layer;
								int num5 = LayerMask.NameToLayer(layerGround);
								if (layer2 != num5)
								{
									goto IL_030b;
								}
								goto IL_0437;
							}
						}
					}
				}
				goto IL_0319;
			}
		}
		goto IL_030b;
		IL_030b:
		return false;
		IL_0437:
		object obj4 = obj - 105;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
		object obj5 = default(object);
		if ((nint)obj5 <= 0)
		{
			object obj6 = obj - 105;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			object obj7 = obj - 105;
			object obj8 = default(object);
			obj3 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rax_v38+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			object obj9 = default(object);
			reference = ref *(Vector3*)obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rax_v39+8]");
			_ = 0;
			return true;
		}
		goto IL_030b;
		IL_0319:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static RaycastHit FindHitClosestToPlayerY(RaycastHit[] hits, out bool foundPosition, bool canChooseObject = true)
	{
		//IL_0348: Expected O, but got I4
		//IL_0351: Expected O, but got I4
		//IL_035a: Expected O, but got I4
		//IL_061a: Expected O, but got I4
		//IL_0615: Expected native int or pointer, but got O
		//IL_0629: Expected native int or pointer, but got O
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Expected O, but got Unknown
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Expected O, but got Unknown
		//IL_0587: Expected O, but got I
		//IL_0582: Expected native int or pointer, but got O
		//IL_05a9: Expected F4, but got I
		//IL_05a4: Expected native int or pointer, but got O
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected O, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Expected O, but got Unknown
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected O, but got Unknown
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected O, but got Unknown
		//IL_0458: Invalid comparison between I and F4
		//IL_00a1: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_0324: Expected O, but got I4
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Expected O, but got Unknown
		//IL_04d3: Expected F4, but got I
		//IL_02da: Expected O, but got I4
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected F4, but got Unknown
		ref bool reference = ref *(bool*)null;
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		object obj;
		object obj2;
		if (mapData.mapType != EMapType.ProceduralMesh && !MapController.isFinalBossStage)
		{
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			float num = 1f / 0f;
			obj = 0;
			obj2 = 0;
			for (object obj3 = 0; (nint)obj3 < hits.Length; obj++, obj3 = obj)
			{
				object obj4 = obj * 44;
				object obj5 = obj4 + 32;
				RaycastHit raycastHit = (RaycastHit)(obj5 + (object)hits);
				Collider collider = ((RaycastHit*)raycastHit)->collider;
				if (collider.CompareTag(tagIgnore))
				{
					continue;
				}
				object obj6 = obj * 44;
				object obj7 = obj6 + 32;
				RaycastHit raycastHit2 = (RaycastHit)(obj7 + (object)hits);
				Collider collider2 = ((RaycastHit*)raycastHit2)->collider;
				if (collider2.CompareTag(layerCameraIgnore))
				{
					continue;
				}
				object obj8 = obj * 44;
				object obj9 = obj8 + 32;
				RaycastHit raycastHit3 = (RaycastHit)(obj9 + (object)hits);
				Collider collider3 = ((RaycastHit*)raycastHit3)->collider;
				GameObject gameObject = collider3.gameObject;
				int layer = gameObject.layer;
				int num2 = LayerMask.NameToLayer(layerObject);
				if (layer != num2)
				{
					object obj10 = obj * 44;
					object obj11 = obj10 + 32;
					object obj12 = obj11 + (object)hits;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1036 @ rax_v75+4]");
					float num3 = 0f - position.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
					float num4 = num3 & 0;
					if (num > num4)
					{
						num = num4;
						obj2 = obj;
					}
					continue;
				}
				goto IL_0265;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180481D98h\"");
			object obj13;
			if (num == 1f / 0f)
			{
				obj13 = 0;
			}
			else
			{
				bool flag = hits.Length < 0;
				bool flag2 = hits.Length == 0;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				obj13 = flag4 & flag3;
			}
			reference = ref *(bool*)obj13;
			if (hits.Length != 0)
			{
				goto IL_0329;
			}
		}
		else
		{
			float num5 = -1f / 0f;
			object obj14 = 0;
			obj2 = 0;
			object obj15 = 0;
			while ((nint)obj15 < hits.Length)
			{
				object obj16 = obj14 * 44;
				object obj17 = obj16 + 32;
				RaycastHit raycastHit4 = (RaycastHit)(obj17 + (object)hits);
				Collider collider4 = ((RaycastHit*)raycastHit4)->collider;
				if (!collider4.CompareTag(tagIgnore))
				{
					object obj18 = obj14 * 44;
					object obj19 = obj18 + 32;
					RaycastHit raycastHit5 = (RaycastHit)(obj19 + (object)hits);
					Collider collider5 = ((RaycastHit*)raycastHit5)->collider;
					if (!collider5.CompareTag(layerCameraIgnore))
					{
						object obj20 = obj14 * 44;
						object obj21 = obj20 + 32;
						object obj22 = obj21 + (object)hits;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v33+4]");
						if (0f > num5)
						{
							if ((nint)obj14 >= hits.Length)
							{
								return (RaycastHit)new IndexOutOfRangeException();
							}
							object obj23 = obj14 * 44;
							object obj24 = obj23 + 32;
							object obj25 = obj24 + (object)hits;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1064 @ rax_v36+4]");
							num5 = 0f;
							obj2 = obj14;
						}
						reference = ref *(bool*)1;
					}
				}
				obj14++;
				obj15 = obj14;
			}
			if (foundPosition)
			{
				goto IL_0329;
			}
		}
		goto IL_060c;
		IL_0265:
		object obj26;
		if (canChooseObject)
		{
			reference = ref *(bool*)1;
			obj26 = obj;
			goto IL_0564;
		}
		reference = ref *(bool*)null;
		goto IL_060c;
		IL_0329:
		obj26 = obj2;
		goto IL_0564;
		IL_0654:
		RaycastHit raycastHit6 = default(RaycastHit);
		return raycastHit6;
		IL_0564:
		object obj27 = obj26 * 44;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ rcx_v12+20+hits @ rdx (UnityEngine.RaycastHit[])]");
		((RaycastHit*)(nint)raycastHit6)->m_Point = (Vector3)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ rcx_v12+30+hits @ rdx (UnityEngine.RaycastHit[])]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ rcx_v12+3C+hits @ rdx (UnityEngine.RaycastHit[])]");
		((RaycastHit*)(nint)raycastHit6)->m_Distance = 0f;
		goto IL_0654;
		IL_060c:
		((RaycastHit*)(nint)raycastHit6)->m_Point = (Vector3)0;
		_ = 0;
		((RaycastHit*)(nint)raycastHit6)->m_Distance = 0f;
		goto IL_0654;
	}

	public unsafe static Vector3 PredictPlayerPosition(float time)
	{
		//IL_00ff: Expected native int or pointer, but got O
		//IL_010c: Expected native int or pointer, but got O
		//IL_0119: Expected native int or pointer, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerMovement playerMovement = instance.playerMovement;
			if ((object)instance.playerMovement != null && (object)playerMovement.rb != null)
			{
				Vector3 position = playerMovement.rb.position;
				Vector3 velocity = playerMovement.rb.velocity;
				float num = time * velocity.x;
				float num2 = time * velocity.z;
				float num3 = time * velocity.y;
				float x = num + position.x;
				float z = num2 + position.z;
				float y = num3 + position.y;
				Vector3 vector = default(Vector3);
				((Vector3*)(nint)vector)->x = x;
				((Vector3*)(nint)vector)->z = z;
				((Vector3*)(nint)vector)->y = y;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Vector3 GetRandomSpawnPositionOnMap(float extraHeight = 0f)
	{
		//IL_0048: Expected F4, but got I4
		//IL_0048: Expected F4, but got I4
		//IL_0048: Expected O, but got Ref
		//IL_0048: Expected O, but got Ref
		//IL_0059: Expected native int or pointer, but got O
		//IL_006b: Expected native int or pointer, but got O
		GameManager instance = GameManager.Instance;
		if ((object)GameManager.Instance != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			object obj = default(object);
			object obj2 = default(object);
			int layerMask = default(int);
			ref Vector3 normal = default(ref Vector3);
			int attempts = default(int);
			bool onlyUseGroundLayer = default(bool);
			bool debug = default(bool);
			object obj3 = default(object);
			Vector3 objectSpawnPosition = GetObjectSpawnPosition((Vector3)(&obj), (Vector3)(&obj2), 0.5f, layerMask, out normal, attempts, onlyUseGroundLayer, debug, (byte)(&obj3) != 0, 999f, 1f);
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = objectSpawnPosition.x;
			((Vector3*)(nint)vector)->z = objectSpawnPosition.z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	static SpawnPositions()
	{
		//IL_0076: Expected I, but got O
		//IL_0090: Expected O, but got I4
		nint num = (nint)typeof(SpawnPositions);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v2 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
		nint num2 = 0;
		INVALID_POS = (Vector3)1116430664;
		_ = 1116430664;
		_ = 1116430664;
		RaycastHit[] array = new RaycastHit[99];
		spherecastBuffer = array;
		List<RaycastHit> list = new List<RaycastHit>();
		list._002Ector();
		myRaycastAllBuffer = list;
		layerNoSpawnArea = "NoSpawnArea";
		layerCameraIgnore = "CameraIgnore";
		layerWater = "Water";
		layerObject = "Object";
		layerGround = "Ground";
		tagIgnore = "Ignore";
	}
}
