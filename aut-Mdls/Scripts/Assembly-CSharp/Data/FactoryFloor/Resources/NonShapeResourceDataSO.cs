using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	[CreateAssetMenu(menuName = "Factory/Resources/NonShapeResourceData", fileName = "NonShapeResourceData", order = 2)]
	public class NonShapeResourceDataSO : ResourceDataSO
	{
		[SerializeField]
		private ResourceViewMeshData _meshData;

		[SerializeField]
		private Sprite _sprite;

		[SerializeField]
		private string _nameLocaKey;

		[SerializeField]
		private int _familyID;

		public ResourceViewMeshData MeshData => _meshData;

		public Sprite Sprite => _sprite;

		public string NameLocaKey => _nameLocaKey;

		public int FamilyID => _familyID;
	}
}
