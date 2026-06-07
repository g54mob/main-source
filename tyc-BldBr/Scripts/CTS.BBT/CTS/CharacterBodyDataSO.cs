using UnityEngine;

namespace CTS
{
	public class CharacterBodyDataSO : ScriptableObject, IIndentifiable
	{
		[SerializeField]
		public Mesh mesh;

		[SerializeField]
		public CharacterData characterData;

		[SerializeField]
		public BodyMaterialList[] materialsGroup;

		[SerializeField]
		public string[] materialsGroupFolders;

		[field: SerializeField]
		public int ID { get; private set; }
	}
}
