using System;
using System.Linq;
using ScriptHelpers;
using UnityEngine;

namespace Utility
{
	public abstract class LogLikePresenceArray<T> : LogLikeArraySerial<T>, ISaveableBin where T : new()
	{
		public ushort[] nPresentAtScale;

		public byte scaleOfApparition;

		public short indexOfApparition = -1;

		public byte scaleOfDisappearance;

		public short indexOfDisappearance = -1;

		public int totalIndexOfApparition => indexOfApparition + ((scaleOfApparition > 0) ? scaleDataSum[scaleOfApparition - 1] : 0);

		public int totalIndexOfDisappearance => indexOfDisappearance + ((scaleOfDisappearance > 0) ? scaleDataSum[scaleOfDisappearance - 1] : 0);

		public int nPointsPresent => nPresentAtScale.Sum((ushort v) => v);

		public int nPointsRelevant => nPointsPresent + pushCounters.Skip(Mathf.Max(0, scaleOfDisappearance - 1)).Take(Mathf.Max(0, scaleOfApparition - scaleOfDisappearance + 2)).Sum((byte v) => v);

		public int nPointsToSave => nPointsPresent + pushCounters.Sum((byte v) => v);

		public abstract byte sizeOfPoint { get; }

		public TimeFormat TimeFormatOfApparition()
		{
			return TimeFormatOfPoint(totalIndexOfApparition);
		}

		public TimeFormat TimeFormatOfDisappearance()
		{
			return TimeFormatOfPoint(totalIndexOfDisappearance);
		}

		public abstract bool PointIsPresent(T point);

		public LogLikePresenceArray(LogLikeConfig logLikeConfig, Func<T[], Func<int, int>, int, T> compressFunc = null)
			: base(logLikeConfig, compressFunc)
		{
			onDataPushedToScale.AddListener(NewPointPushedToScale);
			nPresentAtScale = new ushort[nScales];
		}

		private void NewPointPushedToScale(T point, int i)
		{
			if (PointIsPresent(point))
			{
				if (i > scaleOfApparition)
				{
					scaleOfApparition = (byte)i;
					indexOfApparition = -1;
				}
				if (i <= scaleOfDisappearance && indexOfDisappearance >= 0)
				{
					scaleOfDisappearance = (byte)i;
					indexOfDisappearance = -1;
					for (int j = scaleOfDisappearance; j <= scaleOfApparition; j++)
					{
						nPresentAtScale[j] = ((j == scaleOfApparition) ? ((ushort)(indexOfApparition + 1)) : ((ushort)DataSizeAtScale(j)));
					}
				}
			}
			else
			{
				if (i > scaleOfDisappearance && indexOfDisappearance >= DataSizeAtScale(scaleOfDisappearance) - 1)
				{
					scaleOfDisappearance = (byte)i;
					indexOfDisappearance = -1;
				}
				if (i == scaleOfDisappearance && indexOfDisappearance < DataSizeAtScale(i) - 1)
				{
					indexOfDisappearance++;
					nPresentAtScale[i]--;
				}
			}
			if (i == scaleOfApparition && indexOfApparition < DataSizeAtScale(i) - 1)
			{
				indexOfApparition++;
				nPresentAtScale[i]++;
			}
		}

		public void RefreshPresentsFromIndices()
		{
			for (int i = scaleOfDisappearance; i <= scaleOfApparition; i++)
			{
				if (i >= scaleOfDisappearance)
				{
					if (i < scaleOfApparition - 1)
					{
						nDataAtScale[i] = (byte)dataSizes[i];
					}
					int num = ((i == scaleOfDisappearance) ? (indexOfDisappearance + 1) : 0);
					int num2 = ((i == scaleOfApparition) ? indexOfApparition : (DataSizeAtScale(i) - 1));
					nPresentAtScale[i] = (ushort)Mathf.Clamp(num2 - num + 1, 0, DataSizeAtScale(i));
					if (i == scaleOfApparition && i < nScales - 1)
					{
						nDataAtScale[i] = (byte)nPresentAtScale[i];
					}
				}
			}
		}

		public int BytesSpace()
		{
			int num = scaleOfApparition + 1;
			return 6 + 3 * num + nPointsToSave * sizeOfPoint;
		}

