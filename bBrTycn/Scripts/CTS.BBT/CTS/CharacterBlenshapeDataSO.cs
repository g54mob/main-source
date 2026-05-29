using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Character Blenshape", menuName = "CharacterTool/Character Blenshape")]
	public class CharacterBlenshapeDataSO : ScriptableObject, IIndentifiable
	{
		[SerializeField]
		public Mesh mesh;

		public CharacterData characterData;

		public MeshBlendShape meshBlendShape;

		[field: SerializeField]
		public int ID { get; private set; }
	}
}
