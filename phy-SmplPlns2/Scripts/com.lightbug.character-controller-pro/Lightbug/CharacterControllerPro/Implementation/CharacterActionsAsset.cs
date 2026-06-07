using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[CreateAssetMenu(menuName = "Character Controller Pro/Implementation/Inputs/Character actions asset")]
	public class CharacterActionsAsset : ScriptableObject
	{
		[SerializeField]
		private string[] boolActions;

		[SerializeField]
		private string[] floatActions;

		[SerializeField]
		private string[] vector2Actions;
	}
}
