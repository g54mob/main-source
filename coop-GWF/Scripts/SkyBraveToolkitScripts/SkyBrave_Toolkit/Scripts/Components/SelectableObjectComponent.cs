using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	[RequireComponent(typeof(Collider))]
	public class SelectableObjectComponent : MonoBehaviour
	{
		[Header("Logic")]
		public bool IsSelected;

		public bool IsHovered;

		public Vector3 SelectionWorldPos;

		[SerializeField]
		private UnityEvent onSelected;

		[SerializeField]
		private UnityEvent onHovered;

		[SerializeField]
		private UnityEvent onHoverExit;

		public void SelectObject(Vector3 selectionWorldPos)
		{
			IsSelected = true;
			SelectionWorldPos = selectionWorldPos;
			onSelected.Invoke();
		}

		public void HoverObject(Vector3 selectionWorldPos)
		{
			IsHovered = true;
			SelectionWorldPos = selectionWorldPos;
			onHovered.Invoke();
		}

		public void OnHoverExit()
		{
			IsHovered = false;
			SelectionWorldPos = Vector3.zero;
			onHoverExit.Invoke();
		}
	}
}