		public byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			int num = nPointsToSave;
			byte b = (byte)(scaleOfApparition + 1);
			Buffer.BlockCopy(BitConverter.GetBytes(indexOfApparition), 0, bytes, offset, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(indexOfDisappearance), 0, bytes, offset + 2, 2);
			bytes[offset + 4] = scaleOfDisappearance;
			bytes[offset + 5] = b;
			offset += 6;
			if (num < 1)
			{
				return bytes;
			}
			Buffer.BlockCopy(nPresentAtScale, 0, bytes, offset, 2 * b);
			Buffer.BlockCopy(pushCounters, 0, bytes, offset + 2 * b, b);
			offset += 3 * b;
			Array[] arrays = CreateTempArrays(num);
			int num2 = 0;
			for (int i = 0; i <= scaleOfApparition; i++)
			{
				int num3 = ((i == scaleOfDisappearance) ? (indexOfDisappearance + 1) : 0);
				int num4 = ((i == scaleOfApparition) ? indexOfApparition : (DataSizeAtScale(i) - 1));
				if (i >= scaleOfDisappearance && num3 >= 0 && num4 >= 0)
				{
					for (int j = num3; j <= num4; j++)
					{
						SavePointToArrays(arrays, base[i, j], num2++);
					}
				}
				if (i == nScales - 1)
				{
					break;
				}
				int num5 = dataSizes[i] + pushCounters[i];
				for (int k = dataSizes[i]; k < num5; k++)
				{
					SavePointToArrays(arrays, base[i, k], num2++);
				}
			}
			SaveArraysToBin(arrays, bytes, offset, num);
			return bytes;
		}

		public void LoadStateBin(byte[] bytes, Version version, int offset = 0, int nBytes = -1)
		{
			indexOfApparition = BitConverter.ToInt16(bytes, offset);
			indexOfDisappearance = BitConverter.ToInt16(bytes, offset + 2);
			scaleOfDisappearance = bytes[offset + 4];
			byte b = bytes[offset + 5];
			scaleOfApparition = (byte)(b - 1);
			offset += 6;
			if (b < 1)
			{
				scaleOfApparition = 0;
				return;
			}
			Buffer.BlockCopy(bytes, offset, nPresentAtScale, 0, 2 * b);
			Buffer.BlockCopy(bytes, offset + 2 * b, pushCounters, 0, b);
			offset += 3 * b;
			int num = nPointsToSave;
			if (num < 1)
			{
				return;
			}
			if (isInfinite && nPresentAtScale[^1] > 0)
			{
				for (int i = 0; i <= indexOfApparition; i++)
				{
					infiniteData.Add(new T());
				}
			}
			Array[] arrays = CreateTempArrays(num);
			LoadArraysFromBin(arrays, bytes, version, offset, num);
			int num2 = 0;
			for (int j = 0; j <= scaleOfApparition; j++)
			{
				int num3 = ((j == scaleOfDisappearance) ? (indexOfDisappearance + 1) : 0);
				int num4 = ((j == scaleOfApparition) ? indexOfApparition : (DataSizeAtScale(j) - 1));
				if (j >= scaleOfDisappearance && num3 >= 0 && num4 >= 0)
				{
					for (int k = num3; k <= num4; k++)
					{
						base[j, k] = LoadPointFromArrays(arrays, num2++);
					}
				}
				if (j == nScales - 1)
				{
					break;
				}
				int num5 = dataSizes[j] + pushCounters[j];
				for (int l = dataSizes[j]; l < num5; l++)
				{
					base[j, l] = LoadPointFromArrays(arrays, num2++);
				}
			}
			for (int m = 0; m <= scaleOfApparition && (!isInfinite || m != nScales - 1); m++)
			{
				if (m == scaleOfApparition)
				{
					nDataAtScale[m] = (byte)(indexOfApparition + 1);
				}
				else
				{
					nDataAtScale[m] = (byte)dataSizes[m];
				}
			}
		}

		protected abstract Array[] CreateTempArrays(int nPointsSaved);

		protected abstract void SavePointToArrays(Array[] arrays, T point, int arrayIndexOffset);

		protected abstract T LoadPointFromArrays(Array[] arrays, int arrayIndexOffset);

		protected abstract void SaveArraysToBin(Array[] arrays, byte[] bytes, int offset, int nPointsSaved);

		protected abstract void LoadArraysFromBin(Array[] arrays, byte[] bytes, Version version, int offset, int nPointsSaved);
	}
}
