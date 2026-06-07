using System.Collections.Generic;
using UnityEngine;

namespace Placemaker
{
	public class BigMeshMaster : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		public List<BigMeshGroup> bigMeshGroups;

		public BigMesh GetBigMesh(Material material, int vertCount)
		{
			return null;
		}

		public void OnLateUpdate()
		{
		}

		public void OnStart()
		{
		}

		private void MaybeApply(BigMesh bigMesh)
		{
		}

		public void AddMesh(BigMeshPart bigMeshPart, Material material, BigMeshList lists, bool superDirty = false)
		{
		}

		public void AddMesh(BigMeshPart bigMeshPart, Material material, List<Vector3> verts, List<Vector3> normals, List<Vector4> tangents, List<Vector2> uvs, List<int> tris, bool superDirty = false)
		{
		}

		public void ReturnMesh(BigMeshPart bigMeshPart, bool superDirty = false)
		{
		}
	}
}
