using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace GAudio
{
	public class GATData : RetainableObject, IGATDataOwner, IRetainable
	{
		protected readonly float[] _parentArray;

		protected int _offset;

		protected readonly IGAT16BitDataProvider _data16;

		public static bool UseNativeGainMixToInterlaced = true;

		public static bool UseNativeResampleCopyFrom = true;

		public string SampleName { get; set; }

		public int MemOffset => _offset;

		public float[] ParentArray => _parentArray;

		public short[] ParentArray16
		{
			get
			{
				if (_data16 == null)
				{
					return null;
				}
				return _data16.SampleData;
			}
		}

		public virtual int Count
		{
			get
			{
				if (_data16 != null)
				{
					return _data16.Length;
				}
				return _parentArray.Length - _offset;
			}
		}

		public float this[int index]
		{
			get
			{
				return _parentArray[_offset + index];
			}
			set
			{
				_parentArray[_offset + index] = value;
			}
		}

		GATData IGATDataOwner.AudioData => this;

		public GATData(float[] parentArray)
		{
			_parentArray = parentArray;
		}

		public GATData(IGAT16BitDataProvider data16)
		{
			_data16 = data16;
			_offset = 0;
			_parentArray = null;
		}

		public virtual IntPtr GetPointer()
		{
			return IntPtr.Zero;
		}

		public void CopyTo(float[] destinationArray, int destinationIndex, int sourceIndex, int length)
		{
			Array.Copy(_parentArray, sourceIndex + _offset, destinationArray, destinationIndex, length);
		}

		public void CopyTo(GATData destinationData, int destinationIndex, int sourceIndex, int length)
		{
			Array.Copy(_parentArray, sourceIndex + _offset, destinationData._parentArray, destinationIndex + destinationData._offset, length);
		}

		public void CopyFrom(float[] sourceArray, int destinationIndex, int sourceIndex, int length)
		{
			Array.Copy(sourceArray, sourceIndex, _parentArray, _offset + destinationIndex, length);
		}

		public void CopyFrom(short[] sourceArray, int destinationIndex, int sourceIndex, int length, bool reverse = false)
		{
			int num = _parentArray.Length - (_offset + destinationIndex + length);
			int num2 = sourceArray.Length - (sourceIndex + length);
			if (num < 0 || num2 < 0)
			{
				Debug.LogFormat("GATData: Caught illegal copy! _parentArray[{0} + {1} + 0 -> {2}], length = {3}. sourceArray[{4} + 0 -> {5}], length = {6}.", _offset, destinationIndex, length, _parentArray.Length, sourceIndex, length, sourceArray.Length);
				length += Mathf.Min(num, num2);
			}
			if (!reverse)
			{
				for (int i = 0; i < length; i++)
				{
					_parentArray[_offset + destinationIndex + i] = (float)sourceArray[sourceIndex + i] * GATWavHelper.int16ToFloatRescaleFactor;
				}
				return;
			}
			int num3 = length - 1;
			for (int j = 0; j < length; j++)
			{
				_parentArray[_offset + destinationIndex + (num3 - j)] = (float)sourceArray[sourceIndex + j] * GATWavHelper.int16ToFloatRescaleFactor;
			}
		}

		public void CopyGainTo(GATData destinationData, int sourceIndex, int destinationIndex, int length, float gain)
		{
			sourceIndex += _offset;
			length += sourceIndex;
			float[] parentArray = destinationData.ParentArray;
			destinationIndex += destinationData._offset;
			while (sourceIndex < length)
			{
				parentArray[destinationIndex] = _parentArray[sourceIndex] * gain;
				sourceIndex++;
				destinationIndex++;
			}
		}

		public void CopyFromInterlaced(float[] sourceArray, int targetLength, int channelNb, int nbOfChannels)
		{
			int num = channelNb;
			targetLength += _offset;
			for (int i = _offset; i < targetLength; i++)
			{
				_parentArray[i] = sourceArray[num];
				num += nbOfChannels;
			}
		}

		public void CopyFromInterlaced(float[] sourceArray, int targetLength, int targetOffset, int channelNb, int nbOfChannels)
		{
			int num = channelNb;
			targetLength += _offset + targetOffset;
			for (int i = _offset + targetOffset; i < targetLength; i++)
			{
				_parentArray[i] = sourceArray[num];
				num += nbOfChannels;
			}
		}

		public void CopyFromInterlaced(float[] sourceArray, int sourceOffset, int targetLength, int targetOffset, int channelNb, int nbOfChannels)
		{
			int num = sourceOffset + channelNb;
			targetLength += _offset + targetOffset;
			for (int i = _offset + targetOffset; i < targetLength; i++)
			{
				_parentArray[i] = sourceArray[num];
				num += nbOfChannels;
			}
		}

		public void MixFromInterlaced(float[] sourceArray, int sourceFrameOffset, int targetLength, int targetOffset, int channelNb, int nbOfChannels)
		{
			int num = sourceFrameOffset + channelNb;
			targetLength += _offset + targetOffset;
			for (int i = _offset + targetOffset; i < targetLength; i++)
			{
				_parentArray[i] += sourceArray[num];
				num += nbOfChannels;
			}
		}

		public void CopySmoothedGainFrom(float[] sourceArray, int sourceIndex, int destinationIndex, int length, float fromGain, float toGain)
		{
			float num = (toGain - fromGain) / (float)length;
			destinationIndex += _offset;
			length += sourceIndex;
			while (sourceIndex < length)
			{
				_parentArray[destinationIndex] = sourceArray[sourceIndex] * fromGain;
				fromGain += num;
				destinationIndex++;
				sourceIndex++;
			}
		}

		public void CopySmoothedGainTo(int sourceIndex, GATData destination, int destinationIndex, int length, float fromGain, float toGain)
		{
			sourceIndex += _offset;
			destination.CopySmoothedGainFrom(_parentArray, sourceIndex, destinationIndex, length, fromGain, toGain);
		}

		public void MixTo(float[] destinationArray, int destinationIndex, int sourceIndex, int length)
		{
			sourceIndex += _offset;
			length += sourceIndex;
			while (sourceIndex < length)
			{
				destinationArray[destinationIndex] += _parentArray[sourceIndex];
				destinationIndex++;
				sourceIndex++;
			}
		}

		public void MixFrom(float[] sourceArray, int destinationIndex, int sourceIndex, int length)
		{
			length += sourceIndex;
			destinationIndex += _offset;
			while (sourceIndex < length)
			{
				_parentArray[destinationIndex] += sourceArray[sourceIndex];
				destinationIndex++;
				sourceIndex++;
			}
		}

		public void MixTo(GATData destination, int destinationIndex, int sourceIndex, int length)
		{
			float[] parentArray = destination._parentArray;
			sourceIndex += _offset;
			length += sourceIndex;
			destinationIndex += destination._offset;
			while (sourceIndex < length)
			{
				parentArray[destinationIndex] += _parentArray[sourceIndex];
				destinationIndex++;
				sourceIndex++;
			}
		}

		public void GainMixTo(GATData destinationData, int sourceIndex, int destinationIndex, int length, float gain)
		{
			sourceIndex += _offset;
			length += sourceIndex;
			float[] parentArray = destinationData.ParentArray;
			destinationIndex += destinationData._offset;
			while (sourceIndex < length)
			{
				parentArray[destinationIndex] += _parentArray[sourceIndex] * gain;
				sourceIndex++;
				destinationIndex++;
			}
		}

		public void GainMixToInterlaced(float[] destinationArray, int destinationOffset, int sourceIndex, int length, GATChannelGain channelGain)
		{
			if (destinationOffset < 0)
			{
				Debug.LogErrorFormat("[GATData] Caught invalid mix to destinationOffset {0}", destinationOffset);
				destinationOffset = 0;
			}
			if (sourceIndex < 0)
			{
				Debug.LogErrorFormat("[GATData] Caught invalid mix from sourceIndex {0}.", sourceIndex);
				sourceIndex = 0;
			}
			int a = (destinationArray.Length - destinationOffset) / GATInfo.NbOfChannels;
			int b = _parentArray.Length - (sourceIndex + _offset);
			int num = Mathf.Min(a, b);
			if (length > num)
			{
				Debug.LogErrorFormat("[GATData] Caught invalid mix of {0} samples from index {1} of {2}, to index {3} of {4}.", length, sourceIndex + _offset, _parentArray.Length, destinationOffset, destinationArray.Length);
				length = num;
			}
			sourceIndex += _offset;
			length = sourceIndex + length;
			destinationOffset += channelGain.ChannelNumber;
			if (UseNativeGainMixToInterlaced)
			{
				GCHandle gCHandle = GCHandle.Alloc(destinationArray, GCHandleType.Pinned);
				GCHandle gCHandle2 = GCHandle.Alloc(_parentArray, GCHandleType.Pinned);
				NativeGainMixToInterlaced(gCHandle.AddrOfPinnedObject(), destinationOffset, GATInfo.NbOfChannels, gCHandle2.AddrOfPinnedObject(), sourceIndex, length, channelGain.Gain);
				gCHandle.Free();
				gCHandle2.Free();
			}
			else
			{
				while (sourceIndex < length && destinationOffset >= 0 && destinationOffset < destinationArray.Length && sourceIndex >= 0 && sourceIndex < _parentArray.Length)
				{
					destinationArray[destinationOffset] += _parentArray[sourceIndex] * channelGain.Gain;
					destinationOffset += GATInfo.NbOfChannels;
					sourceIndex++;
				}
			}
		}

		public void GainMixToInterlaced(float[] destinationArray, int destinationOffset, int sourceIndex, int length, GATChannelGain channelGain, float igain)
		{
			if (destinationOffset < 0)
			{
				Debug.LogErrorFormat("[GATData] Caught invalid mix to destinationOffset {0}", destinationOffset);
				destinationOffset = 0;
			}
			if (sourceIndex < 0)
			{
				Debug.LogErrorFormat("[GATData] Caught invalid mix from sourceIndex {0}.", sourceIndex);
				sourceIndex = 0;
			}
			int a = (destinationArray.Length - destinationOffset) / GATInfo.NbOfChannels;
			int b = _parentArray.Length - (sourceIndex + _offset);
			int num = Mathf.Min(a, b);
			if (length > num)
			{
				Debug.LogErrorFormat("[GATData] Caught invalid mix of {0} samples from index {1} of {2}, to index {3} of {4}.", length, sourceIndex + _offset, _parentArray.Length, destinationOffset, destinationArray.Length);
				length = num;
			}
			sourceIndex += _offset;
			length = sourceIndex + length;
			destinationOffset += channelGain.ChannelNumber;
			float num2 = igain * channelGain.Gain;
			if (UseNativeGainMixToInterlaced)
			{
				GCHandle gCHandle = GCHandle.Alloc(destinationArray, GCHandleType.Pinned);
				GCHandle gCHandle2 = GCHandle.Alloc(_parentArray, GCHandleType.Pinned);
				NativeGainMixToInterlaced(gCHandle.AddrOfPinnedObject(), destinationOffset, GATInfo.NbOfChannels, gCHandle2.AddrOfPinnedObject(), sourceIndex, length, num2);
				gCHandle.Free();
				gCHandle2.Free();
			}
			else
			{
				while (sourceIndex < length && destinationOffset >= 0 && destinationOffset < destinationArray.Length && sourceIndex >= 0 && sourceIndex < _parentArray.Length)
				{
					destinationArray[destinationOffset] += _parentArray[sourceIndex] * num2;
					destinationOffset += GATInfo.NbOfChannels;
					sourceIndex++;
				}
			}
		}

		public void GainCopyToInterlaced(float[] destinationArray, int destinationOffset, int sourceIndex, int length, GATChannelGain channelGain)
		{
			sourceIndex += _offset;
			length = sourceIndex + length;
			destinationOffset += channelGain.ChannelNumber;
			while (sourceIndex < length)
			{
				destinationArray[destinationOffset] = _parentArray[sourceIndex] * channelGain.Gain;
				destinationOffset += GATInfo.NbOfChannels;
				sourceIndex++;
			}
		}

		public void CopyToInterlaced(float[] destinationArray, int destinationOffset, int sourceIndex, int length, int channelNb)
		{
			sourceIndex += _offset;
			length = sourceIndex + length;
			destinationOffset += channelNb;
			while (sourceIndex < length)
			{
				destinationArray[destinationOffset] = _parentArray[sourceIndex];
				destinationOffset += GATInfo.NbOfChannels;
				sourceIndex++;
			}
		}

		public void SmoothedGainMixToInterlaced(float[] destinationArray, int destinationOffset, int sourceIndex, int length, GATDynamicChannelGain channelGain)
		{
			float num = channelGain.PrevGain;
			float interpolationDelta = channelGain.InterpolationDelta;
			sourceIndex += _offset;
			length = sourceIndex + length;
			destinationOffset += channelGain.ChannelNumber;
			int nbOfChannels = GATInfo.NbOfChannels;
			length = Mathf.Min(length, _parentArray.Length);
			int num2 = Mathf.Max(length - sourceIndex - 1, 0);
			int num3 = destinationOffset + num2 * nbOfChannels;
			if (num3 >= destinationArray.Length)
			{
				int num4 = Mathf.CeilToInt((float)(1 + (num3 - destinationArray.Length)) / (float)nbOfChannels);
				length -= num4;
			}
			while (sourceIndex < length)
			{
				destinationArray[destinationOffset] += _parentArray[sourceIndex] * num;
				destinationOffset += nbOfChannels;
				num += interpolationDelta;
				sourceIndex++;
			}
		}

		public void SmoothedGainMixToInterlaced(float[] destinationArray, int destinationOffset, int sourceIndex, int length, GATDynamicChannelGain channelGain, float igain)
		{
			float num = channelGain.PrevGain;
			float interpolationDelta = channelGain.InterpolationDelta;
			sourceIndex += _offset;
			length = sourceIndex + length;
			destinationOffset += channelGain.ChannelNumber;
			int nbOfChannels = GATInfo.NbOfChannels;
			length = Mathf.Min(length, _parentArray.Length);
			int num2 = Mathf.Max(length - sourceIndex - 1, 0);
			int num3 = destinationOffset + num2 * nbOfChannels;
			if (num3 >= destinationArray.Length)
			{
				int num4 = Mathf.CeilToInt((float)(1 + (num3 - destinationArray.Length)) / (float)nbOfChannels);
				length -= num4;
			}
			while (sourceIndex < length)
			{
				destinationArray[destinationOffset] += _parentArray[sourceIndex] * num * igain;
				destinationOffset += nbOfChannels;
				num += interpolationDelta;
				sourceIndex++;
			}
		}

		public void SmoothedGainCopyToInterlaced(float[] destinationArray, int destinationOffset, int sourceIndex, int length, GATDynamicChannelGain channelGain)
		{
			float num = channelGain.PrevGain;
			float interpolationDelta = channelGain.InterpolationDelta;
			sourceIndex += _offset;
			length = sourceIndex + length;
			destinationOffset += channelGain.ChannelNumber;
			while (sourceIndex < length)
			{
				destinationArray[destinationOffset] = _parentArray[sourceIndex] * num;
				destinationOffset += GATInfo.NbOfChannels;
				num += interpolationDelta;
				sourceIndex++;
			}
		}

		public void MixSmoothedGainFrom(float[] sourceArray, int sourceIndex, int destinationIndex, int length, float fromGain, float toGain)
		{
			float num = (toGain - fromGain) / (float)length;
			destinationIndex += _offset;
			length += sourceIndex;
			while (sourceIndex < length)
			{
				_parentArray[destinationIndex] += sourceArray[sourceIndex] * fromGain;
				fromGain += num;
				destinationIndex++;
				sourceIndex++;
			}
		}

		public void MixSmoothedGainTo(int sourceIndex, GATData destination, int destinationIndex, int length, float fromGain, float toGain)
		{
			float num = (toGain - fromGain) / (float)length;
			destinationIndex += destination._offset;
			sourceIndex += _offset;
			length += sourceIndex;
			float[] parentArray = destination._parentArray;
			while (sourceIndex < length)
			{
				parentArray[destinationIndex] += _parentArray[sourceIndex] * fromGain;
				fromGain += num;
				destinationIndex++;
				sourceIndex++;
			}
		}

		public void SmoothedGain(int fromIndex, int length, float fromGain, float toGain)
		{
			float num = (toGain - fromGain) / (float)length;
			fromIndex += _offset;
			length += fromIndex;
			while (fromIndex < length)
			{
				_parentArray[fromIndex] *= fromGain;
				fromGain += num;
				fromIndex++;
			}
		}

		public void Gain(int fromIndex, int length, float gain)
		{
			fromIndex += _offset;
			length += _offset;
			while (fromIndex < length)
			{
				_parentArray[fromIndex] *= gain;
				fromIndex++;
			}
		}

		public void FadeIn(int fadeLength)
		{
			if (fadeLength > Count)
			{
				fadeLength = Count;
			}
			float num = 1f / (float)fadeLength;
			int num2 = _offset;
			for (int i = 0; i < fadeLength; i++)
			{
				_parentArray[num2] *= (float)i * num;
				num2++;
			}
		}

		public void FadeInSquared(int fadeLength)
		{
			if (fadeLength > Count)
			{
				fadeLength = Count;
			}
			float num = 1f / (float)fadeLength;
			int num2 = _offset;
			for (int i = 0; i < fadeLength; i++)
			{
				float num3 = (float)i * num;
				num3 *= num3;
				_parentArray[num2] *= num3;
				num2++;
			}
		}

		public void FadeOut(int fadeLength)
		{
			if (fadeLength > Count)
			{
				fadeLength = Count;
			}
			float num = 1f / (float)fadeLength;
			int num2 = _offset + Count - fadeLength;
			for (int i = 0; i < fadeLength; i++)
			{
				_parentArray[num2] *= 1f - (float)i * num;
				num2++;
			}
		}

		public void FadeOutSquared(int fadeLength)
		{
			if (fadeLength > Count)
			{
				fadeLength = Count;
			}
			float num = 1f / (float)fadeLength;
			int num2 = _offset + Count - fadeLength;
			for (int i = 0; i < fadeLength; i++)
			{
				float num3 = 1f - (float)i * num;
				num3 *= num3;
				_parentArray[num2] *= num3;
				num2++;
			}
		}

		public void FadeOut(int offset, int fadeLength)
		{
			if (offset + fadeLength > Count)
			{
				fadeLength = Count - offset;
			}
			float num = 1f / (float)fadeLength;
			offset += _offset;
			for (int i = 0; i < fadeLength; i++)
			{
				_parentArray[offset] *= 1f - (float)i * num;
				offset++;
			}
		}

		public void Fade(float fromGain, float toGain, int fadeLength, int offset = 0)
		{
			if (offset + fadeLength > Count)
			{
				fadeLength = Count - offset;
			}
			offset += _offset;
			float num = (toGain - fromGain) / (float)fadeLength;
			float num2 = fromGain;
			for (int i = 0; i < fadeLength; i++)
			{
				_parentArray[offset] *= num2;
				offset++;
				num2 += num;
			}
		}

		public void Normalize(float normalizedMax)
		{
			float num = 0f;
			int num2 = _offset + Count;
			for (int i = _offset; i < num2; i++)
			{
				if (_parentArray[i] > num)
				{
					num = _parentArray[i];
				}
			}
			float num3 = normalizedMax / num;
			for (int i = _offset; i < num2; i++)
			{
				_parentArray[i] *= num3;
			}
		}

		public void ResampleCopyTo(int sourceIndex, GATData destinationSample, int targetLength, double resamplingFactor)
		{
			sourceIndex += _offset;
			destinationSample.ResampleCopyFrom(_parentArray, sourceIndex, targetLength, 0, resamplingFactor);
		}

		public double ResampleCopyFrom(float[] sourceArray, double trueInterpolatedIndex, int targetLength, int targetOffset, double resamplingFactor, bool readOnly = false)
		{
			int num = _offset + targetOffset;
			targetLength += num;
			if (!readOnly)
			{
				while (num < targetLength)
				{
					int num2 = (int)trueInterpolatedIndex;
					double num3 = trueInterpolatedIndex - (double)num2;
					float num4 = sourceArray[num2];
					_parentArray[num] = num4 + (sourceArray[num2 + 1] - num4) * (float)num3;
					num++;
					trueInterpolatedIndex += resamplingFactor;
				}
			}
			else
			{
				trueInterpolatedIndex += (double)(targetLength - num) * resamplingFactor;
			}
			return trueInterpolatedIndex;
		}

		public double ResampleCopyFrom(short[] sourceArray, int sourceLength, int sourceOffset, bool sourceLoops, double trueInterpolatedIndex, int targetLength, int targetOffset, double resamplingFactor, bool readOnly = false)
		{
			int num = _offset + targetOffset;
			targetLength += num;
			if (targetLength > _parentArray.Length)
			{
				Debug.LogErrorFormat("[GATData] Caught illegal copy! _parentArray[{0} + {1} -> {2}], length = {3}.", _offset, targetOffset, targetLength, _parentArray.Length);
				targetLength = _parentArray.Length;
			}
			int num2 = targetLength - num;
			int num3 = (int)(trueInterpolatedIndex + resamplingFactor * (double)(num2 - 1));
			if (num3 >= sourceArray.Length)
			{
				Debug.LogErrorFormat("GATData: Caught illegal copy! sourceArray[{0} -> {1}], length = {2}.", (int)trueInterpolatedIndex, num3, sourceArray.Length);
			}
			num3 = sourceArray.Length - 1;
			if (!readOnly)
			{
				if (UseNativeResampleCopyFrom)
				{
					GCHandle gCHandle = GCHandle.Alloc(sourceArray, GCHandleType.Pinned);
					GCHandle gCHandle2 = GCHandle.Alloc(_parentArray, GCHandleType.Pinned);
					trueInterpolatedIndex = NativeResampleCopyFromInt16(gCHandle.AddrOfPinnedObject(), sourceLength, sourceOffset, num3, sourceLoops, (float)trueInterpolatedIndex, gCHandle2.AddrOfPinnedObject(), targetLength, num, (float)resamplingFactor);
					gCHandle.Free();
					gCHandle2.Free();
				}
				else
				{
					while (num < targetLength)
					{
						int num4 = Mathf.Min(num3, (int)trueInterpolatedIndex);
						int num5 = num4 + 1;
						if (num5 >= sourceOffset + sourceLength)
						{
							num5 = ((!sourceLoops) ? num4 : (num5 - sourceLength));
						}
						float num6 = (float)trueInterpolatedIndex - (float)num4;
						float num7 = (float)sourceArray[num4] * (1f - num6);
						_parentArray[num] = (num7 + (float)sourceArray[num5] * num6) * GATWavHelper.int16ToFloatRescaleFactor;
						num++;
						trueInterpolatedIndex += resamplingFactor;
					}
				}
			}
			else
			{
				trueInterpolatedIndex += (double)(targetLength - num) * resamplingFactor;
			}
			return trueInterpolatedIndex;
		}

		public double ResampleCopyTo(double trueInterpolatedIndex, GATData destinationSample, int targetLength, double resamplingFactor)
		{
			return destinationSample.ResampleCopyFrom(_parentArray, trueInterpolatedIndex, targetLength, 0, resamplingFactor);
		}

		public void ApplyFilter(AGATFilter filter, int fromIndex, int length, bool emptyData)
		{
			fromIndex += _offset;
			filter.ProcessChunk(_parentArray, fromIndex, length, emptyData);
		}

		public void Clear(int fromIndex, int length)
		{
			Array.Clear(_parentArray, _offset + fromIndex, length);
		}

		public void Clear()
		{
			Array.Clear(_parentArray, _offset, Count);
		}

		public void ClearInterlaced(int channelNb, int nbOfInterlacedChannels, int length)
		{
			int i = _offset + channelNb;
			for (length += i; i < length; i += nbOfInterlacedChannels)
			{
				_parentArray[i] = 0f;
			}
		}

		public void Reverse()
		{
			Array.Reverse(_parentArray, _offset, Count);
		}

		public void Reverse(int offset, int length)
		{
			Array.Reverse(_parentArray, _offset + offset, length);
		}

		public int NextZeroCrossing(int fromIndex, out bool positive)
		{
			fromIndex += _offset;
			if (_parentArray[fromIndex] < 0f)
			{
				while (_parentArray[fromIndex] < 0f)
				{
					fromIndex++;
				}
				positive = true;
				return fromIndex - _offset;
			}
			if (_parentArray[fromIndex] > 0f)
			{
				while (_parentArray[fromIndex] > 0f)
				{
					fromIndex++;
				}
				positive = false;
				return fromIndex - _offset;
			}
			while (_parentArray[fromIndex] == 0f)
			{
				fromIndex++;
			}
			positive = _parentArray[fromIndex] > 0f;
			return fromIndex - _offset;
		}

		public void ConvertAndSetInt16(short[] source, int sourceOffset, int targetOffset, int length)
		{
			targetOffset += _offset;
			length += sourceOffset;
			while (sourceOffset < length)
			{
				float num = (float)source[sourceOffset] / (float)GATWavHelper.floatToInt16RescaleFactor;
				_parentArray[targetOffset] = num;
				sourceOffset++;
				targetOffset++;
			}
		}

		public bool CheckSampleBounds()
		{
			for (int i = _offset; i < Count; i++)
			{
				if (_parentArray[i] > 1f || _parentArray[i] < -1f)
				{
					return false;
				}
			}
			return true;
		}

		protected override void Discard()
		{
		}

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GainMixToInterlaced")]
		private static extern void NativeGainMixToInterlaced(IntPtr destinationArray, int destinationOffset, int channelCount, IntPtr sourceArray, int sourceIndex, int length, float gain);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ResampleCopyFromInt16")]
		private static extern float NativeResampleCopyFromInt16(IntPtr sourceArray, int sourceLength, int sourceOffset, int maxSourceIndex, bool sourceLoops, float trueInterpolatedIndex, IntPtr _parentArray, int targetLength, int targetOffset, float resamplingFactor);
	}
}
