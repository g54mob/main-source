using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct JobDependencyAnalyzer<T> where T : struct
	{
		private struct ReflectionData
		{
			public int[] fieldOffsets;

			public bool[] writes;

			public bool[] checkUninitializedRead;

			public string[] fieldNames;

			public void Build()
			{
				List<int> list = new List<int>();
				List<bool> list2 = new List<bool>();
				List<bool> list3 = new List<bool>();
				List<string> list4 = new List<string>();
				Build(typeof(T), list, list2, list3, list4, 0, forceReadOnly: false, forceWriteOnly: false, forceDisableUninitializedCheck: false);
				fieldOffsets = list.ToArray();
				writes = list2.ToArray();
				fieldNames = list4.ToArray();
				checkUninitializedRead = list3.ToArray();
			}

			private void Build(Type type, List<int> fields, List<bool> writes, List<bool> reads, List<string> names, int offset, bool forceReadOnly, bool forceWriteOnly, bool forceDisableUninitializedCheck)
			{
				FieldInfo[] fields2 = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields2)
				{
					if (fieldInfo.FieldType.IsGenericType && fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(NativeArray<>))
					{
						fields.Add(offset + UnsafeUtility.GetFieldOffset(fieldInfo) + JobDependencyAnalyzer<T>.BufferOffset);
						writes.Add(!forceReadOnly && fieldInfo.GetCustomAttribute(typeof(ReadOnlyAttribute)) == null);
						reads.Add(!forceWriteOnly && !forceDisableUninitializedCheck && fieldInfo.GetCustomAttribute(typeof(WriteOnlyAttribute)) == null && fieldInfo.GetCustomAttribute(typeof(DisableUninitializedReadCheckAttribute)) == null);
						names.Add(fieldInfo.Name);
					}
					else if (fieldInfo.FieldType.IsGenericType && fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(UnsafeSpan<>))
					{
						fields.Add(offset + UnsafeUtility.GetFieldOffset(fieldInfo) + JobDependencyAnalyzer<T>.SpanPtrOffset);
						writes.Add(!forceReadOnly && fieldInfo.GetCustomAttribute(typeof(ReadOnlyAttribute)) == null);
						reads.Add(!forceWriteOnly && !forceDisableUninitializedCheck && fieldInfo.GetCustomAttribute(typeof(WriteOnlyAttribute)) == null && fieldInfo.GetCustomAttribute(typeof(DisableUninitializedReadCheckAttribute)) == null);
						names.Add(fieldInfo.Name);
					}
					else if (!fieldInfo.FieldType.IsPrimitive && fieldInfo.FieldType.IsValueType && !fieldInfo.FieldType.IsEnum)
					{
						bool forceReadOnly2 = fieldInfo.GetCustomAttribute(typeof(ReadOnlyAttribute)) != null;
						bool forceWriteOnly2 = fieldInfo.GetCustomAttribute(typeof(WriteOnlyAttribute)) != null;
						bool forceDisableUninitializedCheck2 = fieldInfo.GetCustomAttribute(typeof(DisableUninitializedReadCheckAttribute)) != null;
						Build(fieldInfo.FieldType, fields, writes, reads, names, offset + UnsafeUtility.GetFieldOffset(fieldInfo), forceReadOnly2, forceWriteOnly2, forceDisableUninitializedCheck2);
					}
				}
			}
		}

		private static ReflectionData reflectionData;

		private static readonly int BufferOffset = UnsafeUtility.GetFieldOffset(typeof(NativeArray<int>).GetField("m_Buffer", BindingFlags.Instance | BindingFlags.NonPublic));

		private static readonly int SpanPtrOffset = UnsafeUtility.GetFieldOffset(typeof(UnsafeSpan<int>).GetField("ptr", BindingFlags.Instance | BindingFlags.NonPublic));

		private static void initReflectionData()
		{
			if (reflectionData.fieldOffsets == null)
			{
				reflectionData.Build();
			}
		}

		private static bool HasHash(int[] hashes, int hash, int count)
		{
			for (int i = 0; i < count; i++)
			{
				if (hashes[i] == hash)
				{
					return true;
				}
			}
			return false;
		}

		public static JobHandle GetDependencies(ref T data, JobDependencyTracker tracker)
		{
			return GetDependencies(ref data, tracker, default(JobHandle), useAdditionalDependency: false);
		}

		public static JobHandle GetDependencies(ref T data, JobDependencyTracker tracker, JobHandle additionalDependency)
		{
			return GetDependencies(ref data, tracker, additionalDependency, useAdditionalDependency: true);
		}

		private unsafe static JobHandle GetDependencies(ref T data, JobDependencyTracker tracker, JobHandle additionalDependency, bool useAdditionalDependency)
		{
			if (!tracker.dependenciesScratchBuffer.IsCreated)
			{
				tracker.dependenciesScratchBuffer = new NativeArray<JobHandle>(16, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			}
			NativeArray<JobHandle> dependenciesScratchBuffer = tracker.dependenciesScratchBuffer;
			List<JobDependencyTracker.NativeArraySlot> slots = tracker.slots;
			int[] tempJobDependencyHashes = JobDependencyAnalyzerAssociated.tempJobDependencyHashes;
			int num = 0;
			initReflectionData();
			byte* ptr = (byte*)UnsafeUtility.AddressOf(ref data);
			int[] fieldOffsets = reflectionData.fieldOffsets;
			for (int i = 0; i < fieldOffsets.Length; i++)
			{
				long num2 = (long)(nuint)(*(nint*)(ptr + fieldOffsets[i]));
				for (int j = 0; j <= slots.Count; j++)
				{
					if (j == slots.Count)
					{
						slots.Add(new JobDependencyTracker.NativeArraySlot
						{
							hash = num2,
							lastWrite = default(JobDependencyTracker.JobInstance),
							lastReads = ListPool<JobDependencyTracker.JobInstance>.Claim(),
							initialized = true,
							hasWrite = false
						});
					}
					JobDependencyTracker.NativeArraySlot nativeArraySlot = slots[j];
					if (nativeArraySlot.hash != num2)
					{
						continue;
					}
					if (reflectionData.checkUninitializedRead[i] && !nativeArraySlot.initialized)
					{
						throw new InvalidOperationException("A job tries to read from the native array " + typeof(T).Name + "." + reflectionData.fieldNames[i] + " which contains uninitialized data");
					}
					if (nativeArraySlot.hasWrite && !HasHash(tempJobDependencyHashes, nativeArraySlot.lastWrite.hash, num))
					{
						dependenciesScratchBuffer[num] = nativeArraySlot.lastWrite.handle;
						tempJobDependencyHashes[num] = nativeArraySlot.lastWrite.hash;
						num++;
						if (num >= dependenciesScratchBuffer.Length)
						{
							throw new Exception("Too many dependencies for job");
						}
					}
					if (!reflectionData.writes[i])
					{
						break;
					}
					for (int k = 0; k < nativeArraySlot.lastReads.Count; k++)
					{
						if (!HasHash(tempJobDependencyHashes, nativeArraySlot.lastReads[k].hash, num))
						{
							dependenciesScratchBuffer[num] = nativeArraySlot.lastReads[k].handle;
							tempJobDependencyHashes[num] = nativeArraySlot.lastReads[k].hash;
							num++;
							if (num >= dependenciesScratchBuffer.Length)
							{
								throw new Exception("Too many dependencies for job");
							}
						}
					}
					break;
				}
			}
			if (useAdditionalDependency)
			{
				dependenciesScratchBuffer[num] = additionalDependency;
				num++;
			}
			return num switch
			{
				0 => default(JobHandle), 
				1 => dependenciesScratchBuffer[0], 
				_ => JobHandle.CombineDependencies(dependenciesScratchBuffer.Slice(0, num)), 
			};
		}

		internal unsafe static void Scheduled(ref T data, JobDependencyTracker tracker, JobHandle job)
		{
			int jobHash = JobDependencyAnalyzerAssociated.jobCounter++;
			byte* ptr = (byte*)UnsafeUtility.AddressOf(ref data);
			for (int i = 0; i < reflectionData.fieldOffsets.Length; i++)
			{
				long nativeArrayHash = (long)(nuint)(*(nint*)(ptr + reflectionData.fieldOffsets[i]));
				if (reflectionData.writes[i])
				{
					tracker.JobWritesTo(job, nativeArrayHash, jobHash);
				}
				else
				{
					tracker.JobReadsFrom(job, nativeArrayHash, jobHash);
				}
			}
		}
	}
}
