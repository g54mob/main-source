using UnityEngine;

namespace CTS
{
	public class CharacterMaterialDataSO : ScriptableObject, IIndentifiable
	{
		[SerializeField]
		public Material material;

		[SerializeField]
		public CharacterData characterData;

		[field: SerializeField]
		public int ID { get; private set; }
	}
}
