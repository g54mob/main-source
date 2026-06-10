using System.Collections.Generic;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class MeshRepository : AddressableRepository<MeshRepository, KeyGameObjectPair, GameObject>
	{
		public Mesh GetMeshByAddress(string address)
		{
			if (string.IsNullOrEmpty(address))
			{
				return null;
			}
			GameObject byAddress = GetByAddress(address);
			if (byAddress == null)
			{
				return null;
			}
			MeshFilter componentInChildren = byAddress.GetComponentInChildren<MeshFilter>();
			if (componentInChildren != null)
			{
				Mesh sharedMesh = componentInChildren.sharedMesh;
				if ((object)sharedMesh != null)
				{
					return sharedMesh;
				}
			}
			SkinnedMeshRenderer componentInChildren2 = byAddress.GetComponentInChildren<SkinnedMeshRenderer>();
			if (componentInChildren2 != null)
			{
				Mesh sharedMesh2 = componentInChildren2.sharedMesh;
				if ((object)sharedMesh2 != null)
				{
					return sharedMesh2;
				}
			}
			return null;
		}

		public override List<string> AddressableLabels()
		{
			return new List<string> { "Mesh" };
		}

		public override void AddNewObject(string key, Object obj, bool overwrite = false)
		{
			if (!(obj == null) && !string.IsNullOrEmpty(key) && !dictionary.ContainsKey(key))
			{
				Add(new KeyGameObjectPair(key, obj as GameObject));
			}
		}
	}
}
