using System;
using System.Runtime.CompilerServices;
using LitMotion.Collections;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace LitMotion
{
	internal sealed class MotionStorage<TValue, TOptions, TAdapter> : IMotionStorage where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
	{
		private const int InitialCapacity = 32;

		private SparseSetCore sparseSetCore = new SparseSetCore();

		private SparseIndex[] sparseIndexLookup = new SparseIndex[32];

		private MotionData<TValue, TOptions>[] unmanagedDataArray = new MotionData<TValue, TOptions>[32];

		private ManagedMotionData[] managedDataArray = new ManagedMotionData[32];

		private AllocatorHelper<RewindableAllocator> allocator;

		private int tail;

		public int Id { get; }

		public int Count => tail;

		public MotionStorage(int id)
		{
			Id = id;
			allocator = RewindableAllocatorFactory.CreateAllocator();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Span<MotionData<TValue, TOptions>> GetDataSpan()
		{
			return unmanagedDataArray.AsSpan();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Span<ManagedMotionData> GetManagedDataSpan()
		{
			return managedDataArray.AsSpan();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void EnsureCapacity(int minimumCapacity)
		{
			sparseSetCore.EnsureCapacity(minimumCapacity);
			ArrayHelper.EnsureCapacity(ref sparseIndexLookup, minimumCapacity);
			ArrayHelper.EnsureCapacity(ref unmanagedDataArray, minimumCapacity);
			ArrayHelper.EnsureCapacity(ref managedDataArray, minimumCapacity);
		}

		public MotionHandle Create(ref MotionBuilder<TValue, TOptions, TAdapter> builder)
		{
			EnsureCapacity(tail + 1);
			MotionBuilderBuffer<TValue, TOptions> buffer = builder.buffer;
			ref MotionData<TValue, TOptions> reference = ref unmanagedDataArray[tail];
			ref ManagedMotionData reference2 = ref managedDataArray[tail];
			ref MotionData.MotionState state = ref reference.Core.State;
			ref MotionData.MotionParameters parameters = ref reference.Core.Parameters;
			state.Status = MotionStatus.Scheduled;
			state.Time = 0.0;
			state.PlaybackSpeed = 1f;
			state.IsPreserved = false;
			parameters.TimeKind = buffer.TimeKind;
			parameters.Duration = buffer.Duration;
			parameters.Delay = buffer.Delay;
			parameters.DelayType = buffer.DelayType;
			parameters.Ease = buffer.Ease;
			parameters.Loops = buffer.Loops;
			parameters.LoopType = buffer.LoopType;
			reference.StartValue = buffer.StartValue;
			reference.EndValue = buffer.EndValue;
			reference.Options = buffer.Options;
			if (buffer.Ease == Ease.CustomAnimationCurve)
			{
				if (parameters.AnimationCurve.IsCreated)
				{
					parameters.AnimationCurve.CopyFrom(buffer.AnimationCurve);
				}
				else
				{
					parameters.AnimationCurve = new NativeAnimationCurve(buffer.AnimationCurve, allocator.Allocator.Handle);
				}
			}
			reference2.CancelOnError = buffer.CancelOnError;
			reference2.SkipValuesDuringDelay = buffer.SkipValuesDuringDelay;
			reference2.UpdateAction = buffer.UpdateAction;
			reference2.OnLoopCompleteAction = buffer.OnLoopCompleteAction;
			reference2.OnCancelAction = buffer.OnCancelAction;
			reference2.OnCompleteAction = buffer.OnCompleteAction;
			reference2.StateCount = buffer.StateCount;
			reference2.State0 = buffer.State0;
			reference2.State1 = buffer.State1;
			reference2.State2 = buffer.State2;
			if (buffer.ImmediateBind && buffer.UpdateAction != null)
			{
				TAdapter val = default(TAdapter);
				MotionEvaluationContext motionEvaluationContext = default(MotionEvaluationContext);
				float progress = ((parameters.Ease != Ease.CustomAnimationCurve) ? EaseUtility.Evaluate(0f, parameters.Ease) : buffer.AnimationCurve.Evaluate(0f));
				motionEvaluationContext.Progress = progress;
				motionEvaluationContext.Time = state.Time;
				ref TValue startValue = ref reference.StartValue;
				ref TValue endValue = ref reference.EndValue;
				ref TOptions options = ref reference.Options;
				MotionEvaluationContext context = motionEvaluationContext;
				reference2.UpdateUnsafe<TValue>(val.Evaluate(ref startValue, ref endValue, ref options, in context));
			}
			SparseIndex sparseIndex = sparseSetCore.Alloc(tail);
			sparseIndexLookup[tail] = sparseIndex;
			tail++;
			return new MotionHandle
			{
				Index = sparseIndex.Index,
				Version = sparseIndex.Version,
				StorageId = Id
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RemoveAt(int denseIndex)
		{
			tail--;
			unmanagedDataArray[denseIndex] = unmanagedDataArray[tail];
			unmanagedDataArray[tail] = default(MotionData<TValue, TOptions>);
			managedDataArray[denseIndex] = managedDataArray[tail];
			managedDataArray[tail] = default(ManagedMotionData);
			SparseIndex sparseIndex = sparseIndexLookup[denseIndex];
			SparseIndex sparseIndex2 = (sparseIndexLookup[denseIndex] = sparseIndexLookup[tail]);
			sparseIndexLookup[tail] = default(SparseIndex);
			if (sparseIndex2.Version != 0)
			{
				sparseSetCore.GetSlotRefUnchecked(sparseIndex2.Index).DenseIndex = denseIndex;
			}
			if (sparseIndex.Version != 0)
			{
				sparseSetCore.Free(sparseIndex);
			}
		}

		public void RemoveAll(NativeList<int> denseIndexList)
		{
			NativeArray<SparseIndex> nativeArray = new NativeArray<SparseIndex>(denseIndexList.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				nativeArray[i] = sparseIndexLookup[denseIndexList[i]];
			}
			for (int j = 0; j < nativeArray.Length; j++)
			{
				RemoveAt(sparseSetCore.GetSlotRefUnchecked(nativeArray[j].Index).DenseIndex);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsValid(MotionHandle handle)
		{
			ref SparseSetCore.Slot slotRefUnchecked = ref sparseSetCore.GetSlotRefUnchecked(handle.Index);
			if (IsDenseIndexOutOfRange(slotRefUnchecked.DenseIndex))
			{
				return false;
			}
			if (IsInvalidVersion(slotRefUnchecked.Version, handle))
			{
				return false;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsActive(MotionHandle handle)
		{
			ref SparseSetCore.Slot slotRefUnchecked = ref sparseSetCore.GetSlotRefUnchecked(handle.Index);
			if (IsDenseIndexOutOfRange(slotRefUnchecked.DenseIndex))
			{
				return false;
			}
			if (IsInvalidVersion(slotRefUnchecked.Version, handle))
			{
				return false;
			}
			ref MotionData.MotionState state = ref unmanagedDataArray[slotRefUnchecked.DenseIndex].Core.State;
			MotionStatus status = state.Status;
			if (status != MotionStatus.Scheduled && status != MotionStatus.Delayed && status != MotionStatus.Playing)
			{
				if (state.Status == MotionStatus.Completed)
				{
					return state.IsPreserved;
				}
				return false;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsPlaying(MotionHandle handle)
		{
			ref SparseSetCore.Slot slotRefUnchecked = ref sparseSetCore.GetSlotRefUnchecked(handle.Index);
			if (IsDenseIndexOutOfRange(slotRefUnchecked.DenseIndex))
			{
				return false;
			}
			if (IsInvalidVersion(slotRefUnchecked.Version, handle))
			{
				return false;
			}
			MotionStatus status = unmanagedDataArray[slotRefUnchecked.DenseIndex].Core.State.Status;
			return status == MotionStatus.Scheduled || status == MotionStatus.Delayed || status == MotionStatus.Playing;
		}

		public bool TryCancel(MotionHandle handle, bool checkIsInSequence = true)
		{
			return TryCancelCore(handle, checkIsInSequence) == 0;
		}

		public void Cancel(MotionHandle handle, bool checkIsInSequence = true)
		{
			switch (TryCancelCore(handle, checkIsInSequence))
			{
			case 1:
				Error.MotionNotExists();
				break;
			case 2:
				Error.MotionHasBeenCanceledOrCompleted();
				break;
			case 3:
				Error.MotionIsInSequence();
				break;
			}
		}

		private int TryCancelCore(MotionHandle handle, bool checkIsInSequence)
		{
			ref SparseSetCore.Slot slotRefUnchecked = ref sparseSetCore.GetSlotRefUnchecked(handle.Index);
			int denseIndex = slotRefUnchecked.DenseIndex;
			if (IsDenseIndexOutOfRange(denseIndex) || IsInvalidVersion(slotRefUnchecked.Version, handle))
			{
				return 1;
			}
			ref MotionData.MotionState state = ref unmanagedDataArray[denseIndex].Core.State;
			MotionStatus status = state.Status;
			if (status == MotionStatus.None || status == MotionStatus.Canceled || (state.Status == MotionStatus.Completed && !state.IsPreserved))
			{
				return 2;
			}
			if (checkIsInSequence && state.IsInSequence)
			{
				return 3;
			}
			state.Status = MotionStatus.Canceled;
			managedDataArray[denseIndex].InvokeOnCancel();
			return 0;
		}

		public bool TryComplete(MotionHandle handle, bool checkIsInSequence = true)
		{
			return TryCompleteCore(handle, checkIsInSequence) == 0;
		}

		public void Complete(MotionHandle handle, bool checkIsInSequence = true)
		{
			switch (TryCompleteCore(handle, checkIsInSequence))
			{
			case 1:
				Error.MotionNotExists();
				break;
			case 2:
				Error.MotionHasBeenCanceledOrCompleted();
				break;
			case 3:
				Error.MotionIsInSequence();
				break;
			case 4:
				throw new InvalidOperationException("Complete was ignored because it is not possible to complete a motion that loops infinitely. If you want to end the motion, call Cancel() instead.");
			}
		}

		private int TryCompleteCore(MotionHandle handle, bool checkIsInSequence)
		{
			ref SparseSetCore.Slot slotRefUnchecked = ref sparseSetCore.GetSlotRefUnchecked(handle.Index);
			if (IsDenseIndexOutOfRange(slotRefUnchecked.DenseIndex) || IsInvalidVersion(slotRefUnchecked.Version, handle))
			{
				return 1;
			}
			ref MotionData<TValue, TOptions> reference = ref unmanagedDataArray[slotRefUnchecked.DenseIndex];
			ref MotionData.MotionState state = ref reference.Core.State;
			ref MotionData.MotionParameters parameters = ref reference.Core.Parameters;
			MotionStatus status = state.Status;
			if (status == MotionStatus.None || status == MotionStatus.Canceled || status == MotionStatus.Completed)
			{
				return 2;
			}
			if (checkIsInSequence && state.IsInSequence)
			{
				return 3;
			}
			if (parameters.Loops < 0)
			{
				return 4;
			}
			reference.Complete<TAdapter>(out var result);
			ref ManagedMotionData reference2 = ref managedDataArray[slotRefUnchecked.DenseIndex];
			try
			{
				reference2.UpdateUnsafe(in result);
			}
			catch (Exception obj)
			{
				MotionDispatcher.GetUnhandledExceptionHandler()?.Invoke(obj);
			}
			if (state.WasLoopCompleted)
			{
				reference2.InvokeOnLoopComplete(state.CompletedLoops);
			}
			reference2.InvokeOnComplete();
			return 0;
		}

		public unsafe void SetTime(MotionHandle handle, double time, bool checkIsInSequence = true)
		{
			ref SparseSetCore.Slot slotRefUnchecked = ref sparseSetCore.GetSlotRefUnchecked(handle.Index);
			int denseIndex = slotRefUnchecked.DenseIndex;
			if (IsDenseIndexOutOfRange(denseIndex))
			{
				Error.MotionNotExists();
			}
			int version = slotRefUnchecked.Version;
			if (version <= 0 || version != handle.Version)
			{
				Error.MotionNotExists();
			}
			fixed (MotionData<TValue, TOptions>* ptr = unmanagedDataArray)
			{
				MotionData<TValue, TOptions>* num = ptr + denseIndex;
				ref MotionData.MotionState reference = ref num->Core.State;
				if (checkIsInSequence && reference.IsInSequence)
				{
					Error.MotionIsInSequence();
				}
				num->Update<TAdapter>(time, out var result);
				MotionStatus status = reference.Status;
				ref ManagedMotionData reference2 = ref managedDataArray[denseIndex];
				switch (status)
				{
				default:
					goto end_IL_0046;
				case MotionStatus.Delayed:
					if (!reference2.SkipValuesDuringDelay)
					{
						break;
					}
					goto end_IL_0046;
				case MotionStatus.Playing:
				case MotionStatus.Completed:
					break;
				}
				try
				{
					reference2.UpdateUnsafe(in result);
				}
				catch (Exception obj)
				{
					MotionDispatcher.GetUnhandledExceptionHandler()?.Invoke(obj);
					if (reference2.CancelOnError)
					{
						reference.Status = MotionStatus.Canceled;
						reference2.OnCancelAction?.Invoke();
						return;
					}
				}
				if (reference.WasLoopCompleted)
				{
					reference2.InvokeOnLoopComplete(reference.CompletedLoops);
				}
				if (status == MotionStatus.Completed && reference.WasStatusChanged)
				{
					reference2.InvokeOnComplete();
				}
				end_IL_0046:;
			}
		}

		public void AddToSequence(MotionHandle handle, out double motionDuration)
		{
			ref SparseSetCore.Slot slotWithVarify = ref GetSlotWithVarify(handle);
			ref MotionData<TValue, TOptions> reference = ref unmanagedDataArray[slotWithVarify.DenseIndex];
			if (reference.Core.State.Status != MotionStatus.Scheduled)
			{
				throw new ArgumentException("Cannot add a running motion to a sequence.");
			}
			motionDuration = handle.TotalDuration;
			if (double.IsInfinity(motionDuration))
			{
				throw new ArgumentException("Cannot add an infinitely looping motion to a sequence.");
			}
			reference.Core.State.IsPreserved = true;
			reference.Core.State.IsInSequence = true;
		}

		public ref ManagedMotionData GetManagedDataRef(MotionHandle handle, bool checkIsInSequence = true)
		{
			ref SparseSetCore.Slot slotWithVarify = ref GetSlotWithVarify(handle, checkIsInSequence);
			return ref managedDataArray[slotWithVarify.DenseIndex];
		}

		public ref MotionData GetDataRef(MotionHandle handle, bool checkIsInSequence = true)
		{
			ref SparseSetCore.Slot slotWithVarify = ref GetSlotWithVarify(handle, checkIsInSequence);
			return ref UnsafeUtility.As<MotionData<TValue, TOptions>, MotionData>(ref unmanagedDataArray[slotWithVarify.DenseIndex]);
		}

		public MotionDebugInfo GetDebugInfo(MotionHandle handle)
		{
			ref SparseSetCore.Slot slotWithVarify = ref GetSlotWithVarify(handle, checkIsInSequence: false);
			ref MotionData<TValue, TOptions> reference = ref unmanagedDataArray[slotWithVarify.DenseIndex];
			return new MotionDebugInfo
			{
				StartValue = reference.StartValue,
				EndValue = reference.EndValue,
				Options = reference.Options
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private ref SparseSetCore.Slot GetSlotWithVarify(MotionHandle handle, bool checkIsInSequence = true)
		{
			ref SparseSetCore.Slot slotRefUnchecked = ref sparseSetCore.GetSlotRefUnchecked(handle.Index);
			if (IsDenseIndexOutOfRange(slotRefUnchecked.DenseIndex))
			{
				Error.MotionNotExists();
			}
			ref MotionData<TValue, TOptions> reference = ref unmanagedDataArray[slotRefUnchecked.DenseIndex];
			if (IsInvalidVersion(slotRefUnchecked.Version, handle) || reference.Core.State.Status == MotionStatus.None)
			{
				Error.MotionNotExists();
			}
			if (checkIsInSequence && reference.Core.State.IsInSequence)
			{
				Error.MotionIsInSequence();
			}
			return ref slotRefUnchecked;
		}

		public void Reset()
		{
			sparseSetCore.Reset();
			sparseIndexLookup.AsSpan().Clear();
			unmanagedDataArray.AsSpan().Clear();
			managedDataArray.AsSpan().Clear();
			tail = 0;
			allocator.Allocator.Rewind();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool IsDenseIndexOutOfRange(int denseIndex)
		{
			if (denseIndex >= 0)
			{
				return denseIndex >= tail;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsInvalidVersion(int version, MotionHandle handle)
		{
			if (version > 0)
			{
				return version != handle.Version;
			}
			return true;
		}
	}
}
