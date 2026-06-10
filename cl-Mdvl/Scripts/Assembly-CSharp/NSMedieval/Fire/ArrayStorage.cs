using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Unity.Collections;
using UnityEngine;

namespace NSMedieval.Fire
{
	public static class ArrayStorage
	{
		private static Dictionary<string, object> storage = new Dictionary<string, object>();

		private static HashSet<string> nativeListIds = new HashSet<string>();

		private static HashSet<string> nativeArrayIds = new HashSet<string>();

		private static HashSet<string> nativeHashSetIds = new HashSet<string>();

		private static HashSet<string> computeBufferIds = new HashSet<string>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			DisposeAll();
			if (storage != null)
			{
				storage.Clear();
			}
			else
			{
				storage = new Dictionary<string, object>();
			}
			if (nativeArrayIds != null)
			{
				nativeArrayIds.Clear();
			}
			else
			{
				nativeArrayIds = new HashSet<string>();
			}
			if (nativeListIds != null)
			{
				nativeListIds.Clear();
			}
			else
			{
				nativeListIds = new HashSet<string>();
			}
			if (nativeHashSetIds != null)
			{
				nativeHashSetIds.Clear();
			}
			else
			{
				nativeHashSetIds = new HashSet<string>();
			}
			if (computeBufferIds != null)
			{
				computeBufferIds.Clear();
			}
			else
			{
				computeBufferIds = new HashSet<string>();
			}
		}

		public static T[] GetArray<T>(string id, int length)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder;
			if (storage.TryGetValue(id, out var value))
			{
				T[] array = value as T[];
				if (array.Length != length)
				{
					messageBuilder = new FVLogInfoInterpolationHandler(52, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Resizing Array with ID ");
						messageBuilder.AppendFormatted(id);
						messageBuilder.AppendLiteral(". Old length: ");
						messageBuilder.AppendFormatted(array.Length);
						messageBuilder.AppendLiteral(", new length: ");
						messageBuilder.AppendFormatted(length);
						messageBuilder.AppendLiteral(".");
					}
					Log.Info(messageBuilder);
					Array.Resize(ref array, length);
				}
				return array;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(34, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating Array with ID ");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral(", length: ");
				messageBuilder.AppendFormatted(length);
				messageBuilder.AppendLiteral(".");
			}
			Log.Info(messageBuilder);
			T[] array2 = new T[length];
			storage[id] = array2;
			return array2;
		}

		public static NativeArray<T> GetNativeArray<T>(string id, int length) where T : unmanaged
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder;
			if (storage.TryGetValue(id, out var value))
			{
				NativeArray<T> nativeArray = (NativeArray<T>)value;
				if (nativeArray.Length != length)
				{
					messageBuilder = new FVLogInfoInterpolationHandler(58, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Resizing NativeArray with ID ");
						messageBuilder.AppendFormatted(id);
						messageBuilder.AppendLiteral(". Old length: ");
						messageBuilder.AppendFormatted(nativeArray.Length);
						messageBuilder.AppendLiteral(", new length: ");
						messageBuilder.AppendFormatted(length);
						messageBuilder.AppendLiteral(".");
					}
					Log.Info(messageBuilder);
					nativeArray.Dispose();
					nativeArray = new NativeArray<T>(length, Allocator.Persistent);
					storage[id] = nativeArray;
				}
				return nativeArray;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(40, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating NativeArray with ID ");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral(", length: ");
				messageBuilder.AppendFormatted(length);
				messageBuilder.AppendLiteral(".");
			}
			Log.Info(messageBuilder);
			nativeArrayIds.Add(id);
			NativeArray<T> nativeArray2 = new NativeArray<T>(length, Allocator.Persistent);
			storage[id] = nativeArray2;
			return nativeArray2;
		}

		public static NativeList<T> GetNativeList<T>(string id) where T : unmanaged
		{
			if (storage.TryGetValue(id, out var value))
			{
				return (NativeList<T>)value;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating NativeList with ID ");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral(".");
			}
			Log.Info(messageBuilder);
			nativeListIds.Add(id);
			NativeList<T> nativeList = new NativeList<T>(Allocator.Persistent);
			storage[id] = nativeList;
			return nativeList;
		}

