using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Libs;
using UnityEngine;

namespace Factory.FieldData
{
	public class MapContextData : ISerializationCallbackReceiver
	{
		public const string Version001 = "0.0.1";

		public const string Version010 = "0.1.0";

		public const string Version011 = "0.1.1";

		public static readonly Version SaveContextVersion;

		public SerializableGuid guid;

		public string mapContextVersion;

		private Version _mapContextVersion;

		public List<SerializableLuggage> luggageList;

		public List<SerializableLiquid> liquidList;

		public List<SerializableLiquid> liquidListMT;

		public List<SerializableStructureContext> structureContextList;

		public List<SerializableMechBase> mechBaseList;

		public List<eMapExtension> mapExtensionList;

		[IgnoreDataMember]
		public Version MapContextVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
