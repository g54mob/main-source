using UnityEngine;

[RequireComponent(typeof(PlacementComponent))]
public class MapObject : MonoBehaviour, ISelectable
{
	protected PlacementComponent placementComponent;

	protected virtual void Awake()
	{
		placementComponent = GetComponent<PlacementComponent>();
	}

	protected virtual void Start()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	public virtual void Select()
	{
	}

	public virtual void Deselect()
	{
	}
}
