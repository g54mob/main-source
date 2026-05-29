using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Libs;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	[Serializable]
	public class MapData : ISerializationCallbackReceiver
	{
		public const int FirstMapSizeWidth = 42;

		public const int FirstMapSizeHeight = 35;

		public const int MapSectionSizeWidth = 22;

		public const int MapSectionSizeHeight = 20;

		public const int FullMapSizeX = 86;

		public const int FullMapSizeY = 75;

		public const string Version000 = "0.0.0";

		public const string Version010 = "0.1.0";

		public const string Version100 = "1.0.0";

		public const string Version101 = "1.0.1";

		public const string Version102 = "1.0.2";

		public const string Version105 = "1.0.5";

		public const string Version106 = "1.0.6";

		public const string Version107 = "1.0.7";

		public const string Version108 = "1.0.8";

		public const string Version109 = "1.0.9";

		public const string Version110 = "1.1.0";

		public const string Version111 = "1.1.1";

		public const string Version112 = "1.1.2";

		public static readonly Version SaveMapVersion;

		public int mapId;

		public SerializableGuid guid;

		public string mapVersion;

		private Version _mapVersion;

		public Vector2Int mapSize;

		public Vector2Int mapOffset;

		public eMapExtension mapExtensionArea;

		public List<MapResource> resourcesList;

		public List<SerializableStructure> structureList;

		[IgnoreDataMember]
		public Version MapVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static RectInt DefaultPlayArea => default(RectInt);

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public static bool IsValidAddr(Vector2Int addr)
		{
			return false;
		}

		public static bool IsValidAddr(StructureAddr addr)
		{
			return false;
		}
	}
}
