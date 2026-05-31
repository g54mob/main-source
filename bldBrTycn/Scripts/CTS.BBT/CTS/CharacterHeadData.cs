using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Characters/Head Data")]
	public class CharacterHeadData : ScriptableObject
	{
		[field: SerializeField]
		public int ID { get; private set; }

		[field: SerializeField]
		public Mesh Mesh { get; private set; }

		[field: SerializeField]
		public Material Material { get; private set; }

		[field: SerializeField]
		public ESpecies AllowedSpecies { get; private set; }

		[field: SerializeField]
		public ESubSpecies AllowedSubSpecies { get; private set; }

		[field: SerializeField]
		public EEthnics AllowedEthnics { get; private set; }

		[field: SerializeField]
		public EGender AllowedGenders { get; private set; }
	}
}
