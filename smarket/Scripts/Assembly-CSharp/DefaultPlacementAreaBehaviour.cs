using System.Collections.Generic;
using UnityEngine;

public class DefaultPlacementAreaBehaviour : PlacementAreaBehaviour
{
	public const float MovementDuration = 0.3f;

	private readonly IPlacementArea m_PlacementArea;

	private readonly Rigidbody m_AttachedRigidbody;

	private readonly Collider[] m_RigidbodyColliders;

	private readonly List<SortableBox> m_SortableBoxes;

	private readonly GameObject m_Owner;

	public DefaultPlacementAreaBehaviour(GameObject owner, List<SortableBox> sortableBoxes)
	{
	}

	public override void OnAdded(SortableBox sortableBox)
	{
	}

	public override void OnRemoved(SortableBox box)
	{
	}

	public override void HandlePlacement(SortableBox sortableBox, Vector3 localPosition, Vector3 localEulerAngles)
	{
	}

	public override void ToggleCollision(SortableBox box, bool value)
	{
	}
}
