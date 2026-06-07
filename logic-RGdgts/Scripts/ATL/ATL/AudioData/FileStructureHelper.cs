using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ATL.AudioData
{
	public class FileStructureHelper
	{
		public class FrameHeader
		{
			public enum TYPE
			{
				Counter = 0,
				Size = 1,
				Index = 2,
				RelativeIndex = 3
			}

			public readonly TYPE Type;

			public readonly long Position;

			public readonly bool IsLittleEndian;

			public readonly string ParentZone;

			public readonly string ValueZone;

			public object Value { get; set; }

			public FrameHeader(TYPE type, long position, object value, bool isLittleEndian = true, string parentZone = "", string valueZone = "")
			{
			}
		}

		public class Zone
		{
			[CompilerGenerated]
			private bool _003CIsDeletable_003Ek__BackingField;

			[CompilerGenerated]
			private bool _003CIsResizable_003Ek__BackingField;

			public string Name { get; set; }

			public long Offset { get; set; }

			public long Size { get; set; }

			public byte[] CoreSignature { get; set; }

			public bool IsDeletable
			{
				[CompilerGenerated]
				set
				{
					_003CIsDeletable_003Ek__BackingField = value;
				}
			}

			public byte Flag { get; set; }

			public IList<FrameHeader> Headers { get; set; }

			public bool IsResizable
			{
				[CompilerGenerated]
				set
				{
					_003CIsResizable_003Ek__BackingField = value;
				}
			}

			public Zone(string name, long offset, long size, byte[] coreSignature, bool isDeletable = true, byte flag = 0, bool resizable = true)
			{
			}

			public void Clear()
			{
			}
		}

		private sealed class ZoneInfo
		{
		}

		private readonly IDictionary<string, Zone> zones;

		private readonly IDictionary<int, IDictionary<ZoneInfo, KeyValuePair<long, long>>> dynamicOffsetCorrection;

		private readonly bool isLittleEndian;

		public ICollection<string> ZoneNames => null;

		public ICollection<Zone> Zones => null;

		public FileStructureHelper(bool isLittleEndian = true)
		{
		}

		public void Clear()
		{
		}

		public Zone GetZone(string name)
		{
			return null;
		}

		public void AddZone(Zone zone)
		{
		}

		public void AddZone(long offset, long size, string name = "default", bool isDeletable = true, bool resizable = true)
		{
		}

		public void AddZone(long offset, long size, byte[] coreSignature, string name = "default", bool isDeletable = true, bool resizable = true)
		{
		}

		public void RemoveZone(string name)
		{
		}

		public void RemoveZonesStartingWith(string name)
		{
		}

		public void AddCounter(long position, object value, string zone = "default", string parentZone = "")
		{
		}

		public void AddSize(long position, object value, string zone = "default", string parentZone = "")
		{
		}

		public void AddIndex(long position, object value, bool relative = false, string zone = "default", string parentZone = "")
		{
		}

		public void DeclareZone(string zone)
		{
		}

		private void addZoneHeader(string zone, FrameHeader.TYPE type, long position, object value, bool isLittleEndian, string parentZone = "", string valueZone = "")
		{
		}
	}
}
