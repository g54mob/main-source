using UnityEngine;
using UnityEngine.EventSystems;

namespace GRP
{
	public class BoardBar : MonoBehaviour, IDragHandler, IEventSystemHandler
	{
		public BoardView board;

		public void OnDrag(PointerEventData eventData)
		{
		}
	}
}
