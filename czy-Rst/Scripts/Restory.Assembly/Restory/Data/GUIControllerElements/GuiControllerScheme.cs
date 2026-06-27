using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Scripting;

namespace Restory.Data.GUIControllerElements
{
	[Preserve]
	[CreateAssetMenu(menuName = "Restory/GUI/Controllers/GuiControllerScheme", fileName = "New GuiControllerScheme")]
	public sealed class GuiControllerScheme : SerializedScriptableObject
	{
		[SerializeField]
		private ControllerId controllerId;

		[SerializeField]
		private GameObject schemeView;

		public ControllerId ControllerId => controllerId;

		public GameObject SchemeView => schemeView;
	}
}
