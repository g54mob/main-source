using System.Collections.Generic;
using CTS;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class ConstructionParams : MonoSingleton<ConstructionParams>
{
	[SerializeField]
	[BoxGroup("Room Assignation Data")]
	private SerializableDictionary<NavigationArea, NavigationMask> _exitMasks = new SerializableDictionary<NavigationArea, NavigationMask>();

	[field: SerializeField]
	public AnimationCurve SpawnScaleCurveY { get; private set; }

	[field: SerializeField]
	public float CellSize { get; private set; } = 1f;

	[field: SerializeField]
	public WallMeshSO WallSO { get; private set; }

	[field: SerializeField]
	public WallMeshSO LargeWallSO { get; private set; }

	[field: SerializeField]
	public BuildingFloor FloorPrefab { get; private set; }

	[field: SerializeField]
	public Material PrevisualConstructionMaterial { get; private set; }

	[field: SerializeField]
	public Material PrevisualDestroyMaterial { get; private set; }

	[field: SerializeField]
	[field: BoxGroup("Room Assignation Data")]
	public SerializableDictionary<NavigationArea, Material> RoomAssignationMaterials { get; private set; }

	[field: SerializeField]
	[field: BoxGroup("Room Assignation Data")]
	public Material WorkerAssignationMaterial { get; private set; }

	public IReadOnlyDictionary<NavigationArea, NavigationMask> ExitMasks => _exitMasks.Dict;

	[field: SerializeField]
	[field: BoxGroup("Gameplay")]
	public bool CanOverrideOtherRoom { get; private set; }

	[field: SerializeField]
	[field: BoxGroup("Gameplay")]
	public int InteriorMinimumCellCount { get; private set; } = 6;

	[field: SerializeField]
	[field: BoxGroup("Gameplay")]
	public int InteriorMinimumZoneLenght { get; private set; } = 2;

	[field: SerializeField]
	[field: BoxGroup("Gameplay")]
	public bool CheckNearCells { get; private set; }

	[field: SerializeField]
	[field: BoxGroup("Gameplay")]
	[field: MinValue(0)]
	[field: ShowIf("CheckNearCells")]
	public int NearCellDistance { get; private set; } = 2;

	public Material PrevisualMaterial
	{
		get
		{
			if (MonoSingleton<ConstructionSystem>.Instance.CurrentMode == EConstructionMode.Destruction)
			{
				return PrevisualDestroyMaterial;
			}
			return PrevisualConstructionMaterial;
		}
	}

	protected override void SingletonAwake()
	{
	}

	protected override void OnSingletonDestroy()
	{
	}

	public BuildingWall GetWallPrefab(bool largeWall)
	{
		if (largeWall)
		{
			return LargeWallSO.WallPrefab;
		}
		return WallSO.WallPrefab;
	}

	public Mesh GetMeshFromWallType(EWallType wallType, bool largeWall)
	{
		if (largeWall)
		{
			return GetMeshFromWallType(wallType, LargeWallSO);
		}
		return GetMeshFromWallType(wallType, WallSO);
	}

	private Mesh GetMeshFromWallType(EWallType wallType, WallMeshSO so)
	{
		return wallType switch
		{
			EWallType.Simple => so.SimpleWall, 
			EWallType.InteriorCorner => so.InteriorCornerWall, 
			EWallType.LeftInteriorCorner => so.LeftInteriorCornerWall, 
			EWallType.RightInteriorCorner => so.RightInteriorCornerWall, 
			EWallType.ExteriorCorner => so.ExteriorCornerWall, 
			EWallType.LeftExteriorCorner => so.LeftExteriorCornerWall, 
			EWallType.RightExteriorCorner => so.RightExteriorCornerWall, 
			EWallType.LeftSwiftCorner => so.LeftSwiftCornerWall, 
			EWallType.RightSwiftCorner => so.RightSwiftCornerWall, 
			_ => null, 
		};
	}

	public static Quaternion GetRotationFromRotationAngle(ERotationAngle angle)
	{
		return angle switch
		{
			ERotationAngle.South => Quaternion.identity, 
			ERotationAngle.West => Quaternion.Euler(0f, 90f, 0f), 
			ERotationAngle.Nord => Quaternion.Euler(0f, 180f, 0f), 
			ERotationAngle.East => Quaternion.Euler(0f, 270f, 0f), 
			_ => Quaternion.identity, 
		};
	}
}
