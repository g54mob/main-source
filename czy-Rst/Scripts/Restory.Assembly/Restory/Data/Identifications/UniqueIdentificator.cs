using UnityEngine;

namespace Restory.Data.Identifications
{
	[CreateAssetMenu(menuName = "Restory/Data/Identificators/Create UniqueIdentificator", fileName = "UniqueIdentificator - Name", order = 0)]
	public class UniqueIdentificator : ScriptableObject
	{
		[SerializeField]
		private string id = string.Empty;

		public string ID => id;
	}
}
