using UnityEngine;

public class OutlineSelection : MonoBehaviour
{
	private Transform highlight;

	private RaycastHit raycastHit;

	private Ray ray;

	[SerializeField]
	private LayerMask interactableLayerMask;
}
