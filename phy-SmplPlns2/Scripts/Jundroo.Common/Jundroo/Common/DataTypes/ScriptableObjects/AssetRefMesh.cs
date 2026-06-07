using UnityEngine;

namespace Jundroo.Common.DataTypes.ScriptableObjects
{
	public class AssetRefMesh : ScriptableObject
	{
		[SerializeField]
		private Mesh _mesh;

		public Mesh GetMeshInstance()
		{
			return Object.Instantiate(_mesh);
		}

		public Mesh GetMeshShared()
		{
			return _mesh;
		}
	}
}
