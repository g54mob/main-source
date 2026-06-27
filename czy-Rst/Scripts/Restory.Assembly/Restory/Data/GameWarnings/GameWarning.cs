using UnityEngine;

namespace Restory.Data.GameWarnings
{
	[CreateAssetMenu(menuName = "Restory/GameWarnings/GameWarning", fileName = "GameWarning - 00 - Name")]
	public class GameWarning : ScriptableObject
	{
		[SerializeField]
		private string messageLocalizationKey;

		public string MessageLocalizationKey => messageLocalizationKey;
	}
}
