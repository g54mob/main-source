using UnityEngine;
using UnityEngine.EventSystems;

namespace GRP
{
	public class BoardHandle : MonoBehaviour, IDragHandler, IEventSystemHandler
	{
		public BoardView board;

		public Vector2 size;

		public Vector2 position;

		public void OnDrag(PointerEventData eventData)
		{
		}
	}
}
