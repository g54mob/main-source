using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageDataSerializer
	{
		public static FoliageDataRuntime LoadFromFileRuntime(string filename)
		{
			FoliageData foliageData = LoadFromFileEditTime(filename);
			FoliageDataRuntime foliageDataRuntime = new FoliageDataRuntime();
			foreach (KeyValuePair<int, FoliageCellData> foliageDatum in foliageData.m_FoliageData)
			{
				FoliageCellData value = foliageDatum.Value;
				FoliageCellDataRuntime foliageCellDataRuntime = new FoliageCellDataRuntime();
				foliageCellDataRuntime.m_Bounds = value.m_BoundsExtended;
				foliageCellDataRuntime.m_Position = value.m_Position;
				int num = -1;
				foliageCellDataRuntime.m_TypeHashLocationsRuntime = new FoliageKeyValuePair<int, FoliageTuple<FoliageInstance[]>>[value.m_TypeHashLocationsEditor.Count];
				foreach (KeyValuePair<int, Dictionary<string, List<FoliageInstance>>> item in value.m_TypeHashLocationsEditor)
				{
					num++;
					List<FoliageInstance> list = new List<FoliageInstance>();
					foreach (List<FoliageInstance> value4 in item.Value.Values)
					{
						list.AddRange(value4);
					}
					for (int i = 0; i < list.Count; i++)
					{
						FoliageInstance value2 = list[i];
						value2.BuildWorldMatrix();
						list[i] = value2;
					}
					list.TrimExcess();
					foliageCellDataRuntime.m_TypeHashLocationsRuntime[num] = new FoliageKeyValuePair<int, FoliageTuple<FoliageInstance[]>>(item.Key, new FoliageTuple<FoliageInstance[]>(list.ToArray()));
				}
				List<FoliageKeyValuePair<int, FoliageCellSubdividedDataRuntime>> list2 = new List<FoliageKeyValuePair<int, FoliageCellSubdividedDataRuntime>>(value.m_FoliageDataSubdivided.Count);
				foreach (KeyValuePair<int, FoliageCellSubdividedData> item2 in value.m_FoliageDataSubdivided)
				{
					FoliageCellSubdividedData value3 = item2.Value;
					FoliageCellSubdividedDataRuntime foliageCellSubdividedDataRuntime = new FoliageCellSubdividedDataRuntime();
					foliageCellSubdividedDataRuntime.m_Bounds = value3.m_Bounds;
					foliageCellSubdividedDataRuntime.m_Position = value3.m_Position;
					num = -1;
					foliageCellSubdividedDataRuntime.m_TypeHashLocationsRuntime = new FoliageKeyValuePair<int, FoliageTuple<Matrix4x4[][]>>[value3.m_TypeHashLocationsEditor.Count];
					foreach (KeyValuePair<int, Dictionary<string, List<FoliageInstance>>> item3 in value3.m_TypeHashLocationsEditor)
					{
						num++;
						List<FoliageInstance> list3 = new List<FoliageInstance>();
						foreach (List<FoliageInstance> value5 in item3.Value.Values)
						{
							list3.AddRange(value5);
						}
						int num2 = Mathf.CeilToInt((float)list3.Count / 1000f);
						Matrix4x4[][] array = new Matrix4x4[num2][];
						for (int j = 0; j < num2; j++)
						{
							List<FoliageInstance> range = list3.GetRange(j * 1000, (j * 1000 + 1000 > list3.Count) ? (list3.Count - j * 1000) : 1000);
							array[j] = range.ConvertAll((FoliageInstance x) => x.GetWorldTransform()).ToArray();
						}
						foliageCellSubdividedDataRuntime.m_TypeHashLocationsRuntime[num] = new FoliageKeyValuePair<int, FoliageTuple<Matrix4x4[][]>>(item3.Key, new FoliageTuple<Matrix4x4[][]>(array));
					}
					list2.Add(new FoliageKeyValuePair<int, FoliageCellSubdividedDataRuntime>(item2.Key, foliageCellSubdividedDataRuntime));
				}
				foliageCellDataRuntime.m_FoliageDataSubdivided = list2.ToArray();
				foliageDataRuntime.m_FoliageData.Add(foliageDatum.Key, foliageCellDataRuntime);
			}
			return foliageDataRuntime;
		}

		public static FoliageData LoadFromFileEditTime(string filename)
		{
			if (!Directory.Exists(Application.streamingAssetsPath))
			{
				string sourceDirName = Path.Combine(Application.dataPath + "/Polyart/PolyartStudio/SharedResources/CritiasFoliage/StreamingAssets/");
				string destDirName = Path.Combine(Application.dataPath + "/StreamingAssets/");
				Directory.Move(sourceDirName, destDirName);
			}
			string text = Path.Combine(Application.streamingAssetsPath, filename);
			Debug.Log("Loading runtime foliage from file: " + text);
			FoliageData foliageData = new FoliageData();
			if (File.Exists(text))
			{
				using BinaryReader binaryReader = new BinaryReader(new BufferedStream(File.OpenRead(text)));
				ulong num = binaryReader.ReadUInt64();
				int num2 = binaryReader.ReadInt32();
				if (num == 4851020374937128009L)
				{
					Debug.Log($"Reading file with identifier: {num} and version: {num2}");
					ReadFoliageData(binaryReader, foliageData);
				}
				else
				{
					Debug.LogError("Foliage data has been tampered with! Delete it!");
				}
			}
			else
			{
				Debug.LogWarning("Warning, no grass file data exists! Save the grass!");
			}
			return foliageData;
		}

		public static void SaveToFile(string filename, FoliageData data)
		{
			Debug.Log(Application.streamingAssetsPath);
			Directory.CreateDirectory(Application.streamingAssetsPath);
			string text = Path.Combine(Application.streamingAssetsPath, filename);
			Debug.Log("Saving runtime grass to file: " + text);
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			using BinaryWriter binaryWriter = new BinaryWriter(new BufferedStream(File.Open(text, FileMode.OpenOrCreate)));
			binaryWriter.Write(4851020374937128009uL);
			binaryWriter.Write(1);
			data.RemoveEmptyData();
			WriteFoliageData(binaryWriter, data);
		}

		private static void WriteFoliageData(BinaryWriter a, FoliageData data)
		{
			Dictionary<int, FoliageCellData> foliageData = data.m_FoliageData;
			a.Write(foliageData.Count);
			foreach (int key in foliageData.Keys)
			{
				WriteFoliageCellData(a, key, foliageData[key]);
			}
		}

		private static void ReadFoliageData(BinaryReader a, FoliageData data)
		{
			int num = a.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				ReadFoliageCellData(a, out var key, out var data2);
				data.m_FoliageData.Add(key, data2);
			}
		}

		private static void ReadFoliageCellData(BinaryReader a, out int key, out FoliageCellData data)
		{
			key = a.ReadInt32();
			data = new FoliageCellData();
			data.m_Bounds = ReadBounds(a);
			data.m_BoundsExtended = ReadBounds(a);
			data.m_Position = ReadFoliageCell(a);
			int num = a.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int key2 = a.ReadInt32();
				data.m_TypeHashLocationsEditor.Add(key2, new Dictionary<string, List<FoliageInstance>>());
				int num2 = a.ReadInt32();
				for (int j = 0; j < num2; j++)
				{
					string key3 = a.ReadString();
					List<FoliageInstance> value = ReadListFoliageInstance(a, tree: true);
					data.m_TypeHashLocationsEditor[key2].Add(key3, value);
				}
			}
			int num3 = a.ReadInt32();
			for (int k = 0; k < num3; k++)
			{
				ReadFoliageCellDataSubdivided(a, out var key4, out var data2);
				data.m_FoliageDataSubdivided.Add(key4, data2);
			}
		}

		private static void WriteFoliageCellData(BinaryWriter a, int key, FoliageCellData data)
		{
			a.Write(key);
			WriteBounds(a, data.m_Bounds);
			WriteBounds(a, data.m_BoundsExtended);
			WriteFoliageCell(a, data.m_Position);
			a.Write(data.m_TypeHashLocationsEditor.Count);
			foreach (int key2 in data.m_TypeHashLocationsEditor.Keys)
			{
				a.Write(key2);
				Dictionary<string, List<FoliageInstance>> dictionary = data.m_TypeHashLocationsEditor[key2];
				a.Write(dictionary.Count);
				foreach (string key3 in dictionary.Keys)
				{
					a.Write(key3);
					WriteListFoliageInstance(a, dictionary[key3], tree: true, shuffle: true);
				}
			}
			a.Write(data.m_FoliageDataSubdivided.Count);
			foreach (int key4 in data.m_FoliageDataSubdivided.Keys)
			{
				WriteFoliageCellDataSubdivided(a, key4, data.m_FoliageDataSubdivided[key4]);
			}
		}

		private static void ReadFoliageCellDataSubdivided(BinaryReader a, out int key, out FoliageCellSubdividedData data)
		{
			key = a.ReadInt32();
			data = new FoliageCellSubdividedData();
			data.m_Bounds = ReadBounds(a);
			data.m_Position = ReadFoliageCell(a);
			int num = a.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int key2 = a.ReadInt32();
				data.m_TypeHashLocationsEditor.Add(key2, new Dictionary<string, List<FoliageInstance>>());
				int num2 = a.ReadInt32();
				for (int j = 0; j < num2; j++)
				{
					string key3 = a.ReadString();
					List<FoliageInstance> value = ReadListFoliageInstance(a, tree: false);
					data.m_TypeHashLocationsEditor[key2].Add(key3, value);
				}
			}
		}

		private static void WriteFoliageCellDataSubdivided(BinaryWriter a, int key, FoliageCellSubdividedData data)
		{
			a.Write(key);
			WriteBounds(a, data.m_Bounds);
			WriteFoliageCell(a, data.m_Position);
			a.Write(data.m_TypeHashLocationsEditor.Count);
			foreach (int key2 in data.m_TypeHashLocationsEditor.Keys)
			{
				a.Write(key2);
				Dictionary<string, List<FoliageInstance>> dictionary = data.m_TypeHashLocationsEditor[key2];
				a.Write(dictionary.Count);
				foreach (string key3 in dictionary.Keys)
				{
					a.Write(key3);
					WriteListFoliageInstance(a, dictionary[key3], tree: false, shuffle: true);
				}
			}
		}

		public static List<FoliageInstance> ReadListFoliageInstance(BinaryReader a, bool tree)
		{
			int num = a.ReadInt32();
			List<FoliageInstance> list = new List<FoliageInstance>(num);
			for (int i = 0; i < num; i++)
			{
				list.Add(ReadFoliageInstance(a, tree));
			}
			return list;
		}

		public static void WriteListFoliageInstance(BinaryWriter a, List<FoliageInstance> list, bool tree, bool shuffle)
		{
			a.Write(list.Count);
			if (shuffle)
			{
				FoliageUtilities.Shuffle(list);
			}
			for (int i = 0; i < list.Count; i++)
			{
				WriteFoliageInstance(a, list[i], tree);
			}
		}

		private static void WriteFoliageInstance(BinaryWriter a, FoliageInstance i, bool tree)
		{
			if (tree)
			{
				WriteBounds(a, i.m_Bounds);
				WriteVector3(a, i.m_Position);
				WriteQuaternion(a, i.m_Rotation);
				WriteVector3(a, i.m_Scale);
				WriteGuid(a, i.m_UniqueId);
			}
			else
			{
				WriteVector3(a, i.m_Position);
				WriteQuaternion(a, i.m_Rotation);
				WriteVector3(a, i.m_Scale);
			}
		}

		private static FoliageInstance ReadFoliageInstance(BinaryReader a, bool tree)
		{
			FoliageInstance result = default(FoliageInstance);
			if (tree)
			{
				result.m_Bounds = ReadBounds(a);
				result.m_Position = ReadVector3(a);
				result.m_Rotation = ReadQuaternion(a);
				result.m_Scale = ReadVector3(a);
				result.m_UniqueId = ReadGuid(a);
			}
			else
			{
				result.m_Position = ReadVector3(a);
				result.m_Rotation = ReadQuaternion(a);
				result.m_Scale = ReadVector3(a);
			}
			return result;
		}

		private static Guid ReadGuid(BinaryReader a)
		{
			byte count = a.ReadByte();
			return new Guid(a.ReadBytes(count));
		}

		private static void WriteGuid(BinaryWriter a, Guid g)
		{
			byte[] array = g.ToByteArray();
			a.Write((byte)array.Length);
			a.Write(array);
		}

		private static void WriteMatrix4x4(BinaryWriter a, Matrix4x4 m)
		{
			a.Write(m.m00);
			a.Write(m.m01);
			a.Write(m.m02);
			a.Write(m.m03);
			a.Write(m.m10);
			a.Write(m.m11);
			a.Write(m.m12);
			a.Write(m.m13);
			a.Write(m.m20);
			a.Write(m.m21);
			a.Write(m.m22);
			a.Write(m.m23);
			a.Write(m.m30);
			a.Write(m.m31);
			a.Write(m.m32);
			a.Write(m.m33);
		}

		private static Matrix4x4 ReadMatrix4x4(BinaryReader a)
		{
			Matrix4x4 result = default(Matrix4x4);
			result.m00 = a.ReadSingle();
			result.m01 = a.ReadSingle();
			result.m02 = a.ReadSingle();
			result.m03 = a.ReadSingle();
			result.m10 = a.ReadSingle();
			result.m11 = a.ReadSingle();
			result.m12 = a.ReadSingle();
			result.m13 = a.ReadSingle();
			result.m20 = a.ReadSingle();
			result.m21 = a.ReadSingle();
			result.m22 = a.ReadSingle();
			result.m23 = a.ReadSingle();
			result.m30 = a.ReadSingle();
			result.m31 = a.ReadSingle();
			result.m32 = a.ReadSingle();
			result.m33 = a.ReadSingle();
			return result;
		}

		private static void WriteQuaternion(BinaryWriter a, Quaternion q)
		{
			a.Write(q.x);
			a.Write(q.y);
			a.Write(q.z);
			a.Write(q.w);
		}

		private static Quaternion ReadQuaternion(BinaryReader a)
		{
			Quaternion result = default(Quaternion);
			result.x = a.ReadSingle();
			result.y = a.ReadSingle();
			result.z = a.ReadSingle();
			result.w = a.ReadSingle();
			return result;
		}

		private static void WriteVector2(BinaryWriter a, Vector2 v)
		{
			a.Write(v.x);
			a.Write(v.y);
		}

		private static void ReadVector2(BinaryReader a, out Vector2 v)
		{
			v.x = a.ReadSingle();
			v.y = a.ReadSingle();
		}

		private static Vector2 ReadVector2(BinaryReader a)
		{
			Vector2 result = default(Vector2);
			result.x = a.ReadSingle();
			result.y = a.ReadSingle();
			return result;
		}

		private static void WriteVector3(BinaryWriter a, Vector3 v)
		{
			a.Write(v.x);
			a.Write(v.y);
			a.Write(v.z);
		}

		private static void ReadVector3(BinaryReader a, out Vector3 v)
		{
			v.x = a.ReadSingle();
			v.y = a.ReadSingle();
			v.z = a.ReadSingle();
		}

		private static Vector3 ReadVector3(BinaryReader a)
		{
			Vector3 result = default(Vector3);
			result.x = a.ReadSingle();
			result.y = a.ReadSingle();
			result.z = a.ReadSingle();
			return result;
		}

		private static void WriteBounds(BinaryWriter a, Bounds b)
		{
			WriteVector3(a, b.center);
			WriteVector3(a, b.size);
		}

		private static void ReadBounds(BinaryReader a, out Bounds b)
		{
			b = new Bounds(ReadVector3(a), ReadVector3(a));
		}

		private static Bounds ReadBounds(BinaryReader a)
		{
			return new Bounds(ReadVector3(a), ReadVector3(a));
		}

		private static void WriteFoliageCell(BinaryWriter a, FoliageCell fc)
		{
			a.Write(fc.x);
			a.Write(fc.y);
			a.Write(fc.z);
		}

		private static void ReadFoliageCell(BinaryReader a, out FoliageCell fc)
		{
			fc.x = a.ReadInt32();
			fc.y = a.ReadInt32();
			fc.z = a.ReadInt32();
		}

		private static FoliageCell ReadFoliageCell(BinaryReader a)
		{
			FoliageCell result = default(FoliageCell);
			result.x = a.ReadInt32();
			result.y = a.ReadInt32();
			result.z = a.ReadInt32();
			return result;
		}
	}
}
