using System.Collections.Generic;
using UnityEngine;

public class SortableBox : MonoBehaviour
{
	public bool IsPlaced;

	public Vector3 StartPos;

	public Vector3Int Size;

	public List<BoxCell> cells;

	[SerializeField]
	private Renderer m_BoundsProvider;

	public float BoxVolume;

	private Rigidbody m_BoxRigidbody;

	private BoxCollider m_BoxCollider;

	public Bounds LocalBounds => default(Bounds);

	public BoxCollider BoxCollider => null;

	public Rigidbody BoxRigidbody => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[ContextMenu("CreateCells")]
	private void CreateCells()
	{
	}
}
