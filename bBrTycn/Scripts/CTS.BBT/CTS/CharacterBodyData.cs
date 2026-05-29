using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Characters/Body Data")]
	public class CharacterBodyData : ScriptableObject
	{
		[field: SerializeField]
		public int ID { get; private set; }

		[field: SerializeField]
		public ESpecies AllowedSpecies { get; private set; }

		[field: SerializeField]
		public ESubSpecies AllowedSubSpecies { get; private set; }

		[field: SerializeField]
		public SkinnedMeshRenderer MascMesh { get; private set; }

		[field: SerializeField]
		public SkinnedMeshRenderer FemMesh { get; private set; }

		[field: SerializeField]
		public Material[] MascMaterials { get; private set; }

		[field: SerializeField]
		public Material[] FemMaterials { get; private set; }

		[field: SerializeField]
		public string[] MeshSearchTags { get; private set; }

		[field: SerializeField]
		public string[] MaterialsSearchTags { get; private set; }

		[field: SerializeField]
		public string[] Excludes { get; private set; }

		public bool FemIsValid
		{
			get
			{
				if ((object)FemMesh != null && FemMaterials != null)
				{
					return FemMaterials.Length != 0;
				}
				return false;
			}
		}

		public bool MascIsValid
		{
			get
			{
				if ((object)MascMesh != null && MascMaterials != null)
				{
					return MascMaterials.Length != 0;
				}
				return false;
			}
		}
	}
}
