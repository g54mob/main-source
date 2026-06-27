using UnityEngine;

namespace Restory.Data.GameDialogues
{
	[CreateAssetMenu(menuName = "Restory/GameDialogues/GameDialogue", fileName = "GameDialogue - Name")]
	public class GameDialogue : ScriptableObject
	{
		[SerializeField]
		private string headerLocalizationKey;

		[SerializeField]
		private string bodyLocalizationKey;

		public string HeaderLocalizationKey => headerLocalizationKey;

		public string BodyLocalizationKey => bodyLocalizationKey;
	}
}
