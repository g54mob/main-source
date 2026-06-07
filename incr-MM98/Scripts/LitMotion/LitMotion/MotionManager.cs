using System;
using System.Runtime.CompilerServices;
using LitMotion.Collections;

namespace LitMotion
{
	internal static class MotionManager
	{
		private static FastListCore<IMotionStorage> list;

		public static int MotionTypeCount { get; private set; }

		public static void Register<TValue, TOptions, TAdapter>(MotionStorage<TValue, TOptions, TAdapter> storage) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			list.Add(storage);
			MotionTypeCount++;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref MotionData GetDataRef(MotionHandle handle, bool checkIsInSequence = true)
		{
			CheckTypeId(in handle);
			return ref list[handle.StorageId].GetDataRef(handle, checkIsInSequence);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref ManagedMotionData GetManagedDataRef(MotionHandle handle, bool checkIsInSequence = true)
		{
			CheckTypeId(in handle);
			return ref list[handle.StorageId].GetManagedDataRef(handle, checkIsInSequence);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MotionDebugInfo GetDebugInfo(MotionHandle handle)
		{
			CheckTypeId(in handle);
			return list[handle.StorageId].GetDebugInfo(handle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Complete(MotionHandle handle, bool checkIsInSequence = true)
		{
			CheckTypeId(in handle);
			list[handle.StorageId].Complete(handle, checkIsInSequence);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryComplete(MotionHandle handle, bool checkIsInSequence = true)
		{
			if (handle.StorageId < 0 || handle.StorageId >= MotionTypeCount)
			{
				return false;
			}
			return list[handle.StorageId].TryComplete(handle, checkIsInSequence);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cancel(MotionHandle handle, bool checkIsInSequence = true)
		{
			CheckTypeId(in handle);
			list[handle.StorageId].Cancel(handle, checkIsInSequence);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryCancel(MotionHandle handle, bool checkIsInSequence = true)
		{
			if (handle.StorageId < 0 || handle.StorageId >= MotionTypeCount)
			{
				return false;
			}
			return list[handle.StorageId].TryCancel(handle, checkIsInSequence);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsValid(MotionHandle handle)
		{
			if (handle.StorageId < 0 || handle.StorageId >= MotionTypeCount)
			{
				return false;
			}
			return list[handle.StorageId].IsValid(handle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsActive(MotionHandle handle)
		{
			if (handle.StorageId < 0 || handle.StorageId >= MotionTypeCount)
			{
				return false;
			}
			return list[handle.StorageId].IsActive(handle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPlaying(MotionHandle handle)
		{
			if (handle.StorageId < 0 || handle.StorageId >= MotionTypeCount)
			{
				return false;
			}
			return list[handle.StorageId].IsPlaying(handle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTime(MotionHandle handle, double time, bool checkIsInSequence = true)
		{
			CheckTypeId(in handle);
			list[handle.StorageId].SetTime(handle, time, checkIsInSequence);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddToSequence(MotionHandle handle, out double motionDuration)
		{
			CheckTypeId(in handle);
			list[handle.StorageId].AddToSequence(handle, out motionDuration);
		}

		public static (Type ValueType, Type OptionsType, Type AdapterType) GetMotionType(MotionHandle handle)
		{
			CheckTypeId(in handle);
			Type type = list[handle.StorageId].GetType();
			Type item = type.GenericTypeArguments[0];
			Type item2 = type.GenericTypeArguments[1];
			Type item3 = type.GenericTypeArguments[2];
			return (ValueType: item, OptionsType: item2, AdapterType: item3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void CheckTypeId(in MotionHandle handle)
		{
			if (handle.StorageId < 0 || handle.StorageId >= MotionTypeCount)
			{
				throw new ArgumentException("Invalid type id.");
			}
		}
	}
}
