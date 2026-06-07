using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Cache
{
	public class FileCache
	{
		public class CacheEntry
		{
			public DateTime CreatedDateTime { get; set; }

			public DateTime? ExpirationDateTime
			{
				get
				{
					if (ExpirationInMinutes > 0)
					{
						return CreatedDateTime.AddMinutes(ExpirationInMinutes);
					}
					return null;
				}
			}

			public int ExpirationInMinutes { get; internal set; }

			public string FileName { get; set; }

			public bool IsBinary { get; set; }

			public string Key { get; set; }

			public DateTime LastAccessDateTime { get; set; }

			public string PinKey { get; set; }

			public long SizeInBytes { get; set; }
		}

		private const string CacheXmlFileName = "Cache.xml";

		private Dictionary<string, CacheEntry> _entries = new Dictionary<string, CacheEntry>();

		public long MaxSize { get; }

		public string RootPath { get; }

		public long SizeInBytes => _entries.Values.Sum((CacheEntry x) => x.SizeInBytes);

		public long SizeInBytesPinned => _entries.Values.Where((CacheEntry x) => x.PinKey != null).Sum((CacheEntry x) => x.SizeInBytes);

		private string CacheContentPath { get; }

		private long TotalSize { get; set; }

		public FileCache(string rootPath, long maxSize)
		{
			RootPath = rootPath;
			CacheContentPath = Path.Combine(rootPath, "Files");
			MaxSize = maxSize;
			Directory.CreateDirectory(CacheContentPath);
			try
			{
				LoadXml();
			}
			catch (Exception)
			{
				_entries.Clear();
			}
			ManageCacheSize();
			DeleteUntrackedFiles();
		}

		public void AddOrUpdateBinary(string key, byte[] data, int expirationInMinutes = 0)
		{
			if (expirationInMinutes >= 0)
			{
				CacheEntry cacheEntry = AddOrUpdateCacheEntry(key, isBinary: true, data.Length, expirationInMinutes);
				File.WriteAllBytes(GetPathForEntry(cacheEntry.FileName), data);
			}
		}

		public void AddOrUpdateText(string key, string data, int expirationInMinutes = 0)
		{
			if (expirationInMinutes >= 0)
			{
				CacheEntry cacheEntry = AddOrUpdateCacheEntry(key, isBinary: false, data.Length, expirationInMinutes);
				File.WriteAllText(GetPathForEntry(cacheEntry.FileName), data);
			}
		}

		public void Clear()
		{
			CacheEntry[] array = _entries.Values.Where((CacheEntry x) => x.PinKey == null).ToArray();
			foreach (CacheEntry entry in array)
			{
				DeleteCacheEntry(entry);
			}
		}

		public void ClearAllTextEntries()
		{
			CacheEntry[] array = _entries.Values.ToArray();
			foreach (CacheEntry cacheEntry in array)
			{
				if (!cacheEntry.IsBinary)
				{
					DeleteCacheEntry(cacheEntry);
				}
			}
		}

		public bool ContainsFile(string key)
		{
			return _entries.ContainsKey(key);
		}

		public byte[] GetBinary(string key)
		{
			try
			{
				CacheEntry cacheEntry = GetCacheEntry(key);
				if (cacheEntry != null)
				{
					if (!cacheEntry.IsBinary)
					{
						Debug.Log("Cache item " + cacheEntry.Key + " was initially added as text, but is being accessed as binary.");
						return null;
					}
					return File.ReadAllBytes(GetPathForEntry(cacheEntry.FileName));
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return null;
		}

		public string GetText(string key)
		{
			try
			{
				CacheEntry cacheEntry = GetCacheEntry(key);
				if (cacheEntry != null)
				{
					if (cacheEntry.IsBinary)
					{
						Debug.Log("Cache item " + cacheEntry.Key + " was initially added as binary, but is being accessed as text.");
						return null;
					}
					return File.ReadAllText(GetPathForEntry(cacheEntry.FileName));
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return null;
		}

		public void PinCacheItem(string cacheKey, string pinKey)
		{
			CacheEntry cacheEntry = GetCacheEntry(cacheKey, updateLastAccessDateTime: false);
			if (cacheEntry != null)
			{
				cacheEntry.PinKey = pinKey;
			}
		}

		public void RemoveCacheItem(string key)
		{
			CacheEntry cacheEntry = GetCacheEntry(key, updateLastAccessDateTime: false);
			if (cacheEntry != null)
			{
				DeleteCacheEntry(cacheEntry);
			}
		}

		public void SaveMetaData()
		{
			XElement xElement = new XElement("Cache");
			foreach (CacheEntry value in _entries.Values)
			{
				XElement xElement2 = new XElement("E");
				xElement2.SetAttributeValue("created", value.CreatedDateTime);
				xElement2.SetAttributeValue("binary", value.IsBinary);
				xElement2.SetAttributeValue("fileName", value.FileName);
				xElement2.SetAttributeValue("key", value.Key);
				xElement2.SetAttributeValue("accessed", value.LastAccessDateTime);
				xElement2.SetAttributeValue("size", value.SizeInBytes);
				xElement2.SetAttributeValue("expire", value.ExpirationInMinutes);
				if (value.PinKey != null)
				{
					xElement2.SetAttributeValue("pinKey", value.PinKey);
				}
				xElement.Add(xElement2);
			}
			string fileName = Path.Combine(RootPath, "Cache.xml");
			new XDocument(xElement).Save(fileName);
		}

		public void UnpinCacheItems(string pinKey)
		{
			foreach (KeyValuePair<string, CacheEntry> item in _entries.Where((KeyValuePair<string, CacheEntry> x) => x.Value.PinKey == pinKey).ToList())
			{
				item.Value.PinKey = null;
			}
		}

		private CacheEntry AddOrUpdateCacheEntry(string key, bool isBinary, long sizeInBytes, int expirationInMinutes)
		{
			if (sizeInBytes > MaxSize)
			{
				throw new ArgumentException($"Cache item {key} is larger than the maximum allowable cache size ({sizeInBytes} bytes > {MaxSize} bytes)");
			}
			CacheEntry cacheEntry = GetCacheEntry(key);
			if (cacheEntry == null)
			{
				cacheEntry = new CacheEntry
				{
					FileName = Guid.NewGuid().ToString(),
					Key = key
				};
				_entries[key] = cacheEntry;
			}
			else
			{
				TotalSize -= cacheEntry.SizeInBytes;
			}
			TotalSize += sizeInBytes;
			cacheEntry.CreatedDateTime = DateTime.Now;
			cacheEntry.LastAccessDateTime = DateTime.Now;
			cacheEntry.IsBinary = isBinary;
			cacheEntry.SizeInBytes = sizeInBytes;
			cacheEntry.ExpirationInMinutes = expirationInMinutes;
			ManageCacheSize();
			return cacheEntry;
		}

		private void DeleteCacheEntry(CacheEntry entry)
		{
			string pathForEntry = GetPathForEntry(entry.FileName);
			if (File.Exists(pathForEntry))
			{
				File.Delete(pathForEntry);
			}
			_entries.Remove(entry.Key);
			TotalSize -= entry.SizeInBytes;
		}

		private void DeleteUntrackedFiles()
		{
			FileInfo[] files = new DirectoryInfo(CacheContentPath).GetFiles();
			foreach (FileInfo file in files)
			{
				if (!_entries.Values.Any((CacheEntry x) => x.FileName == file.Name))
				{
					file.Delete();
				}
			}
		}

		private CacheEntry GetCacheEntry(string key, bool updateLastAccessDateTime = true)
		{
			if (_entries.TryGetValue(key, out var value))
			{
				DateTime? expirationDateTime = value.ExpirationDateTime;
				if (value.PinKey != null || !expirationDateTime.HasValue || !(DateTime.Now > value.ExpirationDateTime.Value))
				{
					if (updateLastAccessDateTime)
					{
						value.LastAccessDateTime = DateTime.Now;
					}
					return value;
				}
				DeleteCacheEntry(value);
			}
			return null;
		}

		private string GetPathForEntry(string fileName)
		{
			return Path.Combine(CacheContentPath, fileName);
		}

		private void LoadXml()
		{
			foreach (XElement item in XDocument.Load(Path.Combine(RootPath, "Cache.xml")).Root.Elements())
			{
				CacheEntry cacheEntry = new CacheEntry();
				cacheEntry.CreatedDateTime = (DateTime)item.Attribute("created");
				cacheEntry.IsBinary = (bool)item.Attribute("binary");
				cacheEntry.FileName = item.Attribute("fileName").Value;
				cacheEntry.Key = item.Attribute("key").Value;
				cacheEntry.LastAccessDateTime = (DateTime)item.Attribute("accessed");
				cacheEntry.SizeInBytes = (long)item.Attribute("size");
				cacheEntry.ExpirationInMinutes = (int)item.Attribute("expire");
				cacheEntry.PinKey = item.Attribute("pinKey")?.Value ?? null;
				_entries[cacheEntry.Key] = cacheEntry;
				TotalSize += cacheEntry.SizeInBytes;
			}
		}

		private void ManageCacheSize()
		{
			long num = MaxSize + SizeInBytesPinned;
			if (TotalSize <= num)
			{
				return;
			}
			CacheEntry[] array = (from x in _entries.Values
				where x.PinKey == null
				orderby x.LastAccessDateTime
				select x).ToArray();
			for (int num2 = 0; num2 < array.Length; num2++)
			{
				DeleteCacheEntry(array[num2]);
				if (TotalSize <= num)
				{
					break;
				}
			}
		}
	}
}
