using System;
using Newtonsoft.Json.Linq;
using UIScripts.InfoHandles;

namespace Utility
{
	public class DataParallelStreamGroup<T> : DataStreamGroup<T>, IDataPointStream where T : IDataPoint
	{
		public string title;

		public string description;

		public byte width;

		public FloatValueFormat textFormat;

		private LogLikeArrayParallel<T> dataParallel;

		public DataStreamDescription[] streamElementDescriptions;

		public string groupTitle => title;

		public string groupDesc => description;

		public int nScales => data.nScales;

		public FloatValueFormat formating => textFormat;

		public int nStream => streamElementDescriptions.Length;

		public IDataPoint this[int depth, int i] => data[depth, i];

		public bool DepthHasData(int depth)
		{
			return data.ScaleHasData(depth);
		}

		public int DataAtDepth(int depth)
		{
			return data.NDataAtScale(depth);
		}

		public int DataSizeAtDepth(int depth)
		{
			return data.DataSizeAtScale(depth);
		}

		public DataParallelStreamGroup(LogLikeConfig logLikeConfig, DataStreamDescription[] streamDescriptions, Func<T[], Func<int, int>, int, T> compressFunc = null)
		{
			dataParallel = new LogLikeArrayParallel<T>(logLikeConfig, compressFunc);
			data = dataParallel;
			streamElementDescriptions = streamDescriptions;
			width = (byte)streamDescriptions.Length;
		}

		public IDataPoint PeekCurrentDataPoint()
		{
			return PeekCurrentData();
		}

		public DataStreamDescription[] GetStreamsDescriptions()
		{
			return streamElementDescriptions;
		}

		public DataStreamDescription GetStreamDescription(int i)
		{
			return streamElementDescriptions[i];
		}

		public JObject ExportToJObject()
		{
			JObject jObject = new JObject();
			T[] allData = data.GetAllData();
			int num = allData.Length;
			JArray jArray = new JArray();
			for (int i = 0; i < width; i++)
			{
				JArray jArray2 = new JArray();
				for (int j = 0; j < num; j++)
				{
					jArray2.Add(allData[j][i]);
				}
				jArray.Add(jArray2);
			}
			jObject["data"] = jArray;
			return jObject;
		}

		public override int BytesSpace()
		{
			return dataParallel.GetByteSpace(width * 4);
		}

		public override byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			T[] allData = data.GetAllData();
			int num = allData.Length;
			int nData = data.nData;
			byte[] pushCounters = data.pushCounters;
			byte[] nDataAtScale = data.nDataAtScale;
			float[] array = new float[width * nData];
			for (int i = 0; i < nData; i++)
			{
				for (int j = 0; j < width; j++)
				{
					array[j * nData + i] = allData[i][j];
				}
			}
			Buffer.BlockCopy(BitConverter.GetBytes(nData), 0, bytes, offset, 4);
			bytes[offset + 4] = width;
			bytes[offset + 5] = (byte)data.nScales;
			Buffer.BlockCopy(array, 0, bytes, offset + 6, width * num * 4);
			Buffer.BlockCopy(pushCounters, 0, bytes, offset + 6 + width * num * 4, nScales - 1);
			Buffer.BlockCopy(nDataAtScale, 0, bytes, offset + 6 + width * num * 4 + nScales - 1, nScales);
			return bytes;
		}

		public override void LoadStateBin(byte[] bytes, Version version, int offset = 0, int nBytes = -1)
		{
			if (nBytes < 1)
			{
				nBytes = bytes.Length;
			}
			if (version < Version.Parse("0.6a9"))
			{
				int num = BitConverter.ToInt32(bytes, offset);
				int num2 = BitConverter.ToInt32(bytes, offset + 4);
				int num3 = (nBytes / 4 - 2 - num2 * num) / 2;
				float[] array = new float[num * num2];
				int[] array2 = new int[num3];
				int[] array3 = new int[num3];
				byte[] array4 = new byte[num3];
				byte[] array5 = new byte[num3];
				offset += 8;
				Buffer.BlockCopy(bytes, offset, array, 0, num * num2 * 4);
				Buffer.BlockCopy(bytes, offset + num * num2 * 4, array3, 0, num3 * 4);
				Buffer.BlockCopy(bytes, offset + (num * num2 + num3) * 4, array2, 0, num3 * 4);
				T[] array6 = new T[num2];
				for (int i = 0; i < num2; i++)
				{
					for (int j = 0; j < num; j++)
					{
						ref readonly T reference = ref array6[i];
						int i2 = j;
						float value = array[j * num2 + i];
						reference[i2] = value;
					}
				}
				for (int k = 0; k < num3; k++)
				{
					array4[k] = (byte)array3[k];
				}
				for (int l = 0; l < num3; l++)
				{
					array5[l] = (byte)array2[l];
				}
				dataParallel.LoadData(array6, array5, array4);
				return;
			}
			int num4 = BitConverter.ToInt32(bytes, offset);
			byte b = bytes[offset + 4];
			byte b2 = bytes[offset + 5];
			int num5 = (nBytes - 6 - b2) / (b * 4);
			float[] array7 = new float[b * num4];
			offset += 6;
			Buffer.BlockCopy(bytes, offset + b * num5 * 4, data.pushCounters, 0, b2 - 1);
			Buffer.BlockCopy(bytes, offset + b * num5 * 4 + b2 - 1, data.nDataAtScale, 0, b2);
			Buffer.BlockCopy(bytes, offset, array7, 0, b * num4 * 4);
			T[] array8 = new T[num4];
			for (int m = 0; m < num4; m++)
			{
				for (int n = 0; n < b; n++)
				{
					ref readonly T reference2 = ref array8[m];
					int i3 = n;
					float value2 = array7[n * num4 + m];
					reference2[i3] = value2;
				}
			}
			int num6 = 0;
			for (int num7 = 0; num7 < nScales; num7++)
			{
				byte b3 = data.nDataAtScale[num7];
				if (b3 <= 0)
				{
					break;
				}
				Array.Copy(array8, num6, data.data, data.scaleOffsets[num7], b3);
				num6 += b3;
			}
			data.nData = num4;
			data.nPoints = num5;
		}
	}
}
