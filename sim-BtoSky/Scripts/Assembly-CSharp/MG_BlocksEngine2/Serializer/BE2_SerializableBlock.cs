using System;
using System.Collections.Generic;
using UnityEngine;

namespace MG_BlocksEngine2.Serializer
{
	[Serializable]
	public class BE2_SerializableBlock
	{
		public string blockName;

		public Vector3 position;

		public List<BE2_SerializableSection> sections;

		public string varManagerName;

		public string varName;

		public BE2_SerializableOuterArea outerArea;

		public string defineID;

		public string isLocalVar;

		public List<DefineItem> defineItems = new List<DefineItem>();

		public BE2_SerializableBlock()
		{
			sections = new List<BE2_SerializableSection>();
		}
	}
}
