using System.IO;
using Utility;

namespace ScriptHelpers
{
	public static class DataBucketExporter
	{
		public static void ExportData(this DataLoggerBucket<float> bucket, string path, string title)
		{
			string text = "";
			int num = bucket.nChildren + 1;
			int num2 = 0;
			if (bucket.serialFeeding)
			{
				text += "timeago; data\n";
				int num3 = 1;
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < bucket.size; j++)
					{
						text += $"{num2};{bucket.data[j]:0.00}\n";
						num2 += num3;
					}
					num3 *= bucket.feedRatio;
					if (i < num - 1)
					{
						bucket = bucket.feedingBucket;
					}
				}
			}
			else
			{
				DataLoggerBucket<float>[] array = new DataLoggerBucket<float>[num];
				int[] array2 = new int[num];
				array[0] = bucket;
				text += "timeago;scale 1";
				array2[0] = 1;
				for (int k = 1; k < num; k++)
				{
					array2[k] = array2[k - 1] * array[k - 1].feedRatio;
					text += $";scale {array2[k]}";
					array[k] = array[k - 1].feedingBucket;
				}
				text += "\n";
				int num4 = 0;
				int num5 = 1;
				while (num4 < num)
				{
					text += $"{num2}";
					for (int l = 0; l < num; l++)
					{
						int num6 = num2 / array2[l];
						text = ((num6 <= array[l].size - 1) ? (text + ((num2 % array2[l] == 0) ? $";{array[l].data[num6]}" : ";")) : (text + ";"));
					}
					text += "\n";
					if (num2 / array2[num4] > array[num4].size - 1)
					{
						num4++;
						if (num4 < num)
						{
							num5 = array2[num4];
							num2 = (num2 / num5 + 1) * num5;
						}
					}
					else
					{
						num2 += num5;
					}
				}
			}
			File.WriteAllText(Path.Combine(path, title + ".csv"), text);
		}

		public static void ExportData(this DataLoggerBucket<int> bucket, string path, string title)
		{
			string text = "";
			int num = bucket.nChildren + 1;
			int num2 = 0;
			if (bucket.serialFeeding)
			{
				text += "timeago; data\n";
				int num3 = 1;
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < bucket.size; j++)
					{
						text += $"{num2};{bucket.data[j]}\n";
						num2 += num3;
					}
					num3 *= bucket.feedRatio;
					if (i < num - 1)
					{
						bucket = bucket.feedingBucket;
					}
				}
			}
			else
			{
				DataLoggerBucket<int>[] array = new DataLoggerBucket<int>[num];
				int[] array2 = new int[num];
				array[0] = bucket;
				text += "timeago;scale 1";
				array2[0] = 1;
				for (int k = 1; k < num; k++)
				{
					array2[k] = array2[k - 1] * array[k - 1].feedRatio;
					text += $";scale {array2[k]}";
					array[k] = array[k - 1].feedingBucket;
				}
				text += "\n";
				int num4 = 0;
				int num5 = 1;
				while (num4 < num)
				{
					text += $"{num2}";
					for (int l = 0; l < num; l++)
					{
						int num6 = num2 / array2[l];
						text = ((num6 <= array[l].size - 1) ? (text + ((num2 % array2[l] == 0) ? $";{array[l].data[num6]}" : ";")) : (text + ";"));
					}
					text += "\n";
					if (num2 / array2[num4] > array[num4].size - 1)
					{
						num4++;
						if (num4 < num)
						{
							num5 = array2[num4];
							num2 = (num2 / num5 + 1) * num5;
						}
					}
					else
					{
						num2 += num5;
					}
				}
			}
			File.WriteAllText(Path.Combine(path, title + ".csv"), text);
		}
	}
}
