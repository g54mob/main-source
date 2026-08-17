using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Framework;

public class EnemiesManager : GameTickable, IInitializable, IDisposable
{
	private struct EnemyVelocityCalcJob : IJobParallelFor
	{
		public NativeArray<float3> _positionArray;

		public NativeArray<float3> _velocityArray;

		public NativeArray<float> _speedArray;

		public NativeArray<bool> _fixedDirectionArray;

		public NativeArray<float3> _currentDirectionArray;

		public NativeArray<float3> _targetArray;

		public bool _isPaused;

		public void Execute(int index)
		{
			HandleTargetVelocityCalc(index);
		}

		private void HandleTargetVelocityCalc(int index)
		{
			//IL_01df: Expected O, but got I4
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Expected O, but got Unknown
			//IL_01a3: Expected I, but got O
			//IL_001f: Expected O, but got I
			//IL_002f: Expected O, but got I
			//IL_00ec: Expected O, but got I4
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_0107: Expected O, but got I4
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_013b: Expected O, but got I
			//IL_0165: Expected O, but got I
			//IL_0226: Expected O, but got I4
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Expected O, but got Unknown
			//IL_02ba: Invalid comparison between O and F4
			//IL_0190: Expected F4, but got I4
			//IL_02f7: Expected O, but got I4
			//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0304: Expected O, but got Unknown
			object obj = index * 2;
			object obj2 = index + obj;
			object obj6;
			object obj7;
			object obj8;
			object obj4;
			object obj3;
			if (!_isPaused)
			{
				NativeArray<float3> currentDirectionArray = _currentDirectionArray;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v4 (Unity.Collections.NativeArray`1<Unity.Mathematics.float3>)+v44 @ r8_v1*4]");
				obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v4 (Unity.Collections.NativeArray`1<Unity.Mathematics.float3>)+8+v44 @ r8_v1*4]");
				obj4 = 0;
				NativeArray<bool> fixedDirectionArray = _fixedDirectionArray;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [index @ rdx (System.Int32)+v61 @ rax_v5 (Unity.Collections.NativeArray`1<System.Boolean>)]");
				if ((nint)0 == 0)
				{
					goto IL_00d4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877D4674h\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v4 (Unity.Collections.NativeArray`1<Unity.Mathematics.float3>)+v44 @ r8_v1*4]");
				object obj5 = default(object);
				if ((nint)0 == 0)
				{
					bool flag = obj5 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877D4674h\"");
					if (flag)
					{
						goto IL_00d4;
					}
				}
				obj6 = obj4;
				obj7 = obj5;
				obj8 = obj3;
				goto IL_020e;
			}
			nint num = (nint)typeof(float3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v2 (Il2CppClass<Unity.Mathematics.float3>)+B8]");
			nint num2 = 0;
			NativeArray<float3> velocityArray = _velocityArray;
			_ = float3.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v2 (Il2CppStaticFields<Unity.Mathematics.float3>)+8]");
			_ = 0;
			return;
			IL_020e:
			NativeArray<float3> currentDirectionArray2 = _currentDirectionArray;
			object obj9 = index * 2;
			object obj10 = index + obj9;
			object obj11 = obj7 * obj7;
			object obj12 = obj8 * obj8;
			NativeArray<float> speedArray = _speedArray;
			object obj13 = obj6 * obj6;
			object obj14 = obj11 + obj12;
			object obj15 = obj14 + obj13;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			float num3 = 1f / (float)obj15;
			float num4 = (float)obj6 * num3;
			float num5 = ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.1754944E-38f)) ? 0f : num4);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v8 (Unity.Collections.NativeArray`1<System.Single>)+index @ rdx (System.Int32)*4]");
			float num6 = 0f / 100f;
			object obj16 = index * 2;
			object obj17 = index + obj16;
			NativeArray<float3> velocityArray2 = _velocityArray;
			float num7 = num5 * num6;
			return;
			IL_00d4:
			NativeArray<float3> positionArray = _positionArray;
			object obj18 = index * 2;
			object obj19 = index + obj18;
			object obj20 = index * 2;
			object obj21 = index + obj20;
			NativeArray<float3> targetArray = _targetArray;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v11 (Unity.Collections.NativeArray`1<Unity.Mathematics.float3>)+v125 @ rcx_v7*4]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v10 (Unity.Collections.NativeArray`1<Unity.Mathematics.float3>)+v121 @ rcx_v6*4]");
			obj8 = num8 - 0;
			object obj22 = default(object);
			obj7 = obj22 - obj22;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v11 (Unity.Collections.NativeArray`1<Unity.Mathematics.float3>)+8+v125 @ rcx_v7*4]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v10 (Unity.Collections.NativeArray`1<Unity.Mathematics.float3>)+8+v121 @ rcx_v6*4]");
			obj6 = num9 - 0;
			obj4 = obj6;
			obj3 = obj22;
			goto IL_020e;
		}
	}

	private GameManager _gameManager;

	private static readonly ProfilerMarker s_onTickMarker;

	public void Initialize()
	{
	}

	public void Dispose()
	{
	}

	protected override void OnTick()
	{
		//IL_0045: Expected O, but got I
		//IL_0226: Expected I, but got O
		//IL_00a5: Expected I, but got O
		//IL_00b5: Expected O, but got I
		//IL_00c5: Expected O, but got I
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0251->IL0256: Incompatible stack heights: 7 vs 3
		//IL_01b9->IL0256: Incompatible stack heights: 7 vs 3
		//IL_01d5->IL0256: Incompatible stack heights: 7 vs 3
		if ((object)s_onTickMarker != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)s_onTickMarker);
		}
		GameManager gameManager = _gameManager;
		bool flag = (object)_gameManager == null;
		EnemiesManager stage = (EnemiesManager)(object)gameManager._stage;
		bool flag2 = (object)gameManager._stage == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v6 (VampireSurvivors.Framework.EnemiesManager)+190]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v6 (VampireSurvivors.Framework.EnemiesManager)+190]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v11+18]");
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if ((nint)0 > (nint)0)
		{
			GameManager gameManager2 = _gameManager;
			nint num = (nint)gameManager2._stage;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rcx_v9 (Il2CppClass<UnityEngine.Object>)+190]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v15+18]");
			object obj3 = 0;
			while (true)
			{
				obj3--;
				if ((nint)obj3 < 0)
				{
					break;
				}
				GameManager gameManager3 = _gameManager;
				bool flag4 = (object)_gameManager == null;
				Stage stage2 = gameManager3._stage;
				bool flag5 = (object)gameManager3._stage == null;
				List<EnemyController> spawnedEnemies = stage2._spawnedEnemies;
				bool flag6 = stage2._spawnedEnemies == null;
				bool flag7 = (nint)obj3 >= spawnedEnemies._size;
				EnemyController[] items = spawnedEnemies._items;
				GameMonoBehaviour gameMonoBehaviour = items[obj3];
				if ((object)items[obj3] != null && ((UnityEngine.Object)gameMonoBehaviour).m_CachedPtr != (IntPtr)0)
				{
					items[obj3].UpdateCallback();
				}
			}
			autoScope.Dispose();
		}
		else
		{
			autoScope.Dispose();
		}
	}

	private unsafe void RunMovementJob()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00b5: Expected I8, but got O
		//IL_00c2: Expected I, but got O
		//IL_00f1: Expected I8, but got O
		//IL_00fe: Expected I, but got O
		//IL_0143: Expected O, but got I
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0166: Expected I8, but got O
		//IL_01e6: Expected I8, but got I4
		//IL_0201: Expected I8, but got I4
		//IL_01c4: Expected I4, but got I8
		//IL_0256: Expected O, but got I
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		//IL_0279: Expected I8, but got O
		//IL_02d3: Expected O, but got I
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02f6: Expected I8, but got O
		//IL_0976: Expected O, but got I
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_0400: Expected O, but got I4
		//IL_040a: Expected O, but got I4
		//IL_0762: Expected O, but got Ref
		//IL_09c5: Expected O, but got Ref
		//IL_0a7e: Expected O, but got Ref
		//IL_0799: Expected O, but got Ref
		//IL_07b5: Expected O, but got Ref
		//IL_0a10: Expected O, but got Ref
		//IL_08ad: Expected O, but got I
		//IL_0617: Expected I, but got O
		//IL_067d: Expected I, but got O
		//IL_090d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Expected O, but got Unknown
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0920: Expected O, but got Unknown
		//IL_0439->IL07bf: Incompatible stack heights: 1 vs 0
		//IL_0470->IL07bf: Incompatible stack heights: 1 vs 0
		//IL_0862->IL07bf: Incompatible stack heights: 2 vs 0
		//IL_04b3->IL07bf: Incompatible stack heights: 4 vs 0
		//IL_04ea->IL07bf: Incompatible stack heights: 4 vs 0
		//IL_0553->IL07bf: Incompatible stack heights: 5 vs 0
		//IL_058a->IL07bf: Incompatible stack heights: 5 vs 0
		//IL_05e3->IL07bf: Incompatible stack heights: 6 vs 0
		//IL_060a->IL07bf: Incompatible stack heights: 6 vs 0
		//IL_0667->IL07bf: Incompatible stack heights: 7 vs 0
		//IL_069e->IL07bf: Incompatible stack heights: 7 vs 0
		//IL_06d3->IL07bf: Incompatible stack heights: 7 vs 0
		//IL_0961->IL0a3e: Incompatible stack heights: 8 vs 0
		//IL_0966->IL06e2: Incompatible stack heights: 8 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameManager gameManager = _gameManager;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		List<EnemyController> spawnedEnemies;
		NativeArray<float3> array;
		NativeArray<float> array2;
		JobHandle ret2;
		if ((object)_gameManager != null)
		{
			Stage stage = gameManager._stage;
			if ((object)gameManager._stage != null)
			{
				spawnedEnemies = stage._spawnedEnemies;
				if (stage._spawnedEnemies != null)
				{
					NativeArray<float3>.Allocate(spawnedEnemies._size, Allocator.TempJob, out array);
					object obj4 = default(object);
					object obj3 = obj4 * 2;
					object obj5 = obj4 + obj3;
					long size = obj5 << 2;
					UnsafeUtility.MemClear((void*)(nint)array, size);
					NativeArray<float>.Allocate(spawnedEnemies._size, Allocator.TempJob, out array2);
					object obj6 = default(object);
					long size2 = obj6 << 2;
					UnsafeUtility.MemClear((void*)(nint)array2, size2);
					NativeArray<float3>.Allocate(spawnedEnemies._size, Allocator.TempJob, out System.Runtime.CompilerServices.Unsafe.As<object, NativeArray<float3>>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128)));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
					object obj7 = (nint)0 * (nint)2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
					object obj8 = 0 + obj7;
					long num = obj8 << 2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
					UnsafeUtility.MemClear(null, num);
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1056 @ rcx_v43 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						NativeArray<float3>.Allocate(0, (Allocator)num, out *(NativeArray<float3>*)null);
					}
					void* destination = UnsafeUtility.MallocTracked(spawnedEnemies._size, 1, Allocator.TempJob, 0);
					UnsafeUtility.MemClear(destination, spawnedEnemies._size);
					NativeArray<float3>.Allocate(spawnedEnemies._size, Allocator.TempJob, out System.Runtime.CompilerServices.Unsafe.As<object, NativeArray<float3>>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112)));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
					void* ptr = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
					object obj9 = (nint)0 * (nint)2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
					object obj10 = 0 + obj9;
					long size3 = obj10 << 2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
					UnsafeUtility.MemClear(null, size3);
					NativeArray<float3>.Allocate(spawnedEnemies._size, Allocator.TempJob, out System.Runtime.CompilerServices.Unsafe.As<object, NativeArray<float3>>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96)));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
					object obj11 = (nint)0 * (nint)2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
					object obj12 = 0 + obj11;
					long size4 = obj12 << 2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
					UnsafeUtility.MemClear(null, size4);
					GameManager gameManager2 = _gameManager;
					if ((object)_gameManager != null)
					{
						Stage stage2 = gameManager2._stage;
						if ((object)gameManager2._stage != null)
						{
							List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
							if (spawnedEnemies._size <= 0)
							{
								goto IL_06e2;
							}
							NativeArray<float3> nativeArray = array;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
							object obj13 = nativeArray - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
							void* ptr2 = (void*)(num3 - 0);
							if (stage2._spawnedEnemies != null)
							{
								object obj14 = 0;
								object obj15 = 0;
								object obj18 = default(object);
								while (true)
								{
									bool flag = (nint)obj15 >= spawnedEnemies2._size;
									EnemyController[] items = spawnedEnemies2._items;
									if (spawnedEnemies2._items == null)
									{
										break;
									}
									object obj16 = items[obj15];
									if ((object)items[obj15] == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rsi_v17 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rsi_v17 (System.Object)+10]");
									IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
									Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
									if ((object)transform == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v120 (UnityEngine.Transform)+10]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v120 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 _);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
									object obj17 = 0;
									_ = 0;
									bool flag4 = (nint)obj15 >= spawnedEnemies2._size;
									EnemyController[] items2 = spawnedEnemies2._items;
									if (spawnedEnemies2._items == null)
									{
										break;
									}
									EnemyController enemyController = items2[obj15];
									if ((object)items2[obj15] == null)
									{
										break;
									}
									float num4 = GameManager.EnemySpeed * enemyController._003CSpeed_003Ek__BackingField;
									bool flag5 = (nint)obj15 >= spawnedEnemies2._size;
									EnemyController[] items3 = spawnedEnemies2._items;
									if (spawnedEnemies2._items == null)
									{
										break;
									}
									EnemyController enemyController2 = items3[obj15];
									if ((object)items3[obj15] == null)
									{
										break;
									}
									_ = enemyController2._fixedDirection;
									bool flag6 = (nint)obj15 >= spawnedEnemies2._size;
									EnemyController[] items4 = spawnedEnemies2._items;
									if (spawnedEnemies2._items == null || (object)items4[obj15] == null)
									{
										break;
									}
									ptr = (void*)(nint)obj18;
									_ = 0;
									bool flag7 = (nint)obj15 >= spawnedEnemies2._size;
									EnemyController[] items5 = spawnedEnemies2._items;
									if (spawnedEnemies2._items == null)
									{
										break;
									}
									void* ptr3 = (void*)(nint)items5[obj15];
									if ((object)items5[obj15] == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rsi_v19 (System.Void*)+F8]");
									void* ptr4 = null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rsi_v19 (System.Void*)+F8]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v20 (System.Void*)+10]");
									bool flag8 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v20 (System.Void*)+10]");
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret2));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
									void* ptr5 = null;
									obj15++;
									obj14++;
									_ = 0;
									ptr = (byte*)ptr + 12;
									bool flag9 = (nint)obj14 < spawnedEnemies._size;
									size4 = (nint)(&ret2);
									if (flag9)
									{
										continue;
									}
									goto IL_06e2;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_06e2:
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
		obj = 0;
		_ = PauseSystem._paused;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
		_ = 0;
		_ = 0;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1716 @ rbx_v21 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		IJobParallelForExtensions.ParallelForJobStruct<EnemyVelocityCalcJob>.Initialize();
		Unity.Collections.LowLevel.Unsafe.BurstLike.SharedStatic<IntPtr> jobReflectionData = IJobParallelForExtensions.ParallelForJobStruct<EnemyVelocityCalcJob>.jobReflectionData;
		object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		_ = 1;
		_ = 0;
		object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
		JobsUtility.ScheduleParallelFor_Injected(ref *(JobsUtility.JobScheduleParameters*)obj20, spawnedEnemies._size, 100, out ret2);
		if ((object)ret2 != null)
		{
			object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
			JobHandle.ScheduleBatchedJobsAndComplete(ref *(JobHandle*)obj21);
		}
		array.Dispose();
		array2.Dispose();
		NativeArray<float3> nativeArray2 = (NativeArray<float3>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		((NativeArray<float3>*)nativeArray2)->Dispose();
		NativeArray<bool> nativeArray3 = default(NativeArray<bool>);
		nativeArray3.Dispose();
		NativeArray<float3> nativeArray4 = (NativeArray<float3>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
		((NativeArray<float3>*)nativeArray4)->Dispose();
		NativeArray<float3> nativeArray5 = (NativeArray<float3>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		((NativeArray<float3>*)nativeArray5)->Dispose();
	}

	static EnemiesManager()
	{
		//IL_002b: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("EnemiesManager.OnTick", 7, MarkerFlags.Default, 0);
		s_onTickMarker = (ProfilerMarker)(nint)intPtr;
	}
}
