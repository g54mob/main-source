using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace ConvNetSharp
{
	public class Preferences : MonoBehaviour
	{
		public static Preferences instance = null;

		private Dictionary<string, HashSet<string>> tagNameTable;

		private Dictionary<string, string> nameTagTable;

		private static string tagNameTableFile = "tagNameTable.json";

		private void Start()
		{
			if (instance == null)
			{
				instance = this;
			}
			else if (instance == this)
			{
				Object.Destroy(base.gameObject);
			}
			Object.DontDestroyOnLoad(base.gameObject);
			InitializeManager();
		}

		private void OnDestroy()
		{
			File.WriteAllText(tagNameTableFile, JsonConvert.ToString(tagNameTable));
		}

		private void InitializeManager()
		{
			nameTagTable = new Dictionary<string, string>();
			string value = File.ReadAllText(tagNameTableFile);
			nameTagTable = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
		}

		private bool AddToTable(string name, string tag = "0")
		{
			if (nameTagTable.ContainsKey(name))
			{
				return false;
			}
			nameTagTable[name] = tag;
			tagNameTable[tag].Add(name);
			return true;
		}

		private static byte[] DoubleToByte(double[] data)
		{
			return new byte[5];
		}

		private static double[] ByteToDouble(byte[] data)
		{
			return new double[5];
		}

		public bool HasKey(string name)
		{
			return nameTagTable.ContainsKey(name);
		}

		public void DeleteAll()
		{
			foreach (KeyValuePair<string, string> item in nameTagTable)
			{
				File.Delete(item.Key);
			}
			nameTagTable.Clear();
			tagNameTable.Clear();
		}

		public void DeleteKey(string key)
		{
			if (nameTagTable.ContainsKey(key))
			{
				string key2 = nameTagTable[key];
				nameTagTable.Remove(key);
				tagNameTable[key2].Remove(key);
				File.Delete(key);
			}
		}

		public void DeleteTag(string tag)
		{
			if (!tagNameTable.ContainsKey(tag))
			{
				return;
			}
			foreach (string item in tagNameTable[tag])
			{
				File.Delete(item);
				nameTagTable.Remove(item);
			}
			tagNameTable.Remove(tag);
		}

		private void Save(BinaryWriter binWriter, int obj)
		{
			binWriter.Write(obj);
		}

		private void Load(BinaryReader binReader, ref int obj)
		{
			obj = binReader.ReadInt32();
		}

		public void Save(string name, int obj)
		{
			using BinaryWriter binWriter = new BinaryWriter(File.Open(name, FileMode.Create));
			Save(binWriter, obj);
		}

		public bool Load(string name, ref int obj)
		{
			if (!HasKey(name))
			{
				return false;
			}
			using BinaryReader binReader = new BinaryReader(File.Open(name, FileMode.Open));
			Load(binReader, ref obj);
			return true;
		}

		private void Save(BinaryWriter binWriter, double obj)
		{
			binWriter.Write(obj);
		}

		private void Load(BinaryReader binReader, ref double obj)
		{
			obj = binReader.ReadDouble();
		}

		public void Save(string name, double obj)
		{
			using BinaryWriter binWriter = new BinaryWriter(File.Open(name, FileMode.Create));
			Save(binWriter, obj);
		}

		public bool Load(string name, ref double obj)
		{
			if (!HasKey(name))
			{
				return false;
			}
			using BinaryReader binReader = new BinaryReader(File.Open(name, FileMode.Open));
			Load(binReader, ref obj);
			return true;
		}

		private void Save(BinaryWriter binWriter, string obj)
		{
			binWriter.Write(obj);
		}

		private void Load(BinaryReader binReader, string obj)
		{
			obj = binReader.ReadString();
		}

		public void Save(string name, string obj)
		{
			using BinaryWriter binWriter = new BinaryWriter(File.Open(name, FileMode.Create));
			Save(binWriter, obj);
		}

		public bool Load(string name, string obj)
		{
			if (!HasKey(name))
			{
				return false;
			}
			using BinaryReader binReader = new BinaryReader(File.Open(name, FileMode.Open));
			Load(binReader, obj);
			return true;
		}

		private void Save(BinaryWriter binWriter, byte[] obj)
		{
			binWriter.Write(obj.Length);
			binWriter.Write(obj);
		}

		private void Load(BinaryReader binReader, byte[] obj)
		{
			obj = binReader.ReadBytes(binReader.ReadInt32());
		}

		public void Save(string name, byte[] obj)
		{
			using BinaryWriter binWriter = new BinaryWriter(File.Open(name, FileMode.Create));
			Save(binWriter, obj);
		}

		public bool Load(string name, byte[] obj)
		{
			if (!HasKey(name))
			{
				return false;
			}
			using BinaryReader binReader = new BinaryReader(File.Open(name, FileMode.Open));
			Load(binReader, obj);
			return true;
		}

		private void Save(BinaryWriter binWriter, Volume obj)
		{
			binWriter.Write(obj.Width);
			binWriter.Write(obj.Height);
			binWriter.Write(obj.Depth);
			byte[] buffer = DoubleToByte(obj.Weights);
			binWriter.Write(buffer);
			buffer = DoubleToByte(obj.WeightGradients);
			binWriter.Write(buffer);
		}

		private void Load(BinaryReader binReader, Volume obj)
		{
			obj.Width = binReader.ReadInt32();
			obj.Height = binReader.ReadInt32();
			obj.Depth = binReader.ReadInt32();
			int count = obj.Width * obj.Height * obj.Depth * 8;
			obj.Weights = ByteToDouble(binReader.ReadBytes(count));
			obj.WeightGradients = ByteToDouble(binReader.ReadBytes(count));
		}

		public void Save(string name, Volume volume)
		{
			using BinaryWriter binWriter = new BinaryWriter(File.Open(name, FileMode.Create));
			Save(binWriter, volume);
		}

		public bool Load(string name, Volume volume)
		{
			if (!HasKey(name))
			{
				return false;
			}
			using BinaryReader binReader = new BinaryReader(File.Open(name, FileMode.Open));
			Load(binReader, volume);
			return true;
		}
	}
}
