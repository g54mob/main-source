using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.SaveSystem;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("NanoSave Lite")]
	[Category("NanoSave Lite")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Description("Stores all game information in a compressed JSON file")]
	public class NanoSaveLite : TDataStorage
	{
		[Serializable]
		private class Block
		{
			[SerializeField]
			private Entry[] m_Entries;

			public Entry[] Entries => m_Entries;

			public Block(Dictionary<string, Entry> data)
			{
				m_Entries = new Entry[data.Count];
				int num = 0;
				foreach (KeyValuePair<string, Entry> datum in data)
				{
					m_Entries[num] = datum.Value;
					num++;
				}
			}
		}

		[Serializable]
		private class Entry
		{
			[SerializeField]
			private string m_Key;

			[SerializeField]
			private string m_Value;

			public string Key => m_Key;

			public string Value => m_Value;

			public Entry(string key, string value)
			{
				m_Key = key;
				m_Value = value;
			}
		}

		private const string FILE_NAME = "save.json.gz";

		private static Dictionary<string, Entry> CacheData;

		private Dictionary<string, Entry> Data
		{
			get
			{
				if (CacheData != null)
				{
					return CacheData;
				}
				CacheData = new Dictionary<string, Entry>();
				Block block = null;
				string path = Path.Combine(Application.persistentDataPath, "save.json.gz");
				if (File.Exists(path))
				{
					try
					{
						string input;
						using (FileStream stream = new FileStream(path, FileMode.Open))
						{
							using GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress);
							using StreamReader streamReader = new StreamReader(stream2);
							input = streamReader.ReadToEnd();
						}
						input = base.Cryptography.Decrypt(input);
						block = JsonUtility.FromJson<Block>(input);
					}
					catch (Exception arg)
					{
						Debug.LogError($"Error trying to load data: {arg}");
					}
				}
				Entry[] array = block?.Entries ?? Array.Empty<Entry>();
				foreach (Entry entry in array)
				{
					CacheData[entry.Key] = entry;
				}
				return CacheData;
			}
		}

		public override Task DeleteAll()
		{
			Data.Clear();
			return Task.FromResult(1);
		}

		public override Task DeleteKey(string key)
		{
			Data.Remove(key);
			return Task.FromResult(1);
		}

		public override Task<bool> HasKey(string key)
		{
			return Task.FromResult(Data.ContainsKey(key));
		}

		public override Task<object> Get(string key, Type type)
		{
			Data.TryGetValue(key, out var value);
			string text = value?.Value ?? string.Empty;
			return Task.FromResult((!string.IsNullOrEmpty(text)) ? JsonUtility.FromJson(text, type) : null);
		}

		public override Task Set(string key, object value)
		{
			string value2 = JsonUtility.ToJson(value, prettyPrint: false);
			Data[key] = new Entry(key, value2);
			return Task.FromResult(1);
		}

		public override Task Commit()
		{
			string path = Path.Combine(Application.persistentDataPath, "save.json.gz");
			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path) ?? string.Empty);
				string input = JsonUtility.ToJson(new Block(CacheData), prettyPrint: false);
				input = base.Cryptography.Encrypt(input);
				using FileStream stream = new FileStream(path, FileMode.Create);
				using GZipStream stream2 = new GZipStream(stream, CompressionMode.Compress);
				using StreamWriter streamWriter = new StreamWriter(stream2);
				streamWriter.Write(input);
			}
			catch (Exception arg)
			{
				Debug.LogError($"Error trying to save data: {arg}");
			}
			return Task.FromResult(1);
		}
	}
}
