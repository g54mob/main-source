using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Character Avatar", menuName = "CharacterTool/Character Avatar")]
	public class CharacterAvatarDataSO : ScriptableObject
	{
		[SerializeField]
		public Avatar avatar;

		[SerializeField]
		public CharacterData characterData;
	}
}
