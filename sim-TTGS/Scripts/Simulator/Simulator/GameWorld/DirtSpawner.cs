using System;
using System.Linq;
using Dhs5.Utility.Databases;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public class DirtSpawner
	{
		[SerializeField]
		private Transform m_dirtContainer;

		public Dirt Spawn(SaveClass_Dirt.SaveDirtData saveDirtData)
		{
			if (!Database.Get<DirtDatabase>().TryGetDataByUID(saveDirtData.UID, out DirtData data))
			{
				return null;
			}
			return Spawn(data, saveDirtData.position, saveDirtData.rotation, saveDirtData.textureIndex);
		}

		public Dirt Spawn(DirtData.EType type, Vector3 position)
		{
			if (!Database.Enumerate<DirtDatabase, DirtData>().ToList().TryGetRandom((DirtData x) => x.DirtType == type, out var value))
			{
				return null;
			}
			Vector3 position2 = position;
			Vector3 rotation = new Vector3(0f, UnityEngine.Random.Range(0, 359), 0f);
			if (type != DirtData.EType.TRASH)
			{
				return Spawn(value, position2, rotation);
			}
			position2 += Vector3.up * 1f;
			rotation += new Vector3(UnityEngine.Random.Range(0, 359), 0f, UnityEngine.Random.Range(0, 359));
			return Spawn(value, position2, rotation);
		}

		public Dirt Spawn(DirtData dirtData, Vector3 position, Vector3 rotation, int meshIndex = -1)
		{
			Dirt dirt = UnityEngine.Object.Instantiate(dirtData.Prefab, m_dirtContainer);
			dirt.Spawn(dirtData, position, rotation, meshIndex);
			return dirt;
		}
	}
}
