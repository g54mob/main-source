using UnityEngine;

[CreateAssetMenu(fileName = "WallMeshSO", menuName = "Construction/WallMeshSO")]
public class WallMeshSO : ScriptableObject
{
	[field: SerializeField]
	public BuildingWall WallPrefab { get; private set; }

	[field: SerializeField]
	public Mesh SimpleWall { get; private set; }

	[field: SerializeField]
	public Mesh InteriorCornerWall { get; private set; }

	[field: SerializeField]
	public Mesh LeftInteriorCornerWall { get; private set; }

	[field: SerializeField]
	public Mesh RightInteriorCornerWall { get; private set; }

	[field: SerializeField]
	public Mesh ExteriorCornerWall { get; private set; }

	[field: SerializeField]
	public Mesh LeftExteriorCornerWall { get; private set; }

	[field: SerializeField]
	public Mesh RightExteriorCornerWall { get; private set; }

	[field: SerializeField]
	public Mesh LeftSwiftCornerWall { get; private set; }

	[field: SerializeField]
	public Mesh RightSwiftCornerWall { get; private set; }
}
