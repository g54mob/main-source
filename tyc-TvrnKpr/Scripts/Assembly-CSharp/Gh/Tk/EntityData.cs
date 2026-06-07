using LitJson;
using Unity.Mathematics;
using UnityEngine;

namespace Gh.Tk
{
	public class EntityData : IPersistable, ICustomSaveState
	{
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public int WorldIndex;

		public string PrefabId { get; set; }

		[JsonIgnore]
		public quaternion Rotation { get; set; }

		[JsonIgnore]
		public float3 Translation { get; set; }

		[JsonIgnore]
		public float3 Scale { get; set; }

		[JsonIgnore]
		public int ParentGoxId { get; set; }

		protected EntityData()
		{
		}

		protected EntityData(GameObject go, bool withParentRelation, int world)
		{
		}

		private void ApplyDataToEntity(GameObject go, GameObject parent, int world)
		{
		}

		public GameObject RestoreEntity(GameObject parent, int world)
		{
			return null;
		}

		public static EntityData SnapshotEntity(GameObject go, int world, bool withParentRelation = true)
		{
			return null;
		}

		public void SaveState(IDataStore data)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}
	}
}
