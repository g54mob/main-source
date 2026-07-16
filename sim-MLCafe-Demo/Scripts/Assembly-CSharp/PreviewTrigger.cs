using System.Collections.Generic;
using UnityEngine;

public class PreviewTrigger : MonoBehaviour
{
	private List<Collider> collisions = new List<Collider>();

	private BoxCollider boxCollider;

	private void Start()
	{
		boxCollider = GetComponent<BoxCollider>();
	}

	private void Update()
	{
		if (PreviewSystem.IsWallMount())
		{
			boxCollider.includeLayers = LayerMask.NameToLayer("WallSurface");
		}
		else
		{
			boxCollider.includeLayers = LayerMask.NameToLayer("Interactable");
		}
	}

	public bool IsOverlapping()
	{
		collisions.RemoveAll((Collider c) => c == null);
		return collisions.Count > 0;
	}

	public bool IsOverlapping(LayerMask excludeMasks)
	{
		collisions.RemoveAll((Collider c) => c == null);
		collisions.RemoveAll((Collider c) => IsInLayerMask(c.gameObject, excludeMasks) || IsInLayerMask(c.gameObject, LayerMask.NameToLayer("OnlyInteractableCollision")));
		return collisions.Count > 0;
	}

	public static bool IsInLayerMask(GameObject obj, LayerMask mask)
	{
		return (mask.value & (1 << obj.layer)) != 0;
	}

	public void Clear()
	{
		collisions.Clear();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other != null)
		{
			collisions.Add(other);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other != null)
		{
			collisions.Remove(other);
		}
	}
}
