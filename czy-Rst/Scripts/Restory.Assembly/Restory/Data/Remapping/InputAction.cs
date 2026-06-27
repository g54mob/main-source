using Sirenix.OdinInspector;
using UnityEngine;

namespace Restory.Data.Remapping
{
	[CreateAssetMenu(fileName = "ActionId", menuName = "Restory/Remapping/ActionId", order = 0)]
	public class InputAction : SerializedScriptableObject
	{
		[SerializeField]
		private string id;

		public string Id => id;

		public InputAction(string id)
		{
			this.id = id;
		}
	}
}
