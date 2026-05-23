using System;
using System.Collections.Generic;
using Libs;
using UnityEngine;

namespace Factory.FieldData
{
	[Serializable]
	public class MapAsset
	{
		[Serializable]
		public struct ExtraMachine
		{
			public eMachine id;

			public Dir.Rot rot;

			public ExtraMachine(eMachine id, Dir.Rot rot)
			{
				this.id = default(eMachine);
				this.rot = default(Dir.Rot);
			}
		}

		public string path;

		[NonSerialized]
		public TextAsset asset;

		[NonSerialized]
		public eLuggage[] mapResourceIds;

		[NonSerialized]
		public List<eMachine> mapResourceMachines;

		public ExtraMachine extraPortal;

		public ExtraMachine extraChuChu;

		public MapAsset(string path, TextAsset asset, MapResource[] mapResource = null, string[] mapResourceMachines = null)
		{
		}
	}
}
