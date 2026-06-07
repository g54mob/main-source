using System;
using Newtonsoft.Json.Linq;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace Utility
{
	public class GenesBucketsStreamGroup : DataStreamGroup<GenesBuckets>
	{
		private LogLikeArraySerial<GenesBuckets> dataSerial;

		public GenesBucketPoint this[int depth, int i] => data[depth][i];

		public GenesBuckets this[int depth] => data[depth];

		public GenesBucketsStreamGroup()
		{
			dataSerial = new LogLikeArraySerial<GenesBuckets>(DataLogger.SerialHeavyConfig, CompressGeneBuckets);
			data = dataSerial;
		}

		public JObject ExportToJson()
		{
			JObject jObject = new JObject();
			GenesBuckets[] allData = data.GetAllData();
			int num = allData.Length;
			JObject jObject2 = new JObject();
			string[] names = Enum.GetNames(typeof(BibiteGenes.Genes));
			foreach (string text in names)
			{
				int i2 = (int)Enum.Parse(typeof(BibiteGenes.Genes), text);
				JArray jArray = new JArray();
				for (int j = 0; j < num; j++)
				{
					jArray.Add(JToken.FromObject(allData[j][i2].data));
				}
				jObject2[text] = jArray;
			}
			jObject["data"] = jObject2;
			return jObject;
		}

		public GenesBuckets CompressGeneBuckets(GenesBuckets[] array, Func<int, int> remap, int n)
		{
			int nGene = BibiteGenes.NGene;
			int num = 20;
			GenesBuckets result = new GenesBuckets
			{
				data = new GenesBucketPoint[nGene]
			};
			int[] array2 = new int[n];
			for (int i = 0; i < n; i++)
			{
				array2[i] = remap(i);
			}
			for (int j = 0; j < nGene; j++)
			{
				float span = BibiteEditorSettings.SettingOfGene(j).span;
				float num2 = float.MaxValue;
				float num3 = float.MinValue;
				for (int k = 0; k < n; k++)
				{
					num2 = Mathf.Min(num2, array[array2[k]][j].min);
					num3 = Mathf.Max(num3, array[array2[k]][j].max);
				}
				GenesBucketPoint genesBucketPoint = new GenesBucketPoint(num);
				genesBucketPoint.min = num2;
				genesBucketPoint.max = num3;
				GenesBucketPoint value = genesBucketPoint;
				float num4 = (float)Mathf.Max(1, Mathf.CeilToInt(5f * (num3 - num2) / span)) / 5f * span / (float)num;
				float[] array3 = new float[num];
				for (int l = 0; l < n; l++)
				{
					GenesBucketPoint genesBucketPoint2 = array[array2[l]][j];
					float num5 = Mathf.Max(1f, Mathf.Ceil(5f * (num3 - num2) / span)) / 5f * span / (float)num;
					float num6 = (genesBucketPoint2.min - num2) / num4;
					float num7 = num5 / num4;
					for (int m = 0; m < num; m++)
					{
						int num8 = Mathf.CeilToInt(num6 + (float)m * num7);
						float num9 = (num2 + (float)num8 * num4 - genesBucketPoint2.min - (float)m * num5) / num5;
						if (num8 > num)
						{
							break;
						}
						array3[Mathf.Max(num8 - 1, 0)] += num9 * (float)(int)genesBucketPoint2[m];
						if (num8 < num)
						{
							array3[num8] += (1f - num9) * (float)(int)genesBucketPoint2[m];
						}
					}
				}
				for (int num10 = 0; num10 < num; num10++)
				{
					value[num10] = (ushort)(array3[num10] / (float)n);
				}
				result[j] = value;
			}
			return result;
		}

		public override int BytesSpace()
		{
			int num = data.nPoints * BibiteGenes.NGene * 48;
			int num2 = 2 * data.nScales - 1;
			return 16 + num + num2;
		}

		public override byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			GenesBuckets[] allData = data.GetAllData(includeAccumulators: true);
			int num = allData.Length;
			int nGene = BibiteGenes.NGene;
			int num2 = 20;
			int num3 = 48;
			Buffer.BlockCopy(BitConverter.GetBytes(allData.Length), 0, bytes, offset, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(data.nData), 0, bytes, offset + 4, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(num2), 0, bytes, offset + 8, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(nGene), 0, bytes, offset + 12, 4);
			offset += 16;
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < nGene; j++)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(allData[i][j].min), 0, bytes, offset, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(allData[i][j].max), 0, bytes, offset + 4, 4);
					Buffer.BlockCopy(allData[i][j].data, 0, bytes, offset + 8, num2 * 2);
					offset += num3;
				}
			}
			int nScales = data.nScales;
			Buffer.BlockCopy(data.pushCounters, 0, bytes, offset, nScales - 1);
			Buffer.BlockCopy(data.nDataAtScale, 0, bytes, offset + nScales - 1, nScales);
			return bytes;
		}

		public override void LoadStateBin(byte[] bytes, Version version, int offset = 0, int nBytes = -1)
		{
			if (version < new Version(0, 6, 0, 9))
			{
				int num = BitConverter.ToInt32(bytes, offset);
				int num2 = BitConverter.ToInt32(bytes, offset + 4);
				int num3 = BitConverter.ToInt32(bytes, offset + 8);
				int num4 = 48;
				int nGene = BibiteGenes.NGene;
				GenesBuckets[] array = new GenesBuckets[num];
				offset += 12;
				for (int i = 0; i < num; i++)
				{
					array[i] = new GenesBuckets(nGene);
					for (int j = 0; j < num3; j++)
					{
						GenesBucketPoint value = array[i][j];
						value.min = BitConverter.ToSingle(bytes, offset);
						value.max = BitConverter.ToSingle(bytes, offset + 4);
						Buffer.BlockCopy(bytes, offset + 8, value.data, 0, num2 * 2);
						array[i][j] = value;
						offset += num4;
					}
				}
				int num5 = BitConverter.ToInt32(bytes, offset);
				int[] array2 = new int[num5];
				Buffer.BlockCopy(bytes, offset + 4, array2, 0, num5 * 4);
				byte[] array3 = new byte[num5];
				for (int k = 0; k < num5; k++)
				{
					array3[k] = (byte)array2[k];
				}
				dataSerial.LoadDataWithoutAcc(array, array3);
				return;
			}
			int num6 = BitConverter.ToInt32(bytes, offset);
			int nData = BitConverter.ToInt32(bytes, offset + 4);
			int num7 = BitConverter.ToInt32(bytes, offset + 8);
			int num8 = BitConverter.ToInt32(bytes, offset + 12);
			int num9 = 48;
			data.nData = nData;
			data.nPoints = num6;
			int nGene2 = BibiteGenes.NGene;
			offset += 16;
			for (int l = 0; l < num6; l++)
			{
				data.data[l] = new GenesBuckets(nGene2);
				for (int m = 0; m < num8; m++)
				{
					data.data[l][m] = new GenesBucketPoint(nGene2)
					{
						min = BitConverter.ToSingle(bytes, offset),
						max = BitConverter.ToSingle(bytes, offset + 4)
					};
					Buffer.BlockCopy(bytes, offset + 8, data.data[l][m].data, 0, num7 * 2);
					offset += num9;
				}
			}
			int num10 = (nBytes + 1 - 16 - num6 * num8 * num9) / 2;
			Buffer.BlockCopy(bytes, offset, data.pushCounters, 0, num10 - 1);
			Buffer.BlockCopy(bytes, offset + num10 - 1, data.nDataAtScale, 0, num10);
		}
	}
}
