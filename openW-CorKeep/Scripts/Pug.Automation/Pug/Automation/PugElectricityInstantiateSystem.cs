using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Scripting;

namespace Pug.Automation
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(RunSimulationSystemGroup))]
	public class PugElectricityInstantiateSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_0_Job : IJobChunk
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RunWithoutJobSystem_0000053D_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

			internal static class RunWithoutJobSystem_0000053D_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_0000053D_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
							return;
						}
					}
					RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
				}
			}

			public EntityCommandBuffer ecb;

			public EntityArchetype triggerUpdateArchetypeLocal;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ElectricityEntityRefCD> __entityRefTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ElectricityCD> __electricityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in ElectricityEntityRefCD entityRef, [NoAlias] in ElectricityCD electricity, [NoAlias] in LocalTransform transform)
			{
				if (!electricity.hasDirection)
				{
					CircuitConnectionMode circuitConnectionMode = electricity.circuitConnectionMode;
					if ((circuitConnectionMode == CircuitConnectionMode.None || circuitConnectionMode == CircuitConnectionMode.AccordingToDirection) && !electricity.blocksElectricityWhenVariationIsZero)
					{
						return;
					}
				}
				ecb.RemoveComponent<ElectricityEntityRefCD>(entity);
				ecb.DestroyEntity(entityRef.Value);
				Entity e = ecb.CreateEntity(triggerUpdateArchetypeLocal);
				ecb.SetComponent(e, new ElectricityTriggerUpdateNearbyCD
				{
					position = transform.Position.RoundToInt2(),
					useDoubleRange = true
				});
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __entityRefTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __electricityTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i));
					}
					return;
				}
				if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
				{
					int j = 0;
					int nextRangeEnd = 0;
					while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
					{
						for (; j < nextRangeEnd; j++)
						{
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j));
						}
					}
					return;
				}
				ulong num = chunkEnabledMask.ULong0;
				int num2 = math.min(64, count);
				for (int k = 0; k < num2; k++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, l));
					}
					num >>= 1;
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RunWithoutJobSystem_0000053D_0024PostfixBurstDelegate))]
			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				RunWithoutJobSystem_0000053D_0024BurstDirectCall.Invoke(ref query, jobPtr);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_0_Job>(jobPtr), ref query);
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_1_Job : IJobChunk
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RunWithoutJobSystem_00000541_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

			internal static class RunWithoutJobSystem_00000541_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000541_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
							return;
						}
					}
					RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
				}
			}

			public EntityCommandBuffer ecb;

			public EntityArchetype triggerUpdateArchetypeLocal;

			public EntityArchetype connectionArchetypeLocal;

			public EntityArchetype sourceArchetypeLocal;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ObjectDataCD> __objectDataTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ElectricityCD> __electricityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in ObjectDataCD objectData, [NoAlias] in ElectricityCD electricity, [NoAlias] in LocalTransform transform)
			{
				int2 position = transform.Position.RoundToInt2();
				ElectricityDirectionMask electricityDirectionMask = ElectricityDirectionMask.All;
				if (electricity.hasDirection)
				{
					electricityDirectionMask = objectData.variation switch
					{
						0 => ElectricityDirectionMask.North, 
						1 => ElectricityDirectionMask.East, 
						2 => ElectricityDirectionMask.South, 
						3 => ElectricityDirectionMask.West, 
						_ => electricityDirectionMask, 
					};
				}
				bool flag = electricity.sourceEnergy > 0 || electricity.circuitType == CircuitType.Delay;
				CircuitConnectionMode mode = ((!electricity.blocksElectricity) ? CircuitConnectionMode.AccordingToDirection : CircuitConnectionMode.None);
				int connectionModeVariation = 0;
				if (electricity.blocksElectricityWhenVariationIsZero)
				{
					if (objectData.variation == 0)
					{
						flag = false;
						mode = CircuitConnectionMode.None;
					}
					else
					{
						mode = CircuitConnectionMode.AccordingToDirection;
					}
				}
				else
				{
					CircuitConnectionMode circuitConnectionMode = electricity.circuitConnectionMode;
					if (circuitConnectionMode != CircuitConnectionMode.None && circuitConnectionMode != CircuitConnectionMode.AccordingToDirection)
					{
						mode = electricity.circuitConnectionMode;
						connectionModeVariation = objectData.variation;
					}
				}
				Entity entity2 = ecb.CreateEntity(flag ? sourceArchetypeLocal : connectionArchetypeLocal);
				ecb.SetComponent(entity2, new ElectricityConnectionCD
				{
					position = position,
					connectedEntity = entity,
					mode = mode,
					connectionModeVariation = connectionModeVariation,
					direction = electricityDirectionMask,
					prioritize = !electricity.deprioritize
				});
				if (flag)
				{
					ecb.SetComponent(entity2, new ElectricitySourceCD
					{
						sourceEnergy = electricity.sourceEnergy
					});
				}
				switch (electricity.circuitType)
				{
				case CircuitType.Condition:
					ecb.AddComponent<LogicCircuitCD>(entity2);
					break;
				case CircuitType.Delay:
					ecb.AddComponent<DelayCircuitCD>(entity2);
					break;
				}
				ecb.AddComponent(entity, new ElectricityEntityRefCD
				{
					Value = entity2
				});
				Entity e = ecb.CreateEntity(triggerUpdateArchetypeLocal);
				ecb.SetComponent(e, new ElectricityTriggerUpdateNearbyCD
				{
					position = position
				});
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __objectDataTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __electricityTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i));
					}
					return;
				}
				if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
				{
					int j = 0;
					int nextRangeEnd = 0;
					while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
					{
						for (; j < nextRangeEnd; j++)
						{
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j));
						}
					}
					return;
				}
				ulong num = chunkEnabledMask.ULong0;
				int num2 = math.min(64, count);
				for (int k = 0; k < num2; k++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, l));
					}
					num >>= 1;
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000541_0024PostfixBurstDelegate))]
			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				RunWithoutJobSystem_00000541_0024BurstDirectCall.Invoke(ref query, jobPtr);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_1_Job>(jobPtr), ref query);
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_2_Job : IJobChunk
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RunWithoutJobSystem_00000545_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

			internal static class RunWithoutJobSystem_00000545_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000545_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
							return;
						}
					}
					RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
				}
			}

			public EntityCommandBuffer ecb;

			public EntityArchetype triggerUpdateArchetypeLocal;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ElectricityEntityRefCD> __entityRefTypeHandle;

			[ReadOnly]
			public ComponentLookup<ElectricityConnectionCD> __Pug_Automation_ElectricityConnectionCD_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in ElectricityEntityRefCD entityRef)
			{
				ecb.RemoveComponent<ElectricityEntityRefCD>(entity);
				int2 position = __Pug_Automation_ElectricityConnectionCD_ComponentLookup[entityRef.Value].position;
				Entity e = ecb.CreateEntity(triggerUpdateArchetypeLocal);
				ecb.SetComponent(e, new ElectricityTriggerUpdateNearbyCD
				{
					position = position,
					useDoubleRange = true
				});
				ecb.DestroyEntity(entityRef.Value);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __entityRefTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, i));
					}
					return;
				}
				if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
				{
					int j = 0;
					int nextRangeEnd = 0;
					while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
					{
						for (; j < nextRangeEnd; j++)
						{
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, j));
						}
					}
					return;
				}
				ulong num = chunkEnabledMask.ULong0;
				int num2 = math.min(64, count);
				for (int k = 0; k < num2; k++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, l));
					}
					num >>= 1;
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000545_0024PostfixBurstDelegate))]
			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				RunWithoutJobSystem_00000545_0024BurstDirectCall.Invoke(ref query, jobPtr);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_2_Job>(jobPtr), ref query);
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_3_Job : IJobChunk
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RunWithoutJobSystem_00000549_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

			internal static class RunWithoutJobSystem_00000549_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000549_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
							return;
						}
					}
					RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
				}
			}

			public EntityCommandBuffer ecb;

			public EntityArchetype triggerUpdateArchetypeLocal;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ElectricityEntityRefCD> __entityRefTypeHandle;

			[ReadOnly]
			public ComponentLookup<ElectricityConnectionCD> __Pug_Automation_ElectricityConnectionCD_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in ElectricityEntityRefCD entityRef)
			{
				ecb.RemoveComponent<ElectricityEntityRefCD>(entity);
				int2 position = __Pug_Automation_ElectricityConnectionCD_ComponentLookup[entityRef.Value].position;
				Entity e = ecb.CreateEntity(triggerUpdateArchetypeLocal);
				ecb.SetComponent(e, new ElectricityTriggerUpdateNearbyCD
				{
					position = position,
					useDoubleRange = true
				});
				ecb.DestroyEntity(entityRef.Value);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __entityRefTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, i));
					}
					return;
				}
				if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
				{
					int j = 0;
					int nextRangeEnd = 0;
					while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
					{
						for (; j < nextRangeEnd; j++)
						{
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, j));
						}
					}
					return;
				}
				ulong num = chunkEnabledMask.ULong0;
				int num2 = math.min(64, count);
				for (int k = 0; k < num2; k++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityEntityRefCD>(nativeArrayPtr2, l));
					}
					num >>= 1;
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000549_0024PostfixBurstDelegate))]
			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				RunWithoutJobSystem_00000549_0024BurstDirectCall.Invoke(ref query, jobPtr);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_3_Job>(jobPtr), ref query);
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ElectricityEntityRefCD> __Pug_Automation_ElectricityEntityRefCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentLookup<ElectricityConnectionCD> __Pug_Automation_ElectricityConnectionCD_RO_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__Pug_Automation_ElectricityEntityRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityEntityRefCD>(isReadOnly: true);
				__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
				__Pug_Automation_ElectricityConnectionCD_RO_ComponentLookup = state.GetComponentLookup<ElectricityConnectionCD>(isReadOnly: true);
			}
		}

		private EntityArchetype triggerUpdateArchetype;

		private EntityArchetype connectionArchetype;

		private EntityArchetype sourceArchetype;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_393711671_0;

		private EntityQuery __query_393711671_1;

		private EntityQuery __query_393711671_2;

		private EntityQuery __query_393711671_3;

		[Preserve]
		protected override void OnCreate()
		{
			triggerUpdateArchetype = base.EntityManager.CreateArchetype(typeof(ElectricityTriggerUpdateNearbyCD));
			connectionArchetype = base.EntityManager.CreateArchetype(typeof(ElectricityConnectionCD));
			sourceArchetype = base.EntityManager.CreateArchetype(typeof(ElectricityConnectionCD), typeof(ElectricitySourceCD));
			UpdatesInRunGroup();
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
			EntityArchetype triggerUpdateArchetypeLocal = triggerUpdateArchetype;
			EntityArchetype connectionArchetypeLocal = connectionArchetype;
			EntityArchetype sourceArchetypeLocal = sourceArchetype;
			PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_0_Execute(ref ecb, ref triggerUpdateArchetypeLocal);
			ecb.Playback(base.EntityManager);
			ecb.Dispose();
			ecb = new EntityCommandBuffer(Allocator.Temp);
			PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_1_Execute(ref ecb, ref triggerUpdateArchetypeLocal, ref connectionArchetypeLocal, ref sourceArchetypeLocal);
			PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_2_Execute(ref ecb, ref triggerUpdateArchetypeLocal);
			PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_3_Execute(ref ecb, ref triggerUpdateArchetypeLocal);
			ecb.Playback(base.EntityManager);
			ecb.Dispose();
			base.OnUpdate();
		}

		private void PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref EntityArchetype triggerUpdateArchetypeLocal)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Pug_Automation_ElectricityEntityRefCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_0_Job value = new PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_0_Job
			{
				ecb = ecb,
				triggerUpdateArchetypeLocal = triggerUpdateArchetypeLocal,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__entityRefTypeHandle = __TypeHandle.__Pug_Automation_ElectricityEntityRefCD_RO_ComponentTypeHandle,
				__electricityTypeHandle = __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle,
				__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
			};
			if (!__query_393711671_0.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_393711671_0, jobPtr);
			}
			ecb = value.ecb;
			triggerUpdateArchetypeLocal = value.triggerUpdateArchetypeLocal;
		}

		private void PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_1_Execute(ref EntityCommandBuffer ecb, ref EntityArchetype triggerUpdateArchetypeLocal, ref EntityArchetype connectionArchetypeLocal, ref EntityArchetype sourceArchetypeLocal)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_1_Job value = new PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_1_Job
			{
				ecb = ecb,
				triggerUpdateArchetypeLocal = triggerUpdateArchetypeLocal,
				connectionArchetypeLocal = connectionArchetypeLocal,
				sourceArchetypeLocal = sourceArchetypeLocal,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__objectDataTypeHandle = __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle,
				__electricityTypeHandle = __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle,
				__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
			};
			if (!__query_393711671_1.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_393711671_1, jobPtr);
			}
			ecb = value.ecb;
			triggerUpdateArchetypeLocal = value.triggerUpdateArchetypeLocal;
			connectionArchetypeLocal = value.connectionArchetypeLocal;
			sourceArchetypeLocal = value.sourceArchetypeLocal;
		}

		private void PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_2_Execute(ref EntityCommandBuffer ecb, ref EntityArchetype triggerUpdateArchetypeLocal)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Pug_Automation_ElectricityEntityRefCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Pug_Automation_ElectricityConnectionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
			PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_2_Job value = new PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_2_Job
			{
				ecb = ecb,
				triggerUpdateArchetypeLocal = triggerUpdateArchetypeLocal,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__entityRefTypeHandle = __TypeHandle.__Pug_Automation_ElectricityEntityRefCD_RO_ComponentTypeHandle,
				__Pug_Automation_ElectricityConnectionCD_ComponentLookup = __TypeHandle.__Pug_Automation_ElectricityConnectionCD_RO_ComponentLookup
			};
			if (!__query_393711671_2.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_2_Job.RunWithoutJobSystem(ref __query_393711671_2, jobPtr);
			}
			ecb = value.ecb;
			triggerUpdateArchetypeLocal = value.triggerUpdateArchetypeLocal;
		}

		private void PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_3_Execute(ref EntityCommandBuffer ecb, ref EntityArchetype triggerUpdateArchetypeLocal)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Pug_Automation_ElectricityEntityRefCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Pug_Automation_ElectricityConnectionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
			PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_3_Job value = new PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_3_Job
			{
				ecb = ecb,
				triggerUpdateArchetypeLocal = triggerUpdateArchetypeLocal,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__entityRefTypeHandle = __TypeHandle.__Pug_Automation_ElectricityEntityRefCD_RO_ComponentTypeHandle,
				__Pug_Automation_ElectricityConnectionCD_ComponentLookup = __TypeHandle.__Pug_Automation_ElectricityConnectionCD_RO_ComponentLookup
			};
			if (!__query_393711671_3.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				PugElectricityInstantiateSystem_6DCD3F56_LambdaJob_3_Job.RunWithoutJobSystem(ref __query_393711671_3, jobPtr);
			}
			ecb = value.ecb;
			triggerUpdateArchetypeLocal = value.triggerUpdateArchetypeLocal;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ElectricityEntityRefCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ElectricityCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
			__query_393711671_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			__query_393711671_0.SetChangedVersionFilter(new ComponentType[1]
			{
				new ComponentType(typeof(ObjectDataCD))
			});
			entityQueryBuilder2 = entityQueryBuilder.WithNone<ElectricityEntityRefCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ElectricityCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_393711671_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ElectricityEntityRefCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
			__query_393711671_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithNone<ElectricityCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ElectricityEntityRefCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_393711671_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		protected override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			__AssignQueries(ref base.CheckedStateRef);
			__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
		}

		[Preserve]
		public PugElectricityInstantiateSystem()
		{
		}
	}
}
