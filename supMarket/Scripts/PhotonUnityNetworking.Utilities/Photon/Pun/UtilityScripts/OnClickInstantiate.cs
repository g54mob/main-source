using UnityEngine;
using UnityEngine.EventSystems;

namespace Photon.Pun.UtilityScripts
{
	public class OnClickInstantiate : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public enum InstantiateOption
		{
			Mine = 0,
			Scene = 1
		}

		public PointerEventData.InputButton Button;

		public KeyCode ModifierKey;

		public GameObject Prefab;

		[SerializeField]
		private InstantiateOption InstantiateType;

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