		public static NativeParallelHashSet<T> GetNativeParallelHashSet<T>(string id, int capacity) where T : unmanaged, IEquatable<T>
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder;
			if (storage.TryGetValue(id, out var value))
			{
				NativeParallelHashSet<T> nativeParallelHashSet = (NativeParallelHashSet<T>)value;
				if (nativeParallelHashSet.Capacity != capacity)
				{
					messageBuilder = new FVLogInfoInterpolationHandler(72, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Resizing NativeParallelHashSet with ID ");
						messageBuilder.AppendFormatted(id);
						messageBuilder.AppendLiteral(". Old capacity: ");
						messageBuilder.AppendFormatted(nativeParallelHashSet.Capacity);
						messageBuilder.AppendLiteral(", new capacity: ");
						messageBuilder.AppendFormatted(capacity);
						messageBuilder.AppendLiteral(".");
					}
					Log.Info(messageBuilder);
					nativeParallelHashSet.Dispose();
					nativeParallelHashSet = new NativeParallelHashSet<T>(capacity, Allocator.Persistent);
					storage[id] = nativeParallelHashSet;
				}
				return nativeParallelHashSet;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating NativeParallelHashSet with ID ");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral(", capacity: ");
				messageBuilder.AppendFormatted(capacity);
				messageBuilder.AppendLiteral(".");
			}
			Log.Info(messageBuilder);
			NativeParallelHashSet<T> nativeParallelHashSet2 = new NativeParallelHashSet<T>(capacity, Allocator.Persistent);
			storage[id] = nativeParallelHashSet2;
			nativeHashSetIds.Add(id);
			return nativeParallelHashSet2;
		}

		public static ComputeBuffer GetComputeBuffer(string id, int length, int stride)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder;
			if (storage.TryGetValue(id, out var value))
			{
				ComputeBuffer computeBuffer = (ComputeBuffer)value;
				if (computeBuffer.count != length || computeBuffer.stride != stride)
				{
					messageBuilder = new FVLogInfoInterpolationHandler(73, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Resizing ComputeBuffer with ID ");
						messageBuilder.AppendFormatted(id);
						messageBuilder.AppendLiteral(". Old length: ");
						messageBuilder.AppendFormatted(computeBuffer.count);
						messageBuilder.AppendLiteral(", new length: ");
						messageBuilder.AppendFormatted(length);
						messageBuilder.AppendLiteral(". Stride: ");
						messageBuilder.AppendFormatted(computeBuffer.stride);
						messageBuilder.AppendLiteral(" - ");
						messageBuilder.AppendFormatted(stride);
						messageBuilder.AppendLiteral(".");
					}
					Log.Info(messageBuilder);
					computeBuffer.Release();
					computeBuffer = new ComputeBuffer(length, stride);
					storage[id] = computeBuffer;
				}
				return computeBuffer;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(52, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating ComputeBuffer with ID ");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral(", length: ");
				messageBuilder.AppendFormatted(length);
				messageBuilder.AppendLiteral(", stride: ");
				messageBuilder.AppendFormatted(stride);
				messageBuilder.AppendLiteral(".");
			}
			Log.Info(messageBuilder);
			computeBufferIds.Add(id);
			ComputeBuffer computeBuffer2 = new ComputeBuffer(length, stride);
			storage[id] = computeBuffer2;
			return computeBuffer2;
		}

		public static void DisposeAll<T>() where T : unmanaged, IEquatable<T>
		{
			foreach (string key in storage.Keys)
			{
				bool isEnabled;
				if (nativeArrayIds.Contains(key))
				{
					if (storage[key] is NativeArray<T> nativeArray)
					{
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Disposing NativeArray<");
							messageBuilder.AppendFormatted(typeof(T));
							messageBuilder.AppendLiteral("> ");
							messageBuilder.AppendFormatted(key);
							messageBuilder.AppendLiteral(".");
						}
						Log.Info(messageBuilder);
						nativeArray.Dispose();
					}
				}
				else if (nativeListIds.Contains(key))
				{
					if (storage[key] is NativeList<T> nativeList)
					{
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Disposing NativeList<");
							messageBuilder.AppendFormatted(typeof(T));
							messageBuilder.AppendLiteral("> ");
							messageBuilder.AppendFormatted(key);
							messageBuilder.AppendLiteral(".");
						}
						Log.Info(messageBuilder);
						nativeList.Dispose();
					}
				}
				else if (computeBufferIds.Contains(key))
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Disposing ComputeBuffer ");
						messageBuilder.AppendFormatted(key);
						messageBuilder.AppendLiteral(".");
					}
					Log.Info(messageBuilder);
					((ComputeBuffer)storage[key]).Dispose();
				}
				else if (nativeHashSetIds.Contains(key) && storage[key] is NativeParallelHashSet<T> nativeParallelHashSet)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Disposing NativeParallelHashSet<");
						messageBuilder.AppendFormatted(typeof(T));
						messageBuilder.AppendLiteral("> ");
						messageBuilder.AppendFormatted(key);
						messageBuilder.AppendLiteral(".");
					}
					Log.Info(messageBuilder);
					nativeParallelHashSet.Dispose();
				}
			}
		}

		public static void DisposeAll()
		{
			string[] array = storage.Keys.ToArray();
			foreach (string text in array)
			{
				if (storage[text] is IDisposable disposable)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ArrayStorage.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Disposing ");
						messageBuilder.AppendFormatted(storage[text].GetType().Name);
						messageBuilder.AppendLiteral(" with ID ");
						messageBuilder.AppendFormatted(text);
						messageBuilder.AppendLiteral(".");
					}
					Log.Info(messageBuilder);
					disposable.Dispose();
				}
				storage[text] = null;
			}
			storage.Clear();
		}

		public static void ClearNativeArray<T>(NativeArray<T> nativeArray, int count = -1) where T : unmanaged
		{
			if (count == -1)
			{
				count = nativeArray.Length;
			}
			NativeArray<T>.Copy(GetNativeArray<T>($"empty-{typeof(T).Name}-{nativeArray.Length}", nativeArray.Length), nativeArray, count);
		}

		public static void ClearNativeArray<T>(NativeArray<T> nativeArray, int count, T valueToSet) where T : unmanaged
		{
			if (count == -1)
			{
				count = nativeArray.Length;
			}
			for (int i = 0; i < count; i++)
			{
				nativeArray[i] = valueToSet;
			}
		}

		public static void ClearStorageDictionary()
		{
			storage.Clear();
		}
	}
}
