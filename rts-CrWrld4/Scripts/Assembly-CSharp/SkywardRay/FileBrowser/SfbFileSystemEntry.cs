using System;
using System.Collections.Generic;

namespace SkywardRay.FileBrowser
{
	public class SfbFileSystemEntry
	{
		public bool readContents;

		public readonly bool hidden;

		public readonly string path;

		public readonly string name;

		public readonly string extension;

		public readonly SfbFileSystemEntryType type;

		public SfbFileSystemEntry parent;

		public List<SfbFileSystemEntry> children;

		public DateTime lastWriteTime;

		public byte[] FileContents { get; private set; }

		public SfbFileSystemEntry(string path, bool hidden, SfbFileSystemEntryType type)
		{
		}

		public void AddChild(SfbFileSystemEntry entry)
		{
		}

		public void RemoveChild(SfbFileSystemEntry entry)
		{
		}

		public void ReadLastWriteTime()
		{
		}

		public bool HasChanged()
		{
			return false;
		}

		public void SetContents(byte[] bytes)
		{
		}

		public void ReadContentsFromDisk()
		{
		}

		public void WriteContentsToDisk()
		{
		}
	}
}
