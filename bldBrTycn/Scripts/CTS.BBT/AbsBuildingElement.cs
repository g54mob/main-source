using System.Collections;
using CTS;
using UnityEngine;

public abstract class AbsBuildingElement : MonoBehaviour
{
	private RoomBuilding _linkedRoom;

	[HideInInspector]
	public bool isBuilded;

	protected int? affectedMaterial;

	public ConstructionCell LinkedCell { get; set; }

	public RoomBuilding LinkedRoom
	{
		get
		{
			return _linkedRoom;
		}
		set
		{
			if (!(_linkedRoom == value))
			{
				SetLinkedRoom(value);
			}
		}
	}

	public SurfaceObject SurfaceObject { get; private set; }

	public int? PaintMaterial => affectedMaterial;

	private void Awake()
	{
		SurfaceObject = GetComponent<SurfaceObject>();
	}

	protected virtual void SetLinkedRoom(RoomBuilding room)
	{
		_linkedRoom = room;
	}

	public void ChangeVisibility(bool visible)
	{
		SurfaceObject.ChangeVisibility(visible);
	}

	public abstract void AppliqMaterial();

	public void SetMaterial(Material material)
	{
		SurfaceObject?.ChangeMaterial(material);
	}

	public void PlaySpawnEffect()
	{
		StopCoroutine(Spawn());
		StartCoroutine(Spawn());
	}

	public abstract void UpdateVisual();

	protected abstract IEnumerator Spawn();
}
