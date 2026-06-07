using System;
using System.Collections.Generic;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class SaveClass_Dirt
	{
		[Serializable]
		public class SaveDirtData
		{
			public int UID;

			public Vector3 position;

			public Vector3 rotation;

			public int textureIndex;

			public SaveDirtData(DirtData data, Vector3 position, Vector3 rotation, int textureIndex = -1)
			{
				this.position = position;
				this.rotation = rotation;
				UID = data.UID;
				this.textureIndex = textureIndex;
			}
		}

		public List<SaveDirtData> dirtDatas;

		public void AddDirtData(SaveDirtData data)
		{
			dirtDatas.Add(data);
		}
	}
}
